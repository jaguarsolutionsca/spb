// File: lookup.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Perm from "../permission"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import * as Pager from "../../_BaseApp/src/theme/pager"
import { Calendar, eventMan } from "../../_BaseApp/src/theme/calendar"
import * as Lookup from "../admin/lookupdata"
import { tabTemplate, icon, prepareMenu, buildTitle, buildSubtitle } from "./layout"

declare const i18n: any;

export const NS = "App_lookups";
const table_id = "lookups_table";

interface IState {
    _editing: boolean
    _deleting: boolean
    _isNew: boolean
    totalcount: number
    id: number
    cie: number
    cie_text: string
    groupe: string
    groupe_text: string
    parentgroupe: string
    parentgroupe_text: string
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

interface IKey {
    cie: number
    id: number
}

interface IFilter {
    cie: number
    groupe: string
    parentgroupe: string
    plus: string
}

interface IPagedState extends Pager.IPagedList<IState, IFilter> { }

const blackList = ["_editing", "_deleting", "_isNew", "totalcount", "cie_text", "groupe_text", "parentgroupe_text", "created", "by"];

let key: IKey;
let state = <IPagedState>{
    list: [],
    pager: { pageNo: 1, pageSize: App.getPageState(NS, "pageSize", 20), sortColumn: "ID", sortDirection: "ASC", filter: {} }
};
let fetchedState = <IPagedState>{};
let xtra: any;
let isNew = false;
let isDirty = false;



const filterTemplate = (groupe: string, parentgroupe: string) => {
    let filters: string[] = [];
    filters.push(Theme.renderDropdownFilter(NS, "groupe", groupe, i18n("GROUPE")));
    filters.push(Theme.renderDropdownFilter(NS, "parentgroupe", parentgroupe, i18n("PARENTGROUPE")));
    return filters.join("");
}

const trTemplateLeft = (item: IState, editId: number, deleteId: number, rowNumber: number) => {
    let id = item.id;

    let tdConfirm = `<td class="js-td-33">&nbsp;</td>`;
    if (item._editing) tdConfirm = `<td onclick="${NS}.save()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
    if (item._deleting) tdConfirm = `<td onclick="${NS}.drop()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
    if (item._isNew) tdConfirm = `<td onclick="${NS}.create()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;

    let clickUndo = item._editing || item._deleting || item._isNew;
    let markDeletion = !clickUndo;

    let canEdit = true; //perm && perm.canEdit;
    let readonly = (deleteId != undefined) || (editId != undefined && id != editId) || (isNew && !item._isNew) || (!canEdit);

    let classList: string[] = [];
    if (item._editing || item._isNew) classList.push("js-not-same");
    if (item._deleting) classList.push("js-strikeout");
    if (item._isNew) classList.push("js-new");
    if (readonly) classList.push("js-readonly");
    if (!canEdit) classList.push("js-noclick");

    return `
<tr data-id="${id}" class="${classList.join(" ")}" style="cursor: pointer;">
    <td class="js-index">${rowNumber}</td>

${markDeletion ? `<td onclick="${NS}.selectfordrop(${id})" class="has-text-danger js-td-33 js-drop" title="Click to mark for deletion"><i class='fas fa-times'></i></td>` : ``}
${clickUndo ? `<td onclick="${NS}.undo()" class="has-text-primary js-td-33" title="Click to undo"><i class='fa fa-undo'></i></td>` : ``}
${tdConfirm}

</tr>`;
};

const trTemplateRight = (item: IState, editId: number, deleteId: number, groupe: string, parentgroupe: string) => {
    let id = item.id;

    let canEdit = true; //perm && perm.canEdit;
    let readonly = (deleteId != undefined) || (editId != undefined && id != editId) || (isNew && !item._isNew) || (!canEdit);

    let classList: string[] = [];
    if (item._editing || item._isNew) classList.push("js-not-same");
    if (item._deleting) classList.push("js-strikeout");
    if (item._isNew) classList.push("js-new");
    if (readonly) classList.push("js-readonly");

    return `
<tr data-id="${id}" class="${classList.join(" ")}" style="cursor: pointer;">
${!readonly ? `
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `groupe_${id}`, groupe, true)}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `parentgroupe_${id}`, parentgroupe)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `code_${id}`, item.code, 12)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `description_${id}`, item.description, 50, true)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `value1_${id}`, item.value1, 50)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `value2_${id}`, item.value2, 50)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `value3_${id}`, item.value3, 1024)}</td>
    <td class="js-inline-input">${Theme.renderNumberInline(NS, `started_${id}`, item.started, true)}</td>
    <td class="js-inline-input">${Theme.renderNumberInline(NS, `ended_${id}`, item.ended)}</td>
    <td class="js-inline-input">${Theme.renderNumberInline(NS, `sortorder_${id}`, item.sortorder)}</td>
` : `
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.groupe_text)}</div></td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.parentgroupe_text)}</div></td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.code)}</div></td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.description)}</div></td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.value1)}</div></td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.value2)}</div></td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.value3)}</div></td>
    <td><div class="js-number">${Misc.toStaticNumber(item.started)}</div></td>
    <td><div class="js-number">${Misc.toStaticNumber(item.ended)}</div></td>
    <td><div class="js-number">${Misc.toStaticNumber(item.sortorder)}</div></td>
`}
</tr>`;
};

const tableTemplateLeft = (tbody: string, editId: number, deleteId: number) => {
    let disableAddNew = (deleteId != undefined || editId != undefined || isNew);
    let canEdit = true; //perm && perm.canEdit;
    disableAddNew = disableAddNew || !canEdit;

    return `
<style>.js-td-33 { width: 33px; }</style>
<div>
<table class="table is-hoverable js-inline" style="width: 10px; table-layout: fixed;">
    <thead>
        <tr>
            <th style="width:99px" colspan="3">&nbsp;</th>
        </tr>
    </thead>
    <tbody>
        ${tbody}
        <tr class="js-insert-row ${disableAddNew ? "js-noclick" : ""}">
            <td class="js-index js-td-33">*</td>
            <td class="has-text-primary js-td-33 js-add" onclick="${NS}.addNew()" title="Click to add a new row"><i class="fas fa-plus"></i></td>
            <td></td>
        </tr>
    </tbody>
</table>
</div>
`;
};

const tableTemplateRight = (tbody: string, pager: Pager.IPager<IFilter>) => {
    return `
<div id="${table_id}" class="table-container">
<table class="table is-hoverable js-inline" style="width: 100px; table-layout: fixed;">
    <thead>
        <tr>
            ${Pager.sortableHeaderLink(pager, NS, i18n("GROUPE"), "groupe_text", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PARENTGROUPE"), "parentgroupe_text", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CODE"), "code", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DESCRIPTION"), "description", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE1"), "value1", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE2"), "value2", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE3"), "value3", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("STARTED"), "started", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ENDED"), "ended", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SORTORDER"), "sortorder", "ASC", "width:100px")}
        </tr>
    </thead>
    <tbody>
        ${tbody}
        <tr class="js-insert-row">
            <td colspan="${10 + 4}">&nbsp;</td>
        </tr>
    </tbody>
</table>
</div>
`;
};

const pageTemplate = (xtra, pager: string, tableLeft: string, tableRight: string, tab: string, warning: string, dirty: string) => {
    let readonly = false;

    let buttons: string[] = [];
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, i18n("AAA: AAA"));
    let subtitle = buildSubtitle(xtra, i18n("List of Lookups"));

    let table = `<div style="display: flex;">
    <div>${tableLeft}</div>
    <div style="width:calc(100% - 99px)">${tableRight}</div>
</div>`;

    return `
<form onsubmit="return false;">
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
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-pager", pager)}
    ${Theme.wrapContent("js-uc-list", table)}
</div>
</div>

</form>
`;
};

const dirtyTemplate = () => {
    return (isDirty ? App.dirtyTemplate(NS, null) : "");
}



export const fetchState = (cie: number) => {
    isNew = false;
    isDirty = false;
    Router.registerDirtyExit(dirtyExit);
    state.pager.filter.cie = cie;
    return App.POST(`/lookup/search/${cie}/company`, state.pager)
        .then(payload => {
            state = payload;
            fetchedState = Misc.clone(state) as IPagedState;
            key = { cie, id: undefined };
            xtra = payload.xtra;
        })
        .then(Lookup.fetch_editLut())
};

export const fetch = (params: string[]) => {
    let cie = Perm.getCie(params);
    App.prepareRender(NS, i18n("lookup"));
    prepareMenu();
    fetchState(cie)
        .then(App.render)
        .catch(App.render);
};

const refresh = () => {
    App.prepareRender(NS, i18n("lookup"));
    clearFilterPlus();
    App.POST(`/lookup/search/${key.cie}/company`, state.pager)
        .then(payload => {
            state = payload;
            fetchedState = Misc.clone(state) as IPagedState;
        })
        .then(App.render)
        .catch(App.render);
};

export const render = () => {
    if (!inContext()) return "";
    if (App.fatalError()) return App.fatalErrorTemplate();
    if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
        return App.warningTemplate() || App.unexpectedTemplate();

    let editId: number;
    let deleteId: number;
    state.list.forEach((item, index) => {
        let prevItem = fetchedState.list[index];
        item._editing = !Misc.same(item, prevItem);
        if (item._editing) editId = item.id;
        if (item._deleting) deleteId = item.id;
    });

    let year = Perm.getCurrentYear(); //or something better
    let lookup_groupe = Lookup.get_editLut(year);
    let lookup_parentGroupe = Lookup.get_editLut(year);

    const tbodyLeft = state.list.reduce((html, item, index) => {
        let rowNumber = Pager.rowNumber(state.pager, index);
        return html + trTemplateLeft(item, editId, deleteId, rowNumber);
    }, "");

    const tbodyRight = state.list.reduce((html, item) => {
        let groupe = Theme.renderOptions(lookup_groupe, item.groupe, isNew);
        let parentgroupe = Theme.renderOptions(lookup_parentGroupe, item.parentgroupe, true);
        return html + trTemplateRight(item, editId, deleteId, groupe, parentgroupe);
    }, "");

    let groupe = Theme.renderOptions(lookup_groupe, state.pager.filter.groupe, true);
    let parentgroupe = Theme.renderOptions(lookup_parentGroupe, state.pager.filter.parentgroupe, true);

    const filter = filterTemplate(groupe, parentgroupe);
    const search = Pager.searchTemplate(state.pager, NS);
    const pager = Pager.render(state.pager, NS, [10, 20, 50], search, filter);

    const tableLeft = tableTemplateLeft(tbodyLeft, editId, deleteId);
    const tableRight = tableTemplateRight(tbodyRight, state.pager);

    const tab = tabTemplate(key.cie, xtra);
    const dirty = dirtyTemplate();
    let warning = App.warningTemplate();
    return pageTemplate(xtra, pager, tableLeft, tableRight, tab, dirty, warning);
};

export const postRender = () => {
    if (!inContext()) return;
};

export const inContext = () => {
    return App.inContext(NS);
};



export const goto = (pageNo: number, pageSize: number) => {
    state.pager.pageNo = pageNo;
    state.pager.pageSize = App.setPageState(NS, "pageSize", pageSize);
    refresh();
};

export const sortBy = (columnName: string, direction: string) => {
    state.pager.pageNo = 1;
    state.pager.sortColumn = columnName;
    state.pager.sortDirection = direction;
    refresh();
};

export const search = (element) => {
    state.pager.searchText = element.value;
    state.pager.pageNo = 1;
    refresh();
};

export const filter_groupe = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let groupe = (value.length > 0 ? value : undefined);
    if (groupe == state.pager.filter.groupe)
        return;
    state.pager.filter.groupe = groupe;
    state.pager.pageNo = 1;
    refresh();
};

export const filter_parentgroupe = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let parentgroupe = (value.length > 0 ? value : undefined);
    if (parentgroupe == state.pager.filter.parentgroupe)
        return;
    state.pager.filter.parentgroupe = parentgroupe;
    state.pager.pageNo = 1;
    refresh();
};



const getFormState = () => {
    let clone = Misc.clone(state) as IPagedState;
    clone.list.forEach(item => {
        let id = item.id;
        item.cie = Misc.fromSelectNumber(`${NS}_cie_${id}`, item.cie);
        item.groupe = Misc.fromSelectText(`${NS}_groupe_${id}`, item.groupe);
        item.parentgroupe = Misc.fromSelectText(`${NS}_parentgroupe_${id}`, item.parentgroupe);
        item.code = Misc.fromInputTextNullable(`${NS}_code_${id}`, item.code);
        item.description = Misc.fromInputText(`${NS}_description_${id}`, item.description);
        item.value1 = Misc.fromInputTextNullable(`${NS}_value1_${id}`, item.value1);
        item.value2 = Misc.fromInputTextNullable(`${NS}_value2_${id}`, item.value2);
        item.value3 = Misc.fromInputTextNullable(`${NS}_value3_${id}`, item.value3);
        item.started = Misc.fromInputNumber(`${NS}_started_${id}`, item.started);
        item.ended = Misc.fromInputNumberNullable(`${NS}_ended_${id}`, item.ended);
        item.sortorder = Misc.fromInputNumberNullable(`${NS}_sortorder_${id}`, item.sortorder);
    })
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

    let parts = input.id.replace(`${NS}_`, "").split("_");
    let field = parts[0];
    let id = +parts[1];
    let record = state.list.find(one => one.id == id);

    //if (field == "field_name") {
    //    record.some_field = null;
    //}

    App.render();
};

export const ondate = (input: HTMLInputElement, eventname: string) => {
    return eventMan(NS, input, eventname);
}

export const undo = () => {
    if (isNew) {
        isNew = false;
        fetchedState.list.pop();
    }
    state = Misc.clone(fetchedState) as IPagedState;
    isDirty = false;
    App.render()
}

export const addNew = () => {
    let url = `/lookup/new/${key.cie}/company`;
    return App.GET(url)
        .then((payload) => {
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
    if (!valid(item)) return App.render();
    App.prepareRender();
    App.POST("/lookup", Misc.createBlack(item, blackList))
        .then((key: IKey) => {
            addFilterPlus(key.id);
            fetchedState = Misc.clone(state) as IPagedState;
            Router.gotoCurrent(1);
        })
        .catch(App.render);
}

export const save = () => {
    let formState = getFormState();
    let item = formState.list.find(one => one._editing);
    if (!html5Valid()) return;
    if (!valid(item)) return App.render();
    App.prepareRender();
    App.PUT("/lookup", Misc.createBlack(item, blackList))
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
    App.DELETE("/lookup", { id: item.id, updated: item.updated })
        .then(() => {
            removeFilterPlus(item.id);
            fetchedState = Misc.clone(state) as IPagedState;
            Router.gotoCurrent(1);
        })
        .catch(App.render);
}

export const hasChanges = () => {
    return !Misc.same(fetchedState, state);
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
}



const clearFilterPlus = () => {
    state.pager.filter.plus = undefined;
    isNew = false;
}

const addFilterPlus = (id: number) => {
    if (state.pager.filter.plus)
        state.pager.filter.plus += `,${id}`;
    else
        state.pager.filter.plus = id.toString();
}

const removeFilterPlus = (id: number) => {
}
