// File: proprietaires.ts

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


export const NS = "App_proprietaires";

interface IState {
    totalcount: number
    id: string
    cletri: string
    nom: string
    ausoinsde: string
    rue: string
    ville: string
    paysid: string
    paysid_text: string
    code_postal: string
    telephone: string
    telephone_poste: string
    telecopieur: string
    telephone2: string
    telephone2_desc: string
    telephone2_poste: string
    telephone3: string
    telephone3_desc: string
    telephone3_poste: string
    no_membre: string
    resident: string
    email: string
    www: string
    commentaires: string
    affichercommentaires: boolean
    depotdirect: boolean
    institutionbanquaireid: string
    institutionbanquaireid_text: string
    banque_transit: string
    banque_folio: string
    no_tps: string
    no_tvq: string
    payera: boolean
    payeraid: string
    statut: string
    rep_nom: string
    rep_telephone: string
    rep_telephone_poste: string
    rep_email: string
    enanglais: boolean
    actif: boolean
    mrcproducteurid: number
    paiementmanuel: boolean
    journal: boolean
    recoittps: boolean
    recoittvq: boolean
    modifiertrigger: boolean
    isproducteur: boolean
    istransporteur: boolean
    ischargeur: boolean
    isautre: boolean
    affichercommentairessurpermit: boolean
    pasemissionpermis: boolean
    generique: boolean
    membre_ogc: boolean
    inscrittps: boolean
    inscrittvq: boolean
    isogc: boolean
    rep2_nom: string
    rep2_telephone: string
    rep2_telephone_poste: string
    rep2_email: string
    rep2_commentaires: string
    json: string
}

interface IKey {

}

interface IFilter {
    nom: string
}



let key: IKey;
let state = <Pager.IPagedList<IState, IFilter>>{
    list: [],
    pager: { pageNo: 1, pageSize: 20, sortColumn: "ID", sortDirection: "ASC", filter: { nom: undefined } }
};
let xtra: any;
let uiSelectedRow: { id: string };



const filterTemplate = () => {
    let filters: string[] = [];
    // TODO (filters textbox)
    return filters.join("");
}

const trTemplate = (item: IState, rowNumber: number) => {
    return `
<tr class="${isSelectedRow(item.id) ? "is-selected" : ""}" onclick="${NS}.gotoDetail('${item.id}');">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.id)}</td>
    <td>${Misc.toStaticText(item.cletri)}</td>
    <td>${Misc.toStaticText(item.nom)}</td>
    <td>${Misc.toStaticText(item.ausoinsde)}</td>
    <td>${Misc.toStaticText(item.rue)}</td>
    <td>${Misc.toStaticText(item.ville)}</td>
    <td>${Misc.toStaticText(item.paysid_text)}</td>
    <td>${Misc.toStaticText(item.code_postal)}</td>
    <td>${Misc.toStaticText(item.telephone)}</td>
    <td>${Misc.toStaticText(item.telephone_poste)}</td>
    <td>${Misc.toStaticText(item.telecopieur)}</td>
    <td>${Misc.toStaticText(item.telephone2)}</td>
    <td>${Misc.toStaticText(item.telephone2_desc)}</td>
    <td>${Misc.toStaticText(item.telephone2_poste)}</td>
    <td>${Misc.toStaticText(item.telephone3)}</td>
    <td>${Misc.toStaticText(item.telephone3_desc)}</td>
    <td>${Misc.toStaticText(item.telephone3_poste)}</td>
    <td>${Misc.toStaticText(item.no_membre)}</td>
    <td>${Misc.toStaticText(item.resident)}</td>
    <td>${Misc.toStaticText(item.email)}</td>
    <td>${Misc.toStaticText(item.www)}</td>
    <td>${Misc.toStaticText(item.commentaires)}</td>
    <td>${Misc.toStaticCheckbox(item.affichercommentaires)}</td>
    <td>${Misc.toStaticCheckbox(item.depotdirect)}</td>
    <td>${Misc.toStaticText(item.institutionbanquaireid_text)}</td>
    <td>${Misc.toStaticText(item.banque_transit)}</td>
    <td>${Misc.toStaticText(item.banque_folio)}</td>
    <td>${Misc.toStaticText(item.no_tps)}</td>
    <td>${Misc.toStaticText(item.no_tvq)}</td>
    <td>${Misc.toStaticCheckbox(item.payera)}</td>
    <td>${Misc.toStaticText(item.payeraid)}</td>
    <td>${Misc.toStaticText(item.statut)}</td>
    <td>${Misc.toStaticText(item.rep_nom)}</td>
    <td>${Misc.toStaticText(item.rep_telephone)}</td>
    <td>${Misc.toStaticText(item.rep_telephone_poste)}</td>
    <td>${Misc.toStaticText(item.rep_email)}</td>
    <td>${Misc.toStaticCheckbox(item.enanglais)}</td>
    <td>${Misc.toStaticCheckbox(item.actif)}</td>
    <td>${Misc.toStaticText(item.mrcproducteurid)}</td>
    <td>${Misc.toStaticCheckbox(item.paiementmanuel)}</td>
    <td>${Misc.toStaticCheckbox(item.journal)}</td>
    <td>${Misc.toStaticCheckbox(item.recoittps)}</td>
    <td>${Misc.toStaticCheckbox(item.recoittvq)}</td>
    <td>${Misc.toStaticCheckbox(item.modifiertrigger)}</td>
    <td>${Misc.toStaticCheckbox(item.isproducteur)}</td>
    <td>${Misc.toStaticCheckbox(item.istransporteur)}</td>
    <td>${Misc.toStaticCheckbox(item.ischargeur)}</td>
    <td>${Misc.toStaticCheckbox(item.isautre)}</td>
    <td>${Misc.toStaticCheckbox(item.affichercommentairessurpermit)}</td>
    <td>${Misc.toStaticCheckbox(item.pasemissionpermis)}</td>
    <td>${Misc.toStaticCheckbox(item.generique)}</td>
    <td>${Misc.toStaticCheckbox(item.membre_ogc)}</td>
    <td>${Misc.toStaticCheckbox(item.inscrittps)}</td>
    <td>${Misc.toStaticCheckbox(item.inscrittvq)}</td>
    <td>${Misc.toStaticCheckbox(item.isogc)}</td>
    <td>${Misc.toStaticText(item.rep2_nom)}</td>
    <td>${Misc.toStaticText(item.rep2_telephone)}</td>
    <td>${Misc.toStaticText(item.rep2_telephone_poste)}</td>
    <td>${Misc.toStaticText(item.rep2_email)}</td>
    <td>${Misc.toStaticText(item.rep2_commentaires)}</td>
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
            ${Pager.sortableHeaderLink(pager, NS, i18n("CLETRI"), "cletri", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NOM"), "nom", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AUSOINSDE"), "ausoinsde", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RUE"), "rue", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VILLE"), "ville", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PAYSID_TEXT"), "paysid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CODE_POSTAL"), "code_postal", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE"), "telephone", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE_POSTE"), "telephone_poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELECOPIEUR"), "telecopieur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE2"), "telephone2", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE2_DESC"), "telephone2_desc", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE2_POSTE"), "telephone2_poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE3"), "telephone3", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE3_DESC"), "telephone3_desc", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE3_POSTE"), "telephone3_poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NO_MEMBRE"), "no_membre", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RESIDENT"), "resident", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("EMAIL"), "email", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("WWW"), "www", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COMMENTAIRES"), "commentaires", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERCOMMENTAIRES"), "affichercommentaires", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DEPOTDIRECT"), "depotdirect", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("INSTITUTIONBANQUAIREID_TEXT"), "institutionbanquaireid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("BANQUE_TRANSIT"), "banque_transit", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("BANQUE_FOLIO"), "banque_folio", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NO_TPS"), "no_tps", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NO_TVQ"), "no_tvq", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PAYERA"), "payera", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PAYERAID"), "payeraid", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("STATUT"), "statut", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP_NOM"), "rep_nom", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP_TELEPHONE"), "rep_telephone", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP_TELEPHONE_POSTE"), "rep_telephone_poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP_EMAIL"), "rep_email", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ENANGLAIS"), "enanglais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ACTIF"), "actif", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MRCPRODUCTEURID"), "mrcproducteurid", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PAIEMENTMANUEL"), "paiementmanuel", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("JOURNAL"), "journal", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RECOITTPS"), "recoittps", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RECOITTVQ"), "recoittvq", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MODIFIERTRIGGER"), "modifiertrigger", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISPRODUCTEUR"), "isproducteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISTRANSPORTEUR"), "istransporteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISCHARGEUR"), "ischargeur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISAUTRE"), "isautre", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERCOMMENTAIRESSURPERMIT"), "affichercommentairessurpermit", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PASEMISSIONPERMIS"), "pasemissionpermis", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("GENERIQUE"), "generique", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MEMBRE_OGC"), "membre_ogc", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("INSCRITTPS"), "inscrittps", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("INSCRITTVQ"), "inscrittvq", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISOGC"), "isogc", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_NOM"), "rep2_nom", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_TELEPHONE"), "rep2_telephone", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_TELEPHONE_POSTE"), "rep2_telephone_poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_EMAIL"), "rep2_email", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_COMMENTAIRES"), "rep2_commentaires", "ASC")}
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
    buttons.push(Theme.buttonAddNew(NS, "#/fournisseur/new", i18n("Add New")));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, i18n("fournisseurs title"));
    let subtitle = buildSubtitle(xtra, i18n("fournisseurs subtitle"));

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

export const fetchState = (id: string) => {
    Router.registerDirtyExit(null);
    return App.POST("/fournisseur/search", state.pager)
        .then(payload => {
            state = payload;
            xtra = payload.xtra;
            key = {};
        })
        .then(Lookup.fetch_pays())
        .then(Lookup.fetch_institutionBanquaire())
};

export const fetch = (params: string[]) => {
    let id = params[0];
    App.prepareRender(NS, i18n("fournisseurs"));
    fetchState(id)
        .then(App.render)
        .catch(App.render);
};

const refresh = () => {
    App.prepareRender(NS, i18n("fournisseurs"));
    App.POST("/fournisseur/search", state.pager)
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

const setSelectedRow = (id: string) => {
    if (uiSelectedRow == undefined) uiSelectedRow = { id };
    uiSelectedRow.id = id;
};

const isSelectedRow = (id: string) => {
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

export const filter_nom = (element: HTMLInputElement) => {
    // TODO (filterDef)
};

export const gotoDetail = (id: string) => {
    setSelectedRow(id);
    Router.goto(`#/proprietaire/${id}`);
};
