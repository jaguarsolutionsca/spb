"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Perm from "../permission"
import { setOpenedMenu } from "../layout"

declare const i18n: any;


export interface ISummary {
    title: string
    filecount: number
}

export let icon = "far fa-user";

export const prepareMenu = () => {
    setOpenedMenu("Christian");
}

export const tabTemplate = (id: number, xtra: ISummary, isNew: boolean = false) => {
    let isoffices = App.inContext("App_offices");
    let isoffice = App.inContext("App_office");
    let isFiles = window.location.hash.startsWith("#/files/office");
    let isFile = window.location.hash.startsWith("#/file/office");

    let showDetail = !isoffices;
    let showFiles = showDetail && xtra;
    let showFile = isFile;

    return `
<div class="tabs is-boxed">
    <ul>
        <li ${isoffices ? "class='is-active'" : ""}>
            <a href="#/offices">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("List")}</span>
            </a>
        </li>
${showDetail ? `
        <li ${isoffice ? "class='is-active'" : ""}>
            <a href="#/office/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("office Details")}</span>
            </a>
        </li>
` : ``}
${showFiles ? `
        <li ${isFiles ? "class='is-active'" : ""}>
            <a href="#/files/office/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("Files")} (${xtra.filecount})</span>
            </a>
        </li>
` : ``}
${showFile ? `
        <li ${isFile ? "class='is-active'" : ""}>
            <a href="#/file/office/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("File Details")}</span>
            </a>
        </li>
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
