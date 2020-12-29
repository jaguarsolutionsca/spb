"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Perm from "../permission"
import { setOpenedMenu } from "../layout"

declare const i18n: any;


interface ISummary {
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
            <a href="#/fournisseur/proprietaires">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("List")}</span>
            </a>
        </li>
${showDetail ? `
        <li ${isProprietaire ? "class='is-active'" : ""}>
            <a href="#/fournisseur/proprietaire/${id}">
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

export const buildTitle = (xtra: any, defaultText: string, isNew = false, defaulTextNew: string = null) => {
    if (isNew) {
        return defaulTextNew;
    }
    let title = defaultText;
    if (xtra && xtra.title) {
        let json = JSON.parse(xtra.json);
        title = `${xtra.title}, ${json.date}, ${json.from}`;
    }
    return title;
}

export const buildSubtitle = (xtra: any, defaultText: string) => {
    let subtitle = defaultText;
    if (xtra && xtra.json) {
        let json = JSON.parse(xtra.json);
        subtitle = `Started: <b>${json.started}</b> Last Day: <b>${json.lastDay}</b> Status: <b>${json.status}</b> Hectares: <b>${json.hectares}</b> Action: <b>${json.action}</b> Zone: <b>${json.zone}</b> Total Cost: <b>${Misc.toStaticMoney(json.totalCost)}</b>`;
    }
    return subtitle;
}
