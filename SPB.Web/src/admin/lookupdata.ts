"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Lookup from "../../_BaseApp/src/admin/lookupdata"


export { LookupData, Role, fetch_authrole, authrole, fetch_lutGroup, lutGroup } from "../../_BaseApp/src/admin/lookupdata"


const yearFilter = (one: Lookup.LookupData, year: number) => year >= one.started && (one.ended == undefined || year <= one.ended);
const dateFilter = (one: Lookup.LookupData, date: Date) => date >= one.started && (one.ended == undefined || date <= one.ended);


let district: Lookup.LookupData[];
export const fetch_district = () => {
    return function (data: any) {
        if (district != undefined && district.length > 0)
            return;
        return App.GET(`/lookup/district`).then(json => { district = json; });
    }
}
export const get_district_plus_hq = (year: number) => district.filter(one => yearFilter(one, year));
export const get_district = (year: number) => district.filter(one => yearFilter(one, year) && one.value1 != "HQ");
export const get_district_plus_hq_inRegion = (regionLUID: number, year: number) => {
    return district
        .filter(one => yearFilter(one, year))
        .filter(one => +one.value2 == regionLUID)
        .map(one => <Lookup.LookupData>{
            id: one.id,
            code: one.code,
            description: one.description,
            disabled: false
        });
}
export const get_district_inRegion = (regionLUID: number, year: number) => {
    return district
        .filter(one => yearFilter(one, year))
        .filter(one => +one.value2 == regionLUID)
        .filter(one => one.value1 != "HQ")
        .map(one => <Lookup.LookupData>{
            id: one.id,
            code: one.code,
            description: one.description,
            disabled: false
        });
}

let region: Lookup.LookupData[];
export const fetch_region = () => {
    return function(data: any) {
        if (region != undefined && region.length > 0)
            return;
        return App.GET(`/lookup/region`).then(json => { region = json; });
    }
}
export const get_region_plus_hq = (year: number) => region.filter(one => yearFilter(one, year));
export const get_region = (year: number) => region.filter(one => yearFilter(one, year) && one.code != "HQ");

let fcause: Lookup.LookupData[];
export const fetch_fcause = () => {
    return function (data: any) {
        if (fcause != undefined && fcause.length > 0)
            return;
        return App.GET(`/lookup/cause`).then(json => { fcause = json; });
    }
}
export const get_fcause = (year: number) => fcause.filter(one => yearFilter(one, year));

let tools: Lookup.LookupData[];
export const fetch_tools = () => {
    return function (data: any) {
        if (tools != undefined && tools.length > 0)
            return;
        return App.GET(`/lookup/by/tools`).then(json => { tools = json; });
    }
}
export const get_tools = (year: number) => tools;
