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
    setOpenedMenu("Fournisseur-Propriétaires");
}

export const tabTemplate = (id: string, xtra: ISummary, isNew: boolean = false) => {
    let isProprietaires = App.inContext("App_proprietaires");
    let isProprietaire = App.inContext("App_proprietaire");
    let isFiles = window.location.hash.startsWith("#/files/proprietaire");
    let isFile = window.location.hash.startsWith("#/file/proprietaire");

    let showDetail = !isProprietaires;
    let showFiles = showDetail && xtra;
    let showFile = isFile;

    return `
<div class="tabs is-boxed">
    <ul>
        <li ${isProprietaires ? "class='is-active'" : ""}>
            <a href="#/proprietaires">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("List")}</span>
            </a>
        </li>
${showDetail ? `
        <li ${isProprietaire ? "class='is-active'" : ""}>
            <a href="#/proprietaire/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("Proprietaire Details")}</span>
            </a>
        </li>
` : ``}
${showFiles ? `
        <li ${isFiles ? "class='is-active'" : ""}>
            <a href="#/files/proprietaire/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("Files")} (${xtra.filecount})</span>
            </a>
        </li>
` : ``}
${showFile ? `
        <li ${isFile ? "class='is-active'" : ""}>
            <a href="#/file/proprietaire/${id}">
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
