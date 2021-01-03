// File: proprietaire.ts

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


export const NS = "App_proprietaire";

interface IPayload {
    item: IState
    xtra: ISummary
}

interface IKey {
    id: string
}

interface IState {
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
}

const blackList = ["paysid_text", "institutionbanquaireid_text"];


let key: IKey;
let state = <IState>{};
let xtra: ISummary;
let fetchedState = <IState>{};
let isNew = false;
let isDirty = false;



const block_address = (item: IState, paysid: string) => {
    return `
    ${Theme.renderTextField(NS, "nom", item.nom, i18n("NOM"), 40)}
    ${Theme.renderTextField(NS, "ausoinsde", item.ausoinsde, i18n("AUSOINSDE"), 30)}
    ${Theme.renderTextField(NS, "rue", item.rue, i18n("RUE"), 30)}
    ${Theme.renderTextField(NS, "ville", item.ville, i18n("VILLE"), 30)}
    ${Theme.renderDropdownField(NS, "paysid", paysid, i18n("PAYSID"))}
    ${Theme.renderTextField(NS, "code_postal", item.code_postal, i18n("CODE_POSTAL"), 7)}
`;
}

const block_telephone = (item: IState) => {
    return `
    ${Theme.renderTextField(NS, "telephone", item.telephone, i18n("TELEPHONE"), 12)}
    ${Theme.renderTextField(NS, "telephone_poste", item.telephone_poste, i18n("TELEPHONE_POSTE"), 4)}
    ${Theme.renderTextField(NS, "telecopieur", item.telecopieur, i18n("TELECOPIEUR"), 12)}

    ${Theme.renderTextField(NS, "telephone2_desc", item.telephone2_desc, i18n("TELEPHONE2_DESC"), 20)}
    ${Theme.renderTextField(NS, "telephone2", item.telephone2, i18n("TELEPHONE2"), 12)}
    ${Theme.renderTextField(NS, "telephone2_poste", item.telephone2_poste, i18n("TELEPHONE2_POSTE"), 4)}

    ${Theme.renderTextField(NS, "telephone3_desc", item.telephone3_desc, i18n("TELEPHONE3_DESC"), 20)}
    ${Theme.renderTextField(NS, "telephone3", item.telephone3, i18n("TELEPHONE3"), 12)}
    ${Theme.renderTextField(NS, "telephone3_poste", item.telephone3_poste, i18n("TELEPHONE3_POSTE"), 4)}
`;
}

const block_ciel = (item: IState) => {
    return `
    ${Theme.renderTextField(NS, "statut", item.statut, i18n("STATUT"), 50)}
    ${Theme.renderTextField(NS, "resident", item.resident, i18n("RESIDENT"), 1)}
    ${Theme.renderTextField(NS, "no_membre", item.no_membre, i18n("NO_MEMBRE"), 10)}
`;
}

const block_internet = (item: IState) => {
    return `
    ${Theme.renderTextField(NS, "email", item.email, i18n("EMAIL"), 80)}
    ${Theme.renderTextField(NS, "www", item.www, i18n("WWW"), 80)}
`;
}

const block_autres = (item: IState) => {
    return `
    ${Theme.renderTextField(NS, "id", item.id, i18n("ID"), 15, true)}

    ${Theme.renderCheckboxField(NS, "isproducteur", item.isproducteur, i18n("ISPRODUCTEUR"))}
    ${Theme.renderCheckboxField(NS, "istransporteur", item.istransporteur, i18n("ISTRANSPORTEUR"))}
    ${Theme.renderCheckboxField(NS, "ischargeur", item.ischargeur, i18n("ISCHARGEUR"))}
    ${Theme.renderCheckboxField(NS, "isogc", item.isogc, i18n("ISOGC"))}
    ${Theme.renderCheckboxField(NS, "isautre", item.isautre, i18n("ISAUTRE"))}

    ${Theme.renderTextareaField(NS, "commentaires", item.commentaires, i18n("COMMENTAIRES"), 255, false, null, 5)}
    ${Theme.renderCheckboxField(NS, "affichercommentaires", item.affichercommentaires, i18n("AFFICHERCOMMENTAIRES"))}
    ${Theme.renderCheckboxField(NS, "affichercommentairessurpermit", item.affichercommentairessurpermit, i18n("AFFICHERCOMMENTAIRESSURPERMIT"))}

    ${Theme.renderCheckboxField(NS, "actif", item.actif, i18n("ACTIF"))}
    ${Theme.renderCheckboxField(NS, "journal", item.journal, i18n("JOURNAL"))}
    ${Theme.renderCheckboxField(NS, "pasemissionpermis", item.pasemissionpermis, i18n("PASEMISSIONPERMIS"))}

    ${Theme.renderCheckboxField(NS, "enanglais", item.enanglais, i18n("ENANGLAIS"))}
    ${Theme.renderCheckboxField(NS, "generique", item.generique, i18n("GENERIQUE"))}
    ${Theme.renderCheckboxField(NS, "membre_ogc", item.membre_ogc, i18n("MEMBRE_OGC"))}
`;
}

const block_depotdirect = (item: IState, institutionbanquaireid: string) => {
    return `
    ${Theme.renderCheckboxField(NS, "depotdirect", item.depotdirect, i18n("DEPOTDIRECT"))}

    ${Theme.renderDropdownField(NS, "institutionbanquaireid", institutionbanquaireid, i18n("INSTITUTIONBANQUAIREID"))}
    ${Theme.renderTextField(NS, "banque_transit", item.banque_transit, i18n("BANQUE_TRANSIT"), 5)}
    ${Theme.renderTextField(NS, "banque_folio", item.banque_folio, i18n("BANQUE_FOLIO"), 12)}

    ${Theme.renderTextField(NS, "no_tps", item.no_tps, i18n("NO_TPS"), 25)}
    ${Theme.renderCheckboxField(NS, "recoittps", item.recoittps, i18n("RECOITTPS"))}
    ${Theme.renderCheckboxField(NS, "inscrittps", item.inscrittps, i18n("INSCRITTPS"))}

    ${Theme.renderTextField(NS, "no_tvq", item.no_tvq, i18n("NO_TVQ"), 25)}
    ${Theme.renderCheckboxField(NS, "recoittvq", item.recoittvq, i18n("RECOITTVQ"))}
    ${Theme.renderCheckboxField(NS, "inscrittvq", item.inscrittvq, i18n("INSCRITTVQ"))}

    ${Theme.renderCheckboxField(NS, "payera", item.payera, i18n("PAYERA"))}
    ${Theme.renderTextField(NS, "payeraid", item.payeraid, i18n("PAYERAID"), 15)}
    ${Theme.renderCheckboxField(NS, "paiementmanuel", item.paiementmanuel, i18n("PAIEMENTMANUEL"))}
`;
}

const block_representant = (item: IState) => {
    return `
    ${Theme.renderTextField(NS, "rep_nom", item.rep_nom, i18n("REP_NOM"), 30)}
    ${Theme.renderTextField(NS, "rep_telephone", item.rep_telephone, i18n("REP_TELEPHONE"), 12)}
    ${Theme.renderTextField(NS, "rep_telephone_poste", item.rep_telephone_poste, i18n("REP_TELEPHONE_POSTE"), 4)}
    ${Theme.renderTextField(NS, "rep_email", item.rep_email, i18n("REP_EMAIL"), 80)}

    ${Theme.renderTextField(NS, "rep2_nom", item.rep2_nom, i18n("REP2_NOM"), 80)}
    ${Theme.renderTextField(NS, "rep2_telephone", item.rep2_telephone, i18n("REP2_TELEPHONE"), 12)}
    ${Theme.renderTextField(NS, "rep2_telephone_poste", item.rep2_telephone_poste, i18n("REP2_TELEPHONE_POSTE"), 4)}
    ${Theme.renderTextField(NS, "rep2_email", item.rep2_email, i18n("REP2_EMAIL"), 80)}
    ${Theme.renderTextareaField(NS, "rep2_commentaires", item.rep2_commentaires, i18n("REP2_COMMENTAIRES"), 255, false, null, 3)}
`;
}

const block_camions = (item: IState) => {
    return `
`;
}

const block_lots = (item: IState) => {
    return `
`;
}


const formTemplate = (item: IState, paysid: string, institutionbanquaireid: string) => {
    return `
<div class="js-float-menu">
    <ul>
        <li>${Theme.float_menu_button("Adresse")}</li>
        <li>${Theme.float_menu_button("Téléphone")}</li>
        <li>${Theme.float_menu_button("Ciel")}</li>
        <li>${Theme.float_menu_button("Internet")}</li>
        <li>${Theme.float_menu_button("Autres")}</li>
        <li>${Theme.float_menu_button("Dépôt direct")}</li>
        <li>${Theme.float_menu_button("Représentant")}</li>
        <li>${Theme.float_menu_button("Camions")}</li>
        <li>${Theme.float_menu_button("Lots")}</li>
    </ul>
</div>

<div class="columns">
    <div class="column is-8 is-offset-3">
        ${Theme.wrapFieldset("Adresse", block_address(item, paysid))}
        ${Theme.wrapFieldset("Téléphone", block_telephone(item))}
        ${Theme.wrapFieldset("Ciel", block_ciel(item))}
        ${Theme.wrapFieldset("Internet", block_internet(item))}
        ${Theme.wrapFieldset("Autres", block_autres(item))}
        ${Theme.wrapFieldset("Dépôt direct", block_depotdirect(item, institutionbanquaireid))}
        ${Theme.wrapFieldset("Représentant", block_representant(item))}
        ${Theme.wrapFieldset("Camions", block_camions(item))}
        ${Theme.wrapFieldset("Lots", block_lots(item))}
    </div>
</div>

    ${Theme.renderBlame(item, isNew)}
`;

//    return `
//    ${Theme.renderNumberField(NS, "mrcproducteurid", item.mrcproducteurid, i18n("MRCPRODUCTEURID"))}
//    ${Theme.renderCheckboxField(NS, "modifiertrigger", item.modifiertrigger, i18n("MODIFIERTRIGGER"))}
//`;
};

const pageTemplate = (item: IState, form: string, tab: string, warning: string, dirty: string) => {
    let canEdit = true;
    let readonly = !canEdit;

    let canInsert = canEdit && isNew; // && Perm.hasFournisseur_CanAddFournisseur;
    let canDelete = canEdit && !canInsert; // && Perm.hasFournisseur_CanDeleteFournisseur;
    let canAdd = canEdit && !canInsert; // && Perm.hasFournisseur_CanAddFournisseur;
    let canUpdate = canEdit && !isNew;

    let buttons: string[] = [];
    buttons.push(Theme.buttonCancel(NS));
    if (canInsert) buttons.push(Theme.buttonInsert(NS));
    if (canDelete) buttons.push(Theme.buttonDelete(NS));
    if (canAdd) buttons.push(Theme.buttonAddNew(NS, "#/proprietaire/new"));
    if (canUpdate) buttons.push(Theme.buttonUpdate(NS));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, !isNew ? i18n("fournisseur Details") : i18n("New fournisseur"));
    let subtitle = buildSubtitle(xtra, i18n("fournisseur subtitle"));

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

export const fetchState = (id: string) => {
    isNew = (id == "new");
    isDirty = false;
    Router.registerDirtyExit(dirtyExit);
    return App.GET(`/fournisseur/${isNew ? "new" : id}`)
        .then((payload: IPayload) => {
            state = payload.item;
            xtra = payload.xtra;
            fetchedState = Misc.clone(state) as IState;
            key = <IKey>{ id };


        })
        .then(Lookup.fetch_pays())
        .then(Lookup.fetch_institutionBanquaire())

};

export const fetch = (params: string[]) => {
    let id = params[0];
    App.prepareRender(NS, i18n("proprietaire"));
    fetchState(id)
        .then(App.render)
        .catch(App.render);
};

export const render = () => {
    if (!inContext()) return "";
    if (App.fatalError()) return App.fatalErrorTemplate();
    if (state == undefined || Object.keys(state).length == 0)
        return App.warningTemplate() || App.unexpectedTemplate();

    let year = 2020;// Perm.getCurrentYear(); //or something better
    let lookup_pays = Lookup.get_pays(year);
    let lookup_institutionBanquaire = Lookup.get_institutionBanquaire(year);

    let paysid = Theme.renderOptions(lookup_pays, state.paysid, true);
    let institutionbanquaireid = Theme.renderOptions(lookup_institutionBanquaire, state.institutionbanquaireid, true);


    const form = formTemplate(state, paysid, institutionbanquaireid);

    const tab = tabTemplate(state.id, xtra, isNew);
    const dirty = dirtyTemplate();
    const warning = App.warningTemplate();
    return pageTemplate(state, form, tab, warning, dirty);
};

export const postRender = () => {
    if (!inContext()) return;



    App.setPageTitle(isNew ? i18n("New proprietaire") : xtra.title);
};

export const inContext = () => {
    return App.inContext(NS);
};

const getFormState = () => {
    let clone = Misc.clone(state) as IState;
    clone.cletri = Misc.fromInputTextNullable(`${NS}_cletri`, state.cletri);
    clone.nom = Misc.fromInputTextNullable(`${NS}_nom`, state.nom);
    clone.ausoinsde = Misc.fromInputTextNullable(`${NS}_ausoinsde`, state.ausoinsde);
    clone.rue = Misc.fromInputTextNullable(`${NS}_rue`, state.rue);
    clone.ville = Misc.fromInputTextNullable(`${NS}_ville`, state.ville);
    clone.paysid = Misc.fromSelectText(`${NS}_paysid`, state.paysid);
    clone.code_postal = Misc.fromInputTextNullable(`${NS}_code_postal`, state.code_postal);
    clone.telephone = Misc.fromInputTextNullable(`${NS}_telephone`, state.telephone);
    clone.telephone_poste = Misc.fromInputTextNullable(`${NS}_telephone_poste`, state.telephone_poste);
    clone.telecopieur = Misc.fromInputTextNullable(`${NS}_telecopieur`, state.telecopieur);
    clone.telephone2 = Misc.fromInputTextNullable(`${NS}_telephone2`, state.telephone2);
    clone.telephone2_desc = Misc.fromInputTextNullable(`${NS}_telephone2_desc`, state.telephone2_desc);
    clone.telephone2_poste = Misc.fromInputTextNullable(`${NS}_telephone2_poste`, state.telephone2_poste);
    clone.telephone3 = Misc.fromInputTextNullable(`${NS}_telephone3`, state.telephone3);
    clone.telephone3_desc = Misc.fromInputTextNullable(`${NS}_telephone3_desc`, state.telephone3_desc);
    clone.telephone3_poste = Misc.fromInputTextNullable(`${NS}_telephone3_poste`, state.telephone3_poste);
    clone.no_membre = Misc.fromInputTextNullable(`${NS}_no_membre`, state.no_membre);
    clone.resident = Misc.fromInputTextNullable(`${NS}_resident`, state.resident);
    clone.email = Misc.fromInputTextNullable(`${NS}_email`, state.email);
    clone.www = Misc.fromInputTextNullable(`${NS}_www`, state.www);
    clone.commentaires = Misc.fromInputTextNullable(`${NS}_commentaires`, state.commentaires);
    clone.affichercommentaires = Misc.fromInputCheckbox(`${NS}_affichercommentaires`, state.affichercommentaires);
    clone.depotdirect = Misc.fromInputCheckbox(`${NS}_depotdirect`, state.depotdirect);
    clone.institutionbanquaireid = Misc.fromSelectText(`${NS}_institutionbanquaireid`, state.institutionbanquaireid);
    clone.banque_transit = Misc.fromInputTextNullable(`${NS}_banque_transit`, state.banque_transit);
    clone.banque_folio = Misc.fromInputTextNullable(`${NS}_banque_folio`, state.banque_folio);
    clone.no_tps = Misc.fromInputTextNullable(`${NS}_no_tps`, state.no_tps);
    clone.no_tvq = Misc.fromInputTextNullable(`${NS}_no_tvq`, state.no_tvq);
    clone.payera = Misc.fromInputCheckbox(`${NS}_payera`, state.payera);
    clone.payeraid = Misc.fromInputTextNullable(`${NS}_payeraid`, state.payeraid);
    clone.statut = Misc.fromInputTextNullable(`${NS}_statut`, state.statut);
    clone.rep_nom = Misc.fromInputTextNullable(`${NS}_rep_nom`, state.rep_nom);
    clone.rep_telephone = Misc.fromInputTextNullable(`${NS}_rep_telephone`, state.rep_telephone);
    clone.rep_telephone_poste = Misc.fromInputTextNullable(`${NS}_rep_telephone_poste`, state.rep_telephone_poste);
    clone.rep_email = Misc.fromInputTextNullable(`${NS}_rep_email`, state.rep_email);
    clone.enanglais = Misc.fromInputCheckbox(`${NS}_enanglais`, state.enanglais);
    clone.actif = Misc.fromInputCheckbox(`${NS}_actif`, state.actif);
    clone.mrcproducteurid = Misc.fromInputNumberNullable(`${NS}_mrcproducteurid`, state.mrcproducteurid);
    clone.paiementmanuel = Misc.fromInputCheckbox(`${NS}_paiementmanuel`, state.paiementmanuel);
    clone.journal = Misc.fromInputCheckbox(`${NS}_journal`, state.journal);
    clone.recoittps = Misc.fromInputCheckbox(`${NS}_recoittps`, state.recoittps);
    clone.recoittvq = Misc.fromInputCheckbox(`${NS}_recoittvq`, state.recoittvq);
    clone.modifiertrigger = Misc.fromInputCheckbox(`${NS}_modifiertrigger`, state.modifiertrigger);
    clone.isproducteur = Misc.fromInputCheckbox(`${NS}_isproducteur`, state.isproducteur);
    clone.istransporteur = Misc.fromInputCheckbox(`${NS}_istransporteur`, state.istransporteur);
    clone.ischargeur = Misc.fromInputCheckbox(`${NS}_ischargeur`, state.ischargeur);
    clone.isautre = Misc.fromInputCheckbox(`${NS}_isautre`, state.isautre);
    clone.affichercommentairessurpermit = Misc.fromInputCheckbox(`${NS}_affichercommentairessurpermit`, state.affichercommentairessurpermit);
    clone.pasemissionpermis = Misc.fromInputCheckbox(`${NS}_pasemissionpermis`, state.pasemissionpermis);
    clone.generique = Misc.fromInputCheckbox(`${NS}_generique`, state.generique);
    clone.membre_ogc = Misc.fromInputCheckbox(`${NS}_membre_ogc`, state.membre_ogc);
    clone.inscrittps = Misc.fromInputCheckbox(`${NS}_inscrittps`, state.inscrittps);
    clone.inscrittvq = Misc.fromInputCheckbox(`${NS}_inscrittvq`, state.inscrittvq);
    clone.isogc = Misc.fromInputCheckbox(`${NS}_isogc`, state.isogc);
    clone.rep2_nom = Misc.fromInputTextNullable(`${NS}_rep2_nom`, state.rep2_nom);
    clone.rep2_telephone = Misc.fromInputTextNullable(`${NS}_rep2_telephone`, state.rep2_telephone);
    clone.rep2_telephone_poste = Misc.fromInputTextNullable(`${NS}_rep2_telephone_poste`, state.rep2_telephone_poste);
    clone.rep2_email = Misc.fromInputTextNullable(`${NS}_rep2_email`, state.rep2_email);
    clone.rep2_commentaires = Misc.fromInputTextNullable(`${NS}_rep2_commentaires`, state.rep2_commentaires);
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
    App.POST("/fournisseur", Misc.createBlack(formState, blackList))
        .then(payload => {
            let newkey = <IKey>payload;
            Misc.toastSuccessSave();
            Router.goto(`#/proprietaire/${newkey.id}`, 10);
        })
        .catch(App.render);
}

export const save = (done = false) => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
    App.prepareRender();
    App.PUT("/fournisseur", Misc.createBlack(formState, blackList))
        .then(_ => {
            Misc.toastSuccessSave();
            if (done)
                Router.goto(`#/proprietaires/`, 100);
            else
                Router.goto(`#/proprietaire/${key.id}`, 10);
        })
        .catch(App.render);
}

export const drop = () => {
    //(<any>key).updatedUtc = state.updatedUtc;
    App.prepareRender();
    App.DELETE("/fournisseur", key)
        .then(_ => {
            Router.goto(`#/proprietaires/`, 250);
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
