"use strict"

import * as Auth from "../_BaseApp/src/auth"
export { getEmail, getName, getUID, getRoles, getCurrentYear, getRegionLUID, getRegionText, getDistrictLUID, getDistrictText, refreshLoginData } from "../_BaseApp/src/auth"

export const buttonTemplate = (pageid: number) => {
    return `
<a class="button is-outlined" href="#/admin/page/${pageid}">
    <span class="icon is-small">
        <i class="fa fa-lock"></i>
    </span>
</a>`;
}


export let pageTODO = -1;
//
export let pageAccounts = 1;
export let pageAircraft = 1002;
export let pageCost = 1009;
export let pageFire = 4;
export let pageHome = 2;
export let pageWeather = 1008;


export let isAdmin: boolean;
let isAppManager: boolean;
//
export let hasAccounts_Edit: boolean;
export let hasAircraft_CanEditHired: boolean;
export let hasAircraft_CanUseDataEntry: boolean;
export let hasCost_CanUseDataEntry: boolean;
export let hasFire_CanEditDailySituation: boolean;
export let hasFire_CanManageFireUpdate: boolean;
export let hasFire_CanUseDataEntry: boolean;
export let hasHome_CanEditAllinDistrict: boolean;
export let hasHome_CanEditAllinProvince: boolean;
export let hasHome_CanEditAllinRegion: boolean;
export let hasHome_CanEditHistoricalData: boolean;
export let hasHome_CanViewAdminManagement: boolean;
export let hasHome_CanViewAdminModule: boolean;
export let hasWeather_CanUseDataEntry: boolean;
//
export let canEditSecurity: boolean;
export let canBuildSecurity: boolean;
export let canEditHomeSecurity: boolean;
export let canDebug: boolean;
export let canViewLogs: boolean;
export let canViewWebgen: boolean;
//
export let enableEmail: boolean;

//
//
//
export const evaluatePermissions = () => {
    isAdmin = Auth.hasRole(1);
    isAppManager = Auth.hasRole(4) || isAdmin;
    //
    hasAccounts_Edit = Auth.hasPerm(100);
    hasAircraft_CanEditHired = Auth.hasPerm(100201);
    hasAircraft_CanUseDataEntry = Auth.hasPerm(100200);
    hasCost_CanUseDataEntry = Auth.hasPerm(100900);
    hasFire_CanEditDailySituation = Auth.hasPerm(406);
    hasFire_CanManageFireUpdate = Auth.hasPerm(402);
    hasFire_CanUseDataEntry = Auth.hasPerm(400);
    hasHome_CanEditAllinDistrict = Auth.hasPerm(207);
    hasHome_CanEditAllinProvince = Auth.hasPerm(209);
    hasHome_CanEditAllinRegion = Auth.hasPerm(208);
    hasHome_CanEditHistoricalData = Auth.hasPerm(210);
    hasHome_CanViewAdminManagement = Auth.hasPerm(201);
    hasHome_CanViewAdminModule = Auth.hasPerm(200);
    hasWeather_CanUseDataEntry = Auth.hasPerm(100800);
    //
    canEditSecurity = isAppManager;
    canBuildSecurity = isAdmin;
    canEditHomeSecurity = isAppManager;
    canDebug = false; //isAdmin;
    canViewLogs = isAppManager;
    canViewWebgen = isAppManager;
    //
    enableEmail = (<any>window).APP.portalbag.feature.enableEmail ?? false;
}
