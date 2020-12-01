"use strict"

import * as Misc from "../lib-ts/misc"
import { Calendar } from "./calendar"
import { IOpt } from "./theme";


export interface IOptDateTime extends IOpt {
    changerCaption?: boolean
}


export const renderCalendarField = (ns: string, propName: string, calendar: Calendar, label: string, option: IOptDateTime = {}) => {
    let input_id = `${ns}_${propName}`;
    return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${calendar.required ? "js-required" : ""}" for="${input_id}">${label}</label></div>
        <div class="field-body">
            ${renderCalendarInline(ns, propName, calendar, option)}
        </div>
    </div>`;
}

export const renderCalendarFilter = (ns: string, propName: string, calendar: Calendar, label: string, option: IOptDateTime = {}) => {
    return `
    <div class="field">
        <label class="label ${option.required ? "js-required" : ""}">${label}</label>
${renderCalendarInline(ns, propName, calendar, option)}
    </div>`;
}

export const renderCalendarInline = (ns: string, propName: string, calendar: Calendar, option: IOptDateTime) => {
    let input_id = `${ns}_${propName}`;
    return `
    <div id="${input_id}_wrapper" class="field-body">
    <div class="field">
        <div class="js-calendar">
            ${calendar.render()}
        </div>
        <div class="field has-addons">
            <div class="control" style="width: 90px;">
                <input type="text" class="input js-no-spinner" 
                    id="${input_id}" 
                    value="${Misc.toInputDate(calendar.dateValue)}" 
                    ${calendar.minValue ? `data-min="${Misc.toInputDate(calendar.minValue)}"` : ""}
                    ${calendar.maxValue ? `data-max="${Misc.toInputDate(calendar.maxValue)}"` : ""}
                    autocomplete="off"
                    ${calendar.required ? `required="required"` : ""} 
                    ${calendar.disableDate ? "disabled" : ""}>
            </div>

${calendar.hasTime ? `
            <div class="control" style="width: 60px;">
                <input type="text" class="input js-no-spinner"
                    id="${input_id}_time" 
                    value="${Misc.toInputTimeHHMM(calendar.dateValue)}" 
                    autocomplete="off"
                    ${calendar.required ? "required='required'" : ""}
                    ${calendar.isNullDate ? "disabled" : ""} >
            </div>
` : ""}

${!calendar.required && !calendar.disableDate ? `
            <div class="control">
                <button id="${input_id}_clear" class="button"><i class="far fa-times"></i></button>
            </div>
` : ""}

${!calendar.disableDate ? `
            <div class="control">
                <a id="${input_id}_popup" class="button"><i class="far fa-calendar-alt"></i></a>
            </div>
` : ""}

${calendar.hasChanger ? `
            <div class="control">
                <button id="${input_id}_previous" class="button" ${calendar.isNullDate ? "disabled" : ""}>
                    <i class="fas fa-angle-left"></i>${option.changerCaption ? "&nbsp;Previous Day" : ""}
                </button>
            </div>
            <div class="control">
                <button id="${input_id}_next" class="button" ${calendar.isNullDate ? "disabled" : ""}>
                    <i class="fas fa-angle-right"></i>${option.changerCaption ? "&nbsp;Next Day" : ""}
                </button>
            </div>
` : ""}

        </div>
        ${option.help ? `<p class="help">${option.help}</p>` : ""}
    </div>
    </div>`;
}