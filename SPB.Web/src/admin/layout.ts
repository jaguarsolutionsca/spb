"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Perm from "../permission"
import { setOpenedMenu } from "../layout"

declare const i18n: any;


export interface ISummary {
    title: string
    subtitle: string
    fileCount: number
}

export let icon = "far fa-user";

export const prepareMenu = () => {
    setOpenedMenu("Administration-Management");
}

export const tabTemplate = (id: number, xtra: ISummary, isNew: boolean = false) => {
    let isCompany = App.inContext("App_company");
    let isAccounts = App.inContext("App_accounts");
    let isAccount = App.inContext("App_account");
    let isLookups = App.inContext("App_lookups");
    let isLookup = false && App.inContext("App_lookup");
    let isSecurity = App.inContext("App_security");
    let isFiles = window.location.hash.startsWith("#/files/company");
    let isFile = window.location.hash.startsWith("#/file/company");

    let showFiles = false && xtra;
    let showFile = false && xtra && isFile;
    let showSecurity = Perm.isSupport();

    return `
<div class="tabs is-boxed">
    <ul>
        <li ${isCompany ? "class='is-active'" : ""}>
            <a href="#/admin/company">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("Company Details")}</span>
            </a>
        </li>
        <li ${isAccounts ? "class='is-active'" : ""}>
            <a href="#/admin/accounts">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("Accounts")}</span>
            </a>
        </li>
${isAccount ? `
        <li class="is-active">
            <a href="#/admin/account/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("Account Details")}</span>
            </a>
        </li>
` : ``}

        <li ${isLookups ? "class='is-active'" : ""}>
            <a href="#/admin/lookups">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("Lookups")}</span>
            </a>
        </li>
${isLookup ? `
        <li class="is-active">
            <a href="#/admin/lookup/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("Entry Details")}</span>
            </a>
        </li>
` : ``}

${showSecurity ? `
        <li ${isSecurity ? "class='is-active'" : ""}>
            <a href="#/support/security">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("Security")}</span>
            </a>
        </li>
` : ``}

${showFiles ? `
        <li ${isFiles ? "class='is-active'" : ""}>
            <a href="#/files/account/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("Files")} (${xtra.fileCount})</span>
            </a>
        </li>
` : ``}
${showFile ? `
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
