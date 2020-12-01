"use strict"

import { IOpt } from "./theme";
import * as Lookup from "../admin/lookupdata"



export interface IOptDropdown extends IOpt {
    hoverable: boolean
}


export const renderDropdownField = (ns: string, propName: string, options: string, label: string, required: boolean = false, size: string = "js-width-50", help?: string, disabled = false) => {
    return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            <div class="field">
                <div class="select ${size}">
                    ${renderDropdownNaked(ns, propName, options, required, disabled)}
                </div>
                ${help != undefined ? `<p class="help">${help}</p>` : ``}
            </div>
        </div>
    </div>`;
}

export const renderDropdownInline = (ns: string, propName: string, options: string, required = false, disabled = false) => {
    return `
    <div class="field">
        <div class="select">
            <select id="${ns}_${propName}" 
onchange="${ns}.onchange(this)" 
${required ? "required='required'" : ""}
${disabled ? "disabled tabindex='-1'" : ""}>
                ${options}
            </select>
        </div>
    </div>
`;
}

export const renderDropdownExInline = (ns: string, propName: string, text: string, items: string, option: IOptDropdown) => {
    return `
    <div class="field">
<div class="dropdown ${option.hoverable ? "is-hoverable" : ""}" ${!option.hoverable ? `onclick="this.classList.toggle('is-active')"` : ""}>
    <div class="dropdown-trigger">
        <div aria-controls="dropdown-menu-${propName}">
            <span>${text}</span>
            <span class="icon is-small">
                <i class="fas fa-angle-down" aria-hidden="true"></i>
            </span>
        </div>
    </div>
    <div class="dropdown-menu" id="dropdown-menu-${propName}" role="menu">
        <div class="dropdown-content">
            ${items}
        </div>
    </div>
</div>
    </div>
`;
}

export const renderDropdownNaked = (ns: string, propName: string, options: string, required = false, disabled = false) => {
    return `
    <select id="${ns}_${propName}" onchange="${ns}.onchange(this)" ${required ? "required='required'" : ""} ${disabled ? "disabled tabindex='-1'" : ""}>
        ${options}
    </select>`;
}

export const renderDropdownFilter = (ns: string, propName: string, options: string, label: string, required: boolean = false, size: string = "", help?: string) => {
    return `
    <div class="field">
        <label class="label ${required ? "js-required" : ""}">${label}</label>
        <div class="control">
            <div class="select">
                <select onchange="${ns}.filter_${propName}(this)" ${required ? "required='required'" : ""}>
                    ${options}
                </select>
            </div>
        </div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
}




export const renderOptions = (list: Lookup.LookupData[], selectedId: number | string, hasEmptyOption: boolean, emptyText = "") => {
    return renderOptionsFun(list, selectedId, hasEmptyOption, emptyText, (item) => item.description);
}

export const renderOptionsShowCode = (list: Lookup.LookupData[], selectedId: number | string, hasEmptyOption: boolean, emptyText = "") => {
    return renderOptionsFun(list, selectedId, hasEmptyOption, emptyText, (item) => item.code);
}

export const renderOptionsShowBoth = (list: Lookup.LookupData[], selectedId: number | string, hasEmptyOption: boolean, emptyText = "") => {
    return renderOptionsFun(list, selectedId, hasEmptyOption, emptyText, (item) => `${item.code}     ${item.description}`);
}

export const renderOptionsFun = (list: Lookup.LookupData[], selectedId: number | string, hasEmptyOption: boolean, emptyText = "", fun: (item: Lookup.LookupData) => string) => {
    if (hasEmptyOption) {
        let emptySelected = (selectedId == undefined) || (list.findIndex(one => one.id == selectedId) == -1);
        return list.reduce((html, entry) => {
            let selected = (selectedId != undefined && selectedId == entry.id);
            return html + `<option value="${entry.id}" ${selected ? "selected" : ""}>${fun(entry)}</option>`;
        }, `<option value="" ${emptySelected ? "selected" : ""}>${emptyText}</option>`);
    }
    else
        return list.reduce((html, entry, index) => {
            let selected = (selectedId != undefined && selectedId == entry.id);
            selected = selected || (selectedId == undefined && index == 0);
            return html + `<option value="${entry.id}" ${selected ? "selected" : ""}>${fun(entry)}</option>`;
        }, "");
}

export const renderItems = (list: Lookup.LookupData[], selectedId: number | string, hasEmptyOption: boolean, emptyText = "") => {
    if (hasEmptyOption) {
        let emptySelected = (selectedId == undefined) || (list.findIndex(one => one.id == selectedId) == -1);
        return list.reduce((html, entry) => {
            let selected = (selectedId != undefined && selectedId == entry.id);
            return html + `<div data-value="${entry.id}" class="dropdown-item ${selected ? "is-active" : ""}">${entry.description}</div>`;
        }, `<div data-value="" class="dropdown-item ${emptySelected ? "is-active" : ""}">${emptyText}</div>`);
    }
    else
        return list.reduce((html, entry, index) => {
            let selected = (selectedId != undefined && selectedId == entry.id);
            selected = selected || (selectedId == undefined && index == 0);
            return html + `<div data-value="${entry.id}" class="dropdown-item ${selected ? "is-active" : ""}">${entry.description}</div>`;
        }, "");
}

export const renderNullableBooleanOptions = (value: boolean, description: string[]) => {
    return `
    <option value="" ${value == undefined ? "selected" : ""}>${description[0]}</option>
    <option value="true" ${value != undefined && value ? "selected" : ""}>${description[1]}</option>
    <option value="false" ${value != undefined && !value ? "selected" : ""}>${description[2]}</option>
    `;
}

export const renderNullableBooleanOptionsReverse = (value: boolean, description: string[]) => {
    return `
    <option value="false" ${value != undefined && !value ? "selected" : ""}>${description[2]}</option>
    <option value="true" ${value != undefined && value ? "selected" : ""}>${description[1]}</option>
    <option value="" ${value == undefined ? "selected" : ""}>${description[0]}</option>
    `;
}




export const renderDatalistOptions = (list: Lookup.LookupData[]) => {
    return list.reduce((html, entry) => {
        return html + `<option value="${entry.description}">`;
    }, "");

}
