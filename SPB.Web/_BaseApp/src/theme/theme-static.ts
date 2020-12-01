"use strict"

import * as Misc from "../lib-ts/misc"
import { IOpt } from "./theme";



export const renderStaticField = (value: string, label: string, help?: string, required = false) => {
    return `
    <div class="field is-horizontal js-field-static">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}">${label}</label></div>
        <div class="field-body">
            <div style="width: 100%; height: 2.534em; padding-top: 6px;">
                ${Misc.toInputText(value)}
                ${help != undefined ? `<p class="help">${help}</p>` : ``}
            </div>
        </div>
    </div>`;
}

export const renderStaticField2 = (value: string, label: string, option: IOpt) => {
    return `
<div class="field is-horizontal js-field-static">
    <div class="field-label"><label class="label">${label}</label></div>
    <div class="field-body">
        ${renderStaticInline2(value, option)}
    </div>
</div>`;
}

export const renderStaticHtmlField = (value: string, label: string, help?: string) => {
    return `
    <div class="field is-horizontal js-field-static">
        <div class="field-label"><label class="label">${label}</label></div>
        <div class="field-body">
            <div style="width: 100%; padding-top: 6px;">
                ${value == undefined ? "" : value}
                ${help != undefined ? `<p class="help">${help}</p>` : ``}
            </div>
        </div>
    </div>`;
}

export const renderStaticField_V = (value: string, label: string, help?: string, extraStyle = "") => {
    return `
    <div class="field">
        <label class="label">${label}</label>
        <div class="control" style="${extraStyle}">${Misc.toInputText(value)}</div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
}

export const renderStaticInline = (value: string) => {
    return `
    <div class="field">
        <div class="field-body"><span>${value}</span></div>
    </div>`;
}

export const renderStaticInline2 = (value: string, option: IOpt) => {
    let hasAddonStatic = (option.addonStatic != undefined);
    let hasAddon = (option.addon != undefined);
    return `
<div class="field" ${!hasAddon && !hasAddonStatic ? `style="padding-bottom: 6px;"` : ""}>
    <div class="field ${hasAddon || hasAddonStatic ? "has-addons" : ""}">
        <div class="control">
            <div class="field-body"><span style="margin-right: 8px;">${value}</span></div>
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
