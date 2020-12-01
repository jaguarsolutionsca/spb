"use strict"

import * as Lookup from "../admin/lookupdata"



export const renderCheckboxField = (ns: string, propName: string, value: boolean, label: string, text?: string, help?: string, disabled = false) => {
    return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label">${label}</label></div>
        <div class="field-body">
            ${renderCheckboxInline(ns, propName, value, label, (text == undefined ? label : text), help, disabled)}
        </div>
    </div>`;
}

export const renderCheckboxInline = (ns: string, propName: string, value: boolean, label = "", text = "", help?: string, disabled = false) => {
    return `
    <div class="field">
        ${rawCheckbox(ns, propName, value, text, disabled)}
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
}

export const renderCheckboxFilter = (ns: string, propName: string, value: boolean, label = "", text: string) => {
    return `
    <div class="field">
        <label class="label">${label}</label>
        <div class="field-body">
            <label class="checkbox">
                <input type="checkbox" onchange="${ns}.filter_${propName}(this)" ${value ? "checked" : ""}> ${text}
            </label>
        </div>
    </div>`;
}

export const renderCheckboxListField = (ns: string, propName: string, maskValue: number, label: string, list: Lookup.LookupData[]) => {
    const checkboxTemplate = (entry: Lookup.LookupData) => {
        let selected = (+entry.code & maskValue) != 0;
        return `
        <div>
            <label class="checkbox">
                <input type="checkbox" ${selected ? "checked" : ""} name="${ns}_${propName}" onchange="${ns}.onchange(this)" data-mask="${entry.code}"> ${entry.description}
            </label>
        </div>`;
    };

    const checkboxes = list.reduce((html, one, index) => html + checkboxTemplate(one), "");

    return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            <div class="field js-checkbox-row">
                ${checkboxes}
            </div>
        </div>
    </div>
`;
}


export const rawCheckbox = (ns: string, propName: string, value: boolean, text: string, disabled = false) => {
    return `
    <div class="control">
        <label class="checkbox ${disabled ? "js-disabled" : ""}">
            <input type="checkbox" id="${ns}_${propName}" onchange="${ns}.onchange(this)" ${value ? "checked" : ""} ${disabled ? "disabled" : ""}> ${text}
        </label>
    </div>`;
}

export const rawToggle = (ns: string, propName: string, value: boolean, text_on: string, text_off: string) => {
    return `
<div class="js-toggle">
    <label for="${ns}_${propName}">${value ? text_on : text_off}</label>
    <input type="checkbox" id="${ns}_${propName}" onchange="${ns}.onchange(this)" ${value ? "checked" : ""}>
</div>
`;
}
