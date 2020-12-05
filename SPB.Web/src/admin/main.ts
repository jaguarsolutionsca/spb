"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
//
import * as Perm from "../permission"
import * as accounts from "./accounts"
//import * as account from "./account"
//import * as profile from "./profile"
//import * as DataFiles from "./datafiles"
//import * as DataFile from "./datafile"
//import * as Lookups from "./lookups"
//import * as Lookup from "./lookup"


//
// Global references to application objects
// These must match the "NS" values defined in modules
// Mainly used for event handlers
//
(<any>window).App_accounts = accounts;
//(<any>window).App_account = account;
//(<any>window).App_profile = profile;
//(<any>window).App_DataFiles = DataFiles;
//(<any>window).App_DataFile = DataFile;
//(<any>window).App_Lookups = Lookups;
//(<any>window).App_Lookup = Lookup;


export const startup = () => {
    Router.addRoute("^#/admin/accounts/?(.*)?$", accounts.fetch);
//    Router.addRoute("^#/admin/account/(.*)$", account.fetch);
    //Router.addRoute("^#/files/(.*)$", DataFiles.fetch);
    //Router.addRoute("^#/file/(.*)$", DataFile.fetch);
    //Router.addRoute("^#/admin/lookups/?(.*)$", Lookups.fetch);
    //Router.addRoute("^#/admin/lookup/(.*)$", Lookup.fetch);
    //Router.addRoute("^#/admin/audittrails/?(.*)$", AuditTrails.fetch);
}

export const render = () => {
    return `
    ${accounts.render()}
`;
    //${account.render()}
    //${DataFiles.render()}
    //${DataFile.render()}
    //${Lookups.render()}
    //${Lookup.render()}
}

export const postRender = () => {
    accounts.postRender();
    //account.postRender();
    //DataFiles.postRender();
    //DataFile.postRender();
    //Lookups.postRender();
    //Lookup.postRender();
}
