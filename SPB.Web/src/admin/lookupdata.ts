"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Lookup from "../../_BaseApp/src/admin/lookupdata"


export { LookupData, fetch_authrole, authrole, fetch_lutGroup, get_lutGroup } from "../../_BaseApp/src/admin/lookupdata"


const yearFilter = (one: Lookup.LookupData, year: number) => year >= one.started && (one.ended == undefined || year <= one.ended);
const dateFilter = (one: Lookup.LookupData, date: Date) => date >= one.started && (one.ended == undefined || date <= one.ended);



let cIE: Lookup.LookupData[];
export const fetch_cIE = () => {
    return function (data: any) {
        if (cIE != undefined && cIE.length > 0)
            return;
        return App.GET(`/lookup/by/cie`).then(json => { cIE = json; });
    }
}
export const get_cIE = (year: number) => cIE;

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

let lot: Lookup.LookupData[];
export const fetch_lot = () => {
    return function (data: any) {
        if (lot != undefined && lot.length > 0)
            return;
        return App.GET(`/lookup/by/lot`).then(json => { lot = json; });
    }
}
export const get_lot = (year: number) => lot;

let canton: Lookup.LookupData[];
export const fetch_canton = () => {
    return function (data: any) {
        if (canton != undefined && canton.length > 0)
            return;
        return App.GET(`/lookup/by/canton`).then(json => { canton = json; });
    }
}
export const get_canton = (year: number) => canton;

let municipalite: Lookup.LookupData[];
export const fetch_municipalite = () => {
    return function (data: any) {
        if (municipalite != undefined && municipalite.length > 0)
            return;
        return App.GET(`/lookup/by/municipalite`).then(json => { municipalite = json; });
    }
}
export const get_municipalite = (year: number) => municipalite;

let proprietaire: Lookup.LookupData[];
export const fetch_proprietaire = () => {
    return function (data: any) {
        if (proprietaire != undefined && proprietaire.length > 0)
            return;
        return App.GET(`/lookup/by/proprietaire`).then(json => { proprietaire = json; });
    }
}
export const get_proprietaire = (year: number) => proprietaire;

let contingent: Lookup.LookupData[];
export const fetch_contingent = () => {
    return function (data: any) {
        if (contingent != undefined && contingent.length > 0)
            return;
        return App.GET(`/lookup/by/contingent`).then(json => { contingent = json; });
    }
}
export const get_contingent = (year: number) => contingent;

let droit_coupe: Lookup.LookupData[];
export const fetch_droit_coupe = () => {
    return function (data: any) {
        if (droit_coupe != undefined && droit_coupe.length > 0)
            return;
        return App.GET(`/lookup/by/droit_coupe`).then(json => { droit_coupe = json; });
    }
}
export const get_droit_coupe = (year: number) => droit_coupe;

let entente_paiement: Lookup.LookupData[];
export const fetch_entente_paiement = () => {
    return function (data: any) {
        if (entente_paiement != undefined && entente_paiement.length > 0)
            return;
        return App.GET(`/lookup/by/entente_paiement`).then(json => { entente_paiement = json; });
    }
}
export const get_entente_paiement = (year: number) => entente_paiement;

let zone: Lookup.LookupData[];
export const fetch_zone = () => {
    return function (data: any) {
        if (zone != undefined && zone.length > 0)
            return;
        return App.GET(`/lookup/by/zone`).then(json => { zone = json; });
    }
}
export const get_zone = (year: number) => zone;

let region: Lookup.LookupData[];
export const fetch_region = () => {
    return function (data: any) {
        if (region != undefined && region.length > 0)
            return;
        return App.GET(`/lookup/by/region`).then(json => { region = json; });
    }
}
export const get_region = (year: number) => region;






let office: Lookup.LookupData[];
export const fetch_office = () => {
    return function (data: any) {
        if (office != undefined && office.length > 0)
            return;
        return App.GET(`/office/lookup`).then(json => { office = json; });
    }
}
export const get_office = (year: number) => office;

let job: Lookup.LookupData[];
export const fetch_job = () => {
    return function (data: any) {
        if (job != undefined && job.length > 0)
            return;
        return App.GET(`/office/lookup`).then(json => { job = json; });
    }
}
export const get_job = (year: number) => job;
