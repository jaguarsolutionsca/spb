"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
//
import * as Perm from "../permission"
import * as proprietaires from "./proprietaires"
import * as proprietaire from "./proprietaire"


//
// Global references to application objects
// These must match the "NS" values defined in modules
// Mainly used for event handlers
//
window[proprietaires.NS] = proprietaires;
window[proprietaire.NS] = proprietaire;


export const startup = () => {
    Router.addRoute("^#/proprietaires/?(.*)?$", proprietaires.fetch);
    Router.addRoute("^#/proprietaire/?(.*)?$", proprietaire.fetch);
}

export const render = () => {
    return `
<div>
    ${proprietaires.render()}
    ${proprietaire.render()}
</div>
`;
}

export const postRender = () => {
    proprietaires.postRender();
    proprietaire.postRender();
}
