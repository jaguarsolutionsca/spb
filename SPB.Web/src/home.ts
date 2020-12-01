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
    canView: boolean
    securityPage?: number
    toolButton?: string
    sections: ISection[]
}

export interface ISection {
    name: string
    icon: string
    maxrows?: number
    hidden?: boolean
    canView?: boolean
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

    let year = Perm.getCurrentYear();
    today = new Date();
    yesterday = new Date();
    yesterday.setDate(today.getDate() - 1);
    tomorrow = new Date();
    tomorrow.setDate(today.getDate() + 1);
    tomorrow_2 = new Date();
    tomorrow_2.setDate(today.getDate() + 2);
    tomorrow_3 = new Date();
    tomorrow_3.setDate(today.getDate() + 3);
    tomorrow_4 = new Date();
    tomorrow_4.setDate(today.getDate() + 4);
    //
    region = Perm.getRegionLUID();
    //
    let isOpsFMS2020 = (year >= 2020);


    menuData = [
        {
            name: "Fires",
            icon: "far fa-fire",
            columnClass: "is-half-tablet is-one-third-widescreen",
            canView: true,
            securityPage: Perm.pageFire,
            sections: [
                {
                    name: "Data Entry", icon: "fal fa-table", canView: Perm.hasFire_CanUseDataEntry,
                    links: [
                        { name: "Daily Fire", href: "#/firedays", ns: ["App_firedays", "App_fireday", "App_firemap"] },
                        { name: "Fire History", href: "#/fires", ns: ["App_fires", "App_fire"] },
                        { name: "Wildfire Report", href: "#/wfrs", ns: ["App_wfrs", "App_wfr"] },
                        { name: "Daily Situation", href: "#/firesituations", ns: ["App_firesituations", "App_firesituation"] },
                        { name: "Fire Update", hidden: !isOpsFMS2020, canView: Perm.hasFire_CanManageFireUpdate, href: "#/fireupdates", ns: ["App_fireupdates", "App_fireupdate"] },
                        { name: "Check Fire Indicies", hidden: true },
                        { name: "Today's Fire", href: `#/fireday/${Misc.formatYYYYMMDD(today, "")}/${Perm.getRegionLUID()}` },
                        { name: "Yesterday's Fire", href: `#/fireday/${Misc.formatYYYYMMDD(yesterday, "")}/${Perm.getRegionLUID()}`, classes: "has-text-weight-bold" },
                        { name: "goto fire", markup: gotoFire(), noSidebar: true, },
                    ]
                },
                {
                    name: "Reports", icon: "fal fa-file-alt", canView: true,
                    links: [
                        { name: "Daily Fire", onclick: "App_rpt_bydate.fetch_dailyfire()" },
                        { name: "Fire History", onclick: "App_rpt_byfire.fetch_firehistory()" },
                        { name: "Wildfire Report", onclick: "App_rpt_byfire.fetch_wfr()" },
                        { name: "Daily Situation", onclick: "App_rpt_bydate.fetch_dailysituation()" },
                        { name: "District Fire", href: "/opsfms.web/excel/odata_fire.xlsx" },
                        { name: "Wildfire Pivot", href: "/opsfms.web/excel/odata_wfr.xlsx" },
                    ]
                },
                {
                    name: "Maps", icon: "fal fa-map-marker-alt",
                    links: [
                        { name: "Fire Display", onclick: `App_rpt_bydate.fetch_firesitmap();` },
                        { name: "Fire Danger Classes", onclick: `App_rpt_bydate.fetch_6plex();` },
                        { name: "Upload Perimeter", markup: uploadPerimeter() },
                    ]
                },
                {
                    name: "gov.mb.ca", icon: "fas fa-external-link", maxrows: 3,
                    links: [
                        { name: "Fire Hazard Maps", href: "https://www.gov.mb.ca/sd/fire/Fire-Hazard/index.html" },
                        { name: "Fire Status Reports", href: "https://www.gov.mb.ca/sd/fire/Fire-Status/index.html" },
                        { name: "Fire Status Displays", href: "https://www.gov.mb.ca/sd/fire/Fire-Display/index.html" },
                        { name: "Fire Situation Reports", href: "https://www.gov.mb.ca/sd/fire/Fire-Situation/index.html" },
                        { name: "Fire Update Reports", href: "https://www.gov.mb.ca/sd/fire/Fire-Update/index.html" },
                        { name: "FireView", href: "https://www.gov.mb.ca/sd/fire/Fire-Maps/fireview/fireview.html", hidden: false },
                    ]
                },
                {
                    name: "Activity", icon: "far fa-clock", hidden: true,
                    links: [
                        { name: "*Radio Message Log" },
                    ]
                },
            ]
        },
        {
            name: "Weather",
            icon: "far fa-sun-cloud",
            columnClass: "is-half-tablet is-one-third-widescreen",
            canView: true,
            securityPage: Perm.pageWeather,
            sections: [
                {
                    name: "Data Entry", icon: "fal fa-table", canView: Perm.hasWeather_CanUseDataEntry,
                    links: [
                        { name: "Weather/Day", hidden: true },
                        { name: "Weather/Station", hidden: true },
                        { name: "Forecast", hidden: true },
                        { name: "Weather Forecast", hidden: !isOpsFMS2020, href: "#/weatherforecasts", ns: ["App_weatherforecasts", "App_weatherforecast"] },
                        { name: "Station", href: "#/stations", ns: ["App_stations", "App_station"] },
                        { name: "Greenup", href: "#/springs", ns: ["App_springs"] },
                    ]
                },
                {
                    name: "Reports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Weather/Day", onclick: "App_rpt_wxbydate.fetch_wxbyday()" },
                        { name: "Weather/Station", onclick: "App_rpt_wxbystation.fetch()" },
                        { name: "Hourly Weather/Day", onclick: "App_rpt_hourly.fetch_byday()" },
                        { name: "Hourly Weather/Station", onclick: "App_rpt_hourly.fetch_bystation()" },
                        { name: "Hourly Weather/Region", onclick: "App_rpt_hourly.fetch_byregion()" },
                        { name: "Station Report", onclick: "App_rpt_stnbyregion.fetch()" },
                    ]
                },
                {
                    name: "Internal Links", icon: "fal fa-chart-bar",
                    links: [
                        { name: "Bar Chart", hidden: true },
                        { name: "Hauling Chart", hidden: true },
                        { name: "Forecast Charts", href: "https://www.gov.mb.ca/sd/fire/Wx-Display/cc/weather.html" },
                    ]
                },
                {
                    name: "Maps", icon: "fal fa-map-marker-alt",
                    links: [
                        { name: "Temperature", onclick: "App_rpt_wxbydate.fetch_temp()" },
                        { name: "Relative Humidity", onclick: "App_rpt_wxbydate.fetch_rh()" },
                        { name: "Wind Direction", onclick: "App_rpt_wxbydate.fetch_wd()", hidden: true },
                        { name: "Wind Speed", onclick: "App_rpt_wxbydate.fetch_ws()" },
                        { name: "Precipitation", onclick: "App_rpt_wxbydate.fetch_rain()" },
                        { name: "DSR", onclick: "App_rpt_wxbydate.fetch_dsr()" },
                    ]
                },
                {
                    name: "Fcst Reports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Noon Today", href: App.url(`report/weather/forecast?date=${Misc.formatYYYYMMDD(today, "")}&region=${region}`), isExternal: true },
                        { name: "Noon Tomorrow", href: App.url(`report/weather/forecast?date=${Misc.formatYYYYMMDD(tomorrow, "")}&region=${region}`), isExternal: true },
                        { name: "Next 2 days", href: App.url(`report/weather/forecast?date=${Misc.formatYYYYMMDD(tomorrow_2, "")}&region=${region}`), isExternal: true },
                        { name: "Next 3 days", href: App.url(`report/weather/forecast?date=${Misc.formatYYYYMMDD(tomorrow_3, "")}&region=${region}`), isExternal: true },
                        { name: "Next 4 days", href: App.url(`report/weather/forecast?date=${Misc.formatYYYYMMDD(tomorrow_4, "")}&region=${region}`), isExternal: true },
                        { name: "By Date", onclick: "App_rpt_wxbydate.fetch_forecast()" },
                        { name: "Forecast Pivot Table", href: "/opsfms.web/excel/odata_forecast.xlsx" },
                    ]
                },
                {
                    name: "Lightning", icon: "far fa-bolt",
                    links: [
                        { name: "Historical", onclick: "App_rpt_period.fetch_lightning()" },
                        { name: "Last hour", href: App.url("map/lightning/last/1"), isExternal: true },
                        { name: "Last 12 hours", href: App.url("map/lightning/last/12"), isExternal: true },
                        { name: "Last 24 hours", href: App.url("map/lightning/last/24"), isExternal: true },
                        { name: "Last 48 hours", href: App.url("map/lightning/last/48"), isExternal: true },
                        { name: "Last 72 hours", href: App.url("map/lightning/last/72"), isExternal: true },
                    ]
                },
                {
                    name: "gov.mb.ca", icon: "fas fa-external-link", maxrows: 2,
                    links: [
                        { name: "Fire Weather Calculations", href: "https://www.gov.mb.ca/sd/fire/Wx-Report/index.html" },
                        { name: "Fire Weather Forecast Reports", href: "https://www.gov.mb.ca/sd/fire/Wx-Forecast/index.html" },
                        { name: "Contour Maps", href: "https://www.gov.mb.ca/sd/fire/Wx-Display/index.html" },
                        { name: "WeatherView", href: "https://www.gov.mb.ca/sd/fire/Wx-Display/weatherview/weatherview.html", hidden: false },
                    ]
                }
            ]
        },
        {
            name: "Aircraft",
            icon: "far fa-plane",
            columnClass: "is-half-tablet is-one-third-widescreen",
            canView: true,
            securityPage: Perm.pageAircraft,
            sections: [
                {
                    name: "Data Entry", icon: "fal fa-table", canView: Perm.hasAircraft_CanUseDataEntry,
                    links: [
                        { name: "Attack Base", href: "#/attackbases", ns: ["App_attackbases", "App_attackbase"] },
                        { name: "Aircraft", href: "#/aircrafts", ns: ["App_aircrafts", "App_aircraft"] },
                        { name: "Registration", href: "#/aircraftregistrations", ns: ["App_aircraftregistrations", "App_aircraftregistration"] },
                        { name: "Company", href: "#/aircraftcompanys", ns: ["App_aircraftcompanys", "App_aircraftcompany"] },
                        { name: "Contract", href: "#/aircraftcontracts", ns: ["App_aircraftcontracts", "App_aircraftcontract"] },
                        { name: "Standby Aircraft", href: "#/standbydays", ns: ["App_standbydays", "App_standbyday"], hidden: true },
                        { name: "*AFF", hidden: true },
                        { name: "*Heli. Manifest", hidden: true },
                    ]
                },
                {
                    name: "Reports", icon: "fal fa-file-alt", canView: true,
                    links: [
                        { name: "Attack Base", href: App.url(`report/aircraft/attackbase`), isExternal: true },
                        { name: "Aircraft", href: App.url(`report/aircraft/aircraft`), isExternal: true },
                        { name: "Registration", onclick: "App_rpt_byyear.fetch_registration()" },
                        { name: "Company", onclick: "App_rpt_byyear.fetch_company()" },
                        { name: "Contract", onclick: "App_rpt_byyear.fetch_contract()" },
                        { name: "Aircraft Pivot Table ", href: "/opsfms.web/excel/odata_flight.xlsx" },
                    ]
                },
                {
                    name: "Maps", icon: "fal fa-map-marker-alt",
                    links: [
                        { name: "Attack Base", href: App.url(`map/attackbase?year=${year}`), isExternal: true },
                    ]
                },
                {
                    name: "Activity", icon: "far fa-clock", hidden: true,
                    links: [
                        { name: "*Aircraft" },
                        { name: "*Helicopter" },
                        { name: "*Waterbomber" },
                        { name: "*Other Aircraft" },
                    ]
                },
            ]
        },
        {
            name: "Costs",
            icon: "far fa-money-bill",
            columnClass: "is-half-tablet",
            canView: true,
            securityPage: Perm.pageCost,
            sections: [
                {
                    name: "Data Entry", icon: "fal fa-table",
                    links: [
                        { name: "Flight Ticket", href: "#/tickets", ns: ["App_tickets", "App_ticket", "App_ticketdetails", "App_ticketdetail"] },
                        { name: "Daily Costs", href: "#/mses", ns: ["App_mses", "App_mseday"] },
                        { name: "Fire Ops", href: "#/fops", ns: ["App_commitfops"] },
                        { name: "Charge Back / EFF", href: "#/cbacks", ns: ["App_commitcbacks"] },
                        { name: "goto ticket", markup: gotoTicket(), noSidebar: true, },
                        { name: "*Invoice Scanning", hidden: true, },
                    ]
                },
                {
                    name: "Reports", icon: "fal fa-file-alt",
                    links: [
                        { name: "Flight Ticket (Single)", onclick: "App_rpt_byticket.fetch()" },
                        { name: "Summary Flight Ticket", onclick: "App_rpt_byrange.fetch_ticketsummary()" },
                        { name: "Manpower/Supp (by Date)", onclick: "App_rpt_bydate.fetch_manpowersupply()" },
                        { name: "Manpower/Supp (by Fire)", onclick: "App_rpt_byfire.fetch_manpowersupply()" },
                        { name: "Equipment (by Date)", onclick: "App_rpt_bydate.fetch_equipment()" },
                        { name: "Equipment (by Fire)", onclick: "App_rpt_byfire.fetch_equipment()" },
                        { name: "Fire Cost Report", onclick: "App_rpt_byrange.fetch_firecost()" },
                        { name: "Flight Ticket Filter", href: "/opsfms.web/excel/odata_ticket.xlsx" },
                    ]
                },
            ]
        },
        {
            name: "Tools",
            icon: "fa fa-wrench",
            columnClass: "is-half-tablet",
            canView: true,
            toolButton: `<a class="button is-small is-outlined" href="#/admin/lookups/tools"><span class="icon is-small"><i class="far fa-tasks"></i></span></a>`,
            sections: [
                {
                    hidden: true,
                    name: "Compute", icon: "fal fa-calculator-alt",
                    links: [
                        { name: "Detection Assessment" },
                        { name: "Coordinate Conversions" },
                        { name: "FWI Calculator" },
                    ]
                },
                {
                    name: "Internal Sites", icon: "far fa-external-link",
                    links: [
                        { name: "Fire Maps" },
                        { name: "DSR Charts" },
                    ]
                },
                {
                    name: "Public Sites", icon: "far fa-external-link",
                    links: [
                        { name: "CFS Fire M3 hotspots", href: "https://cwfis.cfs.nrcan.gc.ca/maps/fm3?type=tri" },
                    ]
                },
                {
                    name: "Operations", icon: "fal fa-phone-office",
                    links: [
                        { name: "AM conference call" },
                        { name: "PM conference call" },
                    ]
                },
            ]
        },
        {
            name: "Administration",
            icon: "fa fa-cogs",
            columnClass: "is-half-tablet",
            canView: Perm.hasHome_CanViewAdminModule,
            sections: [
                {
                    name: "Management", icon: "fas fa-lock", canView: Perm.hasHome_CanViewAdminModule,
                    links: [
                        { name: "Accounts", href: "#/admin/accounts", ns: ["App_accounts", "App_account"] },
                        { name: "Pages Security", href: "#/admin/apages", ns: ["App_Apages", "App_Apage"], canView: Perm.canBuildSecurity },
                        { name: "Audit", href: "#/admin/audittrails", ns: ["App_auditTrails"] },
                        { name: "Server Monitoring", hidden: true },
                        { name: "Scheduler", hidden: true },
                        { name: "Web Generator", canView: Perm.canViewWebgen, href: "/opsfms.gen" },
                        { name: "Log Files", href: "#", canView: Perm.canViewLogs, onclick: "return App.download('/log/latest', 'log.txt')" },
                    ]
                },
                {
                    name: "Configuration", icon: "fa fa-cog",
                    links: [
                        { name: "Setup Values", href: "#/configs", ns: ["App_configs", "App_config", "App_greenups", "App_greenup"] },
                        { name: "Code Tables", href: "#/admin/lookups/action", ns: ["App_Lookups", "App_Lookup"] },
                        { name: "Map Info", hidden: true },
                        { name: "Cell Assignment", hidden: true },
                    ]
                },
            ]
        },
    ];

    let onlyUnique = (value, index, self) => self.indexOf(value) === index;
    let tools = loadToolsState();
    let codes = tools.map(one => one.code).filter(onlyUnique).sort();

    menuData[4].sections = codes.map(code => {
        let meta = tools.filter(one => one.code == code);
        return <ISection>{
            hidden: false,
            name: meta[0].value1,
            icon: meta[0].value2,
            links: meta.map(one => <ILink>{
                name: one.description,
                href: one.value3
            })
        }
    });

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

        let liClasses = (link.classes ? `class="${link.classes}"` : "");

        if (link.markup)
            return `<li ${liClasses}>${link.markup}</li>`;

        let isDisabled = (link.href == undefined && link.onclick == undefined)
        let href = (link.href || "#")
        let isExternal = href.startsWith("http") || link.isExternal;

        return `<li ${liClasses}><a href="${href}" ${isDisabled ? `class="js-disabled"` : ``} ${isExternal ? `target="_new"` : ``} ${link.onclick ? `onclick="${link.onclick}"` : ""}>${link.name}</a></li>`;
    }

    const sectionTemplate = (section: ISection, columnClass: string) => {
        if (section.hidden)
            return "";

        const reduceSection = () => {
            let links = section.links.filter(one => one.canView == undefined || one.canView);

            let maxrows = (section.maxrows == undefined ? 32 : section.maxrows);
            let html = "";
            for (var ix = 0; ix < links.length; ix++) {
                let ixe = ix % maxrows;
                if (ixe == 0) html += "<ul>";
                html += linkTemplate(links[ix]);
                if (ixe == (maxrows - 1) || ix == links.length - 1) html += "</ul>";
            }
            return html;
        };

        return `
        <div class="column ${section.maxrows == undefined ? columnClass : ""}">
            <h3><i class="${section.icon}"></i> ${section.name}</h3>
            <div class="js-links">${reduceSection()}</div>
        </div>
`;
    };

    const menuItemTemplate = (menuItem: IMenuItem) => {
        let securityButton = menuItem.securityPage ? `
            <a class="button is-small is-outlined" href="#/admin/page/${menuItem.securityPage}">
                <span class="icon is-small"><i class="fa fa-lock"></i></span>
            </a>` : "";

        let toolButton = menuItem.toolButton;

        let hasButtons = (Perm.canEditSecurity && (securityButton || toolButton));

        return `
<div class="column is-half-tablet is-one-third-fullhd">
    <div class="box">
        <div class="js-widget">
${hasButtons ? `
            <div class="js-flex-end">
                ${securityButton ? securityButton : ""}
                ${toolButton ? toolButton : ""}
            </div>
` : ``}
            <div class="tile">
                <i class="${menuItem.icon} fa-4x"></i>
                <div>${menuItem.name}</div>
            </div>
            <div class="columns is-mobile is-multiline">
                ${menuItem.sections.filter(one => one.canView == undefined || one.canView).reduce((html, item) => { return html + sectionTemplate(item, menuItem.columnClass) }, "")}
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

${Perm.canEditHomeSecurity ? `
        <div class="js-flex-end js-security">
            <div class="level-item">
                ${Perm.buttonTemplate(Perm.pageHome)}
            </div>
        </div>
` : ``}

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
        .then(Lookup.fetch_tools())
        .then(() => { saveToolsState(Lookup.get_tools(Perm.getCurrentYear())) })
}

export const fetch = () => {
    App.setRenderDomain(Layout);
    App.prepareRender(NS, "Home");
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

const gotoFire = () => {
    return `
<div class="control has-icons-right" style="width: 110px; margin: 0.5rem 0;">
    <input class="input is-primary" type="text" placeholder="Quick Fire" maxlength="5" onkeydown="if(event.keyCode==13)${NS}.ongotoFire(event.target)">
    <span class="icon is-right"><i class="far fa-link"></i></span>
</div>
`;
}

const uploadPerimeter = () => {
    return `
<a href="#/fireperimeter/new">
    <span class="icon is-small">
        <i class="far fa-cloud-upload-alt"></i>
    </span>
    <span>Upload Perimeter</span>
</a>
`;
}

const gotoTicket = () => {
    return `
<div class="control has-icons-right" style="width: 125px; margin: 0.5rem 0;">
    <input class="input is-primary js-no-spinner" type="number" placeholder="Quick Ticket" maxlength="5" onkeydown="if(event.keyCode==13)${NS}.ongotoTicket(event.target)">
    <span class="icon is-right"><i class="far fa-link"></i></span>
</div>
`;
}

export const ongotoFire = (element: HTMLInputElement) => {
    App.prepareRender();
    let fireno = element.value;
    App.GET(`/fire/exists/${fireno}`)
        .then((fireid: number) => {
            if (fireid != undefined) {
                Router.goto(`#/fire/${fireid}`, 10)
            }
            else {
                Misc.toastFailure("Invalid Fire number", 2500);
                App.render()
            }
        })
        .catch(App.render)
}

export const ongotoTicket = (element: HTMLInputElement) => {
    App.prepareRender();
    let ticketno = element.value;
    App.GET(`/ticket/exists/${ticketno}`)
        .then((ticketid: number) => {
            if (ticketid != undefined) {
                Router.goto(`#/ticket/${ticketid}`, 10)
            }
            else {
                Misc.toastFailure("Invalid Ticket number", 2500);
                App.render()
            }
        })
        .catch(App.render)
}


const loadToolsState = () => {
    return JSON.parse(localStorage.getItem("tools-state")) as Lookup.LookupData[];
}

const saveToolsState = (uiTools) => {
    localStorage.setItem("tools-state", JSON.stringify(uiTools));
}
