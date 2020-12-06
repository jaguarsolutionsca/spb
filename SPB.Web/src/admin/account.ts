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
    id: number
}

interface IState {
    xtra: any
    id: number
    email: string
    roleMask: number
    resetGuid: string
    resetExpiryUtc: Date
    lastActivityUtc: Date
    archive: boolean
    createdUtc: Date
    updatedUtc: Date
    updatedBy: number
    by: string
    firstName: string
    lastName: string
    regionLUID: number
    regionLUID_Text: string
    districtLUID: number
    districtLUID_Text: string
    phone1: string
    phone2: string
    fax: string
    machineID: number
    currentYear: number
    autoArchive: boolean
    autoLock: boolean
    canExtendInvitation: boolean
    canResetPassword: boolean
    canCreateInvitation: boolean
    emailSubject: string
    emailBody: string
    address: string
    town: string
    postalCode: string
}



let key: IKey;
let state = <IState>{};
let fetchedState = <IState>{};
let isNew = false;
let isDirty = false;
let emailSubject: string;
let emailBody: string;


const formTemplate = (item: IState, roleList: Lookup.Role[]) => {
    const roleTemplate = (role: Lookup.Role, roleMask: number, index: number) => {
        let mask = Math.pow(2, index);
        let selected = (roleMask & mask) != 0;
        return `
        <div>
            <label class="checkbox">
                <input type="checkbox" ${selected ? "checked" : ""} name="${NS}_roles" onchange="${NS}.onchange(this)" data-mask="${mask}"> ${role.name}
            </label>
        </div>`;
    };

    const roleCheckboxes = roleList.reduce((html, one, index) => html + (index > 1 ? roleTemplate(one, item.roleMask, index) : ""), "");

    let pendingMailto = "";
    if (item.emailBody) {
        pendingMailto = `${item.email}?subject=${item.emailSubject}&body=${item.emailBody}`;
    }

    return `
    <!-- edit -->
    <div class="columns js-2-columns">
    <div class="column">
    ${Theme.renderTextField(NS, "email", item.email, i18n("EMAIL"), 50, true)}
${!isNew ? `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label">&nbsp;</label></div>
        <div class="field-body"><span><a href="mailto:${item.email}"><i class="far fa-envelope"></i> ${i18n("SEND EMAIL TO")} ${item.email}</a></span></div>
    </div>
` : ``}
    ${Theme.renderTextField(NS, "firstName", item.firstName, i18n("FIRSTNAME"), 50, true)}
    ${Theme.renderTextField(NS, "lastName", item.lastName, i18n("LASTNAME"), 50, true)}
    ${Theme.renderTextField(NS, "address", item.address, i18n("ADDRESS"), 50)}
    ${Theme.renderTextField(NS, "town", item.town, i18n("TOWN"), 50, false, "js-width-50")}
    ${Theme.renderTextField(NS, "postalCode", item.postalCode, i18n("POSTALCODE"), 50, false, "js-width-25")}
    ${Theme.renderTextField(NS, "phone1", item.phone1, i18n("PHONE1"), 50, false, "js-width-50")}
    ${Theme.renderTextField(NS, "phone2", item.phone2, i18n("PHONE2"), 50, false, "js-width-50")}
    ${Theme.renderTextField(NS, "fax", item.fax, i18n("FAX"), 50, false, "js-width-50")}
    ${Theme.renderNumberField(NS, "machineID", item.machineID, i18n("MACHINEID"), false, "js-width-25")}

${!isNew ? `
    ${Theme.renderStaticField(Misc.toStaticDateTime(item.resetExpiryUtc), i18n("RESETEXPIRYUTC"))}
    ${Theme.renderStaticField(Misc.toStaticDateTime(item.lastActivityUtc), i18n("LASTACTIVITYUTC"))}
    <div class="field is-horizontal">
        <div class="field-label"><label class="label">&nbsp;</label></div>
        <div class="field-body">${resetPasswordButton(item)}</div>
    </div>
` : ``}
${pendingMailto ? `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label">Pending Email</label></div>
        <div class="field-body"><span><a href="mailto:${pendingMailto}"><i class="far fa-envelope"></i> Send Pending Email</a></span></div>
    </div>
` : ``}
    </div>
    <div class="column">
    ${Theme.renderNumberField(NS, "currentYear", item.currentYear, i18n("CURRENTYEAR"), true, "js-width-25", "User can only enter data for this fire season")}
    <div class="field is-horizontal">
        <div class="field-label"><label class="label" for="${NS}_roleMask">${i18n("ROLEMASK")}</label></div>
        <div class="field-body">
            <div class="field js-checkbox-row">
                ${roleCheckboxes}
            </div>
        </div>
    </div>
    <!--${Theme.renderCheckboxField(NS, "autoLock", item.autoLock, i18n("AUTOLOCK"), "Lock user out of OpsFMS after 5 minutes of inactivity")}-->
    ${Theme.renderCheckboxField(NS, "autoArchive", item.autoArchive, i18n("AUTOARCHIVE"), "<em>Flag for Archive</em> after 4 months of inactivity")}
${!isNew ? `
    ${Theme.renderCheckboxField(NS, "archive", item.archive, i18n("ARCHIVE"), "Disable Account", "User cannot sign-in to OpsFMS when the account is disabled")}
` : ``}
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
    return (isNew || key.id != 1 || Auth.getRoles().indexOf(1) != -1);
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

export const fetchState = (id: number) => {
    isNew = isNaN(id);
    isDirty = false;
    Router.registerDirtyExit(dirtyExit);
    clearState();
    let url = `/account/${isNew ? "new" : id}`;
    return App.GET(url)
        .then(payload => {
            state = payload;
            fetchedState = Misc.clone(state) as IState;
            key = <IKey>{ id };
        })
        .then(Lookup.fetch_authrole())
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

    const form = formTemplate(state, Lookup.authrole);
    emailBody = undefined;

    const tab = tabTemplate(state.id, state.xtra);
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
    clone.email = Misc.fromInputText(`${NS}_email`, state.email);
    clone.roleMask = Misc.fromInputCheckboxMask(`${NS}_roles`, state.roleMask);
    clone.roleMask = (clone.roleMask & 0xFFFFFFFC) | (state.roleMask & 0x00000003);
    clone.archive = Misc.fromInputCheckbox(`${NS}_archive`, state.archive);
    clone.firstName = Misc.fromInputText(`${NS}_firstName`, state.firstName);
    clone.lastName = Misc.fromInputText(`${NS}_lastName`, state.lastName);
    clone.regionLUID = Misc.fromSelectNumber(`${NS}_regionLUID`, state.regionLUID);
    clone.districtLUID = Misc.fromSelectNumber(`${NS}_districtLUID`, state.districtLUID);
    clone.phone1 = Misc.fromInputTextNullable(`${NS}_phone1`, state.phone1);
    clone.phone2 = Misc.fromInputTextNullable(`${NS}_phone2`, state.phone2);
    clone.fax = Misc.fromInputTextNullable(`${NS}_fax`, state.fax);
    clone.machineID = Misc.fromInputNumberNullable(`${NS}_machineID`, state.machineID);
    clone.currentYear = Misc.fromInputNumber(`${NS}_currentYear`, state.currentYear);
    clone.autoArchive = Misc.fromInputCheckbox(`${NS}_autoArchive`, state.autoArchive);
    clone.autoLock = Misc.fromInputCheckbox(`${NS}_autoLock`, state.autoLock);
    clone.address = Misc.fromInputTextNullable(`${NS}_address`, state.address);
    clone.town = Misc.fromInputTextNullable(`${NS}_town`, state.town);
    clone.postalCode = Misc.fromInputTextNullable(`${NS}_postalCode`, state.postalCode);
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
    if (input.id == `${NS}_regionLUID`) {
        state.districtLUID = null;
    }
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
    App.POST("/account", formState)
        .then(payload => {
            let newkey = <IKey>payload;
            emailSubject = payload.emailSubject;
            emailBody = payload.emailBody;
            Misc.toastSuccessSave();
            Router.goto(`#/admin/account/${newkey.id}`, 10);
        })
        .catch(App.render);
}

export const save = (done = false) => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
    App.prepareRender();
    App.PUT("/account", formState)
        .then(_ => {
            Misc.toastSuccessSave();
            if (done)
                Router.goto(`#/admin/accounts/`, 100);
            else
                Router.goto(`#/admin/account/${key.id}`, 10);
        })
        .catch(App.render);
}

export const drop = () => {
    (<any>key).updatedUtc = state.updatedUtc;
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
            Router.goto(`#/admin/account/${key.id}`, 10);
        })
        .catch(App.render);
}

export const createInvitation = () => {
    App.POST("/account/create-invitation", key)
        .then(_ => {
            Misc.toastSuccess(i18n("Invitation sent"));
            Router.goto(`#/admin/account/${key.id}`, 10);
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
