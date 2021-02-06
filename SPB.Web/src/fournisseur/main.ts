"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
//
import * as Perm from "../permission"
import * as proprietaires from "./proprietaires"
import * as proprietaire from "./proprietaire"
import * as lots2 from "./lots2"


//
// Global references to application objects. Used for event handlers.
//
window[proprietaires.NS] = proprietaires;
window[proprietaire.NS] = proprietaire;
window[lots2.NS] = lots2;



//
// ***** Don't forget to update the root main.ts and add call to startup() *****
//

export const startup = () => {
    Router.addRoute("^#/proprietaires/?(.*)?$", proprietaires.fetch);
    Router.addRoute("^#/proprietaire/?(.*)?$", proprietaire.fetch);
}



//
// ***** Don't forget to update the root layout.ts and add calls to render() and postRender() *****
//

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
