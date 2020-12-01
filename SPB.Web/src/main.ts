"use strict"

import * as App from "../_BaseApp/src/core/app"
import * as BaseMain from "../_BaseApp/src/main"
import * as Theme from "../_BaseApp/src/theme/theme"
import * as LatLong from "../_BaseApp/src/theme/latlong"
//
import { fr_CA } from "./fr-CA"
import * as Perm from "./permission"
import * as Layout from "./layout"
import * as Home from "./home"
//
//import * as AdminMain from "./admin/main"
//import * as FireMain from "./fire/main"
//import * as WeatherMain from "./weather/main"
//import * as AircraftMain from "./aircraft/main"
//import * as CostMain from "./cost/main"
//import * as ConfigMain from "./config/main"
//
//import "time-input-polyfill/auto"


declare const i18n: any;

interface IState {
    menuOpened: boolean
    subMenu: string
}

export let state: IState;


//
// Global references to application objects
// Mainly used for event handlers
//
window["App"] = App;
window[Theme.NS] = Theme;
window[LatLong.NS] = LatLong;
window[Layout.NS] = Layout;
window[Home.NS] = Home;


// Loader
if (window.parent != window) (<any>window.parent).stopLoader();

// Language files
let html_lang = document.documentElement.lang;
i18n.translator.add(fr_CA);


export const startup = (hasPublicHomePage = false) => {
    let main = BaseMain.startup(hasPublicHomePage, Layout, Theme);
    let router = main.router;

    // Routing table
    router.addRoute("^#/?$", Home.fetch);

    router.registerHashChanged((hash: string) => {
        if (hash.startsWith("#/signin")) {
            Home.clearMenuData();
        }
    });

    //AdminMain.startup();
    //FireMain.startup();
    //WeatherMain.startup();
    //AircraftMain.startup();
    //CostMain.startup();
    //ConfigMain.startup();

    loadUIState();
}

export const loadUIState = () => {
    let uid = Perm.getUID();
    let key = (uid != undefined ? `home-state:${uid}` : "home-state");
    state = JSON.parse(localStorage.getItem(key)) as IState;
    if (state == undefined) {
        state = <IState>{
            menuOpened: true,
            subMenu: ""
        }
    }
}

export const saveUIState = () => {
    let uid = Perm.getUID();
    let key = (uid != undefined ? `home-state:${uid}` : "home-state")
    localStorage.setItem(key, JSON.stringify(state));
}
