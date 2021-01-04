"use strict"

import * as App from "../_BaseApp/src/core/app"
import * as Router from "../_BaseApp/src/core/router"
import * as Misc from "../_BaseApp/src/lib-ts/misc"
import * as Theme from "../_BaseApp/src/theme/theme"
import * as domlib from "../_BaseApp/src/lib-ts/domlib"
import * as Lookup from "./admin/lookupdata"
import * as Perm from "./permission"
import * as Layout from "./layout"

declare const i18n: any;

export const NS = "App_Home";


export interface IMenuItem {
    name: string
    icon: string
    columnClass: string
    listColumnClass: string
    canView: boolean
    toolButton?: string
    sections: ISection[]
}

export interface ISection {
    name: string
    icon: string
    maxrows?: number
    hidden?: boolean
    canView?: boolean
    merge?: string
    links: ILink[]
}

export interface ILink {
    name: string
    href?: string
    hidden?: boolean
    canView?: boolean
    ns?: string[]
    isExternal?: boolean
    onclick?: string
    classes?: string
    markup?: string
    noSidebar?: boolean
}

let menuData: IMenuItem[];
let yesterday: Date;
let today: Date;
let tomorrow: Date;
let tomorrow_2: Date;
let tomorrow_3: Date;
let tomorrow_4: Date;
let region: number;


export const getMenuData = () => {
    if (menuData != undefined)
        return menuData;

    menuData = [
        {
            name: "Application",
            icon: "fad fa-cogs",
            columnClass: "is-half-tablet is-one-third-fullhd",
            listColumnClass: "",
            canView: true,
            sections: [
                {
                    name: "Gestion", icon: "fas fa-unlock-alt",
                    links: [
                        { name: "Comptes", href: "#/admin/accounts", ns: ["App_accounts", "App_account"] },
                        { name: "Matrice de sécurité", },
                        { name: "Gestion des tables", },
                        { name: "Gestion des périodes", },
                    ],
                    merge: "start"
                },
                {
                    merge: "end",
                    name: "Jaguar", icon: "fas fa-tools",
                    links: [
                        { name: "Compagnies", href: "#/admin/companys", ns: ["App_companys", "App_company"] },
                        { name: "Metadata des permissions", },
                        { name: "Audit", },
                    ]
                },
                {
                    name: "Configuration", icon: "fas fa-tools",
                    links: [
                        { name: "Paramètres du système", },
                        { name: "Personnalisation", },
                        { name: "Acomba", },
                        { name: "Comptes/Fournisseurs", },
                        { name: "Numéro de taxes", },
                        { name: "Permis", },
                        { name: "Paramètres d'impression", },
                        { name: "Backup", },
                    ]
                },
            ]
        },
        {
            name: "Territoires",
            icon: "fad fa-map-marker-alt",
            columnClass: "is-half-tablet is-one-third-fullhd",
            listColumnClass: "",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Lots", href: "#/lots", ns: ["App_lots", "App_lot"] },
                        { name: "Municipalités", },
                        { name: "Lots répétitifs", },
                        { name: "Agences", },
                        { name: "Cantons", },
                        { name: "MRC", },
                    ]
                },
                {
                    name: "Importation", icon: "fal fa-arrow-circle-down",
                    links: [
                        { name: "Lots répétitifs", },
                        { name: "Lots certifiés", },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt", canView: true,
                    links: [
                        { name: "Municipalités", },
                        { name: "Lots par municipalités", },
                        { name: "Lots par secteurs", },
                        { name: "Lots certifiés", },
                        { name: "Superficies (lot)", },
                        { name: "MRC", },
                        { name: "Cantons", },
                        { name: "Statistiques par essence", },
                    ]
                },
            ]
        },
        {
            name: "Essences",
            icon: "fad fa-trees",
            columnClass: "is-half-tablet is-one-third-fullhd",
            listColumnClass: "",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Essences", },
                        { name: "Unités de mesure", },
                        { name: "Essences de sciage", },
                        { name: "Répartitions d'essences", },
                        { name: "Regroupements d'essences", },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Liste des essences", },
                        { name: "Liste des unités de mesure", },
                    ]
                },
            ]
        },
        {
            name: "Fournisseurs",
            icon: "fad fa-user-tag",
            columnClass: "is-half-tablet is-one-third-fullhd",
            listColumnClass: "",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Propriétaires", href: "#/proprietaires", ns: ["App_proprietaires", "App_proprietaire"] },
                        { name: "Transporteurs", },
                        { name: "Chargeurs", },
                        { name: "Autres", },
                        { name: "Fournisseurs en paiement manuel", },
                        { name: "Institutions bancaires", },
                        { name: "Pays", },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Identification des producteurs", },
                        { name: "Livraisons par producteurs", },
                        { name: "Permis non-livrés", },
                        { name: "Superficies", },
                        { name: "Droits de coupe", },
                        { name: "Fonds de roulement", },
                        { name: "Sommaire des montants payés aux producteurs", },
                    ]
                },
            ]
        },
        {
            name: "Usines",
            icon: "fad fa-industry-alt",
            columnClass: "is-half-tablet is-one-third-fullhd",
            listColumnClass: "",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Usines", },
                        { name: "Contingent par regroupement", },
                        { name: "Contingent par usine", },
                        { name: "Demande de contingent", },
                        { name: "Utilisation par les usines", },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Usines", },
                        { name: "Certificat de contingent regroupement", },
                        { name: "Certificat de contingent usine", },
                    ]
                },
            ]
        },
        {
            name: "Contrats",
            icon: "fad fa-file-signature",
            columnClass: "is-half-tablet is-one-third-fullhd",
            listColumnClass: "",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Contrats", },
                        { name: "Ajustements de contrat", },
                        { name: "Augmentation taux transport", },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Contrats", },
                    ]
                },
            ]
        },
        {
            name: "Livraisons",
            icon: "fad fa-truck-container",
            columnClass: "is-half-tablet is-one-third-fullhd",
            listColumnClass: "",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Permis de livraison", },
                        { name: "Recherche de permis", },
                        { name: "Livraisons", },
                        { name: "Facture usine", },
                        { name: "Recherche de livraisons", },
                        { name: "Gestion des volumes", },
                    ],
                    merge: "start"
                },
                {
                    merge: "end",
                    name: "Importation", icon: "fal fa-arrow-circle-down",
                    links: [
                        { name: "Feuillet Domptar", },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Liste détaillée des livraisons", },
                        { name: "Sommaire des livraisons", },
                        { name: "Liste des livraisons (détail)", },
                        { name: "Liste des livraisons (résumé)", },
                        { name: "Répartition des livraisons", },
                        { name: "Nombre de producteurs qui ont livré par usine", },
                        { name: "Identification des transporteurs", },
                        { name: "Liste des transporteurs", },
                    ]
                },
            ]
        },
        {
            name: "Indexations",
            icon: "fad fa-book",
            columnClass: "is-half-tablet is-one-third-fullhd",
            listColumnClass: "",
            canView: true,
            sections: [
                {
                    name: "Saisie", icon: "fal fa-table",
                    links: [
                        { name: "Indexations", },
                    ]
                },
                {
                    name: "Rapports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Sommaire des factures par producteurs", },
                        { name: "Sommaire des factures par transporteurs", },
                    ]
                },
            ]
        },
        {
            name: "Comptabilité",
            icon: "fad fa-file-invoice-dollar",
            columnClass: "",
            listColumnClass: "",
            canView: true,
            sections: [
                {
                    name: "Mise à jour", icon: "fal fa-arrow-circle-down",
                    links: [
                        { name: "Mise à jour des comptes", },
                        { name: "Mise à jour des fournisseurs", },
                        { name: "Mise à jour des usines (clients)", },
                        { name: "Mise à jour des numéros de chèque", },
                        { name: "Mise à jour d'un numéro de chèque ", },
                    ],
                    merge: "start"
                },
                {
                    merge: "end",
                    name: "Opérations", icon: "fal fa-arrow-circle-up",
                    links: [
                        { name: "Transfert des factures", },
                        { name: "Backup des données", },
                    ],
                },
                {
                    name: "Calculs", icon: "fal fa-calculator",
                    links: [
                        { name: "Livraisons", },
                        { name: "Ajustements", },
                        { name: "Indexations", },
                        { name: "Erreurs: Mauvaises factures", },
                        { name: "Erreurs: Mauvais paiements", },
                    ]
                },
            ]
        },
        {
            name: "Rapports",
            icon: "fad fa-file-spreadsheet",
            columnClass: "is-full",
            listColumnClass: "js-nowrap",
            canView: true,
            sections: [
                {
                    name: "Territoires", icon: null,
                    links: [
                        { name: "Liste des municipalités", },
                        { name: "Liste des lots par municipalités", },
                        { name: "Liste des lots par secteurs", },
                        { name: "Liste des lots certifiés", },
                        { name: "Liste des superficies (lot)", },
                        { name: "Liste des MRC", },
                        { name: "Liste des cantons", },
                        { name: "Statistiques par essence", },
                    ]
                },
                {
                    name: "Essences", icon: null,
                    links: [
                        { name: "Liste des essences", },
                        { name: "Liste des unités de mesure", },
                    ]
                },
                {
                    name: "Producteurs", icon: null,
                    links: [
                        { name: "Liste des identifications producteurs", },
                        { name: "Liste des livraisons par producteur", },
                        { name: "Liste des superficies", },
                        { name: "Liste des identifications de droit de coupe", },
                        { name: "Liste des fonds de roulement", },
                        { name: "Liste sommaire des montants payés aux producteurs", },
                        { name: "Liste détaillée des livraisons", },
                        { name: "Liste des superficies (lots)", },
                        { name: "Liste d'envoi du bulletin (courriel)", },
                        { name: "Liste d'envoi du bulletin d'information", },
                        { name: "Liste d'envoi courriel pour un rappel", },
                        { name: "Rapport annuel", },
                    ]
                },
                {
                    name: "Transporteurs", icon: null,
                    links: [
                        { name: "Liste des identifications transporteurs", },
                        { name: "Liste des transporteurs", },
                        { name: "Liste sommaire des montants payés", },
                        { name: "Liste détaillée des livraisons", },
                        { name: "Rapport annuel", },
                    ]
                },
                {
                    name: "Chargeurs", icon: null,
                    links: [
                        { name: "Liste des identifications chargeurs", },
                        { name: "Liste des chargeurs", },
                        { name: "Liste sommaire des montants payés", },
                        { name: "Liste détaillée des livraisons", },
                        { name: "Rapport annuel", },
                    ]
                },
                {
                    name: "Autres fournisseurs", icon: null,
                    links: [
                        { name: "Liste des identifications", },
                    ]
                },
                {
                    name: "Usines", icon: null,
                    links: [
                        { name: "Liste des usines", },
                        { name: "Combinaison d'unités de mesure et essences", },
                    ]
                },
                {
                    name: "Contrats", icon: null,
                    links: [
                        { name: "Liste de contrats", },
                        { name: "Sommaire des contrats par usine", },
                        { name: "Table des prix aux producteurs", },
                        { name: "Table des prix aux transporteurs", },
                        { name: "Ventilation des montants calculés", },
                        { name: "Ventilation des montants calculés (Excel)", },
                        { name: "Contrôle de bois par usine", },
                        { name: "Contrôle de bois par usine (essences combinées)", },
                        { name: "Contrôle de bois par usine (essences codes combinées)", },
                        { name: "Contrôle de bois par contrat regroupement", },
                        { name: "Contrôle de bois par contrat usine", },
                        { name: "Répartition des volumes", },
                        { name: "Statistiques agence-MRC-secteur", },
                        { name: "Statistiques agence-municipalité-secteur", },
                        { name: "Nombre de producteurs", },
                    ]
                },
                {
                    name: "Contingentements", icon: null,
                    links: [
                        { name: "Demandes de contingent", },
                        { name: "Demandes de contingent Estrie", },
                        { name: "Autorisations de livraisons (usine)", },
                        { name: "Autorisations de livraisons (regroupement)", },
                        { name: "Certificat de contingent (usine)", },
                        { name: "Certificat de contingent (regroupement)", },
                        { name: "Permis Regroupement", },
                        { name: "Liste des contingentements par transporteur", },
                        { name: "Liste des contingentements par usine", },
                        { name: "Liste des contingentements par regroupement", },
                        { name: "Liste des demandes de contingentements", },
                        { name: "Rapport des irrégularités", },
                    ]
                },
                {
                    name: "Livraisons", icon: null,
                    links: [
                        { name: "Sommaire des livraisons", },
                        { name: "Sommaire des livraisons (avec déductions)", },
                        { name: "Liste des livraisons (détaillée)", },
                        { name: "Liste des livraisons (résumé)", },
                        { name: "Répartition des livraisons", },
                        { name: "Nombre de producteurs qui ont livré par usine", },
                        { name: "Liste des calculs (payés)", },
                        { name: "Liste des calculs (non-payés)", },
                        { name: "Livraisons non conformes (par transporteur)", },
                        { name: "Livraisons non conformes (sommaire)", },
                        { name: "Producteurs ayant livré / producteurs par secteur", },
                        { name: "Sciage et déroulage (m3 solide)", },
                        { name: "Feuillets de Domptar (Estrie)", },
                        { name: "Liste des livraisons par MRC", },
                        { name: "Valeur des livraisons", },
                    ]
                },
                {
                    name: "Gestion des volumes", icon: null,
                    links: [
                        { name: "Par usine", },
                        { name: "Détaillé", },
                    ]
                },
                {
                    name: "Indexations", icon: null,
                    links: [
                        { name: "Indexation aux transporteurs", },
                        { name: "Indexation aux producteurs", },
                        { name: "Indexation aux transporteurs (avant calculs)", },
                        { name: "Indexation aux producteurs (avant calculs)", },
                    ]
                },
                {
                    name: "Permis", icon: null,
                    links: [
                        { name: "Permis en circulation", },
                        { name: "Permis annulés", },
                    ]
                },
                {
                    name: "Factures", icon: null,
                    links: [
                        { name: "Impression des factures", },
                        { name: "Liste des factures par usine", },
                        { name: "Liste des factures du mois (date du calcul)", },
                        { name: "Liste des factures du mois (date de facture Acomba)", },
                        { name: "Sommaire des factures par producteur", },
                        { name: "Sommaire des factures par transporteur", },
                        { name: "Fournisseurs en paiement manuel", },
                        { name: "Écritures de mise en commun", },
                    ]
                },
                {
                    name: "Ajustements", icon: null,
                    links: [
                        { name: "Rapport usines", },
                        { name: "Rapport producteurs", },
                        { name: "Rapport transporteurs", },
                    ]
                },
            ]
        },
    ];

    return menuData;
}

export const clearMenuData = () => {
    menuData = null;
}

export const renderDropdown = (propName: string, options: string) => {
    return `
    <div class="select is-small">
        <select id="${NS}_${propName}" onchange="${NS}.onchange(this)">
            ${options}
        </select>
    </div>`;
}

const menuTemplate = (menuItems: IMenuItem[]) => {
    const linkTemplate = (link: ILink) => {
        if (link.hidden)
            return "";

        const liClasses = (link.classes ? `class="${link.classes}"` : "");

        if (link.markup)
            return `<li ${liClasses}>${link.markup}</li>`;

        const isDisabled = (link.href == undefined && link.onclick == undefined)
        const href = (link.href || "#")
        const isExternal = href.startsWith("http") || link.isExternal;

        return `<li ${liClasses}><a href="${href}" ${isDisabled ? `class="js-disabled"` : ``} ${isExternal ? `target="_new"` : ``} ${link.onclick ? `onclick="${link.onclick}"` : ""}>${link.name}</a></li>`;
    }

    const sectionTemplate = (section: ISection, listColumnClass: string) => {
        if (section.hidden)
            return "";

        const reduceSection = () => {
            const links = section.links.filter(one => one.canView == undefined || one.canView);

            const maxrows = (section.maxrows == undefined ? 32 : section.maxrows);
            let html = "";
            for (let ix = 0; ix < links.length; ix++) {
                const ixe = ix % maxrows;
                if (ixe == 0) html += "<ul>";
                html += linkTemplate(links[ix]);
                if (ixe == (maxrows - 1) || ix == links.length - 1) html += "</ul>";
            }
            return html;
        };

        const skipOpenDiv = (section.merge != undefined && section.merge == "end");
        const skipCloseDiv = (section.merge != undefined && section.merge == "start");

        return `
        ${!skipOpenDiv ? `<div class="column ${section.maxrows == undefined ? listColumnClass : ""}">` : ``}
            ${section.name ? `<h3><i class="${section.icon}"></i> ${section.name}</h3>` : ``}
            <div class="js-links">${reduceSection()}</div>
        ${!skipCloseDiv ? `</div>` : ``}
`;
    };

    const menuItemTemplate = (menuItem: IMenuItem) => {

        return `
<div class="column ${menuItem.columnClass}">
    <div class="box">
        <div class="js-widget">
            <div class="tile">
                <i class="${menuItem.icon} fa-4x"></i>
                <div>${menuItem.name}</div>
            </div>
            <div class="columns is-mobile is-multiline">
                ${menuItem.sections.filter(one => one.canView == undefined || one.canView).reduce((html, item) => { return html + sectionTemplate(item, menuItem.listColumnClass) }, "")}
            </div>
        </div>
    </div>
</div>
`;
    };

    return menuItems.filter(one => one.canView).reduce((html, item) => { return html + menuItemTemplate(item) }, "");
}

const pageTemplate = (menu: string) => {
    return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">
    <div style="padding:1rem;">
        <div class="columns is-multiline">
            ${menu}
        </div>
    </div>
</form>
`;
}

const fetchState = () => {
    return Promise
        .resolve()
        //.then(Lookup.fetch_tools())
        //.then(() => { saveToolsState(Lookup.get_tools(Perm.getCurrentYear())) })
}

export const fetch = () => {
    App.setRenderDomain(Layout);
    App.prepareRender(NS, "HOME");
    Router.registerDirtyExit(null);
    fetchState()
        .then(App.render)
        .catch(App.render)
};

export const render = () => {
    if (!App.inContext(NS)) return "";

    //
    // Build page
    //
    let menu = menuTemplate(getMenuData());
    return pageTemplate(menu);
}

export const postRender = () => {
    if (!App.inContext(NS)) return "";
}

const getFormState = () => {
};

export const onchange = (input: HTMLInputElement) => {
    //state = getFormState();
    App.render();
};


const loadToolsState = () => {
    return JSON.parse(localStorage.getItem("tools-state")) as Lookup.LookupData[];
}

const saveToolsState = (uiTools) => {
    localStorage.setItem("tools-state", JSON.stringify(uiTools));
}
