// File: lookups.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Perm from "../permission"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import * as Pager from "../../_BaseApp/src/theme/pager"
import { tabTemplate, icon, prepareMenu } from "./layout"
import * as Lookup from "./lookupdata"

declare const i18n: any;


export const NS = "App_Lookups";

interface IState {
    totalCount: number
    id: number
    groupe: string
    code: string
    description: string
    value1: string
    value2: string
    value3: string
    started: string
    ended?: number
    sortOrder: number
    archive: boolean
    createdUtc: Date
    updatedUtc: Date
    updatedBy: number
    by: string
}

interface IKey {

}

interface IFilter {
    groupe: string
    year: number
}

let key: IKey;
let state = <Pager.IPagedList<IState, IFilter>>{
    list: [],
    pager: { pageNo: 1, pageSize: 20, sortColumn: "DESCRIPTION", sortDirection: "ASC", filter: { groupe: undefined, year: Perm.getCurrentYear() } }
};
let uiSelectedRow: { id: number };
let currentYear = new Date().getFullYear();


const filterTemplate = (groupID: string, year: number) => {
    let filters: string[] = [];
    filters.push(Theme.renderDropdownFilter(NS, "groupID", groupID, i18n("LOOKUP")));
    filters.push(Theme.renderNumberFilter(NS, "year", year, i18n("YEAR")));
    return filters.join("");
}

const trTemplate = (item: IState, rowNumber: number) => {
    let obsolete = item.ended != undefined && item.ended < (state.pager.filter.year ?? currentYear);

    let classes: string[] = [];
    if (isSelectedRow(item.id)) classes.push("is-selected");
    if (obsolete) classes.push("has-text-grey-light");

    return `
<tr class="${classes.join(" ")}" onclick="App_Lookups.gotoDetail(${item.id});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.description)}</td>
    <td>${Misc.toStaticText(item.code)}</td>
    <td>${Misc.toStaticText(item.value1)}</td>
    <td>${Misc.toStaticText(item.value2)}</td>
    <td>${Misc.toStaticText(item.value3)}</td>
    <td>${Misc.toStaticText(item.started)}</td>
    <td>${Misc.toStaticText(item.ended)}</td>
    <td>${Misc.toStaticText(item.sortOrder)}</td>
</tr>`;
};

const tableTemplate = (tbody: string, pager: Pager.IPager<IFilter>) => {
    return `
<div class="table-container">
<table class="table is-hoverable is-fullwidth">
    <thead>
        <tr>
            <th></th>
            ${Pager.sortableHeaderLink(pager, NS, i18n("DESCRIPTION"), "description", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CODE"), "code", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE1"), "value1", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE2"), "value2", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE3"), "value3", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("STARTED"), "started", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ENDED"), "ended", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SORTORDER"), "sortOrder", "ASC")}
        </tr>
    </thead>
    <tbody>
        ${tbody}
    </tbody>
</table>
</div>
`;
};

const pageTemplate = (xtra, pager: string, table: string, tab: string, warning: string, dirty: string) => {
    let readonly = false;

    let actions = Theme.renderListActionButtons2(NS, i18n("Add New"));

    return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
                <div class="title"><i class="${icon}"></i> ${i18n("Code Table:")} ${xtra.title}</div>
                <div class="subtitle">${i18n("List of All Entries")}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-pager", pager)}
    ${Theme.wrapContent("js-uc-list", table)}
</div>
</div>

</form>
`;
};

export const fetchState = (groupe: string) => {
    Router.registerDirtyExit(null);
    state.pager.filter.groupe = groupe;
    return App.GET(`/lookup/?${Pager.asParams(state.pager)}`)
        .then(payload => {
            state = payload;
            key = {};
        })
        .then(Lookup.fetch_lutGroup())
};

export const fetch = (params: string[]) => {
    let groupe = params[0];
    App.prepareRender(NS, i18n("Lookups"));
    prepareMenu();
    fetchState(groupe)
        .then(App.render)
        .catch(App.render);
};

const refresh = () => {
    App.prepareRender(NS, i18n("Lookups"));
    App.GET(`/lookup/?${Pager.asParams(state.pager)}`)
        .then(payload => {
            state = payload;
        })
        .then(App.render)
        .catch(App.render);
};

export const render = () => {
    if (!inContext()) return "";
    if (App.fatalError()) return App.fatalErrorTemplate();
    if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
        return App.warningTemplate() || App.unexpectedTemplate();

    let warning = App.warningTemplate();
    let dirty = "";
    const tbody = state.list.reduce((html, item, index) => {
        let rowNumber = Pager.rowNumber(state.pager, index);
        return html + trTemplate(item, rowNumber);
    }, "");

    let groupID = Theme.renderOptions(Lookup.lutGroup, state.pager.filter.groupe, false);

    const filter = filterTemplate(groupID, state.pager.filter.year);
    const pager = Pager.render(state.pager, NS, [20, 50], null, filter);
    const table = tableTemplate(tbody, state.pager);

    const tab = tabTemplate(null, null);
    return pageTemplate(null, pager, table, tab, dirty, warning);
};

export const postRender = () => {
    if (!inContext()) return;
};

const inContext = () => {
    return App.inContext(NS);
};

const setSelectedRow = (id: number) => {
    if (uiSelectedRow == undefined) uiSelectedRow = { id };
    uiSelectedRow.id = id;
};

const isSelectedRow = (id: number) => {
    if (uiSelectedRow == undefined) return false;
    return (uiSelectedRow.id == id);
};

export const goto = (pageNo: number, pageSize: number) => {
    state.pager.pageNo = pageNo;
    state.pager.pageSize = pageSize;
    refresh();
};

export const sortBy = (columnName: string, direction: string) => {
    state.pager.pageNo = 1;
    state.pager.sortColumn = columnName;
    state.pager.sortDirection = direction;
    refresh();
};

export const search = (element) => {
    state.pager.searchText = element.value;
    state.pager.pageNo = 1;
    refresh();
};

export const filter_groupID = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let groupe = (value.length > 0 ? value : undefined);
    if (groupe == state.pager.filter.groupe)
        return;
    Router.goto(`#/admin/lookups/${groupe}`);
};

export const filter_year = (element: HTMLInputElement) => {
    let value = element.value;
    let year = (value.length > 0 ? +value : undefined);
    if (year == state.pager.filter.year)
        return;
    state.pager.filter.year = year;
    state.pager.pageNo = 1;
    refresh();
};

export const gotoDetail = (id: number) => {
    setSelectedRow(id);
    Router.goto(`#/admin/lookup/${id}`);
};

export const create = () => {
    Router.goto(`#/admin/lookup/new/${state.pager.filter.groupe}`);
};
