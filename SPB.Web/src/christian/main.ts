"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
//
import * as Perm from "../permission"
import * as offices from "./offices"
import * as office from "./office"


//
// Global references to application objects
// These must match the "NS" values defined in modules
// Mainly used for event handlers
//
window[offices.NS] = offices;
window[office.NS] = office;


export const startup = () => {
    Router.addRoute("^#/offices/?(.*)?$", offices.fetch);
    Router.addRoute("^#/office/?(.*)?$", office.fetch);
}

export const render = () => {
    return `
<div>
    ${offices.render()}
    ${office.render()}
</div>
`;
}

export const postRender = () => {
    offices.postRender();
    office.postRender();
}
