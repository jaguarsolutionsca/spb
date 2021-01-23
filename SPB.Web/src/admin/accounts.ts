// File: accounts.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Perm from "../permission"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import * as Pager from "../../_BaseApp/src/theme/pager"
import * as Lookup from "../admin/lookupdata"
import * as Layout from "./layout"
import { tabTemplate, icon, prepareMenu } from "./layout"

declare const i18n: any;


export const NS = "App_accounts";

interface IState {
    uid: number
    totalcount: number
    cie_text: string
    email: string
    roleluid_text: string
    lastactivity: Date
    firstname: string
    lastname: string
    readytoarchive: boolean
    archive: boolean
}

interface IKey {
    cie: number
}

interface IFilter {
    cie: number
    archive: boolean
    readyToArchive: boolean
}



let key: IKey;
let state = <Pager.IPagedList<IState, IFilter>>{
    list: [],
    pager: { pageNo: 1, pageSize: 20, sortColumn: "EMAIL", sortDirection: "ASC", filter: { cie: App.cie, archive: undefined, readyToArchive: undefined } }
};
let uiSelectedRow: { uid: number };



let autoArchiveButton = () => {
    let title = i18n("Auto Archive");
    let helpText = i18n("<p><b>Note:</b> This will archive all records having the <b><em>Ready to Archive</em></b> flag set.</p>");
    let onclick = `${NS}.autoArchive()`;
    return Theme.renderButtonWithConfirm(title, "far fa-lock-open-alt", helpText, onclick, false, false, true);
};

const filterTemplate = (archive: string, readytoarchive: string) => {
    let filters: string[] = [];
    filters.push(Theme.renderDropdownFilter(NS, "archive", archive, i18n("ARCHIVE")));
    filters.push(Theme.renderDropdownFilter(NS, "readytoarchive", readytoarchive, i18n("READYTOARCHIVE")));
    return filters.join("");
}

const trTemplate = (item: IState, rowNumber: number) => {
    return `
<tr class="${isSelectedRow(item.uid) ? "is-selected" : ""}" onclick="${NS}.gotoDetail(${item.uid});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.email)}</td>
    <td>${Misc.toStaticText(item.firstname)}</td>
    <td>${Misc.toStaticText(item.lastname)}</td>
    <td>${Misc.toStaticText(item.roleluid_text)}</td>
    <td>${Misc.toStaticDateTime(item.lastactivity)}</td>
    <td>${Misc.toStaticCheckbox(item.readytoarchive)}</td>
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
            ${Pager.sortableHeaderLink(pager, NS, i18n("EMAIL"), "email", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FIRSTNAME"), "firstname", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LASTNAME"), "lastname", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ROLEMASK"), "roleluid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LASTACTIVITY"), "lastactivity", "DESC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("READYTOARCHIVE"), "readytoarchive", "DESC")}
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
    buttons.push(autoArchiveButton());

    return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${icon}"></i> ${i18n("All accounts")}</div>
            <div class="subtitle">${i18n("List of accounts")}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", Theme.renderListActionButtons2(NS, i18n("Add New"), buttons))}
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

export const fetchState = (cie: number) => {
    Router.registerDirtyExit(null);
    state.pager.filter.cie = cie;
    return App.POST("/account/search/", state.pager)
        .then(payload => {
            state = payload;
            key = { cie };
        })
};

export const fetch = (params: string[]) => {
    let cie = Perm.getCie(params);
    App.prepareRender(NS, i18n("accounts"));
    prepareMenu();
    fetchState(cie)
        .then(App.render)
        .catch(App.render);
};

const refresh = () => {
    App.prepareRender(NS, i18n("accounts"));
    App.POST("/account/search/", state.pager)
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

    let year = Perm.getCurrentYear();

    let archive = Theme.renderNullableBooleanOptionsReverse(state.pager.filter.archive, ["All", i18n("Archived"), i18n("Active")]);
    let readytoarchive = Theme.renderNullableBooleanOptions(state.pager.filter.readyToArchive, ["All", i18n("Ready"), i18n("Not Ready")]);

    const filter = filterTemplate(archive, readytoarchive);
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

const setSelectedRow = (uid: number) => {
    if (uiSelectedRow == undefined) uiSelectedRow = { uid };
    uiSelectedRow.uid = uid;
};

const isSelectedRow = (uid: number) => {
    if (uiSelectedRow == undefined) return false;
    return (uiSelectedRow.uid == uid);
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

export const filter_archive = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let archive = (value.length > 0 ? value == "true" : undefined);
    if (archive == state.pager.filter.archive)
        return;
    state.pager.filter.archive = archive;
    state.pager.pageNo = 1;
    refresh();
};

export const filter_readytoarchive = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let readytoarchive = (value.length > 0 ? value == "true" : undefined);
    if (readytoarchive == state.pager.filter.readyToArchive)
        return;
    state.pager.filter.readyToArchive = readytoarchive;
    state.pager.pageNo = 1;
    refresh();
};

export const gotoDetail = (cid: number) => {
    setSelectedRow(cid);
    Router.goto(`#/admin/account/${cid}`);
};

export const create = () => {
    Router.goto(`#/admin/account/new`);
};

export const autoArchive = () => {
    App.POST("/account/auto-archive", null)
        .then(_ => {
            Misc.toastSuccess(i18n("Auto Archive Executed"));
            Router.goto(`#/admin/accounts`, 10);
        })
        .catch(App.render);
}
