// File: lookups.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Perm from "../permission"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import * as Pager from "../../_BaseApp/src/theme/pager"
import { tabTemplate, icon, prepareMenu, buildTitle, buildSubtitle } from "./layout"
import * as Lookup from "./lookupdata"

declare const i18n: any;


export const NS = "App_lookups";

interface IState {
    totalcount: number
    id: number
    cie: number
    cie_text: string
    groupe: string
    code: string
    description: string
    value1: string
    value2: string
    value3: string
    started: number
    ended: number
    sortorder: number
    created: Date
    updated: Date
    updatedby: number
    by: string
}

interface IKey {
    groupe: string
}

interface IFilter {
    cie: number
    groupe: string
    year: number
}



let key: IKey;
let state = <Pager.IPagedList<IState, IFilter>>{
    list: [],
    pager: { pageNo: 1, pageSize: 20, sortColumn: "DESCRIPTION", sortDirection: "ASC", filter: { cie: App.cie, groupe: undefined, year: Perm.getCurrentYear() } }
};
let xtra: any;
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
<tr class="${classes.join(" ")}" onclick="${NS}.gotoDetail(${item.id});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.id)}</td>
    <td>${Misc.toStaticText(item.cie_text)}</td>
    <td>${Misc.toStaticText(item.groupe)}</td>
    <td>${Misc.toStaticText(item.description)}</td>
    <td>${Misc.toStaticText(item.code)}</td>
    <td>${Misc.toStaticText(item.value1)}</td>
    <td>${Misc.toStaticText(item.value2)}</td>
    <td>${Misc.toStaticText(item.value3)}</td>
    <td>${Misc.toStaticText(item.started)}</td>
    <td>${Misc.toStaticText(item.ended)}</td>
    <td>${Misc.toStaticText(item.sortorder)}</td>
</tr>`;
};

const tableTemplate = (tbody: string, pager: Pager.IPager<IFilter>) => {
    return `
<div class="table-container">
<table class="table is-hoverable is-fullwidth">
    <thead>
        <tr>
            <th></th>
            ${Pager.sortableHeaderLink(pager, NS, i18n("ID"), "id", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CIE_TEXT"), "cie_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("GROUPE"), "groupe", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DESCRIPTION"), "description", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CODE"), "code", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE1"), "value1", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE2"), "value2", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE3"), "value3", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("STARTED"), "started", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ENDED"), "ended", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SORTORDER"), "sortorder", "ASC")}
        </tr>
    </thead>
    <tbody>
        ${tbody}
    </tbody>
</table>
</div>
`;
};

const pageTemplate = (pager: string, table: string, tab: string, warning: string, dirty: string) => {
    let readonly = false;

    let buttons: string[] = [];
    buttons.push(Theme.buttonAddNew(NS, `#/admin/lookup/new/${key.groupe}`, i18n("Add New")));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, `${i18n("Code Table:")} ${xtra.title}`);
    let subtitle = buildSubtitle(xtra, i18n("List of All Entries"));

    return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
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

export const fetchState = (cie: number, groupe: string) => {
    Router.registerDirtyExit(null);
    state.pager.filter.cie = cie;
    state.pager.filter.groupe = groupe;
    return App.POST("/lookup/search", state.pager)
        .then(payload => {
            state = payload;
            xtra = payload.xtra;
            key = { groupe };
        })
        .then(Lookup.fetch_lutGroup())
};

export const fetch = (params: string[]) => {
    let cie = Perm.getCie(params);
    let groupe = params[0];
    App.prepareRender(NS, i18n("lookups"));
    prepareMenu();
    fetchState(cie, groupe)
        .then(App.render)
        .catch(App.render);
};

const refresh = () => {
    App.prepareRender(NS, i18n("lookups"));
    App.POST("/lookup/search", state.pager)
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

    var year = Perm.getCurrentYear();
    var lookup_lutGroup = Lookup.get_lutGroup(year).map(one => <Lookup.LookupData>{
        id: one.code.toLowerCase(),
        description: one.description
    });

    let groupID = Theme.renderOptions(lookup_lutGroup, state.pager.filter.groupe, false);

    const filter = filterTemplate(groupID, state.pager.filter.year);
    const pager = Pager.render(state.pager, NS, [20, 50], null, filter);
    const table = tableTemplate(tbody, state.pager);

    const tab = tabTemplate(null, null, null);
    return pageTemplate(pager, table, tab, dirty, warning);
};

export const postRender = () => {
    if (!inContext()) return;
};

export const inContext = () => {
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
