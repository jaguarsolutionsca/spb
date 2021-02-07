"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
//
import * as Perm from "../permission"
import * as offices from "./offices"
import * as office from "./office"
import * as staffs from "./staffs"
import * as staff from "./staff"


//
// Global references to application objects. Used for event handlers.
//
window[offices.NS] = offices;
window[office.NS] = office;
window[staffs.NS] = staffs;
window[staff.NS] = staff;



//
// ***** Don't forget to update the root main.ts and add call to startup() *****
//

export const startup = () => {
    Router.addRoute("^#/offices/?(.*)?$", offices.fetch);
    Router.addRoute("^#/office/?(.*)?$", office.fetch);
    Router.addRoute("^#/staffs/?(.*)?$", staffs.fetch);
    Router.addRoute("^#/staff/?(.*)?$", staff.fetch);
}



//
// ***** Don't forget to update the root layout.ts and add calls to render() and postRender() *****
//

export const render = () => {
    return `
<div>
    ${offices.render()}
    ${office.render()}
    ${staffs.render()}
    ${staff.render()}
</div>
`;
}

export const postRender = () => {
    offices.postRender();
    office.postRender();
    staffs.postRender();
    staff.postRender();
}
