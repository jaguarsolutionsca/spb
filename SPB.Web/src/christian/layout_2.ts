"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Perm from "../permission"
import { setOpenedMenu } from "../layout"

declare const i18n: any;


export interface ISummary {
    title: string
    filecount: number
    equipmentcount: number
}

export let icon = "far fa-user";

export const prepareMenu = () => {
    setOpenedMenu("Application-Support");
}

export const tabTemplate = (id: number, xtra: ISummary, isNew: boolean = false) => {
    let isstaffs = App.inContext("App_staffs_2");
    let isstaff = App.inContext("App_staff_2");
    let isequipments = App.inContext("App_equipments");
    let isequipment = App.inContext("App_equipment");
    let isFiles = window.location.hash.startsWith("#/files/staff");
    let isFile = window.location.hash.startsWith("#/file/staff");

    let showstaff = !isstaffs;
    let showequipment = !isstaffs && !(isstaff && isNew);
    let showFiles = !isstaffs && !(isstaff && isNew);

    return `
<div class="tabs is-boxed">
    <ul>
        <li ${isstaffs ? "class='is-active'" : ""}>
            <a href="#/staffs_2">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("List")}</span>
            </a>
        </li>

${showstaff ? `
        <li ${isstaff ? "class='is-active'" : ""}>
            <a href="#/staff_2/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("staff Details")}</span>
            </a>
        </li>
` : ``}

${showequipment ? `
        <li ${isequipments ? "class='is-active'" : ""}>
            <a href="#/equipments/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>equipment (${xtra?.equipmentcount ?? -1})</span>
            </a>
        </li>
${isequipment ? `
        <li class="is-active">
            <a>
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>equipment</span>
            </a>
        </li>
` : ``}
` : ``}

${showFiles ? `
        <li ${isFiles ? "class='is-active'" : ""}>
            <a href="#/files/staff/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("Files")} (${xtra?.filecount ?? -1})</span>
            </a>
        </li>
${isFile ? `
        <li ${isFile ? "class='is-active'" : ""}>
            <a>
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("File Details")}</span>
            </a>
        </li>
` : ``}
` : ``}

    </ul>
</div>
`;
};

export const buildTitle = (xtra: ISummary, defaultText: string) => {
    return xtra?.title ?? defaultText;
}

export const buildSubtitle = (xtra: any, defaultText: string) => {
    return xtra?.subtitle ?? defaultText;
}
