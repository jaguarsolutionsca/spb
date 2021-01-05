// File: lot.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import { Calendar } from "../../_BaseApp/src/theme/calendar"
import { Autocomplete } from "../../_BaseApp/src/theme/autocomplete"
import * as Pager from "../../_BaseApp/src/theme/pager"
import * as Auth from "../../_BaseApp/src/auth"
import * as Lookup from "../admin/lookupdata"
import * as Perm from "../permission"
import { tabTemplate, icon, ISummary, buildTitle, buildSubtitle } from "./layout"

declare const i18n: any;


export const NS = "App_lot";

interface IPayload {
    item: IState
    xtra: ISummary
}

interface IKey {
    id: number
}

interface IState {
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

interface IState_Fournisseur {
    id: string
    nom: string
    ausoinsde: string
    rue: string
    ville: string
    code_postal: string
    no_membre: string
    email: string
    isproducteur: boolean
    istransporteur: boolean
    ischargeur: boolean
    isautre: boolean
}


const blackList = ["cantonid_text", "municipaliteid_text", "proprietaireid_text", "contingentid_text", "droit_coupeid_text", "entente_paiementid_text", "zoneid_text"];

let key: IKey;
let state = <IState>{};
let fetchedState = <IState>{};
let xtra: ISummary;
let isNew = false;
let isDirty = false;
let contingent_dateCalendar = new Calendar(`${NS}_contingent_date`);
let droit_coupe_dateCalendar = new Calendar(`${NS}_droit_coupe_date`);
let entente_paiement_dateCalendar = new Calendar(`${NS}_entente_paiement_date`);

let state_proprietaireid = <Pager.IPagedList<IState_Fournisseur, any>>{
    list: [],
    pager: { pageNo: 1, pageSize: 5, sortColumn: "ID", sortDirection: "ASC", filter: {} }
};
let proprietaireidAutocomplete = new Autocomplete(NS, "proprietaireid", true);
proprietaireidAutocomplete.options = {
    keyTemplate: (one: IState_Fournisseur) => { return `${one.id}` },
    valueTemplate: (one: IState_Fournisseur) => { return `${one.id} - ${one.nom}` },
    detailTemplate: (one: IState_Fournisseur) => { return `<b>${one.id} - ${one.nom}</b>` },
}

const formTemplate = (item: IState, cantonid: string, municipaliteid: string, proprietaireid: Autocomplete, contingentid: string, droit_coupeid: string, entente_paiementid: string) => {
    let proprietaireidOption = <Theme.IOpt>{
        addon: (item.proprietaireid ? `<a class="button is-text" href="#/proprietaire/${item.proprietaireid}">Voir</a>` : null),
        required: true
    };

    return `

${isNew ? `
` : `
    ${Theme.renderStaticField(Misc.toStaticNumber(item.id), i18n("ID"))}
`}
    ${Theme.renderDropdownField(NS, "cantonid", cantonid, i18n("CANTONID"))}
    ${Theme.renderTextField(NS, "rang", item.rang, i18n("RANG"), 25)}
    ${Theme.renderTextField(NS, "lot", item.lot, i18n("LOT"), 6)}
    ${Theme.renderDropdownField(NS, "municipaliteid", municipaliteid, i18n("MUNICIPALITEID"))}
    ${Theme.renderNumberField(NS, "superficie_total", item.superficie_total, i18n("SUPERFICIE_TOTAL"))}
    ${Theme.renderNumberField(NS, "superficie_boisee", item.superficie_boisee, i18n("SUPERFICIE_BOISEE"))}
    ${Theme.renderAutocompleteField(NS, "proprietaireid", proprietaireid, i18n("PROPRIETAIREID"), proprietaireidOption)}
    ${Theme.renderDropdownField(NS, "contingentid", contingentid, i18n("CONTINGENTID"))}
    ${Theme.renderCalendarField(NS, "contingent_date", contingent_dateCalendar, i18n("CONTINGENT_DATE"))}
    ${Theme.renderDropdownField(NS, "droit_coupeid", droit_coupeid, i18n("DROIT_COUPEID"))}
    ${Theme.renderCalendarField(NS, "droit_coupe_date", droit_coupe_dateCalendar, i18n("DROIT_COUPE_DATE"))}
    ${Theme.renderDropdownField(NS, "entente_paiementid", entente_paiementid, i18n("ENTENTE_PAIEMENTID"))}
    ${Theme.renderCalendarField(NS, "entente_paiement_date", entente_paiement_dateCalendar, i18n("ENTENTE_PAIEMENT_DATE"))}
    ${Theme.renderCheckboxField(NS, "actif", item.actif, i18n("ACTIF"))}
    ${Theme.renderTextField(NS, "sequence", item.sequence, i18n("SEQUENCE"), 6)}
    ${Theme.renderCheckboxField(NS, "partie", item.partie, i18n("PARTIE"))}
    ${Theme.renderTextField(NS, "matricule", item.matricule, i18n("MATRICULE"), 20)}
    ${Theme.renderTextField(NS, "secteur", item.secteur, i18n("SECTEUR"), 2)}
    ${Theme.renderNumberField(NS, "cadastre", item.cadastre, i18n("CADASTRE"))}
    ${Theme.renderCheckboxField(NS, "reforme", item.reforme, i18n("REFORME"))}
    ${Theme.renderTextareaField(NS, "lotscomplementaires", item.lotscomplementaires, i18n("LOTSCOMPLEMENTAIRES"), 255)}
    ${Theme.renderCheckboxField(NS, "certifie", item.certifie, i18n("CERTIFIE"))}
    ${Theme.renderTextField(NS, "numerocertification", item.numerocertification, i18n("NUMEROCERTIFICATION"), 50)}
    ${Theme.renderCheckboxField(NS, "ogc", item.ogc, i18n("OGC"))}
    ${Theme.renderBlame(item, isNew)}
`;
};

const pageTemplate = (item: IState, form: string, tab: string, warning: string, dirty: string) => {
    let canEdit = true;
    let readonly = !canEdit;

    let canInsert = canEdit && isNew; // && Perm.hasLot_CanAddLot;
    let canDelete = canEdit && !canInsert; // && Perm.hasLot_CanDeleteLot;
    let canAdd = canEdit && !canInsert; // && Perm.hasLot_CanAddLot;
    let canUpdate = canEdit && !isNew;

    let buttons: string[] = [];
    buttons.push(Theme.buttonCancel(NS));
    if (canInsert) buttons.push(Theme.buttonInsert(NS));
    if (canDelete) buttons.push(Theme.buttonDelete(NS));
    if (canAdd) buttons.push(Theme.buttonAddNew(NS, "#/lot/new"));
    if (canUpdate) buttons.push(Theme.buttonUpdate(NS));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, !isNew ? i18n("lot Details") : i18n("New lot"));
    let subtitle = buildSubtitle(xtra, i18n("lot subtitle"));

    return `
<form onsubmit="return false;" ${readonly ? "class='js-readonly'" : ""}>
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
            ${Theme.renderBlame(item, isNew)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-details", form)}
</div>
</div>

${Theme.renderModalDelete(`modalDelete_${NS}`, `${NS}.drop()`)}

</form>
`;
};

const dirtyTemplate = () => {
    return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
}

export const fetchState = (id: number) => {
    isNew = isNaN(id);
    isDirty = false;
    Router.registerDirtyExit(dirtyExit);
    return App.GET(`/lot/${isNew ? "new" : id}`)
        .then((payload: IPayload) => {
            state = payload.item;
            fetchedState = Misc.clone(state) as IState;
            xtra = payload.xtra;
            key = <IKey>{ id };
            contingent_dateCalendar.setState(state.contingent_date);
            droit_coupe_dateCalendar.setState(state.droit_coupe_date);
            entente_paiement_dateCalendar.setState(state.entente_paiement_date);
            proprietaireidAutocomplete.setState(state.proprietaireid, state.proprietaireid_text);
        })
        .then(Lookup.fetch_canton())
        .then(Lookup.fetch_municipalite())
        .then(Lookup.fetch_contingent())
        .then(Lookup.fetch_droit_coupe())
        .then(Lookup.fetch_entente_paiement())

};

export const fetch = (params: string[]) => {
    let id = +params[0];
    App.prepareRender(NS, i18n("lot"));
    fetchState(id)
        .then(App.render)
        .catch(App.render);
};

export const render = () => {
    if (!inContext()) return "";
    if (App.fatalError()) return App.fatalErrorTemplate();
    if (state == undefined || Object.keys(state).length == 0)
        return App.warningTemplate() || App.unexpectedTemplate();

    let year = Perm.getCurrentYear(); //or something better

    let lookup_canton = Lookup.get_canton(year);
    let lookup_municipalite = Lookup.get_municipalite(year);
    let lookup_contingent = Lookup.get_contingent(year);
    let lookup_droit_coupe = Lookup.get_droit_coupe(year);
    let lookup_entente_paiement = Lookup.get_entente_paiement(year);

    let cantonid = Theme.renderOptions(lookup_canton, state.cantonid, true);
    let municipaliteid = Theme.renderOptions(lookup_municipalite, state.municipaliteid, true);
    let contingentid = Theme.renderOptions(lookup_contingent, state.contingentid, true);
    let droit_coupeid = Theme.renderOptions(lookup_droit_coupe, state.droit_coupeid, true);
    let entente_paiementid = Theme.renderOptions(lookup_entente_paiement, state.entente_paiementid, true);

    proprietaireidAutocomplete.pagedList = state_proprietaireid;

    const form = formTemplate(state, cantonid, municipaliteid, proprietaireidAutocomplete, contingentid, droit_coupeid, entente_paiementid);

    const tab = tabTemplate(state.id, xtra, isNew);
    const dirty = dirtyTemplate();
    const warning = App.warningTemplate();
    return pageTemplate(state, form, tab, warning, dirty);
};

export const postRender = () => {
    if (!inContext()) return;
    contingent_dateCalendar.postRender();
    droit_coupe_dateCalendar.postRender();
    entente_paiement_dateCalendar.postRender();


    App.setPageTitle(isNew ? i18n("New lot") : xtra.title);
};

export const inContext = () => {
    return App.inContext(NS);
};

const getFormState = () => {
    let clone = Misc.clone(state) as IState;
    clone.cantonid = Misc.fromSelectText(`${NS}_cantonid`, state.cantonid);
    clone.rang = Misc.fromInputTextNullable(`${NS}_rang`, state.rang);
    clone.lot = Misc.fromInputTextNullable(`${NS}_lot`, state.lot);
    clone.municipaliteid = Misc.fromSelectText(`${NS}_municipaliteid`, state.municipaliteid);
    clone.superficie_total = Misc.fromInputNumberNullable(`${NS}_superficie_total`, state.superficie_total);
    clone.superficie_boisee = Misc.fromInputNumberNullable(`${NS}_superficie_boisee`, state.superficie_boisee);
    clone.proprietaireid = Misc.fromAutocompleteText(`${NS}_proprietaireid`, state.proprietaireid);
    clone.contingentid = Misc.fromSelectText(`${NS}_contingentid`, state.contingentid);
    clone.contingent_date = Misc.fromInputDateNullable(`${NS}_contingent_date`, state.contingent_date);
    clone.droit_coupeid = Misc.fromSelectText(`${NS}_droit_coupeid`, state.droit_coupeid);
    clone.droit_coupe_date = Misc.fromInputDateNullable(`${NS}_droit_coupe_date`, state.droit_coupe_date);
    clone.entente_paiementid = Misc.fromSelectText(`${NS}_entente_paiementid`, state.entente_paiementid);
    clone.entente_paiement_date = Misc.fromInputDateNullable(`${NS}_entente_paiement_date`, state.entente_paiement_date);
    clone.actif = Misc.fromInputCheckbox(`${NS}_actif`, state.actif);
    clone.sequence = Misc.fromInputTextNullable(`${NS}_sequence`, state.sequence);
    clone.partie = Misc.fromInputCheckbox(`${NS}_partie`, state.partie);
    clone.matricule = Misc.fromInputTextNullable(`${NS}_matricule`, state.matricule);
    clone.secteur = Misc.fromInputTextNullable(`${NS}_secteur`, state.secteur);
    clone.cadastre = Misc.fromInputNumberNullable(`${NS}_cadastre`, state.cadastre);
    clone.reforme = Misc.fromInputCheckbox(`${NS}_reforme`, state.reforme);
    clone.lotscomplementaires = Misc.fromInputTextNullable(`${NS}_lotscomplementaires`, state.lotscomplementaires);
    clone.certifie = Misc.fromInputCheckbox(`${NS}_certifie`, state.certifie);
    clone.numerocertification = Misc.fromInputTextNullable(`${NS}_numerocertification`, state.numerocertification);
    clone.ogc = Misc.fromInputCheckbox(`${NS}_ogc`, state.ogc);
    return clone;
};

const valid = (formState: IState): boolean => {
    //if (formState.somefield.length == 0) App.setError("Somefield is required");
    return App.hasNoError();
};

const html5Valid = (): boolean => {
    document.getElementById(`${NS}_dummy_submit`).click();
    let form = document.getElementsByTagName("form")[0];
    form.classList.add("js-error");
    return form.checkValidity();
};

export const oncalendar = (id: string) => {
    if (contingent_dateCalendar.id == id) contingent_dateCalendar.toggle();
    if (droit_coupe_dateCalendar.id == id) droit_coupe_dateCalendar.toggle();
    if (entente_paiement_dateCalendar.id == id) entente_paiement_dateCalendar.toggle();
};

export const onautocomplete = (id: string) => {
    if (proprietaireidAutocomplete.id == id) {
        state_proprietaireid.pager.searchText = proprietaireidAutocomplete.textValue;
        App.POST("/fournisseur/search", state_proprietaireid.pager)
            .then(payload => {
                state_proprietaireid = payload;
            })
            .then(App.render)
    }
};

export const onchange = (input: HTMLInputElement) => {
    state = getFormState();
    App.render();
};

export const cancel = () => {
    Router.goBackOrResume(isDirty);
}

export const create = () => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
    App.prepareRender();
    App.POST("/lot", Misc.createBlack(formState, blackList))
        .then(payload => {
            let newkey = <IKey>payload;
            Misc.toastSuccessSave();
            Router.goto(`#/lot/${newkey.id}`, 10);
        })
        .catch(App.render);
}

export const save = (done = false) => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
    App.prepareRender();
    App.PUT("/lot", Misc.createBlack(formState, blackList))
        .then(_ => {
            Misc.toastSuccessSave();
            if (done)
                Router.goto(`#/lots/`, 100);
            else
                Router.goto(`#/lot/${key.id}`, 10);
        })
        .catch(App.render);
}

export const drop = () => {
    //(<any>key).updated = state.updated;
    App.prepareRender();
    App.DELETE("/lot", key)
        .then(_ => {

            Router.goto(`#/lots/`, 250);
        })
        .catch(App.render);
}

const dirtyExit = () => {
    isDirty = !Misc.same(fetchedState, getFormState());
    if (isDirty) {
        setTimeout(() => {
            state = getFormState();
            App.render();
        }, 10);
    }
    return isDirty;
};
