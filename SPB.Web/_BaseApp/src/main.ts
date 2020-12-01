"use strict"

import * as App from "./core/app"
import * as Router from "./core/router"
import * as Auth from "./auth"

export { ITheme } from "./core/app"
export { ILayout } from "./core/app"


//
// Global references to application objects
// These must match the "NS" values defined in modules
// Mainly used for event handlers
//
(<any>window).App_Auth = Auth;


// Routing table
Router.addRoute("^#/signin/(.*)$", params => { Auth.fetch(params); });
Router.addRoute("^#/signout/?$", Auth.signout);
Router.addRoute("^#/accept-invitation/(.*)$", Auth.fetchInvitation);
Router.addRoute("^#/reset-password/(.*)$", Auth.fetchReset);



const checkAuthenticationExpiryLoop = () => {
    const updater = () => {
        if (App.requireAuthentication()) {
            console.log("Authentication required")
            Router.reload();
        }
    };
    setInterval(updater, 2000);
}

export const startup = (hasPublicHomePage: boolean, layout: App.ILayout, theme: App.ITheme) => {
    App.initialize(hasPublicHomePage, layout, theme);

    // We need to wait before the caller initializes its routes before Router.gotoCurrent()
    setTimeout(() => {
        checkAuthenticationExpiryLoop();
        Router.gotoCurrent();
    }, 0);

    return {
        app: App,
        router: Router
    };
}
