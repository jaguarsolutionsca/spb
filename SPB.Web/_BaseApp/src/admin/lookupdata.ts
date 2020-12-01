"use strict"

import * as App from "../core/app"
import { IPagedList, IPager } from "../theme/pager"


export interface Role {
    id: number
    name: string
}

export interface LookupData {
    id: number | string
    code: string
    description: string
    value1: string
    value2: string
    value3: string
    started: number | Date
    ended: number | Date
    disabled: boolean
}


export let authrole: Role[];
export let lutGroup: LookupData[];


export const fetch_authrole = () => {
    return function (data: any) {
        if (authrole != undefined && authrole.length > 0)
            return;
        return App.GET(`/auth/role`).then(json => { authrole = json; });
    }
}

export const fetch_lutGroup = () => {
    return function (data: any) {
        if (lutGroup != undefined && lutGroup.length > 0)
            return;
        return App.GET(`/lookup/lutGroup`).then(json => { lutGroup = json; });
    }
}