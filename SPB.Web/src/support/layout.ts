"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Perm from "../permission"
import { setOpenedMenu } from "../layout"

declare const i18n: any;


export interface ISummary {
    title: string
    fileCount: number
}

export let icon = "far fa-user";

export const prepareMenu = () => {
    setOpenedMenu("Administration-Management");
}

export const tabTemplate = (id: number, xtra: ISummary, isNew: boolean = false) => {
    let isCompanys = App.inContext("App_companys");
    let isAnyLookups = App.inContext("App_any_lookups");
    let isFiles = window.location.hash.startsWith("#/files/company");
    let isFile = window.location.hash.startsWith("#/file/company");

    let showFiles = false && xtra != undefined;

    return `
<div class="tabs is-boxed">
    <ul>
        <li ${isCompanys ? "class='is-active'" : ""}>
            <a href="#/support/companys">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("Company List")}</span>
            </a>
        </li>
        <li ${isAnyLookups ? "class='is-active'" : ""}>
            <a href="#/support/any-lookups">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("Lookups")}</span>
            </a>
        </li>
${showFiles ? `
        <li ${isFiles ? "class='is-active'" : ""}>
            <a href="#/files/account/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("Files")} (${xtra.fileCount})</span>
            </a>
        </li>
` : ``}
${isFile ? `
        <li class="is-active">
            <a href="#/file/account/${id}">
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
