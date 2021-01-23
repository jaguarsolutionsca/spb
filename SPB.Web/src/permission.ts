"use strict"

import * as Auth from "../_BaseApp/src/auth"
export { getEmail, getName, getUID, getRoles, getCurrentYear, refreshLoginData } from "../_BaseApp/src/auth"
import { cie } from "../_BaseApp/src/core/app"


const ROLE_SUPPORT = 1;
let default_cie: number;


export const isSupport = () => { return (Auth.getRoles().indexOf(ROLE_SUPPORT) != -1); }
const hasPermission = (permid: number) => { return (Auth.getPermissions().indexOf(permid) != -1) || isSupport(); }


// Default cie
export const getCie = (params: string[]) => {
    if (isSupport() && params && params.length && params[0].startsWith("?cie="))
        default_cie = +params[0].substr(5);

    return default_cie ?? cie;
}

// Block 100
export const canDoThis = () => hasPermission(101);
export const canDoThat = () => hasPermission(102);


class Feature {
    feat: any = {};
    public assignFeature(feature: any) { this.feat = feature }
    public get private107(): string[] { return this.feat.private107 ?? []; }
    public get private208(): string[] { return this.feat.private208 ?? []; }
    public get private110(): string[] { return this.feat.private110 ?? []; }
}
const feature = new Feature();

export const assignFeature = (newFeature) => feature.assignFeature(newFeature);
