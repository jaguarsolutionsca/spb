// File: fournisseurs.ts

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
    totalCount: number
    id: string
    cleTri: string
    nom: string
    ausoinsde: string
    rue: string
    ville: string
    paysID: string
    paysID_Text: string
    code_postal: string
    telephone: string
    telephone_Poste: string
    telecopieur: string
    telephone2: string
    telephone2_Desc: string
    telephone2_Poste: string
    telephone3: string
    telephone3_Desc: string
    telephone3_Poste: string
    no_membre: string
    resident: string
    email: string
    www: string
    commentaires: string
    afficherCommentaires: boolean
    depotDirect: boolean
    institutionBanquaireID: string
    institutionBanquaireID_Text: string
    banque_transit: string
    banque_folio: string
    no_TPS: string
    no_TVQ: string
    payerA: boolean
    payerAID: string
    statut: string
    rep_Nom: string
    rep_Telephone: string
    rep_Telephone_Poste: string
    rep_Email: string
    enAnglais: boolean
    actif: boolean
    mRCProducteurID: number
    paiementManuel: boolean
    journal: boolean
    recoitTPS: boolean
    recoitTVQ: boolean
    modifierTrigger: boolean
    isProducteur: boolean
    isTransporteur: boolean
    isChargeur: boolean
    isAutre: boolean
    afficherCommentairesSurPermit: boolean
    pasEmissionPermis: boolean
    generique: boolean
    membre_OGC: boolean
    inscritTPS: boolean
    inscritTVQ: boolean
    isOGC: boolean
    rep2_Nom: string
    rep2_Telephone: string
    rep2_Telephone_Poste: string
    rep2_Email: string
    rep2_Commentaires: string
    json: string
}

interface ISummary {
    todo: string
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
let uiSelectedRow: { id: string };

const filterTemplate = () => {
    let filters: string[] = [];
    // TODO (filters textbox)
    return filters.join("");
}

const trTemplate = (item: IState, rowNumber: number) => {
    let summary = <ISummary>JSON.parse(item.json || "{}");

    return `
<tr class="${isSelectedRow(item.id) ? "is-selected" : ""}" onclick="${NS}.gotoDetail('${item.id}');">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.id)}</td>
    <td>${Misc.toStaticText(item.cleTri)}</td>
    <td>${Misc.toStaticText(item.nom)}</td>
    <td>${Misc.toStaticText(item.ausoinsde)}</td>
    <td>${Misc.toStaticText(item.rue)}</td>
    <td>${Misc.toStaticText(item.ville)}</td>
    <td>${Misc.toStaticText(item.paysID_Text)}</td>
    <td>${Misc.toStaticText(item.code_postal)}</td>
    <td>${Misc.toStaticText(item.telephone)}</td>
    <td>${Misc.toStaticText(item.telephone_Poste)}</td>
    <td>${Misc.toStaticText(item.telecopieur)}</td>
    <td>${Misc.toStaticText(item.telephone2)}</td>
    <td>${Misc.toStaticText(item.telephone2_Desc)}</td>
    <td>${Misc.toStaticText(item.telephone2_Poste)}</td>
    <td>${Misc.toStaticText(item.telephone3)}</td>
    <td>${Misc.toStaticText(item.telephone3_Desc)}</td>
    <td>${Misc.toStaticText(item.telephone3_Poste)}</td>
    <td>${Misc.toStaticText(item.no_membre)}</td>
    <td>${Misc.toStaticText(item.resident)}</td>
    <td>${Misc.toStaticText(item.email)}</td>
    <td>${Misc.toStaticText(item.www)}</td>
    <td>${Misc.toStaticText(item.commentaires)}</td>
    <td>${Misc.toStaticCheckbox(item.afficherCommentaires)}</td>
    <td>${Misc.toStaticCheckbox(item.depotDirect)}</td>
    <td>${Misc.toStaticText(item.institutionBanquaireID_Text)}</td>
    <td>${Misc.toStaticText(item.banque_transit)}</td>
    <td>${Misc.toStaticText(item.banque_folio)}</td>
    <td>${Misc.toStaticText(item.no_TPS)}</td>
    <td>${Misc.toStaticText(item.no_TVQ)}</td>
    <td>${Misc.toStaticCheckbox(item.payerA)}</td>
    <td>${Misc.toStaticText(item.payerAID)}</td>
    <td>${Misc.toStaticText(item.statut)}</td>
    <td>${Misc.toStaticText(item.rep_Nom)}</td>
    <td>${Misc.toStaticText(item.rep_Telephone)}</td>
    <td>${Misc.toStaticText(item.rep_Telephone_Poste)}</td>
    <td>${Misc.toStaticText(item.rep_Email)}</td>
    <td>${Misc.toStaticCheckbox(item.enAnglais)}</td>
    <td>${Misc.toStaticCheckbox(item.actif)}</td>
    <td>${Misc.toStaticText(item.mRCProducteurID)}</td>
    <td>${Misc.toStaticCheckbox(item.paiementManuel)}</td>
    <td>${Misc.toStaticCheckbox(item.journal)}</td>
    <td>${Misc.toStaticCheckbox(item.recoitTPS)}</td>
    <td>${Misc.toStaticCheckbox(item.recoitTVQ)}</td>
    <td>${Misc.toStaticCheckbox(item.modifierTrigger)}</td>
    <td>${Misc.toStaticCheckbox(item.isProducteur)}</td>
    <td>${Misc.toStaticCheckbox(item.isTransporteur)}</td>
    <td>${Misc.toStaticCheckbox(item.isChargeur)}</td>
    <td>${Misc.toStaticCheckbox(item.isAutre)}</td>
    <td>${Misc.toStaticCheckbox(item.afficherCommentairesSurPermit)}</td>
    <td>${Misc.toStaticCheckbox(item.pasEmissionPermis)}</td>
    <td>${Misc.toStaticCheckbox(item.generique)}</td>
    <td>${Misc.toStaticCheckbox(item.membre_OGC)}</td>
    <td>${Misc.toStaticCheckbox(item.inscritTPS)}</td>
    <td>${Misc.toStaticCheckbox(item.inscritTVQ)}</td>
    <td>${Misc.toStaticCheckbox(item.isOGC)}</td>
    <td>${Misc.toStaticText(item.rep2_Nom)}</td>
    <td>${Misc.toStaticText(item.rep2_Telephone)}</td>
    <td>${Misc.toStaticText(item.rep2_Telephone_Poste)}</td>
    <td>${Misc.toStaticText(item.rep2_Email)}</td>
    <td>${Misc.toStaticText(item.rep2_Commentaires)}</td>
    <td>${Misc.toStaticText(summary.todo)}</td>
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
            ${Pager.sortableHeaderLink(pager, NS, i18n("CLETRI"), "cleTri", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NOM"), "nom", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AUSOINSDE"), "ausoinsde", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RUE"), "rue", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VILLE"), "ville", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PAYSID_TEXT"), "paysID_Text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CODE_POSTAL"), "code_postal", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE"), "telephone", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE_POSTE"), "telephone_Poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELECOPIEUR"), "telecopieur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE2"), "telephone2", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE2_DESC"), "telephone2_Desc", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE2_POSTE"), "telephone2_Poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE3"), "telephone3", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE3_DESC"), "telephone3_Desc", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE3_POSTE"), "telephone3_Poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NO_MEMBRE"), "no_membre", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RESIDENT"), "resident", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("EMAIL"), "email", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("WWW"), "www", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COMMENTAIRES"), "commentaires", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERCOMMENTAIRES"), "afficherCommentaires", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DEPOTDIRECT"), "depotDirect", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("INSTITUTIONBANQUAIREID_TEXT"), "institutionBanquaireID_Text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("BANQUE_TRANSIT"), "banque_transit", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("BANQUE_FOLIO"), "banque_folio", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NO_TPS"), "no_TPS", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NO_TVQ"), "no_TVQ", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PAYERA"), "payerA", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PAYERAID"), "payerAID", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("STATUT"), "statut", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP_NOM"), "rep_Nom", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP_TELEPHONE"), "rep_Telephone", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP_TELEPHONE_POSTE"), "rep_Telephone_Poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP_EMAIL"), "rep_Email", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ENANGLAIS"), "enAnglais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ACTIF"), "actif", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MRCPRODUCTEURID"), "mRCProducteurID", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PAIEMENTMANUEL"), "paiementManuel", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("JOURNAL"), "journal", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RECOITTPS"), "recoitTPS", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RECOITTVQ"), "recoitTVQ", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MODIFIERTRIGGER"), "modifierTrigger", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISPRODUCTEUR"), "isProducteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISTRANSPORTEUR"), "isTransporteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISCHARGEUR"), "isChargeur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISAUTRE"), "isAutre", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERCOMMENTAIRESSURPERMIT"), "afficherCommentairesSurPermit", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PASEMISSIONPERMIS"), "pasEmissionPermis", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("GENERIQUE"), "generique", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MEMBRE_OGC"), "membre_OGC", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("INSCRITTPS"), "inscritTPS", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("INSCRITTVQ"), "inscritTVQ", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISOGC"), "isOGC", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_NOM"), "rep2_Nom", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_TELEPHONE"), "rep2_Telephone", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_TELEPHONE_POSTE"), "rep2_Telephone_Poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_EMAIL"), "rep2_Email", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_COMMENTAIRES"), "rep2_Commentaires", "ASC")}
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

const pageTemplate = (xtra, pager: string, table: string, tab: string, warning: string, dirty: string) => {
    let readonly = false;

    let buttons: string[] = [];
    buttons.push(Theme.buttonAddNew(NS, "#/fournisseur/new", i18n("Add New")));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(state.xtra, i18n("fournisseurs title"));
    let subtitle = buildSubtitle(state.xtra, i18n("fournisseurs subtitle"));

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
    return pageTemplate(state.xtra, pager, table, tab, dirty, warning);
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
