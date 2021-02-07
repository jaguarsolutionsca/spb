"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Perm from "../permission"
import { setOpenedMenu } from "../layout"

declare const i18n: any;


export interface ISummary {
    title: string
    filecount: number
    staffcount: number
    roomcount: number
}

export let icon = "far fa-user";

export const prepareMenu = () => {
    setOpenedMenu("Christian");
}

export const tabTemplate = (id: number, xtra: ISummary, isNew: boolean = false) => {
    let isoffices = App.inContext("App_offices");
    let isoffice = App.inContext("App_office");
    let isstaffs = App.inContext("App_staffs");
    let isstaff = App.inContext("App_staff");
    let isstaffs_4 = App.inContext("App_staffs_4");
    let isrooms = App.inContext("App_rooms");
    let isroom = App.inContext("App_room");
    let isFiles = window.location.hash.startsWith("#/files/office");
    let isFile = window.location.hash.startsWith("#/file/office");

    let showOffice = !isoffices;
    let showStaff = !isoffices && !(isoffice && isNew);
    let showRoom = !isoffices && !(isoffice && isNew);
    let showFiles = !isoffices && !(isoffice && isNew);

    return `
<div class="tabs is-boxed">
    <ul>
        <li ${isoffices ? "class='is-active'" : ""}>
            <a href="#/offices">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("List")}</span>
            </a>
        </li>

${showOffice ? `
        <li ${isoffice ? "class='is-active'" : ""}>
            <a href="#/office/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("office Details")}</span>
            </a>
        </li>
` : ``}

${showStaff ? `
        <li ${isstaffs ? "class='is-active'" : ""}>
            <a href="#/staffs/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>Staff (${xtra?.staffcount ?? -1})</span>
            </a>
        </li>
${isstaff ? `
        <li class="is-active">
            <a>
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>Staff</span>
            </a>
        </li>
` : ``}
        <li ${isstaffs_4 ? "class='is-active'" : ""}>
            <a href="#/staffs_4/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>Staff/grid (${xtra?.staffcount ?? -1})</span>
            </a>
        </li>
` : ``}

${showRoom ? `
        <li ${isrooms ? "class='is-active'" : ""}>
            <a href="#/rooms/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>Rooms (${xtra?.roomcount ?? -1})</span>
            </a>
        </li>
` : ``}

${showFiles ? `
        <li ${isFiles ? "class='is-active'" : ""}>
            <a href="#/files/office/${id}">
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
