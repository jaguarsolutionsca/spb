// File: lots2.ts

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


export const NS = "App_lots2";
const table_id = "lots2_table";

interface IState {
    _editing: boolean
    _deleting: boolean
    _isNew: boolean
    totalcount: number
    id: number
    proprietaireid: string
    proprietaireid_text: string
    datedebut: Date
    datefin: Date
    lotid: number
    lotid_text: string
}

interface IKey {
    proprietaireid: string
}

interface IFilter {

}

interface IPagedState extends Pager.IPagedList<IState, IFilter> { }

let key: IKey;
let state = <IPagedState>{
    list: [],
    pager: { pageNo: 1, pageSize: 1000, sortColumn: "ID", sortDirection: "ASC", filter: {} }
};
let fetchedState = <IPagedState>{};
let isNew = false;
let callerNS: string;
let isAddingNewParent = false;

const trTemplate = (item: IState, editId: number, deleteId: number, rowNumber: number, lotid: string) => {
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

${markDeletion ? `<td onclick="${NS}.selectfordrop(${id})" class="has-text-danger" title="Click to mark for deletion"><i class='fas fa-times'></i></td>` : ``}
${clickUndo ? `<td onclick="${NS}.undo()" class="has-text-primary" title="Click to undo"><i class='fa fa-undo'></i></td>` : ``}
${tdConfirm}

${!readonly ? `
    <td class="js-inline-input">${Theme.renderDateInline(NS, `datedebut_${id}`, item.datedebut, <Theme.IOptDate>{ required: true })}</td>
    <td class="js-inline-input">${Theme.renderDateInline(NS, `datefin_${id}`, item.datefin, <Theme.IOptDate>{ required: false })}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `lotid_${id}`, lotid, true)}</td>
` : `
    <td>${Misc.toInputDate(item.datedebut)}</td>
    <td>${Misc.toInputDate(item.datefin)}</td>
    <td>${Misc.toStaticText(item.lotid_text)}</td>
`}
</tr>`;
};

const tableTemplate = (tbody: string, editId: number, deleteId: number, perm) => {
    let disableAddNew = (deleteId != undefined || editId != undefined || isNew);
    let canEdit = perm && perm.canEdit;
    disableAddNew = disableAddNew || !canEdit;

    return `
<style>.js-td-33 { width: 33px; }</style>
<div id="${table_id}" class="table-container">
<table class="table is-hoverable js-inline" style="width: 100px; table-layout: fixed;">
    <thead>
        <tr>
            <th style="width:99px" colspan="3">
                <a class="button is-primary is-outlined is-small" ${disableAddNew ? "disabled" : `onclick="${NS}.addNew()"`}>
                    <span class="icon"><i class="fa fa-plus"></i></span><span>${i18n("Add New")}</span>
                </a>
            </th>
            <th style="width:100px">${i18n("DATEDEBUT")}</th>
            <th style="width:100px">${i18n("DATEFIN")}</th>
            <th style="width:100px">${i18n("LOT")}</th>
        </tr>
    </thead>
    <tbody>
        ${tbody}
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

export const fetchState = (proprietaireid: string, ownerNS?: string) => {
    isAddingNewParent = (proprietaireid == "new");
    callerNS = ownerNS || callerNS;
    isNew = false;
    return App.GET(`/lot_proprietaire/search/${proprietaireid}/?${Pager.asParams(state.pager)}`)
        .then(payload => {
            state = payload;
            fetchedState = Misc.clone(state) as IPagedState;
            key = { proprietaireid };
        })
        .then(Lookup.fetch_lot())
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

    let year = Perm.getCurrentYear();
    let lookup_lot = Lookup.get_lot(year);

    const tbody = state.list.reduce((html, item, index) => {
        let rowNumber = Pager.rowNumber(state.pager, index);
        let lotid = Theme.renderOptions(lookup_lot, item.lotid, isNew);
        return html + trTemplate(item, editId, deleteId, rowNumber, lotid);
    }, "");

    const table = tableTemplate(tbody, editId, deleteId, null);
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
        item.proprietaireid = Misc.fromSelectText(`${NS}_proprietaireid_${id}`, item.proprietaireid);
        item.datedebut = Misc.fromInputDate(`${NS}_datedebut_${id}`, item.datedebut);
        item.datefin = Misc.fromInputDateNullable(`${NS}_datefin_${id}`, item.datefin);
        item.lotid = Misc.fromSelectNumber(`${NS}_lotid_${id}`, item.lotid);
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
    let url = `/lot_proprietaire/new/${key.proprietaireid}`;
    return App.GET(url)
        .then((payload: IState) => {
            state.list.push(payload);
            fetchedState = Misc.clone(state) as IPagedState;
            isNew = true;
            payload._isNew = true;
        })
        .then(App.render)
        .catch(App.render);
}

export const create = () => {
    let formState = getFormState();
    let item = formState.list.find(one => one._isNew);
    if (!html5Valid()) return;
    App.prepareRender();
    App.POST("/lot_proprietaire", item)
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
    App.PUT("/lot_proprietaire", item)
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
    App.DELETE("/lot_proprietaire", { id: item.id })
        .then(() => {
            fetchedState = Misc.clone(state) as IPagedState;
            Router.gotoCurrent(1);
        })
        .catch(App.render);
}

export const hasChanges = () => {
    return !Misc.same(fetchedState, state);
}
