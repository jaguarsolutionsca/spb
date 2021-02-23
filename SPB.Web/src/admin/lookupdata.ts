"use strict"

import * as App from "../../_BaseApp/src/core/app"


export interface LookupData {
    id: number | string
    cie: number
    groupe: string
    parentgroupe: string
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


const yearFilter = (one: LookupData, year: number) => year >= one.started && (one.ended == undefined || year <= one.ended);
const dateFilter = (one: LookupData, date: Date) => date >= one.started && (one.ended == undefined || date <= one.ended);


export let authrole: LookupData[];
export const fetch_authrole = () => {
    return function (data: any) {
        if (authrole != undefined && authrole.length > 0)
            return;
        return App.GET(`/account/role`).then(json => { authrole = json; });
    }
}

let editLut: LookupData[];
export const fetch_editLut = () => {
    return function (data: any) {
        if (editLut != undefined && editLut.length > 0)
            return;
        return App.GET(`/lookup/by/edit.lut`).then(json => {
            editLut = json;
            editLut.forEach(one => one.id = one.parentgroupe)
        });
    }
}
export const get_editLut = (year: number) => editLut;



let cIE: LookupData[];
export const fetch_cIE = () => {
    return function (data: any) {
        if (cIE != undefined && cIE.length > 0)
            return;
        return App.GET(`/lookup/by/cie`).then(json => { cIE = json; });
    }
}
export const get_cIE = (year: number) => cIE;

let sortOrderKeys: LookupData[];
export const fetch_sortOrderKeys = () => {
    return function (data: any) {
        const fill = (id: number, description: string) => {
            return <LookupData>{
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

let pays: LookupData[];
export const fetch_pays = () => {
    return function (data: any) {
        if (pays != undefined && pays.length > 0)
            return;
        return App.GET(`/lookup/by/pays`).then(json => { pays = json; });
    }
}
export const get_pays = (year: number) => pays;

let institutionBanquaire: LookupData[];
export const fetch_institutionBanquaire = () => {
    return function (data: any) {
        if (institutionBanquaire != undefined && institutionBanquaire.length > 0)
            return;
        return App.GET(`/lookup/by/institutionBanquaire`).then(json => { institutionBanquaire = json; });
    }
}
export const get_institutionBanquaire = (year: number) => institutionBanquaire;

let compte: LookupData[];
export const fetch_compte = () => {
    return function (data: any) {
        if (compte != undefined && compte.length > 0)
            return;
        return App.GET(`/lookup/by/compte`).then(json => { compte = json; });
    }
}
export const get_compte = (year: number) => compte;

let autreFournisseur: LookupData[];
export const fetch_autreFournisseur = () => {
    return function (data: any) {
        if (autreFournisseur != undefined && autreFournisseur.length > 0)
            return;
        return App.GET(`/lookup/by/autreFournisseur`).then(json => { autreFournisseur = json; });
    }
}
export const get_autreFournisseur = (year: number) => autreFournisseur;

let lot: LookupData[];
export const fetch_lot = () => {
    return function (data: any) {
        if (lot != undefined && lot.length > 0)
            return;
        return App.GET(`/lookup/by/lot`).then(json => { lot = json; });
    }
}
export const get_lot = (year: number) => lot;

let canton: LookupData[];
export const fetch_canton = () => {
    return function (data: any) {
        if (canton != undefined && canton.length > 0)
            return;
        return App.GET(`/lookup/by/canton`).then(json => { canton = json; });
    }
}
export const get_canton = (year: number) => canton;

let municipalite: LookupData[];
export const fetch_municipalite = () => {
    return function (data: any) {
        if (municipalite != undefined && municipalite.length > 0)
            return;
        return App.GET(`/lookup/by/municipalite`).then(json => { municipalite = json; });
    }
}
export const get_municipalite = (year: number) => municipalite;

let proprietaire: LookupData[];
export const fetch_proprietaire = () => {
    return function (data: any) {
        if (proprietaire != undefined && proprietaire.length > 0)
            return;
        return App.GET(`/lookup/by/proprietaire`).then(json => { proprietaire = json; });
    }
}
export const get_proprietaire = (year: number) => proprietaire;

let contingent: LookupData[];
export const fetch_contingent = () => {
    return function (data: any) {
        if (contingent != undefined && contingent.length > 0)
            return;
        return App.GET(`/lookup/by/contingent`).then(json => { contingent = json; });
    }
}
export const get_contingent = (year: number) => contingent;

let droit_coupe: LookupData[];
export const fetch_droit_coupe = () => {
    return function (data: any) {
        if (droit_coupe != undefined && droit_coupe.length > 0)
            return;
        return App.GET(`/lookup/by/droit_coupe`).then(json => { droit_coupe = json; });
    }
}
export const get_droit_coupe = (year: number) => droit_coupe;

let entente_paiement: LookupData[];
export const fetch_entente_paiement = () => {
    return function (data: any) {
        if (entente_paiement != undefined && entente_paiement.length > 0)
            return;
        return App.GET(`/lookup/by/entente_paiement`).then(json => { entente_paiement = json; });
    }
}
export const get_entente_paiement = (year: number) => entente_paiement;

let zone: LookupData[];
export const fetch_zone = () => {
    return function (data: any) {
        if (zone != undefined && zone.length > 0)
            return;
        return App.GET(`/lookup/by/zone`).then(json => { zone = json; });
    }
}
export const get_zone = (year: number) => zone;

let region: LookupData[];
export const fetch_region = () => {
    return function (data: any) {
        if (region != undefined && region.length > 0)
            return;
        return App.GET(`/lookup/by/region`).then(json => { region = json; });
    }
}
export const get_region = (year: number) => region;






let office: LookupData[];
export const fetch_office = () => {
    return function (data: any) {
        if (office != undefined && office.length > 0)
            return;
        return App.GET(`/office/lookup`).then(json => { office = json; });
    }
}
export const get_office = (year: number) => office;

let job: LookupData[];
export const fetch_job = () => {
    return function (data: any) {
        if (job != undefined && job.length > 0)
            return;
        return App.GET(`/job/lookup`).then(json => { job = json; });
    }
}
export const get_job = (year: number) => job;

let cat: LookupData[];
export const fetch_cat = () => {
    return function (data: any) {
        if (cat != undefined && cat.length > 0)
            return;
        return App.GET(`/lookup/by/cat`).then(json => { cat = json; });
    }
}
export const get_cat = (year: number) => cat;
