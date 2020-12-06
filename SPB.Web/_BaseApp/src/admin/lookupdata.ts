﻿"use strict"

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
