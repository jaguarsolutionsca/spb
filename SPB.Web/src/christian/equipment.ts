// File: equipment.ts

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


export const NS = "App_equipment";

interface IPayload {
    item: IState
    xtra: ISummary
}

interface IKey {
    id: number
}

interface IState {
    id: number
    staffid: number
    staffid_text: string
    name: string
    catluid: number
    catluid_text: string
    price: number
    archive: boolean
    created: Date
    updated: Date
    updatedby: number
    by: string
}



const blackList = ["staffid_text", "catluid_text", "created", "updatedby", "by"];

let key: IKey;
let state = <IState>{};
let fetchedState = <IState>{};
let xtra: ISummary;
let isNew = false;
let isDirty = false;



const formTemplate = (item: IState, catluid: string) => {

    return `
${isNew ? `
` : `
    ${Theme.renderStaticField(Misc.toStaticNumber(item.id), i18n("ID"))}
`}
    ${Theme.renderTextField(NS, "name", item.name, i18n("NAME"), 50, true)}
    ${Theme.renderDropdownField(NS, "catluid", catluid, i18n("CATLUID"))}
    ${Theme.renderNumberField(NS, "price", item.price, i18n("PRICE"))}
    ${Theme.renderCheckboxField(NS, "archive", item.archive, i18n("ARCHIVE"))}
    ${Theme.renderBlame(item, isNew)}
`;
};

const pageTemplate = (item: IState, form: string, tab: string, warning: string, dirty: string) => {
    let canEdit = true;
    let readonly = !canEdit;

    let canInsert = canEdit && isNew; // && Perm.hasEquipment_CanAddEquipment;
    let canDelete = canEdit && !canInsert; // && Perm.hasEquipment_CanDeleteEquipment;
    let canAdd = canEdit && !canInsert; // && Perm.hasEquipment_CanAddEquipment;
    let canUpdate = canEdit && !isNew;

    let buttons: string[] = [];
    buttons.push(Theme.buttonCancel(NS));
    if (canInsert) buttons.push(Theme.buttonInsert(NS));
    if (canDelete) buttons.push(Theme.buttonDelete(NS));
    if (canAdd) buttons.push(Theme.buttonAddNew(NS, `#/equipment/new/${state.staffid}`));
    if (canUpdate) buttons.push(Theme.buttonUpdate(NS));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, !isNew ? i18n("equipment Details") : i18n("New equipment"));
    let subtitle = buildSubtitle(xtra, `${i18n("Editing equipment")}: <span>${item.name}</span>`);

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

export const fetchState = (id: number, staffid: number) => {
    isNew = isNaN(id);
    isDirty = false;
    Router.registerDirtyExit(dirtyExit);
    return App.GET(`/equipment/${isNew ? `new/${staffid}` : id}/staff`)
        .then((payload: IPayload) => {
            state = payload.item;
            fetchedState = Misc.clone(state) as IState;
            xtra = payload.xtra;
            key = <IKey>{ id };


        })
        .then(Lookup.fetch_cat())

};

export const fetch = (params: string[]) => {
    let id = +params[0];
    let staffid = +params[1];
    App.prepareRender(NS, i18n("equipment"));
    prepareMenu();
    fetchState(id, staffid)
        .then(App.render)
        .catch(App.render);
};

export const render = () => {
    if (!inContext()) return "";
    if (App.fatalError()) return App.fatalErrorTemplate();
    if (state == undefined || Object.keys(state).length == 0)
        return App.warningTemplate() || App.unexpectedTemplate();

    let year = Perm.getCurrentYear(); //or something better

    let lookup_cat = Lookup.get_cat(year);

    let catluid = Theme.renderOptions(lookup_cat, state.catluid, true);



    const form = formTemplate(state, catluid);

    const tab = tabTemplate(state.staffid, xtra, isNew);
    const dirty = dirtyTemplate();
    const warning = App.warningTemplate();
    return pageTemplate(state, form, tab, warning, dirty);
};

export const postRender = () => {
    if (!inContext()) return;



    App.setPageTitle(isNew ? i18n("New equipment") : xtra.title);
};

export const inContext = () => {
    return App.inContext(NS);
};

const getFormState = () => {
    let clone = Misc.clone(state) as IState;
    clone.staffid = Misc.fromSelectNumber(`${NS}_staffid`, state.staffid);
    clone.name = Misc.fromInputText(`${NS}_name`, state.name);
    clone.catluid = Misc.fromSelectNumber(`${NS}_catluid`, state.catluid);
    clone.price = Misc.fromInputNumberNullable(`${NS}_price`, state.price);
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
    App.POST("/equipment", Misc.createBlack(formState, blackList))
        .then(payload => {
            let newkey = <IKey>payload;
            Misc.toastSuccessSave();
            Router.goto(`#/equipment/${newkey.id}`, 10);
        })
        .catch(App.render);
}

export const save = (done = false) => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
    App.prepareRender();
    App.PUT("/equipment", Misc.createBlack(formState, blackList))
        .then(_ => {
            Misc.toastSuccessSave();
            if (done)
                Router.goto(`#/equipments/${state.staffid}`, 100);
            else
                Router.goto(`#/equipment/${key.id}`, 10);
        })
        .catch(App.render);
}

export const drop = () => {
    (<any>key).updated = state.updated;
    App.prepareRender();
    App.DELETE("/equipment", key)
        .then(_ => {
            let staffid = state.staffid;

            Router.goto(`#/equipments/${staffid}`, 250);
        })
        .catch(App.render);
}

const dirtyExit = () => {
    let masterHasChange = !Misc.same(fetchedState, getFormState());
    let inlineHasChange = false;
    isDirty = masterHasChange || inlineHasChange;
    if (isDirty) {
        setTimeout(() => {
            state = getFormState();
            App.render();
        }, 10);
    }
    return isDirty;
};
