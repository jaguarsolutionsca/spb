"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Lookup from "../../_BaseApp/src/admin/lookupdata"


export { LookupData, fetch_authrole, authrole } from "../../_BaseApp/src/admin/lookupdata"


const yearFilter = (one: Lookup.LookupData, year: number) => year >= one.started && (one.ended == undefined || year <= one.ended);
const dateFilter = (one: Lookup.LookupData, date: Date) => date >= one.started && (one.ended == undefined || date <= one.ended);


let pays: Lookup.LookupData[];
export const fetch_pays = () => {
    return function (data: any) {
        if (pays != undefined && pays.length > 0)
            return;
        return App.GET(`/lookup/by/pays`).then(json => { pays = json; });
    }
}
export const get_pays = (year: number) => pays;

let institutionBanquaire: Lookup.LookupData[];
export const fetch_institutionBanquaire = () => {
    return function (data: any) {
        if (institutionBanquaire != undefined && institutionBanquaire.length > 0)
            return;
        return App.GET(`/lookup/by/institutionBanquaire`).then(json => { institutionBanquaire = json; });
    }
}
export const get_institutionBanquaire = (year: number) => institutionBanquaire;
