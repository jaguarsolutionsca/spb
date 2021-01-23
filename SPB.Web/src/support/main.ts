"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
//
import * as Perm from "../permission"
import * as companys from "./companys"
//import * as DataFiles from "./datafiles"
//import * as DataFile from "./datafile"


//
// Global references to application objects
// These must match the "NS" values defined in modules
// Mainly used for event handlers
//
(<any>window).App_companys = companys;
//(<any>window).App_DataFiles = DataFiles;
//(<any>window).App_DataFile = DataFile;


export const startup = () => {
    Router.addRoute("^#/support/companys/?(.*)?$", companys.fetch);
    //Router.addRoute("^#/files/(.*)$", DataFiles.fetch);
    //Router.addRoute("^#/file/(.*)$", DataFile.fetch);
}

export const render = () => {
    return `
    ${companys.render()}
`;
    //${DataFiles.render()}
    //${DataFile.render()}
}

export const postRender = () => {
    companys.postRender();
    //DataFiles.postRender();
    //DataFile.postRender();
}
