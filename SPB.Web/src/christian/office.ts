// File: office.ts

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
import { tabTemplate, icon, prepareMenu, ISummary, buildTitle, buildSubtitle } from "./layout"

declare const i18n: any;


export const NS = "App_office";

interface IPayload {
    item: IState
    xtra: ISummary
}

interface IKey {
    id: number
}

interface IState {
    id: number
    name: string
    location: string
    openedon: Date
    archive: boolean
    created: Date
    updated: Date
    updatedby: number
    by: string
}



const blackList = ["created", "by"];

let key: IKey;
let state = <IState>{};
let fetchedState = <IState>{};
let xtra: ISummary;
let isNew = false;
let isDirty = false;
let openedonCalendar = new Calendar(`${NS}_openedon`);


const formTemplate = (item: IState) => {

    return `
<div class="columns js-2-columns">
<div class="column is-half">\n
${isNew ? `
` : `
    ${Theme.renderStaticField(Misc.toStaticNumber(item.id), i18n("ID"))}
`}
    ${Theme.renderTextField(NS, "name", item.name, i18n("NAME"), 50, true)}
    ${Theme.renderTextField(NS, "location", item.location, i18n("LOCATION"), 50, true)}
    ${Theme.renderCalendarField(NS, "openedon", openedonCalendar, i18n("OPENEDON"))}
    ${Theme.renderCheckboxField(NS, "archive", item.archive, i18n("ARCHIVE"))}
    </div>
<div class="column is-half">
</div>
</div>

    ${Theme.renderBlame(item, isNew)}
`;
};

const pageTemplate = (item: IState, form: string, tab: string, warning: string, dirty: string) => {
    let canEdit = true;
    let readonly = !canEdit;

    let canInsert = canEdit && isNew; // && Perm.hasOffice_CanAddOffice;
    let canDelete = canEdit && !canInsert; // && Perm.hasOffice_CanDeleteOffice;
    let canAdd = canEdit && !canInsert; // && Perm.hasOffice_CanAddOffice;
    let canUpdate = canEdit && !isNew;

    let buttons: string[] = [];
    buttons.push(Theme.buttonCancel(NS));
    if (canInsert) buttons.push(Theme.buttonInsert(NS));
    if (canDelete) buttons.push(Theme.buttonDelete(NS));
    if (canAdd) buttons.push(Theme.buttonAddNew(NS, "#/office/new"));
    if (canUpdate) buttons.push(Theme.buttonUpdate(NS));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, !isNew ? i18n("office Details") : i18n("New office"));
    let subtitle = buildSubtitle(xtra, i18n("office subtitle"));

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
    return App.GET(`/office/${isNew ? "new" : id}`)
        .then((payload: IPayload) => {
            state = payload.item;
            fetchedState = Misc.clone(state) as IState;
            xtra = payload.xtra;
            key = <IKey>{ id };
            openedonCalendar.setState(state.openedon);

        })
};

export const fetch = (params: string[]) => {
    let id = +params[0];
    App.prepareRender(NS, i18n("office"));
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






    const form = formTemplate(state);

    const tab = tabTemplate(state.id, xtra, isNew);
    const dirty = dirtyTemplate();
    const warning = App.warningTemplate();
    return pageTemplate(state, form, tab, warning, dirty);
};

export const postRender = () => {
    if (!inContext()) return;
    openedonCalendar.postRender();

    App.setPageTitle(isNew ? i18n("New office") : xtra.title);
};

export const inContext = () => {
    return App.inContext(NS);
};

const getFormState = () => {
    let clone = Misc.clone(state) as IState;
    clone.name = Misc.fromInputText(`${NS}_name`, state.name);
    clone.location = Misc.fromInputText(`${NS}_location`, state.location);
    clone.openedon = Misc.fromInputDateNullable(`${NS}_openedon`, state.openedon);
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

export const oncalendar = (id: string) => {
    if (openedonCalendar.id == id) openedonCalendar.toggle();
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
    App.POST("/office", Misc.createBlack(formState, blackList))
        .then(payload => {
            let newkey = <IKey>payload;
            Misc.toastSuccessSave();
            Router.goto(`#/office/${newkey.id}`, 10);
        })
        .catch(App.render);
}

export const save = (done = false) => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
    App.prepareRender();
    App.PUT("/office", Misc.createBlack(formState, blackList))
        .then(_ => {
            Misc.toastSuccessSave();
            if (done)
                Router.goto(`#/offices/`, 100);
            else
                Router.goto(`#/office/${key.id}`, 10);
        })
        .catch(App.render);
}

export const drop = () => {
    (<any>key).updated = state.updated;
    App.prepareRender();
    App.DELETE("/office", key)
        .then(_ => {

            Router.goto(`#/offices/`, 250);
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
