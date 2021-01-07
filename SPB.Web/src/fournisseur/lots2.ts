// File: lots2.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Perm from "../permission"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import * as Pager from "../../_BaseApp/src/theme/pager"
import * as Lookup from "../admin/lookupdata"
import * as Layout from "./layout"
import { tabTemplate, icon } from "./layout"

declare const i18n: any;


export const NS = "App_lots2";
const table_id = "lots2_table";

interface IState {
    _editing: boolean
    _deleting: boolean
    _isNew: boolean
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
}

interface IKey {
    proprietaireid: string
}

interface IFilter {
}

interface IPagedState extends Pager.IPagedList<IState, IFilter> { }

const blackList = ["_editing", "totalcount", "cantonid_text", "municipaliteid_text", "proprietaireid_text", "contingentid_text", "droit_coupeid_text", "entente_paiementid_text", "zoneid_text"];


let key: IKey;
let state = <IPagedState>{
    list: [],
    pager: { pageNo: 1, pageSize: 1000, sortColumn: "ID", sortDirection: "ASC", filter: {  } }
};
let fetchedState = <IPagedState>{};
let isNew = false;
let callerNS: string;
let isAddingNewParent = false;


const trTemplate = (item: IState, editId: number, deleteId: number, rowNumber: number, cantonid: string, municipaliteid: string, contingentid: string, droit_coupeid: string, entente_paiementid: string, zoneid: string) => {
    let id = item.id;

    let tdConfirm = `<td class="js-td-33">&nbsp;</td>`;
    if (item._editing) tdConfirm = `<td onclick="${NS}.save()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
    if (item._deleting) tdConfirm = `<td onclick="${NS}.drop()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
    if (item._isNew) tdConfirm = `<td onclick="${NS}.create()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;

    let clickUndo = item._editing || item._deleting || item._isNew;
    let markDeletion = !clickUndo;

    let readonly = (deleteId != undefined) || (editId != undefined && id != editId) || (isNew && !item._isNew);

    let classList: string[] = [];
    if (item._editing || item._isNew) classList.push("js-not-same");
    if (item._deleting) classList.push("js-strikeout");
    if (item._isNew) classList.push("js-new");
    if (readonly) classList.push("js-readonly");

    return `
<tr data-id="${id}" class="${classList.join(" ")}" style="cursor: pointer;">
    <td class="js-index">${rowNumber}</td>

${markDeletion ? `<td onclick="${NS}.selectfordrop(${id})" class="has-text-danger js-td-33 js-drop" title="Click to mark for deletion"><i class='fas fa-times'></i></td>` : ``}
${clickUndo ? `<td onclick="${NS}.undo()" class="has-text-primary js-td-33" title="Click to undo"><i class='fa fa-undo'></i></td>` : ``}
${tdConfirm}

${!readonly ? `
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `cantonid_${id}`, cantonid)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `rang_${id}`, item.rang, 25)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `lot_${id}`, item.lot, 6)}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `municipaliteid_${id}`, municipaliteid)}</td>
    <td class="js-inline-input">${Theme.renderDecimalInline(NS, `superficie_total_${id}`, item.superficie_total, <Theme.IOptNumber>{ required: true, places: 1, min: 0 })}</td>
    <td class="js-inline-input">${Theme.renderDecimalInline(NS, `superficie_boisee_${id}`, item.superficie_boisee, <Theme.IOptNumber>{ required: true, places: 1, min: 0 })}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `contingentid_${id}`, contingentid)}</td>
    <td class="js-inline-input">${Theme.renderDateInline(NS, `contingent_date_${id}`, item.contingent_date, <Theme.IOptDate>{ required: false })}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `droit_coupeid_${id}`, droit_coupeid)}</td>
    <td class="js-inline-input">${Theme.renderDateInline(NS, `droit_coupe_date_${id}`, item.droit_coupe_date, <Theme.IOptDate>{ required: false })}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `entente_paiementid_${id}`, entente_paiementid)}</td>
    <td class="js-inline-input">${Theme.renderDateInline(NS, `entente_paiement_date_${id}`, item.entente_paiement_date, <Theme.IOptDate>{ required: false })}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `actif_${id}`, item.actif)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `sequence_${id}`, item.sequence, 6)}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `partie_${id}`, item.partie)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `matricule_${id}`, item.matricule, 20)}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `zoneid_${id}`, zoneid)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `secteur_${id}`, item.secteur, 2)}</td>
    <td class="js-inline-input">${Theme.renderNumberInline(NS, `cadastre_${id}`, item.cadastre)}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `reforme_${id}`, item.reforme)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `lotscomplementaires_${id}`, item.lotscomplementaires, 255)}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `certifie_${id}`, item.certifie)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `numerocertification_${id}`, item.numerocertification, 50)}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `ogc_${id}`, item.ogc)}</td>
` : `
    <td>${Misc.toStaticText(item.cantonid_text)}</td>
    <td>${Misc.toStaticText(item.rang)}</td>
    <td>${Misc.toStaticText(item.lot)}</td>
    <td>${Misc.toStaticText(item.municipaliteid_text)}</td>
    <td>${Misc.toStaticText(item.superficie_total)}</td>
    <td>${Misc.toStaticText(item.superficie_boisee)}</td>
    <td>${Misc.toStaticText(item.contingentid_text)}</td>
    <td>${Misc.toInputDate(item.contingent_date)}</td>
    <td>${Misc.toStaticText(item.droit_coupeid_text)}</td>
    <td>${Misc.toInputDate(item.droit_coupe_date)}</td>
    <td>${Misc.toStaticText(item.entente_paiementid_text)}</td>
    <td>${Misc.toInputDate(item.entente_paiement_date)}</td>
    <td>${Misc.toStaticCheckbox(item.actif)}</td>
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
`}
</tr>`;
};

const tableTemplate = (tbody: string, editId: number, deleteId: number) => {
    let disableAddNew = (deleteId != undefined || editId != undefined || isNew);

    return `
<div id="${table_id}" class="table-container">
<table class="table is-hoverable js-inline" style="width: 100px; table-layout: fixed;">
    <thead>
        <tr>
            <th style="width:99px" colspan="3"></th>
            <th style="width:100px">${i18n("CANTON")}</th>
            <th style="width:100px">${i18n("RANG")}</th>
            <th style="width:100px">${i18n("LOT")}</th>
            <th style="width:100px">${i18n("MUNICIPALITE")}</th>
            <th style="width:100px">${i18n("SUPERFICIE_TOTAL")}</th>
            <th style="width:100px">${i18n("SUPERFICIE_BOISEE")}</th>
            <th style="width:100px">${i18n("CONTINGENT")}</th>
            <th style="width:100px">${i18n("CONTINGENT_DATE")}</th>
            <th style="width:100px">${i18n("DROIT_COUPE")}</th>
            <th style="width:100px">${i18n("DROIT_COUPE_DATE")}</th>
            <th style="width:100px">${i18n("ENTENTE_PAIEMENT")}</th>
            <th style="width:100px">${i18n("ENTENTE_PAIEMENT_DATE")}</th>
            <th style="width:100px">${i18n("ACTIF")}</th>
            <th style="width:100px">${i18n("SEQUENCE")}</th>
            <th style="width:100px">${i18n("PARTIE")}</th>
            <th style="width:100px">${i18n("MATRICULE")}</th>
            <th style="width:100px">${i18n("ZONE")}</th>
            <th style="width:100px">${i18n("SECTEUR")}</th>
            <th style="width:100px">${i18n("CADASTRE")}</th>
            <th style="width:100px">${i18n("REFORME")}</th>
            <th style="width:100px">${i18n("LOTSCOMPLEMENTAIRES")}</th>
            <th style="width:100px">${i18n("CERTIFIE")}</th>
            <th style="width:100px">${i18n("NUMEROCERTIFICATION")}</th>
            <th style="width:100px">${i18n("OGC")}</th>
        </tr>
    </thead>
    <tbody>
        ${tbody}
        <tr class="js-insert-row ${disableAddNew ? "js-disabled" : ""}">
            <td class="js-index js-td-33">*</td>
            <td class="has-text-primary js-td-33 js-add" onclick="${NS}.addNew()" title="Click to add a new row"><i class="fas fa-plus"></i></td>
            <td></td>
            <td colspan="24"></td>
        </tr>
    </tbody>
</table>
</div>
`;
};

const pageTemplate = (table: string) => {
    return `
${Theme.wrapContent("js-uc-list", table)}
`
};

export const fetchState = (proprietaireid: string, ownerNS?: string) => {
    isAddingNewParent = (proprietaireid == "new");
    callerNS = ownerNS || callerNS;
    isNew = false;
    return App.POST(`/lot/search/proprietaire/${proprietaireid}`, state.pager)
        .then(payload => {
            state = payload;
            fetchedState = Misc.clone(state) as IPagedState;
            key = { proprietaireid };
        })
        .then(Lookup.fetch_canton())
        .then(Lookup.fetch_municipalite())
        .then(Lookup.fetch_contingent())
        .then(Lookup.fetch_droit_coupe())
        .then(Lookup.fetch_entente_paiement())
        .then(Lookup.fetch_zone())
};

export const preRender = () => {
};

export const render = () => {
    if (isAddingNewParent) return "";

    let editId: number;
    let deleteId: number;
    state.list.forEach((item, index) => {
        let prevItem = fetchedState.list[index];
        item._editing = !Misc.same(item, prevItem);
        if (item._editing) editId = item.id;
        if (item._deleting) deleteId = item.id;
    });

    let year = Perm.getCurrentYear(); //or something better

    let lookup_canton = Lookup.get_canton(year);
    let lookup_municipalite = Lookup.get_municipalite(year);
    let lookup_contingent = Lookup.get_contingent(year);
    let lookup_droit_coupe = Lookup.get_droit_coupe(year);
    let lookup_entente_paiement = Lookup.get_entente_paiement(year);
    let lookup_zone = Lookup.get_zone(year);

    const tbody = state.list.reduce((html, item, index) => {
        let rowNumber = Pager.rowNumber(state.pager, index);
        let cantonid = Theme.renderOptions(lookup_canton, item.cantonid, true);
        let municipaliteid = Theme.renderOptions(lookup_municipalite, item.municipaliteid, true);
        let contingentid = Theme.renderOptions(lookup_contingent, item.contingentid, true);
        let droit_coupeid = Theme.renderOptions(lookup_droit_coupe, item.droit_coupeid, true);
        let entente_paiementid = Theme.renderOptions(lookup_entente_paiement, item.entente_paiementid, true);
        let zoneid = Theme.renderOptions(lookup_zone, item.zoneid, true);
        return html + trTemplate(item, editId, deleteId, rowNumber, cantonid, municipaliteid, contingentid, droit_coupeid, entente_paiementid, zoneid);
    }, "");

    const table = tableTemplate(tbody, editId, deleteId);
    return pageTemplate(table);
};

export const postRender = () => {
};

export const inContext = () => {
    return App.inContext(NS);
};

const getFormState = () => {
    let clone = Misc.clone(state) as IPagedState;
    clone.list.forEach(item => {
        let id = item.id;
        item.cantonid = Misc.fromSelectText(`${NS}_cantonid_${id}`, item.cantonid);
        item.rang = Misc.fromInputTextNullable(`${NS}_rang_${id}`, item.rang);
        item.lot = Misc.fromInputTextNullable(`${NS}_lot_${id}`, item.lot);
        item.municipaliteid = Misc.fromSelectText(`${NS}_municipaliteid_${id}`, item.municipaliteid);
        item.superficie_total = Misc.fromInputNumberNullable(`${NS}_superficie_total_${id}`, item.superficie_total);
        item.superficie_boisee = Misc.fromInputNumberNullable(`${NS}_superficie_boisee_${id}`, item.superficie_boisee);
        item.proprietaireid = Misc.fromSelectText(`${NS}_proprietaireid_${id}`, item.proprietaireid);
        item.contingentid = Misc.fromSelectText(`${NS}_contingentid_${id}`, item.contingentid);
        item.contingent_date = Misc.fromInputDateNullable(`${NS}_contingent_date_${id}`, item.contingent_date);
        item.droit_coupeid = Misc.fromSelectText(`${NS}_droit_coupeid_${id}`, item.droit_coupeid);
        item.droit_coupe_date = Misc.fromInputDateNullable(`${NS}_droit_coupe_date_${id}`, item.droit_coupe_date);
        item.entente_paiementid = Misc.fromSelectText(`${NS}_entente_paiementid_${id}`, item.entente_paiementid);
        item.entente_paiement_date = Misc.fromInputDateNullable(`${NS}_entente_paiement_date_${id}`, item.entente_paiement_date);
        item.actif = Misc.fromInputCheckbox(`${NS}_actif_${id}`, item.actif);
        item.sequence = Misc.fromInputTextNullable(`${NS}_sequence_${id}`, item.sequence);
        item.partie = Misc.fromInputCheckbox(`${NS}_partie_${id}`, item.partie);
        item.matricule = Misc.fromInputTextNullable(`${NS}_matricule_${id}`, item.matricule);
        item.zoneid = Misc.fromSelectText(`${NS}_zoneid_${id}`, item.zoneid);
        item.secteur = Misc.fromInputTextNullable(`${NS}_secteur_${id}`, item.secteur);
        item.cadastre = Misc.fromInputNumberNullable(`${NS}_cadastre_${id}`, item.cadastre);
        item.reforme = Misc.fromInputCheckbox(`${NS}_reforme_${id}`, item.reforme);
        item.lotscomplementaires = Misc.fromInputTextNullable(`${NS}_lotscomplementaires_${id}`, item.lotscomplementaires);
        item.certifie = Misc.fromInputCheckbox(`${NS}_certifie_${id}`, item.certifie);
        item.numerocertification = Misc.fromInputTextNullable(`${NS}_numerocertification_${id}`, item.numerocertification);
        item.ogc = Misc.fromInputCheckbox(`${NS}_ogc_${id}`, item.ogc);
    })
    return clone;
};

const html5Valid = (): boolean => {
    document.getElementById(`${callerNS}_dummy_submit`).click();
    let form = document.getElementsByTagName("form")[0];
    form.classList.add("js-error");
    return form.checkValidity();
};

export const onchange = (input: HTMLInputElement) => {
    state = getFormState();
    App.render();
};

export const undo = () => {
    if (isNew) {
        isNew = false;
        fetchedState.list.pop();
    }
    state = Misc.clone(fetchedState) as IPagedState;
    App.render()
}

export const addNew = () => {
    let url = `/lot/new/${key.proprietaireid}`;
    return App.GET(url)
        .then((payload: IState) => {
            state.list.push(payload);
            fetchedState = Misc.clone(state) as IPagedState;
            isNew = true;
            payload._isNew = true;
        })
        .then(App.render)
        .catch(App.render);
}

export const create = () => {
    let formState = getFormState();
    let item = formState.list.find(one => one._isNew);
    if (!html5Valid()) return;
    App.prepareRender();
    App.POST("/lot", Misc.createBlack(item, blackList))
        .then(() => {
            fetchedState = Misc.clone(state) as IPagedState;
            Router.gotoCurrent(1);
        })
        .catch(App.render);
}

export const save = () => {
    let formState = getFormState();
    let item = formState.list.find(one => one._editing);
    if (!html5Valid()) return;
    App.prepareRender();
    App.PUT("/lot", Misc.createBlack(item, blackList))
        .then(() => {
            fetchedState = Misc.clone(state) as IPagedState;
            Router.gotoCurrent(1);
        })
        .catch(App.render);
}

export const selectfordrop = (id: number) => {
    state = Misc.clone(fetchedState) as IPagedState;
    state.list.find(one => one.id == id)._deleting = true;
    App.render();
}

export const drop = () => {
    App.prepareRender();
    let item = state.list.find(one => one._deleting);
    App.DELETE("/lot", { id: item.id })
        .then(() => {
            fetchedState = Misc.clone(state) as IPagedState;
            Router.gotoCurrent(1);
        })
        .catch(App.render);
}

export const hasChanges = () => {
    return !Misc.same(fetchedState, state);
}
