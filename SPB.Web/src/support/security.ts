// File: network.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import * as Pager from "../../_BaseApp/src/theme/pager"
import * as Auth from "../../_BaseApp/src/auth"
import * as Lookup from "../admin/lookupdata"
import * as Perm from "../permission"
import { tabTemplate, icon } from "../admin/layout"

declare const i18n: any;


export const NS = "App_security";

interface IKey {
    cie: number
}

interface IState {
    xtra: any
    items: IItem[]
    roles: IRole[]
}

interface IItem {
    groupID: number
    groupe: string
    item: IItem2[]
}

interface IItem2 {
    description: string
    permID: number
    perm: IPerm[]
}

interface IPerm {
    permValue: number
}

interface IRole {
    stnKind: string
    ro: IRo[]
}

interface IRo {
    role2: string
    role_bit: number
}

let key: IKey;
let state = <IState>{};
let fetchedState = <IState>{};
let isNew = false;
let isDirty = false;


const thKindTemplate = (item: IRole) => {
    return `
<th colspan="${item.ro.length}">${item.stnKind}</th>
`
}

const thRoleTemplate = (item: IRo) => {
    return `
<th>${item.role2}</th>
`
}

const trTemplate = (item: IItem, item2: IItem2, index: number, masks: number[], titles: string[]) => {

    let permID = item2.permID;
    let permValue = item2.perm[0].permValue;
    let tdCells = masks.reduce((html, mask, index) => {
        let title = titles[index];
        let checked = (mask & permValue) > 0;
        return html + `<td data-mask="${mask}" data-checked="${checked}" title="${title}" class="js-cell">${checked ? `<i class="far fa-check"></i>` : ""}</td>`
    }, "");

    return `
<tr onclick="${NS}.rowClick(${permID})">
    ${index == 0 ? `<td rowspan="${item.item.length}" data-group="1" style="text-align: left;">${item.groupe}</td>` : ``}
    <td style="text-align: left;">${item2.description}</td>
    <td>${permID}</td>
    ${tdCells}
</tr>
`
}

const tableTemplate = (thead1: string, thead2: string, tbody: string) => {
    return `
<div class="container">
<table class="table is-hoverable is-fullwidth is-bordered is-narrow">
    <thead>
        <tr>
            <th class="js-empty"></th>
            <th class="js-empty"></th>
            <th class="js-empty"></th>
            ${thead1}
        </tr>
        <tr>
            <th class="js-empty"></th>
            <th class="js-empty"></th>
            <th class="js-empty"></th>
            ${thead2}
        </tr>
    </thead>
    <tbody>
        ${tbody}
    </tbody>
</table>
</div>
`;
};

const pageTemplate = (item: IState, table: string, tab: string, warning: string, dirty: string) => {
    let canUpdate = Perm.isSupport();
    let readonly = !canUpdate;

    let buttons: string[] = [];

    return `
<style>
    .table thead th.js-empty { border: none; }
    .table thead th:not(.js-empty) { vertical-align: bottom; line-height: 2rem; text-align: center; background-color: rgba(245, 245, 245, 0.75); }
    .table thead th { color: #aaa }
    .table td, .table th { text-align: center; }
    .table .js-cell[data-checked='true'] { background-color: #228b2229; }
    .table .js-cell[data-checked] { cursor: pointer; }
    .js-uc-details.js-readonly td { pointer-events: none; }
</style>

<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${icon}"></i> <span>${Misc.toInputText(item.xtra && item.xtra.title)}</span></div>
            <div class="subtitle">Editing Network Security</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", Theme.renderActionButtons2(NS, isNew, null, buttons, false, false))}
            ${Theme.renderBlame(item, isNew)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-details", table)}
</div>
</div>

</form>
`;
};

const dirtyTemplate = () => {
    return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
}

const clearState = () => {
    state = <IState>{};
};

export const fetchState = (cie: number) => {
    isDirty = false;
    Router.registerDirtyExit(dirtyExit);
    clearState();
    let url = `/security/${cie}`;
    return App.GET(url)
        .then(payload => {
            state = payload;
            fetchedState = Misc.clone(state) as IState;
            key = <IKey>{ cie };

            isNew = (state.items[0].item[0].perm[0].permValue == undefined);
        })
};

export const fetch = (params: string[]) => {
    let cie = Perm.getCie(params);
    App.prepareRender(NS, i18n("Security"));
    fetchState(cie)
        .then(App.render)
        .catch(App.render);
};

export const render = () => {
    if (!inContext()) return "";
    if (App.fatalError()) return App.fatalErrorTemplate();
    if (state == undefined) return (App.serverError() ? pageTemplate(null, "", "", App.warningTemplate(), "") : "");

    const thead1 = state.roles
        .reduce((html, item) => html + thKindTemplate(item), "");

    const thead2 = state.roles
        .reduce((html, item) => html + item.ro.reduce((html2, item2) => html2 + thRoleTemplate(item2), ""), "");

    const masks = state.roles
        .map(item => item.ro.map(item2 => item2.role_bit))
        .reduce((acc, item) => acc.concat(item), []);

    const titles = state.roles
        .map(item => item.ro.map(item2 => `${item.stnKind} [${item2.role2}]`))
        .reduce((acc, item) => acc.concat(item), []);

    const tbody = state.items
        .reduce((html, item) => html + item.item.reduce((html2, item2, index) => html2 + trTemplate(item, item2, index, masks, titles), ""), "");

    const table = tableTemplate(thead1, thead2, tbody);

    const tab = tabTemplate(key.cie, null, isNew);
    const dirty = dirtyTemplate();
    const warning = App.warningTemplate();
    return pageTemplate(state, table, tab, warning, dirty);
};

export const postRender = () => {
    if (!inContext()) return;
};

export const inContext = () => {
    return App.inContext(NS);
};

const getFormState = () => {
    let clone = Misc.clone(state) as IState;
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

export const rowClick = (permID: number) => {
    event.stopPropagation();
    let target = (<HTMLElement>event.target).closest("td");
    if (target.dataset.mask == undefined)
        return;

    let mask = +target.dataset.mask;
    state.items.forEach(group =>
        group.item.forEach(item => {
            if (item.permID == permID) {
                let permValue = item.perm[0].permValue;
                permValue = ((permValue & mask) == 0 ? permValue | mask : permValue & ~mask);
                item.perm[0].permValue = permValue;
            }
        })
    );
    App.render();
}

export const cancel = () => {
    Router.goBackOrResume(isDirty);
}

export const create = () => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();

    App.prepareRender();
    App.POST(`/security/${key.cie}`, {})
        .then(_ => {
            Misc.toastSuccessSave();
            Router.goto(`#/support/security/${key.cie}`, 10);
        })
        .catch(App.render);
}

export const save = () => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();

    let uto = formState.items
        .map(itm => itm.item.map(item => { return { id: item.permID, value: item.perm[0].permValue } }))
        .reduce((acc, item) => acc.concat(item), []);

    App.prepareRender();
    App.PUT(`/security/${key.cie}`, uto)
        .then(_ => {
            Misc.toastSuccessSave();
            Router.goto(`#/support/security/${key.cie}`, 10);
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
