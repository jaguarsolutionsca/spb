// File: staff.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Perm from "../permission"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import * as Pager from "../../_BaseApp/src/theme/pager"
import * as Lookup from "../admin/lookupdata"
import * as Layout from "./layout"
import { tabTemplate, icon } from "./layout"

declare const i18n: any;


export const NS = "App_staff_3";
const table_id = "staff_3_table";

interface IState {
    _editing: boolean
    _deleting: boolean
    _isNew: boolean
    totalcount: number
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

interface IKey {
    officeid: number
}

interface IFilter {
    officeid: number
    jobid: number
}

interface IPagedState extends Pager.IPagedList<IState, IFilter> { }

const blackList = ["_editing", "_deleting", "_isNew", "totalcount", "officeid_text", "jobid_text", "created", "by"];


let key: IKey;
let state = <IPagedState>{
    list: [],
    pager: { pageNo: 1, pageSize: 1000, sortColumn: "ID", sortDirection: "ASC", filter: {} }
};
let fetchedState = <IPagedState>{};
let isNew = false;
let callerNS: string;
let isAddingNewParent = false;


const trTemplate = (item: IState, editId: number, deleteId: number, rowNumber: number, jobid: string) => {
    let id = item.id;

    let tdConfirm = `<td class="js-td-33">&nbsp;</td>`;
    if (item._editing) tdConfirm = `<td onclick="${NS}.save()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
    if (item._deleting) tdConfirm = `<td onclick="${NS}.drop()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
    if (item._isNew) tdConfirm = `<td onclick="${NS}.create()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;

    let clickUndo = item._editing || item._deleting || item._isNew;
    let markDeletion = !clickUndo;

    let readonly = (deleteId != undefined) || (editId != undefined && id != editId) || (isNew && !item._isNew);

    let classList: string[] = [];
    if (item._editing || item._isNew) classList.push("js-not-same");
    if (item._deleting) classList.push("js-strikeout");
    if (item._isNew) classList.push("js-new");
    if (readonly) classList.push("js-readonly");

    return `
<tr data-id="${id}" class="${classList.join(" ")}" style="cursor: pointer;">
    <td class="js-index">${rowNumber}</td>

${markDeletion ? `<td onclick="${NS}.selectfordrop(${id})" class="has-text-danger js-td-33 js-drop" title="Click to mark for deletion"><i class='fas fa-times'></i></td>` : ``}
${clickUndo ? `<td onclick="${NS}.undo()" class="has-text-primary js-td-33" title="Click to undo"><i class='fa fa-undo'></i></td>` : ``}
${tdConfirm}

${!readonly ? `
    <td class="js-inline-input">${Theme.renderTextInline(NS, `firstname_${id}`, item.firstname, 50, true)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `lastname_${id}`, item.lastname, 50, true)}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `jobid_${id}`, jobid)}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `archive_${id}`, item.archive)}</td>
` : `
    <td>${Misc.toStaticText(item.firstname)}</td>
    <td>${Misc.toStaticText(item.lastname)}</td>
    <td>${Misc.toStaticText(item.jobid_text)}</td>
    <td>${Misc.toStaticCheckbox(item.archive)}</td>
`}
</tr>`;
};

const tableTemplate = (tbody: string, editId: number, deleteId: number) => {
    let disableAddNew = (deleteId != undefined || editId != undefined || isNew);

    return `
<div id="${table_id}" class="table-container">
<table class="table is-hoverable js-inline" style="width: 100px; table-layout: fixed;">
    <thead>
        <tr>
            <th style="width:99px" colspan="3"></th>
            <th style="width:100px">${i18n("FIRSTNAME")}</th>
            <th style="width:100px">${i18n("LASTNAME")}</th>
            <th style="width:100px">${i18n("JOB")}</th>
            <th style="width:100px">${i18n("ARCHIVE")}</th>
        </tr>
    </thead>
    <tbody>
        ${tbody}
        <tr class="js-insert-row ${disableAddNew ? "js-disabled" : ""}">
            <td class="js-index js-td-33">*</td>
            <td class="has-text-primary js-td-33 js-add" onclick="${NS}.addNew()" title="Click to add a new row"><i class="fas fa-plus"></i></td>
            <td></td>
            <td colspan="4"></td>
        </tr>
    </tbody>
</table>
</div>
`;
};

const pageTemplate = (table: string) => {
    return `
${Theme.wrapContent("js-uc-list", table)}
`
};

export const fetchState = (officeid: number, ownerNS?: string) => {
    isAddingNewParent = isNaN(officeid);
    callerNS = ownerNS || callerNS;
    isNew = false;
    state.pager.filter.officeid = officeid;
    return App.POST(`/staff/search/${officeid}/office`, state.pager)
        .then(payload => {
            state = payload;
            fetchedState = Misc.clone(state) as IPagedState;
            key = { officeid };
        })
        .then(Lookup.fetch_job())
};

export const preRender = () => {
};

export const render = () => {
    if (isAddingNewParent) return "";

    let editId: number;
    let deleteId: number;
    state.list.forEach((item, index) => {
        let prevItem = fetchedState.list[index];
        item._editing = !Misc.same(item, prevItem);
        if (item._editing) editId = item.id;
        if (item._deleting) deleteId = item.id;
    });

    let year = Perm.getCurrentYear(); //or something better

    let lookup_job = Lookup.get_job(year);

    const tbody = state.list.reduce((html, item, index) => {
        let rowNumber = Pager.rowNumber(state.pager, index);
        let jobid = Theme.renderOptions(lookup_job, item.jobid, true);
        return html + trTemplate(item, editId, deleteId, rowNumber, jobid);
    }, "");

    const table = tableTemplate(tbody, editId, deleteId);
    return pageTemplate(table);
};

export const postRender = () => {
};

export const inContext = () => {
    return App.inContext(NS);
};

const getFormState = () => {
    let clone = Misc.clone(state) as IPagedState;
    clone.list.forEach(item => {
        let id = item.id;
        item.firstname = Misc.fromInputText(`${NS}_firstname_${id}`, item.firstname);
        item.lastname = Misc.fromInputText(`${NS}_lastname_${id}`, item.lastname);
        item.officeid = Misc.fromSelectNumber(`${NS}_officeid_${id}`, item.officeid);
        item.jobid = Misc.fromSelectNumber(`${NS}_jobid_${id}`, item.jobid);
        item.archive = Misc.fromInputCheckbox(`${NS}_archive_${id}`, item.archive);
    })
    return clone;
};

const html5Valid = (): boolean => {
    document.getElementById(`${callerNS}_dummy_submit`).click();
    let form = document.getElementsByTagName("form")[0];
    form.classList.add("js-error");
    return form.checkValidity();
};

export const onchange = (input: HTMLInputElement) => {
    state = getFormState();
    App.render();
};

export const undo = () => {
    if (isNew) {
        isNew = false;
        fetchedState.list.pop();
    }
    state = Misc.clone(fetchedState) as IPagedState;
    App.render()
}

export const addNew = () => {
    let url = `/staff/new/${key.officeid}/office`;
    return App.GET(url)
        .then(payload => {
            state.list.push(payload.item);
            fetchedState = Misc.clone(state) as IPagedState;
            isNew = true;
            payload.item._isNew = true;
        })
        .then(App.render)
        .catch(App.render);
}

export const create = () => {
    let formState = getFormState();
    let item = formState.list.find(one => one._isNew);
    if (!html5Valid()) return;
    App.prepareRender();
    App.POST("/staff", Misc.createBlack(item, blackList))
        .then(() => {
            fetchedState = Misc.clone(state) as IPagedState;
            Router.gotoCurrent(1);
        })
        .catch(App.render);
}

export const save = () => {
    let formState = getFormState();
    let item = formState.list.find(one => one._editing);
    if (!html5Valid()) return;
    App.prepareRender();
    App.PUT("/staff", Misc.createBlack(item, blackList))
        .then(() => {
            fetchedState = Misc.clone(state) as IPagedState;
            Router.gotoCurrent(1);
        })
        .catch(App.render);
}

export const selectfordrop = (id: number) => {
    state = Misc.clone(fetchedState) as IPagedState;
    state.list.find(one => one.id == id)._deleting = true;
    App.render();
}

export const drop = () => {
    App.prepareRender();
    let item = state.list.find(one => one._deleting);
    App.DELETE("/staff", { id: item.id, updated: item.updated })
        .then(() => {
            fetchedState = Misc.clone(state) as IPagedState;
            Router.gotoCurrent(1);
        })
        .catch(App.render);
}

export const hasChanges = () => {
    return !Misc.same(fetchedState, state);
}
