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
    totalCount: number
    id: number
    email: string
    roleMask: number
    roleMask_Text: string
    resetGuid: string
    resetExpiryUtc: Date
    lastActivityUtc: Date
    archive: boolean
    createdUtc: Date
    updatedUtc: Date
    updatedBy: number
    firstName: string
    lastName: string
    regionLUID: number
    regionLUID_Text: string
    districtLUID: number
    districtLUID_Text: string
    phone1: string
    phone2: string
    fax: string
    readyToArchive: boolean
    hasPendingEmail: boolean
    address: string
    town: string
    postalCode: string
}

interface IKey {

}

interface IFilter {
    archive: boolean
    regionLUID: number
    districtLUID: number
    readyToArchive: boolean
}

let key: IKey;
let state = <Pager.IPagedList<IState, IFilter>>{
    list: [],
    pager: { pageNo: 1, pageSize: 20, sortColumn: "EMAIL", sortDirection: "ASC", filter: { archive: undefined, regionLUID: undefined, districtLUID: undefined, readyToArchive: undefined } }
};
let uiSelectedRow: { id: number };

let autoArchiveButton = () => {
    let title = i18n("Auto Archive");
    let helpText = i18n("<p><b>Note:</b> This will archive all records having the <b><em>Ready to Archive</em></b> flag set.</p>");
    let onclick = `${NS}.autoArchive()`;
    return Theme.renderButtonWithConfirm(title, "far fa-lock-open-alt", helpText, onclick, false, false, true);
};

const filterTemplate = (archive: string, regionLUID: string, districtLUID: string, readyToArchive: string) => {
    let filters: string[] = [];
    filters.push(Theme.renderDropdownFilter(NS, "regionLUID", regionLUID, i18n("REGION")));
    filters.push(Theme.renderDropdownFilter(NS, "districtLUID", districtLUID, i18n("DISTRICT")));
    filters.push(Theme.renderDropdownFilter(NS, "archive", archive, i18n("ARCHIVE")));
    filters.push(Theme.renderDropdownFilter(NS, "readyToArchive", readyToArchive, i18n("READYTOARCHIVE")));
    return filters.join("");
}

const trTemplate = (item: IState, rowNumber: number) => {
    return `
<tr class="${isSelectedRow(item.id) ? "is-selected" : ""}" onclick="${NS}.gotoDetail(${item.id});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.email)}</td>
    <td>${Misc.toStaticText(item.firstName)}</td>
    <td>${Misc.toStaticText(item.lastName)}</td>
    <td>${Misc.toStaticText(item.regionLUID_Text)}</td>
    <td>${Misc.toStaticText(item.districtLUID_Text)}</td>
    <td>${Misc.toStaticText(item.phone1)}</td>
    <!--<td>${Misc.toStaticText(item.roleMask_Text)}</td>-->
    <td>${Misc.toStaticDateTime(item.lastActivityUtc)}</td>
    <td>${Misc.toStaticCheckbox(item.readyToArchive)}</td>
    <td>${Misc.toStaticCheckbox(item.hasPendingEmail)}</td>
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
            ${Pager.sortableHeaderLink(pager, NS, i18n("FIRSTNAME"), "firstName", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LASTNAME"), "lastName", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REGION"), "regionLUID_Text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DISTRICT"), "districtLUID_Text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PHONE1"), "phone1", "ASC")}
            <!--${Pager.sortableHeaderLink(pager, NS, i18n("ROLEMASK"), "roleMask_Text", "ASC")}-->
            ${Pager.sortableHeaderLink(pager, NS, i18n("LASTACTIVITYUTC"), "lastActivityUtc", "DESC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("READYTOARCHIVE"), "readyToArchive", "DESC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("HASPENDINGEMAIL"), "hasPendingEmail", "DESC")}
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

const pageTemplate = (xtra, pager: string, table: string, tab: string, warning: string, dirty: string) => {
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

export const fetchState = (id: number) => {
    Router.registerDirtyExit(null);
    return App.GET(`/account/search/?${Pager.asParams(state.pager)}`)
        .then(payload => {
            state = payload;
            key = {};
        })
        .then(Lookup.fetch_region())
        .then(Lookup.fetch_district())
};

export const fetch = (params: string[]) => {
    let id = +params[0];
    App.prepareRender(NS, i18n("accounts"));
    prepareMenu();
    fetchState(id)
        .then(App.render)
        .catch(App.render);
};

const refresh = () => {
    App.prepareRender(NS, i18n("accounts"));
    App.GET(`/account/search/?${Pager.asParams(state.pager)}`)
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
    let lookup_region = Lookup.get_region(year);
    let lookup_district = Lookup.get_district(year);

    let regionLUID = Theme.renderOptions(lookup_region, state.pager.filter.regionLUID, true, "All");
    let districtLUID = Theme.renderOptions(lookup_district, state.pager.filter.districtLUID, true, "All");
    let archive = Theme.renderNullableBooleanOptionsReverse(state.pager.filter.archive, ["All", i18n("Archived"), i18n("Active")]);
    let readyToArchive = Theme.renderNullableBooleanOptions(state.pager.filter.readyToArchive, ["All", i18n("Ready"), i18n("Not Ready")]);

    const filter = filterTemplate(archive, regionLUID, districtLUID, readyToArchive);
    const search = Pager.searchTemplate(state.pager, NS);
    const pager = Pager.render(state.pager, NS, [20, 50], search, filter);
    const table = tableTemplate(tbody, state.pager);

    const tab = tabTemplate(null, null);
    return pageTemplate(state.xtra, pager, table, tab, dirty, warning);
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

export const filter_archive = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let archive = (value.length > 0 ? value == "true" : undefined);
    if (archive == state.pager.filter.archive)
        return;
    state.pager.filter.archive = archive;
    state.pager.pageNo = 1;
    refresh();
};

export const filter_regionLUID = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let regionLUID = (value.length > 0 ? +value : undefined);
    if (regionLUID == state.pager.filter.regionLUID)
        return;
    state.pager.filter.districtLUID = undefined;
    state.pager.filter.regionLUID = regionLUID;
    state.pager.pageNo = 1;
    refresh();
};

export const filter_districtLUID = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let districtLUID = (value.length > 0 ? +value : undefined);
    if (districtLUID == state.pager.filter.districtLUID)
        return;
    state.pager.filter.regionLUID = undefined;
    state.pager.filter.districtLUID = districtLUID;
    state.pager.pageNo = 1;
    refresh();
};

export const filter_readyToArchive = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let readyToArchive = (value.length > 0 ? value == "true" : undefined);
    if (readyToArchive == state.pager.filter.readyToArchive)
        return;
    state.pager.filter.readyToArchive = readyToArchive;
    state.pager.pageNo = 1;
    refresh();
};

export const gotoDetail = (id: number) => {
    setSelectedRow(id);
    Router.goto(`#/admin/account/${id}`);
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
