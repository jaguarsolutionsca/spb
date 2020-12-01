"use strict"

import * as Misc from "../lib-ts/misc"
import { IOpt } from "./theme";

declare const marked: any;


export interface IOptText extends IOpt {
    max: number
    listid: string
}


export const renderTextField = (ns: string, propName: string, value: string, label: string, maxlength: number, required: boolean = false, size: string = "", help?: string) => {
    return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            ${renderTextInline(ns, propName, value, maxlength, required, size, help)}
        </div>
    </div>`;
}

export const renderTextField2 = (ns: string, propName: string, value: string, label: string, maxlength: number, option: IOptText) => {
    return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${option.required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            ${renderTextInline2(ns, propName, value, maxlength, option)}
        </div>
    </div>`;
}

export const renderTextInline = (ns: string, propName: string, value: string, maxlength: number, required: boolean = false, size: string = "", help?: string, datalist?: string) => {
    return `
    <div class="field">
        <div class="control ${size}">
            <input type="text" class="input" id="${ns}_${propName}" value="${Misc.toInputText(value)}" onchange="${ns}.onchange(this)" ${maxlength != undefined ? `maxlength="${maxlength}"` : ""} ${required ? "required='required'" : ""} ${datalist ? `list="${datalist}"` : ""}>
        </div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
}

export const renderTextInline2 = (ns: string, propName: string, value: string, maxlength: number, option: IOptText) => {
    let hasAddonStatic = (option.addonStatic != undefined);
    let hasAddon = (option.addon != undefined);
    let hasAddonHead = (option.addonHead != undefined);
    return `
    <div class="field">
    <div class="field ${hasAddon || hasAddonStatic || hasAddonHead ? "has-addons" : ""}" style="margin-bottom:0;">
${hasAddonHead ? `
        <p class="control">
            ${option.addonHead}
        </p>
` : ``}
        <div class="control ${option.size != undefined ? option.size : ""}">
            <input type="text" class="input" id="${ns}_${propName}" value="${Misc.toInputText(value)}" 
                onchange="${ns}.onchange(this)"
                ${maxlength != undefined ? `maxlength="${maxlength}"` : ""}
                ${option.required ? "required='required'" : ""}
                ${option.noautocomplete ? "autocomplete='off'" : ""}
                ${option.disabled ? "disabled" : ""}
                ${option.listid ? `list="${option.listid}"` : ""}>
        </div>
${hasAddonStatic ? `
        <div class="control">
            <a class="button js-static" ${option.addonHref != undefined ? `href="${option.addonHref}"` : ``}>
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

export const renderTextareaField = (ns: string, propName: string, value: string, label: string, maxlength = 0, required = false, help?: string, rows = 2) => {
    return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            ${renderTextareaInline(ns, propName, value, maxlength, required, help, rows)}
        </div>
    </div>`;
}

export const renderTextareaField_V = (ns: string, propName: string, value: string, label: string, maxlength = 0, required = false, help?: string, rows = 2, event = "onchange") => {
    return `
    <div class="field">
        <label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label>
        <div class="control">
            <textarea class="textarea" rows="${rows}" spellcheck="false" id="${ns}_${propName}" ${event}="${ns}.${event}(this, event)" maxlength="${maxlength}" ${required ? "required='required'" : ""}>${Misc.toInputText(value)}</textarea>
        </div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
}

export const renderTextareaInline = (ns: string, propName: string, value: string, maxlength = 0, required = false, help?: string, rows = 2) => {
    return `
    <div class="field">
        <div class="control">
            <textarea class="textarea" rows="${rows}" spellcheck="false" id="${ns}_${propName}" onchange="${ns}.onchange(this)" ${maxlength > 0 ? `maxlength="${maxlength}"` : ``} ${required ? "required='required'" : ""}>${Misc.toInputText(value)}</textarea>
        </div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
}

export const renderTextareaFieldWithMarkdown = (ns: string, propName: string, value: string, label: string, maxlength = 0, required = false, help?: string, rows = 2, showHtml = false) => {
    return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            <div class="field">
                <div class="js-wrap-markdown" style="background-color: yellow; position: relative;">
                    <div class="control">
                        <textarea class="textarea" rows="${rows}" spellcheck="false" id="${ns}_${propName}" onchange="${ns}.onchange(this)" ${maxlength > 0 ? `maxlength="${maxlength}"` : ``} ${required ? "required='required'" : ""}>${Misc.toInputText(value)}</textarea>
                    </div>
                    <div style="position:absolute; top:0; left:0; width:100%; height:100%; overflow:auto; padding:0 8px; background-color:white; border: 1px solid #e7eaec; ${!showHtml ? `display:none;` : ""}">
                        ${marked(value || "")}
                    </div>
                </div>
                ${help != undefined ? `<p class="help">${help}</p>` : ``}
            </div>
        </div>
    </div>`;
}



export const rawText = (ns: string, propName: string, value: string, option: IOptText) => {
    return `
<input type="text" class="input ${option.size || ""} ${option.class || ""}" ${option.style ? `style="${option.style}"` : ""} id="${ns}_${propName}" value="${Misc.toInputText(value)}" onchange="${ns}.onchange(this)" ${option.max != undefined ? `maxlength="${option.max}"` : ""} ${option.required ? "required='required'" : ""}>
`;
}
