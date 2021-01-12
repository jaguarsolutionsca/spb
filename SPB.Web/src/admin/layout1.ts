"use strict"

import * as App from "../../_BaseApp/src/core/app"
import { setOpenedMenu } from "../layout"

declare const i18n: any;


export interface ISummary {
    title: string
    fileCount: number
}

export let icon = "far fa-tasks";

export const prepareMenu = () => {
    setOpenedMenu("Administration-Configuration");
}

export const tabTemplate = (id: number, groupe: string) => {
    let isLookups = App.inContext(["App_lookups"]);
    let isLookup = App.inContext(["App_lookup"]);
    return `
<div class="tabs is-boxed">
    <ul>
        <li ${isLookups ? "class='is-active'" : ""}>
            <a href="#/admin/lookups/${groupe}">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("List")}</span>
            </a>
        </li>

${!isLookups ? `
        <li ${isLookup ? "class='is-active'" : ""}>
            <a href="#/admin/lookup/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("Entry Details")}</span>
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
