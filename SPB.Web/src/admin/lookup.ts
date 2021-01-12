// File: lookup.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Perm from "../permission"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import { tabTemplate, icon, prepareMenu } from "./layout"

declare const i18n: any;


export const NS = "App_Lookup";

interface IKey {
    id: number
    updatedUtc: Date
}

interface IState {
    xtra: any
    id: number
    groupe: string
    code: string
    description: string
    value1: string
    value2: string
    value3: string
    started: number
    ended: number
    sortOrder: number
    archive: boolean
    createdUtc: Date
    updatedUtc: Date
    updatedBy: number
    by: string
}



let key: IKey;
let state = <IState>{};
let fetchedState = <IState>{};
let isNew = false;
let isDirty = false;


const formTemplate = (item: IState, ) => {
    return `
<style>#${NS}_value3 { font-family: monospace; }</style>
    ${Theme.renderTextField(NS, "description", item.description, i18n("DESCRIPTION"), 50, true, "js-width-50")}
    ${Theme.renderTextField(NS, "code", item.code, i18n("CODE"), 9, false, "js-width-10")}
    ${Theme.renderTextField(NS, "value1", item.value1, i18n("VALUE1"), 50, false, "js-width-50")}
    ${Theme.renderTextField(NS, "value2", item.value2, i18n("VALUE2"), 50, false, "js-width-50")}
    ${Theme.renderTextareaField(NS, "value3", item.value3, i18n("VALUE3"), 1024, false, null, 5)}
    ${Theme.renderNumberField(NS, "started", item.started, i18n("STARTED"), false, "js-width-10")}
    ${Theme.renderNumberField(NS, "ended", item.ended, i18n("ENDED"), false, "js-width-10")}
    ${Theme.renderNumberField(NS, "sortOrder", item.sortOrder, i18n("SORTORDER"))}
    ${Theme.renderBlame(item, isNew)}
`;
};

const pageTemplate = (item: IState, form: string, tab: string, warning: string, dirty: string) => {
    let readonly = false;

    let buttons: string[] = [];

    return `
<form onsubmit="return false;" ${readonly ? "class='js-readonly'" : ""}>
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${icon}"></i> <span>${isNew ? i18n("(new)") : item.xtra && item.xtra.title}</span></div>
            <div class="subtitle">${isNew ? i18n("Editing New Entry") : i18n("Editing Entry Details")}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", Theme.renderActionButtons2(NS, isNew, `#/admin/lookup/new/${state.groupe}`, buttons))}
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

export const fetchState = (id: number, groupe?: string) => {
    isNew = isNaN(id);
    isDirty = false;
    Router.registerDirtyExit(dirtyExit);
    clearState();
    let url = `/lookup/${isNew ? `new/${groupe}` : id}`;
    return App.GET(url)
        .then(payload => {
            state = payload;
            fetchedState = Misc.clone(state) as IState;
            key = <IKey>{ id };


        })

};

export const fetch = (params: string[]) => {
    let id = +params[0];
    let groupe = (params.length > 1 ? params[1] : null);
    App.prepareRender(NS, i18n("Lookup"));
    prepareMenu();
    fetchState(id, groupe)
        .then(App.render)
        .catch(App.render);
};

export const render = () => {
    if (!inContext()) return "";
    if (App.fatalError()) return App.fatalErrorTemplate();
    if (state == undefined || Object.keys(state).length == 0)
        return App.warningTemplate() || App.unexpectedTemplate();



    const form = formTemplate(state);

    const tab = tabTemplate(state.id, null); //state.groupe.toLowerCase());
    const dirty = dirtyTemplate();
    const warning = App.warningTemplate();
    return pageTemplate(state, form, tab, warning, dirty);
};

export const postRender = () => {
    if (!inContext()) return;

    App.setPageTitle(`${state.xtra.title} : ${isNew ? i18n("New Entry") : ""}`);
};

const inContext = () => {
    return App.inContext(NS);
};

const getFormState = () => {
    let clone = Misc.clone(state) as IState;
    clone.id = Misc.fromInputNumber("App_Lookup_id", state.id);
    clone.groupe = Misc.fromInputText("App_Lookup_groupe", state.groupe);
    clone.code = Misc.fromInputTextNullable("App_Lookup_code", state.code);
    clone.description = Misc.fromInputText("App_Lookup_description", state.description);
    clone.value1 = Misc.fromInputTextNullable("App_Lookup_value1", state.value1);
    clone.value2 = Misc.fromInputTextNullable("App_Lookup_value2", state.value2);
    clone.value3 = Misc.fromInputTextNullable("App_Lookup_value3", state.value3);
    clone.started = Misc.fromInputNumber("App_Lookup_started", state.started);
    clone.ended = Misc.fromInputNumberNullable("App_Lookup_ended", state.ended);
    clone.sortOrder = Misc.fromInputNumberNullable("App_Lookup_sortOrder", state.sortOrder);
    clone.archive = Misc.fromInputCheckbox("App_Lookup_archive", state.archive);
    return clone;
};

const valid = (formState: IState): boolean => {
    //if (formState.somefield.length == 0) App.setError("Somefield is required");
    return App.hasNoError();
};

const html5Valid = (): boolean => {
    document.getElementById("App_Lookup_dummy_submit").click();
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
    App.POST("/lookup", formState)
        .then(payload => {
            let newkey = <IKey>payload;
            Misc.toastSuccessSave();
            Router.goto(`#/admin/lookup/${newkey.id}`, 10);
        })
        .catch(App.render);
}

export const save = (done = false) => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
    App.prepareRender();
    App.PUT("/lookup", formState)
        .then(_ => {
            Misc.toastSuccessSave();
            if (done)
                Router.goto(`#/admin/lookups/${state.groupe.toLowerCase()}`, 100);
            else
                Router.goto(`#/admin/lookup/${key.id}`, 10);
        })
        .catch(App.render);
}

export const drop = () => {
    key.updatedUtc = state.updatedUtc;
    App.prepareRender();
    App.DELETE("/lookup", key)
        .then(_ => {
            let groupe = state.groupe;
            clearState();
            Router.goto(`#/admin/lookups/${groupe}`, 250);
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
