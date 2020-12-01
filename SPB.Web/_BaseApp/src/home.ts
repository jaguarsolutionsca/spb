"use strict"

import * as App from "./core/app"
import * as Router from "./core/router"
import * as Perm from "./permission"


export const NS = "App_Home";


export const fetch = () => {
    App.prepareRender(NS, "Home");
    Router.registerDirtyExit(null);
    App.render();
};

export const render = () => {
    if (!App.inContext(NS)) return "";
    return "";
}

export const postRender = () => {
}
