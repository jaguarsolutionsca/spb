// File: lookup.ts

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
import { tabTemplate, icon, prepareMenu, ISummary, buildTitle, buildSubtitle } from "./layout1"

declare const i18n: any;


export const NS = "App_lookup";

interface IPayload {
    item: IState
    xtra: ISummary
}

interface IKey {
    id: number
}

interface IState {
    id: number
    cie: number
    cie_text: string
    groupe: string
    code: string
    description: string
    value1: string
    value2: string
    value3: string
    started: number
    ended: number
    sortorder: number
    created: Date
    updated: Date
    updatedby: number
    by: string
}



const blackList = ["cie_text"];

let key: IKey;
let state = <IState>{};
let fetchedState = <IState>{};
let xtra: ISummary;
let isNew = false;
let isDirty = false;



const formTemplate = (item: IState, cie: string) => {

    return `

    ${Theme.renderDropdownField(NS, "cie", cie, i18n("CIE"))}
    ${Theme.renderTextField(NS, "groupe", item.groupe, i18n("GROUPE"), 12, true)}
    ${Theme.renderTextField(NS, "code", item.code, i18n("CODE"), 12)}
    ${Theme.renderTextField(NS, "description", item.description, i18n("DESCRIPTION"), 50, true)}
    ${Theme.renderTextField(NS, "value1", item.value1, i18n("VALUE1"), 50)}
    ${Theme.renderTextField(NS, "value2", item.value2, i18n("VALUE2"), 50)}
    ${Theme.renderTextField(NS, "value3", item.value3, i18n("VALUE3"), 1024)}
    ${Theme.renderNumberField(NS, "started", item.started, i18n("STARTED"), true)}
    ${Theme.renderNumberField(NS, "ended", item.ended, i18n("ENDED"))}
    ${Theme.renderNumberField(NS, "sortorder", item.sortorder, i18n("SORTORDER"))}
    ${Theme.renderBlame(item, isNew)}
`;
};


const pageTemplate = (item: IState, form: string, tab: string, warning: string, dirty: string) => {
    let canEdit = true;
    let readonly = !canEdit;

    let canInsert = canEdit && isNew; // && Perm.hasLookup_CanAddLookup;
    let canDelete = canEdit && !canInsert; // && Perm.hasLookup_CanDeleteLookup;
    let canAdd = canEdit && !canInsert; // && Perm.hasLookup_CanAddLookup;
    let canUpdate = canEdit && !isNew;

    let buttons: string[] = [];
    buttons.push(Theme.buttonCancel(NS));
    if (canInsert) buttons.push(Theme.buttonInsert(NS));
    if (canDelete) buttons.push(Theme.buttonDelete(NS));
    if (canAdd) buttons.push(Theme.buttonAddNew(NS, "#/admin/lookup/new"));
    if (canUpdate) buttons.push(Theme.buttonUpdate(NS));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, !isNew ? i18n("lookup Details") : i18n("New lookup"));
    let subtitle = buildSubtitle(xtra, i18n("lookup subtitle"));

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

export const fetchState = (id: number, groupe?: string) => {
    isNew = isNaN(id);
    isDirty = false;
    Router.registerDirtyExit(dirtyExit);
    return App.GET(`/lookup/${isNew ? `new/${groupe}` : id}`)
        .then((payload: IPayload) => {
            state = payload.item;
            fetchedState = Misc.clone(state) as IState;
            xtra = payload.xtra;
            key = <IKey>{ id };


        })
        .then(Lookup.fetch_cIE())

};

export const fetch = (params: string[]) => {
    let id = +params[0];
    let groupe = (params.length > 1 ? params[1] : null);
    App.prepareRender(NS, i18n("lookup"));
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

    let year = Perm.getCurrentYear(); //or something better

    let lookup_cIE = Lookup.get_cIE(year);

    let cie = Theme.renderOptions(lookup_cIE, state.cie, true);


    const form = formTemplate(state, cie);

    const tab = tabTemplate(state.id, state.groupe.toLowerCase());
    const dirty = dirtyTemplate();
    const warning = App.warningTemplate();
    return pageTemplate(state, form, tab, warning, dirty);
};

export const postRender = () => {
    if (!inContext()) return;



    App.setPageTitle(isNew ? i18n("New lookup") : xtra.title);
};

export const inContext = () => {
    return App.inContext(NS);
};

const getFormState = () => {
    let clone = Misc.clone(state) as IState;
    clone.cie = Misc.fromSelectNumber(`${NS}_cie`, state.cie);
    clone.groupe = Misc.fromInputText(`${NS}_groupe`, state.groupe);
    clone.code = Misc.fromInputTextNullable(`${NS}_code`, state.code);
    clone.description = Misc.fromInputText(`${NS}_description`, state.description);
    clone.value1 = Misc.fromInputTextNullable(`${NS}_value1`, state.value1);
    clone.value2 = Misc.fromInputTextNullable(`${NS}_value2`, state.value2);
    clone.value3 = Misc.fromInputTextNullable(`${NS}_value3`, state.value3);
    clone.started = Misc.fromInputNumber(`${NS}_started`, state.started);
    clone.ended = Misc.fromInputNumberNullable(`${NS}_ended`, state.ended);
    clone.sortorder = Misc.fromInputNumberNullable(`${NS}_sortorder`, state.sortorder);
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
    App.POST("/lookup", Misc.createBlack(formState, blackList))
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
    App.PUT("/lookup", Misc.createBlack(formState, blackList))
        .then(_ => {
            Misc.toastSuccessSave();
            if (done)
                Router.goto(`#/admin/lookups/`, 100);
            else
                Router.goto(`#/admin/lookup/${key.id}`, 10);
        })
        .catch(App.render);
}

export const drop = () => {
    (<any>key).updated = state.updated;
    App.prepareRender();
    App.DELETE("/lookup", key)
        .then(_ => {

            Router.goto(`#/admin/lookups/`, 250);
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
