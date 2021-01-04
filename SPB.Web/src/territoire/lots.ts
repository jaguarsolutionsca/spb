// File: lots.ts

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


export const NS = "App_lots";

interface IState {
    totalcount: number
    cantonid: string
    cantonid_text: string
    rang: string
    lot: string
    municipaliteid: string
    municipaliteid_text: string
    superficie_total: number
    superficie_boisee: number
    proprietaireid: string
    proprietaireid_text: string
    contingentid: string
    contingentid_text: string
    contingent_date: Date
    droit_coupeid: string
    droit_coupeid_text: string
    droit_coupe_date: Date
    entente_paiementid: string
    entente_paiementid_text: string
    entente_paiement_date: Date
    actif: boolean
    id: number
    sequence: string
    partie: boolean
    matricule: string
    zoneid: string
    zoneid_text: string
    secteur: string
    cadastre: number
    reforme: boolean
    lotscomplementaires: string
    certifie: boolean
    numerocertification: string
    ogc: boolean
    json: string
}

interface IKey {

}

interface IFilter {

}



let key: IKey;
let state = <Pager.IPagedList<IState, IFilter>>{
    list: [],
    pager: { pageNo: 1, pageSize: 20, sortColumn: "ID", sortDirection: "ASC", filter: {} }
};
let xtra: any;
let uiSelectedRow: { id: number };



const filterTemplate = () => {
    let filters: string[] = [];

    return filters.join("");
}

const trTemplate = (item: IState, rowNumber: number) => {
    return `
<tr class="${isSelectedRow(item.id) ? "is-selected" : ""}" onclick="${NS}.gotoDetail(${item.id});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.cantonid_text)}</td>
    <td>${Misc.toStaticText(item.rang)}</td>
    <td>${Misc.toStaticText(item.lot)}</td>
    <td>${Misc.toStaticText(item.municipaliteid_text)}</td>
    <td>${Misc.toStaticText(item.superficie_total)}</td>
    <td>${Misc.toStaticText(item.superficie_boisee)}</td>
    <td>${Misc.toStaticText(item.proprietaireid_text)}</td>
    <td>${Misc.toStaticText(item.contingentid_text)}</td>
    <td>${Misc.toStaticDate(item.contingent_date)}</td>
    <td>${Misc.toStaticText(item.droit_coupeid_text)}</td>
    <td>${Misc.toStaticDate(item.droit_coupe_date)}</td>
    <td>${Misc.toStaticText(item.entente_paiementid_text)}</td>
    <td>${Misc.toStaticDate(item.entente_paiement_date)}</td>
    <td>${Misc.toStaticCheckbox(item.actif)}</td>
    <td>${Misc.toStaticText(item.id)}</td>
    <td>${Misc.toStaticText(item.sequence)}</td>
    <td>${Misc.toStaticCheckbox(item.partie)}</td>
    <td>${Misc.toStaticText(item.matricule)}</td>
    <td>${Misc.toStaticText(item.zoneid_text)}</td>
    <td>${Misc.toStaticText(item.secteur)}</td>
    <td>${Misc.toStaticText(item.cadastre)}</td>
    <td>${Misc.toStaticCheckbox(item.reforme)}</td>
    <td>${Misc.toStaticText(item.lotscomplementaires)}</td>
    <td>${Misc.toStaticCheckbox(item.certifie)}</td>
    <td>${Misc.toStaticText(item.numerocertification)}</td>
    <td>${Misc.toStaticCheckbox(item.ogc)}</td>
</tr>`;
};

const tableTemplate = (tbody: string, pager: Pager.IPager<IFilter>) => {
    return `
<div class="table-container">
<table class="table is-hoverable is-fullwidth">
    <thead>
        <tr>
            <th></th>
            ${Pager.sortableHeaderLink(pager, NS, i18n("CANTONID_TEXT"), "cantonid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RANG"), "rang", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LOT"), "lot", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MUNICIPALITEID_TEXT"), "municipaliteid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SUPERFICIE_TOTAL"), "superficie_total", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SUPERFICIE_BOISEE"), "superficie_boisee", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PROPRIETAIREID_TEXT"), "proprietaireid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CONTINGENTID_TEXT"), "contingentid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CONTINGENT_DATE"), "contingent_date", "DESC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DROIT_COUPEID_TEXT"), "droit_coupeid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DROIT_COUPE_DATE"), "droit_coupe_date", "DESC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ENTENTE_PAIEMENTID_TEXT"), "entente_paiementid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ENTENTE_PAIEMENT_DATE"), "entente_paiement_date", "DESC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ACTIF"), "actif", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ID"), "id", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SEQUENCE"), "sequence", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PARTIE"), "partie", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MATRICULE"), "matricule", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ZONEID_TEXT"), "zoneid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SECTEUR"), "secteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CADASTRE"), "cadastre", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REFORME"), "reforme", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LOTSCOMPLEMENTAIRES"), "lotscomplementaires", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CERTIFIE"), "certifie", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NUMEROCERTIFICATION"), "numerocertification", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("OGC"), "ogc", "ASC")}
            ${Pager.headerLink(i18n("TODO"))}
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
    buttons.push(Theme.buttonAddNew(NS, "#/lot/new", i18n("Add New")));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, i18n("lots title"));
    let subtitle = buildSubtitle(xtra, i18n("lots subtitle"));

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

export const fetchState = (id: number) => {
    Router.registerDirtyExit(null);
    return App.POST("/lot/search", state.pager)
        .then(payload => {
            state = payload;
            xtra = payload.xtra;
            key = {};
        })
        .then(Lookup.fetch_canton())
        .then(Lookup.fetch_municipalite())
        .then(Lookup.fetch_proprietaire())
        .then(Lookup.fetch_contingent())
        .then(Lookup.fetch_droit_coupe())
        .then(Lookup.fetch_entente_paiement())
};

export const fetch = (params: string[]) => {
    let id = +params[0];
    App.prepareRender(NS, i18n("lots"));
    fetchState(id)
        .then(App.render)
        .catch(App.render);
};

const refresh = () => {
    App.prepareRender(NS, i18n("lots"));
    App.POST("/lot/search", state.pager)
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

export const gotoDetail = (id: number) => {
    setSelectedRow(id);
    Router.goto(`#/lot/${id}`);
};
