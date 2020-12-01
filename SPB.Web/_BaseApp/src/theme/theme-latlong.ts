"use strict"

import * as Misc from "../lib-ts/misc"
import { NS } from "./latlong"



export const renderDDMMCC = (ns: string, isDDMMCC: boolean) => {
    return `
<div class="field is-horizontal">
    <div class="field-label">
        <label class="label">&nbsp;</label>
    </div>
    <div class="field-body">
        <div class="field">
            <div class="control">
                <label class="checkbox">
                    <input type="checkbox" onchange="${ns}.onDDMMCC(this)" ${isDDMMCC ? "checked" : ""}> Enter latitude and longitude using <b>DD MM.CC</b> instead of <b>DD MM SS</b>
                </label>
            </div>
        </div>
    </div>
</div>
`;
}

export const renderLatField = (ns: string, propName: string, value: number, label: string, required: boolean = false, size: string = "", help?: string, isDDMMCC = false) => {
    return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            ${renderLatLongInline(ns, propName, value, required, size, help, false, isDDMMCC)}
        </div>
    </div>`;
}

export const renderLongField = (ns: string, propName: string, value: number, label: string, required: boolean = false, size: string = "", help?: string, isDDMMCC = false) => {
    return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            ${renderLatLongInline(ns, propName, value, required, size, help, true, isDDMMCC)}
        </div>
    </div>`;
}

export const renderLatLongInline = (ns: string, propName: string, value: number, required: boolean = false, size: string = "", help?: string, isLongitude = false, isDDMMCC = false) => {
    return `
    <div class="field has-addons">
        <div class="control ${size}">
            <input type="text" class="input js-no-spinner"
                id="${ns}_${propName}" 
                data-islongitude="${isLongitude}"
                data-isddmmcc="${isDDMMCC ? "true" : "false"}"
                value="${isDDMMCC ? Misc.toInputLatLongDDMMCC(value) : Misc.toInputLatLong(value)}" 
                onfocus="${NS}.onfocusLatLon(this)"
                onchange="${NS}.onchangeLatLon(this); ${ns}.onchange(this);"
                onblur="${NS}.onblurLatLon(this)"
                ${required ? "required='required'" : ""}
                autocomplete="off">
        </div>
${isDDMMCC ? `
        <div class="control">
            <a class="button js-static">${Misc.toInputLatLong(value)}</a>
        </div>
` : ``}
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>
`;
}
