"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Perm from "../permission"
import { setOpenedMenu } from "../layout"

declare const i18n: any;


interface ISummary {
    title: string
    fileCount: number
}

export let icon = "far fa-user";

export const prepareMenu = () => {
    setOpenedMenu("Administration-Management");
}

export const tabTemplate = (id: number, xtra: ISummary, isNew: boolean = false) => {
    let isAccounts = App.inContext("App_accounts");
    let isAccount = App.inContext("App_account");
    let isFiles = window.location.hash.startsWith("#/files/account");
    let isFile = window.location.hash.startsWith("#/file/account");

    let showDetail = !isAccounts;
    let showFiles = showDetail && xtra;
    let showFile = isFile;

    return `
<div class="tabs is-boxed">
    <ul>
        <li ${isAccounts ? "class='is-active'" : ""}>
            <a href="#/admin/accounts">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("List")}</span>
            </a>
        </li>
${showDetail ? `
        <li ${isAccount ? "class='is-active'" : ""}>
            <a href="#/admin/account/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("Account Details")}</span>
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
        <li ${isFile ? "class='is-active'" : ""}>
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
