"use strict"

import * as Misc from "../lib-ts/misc"
import { IOpt } from "./theme";



export interface IOptNumber extends IOpt {
    min: number
    max: number
    step: number
    places: number
    allowNegative: boolean
}


export const renderNumberField = (ns: string, propName: string, value: number, label: string, required: boolean = false, size: string = "js-width-10", help?: string) => {
    return `
<div class="field is-horizontal">
    <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
    <div class="field-body">
        <div class="field">
            <div class="control ${size}">
                <input type="number" class="input has-text-right"
                    id="${ns}_${propName}" 
                    value="${Misc.toInputNumber(value)}" 
                    onchange="${ns}.onchange(this)" 
                    ${required ? "required='required'" : ""}>
            </div>
            ${help != undefined ? `<p class="help">${help}</p>` : ``}
        </div>
    </div>
</div>`;
}

export const renderNumberInline = (ns: string, propName: string, value: number, required = false, disabled = false) => {
    return `
<div class="field">
    <div class="control">
        <input type="number" class="input has-text-right"
            id="${ns}_${propName}" 
            value="${Misc.toInputNumber(value)}" 
            onchange="${ns}.onchange(this)" 
            min="0"
            ${required ? "required='required'" : ""}
            ${disabled ? "tabindex='-1'" : ""}>
    </div>
</div>`;
}

export const renderDecimalField = (ns: string, propName: string, value: number, label: string, option: IOptNumber) => {
    return `
<div class="field is-horizontal">
    <div class="field-label"><label class="label ${option.required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
    <div class="field-body">
        ${renderDecimalInline(ns, propName, value, option)}
    </div>
</div>`;
}

export const renderDecimalInline = (ns: string, propName: string, value: number, option: IOptNumber) => {
    let hasAddonStatic = (option.addonStatic != undefined);
    let hasAddon = (option.addon != undefined);
    return `
<div class="field">
    <div class="field ${hasAddon || hasAddonStatic ? "has-addons" : ""}" style="margin-bottom:0;">
        <div class="control ${option.size ? option.size : ""}">
            <input type="text" class="input has-text-right"
                id="${ns}_${propName}" 
                value="${Misc.toStaticNumberDecimal(value, option.places, true)}" 
                onchange="${ns}.onchange(this)" 
                ${option.required ? "required='required'" : ""}
                ${option.disabled ? "disabled tabindex='-1'" : ""}
                ${option.places ? `pattern="^${option.allowNegative ? "(-)?" : ""}[0-9]+(\\.[0-9]{0,${option.places}})?$"` : ""}
                ${option.autoselect ? `onfocus="this.select()"` : ""} >
        </div>
${hasAddonStatic ? `
        <div class="control">
            <a class="button js-static">
                ${option.addonStatic}
            </a>
        </div>
` : ``}
${hasAddon ? `
        <div class="control">
            ${option.addon}
        </div>
` : ``}
    </div>
    ${option.help != undefined ? `<p class="help">${option.help}</p>` : ``}
</div>`;
}

export const renderNumberField2 = (ns: string, propName: string, value: number, label: string, option: IOptNumber) => {
    return `
<div class="field is-horizontal">
    <div class="field-label"><label class="label ${option.required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
    <div class="field-body">
        ${renderNumberInline2(ns, propName, value, option)}
    </div>
</div>`;
}

export const renderNumberInline2 = (ns: string, propName: string, value: number, option: IOptNumber) => {
    let hasAddonStatic = (option.addonStatic != undefined);
    let hasAddon = (option.addon != undefined);
    return `
<div class="field">
    <div class="field ${hasAddon || hasAddonStatic ? "has-addons" : ""}" style="margin-bottom:0;">
        <div class="control ${option.size ? option.size : ""}">
            <input type="number" class="input has-text-right"
                id="${ns}_${propName}" 
                value="${Misc.toInputNumber(value)}"
                onchange="${ns}.onchange(this)"
                ${option.required ? "required='required'" : ""}
                ${option.min != undefined ? `min=${option.min}` : ""}
                ${option.max != undefined ? `max=${option.max}` : ""}
                ${option.step ? `step=${option.step}` : ""}
                ${option.disabled ? "disabled tabindex='-1'" : ""}>
        </div>
${hasAddonStatic ? `
        <div class="control">
            <a class="button js-static">
                ${option.addonStatic}
            </a>
        </div>
` : ``}
${hasAddon ? `
        <div class="control">
            ${option.addon}
        </div>
` : ``}
    </div>
    ${option.help != undefined ? `<p class="help">${option.help}</p>` : ``}
</div>`;
}
