"use strict"

import * as domlib from "../lib-ts/domlib"
import * as Misc from "../lib-ts/misc"
import * as Lookup from "../admin/lookupdata"
import { IOpt } from "./theme";



export interface IOptDate extends IOpt {
    min: string
    max: string
}


export const renderDateInline = (ns: string, propName: string, value: Date, option: IOptDate) => {
    return `
    <div class="field">
        <div class="control">
            <input type="date" class="input"
id="${ns}_${propName}" 
value="${Misc.toInputDate(value)}" 
${option.min ? `min="${option.min}"` : ""}
${option.max ? `max="${option.max}"` : ""}
onchange="${ns}.onchange(this)" 
${option.required ? "required='required'" : ""}
${option.disabled ? "tabindex='-1' style='pointer-events:none'" : ""}>
        </div>
    </div>`;
}

const renderDateField = (ns: string, propName: string, value: Date, label: string, option: IOptDate) => {
    return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${option.required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            <div class="field">
                <!--<div class="field has-addons">-->
                <div class="field">
                    <div class="control ${option.size ? option.size : "js-width-20"}">
                        <input type="date" class="input" 
                            id="${ns}_${propName}" 
                            value="${Misc.toInputDate(value)}" 
                            onchange="${ns}.onchange(this)" 
                            ${option.required ? "required='required'" : ""}>
                    </div>
<!--
                    <div class="control">
                        <a class="button">
                            <i class="far fa-calendar-alt"></i>
                        </a>
                    </div>
-->
                </div>
                ${option.help ? `<p class="help">${option.help}</p>` : ``}
            </div>
        </div>
    </div>`;
}

const renderDateTimeField = (ns: string, propName: string, value: Date, label: string, option: IOptDate) => {
    return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${option.required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            <div class="field">
                <div class="field">
                    <div class="control" style="display: inline-block;">
                        <input type="date" class="input" 
                            id="${ns}_${propName}" 
                            value="${Misc.toInputDate(value)}" 
                            ${option.min ? `min="${option.min}"` : ""}
                            ${option.max ? `max="${option.max}"` : ""}
                            onchange="${ns}.onchange(this)" 
                            ${option.required ? "required='required'" : ""}>
                    </div>
                    <div class="control" style="display: inline-block;">
                        <input type="time" class="input"
                            id="${ns}_${propName}_time" 
                            value="${Misc.toInputTimeHHMM(value)}" 
                            onchange="${ns}.onchange(this)" 
                            ${option.required ? "required='required'" : ""}>
                    </div>
                </div>
                ${option.help ? `<p class="help">${option.help}</p>` : ``}
            </div>
        </div>
    </div>`;
}



export const renderDateExInline = (ns: string, propName: string, value: Date, option: IOptDate) => {
    return `
    <div class="field">
        <div class="control" style="width: 90px;">
            <input type="text" class="input js-no-spinner" 
id="${ns}_${propName}" 
value="${Misc.toInputDate(value)}" 
${option.min ? `min="${option.min}"` : ""}
${option.max ? `max="${option.max}"` : ""}
onfocus="${ns}.ondate(this, 'focus')" onchange="${ns}.ondate(this, 'change')" onblur="${ns}.ondate(this, 'blur')" 
autocomplete="off"
${option.required ? "required='required'" : ""}
${option.disabled ? "tabindex='-1' style='pointer-events:none'" : ""}>
        </div>
    </div>`;
}

