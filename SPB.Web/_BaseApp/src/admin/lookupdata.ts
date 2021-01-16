"use strict"

import * as App from "../core/app"


export interface LookupData {
    id: number | string
    cie: number
    code: string
    description: string
    value1: string
    value2: string
    value3: string
    started: number | Date
    ended: number | Date
    sortOrder: number
    disabled: boolean
}


export let authrole: LookupData[];
export const fetch_authrole = () => {
    return function (data: any) {
        if (authrole != undefined && authrole.length > 0)
            return;
        return App.GET(`/account/role`).then(json => { authrole = json; });
    }
}

let lutGroup: LookupData[];
export const fetch_lutGroup = () => {
    return function (data: any) {
        if (lutGroup != undefined && lutGroup.length > 0)
            return;
        return App.GET(`/lookup/lutGroup`).then(json => { lutGroup = json; });
    }
}
export const get_lutGroup = (year: number) => lutGroup;
