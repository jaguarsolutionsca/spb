"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
//
import * as Perm from "../permission"
import * as accounts from "./accounts"
import * as account from "./account"
//import * as profile from "./profile"
import * as companys from "./companys"
import * as company from "./company"
import * as lookups from "./lookups"
import * as lookup from "./lookup"
//import * as DataFiles from "./datafiles"
//import * as DataFile from "./datafile"


//
// Global references to application objects
// These must match the "NS" values defined in modules
// Mainly used for event handlers
//
(<any>window).App_accounts = accounts;
(<any>window).App_account = account;
//(<any>window).App_profile = profile;
(<any>window).App_companys = companys;
(<any>window).App_company = company;
(<any>window).App_lookups = lookups;
(<any>window).App_lookup = lookup;
//(<any>window).App_DataFiles = DataFiles;
//(<any>window).App_DataFile = DataFile;


export const startup = () => {
    Router.addRoute("^#/admin/accounts/?(.*)?$", accounts.fetch);
    Router.addRoute("^#/admin/account/(.*)$", account.fetch);
    Router.addRoute("^#/admin/companys/?(.*)?$", companys.fetch);
    Router.addRoute("^#/admin/company/(.*)$", company.fetch);
    Router.addRoute("^#/admin/lookups/?(.*)$", lookups.fetch);
    Router.addRoute("^#/admin/lookup/(.*)$", lookup.fetch);
    //Router.addRoute("^#/files/(.*)$", DataFiles.fetch);
    //Router.addRoute("^#/file/(.*)$", DataFile.fetch);
    //Router.addRoute("^#/admin/audittrails/?(.*)$", AuditTrails.fetch);
}

export const render = () => {
    return `
    ${accounts.render()}
    ${account.render()}
    ${companys.render()}
    ${company.render()}
    ${lookups.render()}
    ${lookup.render()}
`;
    //${DataFiles.render()}
    //${DataFile.render()}
}

export const postRender = () => {
    accounts.postRender();
    account.postRender();
    companys.postRender();
    company.postRender();
    lookups.postRender();
    lookup.postRender();
    //DataFiles.postRender();
    //DataFile.postRender();
}
