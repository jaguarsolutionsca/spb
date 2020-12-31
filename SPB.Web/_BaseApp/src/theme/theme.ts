"use strict"

import * as Misc from "../lib-ts/misc"
export { renderActionButtons, renderActionButtons2, renderInlineActionButtons, renderListActionButtons, renderListActionButtons2, renderListFloatingActionButtons, renderButtons, buttonCancel, buttonInsert, buttonUpload, buttonAddNew, buttonDelete, buttonUpdate, buttonUpdateNoDone, renderButtonsInline, buttonCancelInline, buttonInsertInline, buttonAddNewInline, buttonDeleteInline, buttonUpdateInline } from "./theme-action"
export { rawCheckbox, renderCheckboxField, renderCheckboxInline, renderCheckboxFilter, renderCheckboxListField, rawToggle } from "./theme-checkbox"
export { IOptDropdown, renderDropdownField, renderDropdownInline, renderDropdownExInline, renderDropdownNaked, renderDropdownFilter, renderOptions, renderItems, renderOptionsFun, renderOptionsShowBoth, renderOptionsShowCode, renderNullableBooleanOptions, renderNullableBooleanOptionsReverse, renderDatalistOptions } from "./theme-dropdown"
export { IOptSelect, rawSelect } from "./theme-select"
export { renderRadios, renderRadioField } from "./theme-radio"
export { renderNumberFilter, renderDateFilter, renderDateChanger } from "./theme-filter"
export { IOptNumber, renderNumberField, renderNumberField2, renderNumberInline, renderDecimalField, renderDecimalInline, renderNumberInline2 } from "./theme-number"
export { renderLatField, renderLongField, renderLatLongInline, renderDDMMCC } from "./theme-latlong"
export { IOptText, rawText, renderTextField, renderTextField2, renderTextInline, renderTextInline2, renderTextareaField, renderTextareaField_V, renderTextareaInline, renderTextareaFieldWithMarkdown } from "./theme-text"
export { IOptDate, renderDateInline, renderDateExInline } from "./theme-date"
export { IOptDateTime, renderCalendarField, renderCalendarInline, renderCalendarFilter } from "./theme-calendar"
export { renderStaticField, renderStaticField2, renderStaticHtmlField, renderStaticField_V, renderStaticInline } from "./theme-static"
export { renderButtonWithConfirm, renderButtonWithConfirmChoices, renderButton } from "./theme-button"
export { renderAutocompleteField, renderAutocompleteInline } from "./theme-autocomplete"
export { renderModalDelete, openModal, closeModal } from "./theme-modal"


declare const i18n: any;

export const NS = "App_Theme";


export interface IOpt {
    required?: boolean
    size?: string
    help?: string
    addonStatic?: string
    addonHref?: string
    addonHead?: string
    addon?: string
    noautocomplete?: boolean
    disabled?: boolean
    autoselect?: boolean
    class?: string
    style?: string
}



export const toggleActive = (element: Element) => {
    element.classList.toggle("is-active");
};

export const wrapContent = (contentClass: string, html: string) => {
    if (html != undefined && html.length > 0)
        return `<div class="content ${contentClass}">${html}</div>`;
    return "";
};

export const warningTemplate = (errorMessages: string[]) => {
    return errorMessages.reduce((text, error) => text +
    `<div class="notification is-danger">
        <i class="fa fa-exclamation-triangle"></i>&nbsp;${error}
    </div>`,
    "");
};

export const fatalErrorTemplate403 = () => {
    return `
    <div class="notification is-danger">
        <h3><i class="fas fa-skull-crossbones"></i>&nbsp;${i18n("Unauthorized")}</h3>
        ${i18n("You don't have the required permission for this operation")}
    </div>`;
};

export const fatalErrorTemplate404 = () => {
    return `
    <div class="notification is-danger">
        <h3><i class="fas fa-skull-crossbones"></i>&nbsp;${i18n("Failed to fetch page data")}</h3>
        ${i18n("You don't have the required permission for this operation")}
    </div>`;
};

export const dirtyTemplate = (ns: string, details: string = null) => {
    return `
    <div class="notification is-warning">
        <i class="fa fa-exclamation-triangle"></i>
        <div style="display:inline-table;">You have changes that are not saved. Click Update to save your changes or ${ns != undefined ? `<a onclick="${ns}.cancel(); return false;">continue</a> without saving` : "Cancel"}.
        ${details != undefined ? `<br>${details}` : ""}</div>
    </div>`;
};

export const unexpectedTemplate = () => {
    return `<div class="notification is-danger">
        <i class="fa fa-exclamation-triangle"></i>&nbsp;UNEXPECTED ERROR
    </div>`;
};

export const inConstruction = (text = "In Construction") => {
    return `
    <div class="notification is-size-4 has-text-centered">
        <span class="icon"><i class="fas fa-wrench"></i></span> ${text}
    </div>
    `;
};

export const onburger = (element: HTMLElement) => {
    let target = document.getElementById(element.dataset.target);
    element.classList.toggle("is-active");
    target.classList.toggle("is-active");
}

export const renderBlame = (obj: any, isNew: boolean) => {
    if (isNew || obj == undefined || obj.updated == undefined || obj.by == undefined) return "";
    return `
    <div class="has-text-right js-blame">
        <span>Last updated on ${Misc.toStaticDateTime(obj.updated)}${obj.by ? ` by ${obj.by}` : ``}</span>
    </div>
`;
}

export const renderFileUpload = (ns: string, propName: string, label: string, accept = "image/*", isBusy = false) => {
    if (!isBusy)
        return `
<div class="level-item">
    <div class="file">
        <label class="file-label">
            <input class="file-input" type="file" id="${ns}_${propName}" name="${ns}_${propName}" accept="${accept}" onchange="${ns}.fileUpload(this)">
            <span class="file-cta">
                <span class="file-icon">
                    <i class="fas fa-upload"></i>
                </span>
                <span class="file-label">
                    ${label}…
                </span>
            </span>
        </label>
    </div>
</div>
    `;

    return `
<div class="level-item">
    <a class="button is-loading">Upoading</a>
</div>
    `;
}



export const renderStyleForFixedWidthTable = (id: string, widths: number[]) => {
    let table_width = widths.reduce((sum, width) => sum + width, 0);

    let thead = widths.reduce((html, width, index) => {
        return html + `#${id} thead th:nth-child(${index + 1}) { width: ${width}px; min-width: ${width}px; }`;
    }, "");

    let tbody = widths.reduce((html, width, index) => {
        return html + `#${id} tbody td:nth-child(${index + 1}) { width: ${width}px; min-width: ${width}px; }`;
    }, "");

    return `
<style>
    #${id} table { width: ${table_width}px; }
    ${thead}
    ${tbody}
</style>
`;
}

export const renderStyleForScrollableTable = (id: string, rows: number, widths: number[]) => {
    let table_width = widths.reduce((sum, width) => sum + width, 0);
    let table_th_height = 32;
    let scrollbar_width = 16 + 4;
    let scrollbar_height = 16;
    let height = 32 * (rows + 1);

    let thead = widths.reduce((html, width, index) => {
        return html + `#${id} thead th:nth-child(${index + 1}) { min-width: ${width + (index == widths.length - 1 ? scrollbar_width : 0)}px; }`;
    }, "");

    let tbody = widths.reduce((html, width, index) => {
        return html + `#${id} tbody td:nth-child(${index + 1}) { width: ${width}px; min-width: ${width}px; }`;
    }, "");

    return `
<style>
    #${id} { overflow: hidden; }
    #${id} table thead { display: block; }
    #${id} table tbody { display: block; overflow: auto; scroll-behavior: smooth; }

    #${id} { height: ${height + scrollbar_height}px; }
    #${id} table { width: ${table_width + scrollbar_width}px; }
    #${id} tbody { height: ${height - table_th_height}px; }

    ${thead}
    ${tbody}
</style>
`;
}



export const wrapFieldset = (legend: string, content: string, actions: string = null) => {
    var id = legend.split(" ").join("");
    return `
<fieldset id="${id}">
    <legend class="js-legend"><span>${legend}</span>${actions ? `<div>${actions}</div>` : ""}</legend>
    ${content}
</fieldset>
`;
}

export const float_menu_button = (title: string, id?: string) => {
    return `<button class="button is-text" onclick="${NS}.scrollTo('${id || title}')">${title}</button>`
}

export const scrollTo = (anchor: string) => {
    var id = anchor.replace(/ /g, "");
    var fieldset = <HTMLElement>document.getElementById(id);
    //
    fieldset.scrollIntoView();
    setTimeout(function () { window.scrollBy(0, -180); }, 10);
}



export const field = (label: string, controls: string | string[], required = false, cssclass?: string) => {
    let html: string;
    if (typeof controls === "string")
        html = `<div class="field">` + controls + "</div>"
    else
        html = `<div class="field js-addons">` + (<string[]>controls).reduce((html, one) => html + one, "") + "</div>"

    return `
<div class="field is-horizontal ${cssclass || ""}">
    <div class="field-label"><label class="label ${required ? "js-required" : ""}">${label}</label></div>
    <div class="field-body">
        ${html}
    </div>
</div>`;
}
