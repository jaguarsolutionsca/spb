// File: account.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import * as Pager from "../../_BaseApp/src/theme/pager"
import * as Auth from "../../_BaseApp/src/auth"
import * as Lookup from "./lookupdata"
import * as Perm from "../permission"
import * as Layout from "./layout"
import { tabTemplate, icon, prepareMenu } from "./layout"

declare const i18n: any;


export const NS = "App_account";

interface IKey {
    uid: number
}

interface IState {
    uid: number
    xtra: any
    cie: number
    cie_Text: string
    email: string
    password: string
    roleLUID: number
    roleLUID_Text: string
    roleMask: number
    isSupport: boolean
    resetGuid: string
    resetExpiry: Date
    lastActivity: Date
    isAdminReset: boolean
    firstName: string
    lastName: string
    useRealEmail: boolean
    archiveDays: number
    readyToArchive: boolean
    currentYear: number
    profile: IProfile
    comment: string
    archive: boolean
    created: Date
    updated: Date
    updatedBy: number
    by: string
    //
    canExtendInvitation: boolean
    canResetPassword: boolean
    canCreateInvitation: boolean
}

interface IProfile {
    AcrobatPath: string
    AutresRapportsPrinterMarginBottom: number
    AutresRapportsPrinterMarginLeft: number
    AutresRapportsPrinterMarginRight: number
    AutresRapportsPrinterMarginTop: number
    ExcelLanguage: string
    FactureFormat: number
    FactureSortType: number
    ImprimanteAutresRapports: string
    ImprimanteDePermis: string
    MunicipaliteSortType: number
    ProprietaireSortType: number
    SignaturePath: string
    SignaturePrint: boolean
    TransporteurSortType: number
}

const blackList = ["cie_Text", "roleLUID_Text", "resetGuid", "created", "updatedBy", "by", "profileJson", "xtra"];


let key: IKey;
let state = <IState>{};
let fetchedState = <IState>{};
let isNew = false;
let isDirty = false;
let emailSubject: string;
let emailBody: string;


const block_account = (item: IState, roleList: Lookup.LookupData[]) => {

    let roleLUID = Theme.renderRadios(NS, "roleLUID", Lookup.authrole, state.roleLUID, false);

    let canCreateFullAccount = true;//Perm.canCreateFullAccount();

    return `
    <div class="columns js-2-columns">
    <div class="column">
    ${canCreateFullAccount ? Theme.renderCheckboxField(NS, "useRealEmail", item.useRealEmail, i18n("USEREALEMAIL"), i18n("USEREALEMAIL_TEXT"), i18n(`USEREALEMAIL_HELP_${item.useRealEmail}`)) : ""}

${item.useRealEmail ? `
    ${Theme.renderTextField2(NS, "email", item.email, i18n("EMAIL"), 50, <Theme.IOptText>{ required: true, size: "js-width-50" })}
    ${!isNew ? `
        <div class="field is-horizontal">
            <div class="field-label"><label class="label">&nbsp;</label></div>
            <div class="field-body"><span><a href="mailto:${item.email}"><i class="far fa-envelope"></i> ${i18n("SEND EMAIL TO")} ${item.email}</a></span></div>
        </div>
    ` : ``}
` : `
    ${Theme.renderTextField2(NS, "email", item.email, i18n("USERNAME"), 50, <Theme.IOptText>{ required: true, size: "js-width-50" })}
    ${Theme.renderTextField2(NS, "password", item.password, i18n("PASSWORD"), 50, <Theme.IOptText>{ required: isNew, size: "js-width-50", help: !isNew ? i18n("PASSWORD_HELP") : undefined, noautocomplete: true })}
`}

    ${Theme.renderTextField(NS, "firstName", item.firstName, i18n("FIRSTNAME"), 50, true)}
    ${Theme.renderTextField(NS, "lastName", item.lastName, i18n("LASTNAME"), 50, true)}

${!isNew ? `
    ${Theme.renderStaticField(Misc.toStaticDateTime(item.resetExpiry), i18n("RESETEXPIRY"))}
    ${Theme.renderStaticField(Misc.toStaticDateTime(item.lastActivity), i18n("LASTACTIVITY"))}
    <div class="field is-horizontal">
        <div class="field-label"><label class="label">&nbsp;</label></div>
        <div class="field-body">${resetPasswordButton(item)}</div>
    </div>
` : ``}
    </div>
    <div class="column">
    ${Theme.renderNumberField(NS, "currentYear", item.currentYear, i18n("CURRENTYEAR"), true, "js-width-25", "User can only enter data for this fire season")}
    ${Theme.renderRadioField(roleLUID, i18n("ROLELUID"))}
    ${Theme.renderNumberField(NS, "archiveDays", item.archiveDays, i18n("ARCHIVEDAYS"), false, "js-width-25", "Duration in days after which an inactive account is archived")}
${!isNew ? `
    ${Theme.renderCheckboxField(NS, "archive", item.archive, i18n("ARCHIVE"), "Disable Account", "User cannot sign-in to OpsFMS when the account is disabled")}
` : ``}
    </div>
    </div>
`;
}

const block_profile = (profile: IProfile, sortOrderKeysID: string) => {
    return `
    <div class="columns js-2-columns">
    <div class="column">
    ${Theme.renderTextField(NS, "profile.AcrobatPath", profile.AcrobatPath, "Chemin d'accès à Acrobat Reader", 100, false)}
    ${Theme.renderDropdownField(NS, "profile.FactureSortType", sortOrderKeysID, "Ordre de tri des factures (croissant)")}
    </div>
    </div>
`;
}

const formTemplate = (item: IState, roleList: Lookup.LookupData[], sortOrderKeysID: string) => {
    return `
<div class="columns">
    <div class="column is-8 is-offset-2">
        ${Theme.wrapFieldset("Compte", block_account(item, roleList))}
        ${Theme.wrapFieldset("Profile", block_profile(item.profile, sortOrderKeysID))}
    </div>
</div>

    ${Theme.renderBlame(item, isNew)}
`;
};

let resetPasswordButton = (item: IState) => {
    let title: string;
    let helpText: string;
    let onclick: string;

    if (item.canResetPassword) {
        title = i18n("Reset Password");
        helpText = i18n("<p><b>Note:</b> This will prevent the user from login until the user re-enters a new password.</p><br><p>An email will be sent to the user with a link to do so.</p>");
        onclick = `${NS}.resetPassword()`;
    }

    if (item.canCreateInvitation) {
        title = i18n("Create Invitation");
        helpText = i18n("<p>Create an invitation for this user to join OpsFMS.</p><br><p>An email will be sent to the user with a link to do so.</p>");
        onclick = `${NS}.createInvitation()`;
    }

    if (item.canExtendInvitation) {
        title = i18n("Extend Invitation");
        helpText = i18n("Re-invite this user to OpsFMS because he/she didn't go through the process before the <b>Password Reset Expiry</b>.</p><br><p>An email will be sent to the user with a link to do so.</p>");
        onclick = `${NS}.createInvitation()`;
    }

    if (title)
        return Theme.renderButtonWithConfirm(title, "fas fa-lock", helpText, onclick, false, false, true);
    else
        return "";
};

const canUpdate = () => {
    return (isNew || key.uid != 1 || Auth.getRoles().indexOf(1) != -1);
}

const pageTemplate = (item: IState, form: string, tab: string, warning: string, dirty: string) => {
    let readonly = !canUpdate();

    let buttons: string[] = [];

    return `
<form onsubmit="return false;" ${readonly ? "class='js-readonly'" : ""}>
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${icon}"></i> <span>${isNew ? i18n("New Account") : item.xtra && item.xtra.title}</span></div>
            <div class="subtitle">${isNew ? i18n("Editing New account") : i18n("Editing account Details")}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", Theme.renderActionButtons2(NS, isNew, `#/admin/account/new`, buttons))}
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
};

export const fetchState = (uid: number) => {
    isNew = isNaN(uid);
    isDirty = false;
    Router.registerDirtyExit(dirtyExit);
    clearState();
    let url = `/account/${isNew ? "new" : uid}`;
    return App.GET(url)
        .then(payload => {
            state = payload;
            fetchedState = Misc.clone(state) as IState;
            key = <IKey>{ uid };
        })
        .then(Lookup.fetch_authrole())
        .then(Lookup.fetch_sortOrderKeys())
};

export const fetch = (params: string[]) => {
    let id = +params[0];
    App.prepareRender(NS, i18n("account"));
    prepareMenu();
    fetchState(id)
        .then(App.render)
        .catch(App.render);
};

export const render = () => {
    if (!inContext()) return "";
    if (App.fatalError()) return App.fatalErrorTemplate();
    if (state == undefined || Object.keys(state).length == 0)
        return App.warningTemplate() || App.unexpectedTemplate();

    let year = state.currentYear;

    let lookup_sortOrderKeys = Lookup.get_sortOrderKeys(year);

    let sortOrderKeysID = Theme.renderOptions(lookup_sortOrderKeys, state.profile.FactureSortType, false);

    const form = formTemplate(state, Lookup.authrole, sortOrderKeysID);
    emailBody = undefined;

    const tab = tabTemplate(state.uid, state.xtra);
    const dirty = dirtyTemplate();
    const warning = App.warningTemplate();
    return pageTemplate(state, form, tab, warning, dirty);
};

export const postRender = () => {
    if (!inContext()) return;

    App.setPageTitle(isNew ? i18n("New account") : state.xtra.title);
};

export const inContext = () => {
    return App.inContext(NS);
};

const getFormState = () => {
    let clone = Misc.clone(state) as IState;
    clone.useRealEmail = Misc.fromInputCheckbox(`${NS}_useRealEmail`, state.useRealEmail);
    clone.email = Misc.fromInputText(`${NS}_email`, state.email);
    clone.password = Misc.fromInputText(`${NS}_password`, state.password);
    clone.firstName = Misc.fromInputText(`${NS}_firstName`, state.firstName);
    clone.lastName = Misc.fromInputText(`${NS}_lastName`, state.lastName);
    clone.currentYear = Misc.fromInputNumber(`${NS}_currentYear`, state.currentYear);
    clone.roleLUID = Misc.fromRadioNumber(`${NS}_roleLUID`, state.roleLUID);
    clone.archiveDays = Misc.fromInputNumberNullable(`${NS}_archiveDays`, state.archiveDays);
    clone.archive = Misc.fromInputCheckbox(`${NS}_archive`, state.archive);
    //
    clone.profile.AcrobatPath = Misc.fromInputText(`${NS}_profile.AcrobatPath`, state.profile.AcrobatPath);
    clone.profile.FactureSortType = Misc.fromSelectNumber(`${NS}_profile.FactureSortType`, state.profile.FactureSortType);
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
    App.POST("/account", Misc.createBlack(formState, blackList))
        .then(payload => {
            let newkey = <IKey>payload;
            emailSubject = payload.emailSubject;
            emailBody = payload.emailBody;
            Misc.toastSuccessSave();
            Router.goto(`#/admin/account/${newkey.uid}`, 10);
        })
        .catch(App.render);
}

export const save = (done = false) => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
    App.prepareRender();
    App.PUT("/account", Misc.createBlack(formState, blackList))
        .then(_ => {
            Misc.toastSuccessSave();
            if (done)
                Router.goto(`#/admin/accounts/`, 100);
            else
                Router.goto(`#/admin/account/${key.uid}`, 10);
        })
        .catch(App.render);
}

export const drop = () => {
    (<any>key).updated = state.updated;
    App.prepareRender();
    App.DELETE("/account", key)
        .then(_ => {
            clearState();
            Router.goto(`#/admin/accounts/`, 250);
        })
        .catch(App.render);
}

export const resetPassword = () => {
    App.POST("/account/reset-password", key)
        .then(_ => {
            Misc.toastSuccess(i18n("Password reset sent"));
            Router.goto(`#/admin/account/${key.uid}`, 10);
        })
        .catch(App.render);
}

export const createInvitation = () => {
    App.POST("/account/create-invitation", key)
        .then(_ => {
            Misc.toastSuccess(i18n("Invitation sent"));
            Router.goto(`#/admin/account/${key.uid}`, 10);
        })
        .catch(App.render);
}

const dirtyExit = () => {
    //console.log(fetchedState); console.log(getFormState())
    isDirty = !Misc.same(fetchedState, getFormState());
    if (isDirty) {
        setTimeout(() => {
            state = getFormState();
            App.render();
        }, 10);
    }
    return isDirty;
};
