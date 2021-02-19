// File: equipments.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Perm from "../permission"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import * as Pager from "../../_BaseApp/src/theme/pager"
import * as Lookup from "../admin/lookupdata"
import { tabTemplate, icon, prepareMenu, buildTitle, buildSubtitle } from "./layout_2"

declare const i18n: any;


export const NS = "App_equipments";

interface IState {
    totalcount: number
    id: number
    staffid: number
    staffid_text: string
    name: string
    catluid: number
    catluid_text: string
    price: number
    archive: boolean
    created: Date
    updated: Date
    updatedby: number
    by: string
    plusorder: number
    rn: number
}

interface IKey {
    staffid: number
}

interface IFilter {
    staffid: number
    catluid: number
}



let key: IKey;
let state = <Pager.IPagedList<IState, IFilter>>{
    list: [],
    pager: { pageNo: 1, pageSize: 20, sortColumn: "ID", sortDirection: "ASC", filter: {} }
};
let xtra: any;
let uiSelectedRow: { id: number };



const filterTemplate = (catluid: string) => {
    let filters: string[] = [];
    filters.push(Theme.renderDropdownFilter(NS, "catluid", catluid, i18n("CATLUID")));
    return filters.join("");
}

const trTemplate = (item: IState, rowNumber: number) => {
    return `
<tr class="${isSelectedRow(item.id) ? "is-selected" : ""}" onclick="${NS}.gotoDetail(${item.id});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.id)}</td>
    <td>${Misc.toStaticText(item.name)}</td>
    <td>${Misc.toStaticText(item.catluid_text)}</td>
    <td>${Misc.toStaticText(item.price)}</td>
    <td>${Misc.toStaticCheckbox(item.archive)}</td>
    <td>${Misc.toStaticText(item.plusorder)}</td>
    <td>${Misc.toStaticText(item.rn)}</td>
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
            ${Pager.sortableHeaderLink(pager, NS, i18n("NAME"), "name", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CATLUID_TEXT"), "catluid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PRICE"), "price", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ARCHIVE"), "archive", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PLUSORDER"), "plusorder", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RN"), "rn", "ASC")}
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
    buttons.push(Theme.buttonAddNew(NS, `#/equipment/new/${key.staffid}`, i18n("Add New")));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, i18n("equipments title"));
    let subtitle = buildSubtitle(xtra, i18n("equipments subtitle"));

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

export const fetchState = (staffid: number) => {
    Router.registerDirtyExit(null);
    state.pager.filter.staffid = staffid;
    return App.POST(`/equipment/search/${staffid}/staff`, state.pager)
        .then(payload => {
            state = payload;
            xtra = payload.xtra;
            key = { staffid };
        })
        .then(Lookup.fetch_cat())
};

export const fetch = (params: string[]) => {
    let staffid = +params[0];
    App.prepareRender(NS, i18n("equipments"));
    prepareMenu();
    fetchState(staffid)
        .then(App.render)
        .catch(App.render);
};

const refresh = () => {
    App.prepareRender(NS, i18n("equipments"));
    App.POST(`/equipment/search/${key.staffid}/staff`, state.pager)
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
    let lookup_cat = Lookup.get_cat(year);
    let catluid = Theme.renderOptions(lookup_cat, state.pager.filter.catluid, true);

    const filter = filterTemplate(catluid);
    const search = Pager.searchTemplate(state.pager, NS);
    const pager = Pager.render(state.pager, NS, [20, 50], search, filter);
    const table = tableTemplate(tbody, state.pager);

    const tab = tabTemplate(key.staffid, xtra);
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

export const filter_catluid = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let catluid = (value.length > 0 ? +value : undefined);
    if (catluid == state.pager.filter.catluid)
        return;
    state.pager.filter.catluid = catluid;
    state.pager.pageNo = 1;
    refresh();
};

export const gotoDetail = (id: number) => {
    setSelectedRow(id);
    Router.goto(`#/equipment/${id}/${key.staffid}`);
};
