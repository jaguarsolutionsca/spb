// File: companys.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Perm from "../permission"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import * as Pager from "../../_BaseApp/src/theme/pager"
import * as Lookup from "../admin/lookupdata"
import * as Layout from "./layout"
import { tabTemplate, icon, buildTitle, buildSubtitle } from "./layout"

declare const i18n: any;


export const NS = "App_companys";

interface IState {
    totalcount: number
    cie: number
    name: string
    archive: boolean
    created: Date
    updated: Date
    accounts: number
    lookups: number
}

interface IKey {

}

interface IFilter {

}



let key: IKey;
let state = <Pager.IPagedList<IState, IFilter>>{
    list: [],
    pager: { pageNo: 1, pageSize: 20, sortColumn: "CIE", sortDirection: "ASC", filter: {} }
};
let xtra: any;
let uiSelectedRow: { cie: number };



const filterTemplate = () => {
    let filters: string[] = [];

    return filters.join("");
}

const trTemplate = (item: IState, rowNumber: number) => {
    return `
<tr class="${isSelectedRow(item.cie) ? "is-selected" : ""}" onclick="${NS}.gotoDetail(${item.cie});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.cie)}</td>
    <td>${Misc.toStaticText(item.name)}</td>
    <td>${item.accounts ? `<a href="#/admin/accounts/?cie=${item.cie}" onclick="event.stopPropagation()">${item.accounts} <i class="fal fa-link"></i></a>` : `<span style="opacity: 0.25">0</span>`}</td>
    <td>${item.lookups ? `<a href="#/admin/lookups/?cie=${item.cie}" onclick="event.stopPropagation()">${item.lookups} <i class="fal fa-link"></i></a>` : `<span style="opacity: 0.25">0</span>`}</td>
    <td>${Misc.toStaticCheckbox(item.archive)}</td>
</tr>`;
};

const tableTemplate = (tbody: string, pager: Pager.IPager<IFilter>) => {
    return `
<div class="table-container">
<table class="table is-hoverable is-fullwidth">
    <thead>
        <tr>
            <th></th>
            ${Pager.sortableHeaderLink(pager, NS, i18n("CIE"), "cie", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NAME"), "name", "ASC")}
            ${Pager.headerLink(i18n("ACCOUNTS"))}
            ${Pager.headerLink(i18n("LOOKUPS"))}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ARCHIVE"), "archive", "ASC")}
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
    buttons.push(Theme.buttonAddNew(NS, "#/admin/company/new", i18n("Add New")));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, i18n("Compagnies"));
    let subtitle = buildSubtitle(xtra, i18n("Liste des compagnies"));

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
    <div class="columns">
    <div class="column is-6 is-offset-3">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-pager", pager)}
    ${Theme.wrapContent("js-uc-list", table)}
    </div>
    </div>
</div>
</div>

</form>
`;
};

export const fetchState = (cie: number) => {
    Router.registerDirtyExit(null);
    return App.POST("/company/search", state.pager)
        .then(payload => {
            state = payload;
            xtra = payload.xtra;
            key = {};
        })
        .then(Lookup.fetch_autreFournisseur())
        .then(Lookup.fetch_compte())
};

export const fetch = (params: string[]) => {
    let cie = +params[0];
    App.prepareRender(NS, i18n("companys"));
    fetchState(cie)
        .then(App.render)
        .catch(App.render);
};

const refresh = () => {
    App.prepareRender(NS, i18n("companys"));
    App.POST("/company/search", state.pager)
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

    let year = Perm.getCurrentYear();//state.pager.filter.year;



    const filter = filterTemplate();
    const search = Pager.searchTemplate(state.pager, NS);
    const pager = Pager.render(state.pager, NS, [20, 50], search, filter);
    const table = tableTemplate(tbody, state.pager);

    const tab = tabTemplate(null, null);
    return pageTemplate(pager, table, tab, dirty, warning);
};

export const postRender = () => {
    if (!inContext()) return;
};

export const inContext = () => {
    return App.inContext(NS);
};

const setSelectedRow = (cie: number) => {
    if (uiSelectedRow == undefined) uiSelectedRow = { cie };
    uiSelectedRow.cie = cie;
};

const isSelectedRow = (cie: number) => {
    if (uiSelectedRow == undefined) return false;
    return (uiSelectedRow.cie == cie);
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

export const gotoDetail = (cie: number) => {
    setSelectedRow(cie);
    Router.goto(`#/admin/company/?cie=${cie}`);
};
