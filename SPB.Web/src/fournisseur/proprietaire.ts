// File: fournisseur.ts

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
import { tabTemplate, icon, buildTitle, buildSubtitle } from "./layout"

declare const i18n: any;


export const NS = "App_proprietaire";

interface IKey {
    id: string
}

interface IState {
    xtra: any
    id: string
    cleTri: string
    nom: string
    auSoinsDe: string
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
}



let key: IKey;
let state = <IState>{};
let fetchedState = <IState>{};
let isNew = false;
let isDirty = false;
let isAudit = false;



const formTemplate = (item: IState, paysID: string, institutionBanquaireID: string) => {
    return `

${isNew ? `
` : `
    ${Theme.renderStaticField(Misc.toStaticText(item.id), i18n("ID"))}
`}
    ${Theme.renderTextField(NS, "id", item.id, i18n("ID"), 15, true)}
    ${Theme.renderTextField(NS, "cleTri", item.cleTri, i18n("CLETRI"), 15)}
    ${Theme.renderTextField(NS, "nom", item.nom, i18n("NOM"), 40)}
    ${Theme.renderTextField(NS, "auSoinsDe", item.auSoinsDe, i18n("AUSOINSDE"), 30)}
    ${Theme.renderTextField(NS, "rue", item.rue, i18n("RUE"), 30)}
    ${Theme.renderTextField(NS, "ville", item.ville, i18n("VILLE"), 30)}
    ${Theme.renderDropdownField(NS, "paysID", paysID, i18n("PAYSID"))}
    ${Theme.renderTextField(NS, "code_postal", item.code_postal, i18n("CODE_POSTAL"), 7)}
    ${Theme.renderTextField(NS, "telephone", item.telephone, i18n("TELEPHONE"), 12)}
    ${Theme.renderTextField(NS, "telephone_Poste", item.telephone_Poste, i18n("TELEPHONE_POSTE"), 4)}
    ${Theme.renderTextField(NS, "telecopieur", item.telecopieur, i18n("TELECOPIEUR"), 12)}
    ${Theme.renderTextField(NS, "telephone2", item.telephone2, i18n("TELEPHONE2"), 12)}
    ${Theme.renderTextField(NS, "telephone2_Desc", item.telephone2_Desc, i18n("TELEPHONE2_DESC"), 20)}
    ${Theme.renderTextField(NS, "telephone2_Poste", item.telephone2_Poste, i18n("TELEPHONE2_POSTE"), 4)}
    ${Theme.renderTextField(NS, "telephone3", item.telephone3, i18n("TELEPHONE3"), 12)}
    ${Theme.renderTextField(NS, "telephone3_Desc", item.telephone3_Desc, i18n("TELEPHONE3_DESC"), 20)}
    ${Theme.renderTextField(NS, "telephone3_Poste", item.telephone3_Poste, i18n("TELEPHONE3_POSTE"), 4)}
    ${Theme.renderTextField(NS, "no_membre", item.no_membre, i18n("NO_MEMBRE"), 10)}
    ${Theme.renderTextField(NS, "resident", item.resident, i18n("RESIDENT"), 1)}
    ${Theme.renderTextField(NS, "email", item.email, i18n("EMAIL"), 80)}
    ${Theme.renderTextField(NS, "www", item.www, i18n("WWW"), 80)}
    ${Theme.renderTextField(NS, "commentaires", item.commentaires, i18n("COMMENTAIRES"), 255)}
    ${Theme.renderCheckboxField(NS, "afficherCommentaires", item.afficherCommentaires, i18n("AFFICHERCOMMENTAIRES"))}
    ${Theme.renderCheckboxField(NS, "depotDirect", item.depotDirect, i18n("DEPOTDIRECT"))}
    ${Theme.renderDropdownField(NS, "institutionBanquaireID", institutionBanquaireID, i18n("INSTITUTIONBANQUAIREID"))}
    ${Theme.renderTextField(NS, "banque_transit", item.banque_transit, i18n("BANQUE_TRANSIT"), 5)}
    ${Theme.renderTextField(NS, "banque_folio", item.banque_folio, i18n("BANQUE_FOLIO"), 12)}
    ${Theme.renderTextField(NS, "no_TPS", item.no_TPS, i18n("NO_TPS"), 25)}
    ${Theme.renderTextField(NS, "no_TVQ", item.no_TVQ, i18n("NO_TVQ"), 25)}
    ${Theme.renderCheckboxField(NS, "payerA", item.payerA, i18n("PAYERA"))}
    ${Theme.renderTextField(NS, "payerAID", item.payerAID, i18n("PAYERAID"), 15)}
    ${Theme.renderTextField(NS, "statut", item.statut, i18n("STATUT"), 50)}
    ${Theme.renderTextField(NS, "rep_Nom", item.rep_Nom, i18n("REP_NOM"), 30)}
    ${Theme.renderTextField(NS, "rep_Telephone", item.rep_Telephone, i18n("REP_TELEPHONE"), 12)}
    ${Theme.renderTextField(NS, "rep_Telephone_Poste", item.rep_Telephone_Poste, i18n("REP_TELEPHONE_POSTE"), 4)}
    ${Theme.renderTextField(NS, "rep_Email", item.rep_Email, i18n("REP_EMAIL"), 80)}
    ${Theme.renderCheckboxField(NS, "enAnglais", item.enAnglais, i18n("ENANGLAIS"))}
    ${Theme.renderCheckboxField(NS, "actif", item.actif, i18n("ACTIF"))}
    ${Theme.renderNumberField(NS, "mRCProducteurID", item.mRCProducteurID, i18n("MRCPRODUCTEURID"))}
    ${Theme.renderCheckboxField(NS, "paiementManuel", item.paiementManuel, i18n("PAIEMENTMANUEL"))}
    ${Theme.renderCheckboxField(NS, "journal", item.journal, i18n("JOURNAL"))}
    ${Theme.renderCheckboxField(NS, "recoitTPS", item.recoitTPS, i18n("RECOITTPS"))}
    ${Theme.renderCheckboxField(NS, "recoitTVQ", item.recoitTVQ, i18n("RECOITTVQ"))}
    ${Theme.renderCheckboxField(NS, "modifierTrigger", item.modifierTrigger, i18n("MODIFIERTRIGGER"))}
    ${Theme.renderCheckboxField(NS, "isProducteur", item.isProducteur, i18n("ISPRODUCTEUR"))}
    ${Theme.renderCheckboxField(NS, "isTransporteur", item.isTransporteur, i18n("ISTRANSPORTEUR"))}
    ${Theme.renderCheckboxField(NS, "isChargeur", item.isChargeur, i18n("ISCHARGEUR"))}
    ${Theme.renderCheckboxField(NS, "isAutre", item.isAutre, i18n("ISAUTRE"))}
    ${Theme.renderCheckboxField(NS, "afficherCommentairesSurPermit", item.afficherCommentairesSurPermit, i18n("AFFICHERCOMMENTAIRESSURPERMIT"))}
    ${Theme.renderCheckboxField(NS, "pasEmissionPermis", item.pasEmissionPermis, i18n("PASEMISSIONPERMIS"))}
    ${Theme.renderCheckboxField(NS, "generique", item.generique, i18n("GENERIQUE"))}
    ${Theme.renderCheckboxField(NS, "membre_OGC", item.membre_OGC, i18n("MEMBRE_OGC"))}
    ${Theme.renderCheckboxField(NS, "inscritTPS", item.inscritTPS, i18n("INSCRITTPS"))}
    ${Theme.renderCheckboxField(NS, "inscritTVQ", item.inscritTVQ, i18n("INSCRITTVQ"))}
    ${Theme.renderCheckboxField(NS, "isOGC", item.isOGC, i18n("ISOGC"))}
    ${Theme.renderTextField(NS, "rep2_Nom", item.rep2_Nom, i18n("REP2_NOM"), 80)}
    ${Theme.renderTextField(NS, "rep2_Telephone", item.rep2_Telephone, i18n("REP2_TELEPHONE"), 12)}
    ${Theme.renderTextField(NS, "rep2_Telephone_Poste", item.rep2_Telephone_Poste, i18n("REP2_TELEPHONE_POSTE"), 4)}
    ${Theme.renderTextField(NS, "rep2_Email", item.rep2_Email, i18n("REP2_EMAIL"), 80)}
    ${Theme.renderTextField(NS, "rep2_Commentaires", item.rep2_Commentaires, i18n("REP2_COMMENTAIRES"), 255)}
    ${Theme.renderBlame(item, isNew)}
`;
};

const pageTemplate = (item: IState, form: string, tab: string, warning: string, dirty: string) => {
    let canEdit = true;
    let readonly = !canEdit || isAudit;

    let canInsert = canEdit && isNew; // && Perm.hasFournisseur_CanAddFournisseur;
    let canDelete = canEdit && !canInsert; // && Perm.hasFournisseur_CanDeleteFournisseur;
    let canAdd = canEdit && !canInsert; // && Perm.hasFournisseur_CanAddFournisseur;
    let canUpdate = canEdit && !isNew;

    let buttons: string[] = [];
    buttons.push(Theme.buttonCancel(NS));
    if (canInsert) buttons.push(Theme.buttonInsert(NS));
    if (canDelete) buttons.push(Theme.buttonDelete(NS));
    if (canAdd) buttons.push(Theme.buttonAddNew(NS, "#/fournisseur/new"));
    if (canUpdate) buttons.push(Theme.buttonUpdate(NS));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(item.xtra, i18n("fournisseur Details"), isNew, i18n("New fournisseur"));
    let subtitle = buildSubtitle(item.xtra, i18n("fournisseur subtitle"));

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

const clearState = () => {
    state = <IState>{};
    return Promise.resolve();
};

export const fetchState = (id: string, auditid?: number) => {
    isNew = (id == "new");
    isDirty = false;
    isAudit = (auditid != undefined);
    Router.registerDirtyExit(dirtyExit);
    clearState();
    let url = (!isAudit ? `/fournisseur/${isNew ? "new" : id}` : `/fournisseur/audit/${id}/${auditid}`);
    return App.GET(url)
        .then(payload => {
            state = payload;
            fetchedState = Misc.clone(state) as IState;
            key = <IKey>{ id };


        })
        .then(Lookup.fetch_pays())
        .then(Lookup.fetch_institutionBanquaire())

};

export const fetch = (params: string[]) => {
    let id = params[0];
    App.prepareRender(NS, i18n("fournisseur"));
    fetchState(id)
        .then(App.render)
        .catch(App.render);
};

export const fetchAudit = (id: string, auditid: number) => {
    App.prepareRender(NS, i18n("fournisseur_select"));
    fetchState(id, auditid)
        .then(App.render)
        .catch(App.render);
};

export const render = () => {
    if (!inContext()) return "";
    if (App.fatalError()) return App.fatalErrorTemplate();
    if (state == undefined || Object.keys(state).length == 0)
        return App.warningTemplate() || App.unexpectedTemplate();

    let year = Perm.getCurrentYear(); //or something better
    let lookup_pays = Lookup.get_pays(year);
    let lookup_institutionBanquaire = Lookup.get_institutionBanquaire(year);

    let paysID = Theme.renderOptions(lookup_pays, state.paysID, true);
    let institutionBanquaireID = Theme.renderOptions(lookup_institutionBanquaire, state.institutionBanquaireID, true);


    const form = formTemplate(state, paysID, institutionBanquaireID);

    const tab = tabTemplate(state.id, state.xtra, isNew);
    const dirty = dirtyTemplate();
    const warning = App.warningTemplate();
    return pageTemplate(state, form, tab, warning, dirty);
};

export const postRender = () => {
    if (!inContext()) return;



    App.setPageTitle(isNew ? i18n("New fournisseur") : state.xtra.title);
};

export const inContext = () => {
    return App.inContext(NS);
};

const getFormState = () => {
    let clone = Misc.clone(state) as IState;
    clone.cleTri = Misc.fromInputTextNullable(`${NS}_cleTri`, state.cleTri);
    clone.nom = Misc.fromInputTextNullable(`${NS}_nom`, state.nom);
    clone.auSoinsDe = Misc.fromInputTextNullable(`${NS}_auSoinsDe`, state.auSoinsDe);
    clone.rue = Misc.fromInputTextNullable(`${NS}_rue`, state.rue);
    clone.ville = Misc.fromInputTextNullable(`${NS}_ville`, state.ville);
    clone.paysID = Misc.fromSelectString(`${NS}_paysID`, state.paysID);
    clone.code_postal = Misc.fromInputTextNullable(`${NS}_code_postal`, state.code_postal);
    clone.telephone = Misc.fromInputTextNullable(`${NS}_telephone`, state.telephone);
    clone.telephone_Poste = Misc.fromInputTextNullable(`${NS}_telephone_Poste`, state.telephone_Poste);
    clone.telecopieur = Misc.fromInputTextNullable(`${NS}_telecopieur`, state.telecopieur);
    clone.telephone2 = Misc.fromInputTextNullable(`${NS}_telephone2`, state.telephone2);
    clone.telephone2_Desc = Misc.fromInputTextNullable(`${NS}_telephone2_Desc`, state.telephone2_Desc);
    clone.telephone2_Poste = Misc.fromInputTextNullable(`${NS}_telephone2_Poste`, state.telephone2_Poste);
    clone.telephone3 = Misc.fromInputTextNullable(`${NS}_telephone3`, state.telephone3);
    clone.telephone3_Desc = Misc.fromInputTextNullable(`${NS}_telephone3_Desc`, state.telephone3_Desc);
    clone.telephone3_Poste = Misc.fromInputTextNullable(`${NS}_telephone3_Poste`, state.telephone3_Poste);
    clone.no_membre = Misc.fromInputTextNullable(`${NS}_no_membre`, state.no_membre);
    clone.resident = Misc.fromInputTextNullable(`${NS}_resident`, state.resident);
    clone.email = Misc.fromInputTextNullable(`${NS}_email`, state.email);
    clone.www = Misc.fromInputTextNullable(`${NS}_www`, state.www);
    clone.commentaires = Misc.fromInputTextNullable(`${NS}_commentaires`, state.commentaires);
    clone.afficherCommentaires = Misc.fromInputCheckbox(`${NS}_afficherCommentaires`, state.afficherCommentaires);
    clone.depotDirect = Misc.fromInputCheckbox(`${NS}_depotDirect`, state.depotDirect);
    clone.institutionBanquaireID = Misc.fromSelectString(`${NS}_institutionBanquaireID`, state.institutionBanquaireID);
    clone.banque_transit = Misc.fromInputTextNullable(`${NS}_banque_transit`, state.banque_transit);
    clone.banque_folio = Misc.fromInputTextNullable(`${NS}_banque_folio`, state.banque_folio);
    clone.no_TPS = Misc.fromInputTextNullable(`${NS}_no_TPS`, state.no_TPS);
    clone.no_TVQ = Misc.fromInputTextNullable(`${NS}_no_TVQ`, state.no_TVQ);
    clone.payerA = Misc.fromInputCheckbox(`${NS}_payerA`, state.payerA);
    clone.payerAID = Misc.fromInputTextNullable(`${NS}_payerAID`, state.payerAID);
    clone.statut = Misc.fromInputTextNullable(`${NS}_statut`, state.statut);
    clone.rep_Nom = Misc.fromInputTextNullable(`${NS}_rep_Nom`, state.rep_Nom);
    clone.rep_Telephone = Misc.fromInputTextNullable(`${NS}_rep_Telephone`, state.rep_Telephone);
    clone.rep_Telephone_Poste = Misc.fromInputTextNullable(`${NS}_rep_Telephone_Poste`, state.rep_Telephone_Poste);
    clone.rep_Email = Misc.fromInputTextNullable(`${NS}_rep_Email`, state.rep_Email);
    clone.enAnglais = Misc.fromInputCheckbox(`${NS}_enAnglais`, state.enAnglais);
    clone.actif = Misc.fromInputCheckbox(`${NS}_actif`, state.actif);
    clone.mRCProducteurID = Misc.fromInputNumberNullable(`${NS}_mRCProducteurID`, state.mRCProducteurID);
    clone.paiementManuel = Misc.fromInputCheckbox(`${NS}_paiementManuel`, state.paiementManuel);
    clone.journal = Misc.fromInputCheckbox(`${NS}_journal`, state.journal);
    clone.recoitTPS = Misc.fromInputCheckbox(`${NS}_recoitTPS`, state.recoitTPS);
    clone.recoitTVQ = Misc.fromInputCheckbox(`${NS}_recoitTVQ`, state.recoitTVQ);
    clone.modifierTrigger = Misc.fromInputCheckbox(`${NS}_modifierTrigger`, state.modifierTrigger);
    clone.isProducteur = Misc.fromInputCheckbox(`${NS}_isProducteur`, state.isProducteur);
    clone.isTransporteur = Misc.fromInputCheckbox(`${NS}_isTransporteur`, state.isTransporteur);
    clone.isChargeur = Misc.fromInputCheckbox(`${NS}_isChargeur`, state.isChargeur);
    clone.isAutre = Misc.fromInputCheckbox(`${NS}_isAutre`, state.isAutre);
    clone.afficherCommentairesSurPermit = Misc.fromInputCheckbox(`${NS}_afficherCommentairesSurPermit`, state.afficherCommentairesSurPermit);
    clone.pasEmissionPermis = Misc.fromInputCheckbox(`${NS}_pasEmissionPermis`, state.pasEmissionPermis);
    clone.generique = Misc.fromInputCheckbox(`${NS}_generique`, state.generique);
    clone.membre_OGC = Misc.fromInputCheckbox(`${NS}_membre_OGC`, state.membre_OGC);
    clone.inscritTPS = Misc.fromInputCheckbox(`${NS}_inscritTPS`, state.inscritTPS);
    clone.inscritTVQ = Misc.fromInputCheckbox(`${NS}_inscritTVQ`, state.inscritTVQ);
    clone.isOGC = Misc.fromInputCheckbox(`${NS}_isOGC`, state.isOGC);
    clone.rep2_Nom = Misc.fromInputTextNullable(`${NS}_rep2_Nom`, state.rep2_Nom);
    clone.rep2_Telephone = Misc.fromInputTextNullable(`${NS}_rep2_Telephone`, state.rep2_Telephone);
    clone.rep2_Telephone_Poste = Misc.fromInputTextNullable(`${NS}_rep2_Telephone_Poste`, state.rep2_Telephone_Poste);
    clone.rep2_Email = Misc.fromInputTextNullable(`${NS}_rep2_Email`, state.rep2_Email);
    clone.rep2_Commentaires = Misc.fromInputTextNullable(`${NS}_rep2_Commentaires`, state.rep2_Commentaires);
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
    App.POST("/fournisseur", formState)
        .then(payload => {
            let newkey = <IKey>payload;
            Misc.toastSuccessSave();
            Router.goto(`#/fournisseur/${newkey.id}`, 10);
        })
        .catch(App.render);
}

export const save = (done = false) => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
    App.prepareRender();
    App.PUT("/fournisseur", formState)
        .then(_ => {
            Misc.toastSuccessSave();
            if (done)
                Router.goto(`#/fournisseurs/`, 100);
            else
                Router.goto(`#/fournisseur/${key.id}`, 10);
        })
        .catch(App.render);
}

export const drop = () => {
    //(<any>key).updatedUtc = state.updatedUtc;
    App.prepareRender();
    App.DELETE("/fournisseur", key)
        .then(_ => {
            clearState();
            Router.goto(`#/fournisseurs/`, 250);
        })
        .catch(App.render);
}

const dirtyExit = () => {
    if (isAudit) return false;
    isDirty = !Misc.same(fetchedState, getFormState());
    if (isDirty) {
        setTimeout(() => {
            state = getFormState();
            App.render();
        }, 10);
    }
    return isDirty;
};
