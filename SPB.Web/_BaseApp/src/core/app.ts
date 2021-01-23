"use strict"

import * as Auth from "../auth"
export { isAuthenticated, getUserCaps, UserCaps } from "../auth"
//import * as Theme from "../theme/theme"
//import * as Layout from "../layout"
//import * as LayoutReport from "../layoutReport"

export interface ITheme {
    warningTemplate: (errorMessages: string[]) => string
    fatalErrorTemplate403: () => string
    fatalErrorTemplate404: () => string
    dirtyTemplate: (ns: string, details?: string) => string
    unexpectedTemplate: () => string
}

export interface ILayout {
    render: () => string
    postRender: () => void
}

export interface IFeature {
    emailEnabled: boolean
}

let context = "";
let root = (<any>window).APP.root;
let api = (<any>window).APP.api;
let name = (<any>window).APP.name;
let Layout: ILayout;
let Theme: ITheme;

// Note: Always fresh
export let cie: number = (<any>window).APP.cie;

export let Feature: IFeature = {
    emailEnabled: (<any>window).APP.emailEnabled
}

interface IException {
    hasError: boolean
    messages: string[]
    status: number
    kind: string
    code: number
}

interface IRender { (): string }
interface IPostRender { (): void }

let error = <IException>{ hasError: false };
let sessionExpired = false;
let rendering = false;
let title = "";
//
let myPublicHomePage = false;


export const initialize = (hasPublicHomePage: boolean, layout: ILayout, theme: ITheme) => {
    myPublicHomePage = hasPublicHomePage;
    Layout = layout;
    Theme = theme;
};

export const requireAuthentication = () => {
    if (myPublicHomePage) {
        if (window.location.hash.length == 0 || window.location.hash == "/#" || window.location.hash == "/#/")
            return false;
    }
    return Auth.requireAuthentication();
}

const myrender = (pageRender: IRender, pagePostRender: IPostRender) => {
    if (!rendering) {
        if (requireAuthentication()) {
            Auth.redirectToSignin();
            return;
        }
        rendering = true;
        //
        let hasServerError = (serverError() ? "js-server-error" : "");
        let hasFatalError = (fatalError() ? "js-fatal-error" : "");
        //
        let html = (context == Auth.NS ? Auth.render() : pageRender());
        let element = document.getElementById("app-root");
        ((<any>window).morphdom)(element, `<div id="app-root" class="js-fadein ${hasServerError} ${hasFatalError}">${html}</div>`, {
            getNodeKey: function (node) { return node.id; },
            onBeforeNodeAdded: function (node) { return node; },
            onNodeAdded: function (node) { },
            onBeforeElUpdated: function (fromEl: HTMLElement, toEl) {
                if (fromEl.matches("input[type=text]:focus")) return false;
                if (fromEl.matches("input[type=number]:focus")) return false;
                if (fromEl.matches("textarea:focus")) return false;
                if (fromEl.hasAttribute("js-skip-render-class") && fromEl.classList.contains(fromEl.getAttribute("js-skip-render-class"))) return false;
                if (fromEl.hasAttribute("js-skip-render-not-class") && !fromEl.classList.contains(fromEl.getAttribute("js-skip-render-not-class"))) return false;
                return true;
            },
            onElUpdated: function (el) { },
            onBeforeNodeDiscarded: function (node) { return true; },
            onNodeDiscarded: function (node) { },
            onBeforeElChildrenUpdated: function (fromEl, toEl) { return true; }
        });
        pagePostRender();
        postRender();
        if (context == Auth.NS) clearSessionExpired();
        //
        rendering = false;
    }
};

const postRender = () => {
    document.title = title;
    document.body.id = context.toLowerCase().replace("_", "-");
    if (!sessionExpired) clearErrors();
};

export const render = () => {
    myrender(Layout.render, Layout.postRender);
};

export const renderOnNextTick = () => {
    setTimeout(render, 0);
};

export const pauseRender = (pause = true) => {
    rendering = pause;
}

export const setRenderDomain = (layout: ILayout) => {
    Layout = layout;
};

export const prepareRender = (ns: string = "", title: string = "") => {
    transitionUI();
    if (!sessionExpired) clearErrors();
    if (title.length > 0) setPageTitle(title);
    if (ns.length > 0) setContext(ns);
};

export const transitionUI = () => {
    let element = document.getElementById("app-root");
    element.classList.remove("js-fadein");
    element.classList.add("js-waiting");
};

export const setPageTitle = (newtitle: string) => {
    title = `${newtitle} | ${name}`;
};

const setContext = (ns: string) => {
    context = ns;
};

export const inContext = (ns: string | string[]) => {
    if (context == undefined)
        return false;
    if (typeof ns === "string")
        return (context == ns);
    else
        return (ns.indexOf(context) != -1);
};

export const setError = (text: string) => {
    error.hasError = true;
    error.messages.push(text);
    return false;
};

export const clearErrors = () => {
    error.hasError = false;
    error.status = 0;
    error.messages = [];
};

export const hasError = () => {
    return (error != undefined && error.hasError);
};

export const hasNoError = () => {
    return !hasError();
};

export const warningTemplate = () => {
    if (hasNoError())
        return "";
    return Theme.warningTemplate(error.messages);
};

export const serverError = () => {
    return (hasError() && error.status == 500);
};

export const fatalError = () => {
    return (hasError() && (error.status == 403 || error.status == -404));
};

export const fatalErrorTemplate = () => {
    if (hasError() && error.status == 403)
        return Theme.fatalErrorTemplate403();

    if (hasError() && error.status == -404)
        return Theme.fatalErrorTemplate404();
};

export const dirtyTemplate = (ns: string, details: string = null) => {
    return Theme.dirtyTemplate(ns, details);
};

export const unexpectedTemplate = () => {
    return Theme.unexpectedTemplate();
}

const setSessionExpired = () => {
    sessionExpired = true;
};

const clearSessionExpired = () => {
    sessionExpired = false;
    clearErrors();
};

const handleFetch = (response: Response) => {
    if (!response.ok) {
        if (response.status == 304/*Not Modified*/) {
            return null;
        }
        else if (response.status == 401/*Unauthorized (authentication error really - requires user to signin)*/) {
            error.hasError = true;
            error.messages = ["Not authenticated"];
            error.status = response.status;
            throw error;
        }
        else if (response.status == 403/*Forbidden (authorization error really)*/) {
            error.hasError = true;
            error.messages = ["Not authorized"];
            error.status = response.status;
            throw error;
        }
        else if (response.status != 500/*500 is used for validation error - and it's handled later when json content is available*/) {
            error.hasError = true;
            error.messages = [response.statusText];
            error.status = response.status;
            throw error;
        }
    }
    else {
        if (response.status == 204/*No Content*/) {
            return null;
        }
    }
    return response;
};

const parseJson = (response: Response) => {
    if (response == null)
        return null;

    return response
        .text()
        .then(text => {
            const datetimeFormat = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}/;
            const reviver = function (key, value) {
                if (typeof value === "string" && datetimeFormat.test(value)) {
                    return new Date(value);
                }
                return value;
            }

            if (!text)
                return null;

            var json = JSON.parse(text, reviver);
            if ((<IException>json).hasError/*Error returned by the api exception handler*/) {
                error.hasError = true;
                error.messages = [(<any>json).message];
                error.status = 500; /*500 is used for validation error*/
                throw error;
            }
            return json;
        });
}

const catchFetch = (reason: IException | any) => {
    if (reason.hasError != undefined) {
        //All errors except network failures
        error.hasError = reason.hasError;
        error.messages = reason.messages;
        error.status = reason.status;

        if (error.status == 401/*Unauthorized (not authenticated or expired)*/) {
            setSessionExpired();
            Auth.redirectToSignin();
        }
    }
    else {
        //"Failed to fetch": Network failures or api server is not responding
        error.hasError = true;
        error.messages = [reason.message];
        error.status = -404;
    }
    throw reason;
};

export const apiurl = (resource: string) => {
    return `${root}${api}${resource}`;
};

export const url = (resource: string) => {
    return `${root}${resource}`;
};

export const POST = (url: string, body: any) => {
    return window.fetch(`${root}${api}${url}`,
        {
            method: "post",
            headers: { "Content-type": "application/json", "Authorization": Auth.getAuthorization() },
            credentials: "include",
            mode: "cors",
            body: JSON.stringify(body)
        })
        .then(handleFetch)
        .then(parseJson)
        .catch(catchFetch);
};

export const GET = (url: string) => {
    return window.fetch(`${root}${api}${url}`,
        {
            method: "get",
            headers: { "Authorization": Auth.getAuthorization(), "Cache-Control": "no-cache", "Pragma": "no-cache" },
            credentials: "include",
            mode: "cors",
        })
        .then(handleFetch)
        .then(parseJson)
        .catch(catchFetch);
};

export const PUT = (url: string, body: any) => {
    return window.fetch(`${root}${api}${url}`,
        {
            method: "put",
            headers: { "Content-type": "application/json", "Authorization": Auth.getAuthorization() },
            credentials: "include",
            mode: "cors",
            body: JSON.stringify(body)
        })
        .then(handleFetch)
        .then(parseJson)
        .catch(catchFetch);
};

export const DELETE = (url: string, body: any) => {
    return window.fetch(`${root}${api}${url}`,
        {
            method: "delete",
            headers: { "Content-type": "application/json", "Authorization": Auth.getAuthorization() },
            credentials: "include",
            mode: "cors",
            body: JSON.stringify(body)
        })
        .then(handleFetch)
        .then(parseJson)
        .catch(catchFetch);
};

export const UPLOAD = (url: string, body: any) => {
    return window.fetch(`${root}${api}${url}`,
        {
            method: "post",
            headers: { "Authorization": Auth.getAuthorization() },
            credentials: "include",
            mode: "cors",
            body: body
        })
        .then(handleFetch)
        .then(parseJson)
        .catch(catchFetch);
};

export const DOWNLOAD = (url: string) => {
    return window.fetch(`${root}${api}${url}`,
        {
            method: "get",
            headers: { "Authorization": Auth.getAuthorization() },
            credentials: "include",
            mode: "cors",
        })
        .then(handleFetch)
        .then(response => response.blob())
        .catch(catchFetch);
};

export const download = (url: string, name: string, event: Event) => {
    if (event) {
        event.preventDefault();
        event.stopPropagation();
    }

    let anchor = document.createElement("a");
    document.body.appendChild(anchor);

    DOWNLOAD(url)
        .then(blob => {
            if (window.navigator.msSaveBlob != undefined) {
                window.navigator.msSaveBlob(blob, name);
            }
            else {
                let objectUrl = window.URL.createObjectURL(blob);
                anchor.href = objectUrl;
                anchor.rel = "noopener";
                anchor.download = name;
                anchor.click();
                setTimeout(_ => { window.URL.revokeObjectURL(objectUrl) }, 1000);
            }
        })
        .catch(render);

    return false;
};

export const view = (url: string, name: string, event: Event) => {
    if (event) {
        event.preventDefault();
        event.stopPropagation();
    }

    let anchor = document.createElement("a");
    document.body.appendChild(anchor);

    DOWNLOAD(url)
        .then(blob => {
            if (window.navigator.msSaveOrOpenBlob != undefined) {
                window.navigator.msSaveOrOpenBlob(blob, name);
            }
            else {
                let objectUrl = window.URL.createObjectURL(blob);
                window.open(objectUrl, "_blank");
                setTimeout(_ => { window.URL.revokeObjectURL(objectUrl) }, 1000);
            }
        })
        .catch(render);

    return false;
};

export const getPageState = (ns: string, key: string, defaultValue: any) => {
    let uid = Auth.getUID();
    let id = `pages-state:${uid}`;
    let pageState = JSON.parse(localStorage.getItem(id));

    if (pageState == undefined || pageState[ns] == undefined || pageState[ns][key] == undefined)
        return defaultValue;

    return pageState[ns][key];
}

export const setPageState = (ns: string, key: string, value: any) => {
    let uid = Auth.getUID();
    let id = `pages-state:${uid}`;
    let pageState = JSON.parse(localStorage.getItem(id));

    if (pageState == undefined)
        pageState = {};

    if (pageState[ns] == undefined)
        pageState[ns] = {};

    pageState[ns][key] = value;

    localStorage.setItem(id, JSON.stringify(pageState));
    return value;
}
