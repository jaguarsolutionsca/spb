"use strict"

import * as App from "../_BaseApp/src/core/app"
import * as Misc from "../_BaseApp/src/lib-ts/misc"
import * as Perm from "./permission"
import * as Main from "./main"


//
// Modules rendered
// Use these in both render() and postRender()
//
import * as Home from "./home"
import * as Admin from "./admin/main"
import * as Fournisseur from "./fournisseur/main"
import * as Territoire from "./territoire/main"


declare const i18n: any;

export const NS = "App_Layout";



export const render = () => {
    Main.saveUIState();

    // Note: Render js-uc-main content first, before renderHeader() and renderAsideMenu(), 
    // so they can potentially have an impact over there.
    let ucMain = `
${Home.render()}
${Admin.render()}
${Fournisseur.render()}
${Territoire.render()}
`;

    let menu = menuTemplate(Home.getMenuData());

    return `
<div class="js-layout ${Main.state.menuOpened ? "" : "js-close"}">
${renderHeader()}
${renderAsideMenu(menu)}
<section class="js-uc-main js-waitable">
${ucMain}
</section>
</div>
`;
}

export const postRender = () => {
    Home.postRender();
    Admin.postRender()
    Fournisseur.postRender()
    Territoire.postRender()
}

const renderHeader = () => {
    return `
<header class="js-uc-header">

    <div class="js-logo">
        <div class="js-bars">
            <button class="button is-primary" onclick="${NS}.menuClick()">
                <div class="icon"><i class="fas fa-bars"></i></div>
            </button>
        </div>
        <a href="#" onclick="${NS}.toggle('opsfms')">
            <span>Gestion/Paye</span>
        </a>
        <div style="width:20px;margin-right:1rem;">&nbsp;</div>
    </div>

    <div class="js-navbar">
        <div class="js-navbar-items">
            <div class="js-items">
                <div>
                    <span class="has-text-grey-light">Année courante:</span> <span class="has-text-white">2020</span>
                </div>
            </div>
            <div class="js-items">
                <button class="button is-primary" onclick="${NS}.help()" style="font-size:125%">
                    <span class="icon"><i class="fas fa-question-circle"></i></span>
                </button>
                <div class="navbar-item has-dropdown" onclick="${NS}.toggleProfileMenu(this)">
                    <a class="navbar-link">
                        ${Perm.getEmail()}
                    </a>
                    <div class="navbar-dropdown">
                        <div class="navbar-item">
                            <div><b>${Perm.getName()}</b></div>
                        </div>
                        <div class="navbar-item">
                            <button class="button is-fullwidth is-primary" onclick="${NS}.toggleProfileMenu();${NS}.editProfile()">
                                <i class="far fa-user"></i>&nbsp;&nbsp;Edit Profile
                            </button>
                        </div>
                        <hr class="navbar-divider">
                        <div class="navbar-item">
                            <button class="button is-fullwidth is-outlined" onclick="${NS}.toggleProfileMenu();App_Auth.signout();">
                                <span class="icon"><i class="fas fa-sign-out-alt"></i></span>&nbsp;${i18n("Sign out")}
                            </button>
                        </div>
                        <hr class="navbar-divider">
                        <a href="#" class="navbar-item">
                            <div>Terms of Service</div>
                        </a>
                    </div>
                </div>
                <button class="button is-primary" onclick="App_Auth.signout();">
                    <span class="icon"><i class="fas fa-sign-out-alt"></i></span>&nbsp;${i18n("Sign out")}
                </button>
            </div>
        </div>
    </div>

</header>`;
}

const menuTemplate = (menuItems: Home.IMenuItem[]) => {
    const linkTemplate = (link: Home.ILink) => {
        if (link.hidden || link.noSidebar)
            return "";

        let isDisabled = (link.href == undefined && link.onclick == undefined) && !link.markup;
        let href = (link.href ? link.href : "#")
        let isExternal = href.startsWith("http") || link.isExternal;

        let classes: string[] = [];
        let isActive = (link.ns && App.inContext(link.ns));
        if (isDisabled) classes.push("js-disabled")
        if (isActive) classes.push("is-active")

        let liClasses = (link.classes ? `class="${link.classes}"` : "");

        if (link.markup)
            return `<li ${liClasses}>${link.markup}</li>`;
        else
            return `<li ${liClasses}><a href="${href}" ${classes.length ? `class="${classes.join(" ")}"` : ``} ${isExternal ? `target="_new"` : ``} ${link.onclick ? `onclick="${link.onclick}"` : ""}>${link.name}</a></li>`;
    }

    const sectionTemplate = (section: Home.ISection, name: string) => {
        if (section.hidden)
            return "";

        let key = `${name}-${section.name}`;
        let opened = (Main.state.subMenu == key);
        return `
        <li>
            <a onclick="${NS}.toggle('${key}')" class="${opened ? "js-opened" : ""}">${section.name}</a>
${opened ? `
            <ul>${section.links.filter(one => one.canView == undefined || one.canView).reduce((html, item) => { return html + linkTemplate(item) }, "")}</ul>
` : ``}
        </li>
`;
    };

    const menuItemTemplate = (menuItem: Home.IMenuItem) => {
        return `
    <p class="menu-label">
        <i class="${menuItem.icon} fa-2x"></i> ${menuItem.name}
    </p>
    <ul class="menu-list">
        ${menuItem.sections.filter(one => one.canView == undefined || one.canView).reduce((html, item) => { return html + sectionTemplate(item, menuItem.name) }, "")}
    </ul>
`;
    };

    return menuItems.filter(one => one.canView).reduce((html, item) => { return html + menuItemTemplate(item) }, "");
}

const renderAsideMenu = (menu: string) => {
    return `
<aside class="menu has-background-black-ter js-uc-aside">
    <div class="js-wrapper">
        <ul class="menu-list">
            <li><a href="#" class="${isActive(Home.NS)}" onclick="${NS}.toggle('home')"><i class="far fa-home"></i> ${i18n("HOME")}</a></li>
        </ul>
        ${menu}
    </div>
</aside>
`;
}

const isActive = (ns: string | string[]) => {
    return App.inContext(ns) ? "is-active" : "";
}

export const menuClick = () => {
    Main.state.menuOpened = !Main.state.menuOpened;
    Main.saveUIState();
    App.render();
}

export const toggle = (entry: string) => {
    Main.state.subMenu = (Main.state.subMenu == entry ? "" : entry);
    App.render();
}

export const setOpenedMenu = (entry: string) => {
    Main.state.subMenu = entry;
}

export const editProfile = () => {
    //Profile.fetch([Perm.getUID().toString()]);
    return false;
}

export const toggleProfileMenu = (element: HTMLElement) => {
    if (element) element.classList.toggle("is-active");
}
