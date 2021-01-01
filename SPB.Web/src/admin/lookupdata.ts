"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Lookup from "../../_BaseApp/src/admin/lookupdata"


export { LookupData, fetch_authrole, authrole } from "../../_BaseApp/src/admin/lookupdata"


const yearFilter = (one: Lookup.LookupData, year: number) => year >= one.started && (one.ended == undefined || year <= one.ended);
const dateFilter = (one: Lookup.LookupData, date: Date) => date >= one.started && (one.ended == undefined || date <= one.ended);


let sortOrderKeys: Lookup.LookupData[];
export const fetch_sortOrderKeys = () => {
    return function (data: any) {
        const fill = (id: number, description: string) => {
            return <Lookup.LookupData>{
                id: id,
                description: description
            }
        }
        sortOrderKeys = [
            fill(1, "Nom fournisseur"),
            fill(2, "No chèque/paiement, Type de facture, Nom fournisseur"),
            fill(3, "No fournisseur"),
            fill(4, "No facture")
        ]
    }
}
export const get_sortOrderKeys = (year: number) => sortOrderKeys;

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

let compte: Lookup.LookupData[];
export const fetch_compte = () => {
    return function (data: any) {
        if (compte != undefined && compte.length > 0)
            return;
        return App.GET(`/lookup/by/compte`).then(json => { compte = json; });
    }
}
export const get_compte = (year: number) => compte;

let autreFournisseur: Lookup.LookupData[];
export const fetch_autreFournisseur = () => {
    return function (data: any) {
        if (autreFournisseur != undefined && autreFournisseur.length > 0)
            return;
        return App.GET(`/lookup/by/autreFournisseur`).then(json => { autreFournisseur = json; });
    }
}
export const get_autreFournisseur = (year: number) => autreFournisseur;
