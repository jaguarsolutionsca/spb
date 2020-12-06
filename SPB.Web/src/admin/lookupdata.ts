"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Lookup from "../../_BaseApp/src/admin/lookupdata"


export { LookupData, Role, fetch_authrole, authrole } from "../../_BaseApp/src/admin/lookupdata"


const yearFilter = (one: Lookup.LookupData, year: number) => year >= one.started && (one.ended == undefined || year <= one.ended);
const dateFilter = (one: Lookup.LookupData, date: Date) => date >= one.started && (one.ended == undefined || date <= one.ended);

