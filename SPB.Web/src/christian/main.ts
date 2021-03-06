﻿"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
//
import * as Perm from "../permission"
import * as offices from "./offices"
import * as office from "./office"
import * as staffs from "./staffs"
import * as staff from "./staff"
import * as staffs_2 from "./staffs_2"
import * as staff_2 from "./staff_2"
import * as staffs_3 from "./staffs_3"
import * as staffs_4 from "./staffs_4"
import * as equipments from "./equipments"
import * as equipment from "./equipment"

//
// Global references to application objects. Used for event handlers.
//
window[offices.NS] = offices;
window[office.NS] = office;
window[staffs.NS] = staffs;
window[staff.NS] = staff;
window[staffs_2.NS] = staffs_2;
window[staff_2.NS] = staff_2;
window[staffs_3.NS] = staffs_3;
window[staffs_4.NS] = staffs_4;
window[equipments.NS] = equipments;
window[equipment.NS] = equipment;


//
// ***** For a brand new main.ts, don't forget to update the root main.ts and add call to startup() *****
//

export const startup = () => {
    Router.addRoute("^#/offices/?(.*)?$", offices.fetch);
    Router.addRoute("^#/office/?(.*)?$", office.fetch);
    Router.addRoute("^#/staffs_2/?(.*)?$", staffs_2.fetch);
    Router.addRoute("^#/staff_2/?(.*)?$", staff_2.fetch);
    Router.addRoute("^#/staffs_4/?(.*)?$", staffs_4.fetch);
    Router.addRoute("^#/staffs/?(.*)?$", staffs.fetch);
    Router.addRoute("^#/staff/?(.*)?$", staff.fetch);
    Router.addRoute("^#/equipments/?(.*)?$", equipments.fetch);
    Router.addRoute("^#/equipment/?(.*)?$", equipment.fetch);}



//
// ***** For a brand new main.ts, don't forget to update the root layout.ts and add calls to render() and postRender() *****
//

export const render = () => {
    return `
<div>
    ${offices.render()}
    ${office.render()}
    ${staffs.render()}
    ${staff.render()}
    ${staffs_2.render()}
    ${staff_2.render()}
    ${staffs_4.render()}
    ${equipments.render()}
    ${equipment.render()}</div>
`;
}

export const postRender = () => {
    offices.postRender();
    office.postRender();
    staffs.postRender();
    staff.postRender();
    staffs_2.postRender();
    staff_2.postRender();
    staffs_4.postRender();
    equipments.postRender();
    equipment.postRender();}
