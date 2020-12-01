"use strict"

import * as App from "./core/app"
import * as Perm from "./permission"
import * as Auth from "./auth"


//
// Modules rendered
// Use these in both render() and postRender()
//
import * as Home from "./home"


declare const i18n: any;


export const render = () => {
    return `
${renderHeader()}
${renderMenu()}
${Home.render()}
${renderFooter()}
`;
}

export const postRender = () => {
    Home.postRender();
}

const renderHeader = () => {
    return ``;
}

const renderMenu = () => {
    return ``;
}

const renderFooter = () => {
    return ``;
}
