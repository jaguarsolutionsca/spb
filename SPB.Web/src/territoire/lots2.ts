// File: commitcbacks.ts

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
import { Calendar, eventMan } from "../../_BaseApp/src/theme/calendar"

declare const i18n: any;


export const NS = "App_commitcbacks";
const table_id = "commitcbacks_table";

interface IState {
    _editing: boolean
    _deleting: boolean
    _isNew: boolean
    totalCount: number
    id: number
    year: number
    regionLUID: number
    regionLUID_Code: string
    regionLUID_Text: string
    districtLUID: number
    districtLUID_Code: string
    districtLUID_Text: string
    typeLUID: number
    typeLUID_Text: string
    reference: string
    refNumber: string
    roleLUID: number
    roleLUID_Text: string
    fireID: number
    fireID_Text: string
    otherInfo: string
    codingLUID: number
    codingLUID_Text: string
    details: string
    monthPaid: string
    paid: boolean
    amount: number
    comment: string
    archive: boolean
    createdUtc: Date
    updatedUtc: Date
    updatedBy: number
    by: string
}

interface IKey {
    id: number
}

interface IFilter {
    year: number
    regionLUID: number
    districtLUID: number
    typeLUID: number
    roleLUID: number
    codingLUID: number
    paid: boolean
    plus: string
}

interface IPagedState extends Pager.IPagedList<IState, IFilter> { }

let state = <IPagedState>{
    list: [],
    pager: { pageNo: 1, pageSize: App.getPageState(NS, "pageSize", 20), sortColumn: "YEAR", sortDirection: "ASC", filter: { year: Perm.getCurrentYear(), regionLUID: undefined, districtLUID: undefined, typeLUID: undefined, roleLUID: undefined, codingLUID: undefined, paid: undefined } }
};
let fetchedState = <IPagedState>{};
let isNew = false;
let isDirty = false;
let LUID_role_FA: number;


const filterTemplate = (year: number, regionLUID: string, districtLUID: string, typeLUID: string, roleLUID: string, codingLUID: string, paid: string) => {
    let filters: string[] = [];
    filters.push(Theme.renderNumberFilter(NS, "year", year, i18n("YEAR"), true));
    filters.push(Theme.renderDropdownFilter(NS, "regionLUID", regionLUID, i18n("REGION")));
    filters.push(Theme.renderDropdownFilter(NS, "districtLUID", districtLUID, i18n("DISTRICT")));
    filters.push(Theme.renderDropdownFilter(NS, "typeLUID", typeLUID, i18n("Type")));
    filters.push(Theme.renderDropdownFilter(NS, "roleLUID", roleLUID, i18n("ROLE")));

    filters.push(`<style>#id_coding select{max-width:98px;} #id_coding {margin-right:0.75rem;}</style>`);
    filters.push(`<div id="id_coding">${Theme.renderDropdownFilter(NS, "codingLUID", codingLUID, i18n("CODING"))}</div>`);

    filters.push(Theme.renderDropdownFilter(NS, "paid", paid, i18n("PAID")));
    return filters.join("");
}

const trTemplateLeft = (item: IState, editId: number, deleteId: number, rowNumber: number, perm) => {
    let id = item.id;

    let tdConfirm = `<td class="js-td-33">&nbsp;</td>`;
    if (item._editing) tdConfirm = `<td onclick="${NS}.save()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
    if (item._deleting) tdConfirm = `<td onclick="${NS}.drop()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
    if (item._isNew) tdConfirm = `<td onclick="${NS}.create()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;

    let clickUndo = item._editing || item._deleting || item._isNew;
    let markDeletion = !clickUndo;

    let canEdit = perm && perm.canEdit;
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

const trTemplateRight = (item: IState, editId: number, deleteId: number, perm, regionLUID: string, districtLUID: string, typeLUID: string, roleLUID: string, fireID: string, codingLUID: string, referenceListID: string) => {
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
    <td class="js-readonly js-grayout">${Misc.toStaticText(item.year)}</td>
    <td class="js-inline-select js-mono js-2">${Theme.renderDropdownInline(NS, `regionLUID_${id}`, regionLUID, true)}</td>
    <td class="js-inline-select js-mono js-3">${Theme.renderDropdownInline(NS, `districtLUID_${id}`, districtLUID)}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `typeLUID_${id}`, typeLUID, true)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `reference_${id}`, item.reference, 50)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `refNumber_${id}`, item.refNumber, 25)}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `roleLUID_${id}`, roleLUID)}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `fireID_${id}`, fireID)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `otherInfo_${id}`, item.otherInfo, 50)}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `codingLUID_${id}`, codingLUID, true)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `details_${id}`, item.details, 50)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `monthPaid_${id}`, item.monthPaid, 25)}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `paid_${id}`, item.paid)}</td>
    <td class="js-inline-input">${Theme.renderDecimalInline(NS, `amount_${id}`, item.amount, <Theme.IOptNumber>{ required: true, places: 2, min: 0 })}</td>
` : `
    <td class="js-readonly js-grayout">${Misc.toStaticText(item.year)}</td>
    <td class="js-mono"><div class="js-truncate" style="width:70px;">${Misc.toStaticText(item.regionLUID_Code)}</div></td>
    <td class="js-mono"><div class="js-truncate" style="width:75px;">${Misc.toStaticText(item.districtLUID_Code)}</div></td>
    <td><div class="js-truncate" style="width:105px;">${Misc.toStaticText(item.typeLUID_Text)}</div></td>
    <td><div class="js-truncate" style="width:180px;">${Misc.toStaticText(item.reference)}</div></td>
    <td><div class="js-truncate" style="width:75px;">${Misc.toStaticText(item.refNumber)}</div></td>
    <td>${Misc.toStaticText(item.roleLUID_Text)}</td>
    <td>${Misc.toStaticText(item.fireID_Text)}</td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.otherInfo)}</div></td>
    <td><div class="js-truncate" style="width:90px;">${Misc.toStaticText(item.codingLUID_Text)}</div></td>
    <td><div class="js-truncate" style="width:180px;">${Misc.toStaticText(item.details)}</div></td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.monthPaid)}</div></td>
    <td>${Misc.toStaticCheckbox(item.paid)}</td>
    <td><div class="js-number">${Misc.toStaticNumberDecimal(item.amount, 2, true)}</div></td>
`}
</tr>`;
};

const tableTemplateLeft = (tbody: string, editId: number, deleteId: number, perm) => {
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

const tableTemplateRight = (tbody: string, pager: Pager.IPager<IFilter>, referenceListID: string) => {
    return `
<div id="${table_id}" class="table-container">
<table class="table is-hoverable js-inline" style="width: 100px; table-layout: fixed;">
    <thead>
        <tr>
            ${Pager.sortableHeaderLink(pager, NS, i18n("YEAR"), "year", "DESC", "width:70px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REGION"), "regionLUID_Text", "ASC", "width:70px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DISTRICT"), "districtLUID_Text", "ASC", "width:75px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("Type"), "typeLUID_Text", "ASC", "width:105px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REFERENCE"), "reference", "ASC", "width:180px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("Ref#"), "refNumber", "ASC", "width:75px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ROLE"), "roleLUID_Text", "ASC", "width:115px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FIRE"), "fireID_Text", "ASC", "width:75px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("OTHERINFO"), "otherInfo", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CODING"), "codingLUID_Text", "ASC", "width:90px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("Details"), "details", "ASC", "width:180px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MONTHPAID"), "monthPaid", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PAID"), "paid", "ASC", "width:50px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AMOUNT"), "amount", "ASC", "width:80px")}
        </tr>
    </thead>
    <tbody>
        ${tbody}
        <tr class="js-insert-row">
            <td colspan="18">&nbsp;</td>
        </tr>
    </tbody>
</table>
</div>
${referenceListID}
`;
};

const pageTemplate = (xtra, pager: string, tableLeft: string, tableRight: string, tab: string, warning: string, dirty: string) => {
    let readonly = false;

    let buttons: string[] = [];
    let actions = Theme.renderButtons(buttons);

    let title = Layout.buildTitle(state.xtra, i18n("Commitment: Charge Back / EFF"));
    let subtitle = Layout.buildSubtitle(state.xtra, i18n("Fire Charge Back / EFF"));

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

const fetchState = (id: number) => {
    isNew = false;
    isDirty = false;
    Router.registerDirtyExit(dirtyExit);
    return App.GET(`/commitcbeff/search/?${Pager.asParams(state.pager)}`)
        .then(payload => {
            state = payload;
            fetchedState = Misc.clone(state) as IPagedState;
        })
        .then(Lookup.fetch_region())
        .then(Lookup.fetch_district())
        .then(Lookup.fetch_committype())
        .then(Lookup.fetch_manrole())
        .then(Lookup.fetch_codingCBEFF())
        .then(Lookup.fetch_fire())
        .then(Lookup.fetch_reference(() => state.pager.filter.year))
};

export const fetch = (params: string[]) => {
    let id = +params[0];
    App.prepareRender(NS, i18n("Commitments: Charge Back / EFF"));
    fetchState(id)
        .then(App.render)
        .catch(App.render);
};

const refresh = () => {
    App.prepareRender(NS, i18n("commitcbacks"));
    clearFilterPlus();
    App.GET(`/commitcbeff/search/?${Pager.asParams(state.pager)}`)
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

    let year = state.pager.filter.year;
    let lookup_region = Lookup.get_region(year);
    let lookup_district = Lookup.get_district(year);
    let lookup_type = Lookup.get_committype(year);
    let lookup_role = Lookup.get_manrole(year);
    let lookup_coding = Lookup.get_codingCBEFF(year);

    LUID_role_FA = +lookup_role.find(one => one.code == "FA").id

    let referenceListID = `${NS}_referenceList`;
    let lookup_reference = Lookup.get_reference();
    let referenceList = `<datalist id="${referenceListID}">${Theme.renderDatalistOptions(lookup_reference)}</datalist>`;

    const tbodyLeft = state.list.reduce((html, item, index) => {
        let rowNumber = Pager.rowNumber(state.pager, index);
        return html + trTemplateLeft(item, editId, deleteId, rowNumber, state.perm);
    }, "");

    const tbodyRight = state.list.reduce((html, item) => {
        let regionLUID = Theme.renderOptionsShowBoth(lookup_region, item.regionLUID, isNew);

        let lookup_district = Lookup.get_district_inRegion(item.regionLUID, year);
        let districtLUID = Theme.renderOptionsShowBoth(lookup_district, item.districtLUID, true);

        let typeLUID = Theme.renderOptions(lookup_type, item.typeLUID, isNew);
        let roleLUID = Theme.renderOptions(lookup_role, item.roleLUID, true);

        let lookup_fire = Lookup.get_fire_inRegion(item.regionLUID, year);
        let fireID = Theme.renderOptions(lookup_fire, item.fireID, true);

        let lookup_coding = Lookup.get_codingCBEFF_byRegion(item.regionLUID, year);
        let codingLUID = Theme.renderOptionsShowBoth(lookup_coding, item.codingLUID, isNew);

        return html + trTemplateRight(item, editId, deleteId, state.perm, regionLUID, districtLUID, typeLUID, roleLUID, fireID, codingLUID, referenceListID);
    }, "");

    let regionLUID = Theme.renderOptions(lookup_region, state.pager.filter.regionLUID, true, "All");
    let districtLUID = Theme.renderOptions(lookup_district, state.pager.filter.districtLUID, true, "All");
    let typeLUID = Theme.renderOptions(lookup_type, state.pager.filter.typeLUID, true, "All");
    let roleLUID = Theme.renderOptions(lookup_role, state.pager.filter.roleLUID, true, "All");
    let codingLUID = Theme.renderOptionsShowBoth(lookup_coding, state.pager.filter.codingLUID, true, "All");
    let paid = Theme.renderNullableBooleanOptions(state.pager.filter.paid, ["All", i18n("Paid"), i18n("Not Paid")]);

    const filter = filterTemplate(year, regionLUID, districtLUID, typeLUID, roleLUID, codingLUID, paid);
    const search = Pager.searchTemplate(state.pager, NS);
    const pager = Pager.render(state.pager, NS, [7, 20, 50], search, filter);

    const tableLeft = tableTemplateLeft(tbodyLeft, editId, deleteId, state.perm);
    const tableRight = tableTemplateRight(tbodyRight, state.pager, referenceList);

    const tab = tabTemplate(null, null);
    const dirty = dirtyTemplate();
    let warning = App.warningTemplate();
    return pageTemplate(state.xtra, pager, tableLeft, tableRight, tab, dirty, warning);
};

export const postRender = () => {
    if (!inContext()) return;
    App.setPageTitle(`Commitments: Fire OPS ${state.pager.filter.year}`)
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

export const filter_year = (element: HTMLInputElement) => {
    let value = element.value;
    let year = (value.length > 0 ? +value : Perm.getCurrentYear());
    if (year == state.pager.filter.year)
        return;

    let lookup_region = Lookup.get_region_plus_hq(year).find(one => one.id == state.pager.filter.regionLUID);
    if (lookup_region == undefined)
        state.pager.filter.regionLUID = null;

    let lookup_district = Lookup.get_district_plus_hq(year).find(one => one.id == state.pager.filter.districtLUID);
    if (lookup_district == undefined)
        state.pager.filter.districtLUID = null;

    state.pager.filter.year = year;
    state.pager.pageNo = 1;
    refresh();
};

export const filter_regionLUID = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let regionLUID = (value.length > 0 ? +value : undefined);
    if (regionLUID == state.pager.filter.regionLUID)
        return;

    if (regionLUID != undefined) state.pager.filter.districtLUID = null;
    state.pager.filter.regionLUID = regionLUID;
    state.pager.pageNo = 1;
    refresh();
};

export const filter_districtLUID = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let districtLUID = (value.length > 0 ? +value : undefined);
    if (districtLUID == state.pager.filter.districtLUID)
        return;

    if (districtLUID != undefined) state.pager.filter.regionLUID = null;
    state.pager.filter.districtLUID = districtLUID;
    state.pager.pageNo = 1;
    refresh();
};

export const filter_typeLUID = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let typeLUID = (value.length > 0 ? +value : undefined);
    if (typeLUID == state.pager.filter.typeLUID)
        return;
    state.pager.filter.typeLUID = typeLUID;
    state.pager.pageNo = 1;
    refresh();
};

export const filter_roleLUID = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let roleLUID = (value.length > 0 ? +value : undefined);
    if (roleLUID == state.pager.filter.roleLUID)
        return;
    state.pager.filter.roleLUID = roleLUID;
    state.pager.pageNo = 1;
    refresh();
};

export const filter_codingLUID = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let codingLUID = (value.length > 0 ? +value : undefined);
    if (codingLUID == state.pager.filter.codingLUID)
        return;
    state.pager.filter.codingLUID = codingLUID;
    state.pager.pageNo = 1;
    refresh();
};

export const filter_paid = (element: HTMLSelectElement) => {
    let value = element.options[element.selectedIndex].value;
    let paid = (value.length > 0 ? value == "true" : undefined);
    if (paid == state.pager.filter.paid)
        return;
    state.pager.filter.paid = paid;
    state.pager.pageNo = 1;
    refresh();
};



const getFormState = () => {
    let clone = Misc.clone(state) as IPagedState;
    clone.list.forEach(item => {
        let id = item.id;
        item.year = Misc.fromInputNumber(`${NS}_year_${id}`, item.year);
        item.regionLUID = Misc.fromSelectNumber(`${NS}_regionLUID_${id}`, item.regionLUID);
        item.districtLUID = Misc.fromSelectNumber(`${NS}_districtLUID_${id}`, item.districtLUID);
        item.typeLUID = Misc.fromSelectNumber(`${NS}_typeLUID_${id}`, item.typeLUID);
        item.reference = Misc.fromInputTextNullable(`${NS}_reference_${id}`, item.reference);
        item.refNumber = Misc.fromInputTextNullable(`${NS}_refNumber_${id}`, item.refNumber);
        item.roleLUID = Misc.fromSelectNumber(`${NS}_roleLUID_${id}`, item.roleLUID);
        item.fireID = Misc.fromSelectNumber(`${NS}_fireID_${id}`, item.fireID);
        item.otherInfo = Misc.fromInputTextNullable(`${NS}_otherInfo_${id}`, item.otherInfo);
        item.codingLUID = Misc.fromSelectNumber(`${NS}_codingLUID_${id}`, item.codingLUID);
        item.details = Misc.fromInputTextNullable(`${NS}_details_${id}`, item.details);
        item.monthPaid = Misc.fromInputTextNullable(`${NS}_monthPaid_${id}`, item.monthPaid);
        item.paid = Misc.fromInputCheckbox(`${NS}_paid_${id}`, item.paid);
        item.amount = Misc.fromInputNumber(`${NS}_amount_${id}`, item.amount);
        item.comment = Misc.fromInputTextNullable(`${NS}_comment_${id}`, item.comment);
        item.archive = Misc.fromInputCheckbox(`${NS}_archive_${id}`, item.archive);
    })
    return clone;
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

    if (field == "regionLUID") {
        record.districtLUID = null;
        record.codingLUID = null;
    }

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

export const cancel = () => {
    Router.goBackOrResume(isDirty);
}

export const addNew = () => {
    let url = `/commitcbeff/new`;
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
    App.POST("/commitcbeff", item)
        .then((key: IKey) => {
            addFilterPlus(key.id);
            fetchedState = Misc.clone(state) as IPagedState;
            Lookup.update_reference(item.reference);
            Router.gotoCurrent(1);
        })
        .catch(App.render);
}

export const save = () => {
    let formState = getFormState();
    let item = formState.list.find(one => one._editing);
    if (!html5Valid()) return;
    App.prepareRender();
    App.PUT("/commitcbeff", item)
        .then(() => {
            fetchedState = Misc.clone(state) as IPagedState;
            Lookup.update_reference(item.reference);
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
    App.DELETE("/commitcbeff", { id: item.id, updatedUtc: item.updatedUtc })
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
};



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
