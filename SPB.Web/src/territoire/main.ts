"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
//
import * as Perm from "../permission"
import * as lots from "./lots"
import * as lot from "./lot"


//
// Global references to application objects
// These must match the "NS" values defined in modules
// Mainly used for event handlers
//
window[lots.NS] = lots;
window[lot.NS] = lot;


export const startup = () => {
    Router.addRoute("^#/lots/?(.*)?$", lots.fetch);
    Router.addRoute("^#/lot/?(.*)?$", lot.fetch);
}

export const render = () => {
    return `
<div>
    ${lots.render()}
    ${lot.render()}
</div>
`;
}

export const postRender = () => {
    lots.postRender();
    lot.postRender();
}
