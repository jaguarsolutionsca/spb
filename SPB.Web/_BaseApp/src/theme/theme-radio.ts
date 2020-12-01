"use strict"

import * as Lookup from "../admin/lookupdata"



export const renderRadioField = (radios: string, label: string, disabled = false) => {
    return `
    <div class="field is-horizontal js-radio">
        <div class="field-label"><label class="label">${label}</label></div>
        <div class="field-body">
            <div class="control ${disabled ? "js-disabled" : ""}">
                ${radios}
            </div>
        </div>
    </div>`;
}

export const renderRadios = (ns: string, propName: string, list: Lookup.LookupData[], selectedId: number | string, hasEmptyOption: boolean, emptyText = "") => {
    if (hasEmptyOption) {
        return list.reduce((html, entry) => {
            let checked = (selectedId != undefined && selectedId == entry.id);
            let disabled = (entry.disabled != undefined && entry.disabled);
            return html + `
            <label class="radio ${disabled ? "js-disabled" : ""}">
                <input type="radio" name="${ns}_${propName}" data-value="${entry.id}" onchange="${ns}.onchange(this)" ${checked ? "checked" : ""} ${disabled ? "disabled" : ""}>
                ${entry.description}
            </label>`;
        }, `<label class="radio">
                <input type="radio" name="${ns}_${propName}" data-value="" onchange="${ns}.onchange(this)" ${selectedId == undefined ? "checked" : ""}>
                ${emptyText}
            </label>`
        );
    }
    else {
        return list.reduce((html, entry, index) => {
            let checked = (selectedId != undefined && selectedId == entry.id);
            checked = checked || (selectedId == undefined && index == 0);
            let disabled = (entry.disabled != undefined && entry.disabled);
            return html + `
            <label class="radio ${disabled ? "js-disabled" : ""}">
                <input type="radio" name="${ns}_${propName}" data-value="${entry.id}" onchange="${ns}.onchange(this)" ${checked ? "checked" : ""} ${disabled ? "disabled" : ""}>
                ${entry.description}
            </label>`;
        }, "");
    }
}
