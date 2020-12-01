"use strict"

import * as Misc from "../lib-ts/misc"
import { Autocomplete } from "./autocomplete"
import { IOpt } from "./theme";


export const renderAutocompleteField = (ns: string, propName: string, autocomplete: Autocomplete, label: string, option: IOpt) => {
    let input_id = `${ns}_${propName}`;
    return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${option.required ? "js-required" : ""}" for="${input_id}">${label}</label></div>
        <div class="field-body">
            ${renderAutocompleteInline(ns, propName, autocomplete, option)}
        </div>
    </div>`;
}

export const renderAutocompleteInline = (ns: string, propName: string, autocomplete: Autocomplete, option: IOpt) => {
    let hasAddonStatic = (option.addonStatic != undefined);
    let hasAddon = (option.addon != undefined);
    let hasAddonHead = (option.addonHead != undefined);
    let input_id = `${ns}_${propName}`;
    return `
    <div class="field">
    <div class="field js-autocomplete" id="${autocomplete.id}">
        <div class="dropdown ${autocomplete.isActive ? "is-active" : ""} ${option.size ? option.size : "js-width-25"}">
            <div class="control has-icons-right">
                <input type="text" class="input"
                    id="${input_id}" 
                    data-key="${autocomplete.keyValue}"
                    value="${Misc.toStaticText(autocomplete.textValue)}" 
                    onfocus="${autocomplete.handle('onfocus')}"
                    onkeydown="${autocomplete.handle('onkeydown')}"
                    onblur="${autocomplete.handle('onblur')}"
                    ${autocomplete.required ? "required='required'" : ""}
                    ${autocomplete.disabled ? "disabled" : ""}
                    autocomplete="off">
                    
                <span class="icon is-small is-right">
                    <i class="fas fa-search"></i>
                </span>
            </div>
            ${autocomplete.render()}
        </div>
${hasAddonStatic ? `
        <div class="control" style="display:inline-block">
            <a class="button js-static" ${option.addonHref != undefined ? `href="${option.addonHref}"` : ``}>
                ${option.addonStatic}
            </a>
        </div>
` : ``}
${hasAddon ? `
        <div class="control" style="display:inline-block">
            ${option.addon}
        </div>
` : ``}
    </div>
    ${option.help != undefined ? `<p class="help">${option.help}</p>` : ``}
    </div>`;
}
