"use strict"

import * as Misc from "../lib-ts/misc"



export const renderNumberFilter = (ns: string, propName: string, value: number, label: string = "", required: boolean = false, help?: string) => {
    return `
    <div class="field">
        <label class="label ${required ? "js-required" : ""}">${label}</label>
        <div class="control" style="width: 100px">
            <input type="number" class="input" id="${ns}_${propName}" value="${Misc.toInputNumber(value)}" onchange="${ns}.filter_${propName}(this)" ${required ? "required='required'" : ""}>
        </div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
}

export const renderDateFilter = (ns: string, propName: string, value: Date, label: string = "", required: boolean = false, help?: string, min: Date = null, max: Date = null) => {
    return `
    <div class="field">
        <label class="label ${required ? "js-required" : ""}">${label}</label>
        <div class="control">
            <input type="date" class="input"
id="${ns}_${propName}" 
value="${Misc.toInputDate(value)}" 
onchange="${ns}.filter_${propName}(this)" 
${required ? "required='required'" : ""}
${min ? `min="${Misc.toInputDate(min)}"` : ""}
${max ? `max="${Misc.toInputDate(max)}"` : ""}
${required ? "required='required'" : ""}>
        </div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
}

export const renderDateChanger = (ns: string, propName: string, disabled = false) => {
    return `
<div class="field" style="margin-left: -0.75rem;">
    <label class="label">&nbsp;</label>
    <div class="buttons has-addons">
        <button class="button" ${disabled ? "disabled" : ""} onclick="${ns}.filter_${propName}(this, 'previous')"><i class="fas fa-angle-left"></i></button>
        <button class="button" ${disabled ? "disabled" : ""} onclick="${ns}.filter_${propName}(this, 'next')"><i class="fas fa-angle-right"></i></button>
    </div>
</div>
`;
}