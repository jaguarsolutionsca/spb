// File: staff.ts

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
import { tabTemplate, icon, prepareMenu, ISummary, buildTitle, buildSubtitle } from "./layout_2"

declare const i18n: any;


export const NS = "App_staff_2";

interface IPayload {
    item: IState
    xtra: ISummary
}

interface IKey {
    id: number
}

interface IState {
    id: number
    firstname: string
    lastname: string
    officeid: number
    officeid_text: string
    jobid: number
    jobid_text: string
    archive: boolean
    created: Date
    updated: Date
    updatedby: number
    by: string
}



const blackList = ["officeid_text", "jobid_text", "created", "updatedby", "by"];

let key: IKey;
let state = <IState>{};
let fetchedState = <IState>{};
let xtra: ISummary;
let isNew = false;
let isDirty = false;



const formTemplate = (item: IState, officeid: string, jobid: string) => {

    return `
${isNew ? `
` : `
    ${Theme.renderStaticField(Misc.toStaticNumber(item.id), i18n("ID"))}
`}
    ${Theme.renderTextField(NS, "firstname", item.firstname, i18n("FIRSTNAME"), 50, true)}
    ${Theme.renderTextField(NS, "lastname", item.lastname, i18n("LASTNAME"), 50, true)}
    ${Theme.renderDropdownField(NS, "officeid", officeid, i18n("OFFICEID"))}
    ${Theme.renderDropdownField(NS, "jobid", jobid, i18n("JOBID"))}
    ${Theme.renderCheckboxField(NS, "archive", item.archive, i18n("ARCHIVE"))}
    ${Theme.renderBlame(item, isNew)}
`;
};

const pageTemplate = (item: IState, form: string, tab: string, warning: string, dirty: string) => {
    let canEdit = true;
    let readonly = !canEdit;

    let canInsert = canEdit && isNew; // && Perm.hasStaff_CanAddStaff;
    let canDelete = canEdit && !canInsert; // && Perm.hasStaff_CanDeleteStaff;
    let canAdd = canEdit && !canInsert; // && Perm.hasStaff_CanAddStaff;
    let canUpdate = canEdit && !isNew;

    let buttons: string[] = [];
    buttons.push(Theme.buttonCancel(NS));
    if (canInsert) buttons.push(Theme.buttonInsert(NS));
    if (canDelete) buttons.push(Theme.buttonDelete(NS));
    if (canAdd) buttons.push(Theme.buttonAddNew(NS, `#/staff_2/new`));
    if (canUpdate) buttons.push(Theme.buttonUpdate(NS));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, !isNew ? i18n("staff Details") : i18n("New staff"));
    let subtitle = buildSubtitle(xtra, i18n("staff subtitle"));

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
    return App.GET(`/staff/${isNew ? "new" : id}`)
        .then((payload: IPayload) => {
            state = payload.item;
            fetchedState = Misc.clone(state) as IState;
            xtra = payload.xtra;
            key = <IKey>{ id };


        })
        .then(Lookup.fetch_office())
        .then(Lookup.fetch_job())

};

export const fetch = (params: string[]) => {
    let id = +params[0];
    App.prepareRender(NS, i18n("staff"));
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

    let year = Perm.getCurrentYear(); //or something better

    let lookup_office = Lookup.get_office(year);
    let lookup_job = Lookup.get_job(year);

    let officeid = Theme.renderOptions(lookup_office, state.officeid, true);
    let jobid = Theme.renderOptions(lookup_job, state.jobid, true);


    const form = formTemplate(state, officeid, jobid);

    const tab = tabTemplate(state.id, xtra, isNew);
    const dirty = dirtyTemplate();
    const warning = App.warningTemplate();
    return pageTemplate(state, form, tab, warning, dirty);
};

export const postRender = () => {
    if (!inContext()) return;



    App.setPageTitle(isNew ? i18n("New staff") : xtra.title);
};

export const inContext = () => {
    return App.inContext(NS);
};

const getFormState = () => {
    let clone = Misc.clone(state) as IState;
    clone.firstname = Misc.fromInputText(`${NS}_firstname`, state.firstname);
    clone.lastname = Misc.fromInputText(`${NS}_lastname`, state.lastname);
    clone.officeid = Misc.fromSelectNumber(`${NS}_officeid`, state.officeid);
    clone.jobid = Misc.fromSelectNumber(`${NS}_jobid`, state.jobid);
    clone.archive = Misc.fromInputCheckbox(`${NS}_archive`, state.archive);
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
    App.POST("/staff", Misc.createBlack(formState, blackList))
        .then(payload => {
            let newkey = <IKey>payload;
            Misc.toastSuccessSave();
            Router.goto(`#/staff_2/${newkey.id}`, 10);
        })
        .catch(App.render);
}

export const save = (done = false) => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
    App.prepareRender();
    App.PUT("/staff", Misc.createBlack(formState, blackList))
        .then(_ => {
            Misc.toastSuccessSave();
            if (done)
                Router.goto(`#/staffs_2/`, 100);
            else
                Router.goto(`#/staff_2/${key.id}`, 10);
        })
        .catch(App.render);
}

export const drop = () => {
    (<any>key).updated = state.updated;
    App.prepareRender();
    App.DELETE("/staff", key)
        .then(_ => {

            Router.goto(`#/staffs_2/`, 250);
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
