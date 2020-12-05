"use strict"

import * as App from "../_BaseApp/src/core/app"
import * as Router from "../_BaseApp/src/core/router"
import * as Misc from "../_BaseApp/src/lib-ts/misc"
import * as Theme from "../_BaseApp/src/theme/theme"
import * as domlib from "../_BaseApp/src/lib-ts/domlib"
import * as Lookup from "./admin/lookupdata"
import * as Perm from "./permission"
import * as Layout from "./layout"

declare const i18n: any;

export const NS = "App_Home";


export interface IMenuItem {
    name: string
    icon: string
    columnClass: string
    canView: boolean
    toolButton?: string
    sections: ISection[]
}

export interface ISection {
    name: string
    icon: string
    maxrows?: number
    hidden?: boolean
    canView?: boolean
    links: ILink[]
}

export interface ILink {
    name: string
    href?: string
    hidden?: boolean
    canView?: boolean
    ns?: string[]
    isExternal?: boolean
    onclick?: string
    classes?: string
    markup?: string
    noSidebar?: boolean
}

let menuData: IMenuItem[];
let yesterday: Date;
let today: Date;
let tomorrow: Date;
let tomorrow_2: Date;
let tomorrow_3: Date;
let tomorrow_4: Date;
let region: number;


export const getMenuData = () => {
    if (menuData != undefined)
        return menuData;

    menuData = [
        {
            name: "Application",
            icon: "fad fa-cogs",
            columnClass: "is-half-tablet",
            canView: true,
            sections: [
                {
                    name: "Gestion", icon: "fas fa-lock",
                    links: [
                        { name: "Comptes", href: "#/admin/accounts", ns: ["App_accounts", "App_account"] },
                        { name: "Matrice de sécurité", href: "#/admin/apages", ns: ["App_Apages", "App_Apage"] },
                        { name: "Audit", href: "#/admin/audittrails", ns: ["App_auditTrails"] },
                    ]
                },
            ]
        },
        {
            name: "Territoires",
            icon: "fad fa-map-marker-alt",
            columnClass: "is-half-tablet is-one-third-widescreen",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Daily Fire", href: "#/firedays", ns: ["App_firedays", "App_fireday", "App_firemap"] },
                        { name: "Fire History", href: "#/fires", ns: ["App_fires", "App_fire"] },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt", canView: true,
                    links: [
                        { name: "Daily Fire", onclick: "App_rpt_bydate.fetch_dailyfire()" },
                        { name: "Fire History", onclick: "App_rpt_byfire.fetch_firehistory()" },
                    ]
                },
            ]
        },
        {
            name: "Essences",
            icon: "fad fa-trees",
            columnClass: "is-half-tablet is-one-third-widescreen",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Weather/Day", hidden: true },
                        { name: "Weather/Station", hidden: true },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Weather/Day", onclick: "App_rpt_wxbydate.fetch_wxbyday()" },
                        { name: "Weather/Station", onclick: "App_rpt_wxbystation.fetch()" },
                    ]
                },
            ]
        },
        {
            name: "Fournisseurs",
            icon: "fad fa-user-tag",
            columnClass: "is-half-tablet is-one-third-widescreen",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Weather/Day", hidden: true },
                        { name: "Weather/Station", hidden: true },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Weather/Day", onclick: "App_rpt_wxbydate.fetch_wxbyday()" },
                        { name: "Weather/Station", onclick: "App_rpt_wxbystation.fetch()" },
                    ]
                },
            ]
        },
        {
            name: "Usines",
            icon: "fad fa-industry-alt",
            columnClass: "is-half-tablet is-one-third-widescreen",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Weather/Day", hidden: true },
                        { name: "Weather/Station", hidden: true },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Weather/Day", onclick: "App_rpt_wxbydate.fetch_wxbyday()" },
                        { name: "Weather/Station", onclick: "App_rpt_wxbystation.fetch()" },
                    ]
                },
            ]
        },
        {
            name: "Contrats",
            icon: "fad fa-file-signature",
            columnClass: "is-half-tablet is-one-third-widescreen",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Weather/Day", hidden: true },
                        { name: "Weather/Station", hidden: true },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Weather/Day", onclick: "App_rpt_wxbydate.fetch_wxbyday()" },
                        { name: "Weather/Station", onclick: "App_rpt_wxbystation.fetch()" },
                    ]
                },
            ]
        },
        {
            name: "Livraisons",
            icon: "fad fa-truck-container",
            columnClass: "is-half-tablet is-one-third-widescreen",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Weather/Day", hidden: true },
                        { name: "Weather/Station", hidden: true },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Weather/Day", onclick: "App_rpt_wxbydate.fetch_wxbyday()" },
                        { name: "Weather/Station", onclick: "App_rpt_wxbystation.fetch()" },
                    ]
                },
            ]
        },
        {
            name: "Indexations",
            icon: "fad fa-book",
            columnClass: "is-half-tablet is-one-third-widescreen",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Weather/Day", hidden: true },
                        { name: "Weather/Station", hidden: true },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Weather/Day", onclick: "App_rpt_wxbydate.fetch_wxbyday()" },
                        { name: "Weather/Station", onclick: "App_rpt_wxbystation.fetch()" },
                    ]
                },
            ]
        },
        {
            name: "Rapports",
            icon: "fad fa-file-spreadsheet",
            columnClass: "is-half-tablet is-one-third-widescreen",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Weather/Day", hidden: true },
                        { name: "Weather/Station", hidden: true },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Weather/Day", onclick: "App_rpt_wxbydate.fetch_wxbyday()" },
                        { name: "Weather/Station", onclick: "App_rpt_wxbystation.fetch()" },
                    ]
                },
            ]
        },
    ];

    return menuData;
}

export const clearMenuData = () => {
    menuData = null;
}

export const renderDropdown = (propName: string, options: string) => {
    return `
    <div class="select is-small">
        <select id="${NS}_${propName}" onchange="${NS}.onchange(this)">
            ${options}
        </select>
    </div>`;
}

const menuTemplate = (menuItems: IMenuItem[]) => {
    const linkTemplate = (link: ILink) => {
        if (link.hidden)
            return "";

        const liClasses = (link.classes ? `class="${link.classes}"` : "");

        if (link.markup)
            return `<li ${liClasses}>${link.markup}</li>`;

        const isDisabled = (link.href == undefined && link.onclick == undefined)
        const href = (link.href || "#")
        const isExternal = href.startsWith("http") || link.isExternal;

        return `<li ${liClasses}><a href="${href}" ${isDisabled ? `class="js-disabled"` : ``} ${isExternal ? `target="_new"` : ``} ${link.onclick ? `onclick="${link.onclick}"` : ""}>${link.name}</a></li>`;
    }

    const sectionTemplate = (section: ISection, columnClass: string) => {
        if (section.hidden)
            return "";

        const reduceSection = () => {
            const links = section.links.filter(one => one.canView == undefined || one.canView);

            const maxrows = (section.maxrows == undefined ? 32 : section.maxrows);
            let html = "";
            for (let ix = 0; ix < links.length; ix++) {
                const ixe = ix % maxrows;
                if (ixe == 0) html += "<ul>";
                html += linkTemplate(links[ix]);
                if (ixe == (maxrows - 1) || ix == links.length - 1) html += "</ul>";
            }
            return html;
        };

        return `
        <div class="column ${section.maxrows == undefined ? columnClass : ""}">
            <h3><i class="${section.icon}"></i> ${section.name}</h3>
            <div class="js-links">${reduceSection()}</div>
        </div>
`;
    };

    const menuItemTemplate = (menuItem: IMenuItem) => {

        return `
<div class="column is-half-tablet is-one-third-fullhd">
    <div class="box">
        <div class="js-widget">
            <div class="tile">
                <i class="${menuItem.icon} fa-4x"></i>
                <div>${menuItem.name}</div>
            </div>
            <div class="columns is-mobile is-multiline">
                ${menuItem.sections.filter(one => one.canView == undefined || one.canView).reduce((html, item) => { return html + sectionTemplate(item, menuItem.columnClass) }, "")}
            </div>
        </div>
    </div>
</div>
`;
    };

    return menuItems.filter(one => one.canView).reduce((html, item) => { return html + menuItemTemplate(item) }, "");
}

const pageTemplate = (menu: string) => {
    return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">
    <div style="padding:1rem;">
        <div class="columns is-multiline">
            ${menu}
        </div>
    </div>
</form>
`;
}

const fetchState = () => {
    return Promise
        .resolve()
        //.then(Lookup.fetch_tools())
        //.then(() => { saveToolsState(Lookup.get_tools(Perm.getCurrentYear())) })
}

export const fetch = () => {
    App.setRenderDomain(Layout);
    App.prepareRender(NS, "Home");
    Router.registerDirtyExit(null);
    fetchState()
        .then(App.render)
        .catch(App.render)
};

export const render = () => {
    if (!App.inContext(NS)) return "";

    //
    // Build page
    //
    let menu = menuTemplate(getMenuData());
    return pageTemplate(menu);
}

export const postRender = () => {
    if (!App.inContext(NS)) return "";
}

const getFormState = () => {
};

export const onchange = (input: HTMLInputElement) => {
    //state = getFormState();
    App.render();
};

const gotoFire = () => {
    return `
<div class="control has-icons-right" style="width: 110px; margin: 0.5rem 0;">
    <input class="input is-primary" type="text" placeholder="Quick Fire" maxlength="5" onkeydown="if(event.keyCode==13)${NS}.ongotoFire(event.target)">
    <span class="icon is-right"><i class="far fa-link"></i></span>
</div>
`;
}

const uploadPerimeter = () => {
    return `
<a href="#/fireperimeter/new">
    <span class="icon is-small">
        <i class="far fa-cloud-upload-alt"></i>
    </span>
    <span>Upload Perimeter</span>
</a>
`;
}

const gotoTicket = () => {
    return `
<div class="control has-icons-right" style="width: 125px; margin: 0.5rem 0;">
    <input class="input is-primary js-no-spinner" type="number" placeholder="Quick Ticket" maxlength="5" onkeydown="if(event.keyCode==13)${NS}.ongotoTicket(event.target)">
    <span class="icon is-right"><i class="far fa-link"></i></span>
</div>
`;
}

export const ongotoFire = (element: HTMLInputElement) => {
    App.prepareRender();
    let fireno = element.value;
    App.GET(`/fire/exists/${fireno}`)
        .then((fireid: number) => {
            if (fireid != undefined) {
                Router.goto(`#/fire/${fireid}`, 10)
            }
            else {
                Misc.toastFailure("Invalid Fire number", 2500);
                App.render()
            }
        })
        .catch(App.render)
}

export const ongotoTicket = (element: HTMLInputElement) => {
    App.prepareRender();
    let ticketno = element.value;
    App.GET(`/ticket/exists/${ticketno}`)
        .then((ticketid: number) => {
            if (ticketid != undefined) {
                Router.goto(`#/ticket/${ticketid}`, 10)
            }
            else {
                Misc.toastFailure("Invalid Ticket number", 2500);
                App.render()
            }
        })
        .catch(App.render)
}


const loadToolsState = () => {
    return JSON.parse(localStorage.getItem("tools-state")) as Lookup.LookupData[];
}

const saveToolsState = (uiTools) => {
    localStorage.setItem("tools-state", JSON.stringify(uiTools));
}
