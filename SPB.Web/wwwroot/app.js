System.register("_BaseApp/src/core/app", ["_BaseApp/src/auth"], function (exports_1, context_1) {
    "use strict";
    var Auth, context, root, api, name, Layout, Theme, cie, Feature, error, sessionExpired, rendering, title, myPublicHomePage, initialize, requireAuthentication, myrender, postRender, render, renderOnNextTick, pauseRender, setRenderDomain, prepareRender, transitionUI, setPageTitle, setContext, inContext, setError, clearErrors, hasError, hasNoError, warningTemplate, serverError, fatalError, fatalErrorTemplate, dirtyTemplate, unexpectedTemplate, setSessionExpired, clearSessionExpired, handleFetch, parseJson, catchFetch, apiurl, url, POST, GET, PUT, DELETE, UPLOAD, DOWNLOAD, download, view, getPageState, setPageState;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [
            function (Auth_1) {
                Auth = Auth_1;
                exports_1({
                    "isAuthenticated": Auth_1["isAuthenticated"],
                    "getUserCaps": Auth_1["getUserCaps"]
                });
            }
        ],
        execute: function () {
            context = "";
            root = window.APP.root;
            api = window.APP.api;
            name = window.APP.name;
            // Note: Always fresh
            exports_1("cie", cie = window.APP.cie);
            exports_1("Feature", Feature = {
                emailEnabled: window.APP.emailEnabled
            });
            error = { hasError: false };
            sessionExpired = false;
            rendering = false;
            title = "";
            //
            myPublicHomePage = false;
            exports_1("initialize", initialize = (hasPublicHomePage, layout, theme) => {
                myPublicHomePage = hasPublicHomePage;
                Layout = layout;
                Theme = theme;
            });
            exports_1("requireAuthentication", requireAuthentication = () => {
                if (myPublicHomePage) {
                    if (window.location.hash.length == 0 || window.location.hash == "/#" || window.location.hash == "/#/")
                        return false;
                }
                return Auth.requireAuthentication();
            });
            myrender = (pageRender, pagePostRender) => {
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
                    (window.morphdom)(element, `<div id="app-root" class="js-fadein ${hasServerError} ${hasFatalError}">${html}</div>`, {
                        getNodeKey: function (node) { return node.id; },
                        onBeforeNodeAdded: function (node) { return node; },
                        onNodeAdded: function (node) { },
                        onBeforeElUpdated: function (fromEl, toEl) {
                            if (fromEl.matches("input[type=text]:focus"))
                                return false;
                            if (fromEl.matches("input[type=number]:focus"))
                                return false;
                            if (fromEl.matches("textarea:focus"))
                                return false;
                            if (fromEl.hasAttribute("js-skip-render-class") && fromEl.classList.contains(fromEl.getAttribute("js-skip-render-class")))
                                return false;
                            if (fromEl.hasAttribute("js-skip-render-not-class") && !fromEl.classList.contains(fromEl.getAttribute("js-skip-render-not-class")))
                                return false;
                            return true;
                        },
                        onElUpdated: function (el) { },
                        onBeforeNodeDiscarded: function (node) { return true; },
                        onNodeDiscarded: function (node) { },
                        onBeforeElChildrenUpdated: function (fromEl, toEl) { return true; }
                    });
                    pagePostRender();
                    postRender();
                    if (context == Auth.NS)
                        clearSessionExpired();
                    //
                    rendering = false;
                }
            };
            postRender = () => {
                document.title = title;
                document.body.id = context.toLowerCase().replace("_", "-");
                if (!sessionExpired)
                    clearErrors();
            };
            exports_1("render", render = () => {
                myrender(Layout.render, Layout.postRender);
            });
            exports_1("renderOnNextTick", renderOnNextTick = () => {
                setTimeout(render, 0);
            });
            exports_1("pauseRender", pauseRender = (pause = true) => {
                rendering = pause;
            });
            exports_1("setRenderDomain", setRenderDomain = (layout) => {
                Layout = layout;
            });
            exports_1("prepareRender", prepareRender = (ns = "", title = "") => {
                transitionUI();
                if (!sessionExpired)
                    clearErrors();
                if (title.length > 0)
                    setPageTitle(title);
                if (ns.length > 0)
                    setContext(ns);
            });
            exports_1("transitionUI", transitionUI = () => {
                let element = document.getElementById("app-root");
                element.classList.remove("js-fadein");
                element.classList.add("js-waiting");
            });
            exports_1("setPageTitle", setPageTitle = (newtitle) => {
                title = `${newtitle} | ${name}`;
            });
            setContext = (ns) => {
                context = ns;
            };
            exports_1("inContext", inContext = (ns) => {
                if (context == undefined)
                    return false;
                if (typeof ns === "string")
                    return (context == ns);
                else
                    return (ns.indexOf(context) != -1);
            });
            exports_1("setError", setError = (text) => {
                error.hasError = true;
                error.messages.push(text);
                return false;
            });
            exports_1("clearErrors", clearErrors = () => {
                error.hasError = false;
                error.status = 0;
                error.messages = [];
            });
            exports_1("hasError", hasError = () => {
                return (error != undefined && error.hasError);
            });
            exports_1("hasNoError", hasNoError = () => {
                return !hasError();
            });
            exports_1("warningTemplate", warningTemplate = () => {
                if (hasNoError())
                    return "";
                return Theme.warningTemplate(error.messages);
            });
            exports_1("serverError", serverError = () => {
                return (hasError() && error.status == 500);
            });
            exports_1("fatalError", fatalError = () => {
                return (hasError() && (error.status == 403 || error.status == -404));
            });
            exports_1("fatalErrorTemplate", fatalErrorTemplate = () => {
                if (hasError() && error.status == 403)
                    return Theme.fatalErrorTemplate403();
                if (hasError() && error.status == -404)
                    return Theme.fatalErrorTemplate404();
            });
            exports_1("dirtyTemplate", dirtyTemplate = (ns, details = null) => {
                return Theme.dirtyTemplate(ns, details);
            });
            exports_1("unexpectedTemplate", unexpectedTemplate = () => {
                return Theme.unexpectedTemplate();
            });
            setSessionExpired = () => {
                sessionExpired = true;
            };
            clearSessionExpired = () => {
                sessionExpired = false;
                clearErrors();
            };
            handleFetch = (response) => {
                if (!response.ok) {
                    if (response.status == 304 /*Not Modified*/) {
                        return null;
                    }
                    else if (response.status == 401 /*Unauthorized (authentication error really - requires user to signin)*/) {
                        error.hasError = true;
                        error.messages = ["Not authenticated"];
                        error.status = response.status;
                        throw error;
                    }
                    else if (response.status == 403 /*Forbidden (authorization error really)*/) {
                        error.hasError = true;
                        error.messages = ["Not authorized"];
                        error.status = response.status;
                        throw error;
                    }
                    else if (response.status != 500 /*500 is used for validation error - and it's handled later when json content is available*/) {
                        error.hasError = true;
                        error.messages = [response.statusText];
                        error.status = response.status;
                        throw error;
                    }
                }
                else {
                    if (response.status == 204 /*No Content*/) {
                        return null;
                    }
                }
                return response;
            };
            parseJson = (response) => {
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
                    };
                    if (!text)
                        return null;
                    var json = JSON.parse(text, reviver);
                    if (json.hasError /*Error returned by the api exception handler*/) {
                        error.hasError = true;
                        error.messages = [json.message];
                        error.status = 500; /*500 is used for validation error*/
                        throw error;
                    }
                    return json;
                });
            };
            catchFetch = (reason) => {
                if (reason.hasError != undefined) {
                    //All errors except network failures
                    error.hasError = reason.hasError;
                    error.messages = reason.messages;
                    error.status = reason.status;
                    if (error.status == 401 /*Unauthorized (not authenticated or expired)*/) {
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
            exports_1("apiurl", apiurl = (resource) => {
                return `${root}${api}${resource}`;
            });
            exports_1("url", url = (resource) => {
                return `${root}${resource}`;
            });
            exports_1("POST", POST = (url, body) => {
                return window.fetch(`${root}${api}${url}`, {
                    method: "post",
                    headers: { "Content-type": "application/json", "Authorization": Auth.getAuthorization() },
                    credentials: "include",
                    mode: "cors",
                    body: JSON.stringify(body)
                })
                    .then(handleFetch)
                    .then(parseJson)
                    .catch(catchFetch);
            });
            exports_1("GET", GET = (url) => {
                return window.fetch(`${root}${api}${url}`, {
                    method: "get",
                    headers: { "Authorization": Auth.getAuthorization(), "Cache-Control": "no-cache", "Pragma": "no-cache" },
                    credentials: "include",
                    mode: "cors",
                })
                    .then(handleFetch)
                    .then(parseJson)
                    .catch(catchFetch);
            });
            exports_1("PUT", PUT = (url, body) => {
                return window.fetch(`${root}${api}${url}`, {
                    method: "put",
                    headers: { "Content-type": "application/json", "Authorization": Auth.getAuthorization() },
                    credentials: "include",
                    mode: "cors",
                    body: JSON.stringify(body)
                })
                    .then(handleFetch)
                    .then(parseJson)
                    .catch(catchFetch);
            });
            exports_1("DELETE", DELETE = (url, body) => {
                return window.fetch(`${root}${api}${url}`, {
                    method: "delete",
                    headers: { "Content-type": "application/json", "Authorization": Auth.getAuthorization() },
                    credentials: "include",
                    mode: "cors",
                    body: JSON.stringify(body)
                })
                    .then(handleFetch)
                    .then(parseJson)
                    .catch(catchFetch);
            });
            exports_1("UPLOAD", UPLOAD = (url, body) => {
                return window.fetch(`${root}${api}${url}`, {
                    method: "post",
                    headers: { "Authorization": Auth.getAuthorization() },
                    credentials: "include",
                    mode: "cors",
                    body: body
                })
                    .then(handleFetch)
                    .then(parseJson)
                    .catch(catchFetch);
            });
            exports_1("DOWNLOAD", DOWNLOAD = (url) => {
                return window.fetch(`${root}${api}${url}`, {
                    method: "get",
                    headers: { "Authorization": Auth.getAuthorization() },
                    credentials: "include",
                    mode: "cors",
                })
                    .then(handleFetch)
                    .then(response => response.blob())
                    .catch(catchFetch);
            });
            exports_1("download", download = (url, name, event) => {
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
                        setTimeout(_ => { window.URL.revokeObjectURL(objectUrl); }, 1000);
                    }
                })
                    .catch(render);
                return false;
            });
            exports_1("view", view = (url, name, event) => {
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
                        setTimeout(_ => { window.URL.revokeObjectURL(objectUrl); }, 1000);
                    }
                })
                    .catch(render);
                return false;
            });
            exports_1("getPageState", getPageState = (ns, key, defaultValue) => {
                let uid = Auth.getUID();
                let id = `pages-state:${uid}`;
                let pageState = JSON.parse(localStorage.getItem(id));
                if (pageState == undefined || pageState[ns] == undefined || pageState[ns][key] == undefined)
                    return defaultValue;
                return pageState[ns][key];
            });
            exports_1("setPageState", setPageState = (ns, key, value) => {
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
            });
        }
    };
});
System.register("_BaseApp/src/core/router", [], function (exports_2, context_2) {
    "use strict";
    var reverting, resumeTo, dirtyExit, onHashChange, reload, registerDirtyExit, registerHashChanged, addRoute, goto, gotoCurrent, goBackOrResume, hashChange, router;
    var __moduleName = context_2 && context_2.id;
    return {
        setters: [],
        execute: function () {
            reverting = false;
            exports_2("reload", reload = () => {
                dirtyExit = null;
                location.reload(true);
            });
            exports_2("registerDirtyExit", registerDirtyExit = (dirtyExitFunction) => {
                dirtyExit = dirtyExitFunction;
            });
            exports_2("registerHashChanged", registerHashChanged = (hashChangeFunction) => {
                onHashChange = hashChangeFunction;
            });
            exports_2("addRoute", addRoute = (url, callback) => {
                router.push({ url, callback });
            });
            exports_2("goto", goto = (url, delay = 0, thenReload = false) => {
                dirtyExit = null;
                if (delay == 0) {
                    if (url == "" || url == "/")
                        url = "#/";
                    if (window.location.hash != url)
                        document.location = url;
                    else
                        hashChange();
                    if (thenReload)
                        reload();
                }
                else {
                    setTimeout(() => { goto(url, 0, thenReload); }, delay);
                }
            });
            exports_2("gotoCurrent", gotoCurrent = (delay = 0) => {
                if (delay == 0)
                    hashChange();
                else
                    setTimeout(() => { gotoCurrent(0); }, delay);
            });
            exports_2("goBackOrResume", goBackOrResume = (isDirty) => {
                if (isDirty)
                    goto(resumeTo);
                else
                    history.back();
            });
            hashChange = () => {
                let hash = window.location.hash;
                if (hash.length == 0)
                    hash = "#/";
                const route = router.filter(one => hash.match(new RegExp(one.url)))[0];
                if (route) {
                    if (!reverting) {
                        if (dirtyExit != undefined) {
                            let warning = dirtyExit();
                            if (warning != undefined && warning) {
                                reverting = true;
                                resumeTo = hash;
                                history.back();
                                return;
                            }
                        }
                        if (onHashChange)
                            onHashChange(hash);
                        if (route.callback) {
                            let parameters = new RegExp(route.url).exec(hash);
                            if (parameters.length < 2 || parameters[1] == undefined)
                                route.callback([]);
                            else
                                route.callback(parameters[1].split("/"));
                        }
                    }
                    reverting = false;
                }
            };
            router = [];
            window.addEventListener('hashchange', hashChange);
            window.addEventListener('DOMContentLoaded', hashChange);
        }
    };
});
System.register("_BaseApp/src/lib-ts/misc", [], function (exports_3, context_3) {
    "use strict";
    var ESC_MAP, tolerance, escapeHTML, keepAttr, keepClass, clone, same, changes, toInputText, fromInputText, fromInputTextNullable, toInputNumber, fromInputNumber, fromInputNumberNullable, toInputDate, fromInputDate, fromInputDateNullable, fromInputTime, fromInputTimeComboNullable, fromInputTimeNullable, toInputCheckbox, fromInputCheckbox, fromInputCheckboxMask, toStaticText, toStaticTextNA, toStaticNumber, toStaticNumberNA, toStaticNumberDecimal, toStaticMoney, toStaticDateTime, toStaticDateTimeNA, toStaticDate, toStaticDateNA, toStaticCheckbox, toStaticCheckboxYesNo, filesizeText, fromSelectNumber, fromSelectText, fromSelectBoolean, fromRadioNumber, fromRadioString, fromAutocompleteNumber, fromAutocompleteText, toastSuccess, toastSuccessSave, toastSuccessUpload, toastFailure, blameText, toInputTimeHHMM, toInputTimeHHMMSS, toInputDateTime_2rows, toInputDateTime_hhmm_2rows, toInputDateTime_hhmm, toInputDateTime_hhmmssNA, toInputDateTime_hhmm24, formatYYYYMMDD, formatYYYYMMDDHHMM, formatMMDDYYYY, parseYYYYMMDD, parseYYYYMMDD_number, dateOnly, previousDate, nextDate, formatDuration, isDateInstance, isValidDateString, isValidTimeString, formatLatLong, toInputLatLong, toInputLatLongDDMMCC, fromInputLatLong, fromInputLatLongNullable, getLatLongFullPrecision, createWhite, createBlack;
    var __moduleName = context_3 && context_3.id;
    return {
        setters: [],
        execute: function () {
            ESC_MAP = {
                "&": "&amp;",
                "<": "&lt;",
                ">": "&gt;",
                '"': "&quot;",
                "'": "&#39;"
            };
            tolerance = 0.00012; //for lat/lng fields
            exports_3("escapeHTML", escapeHTML = (text, forAttribute = true) => {
                return text.replace((forAttribute ? /[&<>'"]/g : /[&<>]/g), function (c) { return ESC_MAP[c]; });
            });
            exports_3("keepAttr", keepAttr = (id, bsAttr) => {
                let element = document.getElementById(id);
                if (element == undefined)
                    return `id="${id}"`;
                return `id="${id}" ${bsAttr}="${element.getAttribute(bsAttr)}"`;
            });
            exports_3("keepClass", keepClass = (id, myClass, bsClass) => {
                let element = document.getElementById(id);
                if (element == undefined)
                    return `id="${id}" class="${myClass}"`;
                let exist = element.classList.contains(bsClass);
                return `id="${id}" class="${myClass} ${exist ? bsClass : ""}"`;
            });
            exports_3("clone", clone = (state) => {
                let cloned = {};
                Object.keys(state).forEach(key => {
                    if (state.hasOwnProperty(key)) {
                        if (state[key] == null) {
                            cloned[key] = null;
                        }
                        else if (typeof state[key].getTime === "function") {
                            cloned[key] = new Date(state[key].getTime());
                        }
                        else if (Array.isArray(state[key])) {
                            cloned[key] = [];
                            state[key].forEach(one => cloned[key].push(clone(one)));
                        }
                        else if (typeof state[key] == "object") {
                            cloned[key] = clone(state[key]);
                        }
                        else {
                            cloned[key] = state[key];
                        }
                    }
                });
                return cloned;
            });
            exports_3("same", same = (state1, state2) => {
                let isSame = true;
                Object.keys(state1).forEach(key => {
                    if (isSame && state1.hasOwnProperty(key) && key.charAt(0) != "_") {
                        let value1 = state1[key];
                        let value2 = state2[key];
                        let isPrimitiveType = false;
                        //console.log(`key=${key} value1=${value1}, value2=${value2}`)
                        if (value1 != undefined) {
                            if (typeof value1.getTime === "function") {
                                value1 = value1.getTime();
                                isPrimitiveType = true;
                            }
                            else if (Array.isArray(value1)) {
                                for (let ix = 0; ix < value1.length; ix++) {
                                    isSame = isSame && value2 && same(value1[ix], value2[ix]);
                                    if (!isSame)
                                        return false;
                                }
                            }
                            else if (typeof value1 === "object") {
                                isSame = isSame && value2 && same(value1, value2);
                            }
                            else {
                                isPrimitiveType = true;
                            }
                        }
                        if (value2 != undefined) {
                            if (typeof value2.getTime === "function") {
                                value2 = value2.getTime();
                                isPrimitiveType = true;
                            }
                            else if (Array.isArray(value2)) {
                                for (let ix = 0; ix < value2.length; ix++) {
                                    isSame = isSame && value1 && same(value2[ix], value1[ix]);
                                    if (!isSame)
                                        return false;
                                }
                            }
                            else if (typeof value2 === "object") {
                                isSame = isSame && value1 && same(value2, value1);
                            }
                            else {
                                isPrimitiveType = true;
                            }
                        }
                        if (isPrimitiveType) {
                            if (key == "lat" || key == "lng") {
                                if (Math.abs(value1 - value2) > tolerance)
                                    isSame = false;
                            }
                            else if (value1 !== value2) {
                                //console.log(`*****NOT SAME ${key}`)
                                isSame = false;
                            }
                        }
                        if (!isSame)
                            return false;
                    }
                });
                return isSame;
            });
            exports_3("changes", changes = (state1, state2) => {
                let names = [];
                Object.keys(state1).forEach(key => {
                    if (key != "xtra" && key != "perm") {
                        let value1 = state1[key];
                        let value2 = state2[key];
                        if (value1 != null && typeof value1.getTime === "function")
                            value1 = value1.getTime();
                        if (value2 != null && typeof value2.getTime === "function")
                            value2 = value2.getTime();
                        if (value1 !== value2) {
                            let wrong = true;
                            if ((key == "lat" || key == "lng") && Math.abs(value1 - value2) < tolerance)
                                wrong = false;
                            if (wrong) {
                                let translated = i18n(key.toUpperCase());
                                names.push(translated);
                                console.log(`${key}[${translated}] BEFORE=${state1[key]}, AFTER=${state2[key]}`);
                            }
                        }
                    }
                });
                if (names.length == 0)
                    return null;
                return `Fields: [${names.join(", ")}]`;
            });
            exports_3("toInputText", toInputText = (value) => {
                return (value == undefined ? "" : escapeHTML(value.toString()));
            });
            exports_3("fromInputText", fromInputText = (id, defValue = null) => {
                let element = document.getElementById(id);
                return (element == undefined ? defValue : element.value);
            });
            exports_3("fromInputTextNullable", fromInputTextNullable = (id, defValue = null) => {
                let element = document.getElementById(id);
                return (element == undefined ? defValue : element.value == "" ? null : element.value);
            });
            exports_3("toInputNumber", toInputNumber = (value) => {
                return (value == undefined ? "" : value.toString());
            });
            exports_3("fromInputNumber", fromInputNumber = (id, defValue = null) => {
                let element = document.getElementById(id);
                return (element == undefined ? defValue : +element.value);
            });
            exports_3("fromInputNumberNullable", fromInputNumberNullable = (id, defValue = null) => {
                let element = document.getElementById(id);
                return (element == undefined ? defValue : element.value == "" ? null : +element.value);
            });
            exports_3("toInputDate", toInputDate = (value) => {
                if (value == undefined || value.toString().toLowerCase() == "invalid date")
                    return "";
                return moment(value).format("YYYY-MM-DD");
            });
            exports_3("fromInputDate", fromInputDate = (id, defValue = null) => {
                let element = document.getElementById(id);
                if (element == undefined)
                    return defValue;
                var parts = element.value.split("-");
                if (defValue == null)
                    return new Date(+parts[0], +parts[1] - 1, +parts[2], 0, 0, 0, 0);
                try {
                    let date = new Date(defValue.getTime());
                    date.setFullYear(+parts[0], +parts[1] - 1, +parts[2]);
                    return date;
                }
                catch (error) {
                    return null;
                }
            });
            exports_3("fromInputDateNullable", fromInputDateNullable = (id, defValue = null) => {
                let element = document.getElementById(id);
                if (element == undefined)
                    return defValue;
                if (element.value == "")
                    return null;
                var parts = element.value.split("-");
                if (defValue == null)
                    return new Date(+parts[0], +parts[1] - 1, +parts[2], 0, 0, 0, 0);
                try {
                    let date = new Date(defValue.getTime());
                    date.setFullYear(+parts[0], +parts[1] - 1, +parts[2]);
                    return date;
                }
                catch (error) {
                    return null;
                }
            });
            exports_3("fromInputTime", fromInputTime = (id, defValue = null) => {
                let element = document.getElementById(id);
                if (element == undefined)
                    return defValue;
                var parts = element.value.split(":");
                if (defValue == null) {
                    let date = new Date();
                    date.setHours(+parts[0]);
                    date.setMinutes(+parts[1]);
                    return date;
                }
                try {
                    let date = new Date(defValue.getTime());
                    date.setHours(+parts[0]);
                    date.setMinutes(+parts[1]);
                    return date;
                }
                catch (error) {
                    return null;
                }
            });
            exports_3("fromInputTimeComboNullable", fromInputTimeComboNullable = (id, defValue = null) => {
                if (defValue == null)
                    return null;
                return fromInputTimeNullable(id, defValue);
            });
            exports_3("fromInputTimeNullable", fromInputTimeNullable = (id, defValue = null) => {
                let element = document.getElementById(id);
                if (element == undefined)
                    return defValue;
                if (element.value == "")
                    return defValue;
                var parts = element.value.split(":");
                if (defValue == null) {
                    let date = new Date();
                    date.setHours(+parts[0]);
                    date.setMinutes(+parts[1]);
                    return date;
                }
                try {
                    let date = new Date(defValue.getTime());
                    date.setHours(+parts[0]);
                    date.setMinutes(+parts[1]);
                    return date;
                }
                catch (error) {
                    return null;
                }
            });
            exports_3("toInputCheckbox", toInputCheckbox = (value) => {
                return value.toString();
            });
            exports_3("fromInputCheckbox", fromInputCheckbox = (id, defValue = null) => {
                let element = document.getElementById(id);
                return (element == undefined ? defValue : element.checked);
            });
            exports_3("fromInputCheckboxMask", fromInputCheckboxMask = (name, defValue = null) => {
                let elements = document.getElementsByName(name);
                if (elements == undefined || elements.length == 0)
                    return defValue;
                let value = 0;
                for (let ix = 0; ix < elements.length; ix++) {
                    let element = elements[ix];
                    value += (element.checked ? +element.dataset.mask : 0);
                }
                return value;
            });
            exports_3("toStaticText", toStaticText = (value) => {
                return (value == undefined ? "" : value);
            });
            exports_3("toStaticTextNA", toStaticTextNA = (value) => {
                return (value == undefined ? "n/a" : value.replace(/\n/g, "<br>"));
            });
            exports_3("toStaticNumber", toStaticNumber = (value) => {
                return (value == undefined ? "" : value.toString());
            });
            exports_3("toStaticNumberNA", toStaticNumberNA = (value) => {
                return (value == undefined ? "n/a" : value.toString());
            });
            exports_3("toStaticNumberDecimal", toStaticNumberDecimal = (value, places, forced = false) => {
                if (value == undefined)
                    return "";
                let scale = Math.pow(10, places);
                if (forced)
                    return (Math.fround(value * scale) / scale).toFixed(places);
                else
                    return (Math.fround(value * scale) / scale).toString();
            });
            exports_3("toStaticMoney", toStaticMoney = (value) => {
                return "$" + (value !== null && value !== void 0 ? value : 0).toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
            });
            exports_3("toStaticDateTime", toStaticDateTime = (value) => {
                return (value != undefined ? moment(value).format("LLL") : "");
            });
            exports_3("toStaticDateTimeNA", toStaticDateTimeNA = (value) => {
                return (value != undefined ? moment(value).format("LLL") : "n/a");
            });
            exports_3("toStaticDate", toStaticDate = (value) => {
                return (value != undefined ? moment(value).format("LL") : "");
            });
            exports_3("toStaticDateNA", toStaticDateNA = (value) => {
                return (value != undefined ? moment(value).format("LL") : "n/a");
            });
            exports_3("toStaticCheckbox", toStaticCheckbox = (value) => {
                //return (value ? "<i class='far fa-check-square js-static-checkbox'></i>" : "<i class='far fa-square js-static-checkbox'></i>");
                return (value ? '<i class="fal fa-check-square"></i>' : '<span style="opacity: 0.25"><i class="fal fa-square"></i></span>');
            });
            exports_3("toStaticCheckboxYesNo", toStaticCheckboxYesNo = (value) => {
                return (value == undefined ? "n/a" : value ? i18n("YES") : i18n("NO"));
            });
            exports_3("filesizeText", filesizeText = (filesize) => {
                if (filesize == 0)
                    return "n/a";
                var i = -1;
                var byteUnits = [' kB', ' MB', ' GB', ' TB', 'PB', 'EB', 'ZB', 'YB'];
                do {
                    filesize = filesize / 1024;
                    i++;
                } while (filesize > 1024);
                return Math.max(filesize, 0.1).toFixed(1) + byteUnits[i];
            });
            exports_3("fromSelectNumber", fromSelectNumber = (id, defValue = null) => {
                let select = document.getElementById(id);
                if (select == undefined || select.selectedIndex == -1)
                    return defValue;
                let value = select.options[select.selectedIndex].value;
                return (value.length > 0 ? +value : null);
            });
            exports_3("fromSelectText", fromSelectText = (id, defValue = null) => {
                let select = document.getElementById(id);
                if (select == undefined || select.selectedIndex == -1)
                    return defValue;
                let value = select.options[select.selectedIndex].value;
                return (value.length > 0 ? value : null);
            });
            exports_3("fromSelectBoolean", fromSelectBoolean = (id, defValue = null) => {
                let select = document.getElementById(id);
                if (select == undefined || select.selectedIndex == -1)
                    return defValue;
                let value = select.options[select.selectedIndex].value;
                return (value.length > 0 ? (value == "true") : null);
            });
            exports_3("fromRadioNumber", fromRadioNumber = (id, defValue = null) => {
                let radios = document.getElementsByName(id);
                if (radios == undefined || radios.length == 0)
                    return defValue;
                for (let ix = 0; ix < radios.length; ix++) {
                    let radio = radios[ix];
                    if (radio.checked) {
                        let value = radio.dataset.value;
                        return (value.length > 0 ? +value : null);
                    }
                }
            });
            exports_3("fromRadioString", fromRadioString = (id, defValue = null) => {
                let radios = document.getElementsByName(id);
                if (radios == undefined || radios.length == 0)
                    return defValue;
                for (let ix = 0; ix < radios.length; ix++) {
                    let radio = radios[ix];
                    if (radio.checked) {
                        let value = radio.dataset.value;
                        return (value.length > 0 ? value : null);
                    }
                }
            });
            exports_3("fromAutocompleteNumber", fromAutocompleteNumber = (id, defValue = null) => {
                let input = document.getElementById(id);
                if (input == undefined)
                    return defValue;
                let key = input.dataset["key"];
                if (key === "undefined")
                    return defValue;
                if (key.length == 0)
                    return null;
                return +key;
            });
            exports_3("fromAutocompleteText", fromAutocompleteText = (id, defValue = null) => {
                let input = document.getElementById(id);
                if (input == undefined)
                    return defValue;
                let key = input.dataset["key"];
                if (key === "undefined")
                    return defValue;
                if (key.length == 0)
                    return null;
                return key;
            });
            exports_3("toastSuccess", toastSuccess = (text) => {
                let div = document.createElement("div");
                div.classList.add("js-toast");
                div.style.display = "none";
                document.body.appendChild(div);
                let style = getComputedStyle(div);
                let bgcolor = style.backgroundColor;
                div.parentNode.removeChild(div);
                Toastify({
                    text: text,
                    className: "js-toast",
                    backgroundColor: bgcolor,
                    position: "left",
                }).showToast();
            });
            exports_3("toastSuccessSave", toastSuccessSave = () => {
                toastSuccess(i18n("Data was saved successfully"));
            });
            exports_3("toastSuccessUpload", toastSuccessUpload = () => {
                toastSuccess(i18n("File was uploaded successfully"));
            });
            exports_3("toastFailure", toastFailure = (text = "Your last action failed to execute", duration = 15000) => {
                let div = document.createElement("div");
                div.classList.add("js-toast-bad");
                div.style.display = "none";
                document.body.appendChild(div);
                let style = getComputedStyle(div);
                let bgcolor = style.backgroundColor;
                div.parentNode.removeChild(div);
                Toastify({
                    text: `<i class="far fa-frown" style="opacity:0.5"></i>&nbsp;${text}`,
                    className: "js-toast-bad",
                    backgroundColor: bgcolor,
                    position: "center",
                    gravity: "top",
                    duration: duration,
                    close: true
                }).showToast();
            });
            exports_3("blameText", blameText = (obj) => {
                return `Last updated on ${toStaticDateTime(obj.updatedUtc)} by ${obj.by}`;
            });
            exports_3("toInputTimeHHMM", toInputTimeHHMM = (date) => {
                if (date == undefined)
                    return "";
                var hours = date.getHours();
                var minutes = date.getMinutes();
                return `${hours < 10 ? "0" + hours : hours}:${minutes < 10 ? "0" + minutes : minutes}`;
            });
            exports_3("toInputTimeHHMMSS", toInputTimeHHMMSS = (date) => {
                if (date == undefined)
                    return "";
                var hours = date.getHours();
                var minutes = date.getMinutes();
                let secs = date.getSeconds();
                return `${hours < 10 ? "0" + hours : hours}:${minutes < 10 ? "0" + minutes : minutes}:${secs < 10 ? "0" + secs : secs}`;
            });
            exports_3("toInputDateTime_2rows", toInputDateTime_2rows = (date) => {
                var hours = date.getHours();
                var minutes = date.getMinutes();
                let secs = date.getSeconds();
                var ampm = (hours < 12 ? "AM" : "PM");
                hours = hours % 12;
                hours = (hours ? hours : 12);
                let time = `${hours < 10 ? "0" + hours : hours}:${minutes < 10 ? "0" + minutes : minutes}:${secs < 10 ? "0" + secs : secs} ${ampm}`;
                return `${toInputDate(date)}<br/>${time}`;
            });
            exports_3("toInputDateTime_hhmm_2rows", toInputDateTime_hhmm_2rows = (date) => {
                var hours = date.getHours();
                var minutes = date.getMinutes();
                var ampm = (hours < 12 ? "AM" : "PM");
                hours = hours % 12;
                hours = (hours ? hours : 12);
                let time = `${hours < 10 ? "0" + hours : hours}:${minutes < 10 ? "0" + minutes : minutes} ${ampm}`;
                return `${toInputDate(date)}<br/>${time}`;
            });
            exports_3("toInputDateTime_hhmm", toInputDateTime_hhmm = (date) => {
                if (date == undefined)
                    return "";
                return toInputDateTime_hhmm_2rows(date).replace("<br/>", "&nbsp;");
            });
            exports_3("toInputDateTime_hhmmssNA", toInputDateTime_hhmmssNA = (date) => {
                if (date == undefined)
                    return "n/a";
                var hours = date.getHours();
                var minutes = date.getMinutes();
                var seconds = date.getSeconds();
                var ampm = (hours < 12 ? "AM" : "PM");
                hours = hours % 12;
                hours = (hours ? hours : 12);
                let time = `${hours < 10 ? "0" + hours : hours}:${minutes < 10 ? "0" + minutes : minutes}:${seconds < 10 ? "0" + seconds : seconds} ${ampm}`;
                return `${toInputDate(date)}&nbsp;${time}`;
            });
            exports_3("toInputDateTime_hhmm24", toInputDateTime_hhmm24 = (date) => {
                if (date == undefined)
                    return "";
                var hours = date.getHours();
                var minutes = date.getMinutes();
                let time = `${hours < 10 ? "0" + hours : hours}:${minutes < 10 ? "0" + minutes : minutes}`;
                return `${toInputDate(date)} ${time}`;
            });
            exports_3("formatYYYYMMDD", formatYYYYMMDD = (date, separator = "/") => {
                let month = "" + (date.getMonth() + 1);
                let day = "" + date.getDate();
                let year = date.getFullYear();
                if (month.length < 2)
                    month = "0" + month;
                if (day.length < 2)
                    day = "0" + day;
                return [year, month, day].join(separator);
            });
            exports_3("formatYYYYMMDDHHMM", formatYYYYMMDDHHMM = (date) => {
                let year = date.getFullYear();
                let month = "" + (date.getMonth() + 1);
                let day = "" + date.getDate();
                let hour = "" + date.getHours();
                let minute = "" + date.getMinutes();
                if (month.length < 2)
                    month = "0" + month;
                if (day.length < 2)
                    day = "0" + day;
                if (hour.length < 2)
                    hour = "0" + hour;
                if (minute.length < 2)
                    minute = "0" + minute;
                return [year, month, day, hour, minute].join("");
            });
            exports_3("formatMMDDYYYY", formatMMDDYYYY = (date, separator = "/") => {
                let month = "" + (date.getMonth() + 1);
                let day = "" + date.getDate();
                let year = date.getFullYear();
                if (month.length < 2)
                    month = "0" + month;
                if (day.length < 2)
                    day = "0" + day;
                return [month, day, year].join(separator);
            });
            exports_3("parseYYYYMMDD", parseYYYYMMDD = (text) => {
                return new Date(text);
            });
            exports_3("parseYYYYMMDD_number", parseYYYYMMDD_number = (dateNumber) => {
                let yy = Math.floor(dateNumber / 10000);
                let mm = Math.floor((dateNumber - 10000 * yy) / 100) - 1;
                let dd = dateNumber % 100;
                return new Date(yy, mm, dd, 0, 0, 0, 0);
            });
            exports_3("dateOnly", dateOnly = (date) => {
                return new Date(formatYYYYMMDD(date));
            });
            exports_3("previousDate", previousDate = (date) => {
                var newDate = new Date(date);
                newDate.setDate(newDate.getDate() - 1);
                return newDate;
            });
            exports_3("nextDate", nextDate = (date) => {
                var newDate = new Date(date);
                newDate.setDate(newDate.getDate() + 1);
                return newDate;
            });
            exports_3("formatDuration", formatDuration = (startTime, endTime) => {
                let diff = Math.floor((endTime.getTime() - startTime.getTime()) / 1000);
                let sec = diff % 60;
                let min = Math.floor(diff / 60);
                if (min == 0)
                    return `${sec} sec`;
                min = min % 60;
                let hour = Math.floor(diff / (60 * 60));
                if (hour == 0)
                    return `${min}m ${sec}s`;
                return `${hour}h ${min}m ${sec}s`;
            });
            exports_3("isDateInstance", isDateInstance = (d) => {
                return !isNaN(d) && d instanceof Date;
            });
            exports_3("isValidDateString", isValidDateString = (dateString) => {
                if (!dateString.match(/^\d{4}-\d{2}-\d{2}$/))
                    return false;
                var date = new Date(dateString);
                var time = date.getTime();
                if (!time && time != 0)
                    return false;
                return date.toISOString().slice(0, 10) == dateString;
            });
            exports_3("isValidTimeString", isValidTimeString = (timeString) => {
                let regs = timeString.match(/^(\d{1,2}):(\d{2})([ap]m)?$/);
                if (!regs)
                    return false;
                return (!(+regs[1] > 23 || +regs[2] > 59));
            });
            exports_3("formatLatLong", formatLatLong = (latlon) => {
                if (latlon == undefined)
                    return "";
                let deg = Math.trunc(latlon);
                let min = Math.trunc(60 * (latlon - deg));
                let sec = Math.round(60 * 60 * (latlon - (deg + min / 60)));
                if (sec == 60) {
                    sec = 0;
                    min++;
                }
                if (min == 60) {
                    min = 0;
                    deg++;
                }
                return `${deg < 10 ? "0" + deg : deg}°&nbsp;${min < 10 ? "0" + min : min}′&nbsp;${sec < 10 ? "0" + sec : sec}″`;
            });
            exports_3("toInputLatLong", toInputLatLong = (latlon) => {
                if (latlon == undefined)
                    return "";
                let deg = Math.trunc(latlon);
                let min = Math.trunc(60 * (latlon - deg));
                let sec = Math.round(60 * 60 * (latlon - (deg + min / 60)));
                if (sec == 60) {
                    sec = 0;
                    min++;
                }
                if (min == 60) {
                    min = 0;
                    deg++;
                }
                return `${deg < 10 ? "0" + deg : deg}° ${min < 10 ? "0" + min : min}′ ${sec < 10 ? "0" + sec : sec}″`;
            });
            exports_3("toInputLatLongDDMMCC", toInputLatLongDDMMCC = (latlon) => {
                if (latlon == undefined)
                    return "";
                let deg = Math.trunc(latlon);
                let min = 60 * (latlon - deg);
                if (min == 60) {
                    min = 0;
                    deg++;
                }
                return `${deg < 10 ? "0" + deg : deg}° ${min < 10 ? "0" + min.toFixed(2) : min.toFixed(2)}′`;
            });
            exports_3("fromInputLatLong", fromInputLatLong = (id, defValue = null) => {
                let element = document.getElementById(id);
                if (element == undefined)
                    return defValue;
                if (element.dataset.isddmmcc == "true") {
                    let text = element.value.replace("°", "").replace("′", "");
                    let dmc = text.split(" ");
                    if (dmc.length != 2)
                        return defValue;
                    let deg = +dmc[0];
                    if (isNaN(deg))
                        return defValue;
                    let min = +dmc[1];
                    if (isNaN(min) || min > 59)
                        return defValue;
                    return deg + min / 60;
                }
                else {
                    let text = element.value.replace("°", "").replace("′", "").replace("″", "");
                    let dms = text.split(" ");
                    if (dms.length != 3)
                        return defValue;
                    let deg = +dms[0];
                    if (isNaN(deg))
                        return defValue;
                    let min = +dms[1];
                    if (isNaN(min) || min > 59)
                        return defValue;
                    let sec = +dms[2];
                    if (isNaN(sec) || sec > 59)
                        return defValue;
                    return deg + min / 60 + sec / 3600;
                }
            });
            exports_3("fromInputLatLongNullable", fromInputLatLongNullable = (id, defValue = null) => {
                let element = document.getElementById(id);
                if (element == undefined)
                    return defValue;
                if (element.value == "")
                    return null;
                return fromInputLatLong(id, defValue);
            });
            exports_3("getLatLongFullPrecision", getLatLongFullPrecision = (latlon) => {
                if (latlon == undefined)
                    return latlon;
                // I used to recompute the value from its DDMMSS representation to make sure it wouldn't be considered dirty when exiting a page.
                // It's not necessary anymore because I'm using a tolerance when comparing before and after lat/lng values.
                // This change in methodology became necessary when adding support for DDMMCC.
                return latlon;
            });
            exports_3("createWhite", createWhite = (formState, props) => {
                return props.reduce((acc, key) => { {
                    acc[key] = formState[key];
                    return acc;
                } ; }, {});
            });
            exports_3("createBlack", createBlack = (formState, props) => {
                var cloned = clone(formState);
                props.forEach(prop => delete cloned[prop]);
                return cloned;
            });
        }
    };
});
System.register("_BaseApp/src/lib-ts/domlib", [], function (exports_4, context_4) {
    "use strict";
    var closest, closestByClassName, live, setCookie, getCookie, duplicateEntity, getElementPosition;
    var __moduleName = context_4 && context_4.id;
    return {
        setters: [],
        execute: function () {
            exports_4("closest", closest = function (element, tagName) {
                let el = element;
                let tagname = tagName.toLowerCase();
                if (el.tagName && el.tagName.toLowerCase() == tagname)
                    return el;
                while (el && el.parentElement) {
                    el = el.parentElement;
                    if (el.tagName && el.tagName.toLowerCase() == tagname) {
                        return el;
                    }
                }
                return null;
            });
            exports_4("closestByClassName", closestByClassName = function (element, className) {
                let el = element;
                if (el.classList.contains(className))
                    return el;
                while (el && el.parentElement) {
                    el = el.parentElement;
                    if (el.classList.contains(className)) {
                        return el;
                    }
                }
                return null;
            });
            exports_4("live", live = (eventType, className, callback) => {
                document.addEventListener(eventType, function (event) {
                    var el = event.target;
                    var found = false;
                    while (el) {
                        found = (el.classList && el.classList.contains(className));
                        if (found)
                            break;
                        el = el.parentElement;
                    }
                    if (found)
                        callback.call(el, event);
                });
            });
            exports_4("setCookie", setCookie = function (cname, cvalue, exdays = 0) {
                if (exdays > 0) {
                    var d = new Date();
                    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
                    document.cookie = cname + "=" + cvalue + ";expires=" + d.toUTCString() + ";path=/";
                }
                else {
                    document.cookie = cname + "=" + cvalue + ";path=/";
                }
            });
            exports_4("getCookie", getCookie = function (cname) {
                var name = cname + "=";
                var ca = document.cookie.split(";");
                for (var i = 0; i < ca.length; i++) {
                    var c = ca[i];
                    while (c.charAt(0) == " ") {
                        c = c.substring(1);
                    }
                    if (c.indexOf(name) == 0) {
                        return c.substring(name.length, c.length);
                    }
                }
                return "";
            });
            exports_4("duplicateEntity", duplicateEntity = function (targetElement) {
                let newElement = document.createElement(targetElement.tagName);
                for (let i = 0; i < targetElement.attributes.length; i++) {
                    let attr = targetElement.attributes[i];
                    newElement.setAttribute(attr.name, attr.value);
                }
                return newElement;
            });
            exports_4("getElementPosition", getElementPosition = (el) => {
                var xPos = 0;
                var yPos = 0;
                while (el) {
                    if (el.tagName == "BODY") {
                        var xScroll = el.scrollLeft || document.documentElement.scrollLeft;
                        var yScroll = el.scrollTop || document.documentElement.scrollTop;
                        xPos += (el.offsetLeft - xScroll + el.clientLeft);
                        yPos += (el.offsetTop - yScroll + el.clientTop);
                    }
                    else {
                        xPos += (el.offsetLeft - el.scrollLeft + el.clientLeft);
                        yPos += (el.offsetTop - el.scrollTop + el.clientTop);
                    }
                    el = el.offsetParent;
                }
                return {
                    x: xPos,
                    y: yPos
                };
            });
        }
    };
});
System.register("_BaseApp/src/auth", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc"], function (exports_5, context_5) {
    "use strict";
    var App, Router, Misc, NS, loginData, state, returnUrl, storage, steps, currentStep, formTemplate, formForgottenTemplate, formRemindedTemplate, formNewPasswordTemplate, pageTemplate, fetch, fetchInvitation, fetchReset, render, postRender, getFormState, valid, html5Valid, ensurePasswordMatch, ensureComplexityRequirement, signin, signout, forgotPassword, setCurrentStep, getAuthorization, getEmail, getName, getUID, getCie, getCurrentYear, getPermissions, hasPerm, getRoles, hasRole, getUserCaps, requireAuthentication, isAuthenticated, redirectToSignin, refreshLoginData, createLoginData, b64DecodeUnicode, persistLoginData, restoreLoginData, destroyLoginData, hasLoginData;
    var __moduleName = context_5 && context_5.id;
    return {
        setters: [
            function (App_1) {
                App = App_1;
            },
            function (Router_1) {
                Router = Router_1;
            },
            function (Misc_1) {
                Misc = Misc_1;
            }
        ],
        execute: function () {
            exports_5("NS", NS = "App_Auth");
            loginData = {};
            state = {};
            returnUrl = "/";
            (function (steps) {
                steps[steps["normal"] = 0] = "normal";
                steps[steps["forgotten"] = 1] = "forgotten";
                steps[steps["reminded"] = 2] = "reminded";
                steps[steps["invited"] = 3] = "invited";
                steps[steps["resetted"] = 4] = "resetted";
            })(steps || (steps = {}));
            currentStep = steps.normal;
            formTemplate = (item) => {
                var _a;
                let enablePasswordChange = (_a = window.APP.portalbag.feature.enableEmail) !== null && _a !== void 0 ? _a : false;
                return `
<form onsubmit="App_Auth.signin(); return false;">
<input type="submit" style="display:none;" id="App_Auth_dummy_submit">
    <div class="has-text-centered js-help">
        <h2>
            ${i18n("Sign in to start your session")}
        </h2>
    </div>
    <div class="field">
        <div class="control has-icons-left">
            <input type="email" class="input" id="App_Auth_email" placeholder="${i18n("EMAIL")}" value="${Misc.toInputText(item.email)}" required>
            <span class="icon is-small is-left">
                <i class="fas fa-envelope"></i>
            </span>
        </div>
    </div>
    <div class="field">
        <div class="control has-icons-left">
            <input type="password" class="input" id="App_Auth_password" placeholder="${i18n("PASSWORD")}" required>
            <span class="icon is-small is-left">
                <i class="fas fa-lock"></i>
            </span>
        </div>
    </div>
    <button type="submit" class="button is-block is-primary is-fullwidth">
        <i class="fas fa-sign-in-alt"></i>&nbsp;${i18n("Sign In")}
    </button>
${enablePasswordChange ? `
    <div class="has-text-right js-submenu">
        <button type="button" class="button is-text is-italic is-white" onclick="App_Auth.setCurrentStep(${steps.forgotten})">
            ${i18n("I need a new password!")}
        </button>
    </div>
` : ``}
</form>
`;
            };
            formForgottenTemplate = (item) => {
                return `
<form onsubmit="App_Auth.forgotPassword(); return false;">
<input type="submit" style="display:none;" id="App_Auth_dummy_submit">
    <div class="has-text-centered js-help">
        <h2>
            ${i18n("Let's fix that!")}
        </h2>
        <div class="content">
            <p>
                ${i18n("Enter your email address below. You will receive an email with a link to allow you to enter a new password")}
            </p>
            <p>
                ${i18n("The email link will expire in one week")}
            </p>
        </div>
    </div>
    <div class="field">
        <div class="control has-icons-left">
            <input type="email" class="input" id="App_Auth_email" placeholder="${i18n("EMAIL")}" value="${Misc.toInputText(item.email)}" required>
            <span class="icon is-small is-left">
                <i class="fas fa-lock"></i>
            </span>
        </div>
    </div>
    <button type="submit" class="button is-block is-primary is-fullwidth">
        <i class="fas fa-envelope"></i>&nbsp;${i18n("Send Email")}
    </button>
    <div class="has-text-left js-submenu">
        <button type="button" class="button is-text is-italic is-white" onclick="App_Auth.setCurrentStep(${steps.normal})">
            ${i18n("Cancel that, I remember my password now!")}
        </button>
    </div>
</form>
`;
            };
            formRemindedTemplate = (item) => {
                return `
<form onsubmit="App_Auth.forgotPassword(); return false;">
<input type="submit" style="display:none;" id="App_Auth_dummy_submit">
    <div class="has-text-centered js-help">
        <div class="section">
            <p class="has-text-success">
                <span class="fa-stack fa-2x">
                    <i class="far fa-circle fa-stack-2x"></i>
                    <i class="fa fa-check fa-stack-1x"></i>
                </span>
            </p>
        </div>
        <h2>
            ${i18n("Password reset email sent")}
        </h2>
        <div class="content">
            <p>
                ${i18n("An email has been sent to")} <b>${item.email}</b>
            </p>
            <p>
                ${i18n("Check out the spam folder if you don't see the email in your inbox within 5 minutes")}
            </p>
        </div>
        <button type="button" class="button is-text is-white" onclick="App_Auth.setCurrentStep(${steps.normal})">${i18n("Done")}</a>
    </div>
</form>
`;
            };
            formNewPasswordTemplate = (item, step) => {
                return `
<form onsubmit="App_Auth.signin(${step}); return false;">
<input type="submit" style="display:none;" id="App_Auth_dummy_submit">
    <div class="has-text-centered js-help">
        <h2>
            ${i18n("Now, let's set your password")}
        </h2>
        <div class="content">
            <p>
                ${i18n("You need to enter your password twice below")}
            </p>
        </div>
    </div>
    <div class="field">
        <div class="control has-icons-left">
            <input type="email" class="input" id="App_Auth_email" placeholder="${i18n("EMAIL")}" value="${Misc.toInputText(item.email)}">
            <span class="icon is-small is-left">
                <i class="fas fa-envelope"></i>
            </span>
        </div>
    </div>
<!--
    <div style="margin: 1rem;">
        <p style="margin: 1rem;">Passwords must meet the following complexity requirements:</p>
        <ul style="padding-left: 5rem; list-style: disc;">
            <li>8 characters minimum</li>
            <li>At least one lower case character</li>
            <li>At least one upper case character</li>
            <li>At least one special character</li>
        </ul>
    </div>
-->
    <div class="field">
        <div class="control has-icons-left">
            <input type="password" class="input" id="App_Auth_password" placeholder="${i18n("PASSWORD")}" onkeyup="App_Auth.ensurePasswordMatch()" required>
            <span class="icon is-small is-left">
                <i class="fas fa-lock"></i>
            </span>
        </div>
    </div>
    <div class="field">
        <div class="control has-icons-left">
            <input type="password" class="input" id="App_Auth_password2" placeholder="${i18n("ENTER PASSWORD AGAIN")}" onkeyup="App_Auth.ensurePasswordMatch()" required>
            <span class="icon is-small is-left">
                <i class="fas fa-lock"></i>
            </span>
        </div>
    </div>
    <button type="submit" class="button is-block is-primary is-fullwidth">
        <i class="fas fa-sign-in-alt"></i>&nbsp;${i18n("Sign In")}
    </button>
</form>
`;
            };
            pageTemplate = (item, form, alert) => {
                return `
<section class="is-fullheight">
    <div class="container">
        <div class="column is-4 is-offset-4">
        <div class="box">
            <h1 class="has-text-centered has-text-dark">${i18n("APP WELCOME")}</h1>
            <div id="js_signin_box">
                <figure>
                    <img>
                </figure>
            </div>
${alert}
${form}
        </div>
        </div>
    </div>
</section>`;
            };
            exports_5("fetch", fetch = (params) => {
                returnUrl = "/";
                if (params != undefined && params.length > 0) {
                    returnUrl = decodeURIComponent(params[0]);
                }
                App.prepareRender(NS, i18n("Signin"));
                Router.registerDirtyExit(null);
                App.render();
            });
            exports_5("fetchInvitation", fetchInvitation = (params) => {
                returnUrl = "/";
                let guid = params[0];
                App.prepareRender(NS, i18n("Signin"));
                App.GET(`/auth/accept-invitation/${guid}`)
                    .then(json => {
                    currentStep = steps.invited;
                    state = json;
                    App.render();
                })
                    .catch(App.render);
            });
            exports_5("fetchReset", fetchReset = (params) => {
                returnUrl = "/";
                let guid = params[0];
                App.prepareRender(NS, i18n("Signin"));
                App.GET(`/auth/reset-password/${guid}`)
                    .then(json => {
                    currentStep = steps.resetted;
                    state = json;
                    App.render();
                })
                    .catch(App.render);
            });
            exports_5("render", render = () => {
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined)
                    return (App.serverError() ? pageTemplate(null, "", App.warningTemplate()) : "");
                let form;
                switch (currentStep) {
                    case steps.normal:
                        form = formTemplate(state);
                        break;
                    case steps.forgotten:
                        form = formForgottenTemplate(state);
                        break;
                    case steps.reminded:
                        form = formRemindedTemplate(state);
                        break;
                    case steps.invited:
                        form = formNewPasswordTemplate(state, steps.invited);
                        break;
                    case steps.resetted:
                        form = formNewPasswordTemplate(state, steps.resetted);
                        break;
                    default:
                        break;
                }
                const alert = App.warningTemplate();
                return pageTemplate(state, form, alert);
            });
            exports_5("postRender", postRender = () => {
                if (!App.inContext(NS))
                    return;
            });
            getFormState = () => {
                return {
                    email: Misc.fromInputText("App_Auth_email"),
                    password: Misc.fromInputText("App_Auth_password"),
                    cie: App.cie
                };
            };
            valid = (formState) => {
                if (formState.email.length == 0)
                    App.setError("Email is required");
                if (formState.password && formState.password.length == 0)
                    App.setError("Password is required");
                return App.hasNoError();
            };
            html5Valid = () => {
                document.getElementById("App_Auth_dummy_submit").click();
                let form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_5("ensurePasswordMatch", ensurePasswordMatch = () => {
                let password = document.getElementById("App_Auth_password");
                let password2 = document.getElementById("App_Auth_password2");
                if (password.value != password2.value)
                    password2.setCustomValidity(i18n("Passwords don't match"));
                else if (!ensureComplexityRequirement(password.value))
                    password2.setCustomValidity("Password doesn't meet complexity requirement");
                else
                    password2.setCustomValidity("");
            });
            ensureComplexityRequirement = (password) => {
                return password.length > 0;
                //if (password.length < 8) return false;
                //if (password == password.toUpperCase()) return false;
                //if (password == password.toLowerCase()) return false;
                //return /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/.test(password);
            };
            exports_5("signin", signin = (step = 0) => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                let kind = (step == steps.invited ? "invited" : step == steps.resetted ? "resetted" : "signin");
                App.transitionUI();
                App.POST(`/auth/${kind}`, formState)
                    .then(json => {
                    createLoginData(json.token);
                    persistLoginData();
                    currentStep = steps.normal;
                    Router.goto(returnUrl, 1, true);
                })
                    .catch(App.render);
            });
            exports_5("signout", signout = () => {
                App.transitionUI();
                App.POST("/auth/signout", null)
                    .then(json => {
                    destroyLoginData();
                    returnUrl = "/";
                    Router.goto(returnUrl, 10);
                })
                    .catch(App.render);
            });
            exports_5("forgotPassword", forgotPassword = () => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.transitionUI();
                App.POST("/auth/request-password-reset", formState)
                    .then(_ => {
                    state = formState;
                    currentStep = steps.reminded;
                    App.render();
                })
                    .catch(App.render);
            });
            exports_5("setCurrentStep", setCurrentStep = (step) => {
                state = getFormState();
                currentStep = step;
                App.render();
            });
            exports_5("getAuthorization", getAuthorization = () => {
                if (!hasLoginData())
                    return "";
                if (loginData == undefined || loginData.token == undefined)
                    return "";
                if (new Date().getTime() / 1000 > loginData.expiry)
                    return "";
                return "Bearer " + loginData.token;
            });
            exports_5("getEmail", getEmail = () => {
                if (loginData == undefined || loginData.user == undefined)
                    return null;
                return loginData.user.email;
            });
            exports_5("getName", getName = () => {
                if (loginData == undefined || loginData.user == undefined)
                    return null;
                return loginData.user.name;
            });
            exports_5("getUID", getUID = () => {
                if (loginData == undefined || loginData.user == undefined)
                    return null;
                return loginData.user.uid;
            });
            exports_5("getCie", getCie = () => {
                if (loginData == undefined || loginData.user == undefined)
                    return null;
                return loginData.user.cie;
            });
            exports_5("getCurrentYear", getCurrentYear = () => {
                if (loginData == undefined || loginData.user == undefined)
                    return null;
                return loginData.user.year;
            });
            exports_5("getPermissions", getPermissions = () => {
                if (loginData == undefined || loginData.user == undefined)
                    return [];
                return loginData.user.permissions || [];
            });
            exports_5("hasPerm", hasPerm = (permissionID) => {
                return (getPermissions().indexOf(permissionID) != -1);
            });
            exports_5("getRoles", getRoles = () => {
                if (loginData == undefined || loginData.user == undefined)
                    return [];
                return loginData.user.roles || [];
            });
            exports_5("hasRole", hasRole = (roleID) => {
                return (getRoles().indexOf(roleID) != -1);
            });
            exports_5("getUserCaps", getUserCaps = () => {
                if (loginData == undefined || loginData.user == undefined)
                    return null;
                return loginData.user;
            });
            exports_5("requireAuthentication", requireAuthentication = () => {
                let logging = (window.location.hash.indexOf("#/signin/") == 0) ||
                    (window.location.hash.indexOf("#/accept-invitation/") == 0) ||
                    (window.location.hash.indexOf("#/reset-password/") == 0);
                return !(logging || isAuthenticated());
            });
            exports_5("isAuthenticated", isAuthenticated = () => {
                return getAuthorization().length > 0;
            });
            exports_5("redirectToSignin", redirectToSignin = () => {
                destroyLoginData();
                let url = window.location.hash;
                Router.goto(`#/signin/${encodeURIComponent(url)}`, 100);
            });
            exports_5("refreshLoginData", refreshLoginData = () => {
                return App.POST("/auth/refresh", null)
                    .then(json => {
                    createLoginData(json.token);
                    persistLoginData();
                    Router.reload();
                });
            });
            createLoginData = (token) => {
                let payloadBase64 = token.split('.')[1].replace(/-/g, '+').replace(/_/g, '/');
                let payloadUTF8 = b64DecodeUnicode(payloadBase64);
                let payload = JSON.parse(payloadUTF8);
                let perms = payload["perms"] || [];
                if (!Array.isArray(perms)) {
                    perms = [perms];
                }
                let role = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
                if (!Array.isArray(role)) {
                    role = [role];
                }
                loginData = {};
                loginData.token = token;
                loginData.user = {
                    email: payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
                    name: payload["name"],
                    permissions: perms,
                    roles: role,
                    uid: +payload["uid"],
                    cie: +payload["cie"],
                };
                loginData.expiry = payload["exp"];
            };
            b64DecodeUnicode = (b64) => {
                return decodeURIComponent(Array.prototype.map.call(atob(b64), function (c) {
                    return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
                }).join(''));
            };
            persistLoginData = () => {
                storage.setItem("signin", JSON.stringify(loginData));
            };
            restoreLoginData = () => {
                loginData = JSON.parse(storage.getItem("signin"));
            };
            destroyLoginData = () => {
                storage.removeItem("signin");
                loginData = {};
            };
            hasLoginData = () => {
                return storage.getItem("signin") != undefined;
            };
            //
            // Restore loginData from storage on startup
            //
            storage = sessionStorage;
            restoreLoginData();
        }
    };
});
System.register("_BaseApp/src/permission", ["_BaseApp/src/auth"], function (exports_6, context_6) {
    "use strict";
    var Auth, buttonTemplate, isAdmin, pageTODO;
    var __moduleName = context_6 && context_6.id;
    return {
        setters: [
            function (Auth_2) {
                Auth = Auth_2;
            }
        ],
        execute: function () {
            exports_6("buttonTemplate", buttonTemplate = (pageid) => {
                return `
<a class="button" href="#/page/${pageid}" style="margin-left: 4px;">
    <span class="icon is-small">
        <i class="fa fa-lock"></i>
    </span>
</a>`;
            });
            exports_6("isAdmin", isAdmin = () => { return (Auth.getRoles().indexOf(1) != -1); });
            exports_6("pageTODO", pageTODO = -1);
        }
    };
});
System.register("_BaseApp/src/home", ["_BaseApp/src/core/app", "_BaseApp/src/core/router"], function (exports_7, context_7) {
    "use strict";
    var App, Router, NS, fetch, render, postRender;
    var __moduleName = context_7 && context_7.id;
    return {
        setters: [
            function (App_2) {
                App = App_2;
            },
            function (Router_2) {
                Router = Router_2;
            }
        ],
        execute: function () {
            exports_7("NS", NS = "App_Home");
            exports_7("fetch", fetch = () => {
                App.prepareRender(NS, "Home");
                Router.registerDirtyExit(null);
                App.render();
            });
            exports_7("render", render = () => {
                if (!App.inContext(NS))
                    return "";
                return "";
            });
            exports_7("postRender", postRender = () => {
            });
        }
    };
});
System.register("_BaseApp/src/layout", ["_BaseApp/src/home"], function (exports_8, context_8) {
    "use strict";
    var Home, render, postRender, renderHeader, renderMenu, renderFooter;
    var __moduleName = context_8 && context_8.id;
    return {
        setters: [
            function (Home_1) {
                Home = Home_1;
            }
        ],
        execute: function () {
            exports_8("render", render = () => {
                return `
${renderHeader()}
${renderMenu()}
${Home.render()}
${renderFooter()}
`;
            });
            exports_8("postRender", postRender = () => {
                Home.postRender();
            });
            renderHeader = () => {
                return ``;
            };
            renderMenu = () => {
                return ``;
            };
            renderFooter = () => {
                return ``;
            };
        }
    };
});
System.register("_BaseApp/src/main", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/auth"], function (exports_9, context_9) {
    "use strict";
    var App, Router, Auth, checkAuthenticationExpiryLoop, startup;
    var __moduleName = context_9 && context_9.id;
    return {
        setters: [
            function (App_3) {
                App = App_3;
            },
            function (Router_3) {
                Router = Router_3;
            },
            function (Auth_3) {
                Auth = Auth_3;
            }
        ],
        execute: function () {
            //
            // Global references to application objects
            // These must match the "NS" values defined in modules
            // Mainly used for event handlers
            //
            window.App_Auth = Auth;
            // Routing table
            Router.addRoute("^#/signin/(.*)$", params => { Auth.fetch(params); });
            Router.addRoute("^#/signout/?$", Auth.signout);
            Router.addRoute("^#/accept-invitation/(.*)$", Auth.fetchInvitation);
            Router.addRoute("^#/reset-password/(.*)$", Auth.fetchReset);
            checkAuthenticationExpiryLoop = () => {
                const updater = () => {
                    if (App.requireAuthentication()) {
                        console.log("Authentication required");
                        Router.reload();
                    }
                };
                setInterval(updater, 2000);
            };
            exports_9("startup", startup = (hasPublicHomePage, layout, theme) => {
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
            });
        }
    };
});
System.register("_BaseApp/src/admin/lookupdata", ["_BaseApp/src/core/app"], function (exports_10, context_10) {
    "use strict";
    var App, authrole, fetch_authrole, lutGroup, fetch_lutGroup, get_lutGroup;
    var __moduleName = context_10 && context_10.id;
    return {
        setters: [
            function (App_4) {
                App = App_4;
            }
        ],
        execute: function () {
            exports_10("fetch_authrole", fetch_authrole = () => {
                return function (data) {
                    if (authrole != undefined && authrole.length > 0)
                        return;
                    return App.GET(`/account/role`).then(json => { exports_10("authrole", authrole = json); });
                };
            });
            exports_10("fetch_lutGroup", fetch_lutGroup = () => {
                return function (data) {
                    if (lutGroup != undefined && lutGroup.length > 0)
                        return;
                    return App.GET(`/lookup/lutGroup`).then(json => { lutGroup = json; });
                };
            });
            exports_10("get_lutGroup", get_lutGroup = (year) => lutGroup);
        }
    };
});
System.register("_BaseApp/src/lang/en-CA", [], function (exports_11, context_11) {
    "use strict";
    var en_CA;
    var __moduleName = context_11 && context_11.id;
    return {
        setters: [],
        execute: function () {
            exports_11("en_CA", en_CA = {
                values: {
                    "EMAIL": "Email",
                    "PASSWORD": "Password"
                }
            });
        }
    };
});
System.register("_BaseApp/src/theme/pager", ["_BaseApp/src/lib-ts/misc"], function (exports_12, context_12) {
    "use strict";
    var Misc, NullPager, render, renderStatic, sortableHeaderLink, headerLink, rowNumber, asParams, searchTemplate;
    var __moduleName = context_12 && context_12.id;
    return {
        setters: [
            function (Misc_2) {
                Misc = Misc_2;
            }
        ],
        execute: function () {
            exports_12("NullPager", NullPager = { pageNo: 1, pageSize: 1000, rowCount: 0, searchText: "", sortColumn: "", sortDirection: "", filter: {} });
            exports_12("render", render = (pager, ns, sizes, searchHtml = null, customHtml = null) => {
                let rowFirst = ((pager.pageNo - 1) * pager.pageSize) + 1;
                if (pager.rowCount == 0)
                    rowFirst = 0;
                let rowLast = Math.min(rowFirst + pager.pageSize - 1, pager.rowCount);
                let pageCount = Math.floor((Math.max(pager.rowCount - 1, 0) / pager.pageSize) + 1);
                let firstPage = `${ns}.goto(1, ${pager.pageSize})`;
                let prevPage = `${ns}.goto(${pager.pageNo - 1}, ${pager.pageSize})`;
                let nextPage = `${ns}.goto(${pager.pageNo + 1}, ${pager.pageSize})`;
                let lastPage = `${ns}.goto(${pageCount}, ${pager.pageSize})`;
                let allSizes = "";
                if (sizes.length > 0) {
                    allSizes = sizes.reduce((html, size) => {
                        return html + `
            <a class="dropdown-item" href="#" onclick="${ns}.goto(1, ${size});return false;">
                <span class="fa fa-check" style="width: 15px; ${size != pager.pageSize ? "visibility: hidden" : ""}"></span>
                ${i18n("%n Records per Page", size)}
            </a>`;
                    }, ``);
                }
                return `
<div class="level">
    <div class="level-left">
        <div class="field is-horizontal">
            <div class="field-body">
                ${searchHtml != undefined && searchHtml.length > 0 ? searchHtml : ""}
                ${customHtml != undefined && customHtml.length > 0 ? customHtml : ""}
            </div>
        </div>
    </div>
    <div class="level-right">
        <div class="field is-grouped">
            <div class="dropdown is-right is-hoverable" xx-js-skip-render-class="is-active">
                <div class="dropdown-trigger">
                    <button class="button" aria-haspopup="true" aria-controls="dropdown-menu" title="${i18n("Options")}">
                        <span>${i18n("%{rowFirst}-%{rowLast} of %{rowCount} Records", { rowFirst: rowFirst, rowLast: rowLast, rowCount: pager.rowCount })}</span>
                        <span class="icon is-small"><i class="fas fa-angle-down" aria-hidden="true"></i></span>
                    </button>
                </div>
                <div class="dropdown-menu" id="dropdown-menu" role="menu">
                    <div class="dropdown-content">
                        <a class="dropdown-item" href="#" onclick="${firstPage};return false;">
                            <span class="far fa-fast-backward" style="width: 15px;"></span>
                            ${i18n("Go To First Page")}
                        </a>
                        <a class="dropdown-item" href="#" onclick="${lastPage};return false;">
                            <span class="far fa-fast-forward" style="width: 15px;"></span>
                            ${i18n("Go To Last Page")}
                        </a>
                        <hr class="dropdown-divider">
                        ${allSizes}
                    </div>
                </div>
            </div>
            <div class="buttons has-addons" style="margin-left: 4px;">
                <button type="button" class="button" ${pager.pageNo == 1 ? "disabled" : ""} onclick="${firstPage}"><i class="fal fa-fast-backward"></i></button>
                <button type="button" class="button" ${pager.pageNo == 1 ? "disabled" : ""} onclick="${prevPage}"><i class="fal fa-step-backward"></i></button>
                <button type="button" class="button" ${pager.pageNo == pageCount ? "disabled" : ""} onclick="${nextPage}"><i class="fal fa-step-forward"></i></button>
                <button type="button" class="button" ${pager.pageNo == pageCount ? "disabled" : ""} onclick="${lastPage}"><i class="fal fa-fast-forward"></i></button>
            </div>
        </div>
    </div>
</div>`;
            });
            exports_12("renderStatic", renderStatic = (pager) => {
                return `
<div class="js-container">
    <div class="js-filter-column"></div>
    <div class="js-control">
        <span><em>${pager.rowCount} records found</strong></em>
    </div>
</div>`;
            });
            exports_12("sortableHeaderLink", sortableHeaderLink = (pager, ns, linkText, columnName, defaultDirection /*"ASC"*/, style = "") => {
                var indicator = "";
                var sorting = "";
                var nextDir = defaultDirection;
                if (columnName.toUpperCase() == pager.sortColumn.toUpperCase())
                    nextDir = (pager.sortDirection == "ASC" ? "DESC" : "ASC");
                if (columnName.toUpperCase() == pager.sortColumn.toUpperCase()) {
                    indicator = `&nbsp;<i class="fa ${pager.sortDirection == "DESC" ? "fa-sort-down" : "fa-sort-up"}"></i>`;
                    sorting = " class=\"js-sorting\"";
                }
                if (indicator.length == 0)
                    indicator = '&nbsp;<i class="fa fa-sort-down" style="visibility: hidden;"></i>';
                return `<th${sorting} ${style ? `style="${style}"` : ""}><a href="#" onclick="${ns}.sortBy('${columnName}', '${nextDir}');return false;">${linkText}${indicator}</a></th>`;
            });
            exports_12("headerLink", headerLink = (linkText) => {
                return `<th class="js-no-sorting">${linkText}</th>`;
            });
            exports_12("rowNumber", rowNumber = (pager, index) => {
                return 1 + index + ((pager.pageNo - 1) * pager.pageSize);
            });
            exports_12("asParams", asParams = (pager) => {
                let searchText = (pager.searchText != undefined ? encodeURIComponent(pager.searchText) : "");
                let params = `pn=${pager.pageNo}&ps=${pager.pageSize}&sc=${pager.sortColumn}&sd=${pager.sortDirection}&st=${searchText}`;
                if (pager.filter != undefined) {
                    Object.keys(pager.filter).forEach(key => {
                        if (pager.filter[key] != undefined) {
                            let value = pager.filter[key];
                            if (value != null && typeof value.getTime === "function") {
                                let text = JSON.stringify(value).replace(/"/g, "");
                                params += `&${key}=${text}`;
                            }
                            else if (Array.isArray(value)) {
                                params += `&${key}=${value.join(",")}`;
                            }
                            else {
                                params += `&${key}=${value}`;
                            }
                        }
                    });
                }
                return params;
            });
            exports_12("searchTemplate", searchTemplate = (pager, ns, xtra) => {
                return `
    <div class="field">
        <label class="label">${i18n("SEARCH")}</label>
        <div class="control has-icons-left" style="width:125px;">
            <input class="input" type="text" placeholder="${i18n("SEARCH")}" value="${Misc.toInputText(pager.searchText)}" xonchange="${ns}.search(this)" onkeydown="if (event.keyCode == 13) ${ns}.search(event.target)" ${xtra || ""}>
            <span class="icon is-small is-left">
                <i class="fas fa-search"></i>
            </span>
        </div>
    </div>`;
            });
        }
    };
});
System.register("_BaseApp/src/theme/autocomplete", ["_BaseApp/src/core/app"], function (exports_13, context_13) {
    "use strict";
    var App, Autocomplete;
    var __moduleName = context_13 && context_13.id;
    return {
        setters: [
            function (App_5) {
                App = App_5;
            }
        ],
        execute: function () {
            Autocomplete = class Autocomplete {
                constructor(ns, propName, required = false) {
                    this.ns = ns;
                    this.propName = propName;
                    this.required = required;
                    this.isActive = false;
                    this.disabled = false;
                    this.render = () => {
                        let hasIndex = this.pagedList.list.reduce((selected, one) => one.selected ? true : selected, false);
                        if (!hasIndex) {
                            let index = (this.required || this.text == undefined || this.text.length == 0 ? 0 : 1);
                            if (this.pagedList.list.length > index)
                                this.pagedList.list[index].selected = true;
                        }
                        let opt = this.options;
                        let textRows = this.pagedList.list.map((one, index) => {
                            let key = opt.keyTemplate(one);
                            let value = opt.valueTemplate(one).replace(/"/g, "&quot;");
                            let active = (one.selected ? "is-active" : "");
                            let detail = opt.detailTemplate(one);
                            return `<a href="#" data-key="${key}" data-value="${value}" data-index="${index}" onclick="${this.handle('a.onclick')}; return false;" class="dropdown-item ${active}"><p>${detail}</p></a>`;
                        });
                        let text = textRows.join('<hr class="dropdown-divider">');
                        let html = `
<div class="dropdown-menu">
    <div class="dropdown-content">
        ${text}
${textRows.length > 0 ? `
        <div class="dropdown-item">
            <div>&nbsp;
                <div class="is-pulled-right has-text-grey-light">${textRows.length} out of ${this.pagedList.pager.rowCount} results</div>
            </div>
        </div>
` : `
        <div class="dropdown-item">
            <div>&nbsp;
                <div class="is-pulled-right has-text-grey-light">${i18n("No results")}</div>
            </div>
        </div>
`}
    </div>
</div>
`;
                        return html;
                    };
                    this.postRender = () => {
                    };
                    this.handle = (eventName) => {
                        return `${this.id}.on(this, '${eventName}')`;
                    };
                    this.on = (element, eventName) => {
                        if (eventName == 'onfocus') {
                            this.isActive = true;
                            this.text = element.value;
                            window[this.ns].onautocomplete(this.id);
                        }
                        else if (eventName == 'onkeydown') {
                            let kevent = event;
                            if (kevent.key == "ArrowUp") {
                                event.preventDefault();
                                let index = this.pagedList.list.findIndex(one => one.selected);
                                if (index > 0) {
                                    this.pagedList.list[index].selected = false;
                                    this.pagedList.list[index - 1].selected = true;
                                    App.render();
                                }
                            }
                            else if (kevent.key == "ArrowDown") {
                                event.preventDefault();
                                let index = this.pagedList.list.findIndex(one => one.selected);
                                if (index < this.pagedList.list.length - 1) {
                                    this.pagedList.list[index].selected = false;
                                    this.pagedList.list[index + 1].selected = true;
                                    App.render();
                                }
                            }
                            else if (this.isActive && ["Tab", "Enter", "Escape"].indexOf(kevent.key) > -1) {
                                event.preventDefault();
                                clearTimeout(this.blurTimer);
                                let one = this.pagedList.list.find(one => one.selected);
                                let key = this.options.keyTemplate(one);
                                let text = this.options.valueTemplate(one).replace(/"/g, "&quot;");
                                this.setState(key, text);
                                this.isActive = false;
                                let input = document.getElementById(this.input_id);
                                input.dataset["key"] = this.key;
                                input.blur();
                                window[this.ns].onchange(input);
                            }
                            else {
                                clearTimeout(this.typingTimer);
                                this.typingTimer = setTimeout(_ => {
                                    this.isActive = true;
                                    this.text = element.value;
                                    window[this.ns].onautocomplete(this.id);
                                }, 50);
                            }
                        }
                        else if (eventName == "a.onclick") {
                            clearTimeout(this.blurTimer);
                            let key = element.dataset["key"];
                            let text = element.dataset["value"];
                            this.setState(key, text);
                            this.isActive = false;
                            let input = document.getElementById(this.input_id);
                            input.dataset["key"] = this.key;
                            window[this.ns].onchange(input);
                        }
                        else if (eventName == "onblur") {
                            this.blurTimer = setTimeout(_ => {
                                this.isActive = false;
                                let required = element.hasAttribute("required");
                                if (required) {
                                    this.setState(this.initialKey, this.initialText);
                                    App.render();
                                }
                                else {
                                    let value = element.value.trim();
                                    if (value.length == 0 || value != this.initialText) {
                                        this.setState(null, null);
                                        element.dataset["key"] = this.key;
                                        window[this.ns].onchange(element);
                                    }
                                    else {
                                        App.render();
                                    }
                                }
                            }, 500);
                        }
                    };
                    this.input_id = `${this.ns}_${this.propName}`;
                    this.id = `${this.ns}_${this.propName}Autocomplete`;
                    window[this.id] = this;
                }
                setState(key, text) {
                    this.initialKey = this.key = key;
                    this.initialText = this.text = text;
                }
                get keyValue() {
                    return this.key;
                }
                get textValue() {
                    return this.text;
                }
            };
            exports_13("Autocomplete", Autocomplete);
        }
    };
});
System.register("_BaseApp/src/theme/calendar", ["_BaseApp/src/core/app", "_BaseApp/src/lib-ts/misc"], function (exports_14, context_14) {
    "use strict";
    var App, Misc, days, months, Calendar, eventMan;
    var __moduleName = context_14 && context_14.id;
    return {
        setters: [
            function (App_6) {
                App = App_6;
            },
            function (Misc_3) {
                Misc = Misc_3;
            }
        ],
        execute: function () {
            days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
            months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            /*
                WATCH OUT!
            
                new Date(“1995-01-01”) => Sat Dec 31 1994 19:00:00 GMT-0500 (Eastern Standard Time)
                new Date(1995, 0, 1) => Sun Jan 01 1995 00:00:00 GMT-0500 (Eastern Standard Time)
            
            */
            Calendar = class Calendar {
                constructor(input_id, required = false, alwaysOpened = false, asFilter = false, hasTime = false, hasChanger = false, hasToday = false) {
                    this.input_id = input_id;
                    this.required = required;
                    this.alwaysOpened = alwaysOpened;
                    this.asFilter = asFilter;
                    this.hasTime = hasTime;
                    this.hasChanger = hasChanger;
                    this.hasToday = hasToday;
                    this.isNullDate = false;
                    //
                    this.viewName = "jscal-days";
                    this.hidden = true;
                    this.hasButtons = true;
                    this.isValid = true;
                    this.disableDate = false;
                    this.setState = (date, forcedYear, min, max) => {
                        if (date != undefined) {
                            this.selectedYear = this.displayedYear = date.getFullYear();
                            this.selectedMonth = this.displayedMonth = date.getMonth() + 1;
                            this.selectedDay = date.getDate();
                            this.selectedHour = date.getHours();
                            this.selectedMinute = date.getMinutes();
                            this.initialDate = new Date(date.getTime());
                            this.isNullDate = false;
                        }
                        else {
                            let now = new Date();
                            this.selectedYear = this.displayedYear = (forcedYear != undefined ? forcedYear : now.getFullYear());
                            this.selectedMonth = this.displayedMonth = now.getMonth() + 1;
                            this.selectedDay = now.getDate();
                            this.selectedHour = 0;
                            this.selectedMinute = 0;
                            this.initialDate = null;
                            this.isNullDate = true;
                        }
                        if (min != undefined)
                            this.min = min;
                        if (max != undefined)
                            this.max = max;
                        if (forcedYear) {
                            this.forcedYear = forcedYear;
                            this.min = new Date(forcedYear, 0, 1);
                            this.max = new Date(forcedYear, 11, 31);
                        }
                    };
                    this.render = () => {
                        let date = new Date(this.displayedYear, this.displayedMonth - 1, 1, 0, 0, 0, 0);
                        let year = date.getFullYear();
                        let month = date.getMonth();
                        let firstDate = new Date(date);
                        //
                        while (true) {
                            while (firstDate.getDay() != 0)
                                firstDate.setDate(firstDate.getDate() - 1);
                            if (firstDate.getMonth() != month || firstDate.getDate() == 1)
                                break;
                            firstDate.setDate(firstDate.getDate() - 1);
                        }
                        let lastDate = new Date(date);
                        let lastOfMonth = new Date(year, month + 1, 0);
                        //
                        while (true) {
                            while (lastDate.getDay() != 6)
                                lastDate.setDate(lastDate.getDate() + 1);
                            if (lastDate.getMonth() != month || lastDate.getTime() == lastOfMonth.getTime())
                                break;
                            lastDate.setDate(lastDate.getDate() + 1);
                        }
                        let selectedDate = new Date(this.selectedYear, this.selectedMonth - 1, this.selectedDay, 0, 0, 0, 0);
                        var tr = "";
                        while (true) {
                            tr += "<tr>";
                            for (var iday = 0; iday < 7; iday++) {
                                let selected = (firstDate.getTime() == selectedDate.getTime());
                                let other = (firstDate.getMonth() != month);
                                let outside = ((this.minValue && firstDate < this.minValue) || (this.maxValue && firstDate > this.maxValue));
                                let dateText = [firstDate.getFullYear(), firstDate.getMonth() + 1, firstDate.getDate()].join("/");
                                let classes = [];
                                if (selected)
                                    classes.push("selected");
                                if (other)
                                    classes.push("other");
                                if (outside)
                                    classes.push("outside");
                                tr += `<td ${classes.length ? `class="${classes.join(" ")}"` : ""} data-select="${dateText}">${firstDate.getDate()}</td>`;
                                firstDate.setDate(firstDate.getDate() + 1);
                            }
                            tr += "</tr>";
                            if (firstDate.getTime() >= lastDate.getTime())
                                break;
                        }
                        let prevMonth = this.displayedMonth - 1;
                        let prevYear = this.displayedYear;
                        if (prevMonth == 0) {
                            prevMonth = 12;
                            prevYear--;
                        }
                        let nextMonth = this.displayedMonth + 1;
                        let nextYear = this.displayedYear;
                        if (nextMonth == 13) {
                            nextMonth = 1;
                            nextYear++;
                        }
                        let trMonths = months.reduce((html, item, index) => {
                            let month = index + 1;
                            let name = item.substr(0, 3);
                            return html + `<div data-month="${month}"${this.displayedMonth == month ? " class='selected'" : ""}>${name}</div>`;
                        }, "");
                        let trYears = "";
                        for (var ix = 0; ix < 9; ix++) {
                            let year = this.displayedYear - 4 + ix;
                            trYears += `<div ${this.displayedYear == year ? "class='selected'" : ""}>${year}</div>`;
                        }
                        return `
    <div id="${this.id}" class="jscal-container ${this.hidden ? "js-display-none" : ""}">
    
    <div class="jscal-banner">
        <div class="jscal-day">
            ${days[selectedDate.getDay()]}
        </div>
        <div class="jscal-date" data-date="${this.selectedYear}/${this.selectedMonth}/${this.selectedDay}" data-time="${this.selectedHour}:${this.selectedMinute}">
            <div>${("0" + selectedDate.getDate()).slice(-2)}</div>
            <div>
                <div>${months[selectedDate.getMonth()].substr(0, 3)}</div>
                <div>${selectedDate.getFullYear()}</div>
            </div>
        </div>
    </div>
    <div class="jscal-nav">
        <a class="previous" data-display="${prevYear}/${prevMonth}"><i class="fas fa-chevron-left"></i></a>
        <div>
            <a class="select-month">${months[date.getMonth()]}</a>
            <a class="select-year">${year}</a>
        </div>
        <a class="next" data-display="${nextYear}/${nextMonth}"><i class="fas fa-chevron-right"></i></a>
    </div>
    <div class="jscal-years ${this.viewName != "jscal-years" ? "js-hidden" : ""}">
        <a class="previous"><i class="fas fa-chevron-left"></i></a>
        <div>
            ${trYears}
        </div>
        <a class="next"><i class="fas fa-chevron-right"></i></a>
    </div>
    <div class="jscal-months ${this.viewName != "jscal-months" ? "js-hidden" : ""}">
        ${trMonths}
    </div>
    <div class="jscal-days ${this.viewName != "jscal-days" ? "js-hidden" : ""}">
        <table>
            <thead>
                <tr>
                    <th>Sun</th> <th>Mon</th> <th>Tue</th> <th>Wed</th> <th>Thu</th> <th>Fri</th> <th>Sat</th>
                </tr>
            </thead>
            <tbody>
                ${tr}
            </tbody>
        </table>
        <hr>

${this.hasButtons ? `
        <div class="buttons">
            <button class="button cancel"><span>Cancel</span></button>
${!this.required ? `
            <button class="button clear"><span>Clear</span></button>
` : ``}
${this.hasToday ? `
            <button class="button today is-primary"><span class="icon"><i class="fa fa-check"></i></span><span>Today</span></button>
` : ``}
            <button class="button ok is-primary" ${!this.hasValidYear ? "disabled" : ""}><span class="icon"><i class="fa fa-check"></i></span><span>Select</span></button>
        </div>
` : ``}

    </div>
    
    </div>`;
                    };
                    this.postRender = () => {
                        var _a, _b;
                        let wrapperElem = document.getElementById(this.input_id + "_wrapper");
                        if (wrapperElem == undefined)
                            return;
                        // Remove event listeners
                        wrapperElem.outerHTML = wrapperElem.outerHTML;
                        wrapperElem = document.getElementById(this.id);
                        wrapperElem.querySelector(".jscal-container tbody").addEventListener("click", event => {
                            var td = event.target;
                            if (td.dataset.select == undefined)
                                return;
                            let parts = td.dataset.select.split("/");
                            let selectedYear = +parts[0];
                            let selectedMonth = +parts[1];
                            let selectedDay = +parts[2];
                            let newDate = new Date(selectedYear, selectedMonth - 1, selectedDay, 0, 0, 0, 0);
                            if (this.minValue && newDate < this.minValue)
                                return;
                            if (this.maxValue && newDate > this.maxValue)
                                return;
                            this.selectedYear = selectedYear;
                            this.selectedMonth = selectedMonth;
                            this.selectedDay = selectedDay;
                            this.isNullDate = false;
                            if (!this.asFilter) {
                                App.render();
                            }
                            else {
                                this.initialDate = this.dateValue;
                                this.hidden = (true && !this.alwaysOpened);
                                //
                                let parts = this.input_id.split("_");
                                let ns = parts.slice(0, -1).join("_");
                                let name = parts[parts.length - 1];
                                window[ns].oncalendar_filter(name, this.dateValue);
                            }
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-nav .previous").addEventListener("click", event => {
                            let element = event.target.closest("a");
                            let parts = element.dataset.display.split("/");
                            this.displayedYear = +parts[0];
                            this.displayedMonth = +parts[1];
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-nav .next").addEventListener("click", event => {
                            let element = event.target.closest("a");
                            let parts = element.dataset.display.split("/");
                            this.displayedYear = +parts[0];
                            this.displayedMonth = +parts[1];
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-date").addEventListener("click", event => {
                            let element = event.target.closest(".jscal-date");
                            let parts = element.dataset.date.split("/");
                            this.selectedYear = this.displayedYear = +parts[0];
                            this.selectedMonth = this.displayedMonth = +parts[1];
                            this.selectedDay = +parts[2];
                            this.viewName = "jscal-days";
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-months").addEventListener("click", event => {
                            let element = event.target;
                            this.displayedMonth = +element.dataset.month;
                            this.viewName = "jscal-days";
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-years div").addEventListener("click", event => {
                            let element = event.target;
                            this.displayedYear = +element.innerText;
                            this.viewName = "jscal-days";
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-years .previous").addEventListener("click", event => {
                            this.displayedYear = this.displayedYear - 4;
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-years .next").addEventListener("click", event => {
                            this.displayedYear = this.displayedYear + 4;
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .select-month").addEventListener("click", event => {
                            this.viewName = "jscal-months";
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .select-year").addEventListener("click", event => {
                            this.viewName = "jscal-years";
                            App.render();
                        });
                        if (this.hasButtons) {
                            wrapperElem.querySelector(".jscal-container .cancel").addEventListener("click", event => {
                                this.setState(this.initialDate);
                                this.hidden = (true && !this.alwaysOpened);
                                App.render();
                            });
                            wrapperElem.querySelector(".jscal-container .ok").addEventListener("click", event => {
                                this.initialDate = this.dateValue;
                                this.hidden = (true && !this.alwaysOpened);
                                //
                                //App.render()
                                let dateElem = document.getElementById(this.input_id);
                                let parts = this.input_id.split("_");
                                let ns = parts.slice(0, -1).join("_");
                                let name = parts[parts.length - 1];
                                window[ns].onchange(dateElem);
                            });
                            if (!this.required) {
                                (_a = wrapperElem.querySelector(".jscal-container .clear")) === null || _a === void 0 ? void 0 : _a.addEventListener("click", event => {
                                    this.isNullDate = true;
                                    App.render();
                                });
                            }
                            if (this.hasToday) {
                                (_b = wrapperElem.querySelector(".jscal-container .today")) === null || _b === void 0 ? void 0 : _b.addEventListener("click", event => {
                                    let today = new Date(new Date().setHours(0, 0, 0, 0));
                                    this.setState(today);
                                    this.hidden = (true && !this.alwaysOpened);
                                    //
                                    //App.render()
                                    let dateElem = document.getElementById(this.input_id);
                                    dateElem.value = Misc.toInputDate(today);
                                    let parts = this.input_id.split("_");
                                    let ns = parts.slice(0, -1).join("_");
                                    let name = parts[parts.length - 1];
                                    window[ns].onchange(dateElem);
                                });
                            }
                        }
                        //
                        // Date input
                        //
                        let dateElem = document.getElementById(this.input_id);
                        if (dateElem) {
                            dateElem.addEventListener("focus", event => {
                                dateElem.value = dateElem.value.replace(/\D+/g, "");
                                try {
                                    if (this.forcedYear) {
                                        dateElem.setSelectionRange(4, 8);
                                    }
                                    else {
                                        dateElem.select();
                                    }
                                }
                                catch (error) { }
                                dateElem.type = "number";
                            });
                            const ondatechange = (event) => {
                                let text = "00000000" + dateElem.value.replace(/\D+/g, "");
                                let dd = text.slice(-2);
                                let mm = text.slice(-4, -2);
                                let yy = (this.forcedYear != undefined ? this.forcedYear : text.slice(-8, -4));
                                text = `${yy}-${mm}-${dd}`;
                                dateElem.type = "text";
                                dateElem.value = text;
                                dateElem.setAttribute("value", text);
                                let date = new Date(text);
                                let min = dateElem.dataset.min;
                                let max = dateElem.dataset.max;
                                let outside = ((min != undefined) && date < (new Date(min))) || ((max != undefined) && date > (new Date(max)));
                                if (Misc.isValidDateString(text) && !outside) {
                                    dateElem.style.borderColor = "";
                                    dateElem.style.zIndex = "";
                                    this.isValid = true;
                                    //
                                    date = new Date(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), this.selectedHour, this.selectedMinute, 0, 0);
                                    this.setState(date, this.forcedYear, this.min, this.max);
                                    //
                                    let parts = this.input_id.split("_");
                                    let ns = parts.slice(0, -1).join("_");
                                    let name = parts[parts.length - 1];
                                    if (!this.asFilter) {
                                        window[ns].onchange(dateElem);
                                    }
                                    else {
                                        window[ns].oncalendar_filter(name, this.dateValue);
                                    }
                                    return true;
                                }
                                dateElem.style.borderColor = "red";
                                dateElem.style.zIndex = "1";
                                this.isValid = false;
                            };
                            dateElem.addEventListener("change", ondatechange);
                            dateElem.addEventListener("blur", (event) => {
                                if (isNaN(+dateElem.value)) //return if formatted yyyy-mm-dd
                                    return;
                                ondatechange(event);
                            });
                        }
                        //
                        // Time input
                        //
                        let timeElem = document.getElementById(this.input_id + "_time");
                        if (timeElem) {
                            timeElem.addEventListener("focus", event => {
                                timeElem.value = timeElem.value.replace(/\D+/g, "");
                                timeElem.select();
                                timeElem.type = "number";
                            });
                            const ontimechange = (event) => {
                                let text = "0000" + timeElem.value.replace(/\D+/g, "");
                                let mm = text.slice(-2);
                                let hh = text.slice(-4, -2);
                                text = `${hh}:${mm}`;
                                timeElem.type = "text";
                                timeElem.value = text;
                                timeElem.setAttribute("value", text);
                                if (Misc.isValidTimeString(text)) {
                                    timeElem.style.borderColor = "";
                                    timeElem.style.zIndex = "";
                                    this.isValid = true;
                                    //
                                    let date = new Date(this.dateValue);
                                    date.setHours(+hh);
                                    date.setMinutes(+mm);
                                    this.setState(date, this.forcedYear, this.min, this.max);
                                    //
                                    let parts = this.input_id.split("_");
                                    let ns = parts.slice(0, -1).join("_");
                                    let name = parts[parts.length - 1];
                                    window[ns].onchange(timeElem);
                                    return true;
                                }
                                timeElem.style.borderColor = "red";
                                timeElem.style.zIndex = "1";
                                this.isValid = false;
                            };
                            timeElem.addEventListener("change", ontimechange);
                            timeElem.addEventListener("blur", (event) => {
                                if (isNaN(+timeElem.value)) //return if formatted hh:mm
                                    return;
                                ontimechange(event);
                            });
                        }
                        //
                        // Clear button
                        //
                        let clearElem = document.getElementById(this.input_id + "_clear");
                        if (clearElem) {
                            clearElem.addEventListener("click", event => {
                                this.isNullDate = true;
                                //
                                let parts = this.input_id.split("_");
                                let ns = parts.slice(0, -1).join("_");
                                let name = parts[parts.length - 1];
                                if (!this.asFilter) {
                                    window[ns].onchange(dateElem);
                                }
                                else {
                                    window[ns].oncalendar_filter(name, this.dateValue);
                                }
                            });
                        }
                        //
                        // Popup button
                        //
                        let popupElem = document.getElementById(this.input_id + "_popup");
                        if (popupElem) {
                            popupElem.addEventListener("click", event => {
                                this.toggle();
                            });
                        }
                        //
                        // Previous button
                        //
                        let previousElem = document.getElementById(this.input_id + "_previous");
                        if (previousElem) {
                            previousElem.addEventListener("click", event => {
                                let prevDay = new Date(this.dateValue.getTime());
                                prevDay.setDate(prevDay.getDate() - 1);
                                this.setState(prevDay, this.forcedYear, this.min, this.max);
                                dateElem.setAttribute("value", Misc.toInputDate(this.dateValue));
                                //
                                let parts = this.input_id.split("_");
                                let ns = parts.slice(0, -1).join("_");
                                let name = parts[parts.length - 1];
                                if (!this.asFilter) {
                                    window[ns].onchange(dateElem);
                                }
                                else {
                                    window[ns].oncalendar_filter(name, this.dateValue);
                                }
                            });
                        }
                        //
                        // Next button
                        //
                        let nextElem = document.getElementById(this.input_id + "_next");
                        if (nextElem) {
                            nextElem.addEventListener("click", event => {
                                let nextDay = new Date(this.dateValue.getTime());
                                nextDay.setDate(nextDay.getDate() + 1);
                                this.setState(nextDay, this.forcedYear, this.min, this.max);
                                dateElem.setAttribute("value", Misc.toInputDate(this.dateValue));
                                //
                                let parts = this.input_id.split("_");
                                let ns = parts.slice(0, -1).join("_");
                                let name = parts[parts.length - 1];
                                if (!this.asFilter) {
                                    window[ns].onchange(dateElem);
                                }
                                else {
                                    window[ns].oncalendar_filter(name, this.dateValue);
                                }
                            });
                        }
                    };
                    this.toggle = () => {
                        this.hidden = (!this.hidden && !this.alwaysOpened);
                        App.render();
                    };
                    this.id = this.input_id + "Calendar";
                    this.hidden = !alwaysOpened;
                    this.hasButtons = !alwaysOpened && !asFilter;
                }
                get dateValue() {
                    if (this.isNullDate)
                        return null;
                    return new Date(this.selectedYear, this.selectedMonth - 1, this.selectedDay, this.selectedHour, this.selectedMinute, 0, 0);
                }
                get year() {
                    return this.dateValue.getFullYear();
                }
                get hasValidYear() {
                    if (this.isNullDate)
                        return false;
                    return this.forcedYear == undefined || this.year == this.forcedYear;
                }
                set min(date) {
                    this.minValue = date;
                }
                set max(date) {
                    this.maxValue = date;
                }
            };
            exports_14("Calendar", Calendar);
            exports_14("eventMan", eventMan = (ns, dateElem, eventname) => {
                const ondatechange = () => {
                    if (!dateElem.getAttribute("required") && dateElem.value.length == 0) {
                        window[ns].onchange(dateElem);
                        return true;
                    }
                    let text = "00000000" + dateElem.value.replace(/\D+/g, "");
                    let dd = text.slice(-2);
                    let mm = text.slice(-4, -2);
                    let yy = text.slice(-8, -4);
                    text = `${yy}-${mm}-${dd}`;
                    dateElem.type = "text";
                    dateElem.value = text;
                    dateElem.setAttribute("value", text);
                    let date = new Date(text);
                    let min = dateElem.dataset.min;
                    let max = dateElem.dataset.max;
                    let outside = ((min != undefined) && date < (new Date(min))) || ((max != undefined) && date > (new Date(max)));
                    if (Misc.isValidDateString(text) && !outside) {
                        dateElem.style.borderColor = "";
                        dateElem.style.zIndex = "";
                        //
                        date = new Date(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), 0, 0, 0, 0);
                        //
                        window[ns].onchange(dateElem);
                        return true;
                    }
                    dateElem.style.borderColor = "red";
                    dateElem.style.zIndex = "1";
                };
                if (eventname == "focus") {
                    dateElem.value = dateElem.value.replace(/\D+/g, "");
                    try {
                        dateElem.select();
                    }
                    catch (error) { }
                    dateElem.type = "number";
                }
                else if (eventname == "change") {
                    ondatechange();
                }
                else if (eventname == "blur") {
                    if (isNaN(+dateElem.value)) //return if formatted yyyy-mm-dd
                        return;
                    ondatechange();
                }
            });
        }
    };
});
System.register("_BaseApp/src/theme/latlong", [], function (exports_15, context_15) {
    "use strict";
    var NS, onfocusLatLon, onchangeLatLon, onblurLatLon;
    var __moduleName = context_15 && context_15.id;
    return {
        setters: [],
        execute: function () {
            exports_15("NS", NS = "App_LatLong");
            exports_15("onfocusLatLon", onfocusLatLon = (element) => {
                if (element.dataset.isddmmcc == "true") {
                    element.value = element.value.replace("°", "").replace("′", "").replace(" ", "");
                    element.type = "number";
                    element.select();
                }
                else {
                    element.value = element.value.replace(/\D+/g, "");
                    element.type = "number";
                    element.select();
                }
            });
            exports_15("onchangeLatLon", onchangeLatLon = (element) => {
                if (element.dataset.isddmmcc == "true") {
                    let isLongitude = (element.dataset.islongitude == "true");
                    let text = "0000000" + (+element.value).toFixed(2);
                    let cc = text.slice(-2);
                    let mm = text.slice(-5, -3);
                    let dd = text.slice((isLongitude ? -8 : -7), -5);
                    text = `${dd}° ${mm}.${cc}′`;
                    if (text[0] == "0")
                        text = text.slice(1);
                    element.type = "text";
                    element.value = text;
                    element.setAttribute("value", text);
                }
                else {
                    let isLongitude = (element.dataset.islongitude == "true");
                    let text = "0000000" + element.value;
                    let ss = text.slice(-2);
                    let mm = text.slice(-4, -2);
                    let dd = text.slice((isLongitude ? -7 : -6), -4);
                    text = `${dd}° ${mm}′ ${ss}″`;
                    if (text[0] == "0")
                        text = text.slice(1);
                    element.type = "text";
                    element.value = text;
                    element.setAttribute("value", text);
                }
            });
            exports_15("onblurLatLon", onblurLatLon = (element) => {
                if (isNaN(+element.value))
                    return;
                onchangeLatLon(element);
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-action", [], function (exports_16, context_16) {
    "use strict";
    var renderActionButtons, renderActionButtons2, renderButtons, renderButtonsInline, renderInlineActionButtons, buttonCancelInline, buttonInsertInline, buttonDeleteInline, buttonAddNewInline, buttonUpdateInline, renderListActionButtons, renderListActionButtons2, renderListFloatingActionButtons, buttonCancel, buttonInsert, buttonDelete, buttonAddNew, buttonUpdate, buttonUpdateNoDone, buttonUpload;
    var __moduleName = context_16 && context_16.id;
    return {
        setters: [],
        execute: function () {
            exports_16("renderActionButtons", renderActionButtons = (ns, isNew, addUrl, buttons = null, updateOnly = false) => {
                let buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("&nbsp;") : "");
                return `
    <div class="level js-actions">
        <div class="level-left">
            <div class="level-item">
                <div class="buttons">
                    ${buttonsHtml}
                </div>
            </div>
        </div>
        <div class="level-right">
            <div class="level-item">
                <div class="buttons">
                    <button class="button is-outlined" onclick="${ns}.cancel()"><!--<span class="icon"><i class="fa fa-reply"></i></span>--><span>${i18n("Cancel")}</span></button>
${isNew && !updateOnly ? `
                    <button class="button is-primary is-outlined" onclick="${ns}.create()"><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Insert")}</span></button>
` : `
${!updateOnly ? `
                    <button class="button is-danger is-outlined" onclick="App_Theme.openModal('modalDelete_${ns}')"><span class="icon"><i class="fa fa-times"></i></span><span>${i18n("Delete")}</span></button>
                    <a class="button is-primary is-outlined" href="${addUrl}"><span class="icon"><i class="fa fa-plus"></i></span><span>${i18n("Add New")}</span></a>
` : ``}
                    <button class="button is-primary is-outlined" onclick="${ns}.save()"><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Update")}</span></button>
                    <button class="button is-primary is-outlined" onclick="${ns}.save(true)"><span class="icon"><i class="fa fa-reply"></i></span><span>${i18n("Done")}</span></button>
                </div>
            </div>
`}
        </div>
    </div>
`;
            });
            exports_16("renderActionButtons2", renderActionButtons2 = (ns, isNew, addUrl, buttons = null, canDelete = true, canAdd = true) => {
                let buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("") : "");
                return `
    <div class="buttons">
        ${buttonsHtml}
        <button class="button" onclick="${ns}.cancel()"><!--<span class="icon"><i class="fa fa-reply"></i></span>--><span>${i18n("Cancel")}</span></button>
${isNew && canAdd ? `
        <button class="button is-primary" onclick="${ns}.create()"><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Insert")}</span></button>
` : `
        ${canDelete ? `
                <button class="button is-danger" onclick="App_Theme.openModal('modalDelete_${ns}')"><span class="icon"><i class="fa fa-times"></i></span><span>${i18n("Delete")}</span></button>
        ` : ``}
        ${canAdd ? `
                <a class="button is-primary" href="${addUrl}"><span class="icon"><i class="fa fa-plus"></i></span><span>${i18n("Add New")}</span></a>
        ` : ``}
        <button class="button is-primary" onclick="${ns}.save()"><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Update")}</span></button>
        <button class="button is-primary" onclick="${ns}.save(true)"><span class="icon"><i class="fa fa-reply"></i></span><span>${i18n("Done")}</span></button>
`}
    </div>
`;
            });
            exports_16("renderButtons", renderButtons = (buttons) => {
                let buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("") : "");
                return `
    <div class="buttons">
        ${buttonsHtml}
    </div>
`;
            });
            exports_16("renderButtonsInline", renderButtonsInline = (buttons) => {
                let buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("") : "");
                return `
    <div class="js-actions js-flex-end">
        <div class="buttons are-small">
            ${buttonsHtml}
        </div>
    </div>
`;
            });
            exports_16("renderInlineActionButtons", renderInlineActionButtons = (ns, isNew, disableDelete, disableAddNew, disableUpdate) => {
                return `
    <div class="js-actions js-flex-end">
        <div class="buttons are-small">
            <button class="button is-outlined" onclick="${ns}.undo()"><span class="icon"><i class="fa fa-undo"></i></span><span>${i18n("Undo")}</span></button>
${!disableDelete ? `
            <a class="button is-danger is-outlined" ${disableDelete ? "disabled" : `onclick="${ns}.drop()"`}><span class="icon"><i class="fa fa-times"></i></span><span>${i18n("Delete")}</span></a>
` : ``}
${!disableAddNew ? `
            <a class="button is-primary is-outlined" ${disableAddNew ? "disabled" : `onclick="${ns}.addNew()"`}><span class="icon"><i class="fa fa-plus"></i></span><span>${i18n("Add New")}</span></a>
` : ``}
${isNew && !disableUpdate ? `
            <a class="button is-primary is-outlined" ${disableUpdate ? "disabled" : `onclick="${ns}.create()"`}><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Insert")}</span></a>
` : `
${!disableUpdate ? `
            <a class="button is-primary is-outlined" ${disableUpdate ? "disabled" : `onclick="${ns}.save()"`}><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Update")}</span></a>
` : ``}
`}
        </div>
    </div>
`;
            });
            exports_16("buttonCancelInline", buttonCancelInline = (ns) => {
                return `<button class="button is-outlined" onclick="${ns}.undo()"><span class="icon"><i class="fa fa-undo"></i></span><span>${i18n("Undo")}</span></button>`;
            });
            exports_16("buttonInsertInline", buttonInsertInline = (ns) => {
                return `<a class="button is-primary is-outlined" onclick="${ns}.create()><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Insert")}</span></a>`;
            });
            exports_16("buttonDeleteInline", buttonDeleteInline = (ns) => {
                return `<a class="button is-danger is-outlined" onclick="${ns}.drop()"><span class="icon"><i class="fa fa-times"></i></span><span>${i18n("Delete")}</span></a>`;
            });
            exports_16("buttonAddNewInline", buttonAddNewInline = (ns, addUrl) => {
                return `<a class="button is-primary is-outlined" onclick="${ns}.addNew()"><span class="icon"><i class="fa fa-plus"></i></span><span>${i18n("Add New")}</span></a>`;
            });
            exports_16("buttonUpdateInline", buttonUpdateInline = (ns) => {
                return `<a class="button is-primary is-outlined" onclick="${ns}.save()"><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Update")}</span></a>`;
            });
            exports_16("renderListActionButtons", renderListActionButtons = (ns, label, buttons = null) => {
                let buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("&nbsp;") : "");
                return `
    <div class="level js-actions">
        <div class="level-left">
            ${buttonsHtml}
        </div>
${label != null ? `
        <div class="level-right">
            <div class="level-item">
                <div class="buttons">
                    <button class="button is-primary is-outlined" onclick="${ns}.create()"><span class="icon"><i class="fa fa-plus"></i></span><span>${label}</span></button>
                </div>
            </div>
        </div>
` : ``}
    </div>
    `;
            });
            exports_16("renderListActionButtons2", renderListActionButtons2 = (ns, label, buttons = null) => {
                let buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("&nbsp;") : "");
                return `
    <div class="buttons">
        ${buttonsHtml}
        ${label ? `<button class="button is-primary" onclick="${ns}.create()"><span class="icon"><i class="fa fa-plus"></i></span><span>${label}</span></button>` : ``}
    </div>
`;
            });
            exports_16("renderListFloatingActionButtons", renderListFloatingActionButtons = (ns, label) => {
                return `
        <button class="button is-primary is-rounded js-floating" title="${label}" onclick="${ns}.create()"><span class="icon"><i class="fa fa-plus"></i></span></button>
    `;
            });
            exports_16("buttonCancel", buttonCancel = (ns) => {
                return `<button class="button" onclick="${ns}.cancel()"><span>${i18n("Cancel")}</span></button>`;
            });
            exports_16("buttonInsert", buttonInsert = (ns, label = "Insert") => {
                return `<button class="button is-primary" onclick="${ns}.create()"><span class="icon"><i class="fa fa-check"></i></span><span>${i18n(label)}</span></button>`;
            });
            exports_16("buttonDelete", buttonDelete = (ns) => {
                return `<button class="button is-danger" onclick="App_Theme.openModal('modalDelete_${ns}')"><span class="icon"><i class="fa fa-times"></i></span><span>${i18n("Delete")}</span></button>`;
            });
            exports_16("buttonAddNew", buttonAddNew = (ns, addUrl, label = null) => {
                return `<a class="button is-primary" href="${addUrl}"><span class="icon"><i class="fa fa-plus"></i></span><span>${label ? label : i18n("Add New")}</span></a>`;
            });
            exports_16("buttonUpdate", buttonUpdate = (ns, disabled = false) => {
                return `<button class="button is-primary" ${disabled ? "disabled" : ""} onclick="${ns}.save()"><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Update")}</span></button>
            <button class="button is-primary" ${disabled ? "disabled" : ""} onclick="${ns}.save(true)"><span class="icon"><i class="fa fa-reply"></i></span><span>${i18n("Done")}</span></button>
`;
            });
            exports_16("buttonUpdateNoDone", buttonUpdateNoDone = (ns, disabled = false) => {
                return `<button class="button is-primary" ${disabled ? "disabled" : ""} onclick="${ns}.save()"><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Update")}</span></button>
`;
            });
            exports_16("buttonUpload", buttonUpload = (ns, disabled = false, label = "Upload File") => {
                return `<button class="button is-primary" ${disabled ? "disabled" : ""} onclick="${ns}.create()"><span class="icon"><i class="far fa-cloud-upload-alt"></i></span><span>${i18n(label)}</span></button>`;
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-checkbox", [], function (exports_17, context_17) {
    "use strict";
    var renderCheckboxField, renderCheckboxInline, renderCheckboxFilter, renderCheckboxListField, rawCheckbox, rawToggle;
    var __moduleName = context_17 && context_17.id;
    return {
        setters: [],
        execute: function () {
            exports_17("renderCheckboxField", renderCheckboxField = (ns, propName, value, label, text, help, disabled = false) => {
                return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label">${label}</label></div>
        <div class="field-body">
            ${renderCheckboxInline(ns, propName, value, label, (text == undefined ? label : text), help, disabled)}
        </div>
    </div>`;
            });
            exports_17("renderCheckboxInline", renderCheckboxInline = (ns, propName, value, label = "", text = "", help, disabled = false) => {
                return `
    <div class="field">
        ${rawCheckbox(ns, propName, value, text, disabled)}
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
            });
            exports_17("renderCheckboxFilter", renderCheckboxFilter = (ns, propName, value, label = "", text) => {
                return `
    <div class="field">
        <label class="label">${label}</label>
        <div class="field-body">
            <label class="checkbox">
                <input type="checkbox" onchange="${ns}.filter_${propName}(this)" ${value ? "checked" : ""}> ${text}
            </label>
        </div>
    </div>`;
            });
            exports_17("renderCheckboxListField", renderCheckboxListField = (ns, propName, maskValue, label, list) => {
                const checkboxTemplate = (entry) => {
                    let selected = (+entry.code & maskValue) != 0;
                    return `
        <div>
            <label class="checkbox">
                <input type="checkbox" ${selected ? "checked" : ""} name="${ns}_${propName}" onchange="${ns}.onchange(this)" data-mask="${entry.code}"> ${entry.description}
            </label>
        </div>`;
                };
                const checkboxes = list.reduce((html, one, index) => html + checkboxTemplate(one), "");
                return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            <div class="field js-checkbox-row">
                ${checkboxes}
            </div>
        </div>
    </div>
`;
            });
            exports_17("rawCheckbox", rawCheckbox = (ns, propName, value, text, disabled = false) => {
                return `
    <div class="control">
        <label class="checkbox ${disabled ? "js-disabled" : ""}">
            <input type="checkbox" id="${ns}_${propName}" onchange="${ns}.onchange(this)" ${value ? "checked" : ""} ${disabled ? "disabled" : ""}> ${text}
        </label>
    </div>`;
            });
            exports_17("rawToggle", rawToggle = (ns, propName, value, text_on, text_off) => {
                return `
<div class="js-toggle">
    <label for="${ns}_${propName}">${value ? text_on : text_off}</label>
    <input type="checkbox" id="${ns}_${propName}" onchange="${ns}.onchange(this)" ${value ? "checked" : ""}>
</div>
`;
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-dropdown", [], function (exports_18, context_18) {
    "use strict";
    var renderDropdownField, renderDropdownInline, renderDropdownExInline, renderDropdownNaked, renderDropdownFilter, renderOptions, renderOptionsShowCode, renderOptionsShowBoth, renderOptionsFun, renderItems, renderNullableBooleanOptions, renderNullableBooleanOptionsReverse, renderDatalistOptions;
    var __moduleName = context_18 && context_18.id;
    return {
        setters: [],
        execute: function () {
            exports_18("renderDropdownField", renderDropdownField = (ns, propName, options, label, required = false, size = "js-width-50", help, disabled = false) => {
                return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            <div class="field">
                <div class="select ${size}">
                    ${renderDropdownNaked(ns, propName, options, required, disabled)}
                </div>
                ${help != undefined ? `<p class="help">${help}</p>` : ``}
            </div>
        </div>
    </div>`;
            });
            exports_18("renderDropdownInline", renderDropdownInline = (ns, propName, options, required = false, disabled = false) => {
                return `
    <div class="field">
        <div class="select">
            <select id="${ns}_${propName}" 
onchange="${ns}.onchange(this)" 
${required ? "required='required'" : ""}
${disabled ? "disabled tabindex='-1'" : ""}>
                ${options}
            </select>
        </div>
    </div>
`;
            });
            exports_18("renderDropdownExInline", renderDropdownExInline = (ns, propName, text, items, option) => {
                return `
    <div class="field">
<div class="dropdown ${option.hoverable ? "is-hoverable" : ""}" ${!option.hoverable ? `onclick="this.classList.toggle('is-active')"` : ""}>
    <div class="dropdown-trigger">
        <div aria-controls="dropdown-menu-${propName}">
            <span>${text}</span>
            <span class="icon is-small">
                <i class="fas fa-angle-down" aria-hidden="true"></i>
            </span>
        </div>
    </div>
    <div class="dropdown-menu" id="dropdown-menu-${propName}" role="menu">
        <div class="dropdown-content">
            ${items}
        </div>
    </div>
</div>
    </div>
`;
            });
            exports_18("renderDropdownNaked", renderDropdownNaked = (ns, propName, options, required = false, disabled = false) => {
                return `
    <select id="${ns}_${propName}" onchange="${ns}.onchange(this)" ${required ? "required='required'" : ""} ${disabled ? "disabled tabindex='-1'" : ""}>
        ${options}
    </select>`;
            });
            exports_18("renderDropdownFilter", renderDropdownFilter = (ns, propName, options, label, required = false, size = "", help) => {
                return `
    <div class="field">
        <label class="label ${required ? "js-required" : ""}">${label}</label>
        <div class="control">
            <div class="select">
                <select onchange="${ns}.filter_${propName}(this)" ${required ? "required='required'" : ""}>
                    ${options}
                </select>
            </div>
        </div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
            });
            exports_18("renderOptions", renderOptions = (list, selectedId, hasEmptyOption, emptyText = "") => {
                return renderOptionsFun(list, selectedId, hasEmptyOption, emptyText, (item) => item.description);
            });
            exports_18("renderOptionsShowCode", renderOptionsShowCode = (list, selectedId, hasEmptyOption, emptyText = "") => {
                return renderOptionsFun(list, selectedId, hasEmptyOption, emptyText, (item) => item.code);
            });
            exports_18("renderOptionsShowBoth", renderOptionsShowBoth = (list, selectedId, hasEmptyOption, emptyText = "") => {
                return renderOptionsFun(list, selectedId, hasEmptyOption, emptyText, (item) => `${item.code}     ${item.description}`);
            });
            exports_18("renderOptionsFun", renderOptionsFun = (list, selectedId, hasEmptyOption, emptyText = "", fun) => {
                if (hasEmptyOption) {
                    let emptySelected = (selectedId == undefined) || (list.findIndex(one => one.id == selectedId) == -1);
                    return list.reduce((html, entry) => {
                        let selected = (selectedId != undefined && selectedId == entry.id);
                        return html + `<option value="${entry.id}" ${selected ? "selected" : ""}>${fun(entry)}</option>`;
                    }, `<option value="" ${emptySelected ? "selected" : ""}>${emptyText}</option>`);
                }
                else
                    return list.reduce((html, entry, index) => {
                        let selected = (selectedId != undefined && selectedId == entry.id);
                        selected = selected || (selectedId == undefined && index == 0);
                        return html + `<option value="${entry.id}" ${selected ? "selected" : ""}>${fun(entry)}</option>`;
                    }, "");
            });
            exports_18("renderItems", renderItems = (list, selectedId, hasEmptyOption, emptyText = "") => {
                if (hasEmptyOption) {
                    let emptySelected = (selectedId == undefined) || (list.findIndex(one => one.id == selectedId) == -1);
                    return list.reduce((html, entry) => {
                        let selected = (selectedId != undefined && selectedId == entry.id);
                        return html + `<div data-value="${entry.id}" class="dropdown-item ${selected ? "is-active" : ""}">${entry.description}</div>`;
                    }, `<div data-value="" class="dropdown-item ${emptySelected ? "is-active" : ""}">${emptyText}</div>`);
                }
                else
                    return list.reduce((html, entry, index) => {
                        let selected = (selectedId != undefined && selectedId == entry.id);
                        selected = selected || (selectedId == undefined && index == 0);
                        return html + `<div data-value="${entry.id}" class="dropdown-item ${selected ? "is-active" : ""}">${entry.description}</div>`;
                    }, "");
            });
            exports_18("renderNullableBooleanOptions", renderNullableBooleanOptions = (value, description) => {
                return `
    <option value="" ${value == undefined ? "selected" : ""}>${description[0]}</option>
    <option value="true" ${value != undefined && value ? "selected" : ""}>${description[1]}</option>
    <option value="false" ${value != undefined && !value ? "selected" : ""}>${description[2]}</option>
    `;
            });
            exports_18("renderNullableBooleanOptionsReverse", renderNullableBooleanOptionsReverse = (value, description) => {
                return `
    <option value="false" ${value != undefined && !value ? "selected" : ""}>${description[2]}</option>
    <option value="true" ${value != undefined && value ? "selected" : ""}>${description[1]}</option>
    <option value="" ${value == undefined ? "selected" : ""}>${description[0]}</option>
    `;
            });
            exports_18("renderDatalistOptions", renderDatalistOptions = (list) => {
                return list.reduce((html, entry) => {
                    return html + `<option value="${entry.description}">`;
                }, "");
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-select", [], function (exports_19, context_19) {
    "use strict";
    var rawSelect;
    var __moduleName = context_19 && context_19.id;
    return {
        setters: [],
        execute: function () {
            exports_19("rawSelect", rawSelect = (ns, propName, options, option) => {
                return `
<div class="control ${option.size || ""}">
    <div class="select" style="width:100%">
        <select id="${ns}_${propName}" style="width:100%" onchange="${ns}.onchange(this)" ${option.required ? "required='required'" : ""} ${option.disabled ? "disabled tabindex='-1'" : ""}>
            ${options}
        </select>
    </div>
</div>`;
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-radio", [], function (exports_20, context_20) {
    "use strict";
    var renderRadioField, renderRadios;
    var __moduleName = context_20 && context_20.id;
    return {
        setters: [],
        execute: function () {
            exports_20("renderRadioField", renderRadioField = (radios, label, disabled = false) => {
                return `
    <div class="field is-horizontal js-radio">
        <div class="field-label"><label class="label">${label}</label></div>
        <div class="field-body">
            <div class="control ${disabled ? "js-disabled" : ""}">
                ${radios}
            </div>
        </div>
    </div>`;
            });
            exports_20("renderRadios", renderRadios = (ns, propName, list, selectedId, hasEmptyOption, emptyText = "") => {
                if (hasEmptyOption) {
                    return list.reduce((html, entry) => {
                        let checked = (selectedId != undefined && selectedId == entry.id);
                        let disabled = (entry.disabled != undefined && entry.disabled);
                        return html + `
            <label class="radio ${disabled ? "js-disabled" : ""}">
                <input type="radio" name="${ns}_${propName}" data-value="${entry.id}" onchange="${ns}.onchange(this)" ${checked ? "checked" : ""} ${disabled ? "disabled" : ""}>
                ${entry.description}
            </label>`;
                    }, `<label class="radio">
                <input type="radio" name="${ns}_${propName}" data-value="" onchange="${ns}.onchange(this)" ${selectedId == undefined ? "checked" : ""}>
                ${emptyText}
            </label>`);
                }
                else {
                    return list.reduce((html, entry, index) => {
                        let checked = (selectedId != undefined && selectedId == entry.id);
                        checked = checked || (selectedId == undefined && index == 0);
                        let disabled = (entry.disabled != undefined && entry.disabled);
                        return html + `
            <label class="radio ${disabled ? "js-disabled" : ""}">
                <input type="radio" name="${ns}_${propName}" data-value="${entry.id}" onchange="${ns}.onchange(this)" ${checked ? "checked" : ""} ${disabled ? "disabled" : ""}>
                ${entry.description}
            </label>`;
                    }, "");
                }
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-filter", ["_BaseApp/src/lib-ts/misc"], function (exports_21, context_21) {
    "use strict";
    var Misc, renderNumberFilter, renderDateFilter, renderDateChanger;
    var __moduleName = context_21 && context_21.id;
    return {
        setters: [
            function (Misc_4) {
                Misc = Misc_4;
            }
        ],
        execute: function () {
            exports_21("renderNumberFilter", renderNumberFilter = (ns, propName, value, label = "", required = false, help) => {
                return `
    <div class="field">
        <label class="label ${required ? "js-required" : ""}">${label}</label>
        <div class="control" style="width: 100px">
            <input type="number" class="input" id="${ns}_${propName}" value="${Misc.toInputNumber(value)}" onchange="${ns}.filter_${propName}(this)" ${required ? "required='required'" : ""}>
        </div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
            });
            exports_21("renderDateFilter", renderDateFilter = (ns, propName, value, label = "", required = false, help, min = null, max = null) => {
                return `
    <div class="field">
        <label class="label ${required ? "js-required" : ""}">${label}</label>
        <div class="control">
            <input type="date" class="input"
id="${ns}_${propName}" 
value="${Misc.toInputDate(value)}" 
onchange="${ns}.filter_${propName}(this)" 
${required ? "required='required'" : ""}
${min ? `min="${Misc.toInputDate(min)}"` : ""}
${max ? `max="${Misc.toInputDate(max)}"` : ""}
${required ? "required='required'" : ""}>
        </div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
            });
            exports_21("renderDateChanger", renderDateChanger = (ns, propName, disabled = false) => {
                return `
<div class="field" style="margin-left: -0.75rem;">
    <label class="label">&nbsp;</label>
    <div class="buttons has-addons">
        <button class="button" ${disabled ? "disabled" : ""} onclick="${ns}.filter_${propName}(this, 'previous')"><i class="fas fa-angle-left"></i></button>
        <button class="button" ${disabled ? "disabled" : ""} onclick="${ns}.filter_${propName}(this, 'next')"><i class="fas fa-angle-right"></i></button>
    </div>
</div>
`;
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-number", ["_BaseApp/src/lib-ts/misc"], function (exports_22, context_22) {
    "use strict";
    var Misc, renderNumberField, renderNumberInline, renderDecimalField, renderDecimalInline, renderNumberField2, renderNumberInline2;
    var __moduleName = context_22 && context_22.id;
    return {
        setters: [
            function (Misc_5) {
                Misc = Misc_5;
            }
        ],
        execute: function () {
            exports_22("renderNumberField", renderNumberField = (ns, propName, value, label, required = false, size = "js-width-10", help) => {
                return `
<div class="field is-horizontal">
    <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
    <div class="field-body">
        <div class="field">
            <div class="control ${size}">
                <input type="number" class="input has-text-right"
                    id="${ns}_${propName}" 
                    value="${Misc.toInputNumber(value)}" 
                    onchange="${ns}.onchange(this)" 
                    ${required ? "required='required'" : ""}>
            </div>
            ${help != undefined ? `<p class="help">${help}</p>` : ``}
        </div>
    </div>
</div>`;
            });
            exports_22("renderNumberInline", renderNumberInline = (ns, propName, value, required = false, disabled = false) => {
                return `
<div class="field">
    <div class="control">
        <input type="number" class="input has-text-right"
            id="${ns}_${propName}" 
            value="${Misc.toInputNumber(value)}" 
            onchange="${ns}.onchange(this)" 
            min="0"
            ${required ? "required='required'" : ""}
            ${disabled ? "tabindex='-1'" : ""}>
    </div>
</div>`;
            });
            exports_22("renderDecimalField", renderDecimalField = (ns, propName, value, label, option) => {
                return `
<div class="field is-horizontal">
    <div class="field-label"><label class="label ${option.required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
    <div class="field-body">
        ${renderDecimalInline(ns, propName, value, option)}
    </div>
</div>`;
            });
            exports_22("renderDecimalInline", renderDecimalInline = (ns, propName, value, option) => {
                let hasAddonStatic = (option.addonStatic != undefined);
                let hasAddon = (option.addon != undefined);
                return `
<div class="field">
    <div class="field ${hasAddon || hasAddonStatic ? "has-addons" : ""}" style="margin-bottom:0;">
        <div class="control ${option.size ? option.size : ""}">
            <input type="text" class="input has-text-right"
                id="${ns}_${propName}" 
                value="${Misc.toStaticNumberDecimal(value, option.places, true)}" 
                onchange="${ns}.onchange(this)" 
                ${option.required ? "required='required'" : ""}
                ${option.disabled ? "disabled tabindex='-1'" : ""}
                ${option.places ? `pattern="^${option.allowNegative ? "(-)?" : ""}[0-9]+(\\.[0-9]{0,${option.places}})?$"` : ""}
                ${option.autoselect ? `onfocus="this.select()"` : ""} >
        </div>
${hasAddonStatic ? `
        <div class="control">
            <a class="button js-static">
                ${option.addonStatic}
            </a>
        </div>
` : ``}
${hasAddon ? `
        <div class="control">
            ${option.addon}
        </div>
` : ``}
    </div>
    ${option.help != undefined ? `<p class="help">${option.help}</p>` : ``}
</div>`;
            });
            exports_22("renderNumberField2", renderNumberField2 = (ns, propName, value, label, option) => {
                return `
<div class="field is-horizontal">
    <div class="field-label"><label class="label ${option.required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
    <div class="field-body">
        ${renderNumberInline2(ns, propName, value, option)}
    </div>
</div>`;
            });
            exports_22("renderNumberInline2", renderNumberInline2 = (ns, propName, value, option) => {
                let hasAddonStatic = (option.addonStatic != undefined);
                let hasAddon = (option.addon != undefined);
                return `
<div class="field">
    <div class="field ${hasAddon || hasAddonStatic ? "has-addons" : ""}" style="margin-bottom:0;">
        <div class="control ${option.size ? option.size : ""}">
            <input type="number" class="input has-text-right"
                id="${ns}_${propName}" 
                value="${Misc.toInputNumber(value)}"
                onchange="${ns}.onchange(this)"
                ${option.required ? "required='required'" : ""}
                ${option.min != undefined ? `min=${option.min}` : ""}
                ${option.max != undefined ? `max=${option.max}` : ""}
                ${option.step ? `step=${option.step}` : ""}
                ${option.disabled ? "disabled tabindex='-1'" : ""}>
        </div>
${hasAddonStatic ? `
        <div class="control">
            <a class="button js-static">
                ${option.addonStatic}
            </a>
        </div>
` : ``}
${hasAddon ? `
        <div class="control">
            ${option.addon}
        </div>
` : ``}
    </div>
    ${option.help != undefined ? `<p class="help">${option.help}</p>` : ``}
</div>`;
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-latlong", ["_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/latlong"], function (exports_23, context_23) {
    "use strict";
    var Misc, latlong_1, renderDDMMCC, renderLatField, renderLongField, renderLatLongInline;
    var __moduleName = context_23 && context_23.id;
    return {
        setters: [
            function (Misc_6) {
                Misc = Misc_6;
            },
            function (latlong_1_1) {
                latlong_1 = latlong_1_1;
            }
        ],
        execute: function () {
            exports_23("renderDDMMCC", renderDDMMCC = (ns, isDDMMCC) => {
                return `
<div class="field is-horizontal">
    <div class="field-label">
        <label class="label">&nbsp;</label>
    </div>
    <div class="field-body">
        <div class="field">
            <div class="control">
                <label class="checkbox">
                    <input type="checkbox" onchange="${ns}.onDDMMCC(this)" ${isDDMMCC ? "checked" : ""}> Enter latitude and longitude using <b>DD MM.CC</b> instead of <b>DD MM SS</b>
                </label>
            </div>
        </div>
    </div>
</div>
`;
            });
            exports_23("renderLatField", renderLatField = (ns, propName, value, label, required = false, size = "", help, isDDMMCC = false) => {
                return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            ${renderLatLongInline(ns, propName, value, required, size, help, false, isDDMMCC)}
        </div>
    </div>`;
            });
            exports_23("renderLongField", renderLongField = (ns, propName, value, label, required = false, size = "", help, isDDMMCC = false) => {
                return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            ${renderLatLongInline(ns, propName, value, required, size, help, true, isDDMMCC)}
        </div>
    </div>`;
            });
            exports_23("renderLatLongInline", renderLatLongInline = (ns, propName, value, required = false, size = "", help, isLongitude = false, isDDMMCC = false) => {
                return `
    <div class="field has-addons">
        <div class="control ${size}">
            <input type="text" class="input js-no-spinner"
                id="${ns}_${propName}" 
                data-islongitude="${isLongitude}"
                data-isddmmcc="${isDDMMCC ? "true" : "false"}"
                value="${isDDMMCC ? Misc.toInputLatLongDDMMCC(value) : Misc.toInputLatLong(value)}" 
                onfocus="${latlong_1.NS}.onfocusLatLon(this)"
                onchange="${latlong_1.NS}.onchangeLatLon(this); ${ns}.onchange(this);"
                onblur="${latlong_1.NS}.onblurLatLon(this)"
                ${required ? "required='required'" : ""}
                autocomplete="off">
        </div>
${isDDMMCC ? `
        <div class="control">
            <a class="button js-static">${Misc.toInputLatLong(value)}</a>
        </div>
` : ``}
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>
`;
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-text", ["_BaseApp/src/lib-ts/misc"], function (exports_24, context_24) {
    "use strict";
    var Misc, renderTextField, renderTextField2, renderTextInline, renderTextInline2, renderTextareaField, renderTextareaField_V, renderTextareaInline, renderTextareaFieldWithMarkdown, rawText;
    var __moduleName = context_24 && context_24.id;
    return {
        setters: [
            function (Misc_7) {
                Misc = Misc_7;
            }
        ],
        execute: function () {
            exports_24("renderTextField", renderTextField = (ns, propName, value, label, maxlength, required = false, size = "", help) => {
                return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            ${renderTextInline(ns, propName, value, maxlength, required, size, help)}
        </div>
    </div>`;
            });
            exports_24("renderTextField2", renderTextField2 = (ns, propName, value, label, maxlength, option) => {
                return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${option.required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            ${renderTextInline2(ns, propName, value, maxlength, option)}
        </div>
    </div>`;
            });
            exports_24("renderTextInline", renderTextInline = (ns, propName, value, maxlength, required = false, size = "", help, datalist) => {
                return `
    <div class="field">
        <div class="control ${size}">
            <input type="text" class="input" id="${ns}_${propName}" value="${Misc.toInputText(value)}" onchange="${ns}.onchange(this)" ${maxlength != undefined ? `maxlength="${maxlength}"` : ""} ${required ? "required='required'" : ""} ${datalist ? `list="${datalist}"` : ""}>
        </div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
            });
            exports_24("renderTextInline2", renderTextInline2 = (ns, propName, value, maxlength, option) => {
                let hasAddonStatic = (option.addonStatic != undefined);
                let hasAddon = (option.addon != undefined);
                let hasAddonHead = (option.addonHead != undefined);
                return `
    <div class="field">
    <div class="field ${hasAddon || hasAddonStatic || hasAddonHead ? "has-addons" : ""}" style="margin-bottom:0;">
${hasAddonHead ? `
        <p class="control">
            ${option.addonHead}
        </p>
` : ``}
        <div class="control ${option.size != undefined ? option.size : ""}">
            <input type="text" class="input" id="${ns}_${propName}" value="${Misc.toInputText(value)}" 
                onchange="${ns}.onchange(this)"
                ${maxlength != undefined ? `maxlength="${maxlength}"` : ""}
                ${option.required ? "required='required'" : ""}
                ${option.noautocomplete ? "autocomplete='off'" : ""}
                ${option.disabled ? "disabled" : ""}
                ${option.listid ? `list="${option.listid}"` : ""}>
        </div>
${hasAddonStatic ? `
        <div class="control">
            <a class="button js-static" ${option.addonHref != undefined ? `href="${option.addonHref}"` : ``}>
                ${option.addonStatic}
            </a>
        </div>
` : ``}
${hasAddon ? `
        <div class="control">
            ${option.addon}
        </div>
` : ``}
    </div>
    ${option.help != undefined ? `<p class="help">${option.help}</p>` : ``}
    </div>`;
            });
            exports_24("renderTextareaField", renderTextareaField = (ns, propName, value, label, maxlength = 0, required = false, help, rows = 2) => {
                return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            ${renderTextareaInline(ns, propName, value, maxlength, required, help, rows)}
        </div>
    </div>`;
            });
            exports_24("renderTextareaField_V", renderTextareaField_V = (ns, propName, value, label, maxlength = 0, required = false, help, rows = 2, event = "onchange") => {
                return `
    <div class="field">
        <label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label>
        <div class="control">
            <textarea class="textarea" rows="${rows}" spellcheck="false" id="${ns}_${propName}" ${event}="${ns}.${event}(this, event)" maxlength="${maxlength}" ${required ? "required='required'" : ""}>${Misc.toInputText(value)}</textarea>
        </div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
            });
            exports_24("renderTextareaInline", renderTextareaInline = (ns, propName, value, maxlength = 0, required = false, help, rows = 2) => {
                return `
    <div class="field">
        <div class="control">
            <textarea class="textarea" rows="${rows}" spellcheck="false" id="${ns}_${propName}" onchange="${ns}.onchange(this)" ${maxlength > 0 ? `maxlength="${maxlength}"` : ``} ${required ? "required='required'" : ""}>${Misc.toInputText(value)}</textarea>
        </div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
            });
            exports_24("renderTextareaFieldWithMarkdown", renderTextareaFieldWithMarkdown = (ns, propName, value, label, maxlength = 0, required = false, help, rows = 2, showHtml = false) => {
                return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            <div class="field">
                <div class="js-wrap-markdown" style="background-color: yellow; position: relative;">
                    <div class="control">
                        <textarea class="textarea" rows="${rows}" spellcheck="false" id="${ns}_${propName}" onchange="${ns}.onchange(this)" ${maxlength > 0 ? `maxlength="${maxlength}"` : ``} ${required ? "required='required'" : ""}>${Misc.toInputText(value)}</textarea>
                    </div>
                    <div style="position:absolute; top:0; left:0; width:100%; height:100%; overflow:auto; padding:0 8px; background-color:white; border: 1px solid #e7eaec; ${!showHtml ? `display:none;` : ""}">
                        ${marked(value || "")}
                    </div>
                </div>
                ${help != undefined ? `<p class="help">${help}</p>` : ``}
            </div>
        </div>
    </div>`;
            });
            exports_24("rawText", rawText = (ns, propName, value, option) => {
                return `
<input type="text" class="input ${option.size || ""} ${option.class || ""}" ${option.style ? `style="${option.style}"` : ""} id="${ns}_${propName}" value="${Misc.toInputText(value)}" onchange="${ns}.onchange(this)" ${option.max != undefined ? `maxlength="${option.max}"` : ""} ${option.required ? "required='required'" : ""}>
`;
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-date", ["_BaseApp/src/lib-ts/misc"], function (exports_25, context_25) {
    "use strict";
    var Misc, renderDateInline, renderDateField, renderDateTimeField, renderDateExInline;
    var __moduleName = context_25 && context_25.id;
    return {
        setters: [
            function (Misc_8) {
                Misc = Misc_8;
            }
        ],
        execute: function () {
            exports_25("renderDateInline", renderDateInline = (ns, propName, value, option) => {
                return `
    <div class="field">
        <div class="control">
            <input type="date" class="input"
id="${ns}_${propName}" 
value="${Misc.toInputDate(value)}" 
${option.min ? `min="${option.min}"` : ""}
${option.max ? `max="${option.max}"` : ""}
onchange="${ns}.onchange(this)" 
${option.required ? "required='required'" : ""}
${option.disabled ? "tabindex='-1' style='pointer-events:none'" : ""}>
        </div>
    </div>`;
            });
            renderDateField = (ns, propName, value, label, option) => {
                return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${option.required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            <div class="field">
                <!--<div class="field has-addons">-->
                <div class="field">
                    <div class="control ${option.size ? option.size : "js-width-20"}">
                        <input type="date" class="input" 
                            id="${ns}_${propName}" 
                            value="${Misc.toInputDate(value)}" 
                            onchange="${ns}.onchange(this)" 
                            ${option.required ? "required='required'" : ""}>
                    </div>
<!--
                    <div class="control">
                        <a class="button">
                            <i class="far fa-calendar-alt"></i>
                        </a>
                    </div>
-->
                </div>
                ${option.help ? `<p class="help">${option.help}</p>` : ``}
            </div>
        </div>
    </div>`;
            };
            renderDateTimeField = (ns, propName, value, label, option) => {
                return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${option.required ? "js-required" : ""}" for="${ns}_${propName}">${label}</label></div>
        <div class="field-body">
            <div class="field">
                <div class="field">
                    <div class="control" style="display: inline-block;">
                        <input type="date" class="input" 
                            id="${ns}_${propName}" 
                            value="${Misc.toInputDate(value)}" 
                            ${option.min ? `min="${option.min}"` : ""}
                            ${option.max ? `max="${option.max}"` : ""}
                            onchange="${ns}.onchange(this)" 
                            ${option.required ? "required='required'" : ""}>
                    </div>
                    <div class="control" style="display: inline-block;">
                        <input type="time" class="input"
                            id="${ns}_${propName}_time" 
                            value="${Misc.toInputTimeHHMM(value)}" 
                            onchange="${ns}.onchange(this)" 
                            ${option.required ? "required='required'" : ""}>
                    </div>
                </div>
                ${option.help ? `<p class="help">${option.help}</p>` : ``}
            </div>
        </div>
    </div>`;
            };
            exports_25("renderDateExInline", renderDateExInline = (ns, propName, value, option) => {
                return `
    <div class="field">
        <div class="control" style="width: 90px;">
            <input type="text" class="input js-no-spinner" 
id="${ns}_${propName}" 
value="${Misc.toInputDate(value)}" 
${option.min ? `min="${option.min}"` : ""}
${option.max ? `max="${option.max}"` : ""}
onfocus="${ns}.ondate(this, 'focus')" onchange="${ns}.ondate(this, 'change')" onblur="${ns}.ondate(this, 'blur')" 
autocomplete="off"
${option.required ? "required='required'" : ""}
${option.disabled ? "tabindex='-1' style='pointer-events:none'" : ""}>
        </div>
    </div>`;
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-calendar", ["_BaseApp/src/lib-ts/misc"], function (exports_26, context_26) {
    "use strict";
    var Misc, renderCalendarField, renderCalendarFilter, renderCalendarInline;
    var __moduleName = context_26 && context_26.id;
    return {
        setters: [
            function (Misc_9) {
                Misc = Misc_9;
            }
        ],
        execute: function () {
            exports_26("renderCalendarField", renderCalendarField = (ns, propName, calendar, label, option = {}) => {
                let input_id = `${ns}_${propName}`;
                return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${calendar.required ? "js-required" : ""}" for="${input_id}">${label}</label></div>
        <div class="field-body">
            ${renderCalendarInline(ns, propName, calendar, option)}
        </div>
    </div>`;
            });
            exports_26("renderCalendarFilter", renderCalendarFilter = (ns, propName, calendar, label, option = {}) => {
                return `
    <div class="field">
        <label class="label ${option.required ? "js-required" : ""}">${label}</label>
${renderCalendarInline(ns, propName, calendar, option)}
    </div>`;
            });
            exports_26("renderCalendarInline", renderCalendarInline = (ns, propName, calendar, option) => {
                let input_id = `${ns}_${propName}`;
                return `
    <div id="${input_id}_wrapper" class="field-body">
    <div class="field">
        <div class="js-calendar">
            ${calendar.render()}
        </div>
        <div class="field has-addons">
            <div class="control" style="width: 90px;">
                <input type="text" class="input js-no-spinner" 
                    id="${input_id}" 
                    value="${Misc.toInputDate(calendar.dateValue)}" 
                    ${calendar.minValue ? `data-min="${Misc.toInputDate(calendar.minValue)}"` : ""}
                    ${calendar.maxValue ? `data-max="${Misc.toInputDate(calendar.maxValue)}"` : ""}
                    autocomplete="off"
                    ${calendar.required ? `required="required"` : ""} 
                    ${calendar.disableDate ? "disabled" : ""}>
            </div>

${calendar.hasTime ? `
            <div class="control" style="width: 60px;">
                <input type="text" class="input js-no-spinner"
                    id="${input_id}_time" 
                    value="${Misc.toInputTimeHHMM(calendar.dateValue)}" 
                    autocomplete="off"
                    ${calendar.required ? "required='required'" : ""}
                    ${calendar.isNullDate ? "disabled" : ""} >
            </div>
` : ""}

${!calendar.required && !calendar.disableDate ? `
            <div class="control">
                <button id="${input_id}_clear" class="button"><i class="far fa-times"></i></button>
            </div>
` : ""}

${!calendar.disableDate ? `
            <div class="control">
                <a id="${input_id}_popup" class="button"><i class="far fa-calendar-alt"></i></a>
            </div>
` : ""}

${calendar.hasChanger ? `
            <div class="control">
                <button id="${input_id}_previous" class="button" ${calendar.isNullDate ? "disabled" : ""}>
                    <i class="fas fa-angle-left"></i>${option.changerCaption ? "&nbsp;Previous Day" : ""}
                </button>
            </div>
            <div class="control">
                <button id="${input_id}_next" class="button" ${calendar.isNullDate ? "disabled" : ""}>
                    <i class="fas fa-angle-right"></i>${option.changerCaption ? "&nbsp;Next Day" : ""}
                </button>
            </div>
` : ""}

        </div>
        ${option.help ? `<p class="help">${option.help}</p>` : ""}
    </div>
    </div>`;
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-static", ["_BaseApp/src/lib-ts/misc"], function (exports_27, context_27) {
    "use strict";
    var Misc, renderStaticField, renderStaticField2, renderStaticHtmlField, renderStaticField_V, renderStaticInline, renderStaticInline2;
    var __moduleName = context_27 && context_27.id;
    return {
        setters: [
            function (Misc_10) {
                Misc = Misc_10;
            }
        ],
        execute: function () {
            exports_27("renderStaticField", renderStaticField = (value, label, help, required = false) => {
                return `
    <div class="field is-horizontal js-field-static">
        <div class="field-label"><label class="label ${required ? "js-required" : ""}">${label}</label></div>
        <div class="field-body">
            <div style="width: 100%; height: 2.534em; padding-top: 6px;">
                ${Misc.toInputText(value)}
                ${help != undefined ? `<p class="help">${help}</p>` : ``}
            </div>
        </div>
    </div>`;
            });
            exports_27("renderStaticField2", renderStaticField2 = (value, label, option) => {
                return `
<div class="field is-horizontal js-field-static">
    <div class="field-label"><label class="label">${label}</label></div>
    <div class="field-body">
        ${renderStaticInline2(value, option)}
    </div>
</div>`;
            });
            exports_27("renderStaticHtmlField", renderStaticHtmlField = (value, label, help) => {
                return `
    <div class="field is-horizontal js-field-static">
        <div class="field-label"><label class="label">${label}</label></div>
        <div class="field-body">
            <div style="width: 100%; padding-top: 6px;">
                ${value == undefined ? "" : value}
                ${help != undefined ? `<p class="help">${help}</p>` : ``}
            </div>
        </div>
    </div>`;
            });
            exports_27("renderStaticField_V", renderStaticField_V = (value, label, help, extraStyle = "") => {
                return `
    <div class="field">
        <label class="label">${label}</label>
        <div class="control" style="${extraStyle}">${Misc.toInputText(value)}</div>
        ${help != undefined ? `<p class="help">${help}</p>` : ``}
    </div>`;
            });
            exports_27("renderStaticInline", renderStaticInline = (value) => {
                return `
    <div class="field">
        <div class="field-body"><span>${value}</span></div>
    </div>`;
            });
            exports_27("renderStaticInline2", renderStaticInline2 = (value, option) => {
                let hasAddonStatic = (option.addonStatic != undefined);
                let hasAddon = (option.addon != undefined);
                return `
<div class="field" ${!hasAddon && !hasAddonStatic ? `style="padding-bottom: 6px;"` : ""}>
    <div class="field ${hasAddon || hasAddonStatic ? "has-addons" : ""}">
        <div class="control">
            <div class="field-body"><span style="margin-right: 8px;">${value}</span></div>
        </div>
${hasAddonStatic ? `
        <div class="control">
            <a class="button js-static">
                ${option.addonStatic}
            </a>
        </div>
` : ``}
${hasAddon ? `
        <div class="control">
            ${option.addon}
        </div>
` : ``}
    </div>
    ${option.help != undefined ? `<p class="help">${option.help}</p>` : ``}
</div>`;
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-button", [], function (exports_28, context_28) {
    "use strict";
    var renderButtonWithConfirm, renderButtonWithConfirmChoices, renderButton;
    var __moduleName = context_28 && context_28.id;
    return {
        setters: [],
        execute: function () {
            exports_28("renderButtonWithConfirm", renderButtonWithConfirm = (title, icon, items, onclick, disabled = false, active = false, hoverable = false, ontoggle = null, valid = true) => {
                let uid = new Date().getTime();
                let tag = (disabled ? "p" : "a");
                let itemsHtml = "";
                if (typeof items === "string")
                    itemsHtml = `<div class="dropdown-item">${items}</div>`;
                else
                    itemsHtml = items.reduce((html, item) => html + `<div class="dropdown-item">${item}</div>`, "");
                return `
<div class="dropdown ${active ? "is-active" : ""} ${hoverable ? "is-hoverable" : ""}">
    <div class="dropdown-trigger" onclick="${ontoggle != undefined ? ontoggle : "App_Theme.toggleActive(this)"}">
      <button class="button" aria-haspopup="true" aria-controls="dropdown-${uid}" ${disabled ? "disabled" : ""}>
        ${icon != undefined ? `<span class="icon"><i class="${icon}"></i></span>` : ``}
        <span>${title}</span>
      </button>
    </div>
    <div class="dropdown-menu" id="dropdown-${uid}" role="menu">
      <div class="dropdown-content">
        ${itemsHtml}
        <hr class="dropdown-divider">
${valid ? `
        <${tag} href="#" class="dropdown-item" onclick="${onclick};return false;">
          <span class="icon"><i class="fa fa-check"></i></span> ${i18n("Yes, do that")}
        </${tag}>
` : `
        <p href="#" class="dropdown-item" style="opacity:0.5">
          <span class="icon"><i class="fa fa-check"></i></span> ${i18n("Yes, do that")}
        </p>
`}
      </div>
    </div>
</div>`;
            });
            exports_28("renderButtonWithConfirmChoices", renderButtonWithConfirmChoices = (title, icon, helpText, choices, disabled = false) => {
                let uid = new Date().getTime();
                let tag = (disabled ? "p" : "a");
                let choiceTemplate = (item) => {
                    return `
            <${tag} href="#" class="dropdown-item" onclick="${item.onclick};return false;">
                <span class="icon"><i class="${item.icon != undefined ? item.icon : "far fa-arrow-circle-right"}"></i></span> ${item.text}
            </${tag}>`;
                };
                let lines = choices.reduce((html, item) => html + choiceTemplate(item), "");
                return `
<div class="dropdown is-up" onclick="App_Theme.toggleActive(this)">
    <div class="dropdown-trigger">
      <button class="button" aria-haspopup="true" aria-controls="dropdown-${uid}" ${disabled ? "disabled" : ""}>
        ${icon != undefined ? `<span class="icon"><i class="${icon}"></i></span>` : ``}
        <span>${title}</span>
      </button>
    </div>
    <div class="dropdown-menu" id="dropdown-${uid}" role="menu">
      <div class="dropdown-content">
        <div class="dropdown-item">
            ${helpText}
        </div>
        <hr class="dropdown-divider">
        ${lines}
      </div>
    </div>
</div>`;
            });
            exports_28("renderButton", renderButton = (title, icon, onclick, disabled = false) => {
                return `
<button class="button" onclick="${onclick}" ${disabled ? "disabled" : ""}>
    <span class="icon"><i class="${icon}"></i></span>
    <span>${title}</span>
</button>`;
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-modal", ["_BaseApp/src/lib-ts/domlib"], function (exports_29, context_29) {
    "use strict";
    var domlib, renderModalDelete, openModal, closeModal;
    var __moduleName = context_29 && context_29.id;
    return {
        setters: [
            function (domlib_1) {
                domlib = domlib_1;
            }
        ],
        execute: function () {
            exports_29("renderModalDelete", renderModalDelete = (id, onclick) => {
                return `
<div class="modal js-modal-delete" id="${id}" js-skip-render-class="is-active">
    <div class="modal-background" onclick="App_Theme.closeModal(this);"></div>
    <div class="modal-card">
<div>
        <header class="modal-card-head">
            <p class="modal-card-title">${i18n("Confirm Delete")}</p>
            <button class="delete" onclick="App_Theme.closeModal(this);"></button>
        </header>
        <section class="modal-card-body">
            <div class="level">
                <div class="level-item has-text-centered">
                    <div>
                        <p class="heading has-text-weight-bold">${i18n("Are you sure you want to delete this item?")}</p>
                        <p class="heading">${i18n("This operation cannot be undone.")}</p>
                    </div>
                </div>
            </div>
        </section>
        <footer class="modal-card-foot">
            <button class="button" onclick="App_Theme.closeModal(this);">
                <span>${i18n("CANCEL")}</span>
            </button>
            <button class="button is-danger" onclick="App_Theme.closeModal(this);${onclick}">
                <span class="icon"><i class="fa fa-times"></i></span> <span>${i18n("Yes, Delete")}</span>
            </button>
        </footer>
</div>
    </div>
</div>`;
            });
            exports_29("openModal", openModal = (id) => {
                document.getElementById(id).classList.add("is-active");
            });
            exports_29("closeModal", closeModal = (element) => {
                domlib.closestByClassName(element, "modal").classList.remove("is-active");
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme", ["_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme-action", "_BaseApp/src/theme/theme-checkbox", "_BaseApp/src/theme/theme-dropdown", "_BaseApp/src/theme/theme-select", "_BaseApp/src/theme/theme-radio", "_BaseApp/src/theme/theme-filter", "_BaseApp/src/theme/theme-number", "_BaseApp/src/theme/theme-latlong", "_BaseApp/src/theme/theme-text", "_BaseApp/src/theme/theme-date", "_BaseApp/src/theme/theme-calendar", "_BaseApp/src/theme/theme-static", "_BaseApp/src/theme/theme-button", "_BaseApp/src/theme/theme-autocomplete", "_BaseApp/src/theme/theme-modal"], function (exports_30, context_30) {
    "use strict";
    var Misc, NS, toggleActive, wrapContent, warningTemplate, fatalErrorTemplate403, fatalErrorTemplate404, dirtyTemplate, unexpectedTemplate, inConstruction, onburger, renderBlame, renderFileUpload, renderStyleForFixedWidthTable, renderStyleForScrollableTable, wrapFieldset, float_menu_button, scrollTo, field;
    var __moduleName = context_30 && context_30.id;
    return {
        setters: [
            function (Misc_11) {
                Misc = Misc_11;
            },
            function (theme_action_1_1) {
                exports_30({
                    "renderActionButtons": theme_action_1_1["renderActionButtons"],
                    "renderActionButtons2": theme_action_1_1["renderActionButtons2"],
                    "renderInlineActionButtons": theme_action_1_1["renderInlineActionButtons"],
                    "renderListActionButtons": theme_action_1_1["renderListActionButtons"],
                    "renderListActionButtons2": theme_action_1_1["renderListActionButtons2"],
                    "renderListFloatingActionButtons": theme_action_1_1["renderListFloatingActionButtons"],
                    "renderButtons": theme_action_1_1["renderButtons"],
                    "buttonCancel": theme_action_1_1["buttonCancel"],
                    "buttonInsert": theme_action_1_1["buttonInsert"],
                    "buttonUpload": theme_action_1_1["buttonUpload"],
                    "buttonAddNew": theme_action_1_1["buttonAddNew"],
                    "buttonDelete": theme_action_1_1["buttonDelete"],
                    "buttonUpdate": theme_action_1_1["buttonUpdate"],
                    "buttonUpdateNoDone": theme_action_1_1["buttonUpdateNoDone"],
                    "renderButtonsInline": theme_action_1_1["renderButtonsInline"],
                    "buttonCancelInline": theme_action_1_1["buttonCancelInline"],
                    "buttonInsertInline": theme_action_1_1["buttonInsertInline"],
                    "buttonAddNewInline": theme_action_1_1["buttonAddNewInline"],
                    "buttonDeleteInline": theme_action_1_1["buttonDeleteInline"],
                    "buttonUpdateInline": theme_action_1_1["buttonUpdateInline"]
                });
            },
            function (theme_checkbox_1_1) {
                exports_30({
                    "rawCheckbox": theme_checkbox_1_1["rawCheckbox"],
                    "renderCheckboxField": theme_checkbox_1_1["renderCheckboxField"],
                    "renderCheckboxInline": theme_checkbox_1_1["renderCheckboxInline"],
                    "renderCheckboxFilter": theme_checkbox_1_1["renderCheckboxFilter"],
                    "renderCheckboxListField": theme_checkbox_1_1["renderCheckboxListField"],
                    "rawToggle": theme_checkbox_1_1["rawToggle"]
                });
            },
            function (theme_dropdown_1_1) {
                exports_30({
                    "renderDropdownField": theme_dropdown_1_1["renderDropdownField"],
                    "renderDropdownInline": theme_dropdown_1_1["renderDropdownInline"],
                    "renderDropdownExInline": theme_dropdown_1_1["renderDropdownExInline"],
                    "renderDropdownNaked": theme_dropdown_1_1["renderDropdownNaked"],
                    "renderDropdownFilter": theme_dropdown_1_1["renderDropdownFilter"],
                    "renderOptions": theme_dropdown_1_1["renderOptions"],
                    "renderItems": theme_dropdown_1_1["renderItems"],
                    "renderOptionsFun": theme_dropdown_1_1["renderOptionsFun"],
                    "renderOptionsShowBoth": theme_dropdown_1_1["renderOptionsShowBoth"],
                    "renderOptionsShowCode": theme_dropdown_1_1["renderOptionsShowCode"],
                    "renderNullableBooleanOptions": theme_dropdown_1_1["renderNullableBooleanOptions"],
                    "renderNullableBooleanOptionsReverse": theme_dropdown_1_1["renderNullableBooleanOptionsReverse"],
                    "renderDatalistOptions": theme_dropdown_1_1["renderDatalistOptions"]
                });
            },
            function (theme_select_1_1) {
                exports_30({
                    "rawSelect": theme_select_1_1["rawSelect"]
                });
            },
            function (theme_radio_1_1) {
                exports_30({
                    "renderRadios": theme_radio_1_1["renderRadios"],
                    "renderRadioField": theme_radio_1_1["renderRadioField"]
                });
            },
            function (theme_filter_1_1) {
                exports_30({
                    "renderNumberFilter": theme_filter_1_1["renderNumberFilter"],
                    "renderDateFilter": theme_filter_1_1["renderDateFilter"],
                    "renderDateChanger": theme_filter_1_1["renderDateChanger"]
                });
            },
            function (theme_number_1_1) {
                exports_30({
                    "renderNumberField": theme_number_1_1["renderNumberField"],
                    "renderNumberField2": theme_number_1_1["renderNumberField2"],
                    "renderNumberInline": theme_number_1_1["renderNumberInline"],
                    "renderDecimalField": theme_number_1_1["renderDecimalField"],
                    "renderDecimalInline": theme_number_1_1["renderDecimalInline"],
                    "renderNumberInline2": theme_number_1_1["renderNumberInline2"]
                });
            },
            function (theme_latlong_1_1) {
                exports_30({
                    "renderLatField": theme_latlong_1_1["renderLatField"],
                    "renderLongField": theme_latlong_1_1["renderLongField"],
                    "renderLatLongInline": theme_latlong_1_1["renderLatLongInline"],
                    "renderDDMMCC": theme_latlong_1_1["renderDDMMCC"]
                });
            },
            function (theme_text_1_1) {
                exports_30({
                    "rawText": theme_text_1_1["rawText"],
                    "renderTextField": theme_text_1_1["renderTextField"],
                    "renderTextField2": theme_text_1_1["renderTextField2"],
                    "renderTextInline": theme_text_1_1["renderTextInline"],
                    "renderTextInline2": theme_text_1_1["renderTextInline2"],
                    "renderTextareaField": theme_text_1_1["renderTextareaField"],
                    "renderTextareaField_V": theme_text_1_1["renderTextareaField_V"],
                    "renderTextareaInline": theme_text_1_1["renderTextareaInline"],
                    "renderTextareaFieldWithMarkdown": theme_text_1_1["renderTextareaFieldWithMarkdown"]
                });
            },
            function (theme_date_1_1) {
                exports_30({
                    "renderDateInline": theme_date_1_1["renderDateInline"],
                    "renderDateExInline": theme_date_1_1["renderDateExInline"]
                });
            },
            function (theme_calendar_1_1) {
                exports_30({
                    "renderCalendarField": theme_calendar_1_1["renderCalendarField"],
                    "renderCalendarInline": theme_calendar_1_1["renderCalendarInline"],
                    "renderCalendarFilter": theme_calendar_1_1["renderCalendarFilter"]
                });
            },
            function (theme_static_1_1) {
                exports_30({
                    "renderStaticField": theme_static_1_1["renderStaticField"],
                    "renderStaticField2": theme_static_1_1["renderStaticField2"],
                    "renderStaticHtmlField": theme_static_1_1["renderStaticHtmlField"],
                    "renderStaticField_V": theme_static_1_1["renderStaticField_V"],
                    "renderStaticInline": theme_static_1_1["renderStaticInline"]
                });
            },
            function (theme_button_1_1) {
                exports_30({
                    "renderButtonWithConfirm": theme_button_1_1["renderButtonWithConfirm"],
                    "renderButtonWithConfirmChoices": theme_button_1_1["renderButtonWithConfirmChoices"],
                    "renderButton": theme_button_1_1["renderButton"]
                });
            },
            function (theme_autocomplete_1_1) {
                exports_30({
                    "renderAutocompleteField": theme_autocomplete_1_1["renderAutocompleteField"],
                    "renderAutocompleteInline": theme_autocomplete_1_1["renderAutocompleteInline"]
                });
            },
            function (theme_modal_1_1) {
                exports_30({
                    "renderModalDelete": theme_modal_1_1["renderModalDelete"],
                    "openModal": theme_modal_1_1["openModal"],
                    "closeModal": theme_modal_1_1["closeModal"]
                });
            }
        ],
        execute: function () {
            exports_30("NS", NS = "App_Theme");
            exports_30("toggleActive", toggleActive = (element) => {
                element.classList.toggle("is-active");
            });
            exports_30("wrapContent", wrapContent = (contentClass, html) => {
                if (html != undefined && html.length > 0)
                    return `<div class="content ${contentClass}">${html}</div>`;
                return "";
            });
            exports_30("warningTemplate", warningTemplate = (errorMessages) => {
                return errorMessages.reduce((text, error) => text +
                    `<div class="notification is-danger">
        <i class="fa fa-exclamation-triangle"></i>&nbsp;${error}
    </div>`, "");
            });
            exports_30("fatalErrorTemplate403", fatalErrorTemplate403 = () => {
                return `
    <div class="notification is-danger">
        <h3><i class="fas fa-skull-crossbones"></i>&nbsp;${i18n("Unauthorized")}</h3>
        ${i18n("You don't have the required permission for this operation")}
    </div>`;
            });
            exports_30("fatalErrorTemplate404", fatalErrorTemplate404 = () => {
                return `
    <div class="notification is-danger">
        <h3><i class="fas fa-skull-crossbones"></i>&nbsp;${i18n("Failed to fetch page data")}</h3>
        ${i18n("You don't have the required permission for this operation")}
    </div>`;
            });
            exports_30("dirtyTemplate", dirtyTemplate = (ns, details = null) => {
                return `
    <div class="notification is-warning">
        <i class="fa fa-exclamation-triangle"></i>
        <div style="display:inline-table;">You have changes that are not saved. Click Update to save your changes or ${ns != undefined ? `<a onclick="${ns}.cancel(); return false;">continue</a> without saving` : "Cancel"}.
        ${details != undefined ? `<br>${details}` : ""}</div>
    </div>`;
            });
            exports_30("unexpectedTemplate", unexpectedTemplate = () => {
                return `<div class="notification is-danger">
        <i class="fa fa-exclamation-triangle"></i>&nbsp;UNEXPECTED ERROR
    </div>`;
            });
            exports_30("inConstruction", inConstruction = (text = "In Construction") => {
                return `
    <div class="notification is-size-4 has-text-centered">
        <span class="icon"><i class="fas fa-wrench"></i></span> ${text}
    </div>
    `;
            });
            exports_30("onburger", onburger = (element) => {
                let target = document.getElementById(element.dataset.target);
                element.classList.toggle("is-active");
                target.classList.toggle("is-active");
            });
            exports_30("renderBlame", renderBlame = (obj, isNew) => {
                if (isNew || obj == undefined || obj.updated == undefined || obj.by == undefined)
                    return "";
                return `
    <div class="has-text-right js-blame">
        <span>Last updated on ${Misc.toStaticDateTime(obj.updated)}${obj.by ? ` by ${obj.by}` : ``}</span>
    </div>
`;
            });
            exports_30("renderFileUpload", renderFileUpload = (ns, propName, label, accept = "image/*", isBusy = false) => {
                if (!isBusy)
                    return `
<div class="level-item">
    <div class="file">
        <label class="file-label">
            <input class="file-input" type="file" id="${ns}_${propName}" name="${ns}_${propName}" accept="${accept}" onchange="${ns}.fileUpload(this)">
            <span class="file-cta">
                <span class="file-icon">
                    <i class="fas fa-upload"></i>
                </span>
                <span class="file-label">
                    ${label}…
                </span>
            </span>
        </label>
    </div>
</div>
    `;
                return `
<div class="level-item">
    <a class="button is-loading">Upoading</a>
</div>
    `;
            });
            exports_30("renderStyleForFixedWidthTable", renderStyleForFixedWidthTable = (id, widths) => {
                let table_width = widths.reduce((sum, width) => sum + width, 0);
                let thead = widths.reduce((html, width, index) => {
                    return html + `#${id} thead th:nth-child(${index + 1}) { width: ${width}px; min-width: ${width}px; }`;
                }, "");
                let tbody = widths.reduce((html, width, index) => {
                    return html + `#${id} tbody td:nth-child(${index + 1}) { width: ${width}px; min-width: ${width}px; }`;
                }, "");
                return `
<style>
    #${id} table { width: ${table_width}px; }
    ${thead}
    ${tbody}
</style>
`;
            });
            exports_30("renderStyleForScrollableTable", renderStyleForScrollableTable = (id, rows, widths) => {
                let table_width = widths.reduce((sum, width) => sum + width, 0);
                let table_th_height = 32;
                let scrollbar_width = 16 + 4;
                let scrollbar_height = 16;
                let height = 32 * (rows + 1);
                let thead = widths.reduce((html, width, index) => {
                    return html + `#${id} thead th:nth-child(${index + 1}) { min-width: ${width + (index == widths.length - 1 ? scrollbar_width : 0)}px; }`;
                }, "");
                let tbody = widths.reduce((html, width, index) => {
                    return html + `#${id} tbody td:nth-child(${index + 1}) { width: ${width}px; min-width: ${width}px; }`;
                }, "");
                return `
<style>
    #${id} { overflow: hidden; }
    #${id} table thead { display: block; }
    #${id} table tbody { display: block; overflow: auto; scroll-behavior: smooth; }

    #${id} { height: ${height + scrollbar_height}px; }
    #${id} table { width: ${table_width + scrollbar_width}px; }
    #${id} tbody { height: ${height - table_th_height}px; }

    ${thead}
    ${tbody}
</style>
`;
            });
            exports_30("wrapFieldset", wrapFieldset = (legend, content, actions = null) => {
                var id = legend.split(" ").join("");
                return `
<fieldset id="${id}">
    <legend class="js-legend"><span>${legend}</span>${actions ? `<div>${actions}</div>` : ""}</legend>
    ${content}
</fieldset>
`;
            });
            exports_30("float_menu_button", float_menu_button = (title, id) => {
                return `<button class="button is-text" onclick="${NS}.scrollTo('${id || title}')">${title}</button>`;
            });
            exports_30("scrollTo", scrollTo = (anchor) => {
                var id = anchor.replace(/ /g, "");
                var fieldset = document.getElementById(id);
                //
                fieldset.scrollIntoView();
                setTimeout(function () { window.scrollBy(0, -180); }, 10);
            });
            exports_30("field", field = (label, controls, required = false, cssclass) => {
                let html;
                if (typeof controls === "string")
                    html = `<div class="field">` + controls + "</div>";
                else
                    html = `<div class="field js-addons">` + controls.reduce((html, one) => html + one, "") + "</div>";
                return `
<div class="field is-horizontal ${cssclass || ""}">
    <div class="field-label"><label class="label ${required ? "js-required" : ""}">${label}</label></div>
    <div class="field-body">
        ${html}
    </div>
</div>`;
            });
        }
    };
});
System.register("_BaseApp/src/theme/theme-autocomplete", ["_BaseApp/src/lib-ts/misc"], function (exports_31, context_31) {
    "use strict";
    var Misc, renderAutocompleteField, renderAutocompleteInline;
    var __moduleName = context_31 && context_31.id;
    return {
        setters: [
            function (Misc_12) {
                Misc = Misc_12;
            }
        ],
        execute: function () {
            exports_31("renderAutocompleteField", renderAutocompleteField = (ns, propName, autocomplete, label, option) => {
                let input_id = `${ns}_${propName}`;
                return `
    <div class="field is-horizontal">
        <div class="field-label"><label class="label ${option.required ? "js-required" : ""}" for="${input_id}">${label}</label></div>
        <div class="field-body">
            ${renderAutocompleteInline(ns, propName, autocomplete, option)}
        </div>
    </div>`;
            });
            exports_31("renderAutocompleteInline", renderAutocompleteInline = (ns, propName, autocomplete, option) => {
                let hasAddonStatic = (option.addonStatic != undefined);
                let hasAddon = (option.addon != undefined);
                let hasAddonHead = (option.addonHead != undefined);
                let input_id = `${ns}_${propName}`;
                return `
    <div class="field">
    <div class="field js-autocomplete" id="${autocomplete.id}">
        <div class="dropdown ${autocomplete.isActive ? "is-active" : ""} ${option.size ? option.size : "js-width-25"}">
            <div class="control has-icons-right">
                <input type="text" class="input"
                    id="${input_id}" 
                    data-key="${autocomplete.keyValue}"
                    value="${Misc.toStaticText(autocomplete.textValue)}" 
                    onfocus="${autocomplete.handle('onfocus')}"
                    onkeydown="${autocomplete.handle('onkeydown')}"
                    onblur="${autocomplete.handle('onblur')}"
                    ${autocomplete.required ? "required='required'" : ""}
                    ${autocomplete.disabled ? "disabled" : ""}
                    autocomplete="off">
                    
                <span class="icon is-small is-right">
                    <i class="fas fa-search"></i>
                </span>
            </div>
            ${autocomplete.render()}
        </div>
${hasAddonStatic ? `
        <div class="control" style="display:inline-block">
            <a class="button js-static" ${option.addonHref != undefined ? `href="${option.addonHref}"` : ``}>
                ${option.addonStatic}
            </a>
        </div>
` : ``}
${hasAddon ? `
        <div class="control" style="display:inline-block">
            ${option.addon}
        </div>
` : ``}
    </div>
    ${option.help != undefined ? `<p class="help">${option.help}</p>` : ``}
    </div>`;
            });
        }
    };
});
System.register("src/fr-CA", [], function (exports_32, context_32) {
    "use strict";
    var fr_CA;
    var __moduleName = context_32 && context_32.id;
    return {
        setters: [],
        execute: function () {
            exports_32("fr_CA", fr_CA = {
                values: {
                    "HOME": "Accueil",
                    "Sign out": "Déconnexion",
                    "CANCEL": "Annuler",
                    "EMAIL": "Courriel",
                    "PASSWORD": "Mot de passe",
                    "APP WELCOME": "Bienvenue",
                    "ENTER PASSWORD AGAIN": "Entrer votre mot de passe de nouveau",
                    "Sign In": "Se connecter",
                    "Sign in to start your session": "Commencez votre session",
                    "I need a new password!": "J'ai besoin d'un nouveau mot de passe!",
                    "Let's fix that!": "Réparons ce problème!",
                    "Enter your email address below. You will receive an email with a link to allow you to enter a new password": "Entrez votre adresse courriel ici. Vous recevrez un courriel avec un lien pour entrer un nouveau mot de passe",
                    "The email link will expire in one week": "Le lien dans le courriel expire dans une semaine",
                    "Send Email": "Envoyer mon courriel",
                    "Cancel that, I remember my password now!": "Annulez ma requête, je me souviens du mot de passe!",
                    "Password reset email sent": "Le courriel pour un nouveau mot de passe est envoyé",
                    "An email has been sent to": "Un courriel a été envoyé à",
                    "Check out the spam folder if you don't see the email in your inbox within 5 minutes": "Vérifier votre boîte de pourriel si vous n'avez pas reçu de courriel d'ici 5 minutes",
                    "Done": "Complété",
                    "Now, let's set your password": "Il est temps d'entrer votre mot de passe",
                    "You need to enter your password twice below": "Vous devez entrer votre mot de passe deux fois ici",
                    "Go To First Page": "Aller à la première page",
                    "Go To Last Page": "Aller à la dernière page",
                    "SEARCH": "Recherche",
                }
            });
        }
    };
});
System.register("src/permission", ["_BaseApp/src/auth", "_BaseApp/src/core/app"], function (exports_33, context_33) {
    "use strict";
    var Auth, app_1, ROLE_SUPPORT, default_cie, isSupport, hasPermission, getCie, canDoThis, canDoThat, Feature, feature, assignFeature;
    var __moduleName = context_33 && context_33.id;
    return {
        setters: [
            function (Auth_4) {
                Auth = Auth_4;
                exports_33({
                    "getEmail": Auth_4["getEmail"],
                    "getName": Auth_4["getName"],
                    "getUID": Auth_4["getUID"],
                    "getRoles": Auth_4["getRoles"],
                    "getCurrentYear": Auth_4["getCurrentYear"],
                    "refreshLoginData": Auth_4["refreshLoginData"]
                });
            },
            function (app_1_1) {
                app_1 = app_1_1;
            }
        ],
        execute: function () {
            ROLE_SUPPORT = 1;
            exports_33("isSupport", isSupport = () => { return (Auth.getRoles().indexOf(ROLE_SUPPORT) != -1); });
            hasPermission = (permid) => { return (Auth.getPermissions().indexOf(permid) != -1) || isSupport(); };
            // Default cie
            exports_33("getCie", getCie = (params) => {
                if (isSupport() && params && params.length && params[0].startsWith("?cie="))
                    default_cie = +params[0].substr(5);
                return default_cie !== null && default_cie !== void 0 ? default_cie : app_1.cie;
            });
            // Block 100
            exports_33("canDoThis", canDoThis = () => hasPermission(101));
            exports_33("canDoThat", canDoThat = () => hasPermission(102));
            Feature = class Feature {
                constructor() {
                    this.feat = {};
                }
                assignFeature(feature) { this.feat = feature; }
                get private107() { var _a; return (_a = this.feat.private107) !== null && _a !== void 0 ? _a : []; }
                get private208() { var _a; return (_a = this.feat.private208) !== null && _a !== void 0 ? _a : []; }
                get private110() { var _a; return (_a = this.feat.private110) !== null && _a !== void 0 ? _a : []; }
            };
            feature = new Feature();
            exports_33("assignFeature", assignFeature = (newFeature) => feature.assignFeature(newFeature));
        }
    };
});
System.register("src/admin/lookupdata", ["_BaseApp/src/core/app", "_BaseApp/src/admin/lookupdata"], function (exports_34, context_34) {
    "use strict";
    var App, yearFilter, dateFilter, cIE, fetch_cIE, get_cIE, sortOrderKeys, fetch_sortOrderKeys, get_sortOrderKeys, pays, fetch_pays, get_pays, institutionBanquaire, fetch_institutionBanquaire, get_institutionBanquaire, compte, fetch_compte, get_compte, autreFournisseur, fetch_autreFournisseur, get_autreFournisseur, lot, fetch_lot, get_lot, canton, fetch_canton, get_canton, municipalite, fetch_municipalite, get_municipalite, proprietaire, fetch_proprietaire, get_proprietaire, contingent, fetch_contingent, get_contingent, droit_coupe, fetch_droit_coupe, get_droit_coupe, entente_paiement, fetch_entente_paiement, get_entente_paiement, zone, fetch_zone, get_zone, region, fetch_region, get_region, office, fetch_office, get_office, job, fetch_job, get_job;
    var __moduleName = context_34 && context_34.id;
    return {
        setters: [
            function (App_7) {
                App = App_7;
            },
            function (lookupdata_1_1) {
                exports_34({
                    "fetch_authrole": lookupdata_1_1["fetch_authrole"],
                    "authrole": lookupdata_1_1["authrole"],
                    "fetch_lutGroup": lookupdata_1_1["fetch_lutGroup"],
                    "get_lutGroup": lookupdata_1_1["get_lutGroup"]
                });
            }
        ],
        execute: function () {
            yearFilter = (one, year) => year >= one.started && (one.ended == undefined || year <= one.ended);
            dateFilter = (one, date) => date >= one.started && (one.ended == undefined || date <= one.ended);
            exports_34("fetch_cIE", fetch_cIE = () => {
                return function (data) {
                    if (cIE != undefined && cIE.length > 0)
                        return;
                    return App.GET(`/lookup/by/cie`).then(json => { cIE = json; });
                };
            });
            exports_34("get_cIE", get_cIE = (year) => cIE);
            exports_34("fetch_sortOrderKeys", fetch_sortOrderKeys = () => {
                return function (data) {
                    const fill = (id, description) => {
                        return {
                            id: id,
                            description: description
                        };
                    };
                    sortOrderKeys = [
                        fill(1, "Nom fournisseur"),
                        fill(2, "No chèque/paiement, Type de facture, Nom fournisseur"),
                        fill(3, "No fournisseur"),
                        fill(4, "No facture")
                    ];
                };
            });
            exports_34("get_sortOrderKeys", get_sortOrderKeys = (year) => sortOrderKeys);
            exports_34("fetch_pays", fetch_pays = () => {
                return function (data) {
                    if (pays != undefined && pays.length > 0)
                        return;
                    return App.GET(`/lookup/by/pays`).then(json => { pays = json; });
                };
            });
            exports_34("get_pays", get_pays = (year) => pays);
            exports_34("fetch_institutionBanquaire", fetch_institutionBanquaire = () => {
                return function (data) {
                    if (institutionBanquaire != undefined && institutionBanquaire.length > 0)
                        return;
                    return App.GET(`/lookup/by/institutionBanquaire`).then(json => { institutionBanquaire = json; });
                };
            });
            exports_34("get_institutionBanquaire", get_institutionBanquaire = (year) => institutionBanquaire);
            exports_34("fetch_compte", fetch_compte = () => {
                return function (data) {
                    if (compte != undefined && compte.length > 0)
                        return;
                    return App.GET(`/lookup/by/compte`).then(json => { compte = json; });
                };
            });
            exports_34("get_compte", get_compte = (year) => compte);
            exports_34("fetch_autreFournisseur", fetch_autreFournisseur = () => {
                return function (data) {
                    if (autreFournisseur != undefined && autreFournisseur.length > 0)
                        return;
                    return App.GET(`/lookup/by/autreFournisseur`).then(json => { autreFournisseur = json; });
                };
            });
            exports_34("get_autreFournisseur", get_autreFournisseur = (year) => autreFournisseur);
            exports_34("fetch_lot", fetch_lot = () => {
                return function (data) {
                    if (lot != undefined && lot.length > 0)
                        return;
                    return App.GET(`/lookup/by/lot`).then(json => { lot = json; });
                };
            });
            exports_34("get_lot", get_lot = (year) => lot);
            exports_34("fetch_canton", fetch_canton = () => {
                return function (data) {
                    if (canton != undefined && canton.length > 0)
                        return;
                    return App.GET(`/lookup/by/canton`).then(json => { canton = json; });
                };
            });
            exports_34("get_canton", get_canton = (year) => canton);
            exports_34("fetch_municipalite", fetch_municipalite = () => {
                return function (data) {
                    if (municipalite != undefined && municipalite.length > 0)
                        return;
                    return App.GET(`/lookup/by/municipalite`).then(json => { municipalite = json; });
                };
            });
            exports_34("get_municipalite", get_municipalite = (year) => municipalite);
            exports_34("fetch_proprietaire", fetch_proprietaire = () => {
                return function (data) {
                    if (proprietaire != undefined && proprietaire.length > 0)
                        return;
                    return App.GET(`/lookup/by/proprietaire`).then(json => { proprietaire = json; });
                };
            });
            exports_34("get_proprietaire", get_proprietaire = (year) => proprietaire);
            exports_34("fetch_contingent", fetch_contingent = () => {
                return function (data) {
                    if (contingent != undefined && contingent.length > 0)
                        return;
                    return App.GET(`/lookup/by/contingent`).then(json => { contingent = json; });
                };
            });
            exports_34("get_contingent", get_contingent = (year) => contingent);
            exports_34("fetch_droit_coupe", fetch_droit_coupe = () => {
                return function (data) {
                    if (droit_coupe != undefined && droit_coupe.length > 0)
                        return;
                    return App.GET(`/lookup/by/droit_coupe`).then(json => { droit_coupe = json; });
                };
            });
            exports_34("get_droit_coupe", get_droit_coupe = (year) => droit_coupe);
            exports_34("fetch_entente_paiement", fetch_entente_paiement = () => {
                return function (data) {
                    if (entente_paiement != undefined && entente_paiement.length > 0)
                        return;
                    return App.GET(`/lookup/by/entente_paiement`).then(json => { entente_paiement = json; });
                };
            });
            exports_34("get_entente_paiement", get_entente_paiement = (year) => entente_paiement);
            exports_34("fetch_zone", fetch_zone = () => {
                return function (data) {
                    if (zone != undefined && zone.length > 0)
                        return;
                    return App.GET(`/lookup/by/zone`).then(json => { zone = json; });
                };
            });
            exports_34("get_zone", get_zone = (year) => zone);
            exports_34("fetch_region", fetch_region = () => {
                return function (data) {
                    if (region != undefined && region.length > 0)
                        return;
                    return App.GET(`/lookup/by/region`).then(json => { region = json; });
                };
            });
            exports_34("get_region", get_region = (year) => region);
            exports_34("fetch_office", fetch_office = () => {
                return function (data) {
                    if (office != undefined && office.length > 0)
                        return;
                    return App.GET(`/office/lookup`).then(json => { office = json; });
                };
            });
            exports_34("get_office", get_office = (year) => office);
            exports_34("fetch_job", fetch_job = () => {
                return function (data) {
                    if (job != undefined && job.length > 0)
                        return;
                    return App.GET(`/job/lookup`).then(json => { job = json; });
                };
            });
            exports_34("get_job", get_job = (year) => job);
        }
    };
});
System.register("src/home", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "src/layout"], function (exports_35, context_35) {
    "use strict";
    var App, Router, Perm, Layout, NS, menuData, yesterday, today, tomorrow, tomorrow_2, tomorrow_3, tomorrow_4, region, getMenuData, clearMenuData, renderDropdown, menuTemplate, pageTemplate, fetchState, fetch, render, postRender, getFormState, onchange, loadToolsState, saveToolsState;
    var __moduleName = context_35 && context_35.id;
    return {
        setters: [
            function (App_8) {
                App = App_8;
            },
            function (Router_4) {
                Router = Router_4;
            },
            function (Perm_1) {
                Perm = Perm_1;
            },
            function (Layout_1) {
                Layout = Layout_1;
            }
        ],
        execute: function () {
            exports_35("NS", NS = "App_Home");
            exports_35("getMenuData", getMenuData = () => {
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
                                    { name: "Gestion des tables", href: "#/admin/lookups/profile.key", ns: ["App_lookups", "App_lookup"] },
                                    { name: "Gestion des périodes", },
                                    { name: "Matrice de sécurité", },
                                ],
                                merge: "start"
                            },
                            {
                                merge: "end",
                                name: "Support", icon: "fas fa-tools",
                                links: [
                                    { name: "Compagnies", href: "#/support/companys", ns: ["App_companys", "App_company"] },
                                    { name: "Metadata des permissions", },
                                    { name: "Audit", },
                                    { name: "(office)", href: "#/offices", ns: ["App_offices", "App_office"], hidden: Perm.getEmail() != "ctrepanier@jaguarsolutions.ca" },
                                    { name: "(staff)", href: "#/staffs_2", ns: ["App_staffs_2", "App_staff_2"], hidden: Perm.getEmail() != "ctrepanier@jaguarsolutions.ca" },
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
                                    { name: "Profil par défaut", },
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
            });
            exports_35("clearMenuData", clearMenuData = () => {
                menuData = null;
            });
            exports_35("renderDropdown", renderDropdown = (propName, options) => {
                return `
    <div class="select is-small">
        <select id="${NS}_${propName}" onchange="${NS}.onchange(this)">
            ${options}
        </select>
    </div>`;
            });
            menuTemplate = (menuItems) => {
                const linkTemplate = (link) => {
                    if (link.hidden)
                        return "";
                    const liClasses = (link.classes ? `class="${link.classes}"` : "");
                    if (link.markup)
                        return `<li ${liClasses}>${link.markup}</li>`;
                    const isDisabled = (link.href == undefined && link.onclick == undefined);
                    const href = (link.href || "#");
                    const isExternal = href.startsWith("http") || link.isExternal;
                    return `<li ${liClasses}><a href="${href}" ${isDisabled ? `class="js-disabled"` : ``} ${isExternal ? `target="_new"` : ``} ${link.onclick ? `onclick="${link.onclick}"` : ""}>${link.name}</a></li>`;
                };
                const sectionTemplate = (section, listColumnClass) => {
                    if (section.hidden)
                        return "";
                    const reduceSection = () => {
                        const links = section.links.filter(one => one.canView == undefined || one.canView);
                        const maxrows = (section.maxrows == undefined ? 32 : section.maxrows);
                        let html = "";
                        for (let ix = 0; ix < links.length; ix++) {
                            const ixe = ix % maxrows;
                            if (ixe == 0)
                                html += "<ul>";
                            html += linkTemplate(links[ix]);
                            if (ixe == (maxrows - 1) || ix == links.length - 1)
                                html += "</ul>";
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
                const menuItemTemplate = (menuItem) => {
                    return `
<div class="column ${menuItem.columnClass}">
    <div class="box">
        <div class="js-widget">
            <div class="tile">
                <i class="${menuItem.icon} fa-4x"></i>
                <div>${menuItem.name}</div>
            </div>
            <div class="columns is-mobile is-multiline">
                ${menuItem.sections.filter(one => one.canView == undefined || one.canView).reduce((html, item) => { return html + sectionTemplate(item, menuItem.listColumnClass); }, "")}
            </div>
        </div>
    </div>
</div>
`;
                };
                return menuItems.filter(one => one.canView).reduce((html, item) => { return html + menuItemTemplate(item); }, "");
            };
            pageTemplate = (menu) => {
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
            };
            fetchState = () => {
                return Promise
                    .resolve();
                //.then(Lookup.fetch_tools())
                //.then(() => { saveToolsState(Lookup.get_tools(Perm.getCurrentYear())) })
            };
            exports_35("fetch", fetch = () => {
                App.setRenderDomain(Layout);
                App.prepareRender(NS, "HOME");
                Router.registerDirtyExit(null);
                fetchState()
                    .then(App.render)
                    .catch(App.render);
            });
            exports_35("render", render = () => {
                if (!App.inContext(NS))
                    return "";
                //
                // Build page
                //
                let menu = menuTemplate(getMenuData());
                return pageTemplate(menu);
            });
            exports_35("postRender", postRender = () => {
                if (!App.inContext(NS))
                    return "";
            });
            getFormState = () => {
            };
            exports_35("onchange", onchange = (input) => {
                //state = getFormState();
                App.render();
            });
            loadToolsState = () => {
                return JSON.parse(localStorage.getItem("tools-state"));
            };
            saveToolsState = (uiTools) => {
                localStorage.setItem("tools-state", JSON.stringify(uiTools));
            };
        }
    };
});
System.register("src/admin/layout", ["_BaseApp/src/core/app", "src/permission", "src/layout"], function (exports_36, context_36) {
    "use strict";
    var App, Perm, layout_1, icon, prepareMenu, tabTemplate, buildTitle, buildSubtitle;
    var __moduleName = context_36 && context_36.id;
    return {
        setters: [
            function (App_9) {
                App = App_9;
            },
            function (Perm_2) {
                Perm = Perm_2;
            },
            function (layout_1_1) {
                layout_1 = layout_1_1;
            }
        ],
        execute: function () {
            exports_36("icon", icon = "far fa-user");
            exports_36("prepareMenu", prepareMenu = () => {
                layout_1.setOpenedMenu("Administration-Management");
            });
            exports_36("tabTemplate", tabTemplate = (id, xtra, isNew = false) => {
                let isCompany = App.inContext("App_company");
                let isAccounts = App.inContext("App_accounts");
                let isAccount = App.inContext("App_account");
                let isLookups = App.inContext("App_lookups");
                let isLookup = App.inContext("App_lookup");
                let isSecurity = App.inContext("App_security");
                let isFiles = window.location.hash.startsWith("#/files/company");
                let isFile = window.location.hash.startsWith("#/file/company");
                let showFiles = false && xtra;
                let showFile = false && xtra && isFile;
                let showSecurity = Perm.isSupport();
                return `
<div class="tabs is-boxed">
    <ul>
        <li ${isCompany ? "class='is-active'" : ""}>
            <a href="#/admin/company">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("Company Details")}</span>
            </a>
        </li>
        <li ${isAccounts ? "class='is-active'" : ""}>
            <a href="#/admin/accounts">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("Accounts")}</span>
            </a>
        </li>
${isAccount ? `
        <li class="is-active">
            <a href="#/admin/account/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("Account Details")}</span>
            </a>
        </li>
` : ``}

        <li ${isLookups ? "class='is-active'" : ""}>
            <a href="#/admin/lookups/profile.key">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("Lookups")}</span>
            </a>
        </li>
${isLookup ? `
        <li class="is-active">
            <a href="#/admin/lookup/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("Entry Details")}</span>
            </a>
        </li>
` : ``}

${showSecurity ? `
        <li ${isSecurity ? "class='is-active'" : ""}>
            <a href="#/support/security">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("Security")}</span>
            </a>
        </li>
` : ``}

${showFiles ? `
        <li ${isFiles ? "class='is-active'" : ""}>
            <a href="#/files/account/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("Files")} (${xtra.fileCount})</span>
            </a>
        </li>
` : ``}
${showFile ? `
        <li class="is-active">
            <a href="#/file/account/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("File Details")}</span>
            </a>
        </li>
` : ``}

    </ul>
</div>
`;
            });
            exports_36("buildTitle", buildTitle = (xtra, defaultText) => {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.title) !== null && _a !== void 0 ? _a : defaultText;
            });
            exports_36("buildSubtitle", buildSubtitle = (xtra, defaultText) => {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.subtitle) !== null && _a !== void 0 ? _a : defaultText;
            });
        }
    };
});
// File: accounts.ts
System.register("src/admin/accounts", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/layout"], function (exports_37, context_37) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, layout_2, NS, key, state, xtra, uiSelectedRow, autoArchiveButton, filterTemplate, trTemplate, tableTemplate, pageTemplate, fetchState, fetch, refresh, render, postRender, inContext, setSelectedRow, isSelectedRow, goto, sortBy, search, filter_archive, filter_readytoarchive, gotoDetail, create, autoArchive;
    var __moduleName = context_37 && context_37.id;
    return {
        setters: [
            function (App_10) {
                App = App_10;
            },
            function (Router_5) {
                Router = Router_5;
            },
            function (Perm_3) {
                Perm = Perm_3;
            },
            function (Misc_13) {
                Misc = Misc_13;
            },
            function (Theme_1) {
                Theme = Theme_1;
            },
            function (Pager_1) {
                Pager = Pager_1;
            },
            function (layout_2_1) {
                layout_2 = layout_2_1;
            }
        ],
        execute: function () {
            exports_37("NS", NS = "App_accounts");
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 20, sortColumn: "EMAIL", sortDirection: "ASC", filter: { cie: App.cie, archive: undefined, readyToArchive: undefined } }
            };
            autoArchiveButton = () => {
                let title = i18n("Auto Archive");
                let helpText = i18n("<p><b>Note:</b> This will archive all records having the <b><em>Ready to Archive</em></b> flag set.</p>");
                let onclick = `${NS}.autoArchive()`;
                return Theme.renderButtonWithConfirm(title, "far fa-lock-open-alt", helpText, onclick, false, false, true);
            };
            filterTemplate = (archive, readytoarchive) => {
                let filters = [];
                filters.push(Theme.renderDropdownFilter(NS, "archive", archive, i18n("ARCHIVE")));
                filters.push(Theme.renderDropdownFilter(NS, "readytoarchive", readytoarchive, i18n("READYTOARCHIVE")));
                return filters.join("");
            };
            trTemplate = (item, rowNumber) => {
                return `
<tr class="${isSelectedRow(item.uid) ? "is-selected" : ""}" onclick="${NS}.gotoDetail(${item.uid});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.email)}</td>
    <td>${Misc.toStaticText(item.firstname)}</td>
    <td>${Misc.toStaticText(item.lastname)}</td>
    <td>${Misc.toStaticText(item.roleluid_text)}</td>
    <td>${Misc.toStaticDateTime(item.lastactivity)}</td>
    <td>${Misc.toStaticCheckbox(item.readytoarchive)}</td>
    <td>${Misc.toStaticCheckbox(item.archive)}</td>
</tr>`;
            };
            tableTemplate = (tbody, pager) => {
                return `
<div class="table-container">
<table class="table is-hoverable is-fullwidth">
    <thead>
        <tr>
            <th></th>
            ${Pager.sortableHeaderLink(pager, NS, i18n("EMAIL"), "email", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FIRSTNAME"), "firstname", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LASTNAME"), "lastname", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ROLEMASK"), "roleluid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LASTACTIVITY"), "lastactivity", "DESC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("READYTOARCHIVE"), "readytoarchive", "DESC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ARCHIVE"), "archive", "ASC")}
        </tr>
    </thead>
    <tbody>
        ${tbody}
    </tbody>
</table>
</div>
`;
            };
            pageTemplate = (pager, table, tab, warning, dirty) => {
                let readonly = false;
                let buttons = [];
                buttons.push(autoArchiveButton());
                buttons.push(Theme.buttonAddNew(NS, "#/admin/account/new", i18n("Add New")));
                let actions = Theme.renderButtons(buttons);
                return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_2.icon}"></i> ${xtra.title}</div>
            <div class="subtitle">${i18n("List of accounts")}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-pager", pager)}
    ${Theme.wrapContent("js-uc-list", table)}
</div>
</div>

</form>
`;
            };
            exports_37("fetchState", fetchState = (cie) => {
                Router.registerDirtyExit(null);
                state.pager.filter.cie = cie;
                return App.POST("/account/search/", state.pager)
                    .then(payload => {
                    state = payload;
                    xtra = payload.xtra;
                    key = { cie };
                });
            });
            exports_37("fetch", fetch = (params) => {
                let cie = Perm.getCie(params);
                App.prepareRender(NS, i18n("accounts"));
                layout_2.prepareMenu();
                fetchState(cie)
                    .then(App.render)
                    .catch(App.render);
            });
            refresh = () => {
                App.prepareRender(NS, i18n("accounts"));
                App.POST("/account/search/", state.pager)
                    .then(payload => {
                    state = payload;
                })
                    .then(App.render)
                    .catch(App.render);
            };
            exports_37("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let warning = App.warningTemplate();
                let dirty = "";
                const tbody = state.list.reduce((html, item, index) => {
                    let rowNumber = Pager.rowNumber(state.pager, index);
                    return html + trTemplate(item, rowNumber);
                }, "");
                let year = Perm.getCurrentYear();
                let archive = Theme.renderNullableBooleanOptionsReverse(state.pager.filter.archive, ["All", i18n("Archived"), i18n("Active")]);
                let readytoarchive = Theme.renderNullableBooleanOptions(state.pager.filter.readyToArchive, ["All", i18n("Ready"), i18n("Not Ready")]);
                const filter = filterTemplate(archive, readytoarchive);
                const search = Pager.searchTemplate(state.pager, NS);
                const pager = Pager.render(state.pager, NS, [20, 50], search, filter);
                const table = tableTemplate(tbody, state.pager);
                const tab = layout_2.tabTemplate(null, null);
                return pageTemplate(pager, table, tab, dirty, warning);
            });
            exports_37("postRender", postRender = () => {
                if (!inContext())
                    return;
            });
            exports_37("inContext", inContext = () => {
                return App.inContext(NS);
            });
            setSelectedRow = (uid) => {
                if (uiSelectedRow == undefined)
                    uiSelectedRow = { uid };
                uiSelectedRow.uid = uid;
            };
            isSelectedRow = (uid) => {
                if (uiSelectedRow == undefined)
                    return false;
                return (uiSelectedRow.uid == uid);
            };
            exports_37("goto", goto = (pageNo, pageSize) => {
                state.pager.pageNo = pageNo;
                state.pager.pageSize = pageSize;
                refresh();
            });
            exports_37("sortBy", sortBy = (columnName, direction) => {
                state.pager.pageNo = 1;
                state.pager.sortColumn = columnName;
                state.pager.sortDirection = direction;
                refresh();
            });
            exports_37("search", search = (element) => {
                state.pager.searchText = element.value;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_37("filter_archive", filter_archive = (element) => {
                let value = element.options[element.selectedIndex].value;
                let archive = (value.length > 0 ? value == "true" : undefined);
                if (archive == state.pager.filter.archive)
                    return;
                state.pager.filter.archive = archive;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_37("filter_readytoarchive", filter_readytoarchive = (element) => {
                let value = element.options[element.selectedIndex].value;
                let readytoarchive = (value.length > 0 ? value == "true" : undefined);
                if (readytoarchive == state.pager.filter.readyToArchive)
                    return;
                state.pager.filter.readyToArchive = readytoarchive;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_37("gotoDetail", gotoDetail = (cid) => {
                setSelectedRow(cid);
                Router.goto(`#/admin/account/${cid}`);
            });
            exports_37("create", create = () => {
                Router.goto(`#/admin/account/new`);
            });
            exports_37("autoArchive", autoArchive = () => {
                App.POST("/account/auto-archive", null)
                    .then(_ => {
                    Misc.toastSuccess(i18n("Auto Archive Executed"));
                    Router.goto(`#/admin/accounts`, 10);
                })
                    .catch(App.render);
            });
        }
    };
});
// File: account.ts
System.register("src/admin/account", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/auth", "src/admin/lookupdata", "src/admin/layout"], function (exports_38, context_38) {
    "use strict";
    var App, Router, Misc, Theme, Auth, Lookup, layout_3, NS, blackList, key, state, fetchedState, xtra, isNew, isDirty, emailSubject, emailBody, block_account, block_profile, formTemplate, resetPasswordButton, canUpdate, pageTemplate, dirtyTemplate, clearState, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, onchange, cancel, create, save, drop, resetPassword, createInvitation, dirtyExit;
    var __moduleName = context_38 && context_38.id;
    return {
        setters: [
            function (App_11) {
                App = App_11;
            },
            function (Router_6) {
                Router = Router_6;
            },
            function (Misc_14) {
                Misc = Misc_14;
            },
            function (Theme_2) {
                Theme = Theme_2;
            },
            function (Auth_5) {
                Auth = Auth_5;
            },
            function (Lookup_1) {
                Lookup = Lookup_1;
            },
            function (layout_3_1) {
                layout_3 = layout_3_1;
            }
        ],
        execute: function () {
            exports_38("NS", NS = "App_account");
            blackList = ["cie_text", "roleluid_text", "resetguid", "created", "updatedby", "by", "profileJson", "xtra"];
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            block_account = (item, roleList) => {
                let roleluid = Theme.renderRadios(NS, "roleluid", Lookup.authrole, state.roleluid, false);
                let canCreateFullAccount = true; //Perm.canCreateFullAccount();
                return `
    <div class="columns js-2-columns">
    <div class="column">
    ${canCreateFullAccount ? Theme.renderCheckboxField(NS, "userealemail", item.userealemail, i18n("USEREALEMAIL"), i18n("USEREALEMAIL_TEXT"), i18n(`USEREALEMAIL_HELP_${item.userealemail}`)) : ""}

${item.userealemail ? `
    ${Theme.renderTextField2(NS, "email", item.email, i18n("EMAIL"), 50, { required: true, size: "js-width-50" })}
    ${!isNew ? `
        <div class="field is-horizontal">
            <div class="field-label"><label class="label">&nbsp;</label></div>
            <div class="field-body"><span><a href="mailto:${item.email}"><i class="far fa-envelope"></i> ${i18n("SEND EMAIL TO")} ${item.email}</a></span></div>
        </div>
    ` : ``}
` : `
    ${Theme.renderTextField2(NS, "email", item.email, i18n("USERNAME"), 50, { required: true, size: "js-width-50" })}
    ${Theme.renderTextField2(NS, "password", item.password, i18n("PASSWORD"), 50, { required: isNew, size: "js-width-50", help: !isNew ? i18n("PASSWORD_HELP") : undefined, noautocomplete: true })}
`}

    ${Theme.renderTextField(NS, "firstname", item.firstname, i18n("FIRSTNAME"), 50, true)}
    ${Theme.renderTextField(NS, "lastname", item.lastname, i18n("LASTNAME"), 50, true)}

${!isNew ? `
    ${Theme.renderStaticField(Misc.toStaticDateTime(item.resetexpiry), i18n("RESETEXPIRY"))}
    ${Theme.renderStaticField(Misc.toStaticDateTime(item.lastactivity), i18n("LASTACTIVITY"))}
    <div class="field is-horizontal">
        <div class="field-label"><label class="label">&nbsp;</label></div>
        <div class="field-body">${resetPasswordButton(item)}</div>
    </div>
` : ``}
    </div>
    <div class="column">
    ${Theme.renderNumberField(NS, "currentyear", item.currentyear, i18n("CURRENTYEAR"), true, "js-width-25", "User can only enter data for this fire season")}
    ${Theme.renderRadioField(roleluid, i18n("ROLELUID"))}
    ${Theme.renderNumberField(NS, "archivedays", item.archivedays, i18n("ARCHIVEDAYS"), false, "js-width-25", "Duration in days after which an inactive account is archived")}
${!isNew ? `
    ${Theme.renderCheckboxField(NS, "archive", item.archive, i18n("ARCHIVE"), "Disable Account", "User cannot sign-in to OpsFMS when the account is disabled")}
` : ``}
    </div>
    </div>
`;
            };
            block_profile = (item, sortOrderKeysID) => {
                return `
    <div class="columns js-2-columns">
    <div class="column">
    ${Theme.renderTextField(NS, "acrobatpath", item.acrobatpath, "Chemin d'accès à Acrobat Reader", 100, false)}
    ${Theme.renderDropdownField(NS, "facturesorttype", sortOrderKeysID, "Ordre de tri des factures (croissant)")}
    </div>
    </div>
`;
            };
            formTemplate = (item, roleList, sortOrderKeysID) => {
                return `
<div class="columns">
    <div class="column is-8 is-offset-2">
        ${Theme.wrapFieldset("Compte", block_account(item, roleList))}
        ${Theme.wrapFieldset("Profile", block_profile(item, sortOrderKeysID))}
    </div>
</div>

    ${Theme.renderBlame(item, isNew)}
`;
            };
            resetPasswordButton = (item) => {
                let title;
                let helpText;
                let onclick;
                if (item.canresetpassword) {
                    title = i18n("Reset Password");
                    helpText = i18n("<p><b>Note:</b> This will prevent the user from login until the user re-enters a new password.</p><br><p>An email will be sent to the user with a link to do so.</p>");
                    onclick = `${NS}.resetPassword()`;
                }
                if (item.cancreateinvitation) {
                    title = i18n("Create Invitation");
                    helpText = i18n("<p>Create an invitation for this user to join OpsFMS.</p><br><p>An email will be sent to the user with a link to do so.</p>");
                    onclick = `${NS}.createInvitation()`;
                }
                if (item.canextendinvitation) {
                    title = i18n("Extend Invitation");
                    helpText = i18n("Re-invite this user to OpsFMS because he/she didn't go through the process before the <b>Password Reset Expiry</b>.</p><br><p>An email will be sent to the user with a link to do so.</p>");
                    onclick = `${NS}.createInvitation()`;
                }
                if (title)
                    return Theme.renderButtonWithConfirm(title, "fas fa-lock", helpText, onclick, false, false, true);
                else
                    return "";
            };
            canUpdate = () => {
                return (isNew || key.uid != 1 || Auth.getRoles().indexOf(1) != -1);
            };
            pageTemplate = (item, form, tab, warning, dirty) => {
                let readonly = !canUpdate();
                let buttons = [];
                return `
<form onsubmit="return false;" ${readonly ? "class='js-readonly'" : ""}>
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_3.icon}"></i> <span>${xtra.title}</span></div>
            <div class="subtitle">${isNew ? i18n("New account") : xtra.subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", Theme.renderActionButtons2(NS, isNew, `#/admin/account/new`, buttons))}
            ${Theme.renderBlame(item, isNew)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-details", form)}
</div>
</div>

${Theme.renderModalDelete(`modalDelete_${NS}`, `${NS}.drop()`)}

</form>
`;
            };
            dirtyTemplate = () => {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            clearState = () => {
                state = {};
            };
            exports_38("fetchState", fetchState = (uid) => {
                isNew = isNaN(uid);
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                clearState();
                let url = `/account/${isNew ? "new" : uid}`;
                return App.GET(url)
                    .then((payload) => {
                    state = payload.item;
                    fetchedState = Misc.clone(state);
                    xtra = payload.xtra;
                    key = { uid };
                })
                    .then(Lookup.fetch_authrole())
                    .then(Lookup.fetch_sortOrderKeys());
            });
            exports_38("fetch", fetch = (params) => {
                let id = +params[0];
                App.prepareRender(NS, i18n("account"));
                layout_3.prepareMenu();
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_38("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || Object.keys(state).length == 0)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let year = state.currentyear;
                let lookup_sortOrderKeys = Lookup.get_sortOrderKeys(year);
                let sortOrderKeysID = Theme.renderOptions(lookup_sortOrderKeys, state.facturesorttype, false);
                const form = formTemplate(state, Lookup.authrole, sortOrderKeysID);
                emailBody = undefined;
                const tab = layout_3.tabTemplate(state.uid, xtra);
                const dirty = dirtyTemplate();
                const warning = App.warningTemplate();
                return pageTemplate(state, form, tab, warning, dirty);
            });
            exports_38("postRender", postRender = () => {
                if (!inContext())
                    return;
                App.setPageTitle(isNew ? i18n("New account") : xtra.title);
            });
            exports_38("inContext", inContext = () => {
                return App.inContext(NS);
            });
            getFormState = () => {
                let clone = Misc.clone(state);
                clone.userealemail = Misc.fromInputCheckbox(`${NS}_userealemail`, state.userealemail);
                clone.email = Misc.fromInputText(`${NS}_email`, state.email);
                clone.password = Misc.fromInputText(`${NS}_password`, state.password);
                clone.firstname = Misc.fromInputText(`${NS}_firstname`, state.firstname);
                clone.lastname = Misc.fromInputText(`${NS}_lastname`, state.lastname);
                clone.currentyear = Misc.fromInputNumber(`${NS}_currentyear`, state.currentyear);
                clone.roleluid = Misc.fromRadioNumber(`${NS}_roleluid`, state.roleluid);
                clone.archivedays = Misc.fromInputNumberNullable(`${NS}_archivedays`, state.archivedays);
                clone.archive = Misc.fromInputCheckbox(`${NS}_archive`, state.archive);
                //
                clone.acrobatpath = Misc.fromInputText(`${NS}_acrobatpath`, state.acrobatpath);
                clone.facturesorttype = Misc.fromSelectNumber(`${NS}_facturesorttype`, state.facturesorttype);
                return clone;
            };
            valid = (formState) => {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = () => {
                document.getElementById(`${NS}_dummy_submit`).click();
                let form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_38("onchange", onchange = (input) => {
                state = getFormState();
                App.render();
            });
            exports_38("cancel", cancel = () => {
                Router.goBackOrResume(isDirty);
            });
            exports_38("create", create = () => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST("/account", Misc.createBlack(formState, blackList))
                    .then(payload => {
                    let newkey = payload;
                    emailSubject = payload.emailSubject;
                    emailBody = payload.emailBody;
                    Misc.toastSuccessSave();
                    Router.goto(`#/admin/account/${newkey.uid}`, 10);
                })
                    .catch(App.render);
            });
            exports_38("save", save = (done = false) => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.PUT("/account", Misc.createBlack(formState, blackList))
                    .then(_ => {
                    Misc.toastSuccessSave();
                    if (done)
                        Router.goto(`#/admin/accounts/`, 100);
                    else
                        Router.goto(`#/admin/account/${key.uid}`, 10);
                })
                    .catch(App.render);
            });
            exports_38("drop", drop = () => {
                key.updated = state.updated;
                App.prepareRender();
                App.DELETE("/account", key)
                    .then(_ => {
                    clearState();
                    Router.goto(`#/admin/accounts/`, 250);
                })
                    .catch(App.render);
            });
            exports_38("resetPassword", resetPassword = () => {
                App.POST("/account/reset-password", key)
                    .then(_ => {
                    Misc.toastSuccess(i18n("Password reset sent"));
                    Router.goto(`#/admin/account/${key.uid}`, 10);
                })
                    .catch(App.render);
            });
            exports_38("createInvitation", createInvitation = () => {
                App.POST("/account/create-invitation", key)
                    .then(_ => {
                    Misc.toastSuccess(i18n("Invitation sent"));
                    Router.goto(`#/admin/account/${key.uid}`, 10);
                })
                    .catch(App.render);
            });
            dirtyExit = () => {
                isDirty = !Misc.same(fetchedState, getFormState());
                if (isDirty) {
                    setTimeout(() => {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
// File: company.ts
System.register("src/admin/company", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "src/admin/lookupdata", "src/permission", "src/admin/layout"], function (exports_39, context_39) {
    "use strict";
    var App, Router, Misc, Theme, Lookup, Perm, layout_4, NS, blackList, key, state, fetchedState, xtra, isNew, isDirty, block_company, block_system, block_personnalisation, block_acomba, block_comptes, block_preleve, block_permis, block_print, block_backup, block_security, block_default_profile, block_todo, formTemplate, pageTemplate, dirtyTemplate, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, onchange, cancel, create, save, drop, dirtyExit;
    var __moduleName = context_39 && context_39.id;
    return {
        setters: [
            function (App_12) {
                App = App_12;
            },
            function (Router_7) {
                Router = Router_7;
            },
            function (Misc_15) {
                Misc = Misc_15;
            },
            function (Theme_3) {
                Theme = Theme_3;
            },
            function (Lookup_2) {
                Lookup = Lookup_2;
            },
            function (Perm_4) {
                Perm = Perm_4;
            },
            function (layout_4_1) {
                layout_4 = layout_4_1;
            }
        ],
        execute: function () {
            exports_39("NS", NS = "App_company");
            blackList = ["created"];
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            block_company = (item) => {
                return `
    ${Theme.renderTextField(NS, "name", item.name, i18n("NAME"), 64, true)}
    ${Theme.renderTextField(NS, "features", item.features, i18n("FEATURES"), 2048)}
    ${Theme.renderCheckboxField(NS, "archive", item.archive, i18n("ARCHIVE"))}
`;
            };
            block_system = (item) => {
                return `
    ${Theme.renderTextField(NS, "xlstemplatespath", item.xlstemplatespath, i18n("XLSTEMPLATESPATH"), 500)}
    ${Theme.renderTextField(NS, "helpfilepath", item.helpfilepath, i18n("HELPFILEPATH"), 500)}

    ${Theme.renderNumberField(NS, "masselimitedefaut", item.masselimitedefaut, i18n("MASSELIMITEDEFAUT"), true)}
    ${Theme.renderNumberField(NS, "anneecourante", item.anneecourante, i18n("ANNEECOURANTE"), true)}
    ${Theme.renderNumberField(NS, "taux_tps", item.taux_tps, i18n("TAUX_TPS"))}
    ${Theme.renderNumberField(NS, "taux_tvq", item.taux_tvq, i18n("TAUX_TVQ"))}

    ${Theme.renderNumberField(NS, "massecontingentvoyagedefaut", item.massecontingentvoyagedefaut, i18n("MASSECONTINGENTVOYAGEDEFAUT"), true)}
    ${Theme.renderNumberField(NS, "superficiecontingenteesansdeduction", item.superficiecontingenteesansdeduction, i18n("SUPERFICIECONTINGENTEESANSDEDUCTION"))}
    ${Theme.renderNumberField(NS, "superficiecontingenteepourcentagededuction", item.superficiecontingenteepourcentagededuction, i18n("SUPERFICIECONTINGENTEEPOURCENTAGEDEDUCTION"))}

    ${Theme.renderCheckboxField(NS, "livraisonliertaux", item.livraisonliertaux, i18n("LIVRAISONLIERTAUX"))}
    ${Theme.renderCheckboxField(NS, "utiliserlotscontingentes", item.utiliserlotscontingentes, i18n("UTILISERLOTSCONTINGENTES"))}

    ${Theme.renderTextField(NS, "formicon", item.formicon, i18n("FORMICON"), 500)}
    ${Theme.renderTextField(NS, "formtext", item.formtext, i18n("FORMTEXT"), 500)}
`;
            };
            block_personnalisation = (item) => {
                return `
    ${Theme.renderTextField(NS, "syndicatouoffice", item.syndicatouoffice, i18n("SYNDICATOUOFFICE"), 500)}

    ${Theme.renderTextField(NS, "syndicat_nomanglais", item.syndicat_nomanglais, i18n("SYNDICAT_NOMANGLAIS"), 500)}
    ${Theme.renderTextField(NS, "syndicat_nomfrancais", item.syndicat_nomfrancais, i18n("SYNDICAT_NOMFRANCAIS"), 500)}

    ${Theme.renderTextField(NS, "syndicat_rue", item.syndicat_rue, i18n("SYNDICAT_RUE"), 500)}
    ${Theme.renderTextField(NS, "syndicat_ville", item.syndicat_ville, i18n("SYNDICAT_VILLE"), 500)}
    ${Theme.renderTextField(NS, "syndicat_codepostal", item.syndicat_codepostal, i18n("SYNDICAT_CODEPOSTAL"), 500)}
    ${Theme.renderTextField(NS, "syndicat_telephone", item.syndicat_telephone, i18n("SYNDICAT_TELEPHONE"), 500)}
    ${Theme.renderTextField(NS, "syndicat_fax", item.syndicat_fax, i18n("SYNDICAT_FAX"), 500)}
`;
            };
            block_acomba = (item) => {
                return `
    ${Theme.renderTextField(NS, "acombausername", item.acombausername, i18n("ACOMBAUSERNAME"), 500)}
    ${Theme.renderTextField(NS, "acombapassword", item.acombapassword, i18n("ACOMBAPASSWORD"), 500)}
    ${Theme.renderTextField(NS, "acombasocietepath", item.acombasocietepath, i18n("ACOMBASOCIETEPATH"), 500)}
    ${Theme.renderTextField(NS, "acombapath", item.acombapath, i18n("ACOMBAPATH"), 500)}

    ${Theme.renderCheckboxField(NS, "utiliselesychronisateurdirect", item.utiliselesychronisateurdirect, i18n("UTILISELESYCHRONISATEURDIRECT"))}
    ${Theme.renderTextField(NS, "acombasyncropath", item.acombasyncropath, i18n("ACOMBASYNCROPATH"), 500)}
`;
            };
            block_comptes = (item, fournisseur_planconjoint, fournisseur_surcharge, compte_paiements, compte_arecevoir, compte_apayer, compte_duauxproducteurs, compte_tpspercues, compte_tpspayees, compte_tvqpercues, compte_tvqpayees, fournisseur_fond_roulement, fournisseur_fond_forestier, fournisseur_preleve_divers) => {
                return `
    ${Theme.renderDropdownField(NS, "fournisseur_planconjoint", fournisseur_planconjoint, i18n("FOURNISSEUR_PLANCONJOINT"))}
    ${Theme.renderDropdownField(NS, "fournisseur_surcharge", fournisseur_surcharge, i18n("FOURNISSEUR_SURCHARGE"))}
    ${Theme.renderDropdownField(NS, "fournisseur_fond_roulement", fournisseur_fond_roulement, i18n("FOURNISSEUR_FOND_ROULEMENT"))}
    ${Theme.renderDropdownField(NS, "fournisseur_fond_forestier", fournisseur_fond_forestier, i18n("FOURNISSEUR_FOND_FORESTIER"))}
    ${Theme.renderDropdownField(NS, "fournisseur_preleve_divers", fournisseur_preleve_divers, i18n("FOURNISSEUR_PRELEVE_DIVERS"))}

    ${Theme.renderDropdownField(NS, "compte_paiements", compte_paiements, i18n("COMPTE_PAIEMENTS"))}
    ${Theme.renderDropdownField(NS, "compte_arecevoir", compte_arecevoir, i18n("COMPTE_ARECEVOIR"))}
    ${Theme.renderDropdownField(NS, "compte_apayer", compte_apayer, i18n("COMPTE_APAYER"))}
    ${Theme.renderDropdownField(NS, "compte_duauxproducteurs", compte_duauxproducteurs, i18n("COMPTE_DUAUXPRODUCTEURS"))}
    ${Theme.renderDropdownField(NS, "compte_tpspercues", compte_tpspercues, i18n("COMPTE_TPSPERCUES"))}
    ${Theme.renderDropdownField(NS, "compte_tpspayees", compte_tpspayees, i18n("COMPTE_TPSPAYEES"))}
    ${Theme.renderDropdownField(NS, "compte_tvqpercues", compte_tvqpercues, i18n("COMPTE_TVQPERCUES"))}
    ${Theme.renderDropdownField(NS, "compte_tvqpayees", compte_tvqpayees, i18n("COMPTE_TVQPAYEES"))}
`;
            };
            block_preleve = (item) => {
                return `
    ${Theme.renderTextField(NS, "preleves_notps", item.preleves_notps, i18n("PRELEVES_NOTPS"), 500)}
    ${Theme.renderTextField(NS, "preleves_notvq", item.preleves_notvq, i18n("PRELEVES_NOTVQ"), 500)}

    ${Theme.renderTextField(NS, "syndicat_notps", item.syndicat_notps, i18n("SYNDICAT_NOTPS"), 500)}
    ${Theme.renderTextField(NS, "syndicat_notvq", item.syndicat_notvq, i18n("SYNDICAT_NOTVQ"), 500)}
`;
            };
            block_permis = (item) => {
                return `
    ${Theme.renderNumberField(NS, "typepermis", item.typepermis, i18n("TYPEPERMIS"), true)}

    ${Theme.renderTextField(NS, "serveuremail", item.serveuremail, i18n("SERVEUREMAIL"), 500)}
    ${Theme.renderTextField(NS, "ccemail", item.ccemail, i18n("CCEMAIL"), 500)}
    ${Theme.renderTextField(NS, "fromemail", item.fromemail, i18n("FROMEMAIL"), 500)}

    ${Theme.renderCheckboxField(NS, "permisprintpreview", item.permisprintpreview, i18n("PERMISPRINTPREVIEW"))}
    ${Theme.renderTextField(NS, "typepermis1", item.typepermis1, i18n("TYPEPERMIS1"), 500)}
    ${Theme.renderTextField(NS, "typepermis1anglais", item.typepermis1anglais, i18n("TYPEPERMIS1ANGLAIS"), 500)}
    ${Theme.renderTextField(NS, "typepermis1francais", item.typepermis1francais, i18n("TYPEPERMIS1FRANCAIS"), 500)}
    ${Theme.renderCheckboxField(NS, "afficherpermit1", item.afficherpermit1, i18n("AFFICHERPERMIT1"))}
    ${Theme.renderCheckboxField(NS, "emailpermit1", item.emailpermit1, i18n("EMAILPERMIT1"))}
    ${Theme.renderCheckboxField(NS, "copiepermit1", item.copiepermit1, i18n("COPIEPERMIT1"))}

    ${Theme.renderTextField(NS, "typepermis2", item.typepermis2, i18n("TYPEPERMIS2"), 500)}
    ${Theme.renderTextField(NS, "typepermis2anglais", item.typepermis2anglais, i18n("TYPEPERMIS2ANGLAIS"), 500)}
    ${Theme.renderTextField(NS, "typepermis2francais", item.typepermis2francais, i18n("TYPEPERMIS2FRANCAIS"), 500)}
    ${Theme.renderCheckboxField(NS, "afficherpermit2", item.afficherpermit2, i18n("AFFICHERPERMIT2"))}
    ${Theme.renderCheckboxField(NS, "emailpermit2", item.emailpermit2, i18n("EMAILPERMIT2"))}
    ${Theme.renderCheckboxField(NS, "copiepermit2", item.copiepermit2, i18n("COPIEPERMIT2"))}

    ${Theme.renderTextField(NS, "typepermis3", item.typepermis3, i18n("TYPEPERMIS3"), 500)}
    ${Theme.renderTextField(NS, "typepermis3anglais", item.typepermis3anglais, i18n("TYPEPERMIS3ANGLAIS"), 500)}
    ${Theme.renderTextField(NS, "typepermis3francais", item.typepermis3francais, i18n("TYPEPERMIS3FRANCAIS"), 500)}
    ${Theme.renderCheckboxField(NS, "afficherpermit3", item.afficherpermit3, i18n("AFFICHERPERMIT3"))}
    ${Theme.renderCheckboxField(NS, "emailpermit3", item.emailpermit3, i18n("EMAILPERMIT3"))}
    ${Theme.renderCheckboxField(NS, "copiepermit3", item.copiepermit3, i18n("COPIEPERMIT3"))}

    ${Theme.renderTextField(NS, "typepermis4", item.typepermis4, i18n("TYPEPERMIS4"), 500)}
    ${Theme.renderTextField(NS, "typepermis4anglais", item.typepermis4anglais, i18n("TYPEPERMIS4ANGLAIS"), 500)}
    ${Theme.renderTextField(NS, "typepermis4francais", item.typepermis4francais, i18n("TYPEPERMIS4FRANCAIS"), 500)}
    ${Theme.renderCheckboxField(NS, "afficherpermit4", item.afficherpermit4, i18n("AFFICHERPERMIT4"))}
    ${Theme.renderCheckboxField(NS, "emailpermit4", item.emailpermit4, i18n("EMAILPERMIT4"))}
    ${Theme.renderCheckboxField(NS, "copiepermit4", item.copiepermit4, i18n("COPIEPERMIT4"))}

    ${Theme.renderTextField(NS, "messagespecpermitanglais", item.messagespecpermitanglais, i18n("MESSAGESPECPERMITANGLAIS"), 500)}
    ${Theme.renderTextField(NS, "messagespecpermitfrancais", item.messagespecpermitfrancais, i18n("MESSAGESPECPERMITFRANCAIS"), 500)}

    ${Theme.renderTextField(NS, "showyearsinpermislistview", item.showyearsinpermislistview, i18n("SHOWYEARSINPERMISLISTVIEW"), 500)}
`;
            };
            block_print = (item) => {
                return `
    ${Theme.renderCheckboxField(NS, "facturesaffichersurchargeproducteur", item.facturesaffichersurchargeproducteur, i18n("FACTURESAFFICHERSURCHARGEPRODUCTEUR"))}
    ${Theme.renderCheckboxField(NS, "facturesafficherfraischargeurproducteur", item.facturesafficherfraischargeurproducteur, i18n("FACTURESAFFICHERFRAISCHARGEURPRODUCTEUR"))}
    ${Theme.renderCheckboxField(NS, "facturesafficherfraischargeurtransporteur", item.facturesafficherfraischargeurtransporteur, i18n("FACTURESAFFICHERFRAISCHARGEURTRANSPORTEUR"))}
    ${Theme.renderCheckboxField(NS, "facturesafficherfraisautresproducteur", item.facturesafficherfraisautresproducteur, i18n("FACTURESAFFICHERFRAISAUTRESPRODUCTEUR"))}

    ${Theme.renderCheckboxField(NS, "facturesafficherfraisautrestransporteur", item.facturesafficherfraisautrestransporteur, i18n("FACTURESAFFICHERFRAISAUTRESTRANSPORTEUR"))}
    ${Theme.renderCheckboxField(NS, "facturesafficherfraiscompensationdedeplacement", item.facturesafficherfraiscompensationdedeplacement, i18n("FACTURESAFFICHERFRAISCOMPENSATIONDEDEPLACEMENT"))}
    ${Theme.renderCheckboxField(NS, "facturesafficherfraisautresrevenustransporteur", item.facturesafficherfraisautresrevenustransporteur, i18n("FACTURESAFFICHERFRAISAUTRESREVENUSTRANSPORTEUR"))}
    ${Theme.renderCheckboxField(NS, "facturesafficherfraisautresrevenusproducteur", item.facturesafficherfraisautresrevenusproducteur, i18n("FACTURESAFFICHERFRAISAUTRESREVENUSPRODUCTEUR"))}

    ${Theme.renderTextField(NS, "logopath", item.logopath, i18n("LOGOPATH"), 500)}

    ${Theme.renderCheckboxField(NS, "utiliserlesnomsdemachinedanslenomdeprinter", item.utiliserlesnomsdemachinedanslenomdeprinter, i18n("UTILISERLESNOMSDEMACHINEDANSLENOMDEPRINTER"))}

    ${Theme.renderTextareaField(NS, "message_autorisationdeslivraisons", item.message_autorisationdeslivraisons, i18n("MESSAGE_AUTORISATIONDESLIVRAISONS"), 500, false, null, 10)}
    ${Theme.renderTextareaField(NS, "message_demandecontingentement", item.message_demandecontingentement, i18n("MESSAGE_DEMANDECONTINGENTEMENT"), 500, false, null, 10)}
`;
            };
            block_backup = (item) => {
                return `
    ${Theme.renderCheckboxField(NS, "takeacombabackup", item.takeacombabackup, i18n("TAKEACOMBABACKUP"))}
    ${Theme.renderCheckboxField(NS, "takesqlbackup", item.takesqlbackup, i18n("TAKESQLBACKUP"))}
    ${Theme.renderTextField(NS, "nomdb", item.nomdb, i18n("NOMDB"), 500)}
    ${Theme.renderNumberField(NS, "timeoutsql", item.timeoutsql, i18n("TIMEOUTSQL"), true)}
    ${Theme.renderNumberField(NS, "tempsentrelesbackupsautomatiques", item.tempsentrelesbackupsautomatiques, i18n("TEMPSENTRELESBACKUPSAUTOMATIQUES"))}
`;
            };
            block_security = (item) => {
                return `
    ${Theme.renderTextField(NS, "caneditundeliveredpermits", item.caneditundeliveredpermits, i18n("CANEDITUNDELIVEREDPERMITS"), 500)}

    ${Theme.renderTextField(NS, "adminpassword", item.adminpassword, i18n("ADMINPASSWORD"), 500)}
    ${Theme.renderTextField(NS, "deletefichepassword", item.deletefichepassword, i18n("DELETEFICHEPASSWORD"), 500)}
`;
            };
            block_default_profile = (item) => {
                return `
    ${Theme.renderTextField(NS, "imprimantedepermis", item.imprimantedepermis, i18n("IMPRIMANTEDEPERMIS"), 500)}
    ${Theme.renderNumberField(NS, "permisprintermarginbottom", item.permisprintermarginbottom, i18n("PERMISPRINTERMARGINBOTTOM"))}
    ${Theme.renderNumberField(NS, "permisprintermarginleft", item.permisprintermarginleft, i18n("PERMISPRINTERMARGINLEFT"))}
    ${Theme.renderNumberField(NS, "permisprintermarginright", item.permisprintermarginright, i18n("PERMISPRINTERMARGINRIGHT"))}
    ${Theme.renderNumberField(NS, "permisprintermargintop", item.permisprintermargintop, i18n("PERMISPRINTERMARGINTOP"))}

    ${Theme.renderTextField(NS, "imprimanteautresrapports", item.imprimanteautresrapports, i18n("IMPRIMANTEAUTRESRAPPORTS"), 500)}
    ${Theme.renderNumberField(NS, "autresraportsprintermarginbottom", item.autresraportsprintermarginbottom, i18n("AUTRESRAPORTSPRINTERMARGINBOTTOM"))}
    ${Theme.renderNumberField(NS, "autresraportsprintermarginleft", item.autresraportsprintermarginleft, i18n("AUTRESRAPORTSPRINTERMARGINLEFT"))}
    ${Theme.renderNumberField(NS, "autresraportsprintermarginright", item.autresraportsprintermarginright, i18n("AUTRESRAPORTSPRINTERMARGINRIGHT"))}
    ${Theme.renderNumberField(NS, "autresraportsprintermargintop", item.autresraportsprintermargintop, i18n("AUTRESRAPORTSPRINTERMARGINTOP"))}

    ${Theme.renderTextField(NS, "excellanguage", item.excellanguage, i18n("EXCELLANGUAGE"), 500)}

    ${Theme.renderTextField(NS, "acrobatpath", item.acrobatpath, i18n("ACROBATPATH"), 500)}

    ${Theme.renderTextField(NS, "cletriclientnom", item.cletriclientnom, i18n("CLETRICLIENTNOM"), 500)}
`;
            };
            block_todo = (item) => {
                return `
    ${Theme.renderCheckboxField(NS, "facturesafficherfraisautrechargepourtransporteur", item.facturesafficherfraisautrechargepourtransporteur, i18n("FACTURESAFFICHERFRAISAUTRECHARGEPOURTRANSPORTEUR"))}
    ${Theme.renderNumberField(NS, "fournisseurpointerid", item.fournisseurpointerid, i18n("FOURNISSEURPOINTERID"), true)}
    ${Theme.renderTextField(NS, "gpversion", item.gpversion, i18n("GPVERSION"), 500)}
    ${Theme.renderTextField(NS, "logfile", item.logfile, i18n("LOGFILE"), 500)}
    ${Theme.renderTextField(NS, "messageimpressionsdefactures", item.messageimpressionsdefactures, i18n("MESSAGEIMPRESSIONSDEFACTURES"), 500)}
    ${Theme.renderTextField(NS, "messagelivraisonnonconforme", item.messagelivraisonnonconforme, i18n("MESSAGELIVRAISONNONCONFORME"), 500)}
    ${Theme.renderTextField(NS, "syndicat_nom", item.syndicat_nom, i18n("SYNDICAT_NOM"), 500)}
    ${Theme.renderTextField(NS, "updateotherdatabase", item.updateotherdatabase, i18n("UPDATEOTHERDATABASE"), 500)}
`;
            };
            formTemplate = (item, fournisseur_planconjoint, fournisseur_surcharge, compte_paiements, compte_arecevoir, compte_apayer, compte_duauxproducteurs, compte_tpspercues, compte_tpspayees, compte_tvqpercues, compte_tvqpayees, fournisseur_fond_roulement, fournisseur_fond_forestier, fournisseur_preleve_divers) => {
                return `
<div class="js-float-menu">
    <ul>
        <li>${Theme.float_menu_button("Compte")}</li>
        <li>${Theme.float_menu_button("Paramètres système")}</li>
        <li>${Theme.float_menu_button("Personnalisation")}</li>
        <li>${Theme.float_menu_button("Acomba")}</li>
        <li>${Theme.float_menu_button("Comptes/Fournisseurs")}</li>
        <li>${Theme.float_menu_button("Taxe")}</li>
        <li>${Theme.float_menu_button("Permis")}</li>
        <li>${Theme.float_menu_button("Paramètres imprimantes")}</li>
        <li>${Theme.float_menu_button("Backup")}</li>
        <li>${Theme.float_menu_button("Sécurité")}</li>
        <li>${Theme.float_menu_button("Profil par défaut")}</li>
        <li>${Theme.float_menu_button("TODO")}</li>
    </ul>
</div>

<div class="columns">
    <div class="column is-8 is-offset-3">
        ${Theme.wrapFieldset("Compte", block_company(item))}
        ${Theme.wrapFieldset("Paramètres système", block_system(item))}
        ${Theme.wrapFieldset("Personnalisation", block_personnalisation(item))}
        ${Theme.wrapFieldset("Acomba", block_acomba(item))}
        ${Theme.wrapFieldset("Comptes/Fournisseurs", block_comptes(item, fournisseur_planconjoint, fournisseur_surcharge, compte_paiements, compte_arecevoir, compte_apayer, compte_duauxproducteurs, compte_tpspercues, compte_tpspayees, compte_tvqpercues, compte_tvqpayees, fournisseur_fond_roulement, fournisseur_fond_forestier, fournisseur_preleve_divers))}
        ${Theme.wrapFieldset("Taxe", block_preleve(item))}
        ${Theme.wrapFieldset("Permis", block_permis(item))}
        ${Theme.wrapFieldset("Paramètres imprimantes", block_print(item))}
        ${Theme.wrapFieldset("Backup", block_backup(item))}
        ${Theme.wrapFieldset("Sécurité", block_security(item))}
        ${Theme.wrapFieldset("Profil par défaut", block_default_profile(item))}
        ${Theme.wrapFieldset("TODO", block_todo(item))}
    </div>
</div>

    ${Theme.renderBlame(item, isNew)}
`;
            };
            pageTemplate = (item, form, tab, warning, dirty) => {
                let canEdit = true;
                let readonly = !canEdit;
                let canInsert = canEdit && isNew; // && Perm.hasCompany_CanAddCompany;
                let canDelete = canEdit && !canInsert; // && Perm.hasCompany_CanDeleteCompany;
                let canAdd = canEdit && !canInsert; // && Perm.hasCompany_CanAddCompany;
                let canUpdate = canEdit && !isNew;
                let buttons = [];
                buttons.push(Theme.buttonCancel(NS));
                if (canInsert)
                    buttons.push(Theme.buttonInsert(NS));
                if (canDelete)
                    buttons.push(Theme.buttonDelete(NS));
                if (canAdd)
                    buttons.push(Theme.buttonAddNew(NS, "#/admin/company/new"));
                if (canUpdate)
                    buttons.push(Theme.buttonUpdate(NS));
                let actions = Theme.renderButtons(buttons);
                let title = layout_4.buildTitle(xtra, !isNew ? i18n("company Details") : i18n("New company"));
                let subtitle = layout_4.buildSubtitle(xtra, i18n("company subtitle"));
                return `
<form onsubmit="return false;" ${readonly ? "class='js-readonly'" : ""}>
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_4.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
            ${Theme.renderBlame(item, isNew)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-details", form)}
</div>
</div>

${Theme.renderModalDelete(`modalDelete_${NS}`, `${NS}.drop()`)}

</form>
`;
            };
            dirtyTemplate = () => {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            exports_39("fetchState", fetchState = (cie) => {
                isNew = isNaN(cie);
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                return App.GET(`/company/${isNew ? "new" : cie}`)
                    .then((payload) => {
                    state = payload.item;
                    fetchedState = Misc.clone(state);
                    xtra = payload.xtra;
                    key = { cie };
                })
                    .then(Lookup.fetch_autreFournisseur())
                    .then(Lookup.fetch_compte());
            });
            exports_39("fetch", fetch = (params) => {
                let cie = Perm.getCie(params);
                App.prepareRender(NS, i18n("company"));
                fetchState(cie)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_39("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || Object.keys(state).length == 0)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let year = Perm.getCurrentYear(); //or something better
                let lookup_autreFournisseur = Lookup.get_autreFournisseur(year);
                let lookup_compte = Lookup.get_compte(year);
                let fournisseur_planconjoint = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_planconjoint, true);
                let fournisseur_surcharge = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_surcharge, true);
                let compte_paiements = Theme.renderOptions(lookup_compte, state.compte_paiements, true);
                let compte_arecevoir = Theme.renderOptions(lookup_compte, state.compte_arecevoir, true);
                let compte_apayer = Theme.renderOptions(lookup_compte, state.compte_apayer, true);
                let compte_duauxproducteurs = Theme.renderOptions(lookup_compte, state.compte_duauxproducteurs, true);
                let compte_tpspercues = Theme.renderOptions(lookup_compte, state.compte_tpspercues, true);
                let compte_tpspayees = Theme.renderOptions(lookup_compte, state.compte_tpspayees, true);
                let compte_tvqpercues = Theme.renderOptions(lookup_compte, state.compte_tvqpercues, true);
                let compte_tvqpayees = Theme.renderOptions(lookup_compte, state.compte_tvqpayees, true);
                let fournisseur_fond_roulement = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_fond_roulement, true);
                let fournisseur_fond_forestier = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_fond_forestier, true);
                let fournisseur_preleve_divers = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_preleve_divers, true);
                const form = formTemplate(state, fournisseur_planconjoint, fournisseur_surcharge, compte_paiements, compte_arecevoir, compte_apayer, compte_duauxproducteurs, compte_tpspercues, compte_tpspayees, compte_tvqpercues, compte_tvqpayees, fournisseur_fond_roulement, fournisseur_fond_forestier, fournisseur_preleve_divers);
                const tab = layout_4.tabTemplate(state.cie, xtra, isNew);
                const dirty = dirtyTemplate();
                const warning = App.warningTemplate();
                return pageTemplate(state, form, tab, warning, dirty);
            });
            exports_39("postRender", postRender = () => {
                if (!inContext())
                    return;
                App.setPageTitle(isNew ? i18n("New company") : xtra.title);
            });
            exports_39("inContext", inContext = () => {
                return App.inContext(NS);
            });
            getFormState = () => {
                let clone = Misc.clone(state);
                clone.name = Misc.fromInputText(`${NS}_name`, state.name);
                clone.features = Misc.fromInputTextNullable(`${NS}_features`, state.features);
                clone.archive = Misc.fromInputCheckbox(`${NS}_archive`, state.archive);
                clone.acombapassword = Misc.fromInputTextNullable(`${NS}_acombapassword`, state.acombapassword);
                clone.acombapath = Misc.fromInputTextNullable(`${NS}_acombapath`, state.acombapath);
                clone.acombasocietepath = Misc.fromInputTextNullable(`${NS}_acombasocietepath`, state.acombasocietepath);
                clone.acombasyncropath = Misc.fromInputTextNullable(`${NS}_acombasyncropath`, state.acombasyncropath);
                clone.acombausername = Misc.fromInputTextNullable(`${NS}_acombausername`, state.acombausername);
                clone.acrobatpath = Misc.fromInputTextNullable(`${NS}_acrobatpath`, state.acrobatpath);
                clone.adminpassword = Misc.fromInputTextNullable(`${NS}_adminpassword`, state.adminpassword);
                clone.afficherpermit1 = Misc.fromInputCheckbox(`${NS}_afficherpermit1`, state.afficherpermit1);
                clone.afficherpermit2 = Misc.fromInputCheckbox(`${NS}_afficherpermit2`, state.afficherpermit2);
                clone.afficherpermit3 = Misc.fromInputCheckbox(`${NS}_afficherpermit3`, state.afficherpermit3);
                clone.afficherpermit4 = Misc.fromInputCheckbox(`${NS}_afficherpermit4`, state.afficherpermit4);
                clone.anneecourante = Misc.fromInputNumber(`${NS}_anneecourante`, state.anneecourante);
                clone.autresraportsprintermarginbottom = Misc.fromInputNumberNullable(`${NS}_autresraportsprintermarginbottom`, state.autresraportsprintermarginbottom);
                clone.autresraportsprintermarginleft = Misc.fromInputNumberNullable(`${NS}_autresraportsprintermarginleft`, state.autresraportsprintermarginleft);
                clone.autresraportsprintermarginright = Misc.fromInputNumberNullable(`${NS}_autresraportsprintermarginright`, state.autresraportsprintermarginright);
                clone.autresraportsprintermargintop = Misc.fromInputNumberNullable(`${NS}_autresraportsprintermargintop`, state.autresraportsprintermargintop);
                clone.caneditundeliveredpermits = Misc.fromInputTextNullable(`${NS}_caneditundeliveredpermits`, state.caneditundeliveredpermits);
                clone.ccemail = Misc.fromInputTextNullable(`${NS}_ccemail`, state.ccemail);
                clone.cletriclientnom = Misc.fromInputTextNullable(`${NS}_cletriclientnom`, state.cletriclientnom);
                clone.copiepermit1 = Misc.fromInputCheckbox(`${NS}_copiepermit1`, state.copiepermit1);
                clone.copiepermit2 = Misc.fromInputCheckbox(`${NS}_copiepermit2`, state.copiepermit2);
                clone.copiepermit3 = Misc.fromInputCheckbox(`${NS}_copiepermit3`, state.copiepermit3);
                clone.copiepermit4 = Misc.fromInputCheckbox(`${NS}_copiepermit4`, state.copiepermit4);
                clone.deletefichepassword = Misc.fromInputTextNullable(`${NS}_deletefichepassword`, state.deletefichepassword);
                clone.emailpermit1 = Misc.fromInputCheckbox(`${NS}_emailpermit1`, state.emailpermit1);
                clone.emailpermit2 = Misc.fromInputCheckbox(`${NS}_emailpermit2`, state.emailpermit2);
                clone.emailpermit3 = Misc.fromInputCheckbox(`${NS}_emailpermit3`, state.emailpermit3);
                clone.emailpermit4 = Misc.fromInputCheckbox(`${NS}_emailpermit4`, state.emailpermit4);
                clone.excellanguage = Misc.fromInputTextNullable(`${NS}_excellanguage`, state.excellanguage);
                clone.facturesafficherfraisautrechargepourtransporteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraisautrechargepourtransporteur`, state.facturesafficherfraisautrechargepourtransporteur);
                clone.facturesafficherfraisautresproducteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraisautresproducteur`, state.facturesafficherfraisautresproducteur);
                clone.facturesafficherfraisautresrevenusproducteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraisautresrevenusproducteur`, state.facturesafficherfraisautresrevenusproducteur);
                clone.facturesafficherfraisautresrevenustransporteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraisautresrevenustransporteur`, state.facturesafficherfraisautresrevenustransporteur);
                clone.facturesafficherfraisautrestransporteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraisautrestransporteur`, state.facturesafficherfraisautrestransporteur);
                clone.facturesafficherfraischargeurproducteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraischargeurproducteur`, state.facturesafficherfraischargeurproducteur);
                clone.facturesafficherfraischargeurtransporteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraischargeurtransporteur`, state.facturesafficherfraischargeurtransporteur);
                clone.facturesafficherfraiscompensationdedeplacement = Misc.fromInputCheckbox(`${NS}_facturesafficherfraiscompensationdedeplacement`, state.facturesafficherfraiscompensationdedeplacement);
                clone.facturesaffichersurchargeproducteur = Misc.fromInputCheckbox(`${NS}_facturesaffichersurchargeproducteur`, state.facturesaffichersurchargeproducteur);
                clone.formicon = Misc.fromInputTextNullable(`${NS}_formicon`, state.formicon);
                clone.formtext = Misc.fromInputTextNullable(`${NS}_formtext`, state.formtext);
                clone.fournisseurpointerid = Misc.fromInputNumber(`${NS}_fournisseurpointerid`, state.fournisseurpointerid);
                clone.fromemail = Misc.fromInputTextNullable(`${NS}_fromemail`, state.fromemail);
                clone.gpversion = Misc.fromInputTextNullable(`${NS}_gpversion`, state.gpversion);
                clone.helpfilepath = Misc.fromInputTextNullable(`${NS}_helpfilepath`, state.helpfilepath);
                clone.imprimanteautresrapports = Misc.fromInputTextNullable(`${NS}_imprimanteautresrapports`, state.imprimanteautresrapports);
                clone.imprimantedepermis = Misc.fromInputTextNullable(`${NS}_imprimantedepermis`, state.imprimantedepermis);
                clone.livraisonliertaux = Misc.fromInputCheckbox(`${NS}_livraisonliertaux`, state.livraisonliertaux);
                clone.logfile = Misc.fromInputTextNullable(`${NS}_logfile`, state.logfile);
                clone.logopath = Misc.fromInputTextNullable(`${NS}_logopath`, state.logopath);
                clone.massecontingentvoyagedefaut = Misc.fromInputNumber(`${NS}_massecontingentvoyagedefaut`, state.massecontingentvoyagedefaut);
                clone.masselimitedefaut = Misc.fromInputNumber(`${NS}_masselimitedefaut`, state.masselimitedefaut);
                clone.message_autorisationdeslivraisons = Misc.fromInputTextNullable(`${NS}_message_autorisationdeslivraisons`, state.message_autorisationdeslivraisons);
                clone.message_demandecontingentement = Misc.fromInputTextNullable(`${NS}_message_demandecontingentement`, state.message_demandecontingentement);
                clone.messageimpressionsdefactures = Misc.fromInputTextNullable(`${NS}_messageimpressionsdefactures`, state.messageimpressionsdefactures);
                clone.messagelivraisonnonconforme = Misc.fromInputTextNullable(`${NS}_messagelivraisonnonconforme`, state.messagelivraisonnonconforme);
                clone.messagespecpermitanglais = Misc.fromInputTextNullable(`${NS}_messagespecpermitanglais`, state.messagespecpermitanglais);
                clone.messagespecpermitfrancais = Misc.fromInputTextNullable(`${NS}_messagespecpermitfrancais`, state.messagespecpermitfrancais);
                clone.nomdb = Misc.fromInputTextNullable(`${NS}_nomdb`, state.nomdb);
                clone.permisprintermarginbottom = Misc.fromInputNumberNullable(`${NS}_permisprintermarginbottom`, state.permisprintermarginbottom);
                clone.permisprintermarginleft = Misc.fromInputNumberNullable(`${NS}_permisprintermarginleft`, state.permisprintermarginleft);
                clone.permisprintermarginright = Misc.fromInputNumberNullable(`${NS}_permisprintermarginright`, state.permisprintermarginright);
                clone.permisprintermargintop = Misc.fromInputNumberNullable(`${NS}_permisprintermargintop`, state.permisprintermargintop);
                clone.permisprintpreview = Misc.fromInputCheckbox(`${NS}_permisprintpreview`, state.permisprintpreview);
                clone.preleves_notps = Misc.fromInputTextNullable(`${NS}_preleves_notps`, state.preleves_notps);
                clone.preleves_notvq = Misc.fromInputTextNullable(`${NS}_preleves_notvq`, state.preleves_notvq);
                clone.serveuremail = Misc.fromInputTextNullable(`${NS}_serveuremail`, state.serveuremail);
                clone.showyearsinpermislistview = Misc.fromInputTextNullable(`${NS}_showyearsinpermislistview`, state.showyearsinpermislistview);
                clone.superficiecontingenteepourcentagededuction = Misc.fromInputNumberNullable(`${NS}_superficiecontingenteepourcentagededuction`, state.superficiecontingenteepourcentagededuction);
                clone.superficiecontingenteesansdeduction = Misc.fromInputNumberNullable(`${NS}_superficiecontingenteesansdeduction`, state.superficiecontingenteesansdeduction);
                clone.syndicat_codepostal = Misc.fromInputTextNullable(`${NS}_syndicat_codepostal`, state.syndicat_codepostal);
                clone.syndicat_fax = Misc.fromInputTextNullable(`${NS}_syndicat_fax`, state.syndicat_fax);
                clone.syndicat_nom = Misc.fromInputTextNullable(`${NS}_syndicat_nom`, state.syndicat_nom);
                clone.syndicat_nomanglais = Misc.fromInputTextNullable(`${NS}_syndicat_nomanglais`, state.syndicat_nomanglais);
                clone.syndicat_nomfrancais = Misc.fromInputTextNullable(`${NS}_syndicat_nomfrancais`, state.syndicat_nomfrancais);
                clone.syndicat_notps = Misc.fromInputTextNullable(`${NS}_syndicat_notps`, state.syndicat_notps);
                clone.syndicat_notvq = Misc.fromInputTextNullable(`${NS}_syndicat_notvq`, state.syndicat_notvq);
                clone.syndicat_rue = Misc.fromInputTextNullable(`${NS}_syndicat_rue`, state.syndicat_rue);
                clone.syndicat_telephone = Misc.fromInputTextNullable(`${NS}_syndicat_telephone`, state.syndicat_telephone);
                clone.syndicat_ville = Misc.fromInputTextNullable(`${NS}_syndicat_ville`, state.syndicat_ville);
                clone.syndicatouoffice = Misc.fromInputTextNullable(`${NS}_syndicatouoffice`, state.syndicatouoffice);
                clone.takeacombabackup = Misc.fromInputCheckbox(`${NS}_takeacombabackup`, state.takeacombabackup);
                clone.takesqlbackup = Misc.fromInputCheckbox(`${NS}_takesqlbackup`, state.takesqlbackup);
                clone.tempsentrelesbackupsautomatiques = Misc.fromInputNumberNullable(`${NS}_tempsentrelesbackupsautomatiques`, state.tempsentrelesbackupsautomatiques);
                clone.timeoutsql = Misc.fromInputNumber(`${NS}_timeoutsql`, state.timeoutsql);
                clone.typepermis = Misc.fromInputNumber(`${NS}_typepermis`, state.typepermis);
                clone.typepermis1 = Misc.fromInputTextNullable(`${NS}_typepermis1`, state.typepermis1);
                clone.typepermis1anglais = Misc.fromInputTextNullable(`${NS}_typepermis1anglais`, state.typepermis1anglais);
                clone.typepermis1francais = Misc.fromInputTextNullable(`${NS}_typepermis1francais`, state.typepermis1francais);
                clone.typepermis2 = Misc.fromInputTextNullable(`${NS}_typepermis2`, state.typepermis2);
                clone.typepermis2anglais = Misc.fromInputTextNullable(`${NS}_typepermis2anglais`, state.typepermis2anglais);
                clone.typepermis2francais = Misc.fromInputTextNullable(`${NS}_typepermis2francais`, state.typepermis2francais);
                clone.typepermis3 = Misc.fromInputTextNullable(`${NS}_typepermis3`, state.typepermis3);
                clone.typepermis3anglais = Misc.fromInputTextNullable(`${NS}_typepermis3anglais`, state.typepermis3anglais);
                clone.typepermis3francais = Misc.fromInputTextNullable(`${NS}_typepermis3francais`, state.typepermis3francais);
                clone.typepermis4 = Misc.fromInputTextNullable(`${NS}_typepermis4`, state.typepermis4);
                clone.typepermis4anglais = Misc.fromInputTextNullable(`${NS}_typepermis4anglais`, state.typepermis4anglais);
                clone.typepermis4francais = Misc.fromInputTextNullable(`${NS}_typepermis4francais`, state.typepermis4francais);
                clone.updateotherdatabase = Misc.fromInputTextNullable(`${NS}_updateotherdatabase`, state.updateotherdatabase);
                clone.utiliselesychronisateurdirect = Misc.fromInputCheckbox(`${NS}_utiliselesychronisateurdirect`, state.utiliselesychronisateurdirect);
                clone.utiliserlesnomsdemachinedanslenomdeprinter = Misc.fromInputCheckbox(`${NS}_utiliserlesnomsdemachinedanslenomdeprinter`, state.utiliserlesnomsdemachinedanslenomdeprinter);
                clone.utiliserlotscontingentes = Misc.fromInputCheckbox(`${NS}_utiliserlotscontingentes`, state.utiliserlotscontingentes);
                clone.xlstemplatespath = Misc.fromInputTextNullable(`${NS}_xlstemplatespath`, state.xlstemplatespath);
                clone.fournisseur_planconjoint = Misc.fromSelectText(`${NS}_fournisseur_planconjoint`, state.fournisseur_planconjoint);
                clone.fournisseur_surcharge = Misc.fromSelectText(`${NS}_fournisseur_surcharge`, state.fournisseur_surcharge);
                clone.compte_paiements = Misc.fromSelectNumber(`${NS}_compte_paiements`, state.compte_paiements);
                clone.compte_arecevoir = Misc.fromSelectNumber(`${NS}_compte_arecevoir`, state.compte_arecevoir);
                clone.compte_apayer = Misc.fromSelectNumber(`${NS}_compte_apayer`, state.compte_apayer);
                clone.compte_duauxproducteurs = Misc.fromSelectNumber(`${NS}_compte_duauxproducteurs`, state.compte_duauxproducteurs);
                clone.compte_tpspercues = Misc.fromSelectNumber(`${NS}_compte_tpspercues`, state.compte_tpspercues);
                clone.compte_tpspayees = Misc.fromSelectNumber(`${NS}_compte_tpspayees`, state.compte_tpspayees);
                clone.compte_tvqpercues = Misc.fromSelectNumber(`${NS}_compte_tvqpercues`, state.compte_tvqpercues);
                clone.compte_tvqpayees = Misc.fromSelectNumber(`${NS}_compte_tvqpayees`, state.compte_tvqpayees);
                clone.taux_tps = Misc.fromInputNumberNullable(`${NS}_taux_tps`, state.taux_tps);
                clone.taux_tvq = Misc.fromInputNumberNullable(`${NS}_taux_tvq`, state.taux_tvq);
                clone.fournisseur_fond_roulement = Misc.fromSelectText(`${NS}_fournisseur_fond_roulement`, state.fournisseur_fond_roulement);
                clone.fournisseur_fond_forestier = Misc.fromSelectText(`${NS}_fournisseur_fond_forestier`, state.fournisseur_fond_forestier);
                clone.fournisseur_preleve_divers = Misc.fromSelectText(`${NS}_fournisseur_preleve_divers`, state.fournisseur_preleve_divers);
                return clone;
            };
            valid = (formState) => {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = () => {
                document.getElementById(`${NS}_dummy_submit`).click();
                let form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_39("onchange", onchange = (input) => {
                state = getFormState();
                App.render();
            });
            exports_39("cancel", cancel = () => {
                Router.goBackOrResume(isDirty);
            });
            exports_39("create", create = () => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST("/company", Misc.createBlack(formState, blackList))
                    .then(payload => {
                    let newkey = payload;
                    Misc.toastSuccessSave();
                    Router.goto(`#/admin/company/${newkey.cie}`, 10);
                })
                    .catch(App.render);
            });
            exports_39("save", save = (done = false) => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.PUT("/company", Misc.createBlack(formState, blackList))
                    .then(_ => {
                    Misc.toastSuccessSave();
                    if (done)
                        Router.goto(`#/admin/companys/`, 100);
                    else
                        Router.goto(`#/admin/company/${key.cie}`, 10);
                })
                    .catch(App.render);
            });
            exports_39("drop", drop = () => {
                key.updated = state.updated;
                App.prepareRender();
                App.DELETE("/company", key)
                    .then(_ => {
                    Router.goto(`#/admin/companys/`, 250);
                })
                    .catch(App.render);
            });
            dirtyExit = () => {
                isDirty = !Misc.same(fetchedState, getFormState());
                if (isDirty) {
                    setTimeout(() => {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
// File: lookups.ts
System.register("src/admin/lookups", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/layout", "src/admin/lookupdata"], function (exports_40, context_40) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, layout_5, Lookup, NS, key, state, xtra, uiSelectedRow, currentYear, filterTemplate, trTemplate, tableTemplate, pageTemplate, fetchState, fetch, refresh, render, postRender, inContext, setSelectedRow, isSelectedRow, goto, sortBy, search, filter_groupID, filter_year, gotoDetail, create;
    var __moduleName = context_40 && context_40.id;
    return {
        setters: [
            function (App_13) {
                App = App_13;
            },
            function (Router_8) {
                Router = Router_8;
            },
            function (Perm_5) {
                Perm = Perm_5;
            },
            function (Misc_16) {
                Misc = Misc_16;
            },
            function (Theme_4) {
                Theme = Theme_4;
            },
            function (Pager_2) {
                Pager = Pager_2;
            },
            function (layout_5_1) {
                layout_5 = layout_5_1;
            },
            function (Lookup_3) {
                Lookup = Lookup_3;
            }
        ],
        execute: function () {
            exports_40("NS", NS = "App_lookups");
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 20, sortColumn: "DESCRIPTION", sortDirection: "ASC", filter: { cie: App.cie, groupe: undefined, year: Perm.getCurrentYear() } }
            };
            currentYear = new Date().getFullYear();
            filterTemplate = (groupID, year) => {
                let filters = [];
                filters.push(Theme.renderDropdownFilter(NS, "groupID", groupID, i18n("LOOKUP")));
                filters.push(Theme.renderNumberFilter(NS, "year", year, i18n("YEAR")));
                return filters.join("");
            };
            trTemplate = (item, rowNumber) => {
                var _a;
                let obsolete = item.ended != undefined && item.ended < ((_a = state.pager.filter.year) !== null && _a !== void 0 ? _a : currentYear);
                let classes = [];
                if (isSelectedRow(item.id))
                    classes.push("is-selected");
                if (obsolete)
                    classes.push("has-text-grey-light");
                return `
<tr class="${classes.join(" ")}" onclick="${NS}.gotoDetail(${item.id});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.id)}</td>
    <td>${Misc.toStaticText(item.cie_text)}</td>
    <td>${Misc.toStaticText(item.groupe)}</td>
    <td>${Misc.toStaticText(item.description)}</td>
    <td>${Misc.toStaticText(item.code)}</td>
    <td>${Misc.toStaticText(item.value1)}</td>
    <td>${Misc.toStaticText(item.value2)}</td>
    <td>${Misc.toStaticText(item.value3)}</td>
    <td>${Misc.toStaticText(item.started)}</td>
    <td>${Misc.toStaticText(item.ended)}</td>
    <td>${Misc.toStaticText(item.sortorder)}</td>
</tr>`;
            };
            tableTemplate = (tbody, pager) => {
                return `
<div class="table-container">
<table class="table is-hoverable is-fullwidth">
    <thead>
        <tr>
            <th></th>
            ${Pager.sortableHeaderLink(pager, NS, i18n("ID"), "id", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CIE_TEXT"), "cie_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("GROUPE"), "groupe", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DESCRIPTION"), "description", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CODE"), "code", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE1"), "value1", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE2"), "value2", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE3"), "value3", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("STARTED"), "started", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ENDED"), "ended", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SORTORDER"), "sortorder", "ASC")}
        </tr>
    </thead>
    <tbody>
        ${tbody}
    </tbody>
</table>
</div>
`;
            };
            pageTemplate = (pager, table, tab, warning, dirty) => {
                let readonly = false;
                let buttons = [];
                buttons.push(Theme.buttonAddNew(NS, `#/admin/lookup/new/${key.groupe}`, i18n("Add New")));
                let actions = Theme.renderButtons(buttons);
                let title = layout_5.buildTitle(xtra, `${i18n("Code Table:")} ${xtra.title}`);
                let subtitle = layout_5.buildSubtitle(xtra, i18n("List of All Entries"));
                return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_5.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-pager", pager)}
    ${Theme.wrapContent("js-uc-list", table)}
</div>
</div>

</form>
`;
            };
            exports_40("fetchState", fetchState = (cie, groupe) => {
                Router.registerDirtyExit(null);
                state.pager.filter.cie = cie;
                state.pager.filter.groupe = groupe;
                return App.POST("/lookup/search", state.pager)
                    .then(payload => {
                    state = payload;
                    xtra = payload.xtra;
                    key = { groupe };
                })
                    .then(Lookup.fetch_lutGroup());
            });
            exports_40("fetch", fetch = (params) => {
                let cie = Perm.getCie(params);
                let groupe = params[0];
                App.prepareRender(NS, i18n("lookups"));
                layout_5.prepareMenu();
                fetchState(cie, groupe)
                    .then(App.render)
                    .catch(App.render);
            });
            refresh = () => {
                App.prepareRender(NS, i18n("lookups"));
                App.POST("/lookup/search", state.pager)
                    .then(payload => {
                    state = payload;
                })
                    .then(App.render)
                    .catch(App.render);
            };
            exports_40("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let warning = App.warningTemplate();
                let dirty = "";
                const tbody = state.list.reduce((html, item, index) => {
                    let rowNumber = Pager.rowNumber(state.pager, index);
                    return html + trTemplate(item, rowNumber);
                }, "");
                var year = Perm.getCurrentYear();
                var lookup_lutGroup = Lookup.get_lutGroup(year).map(one => ({
                    id: one.code.toLowerCase(),
                    description: one.description
                }));
                let groupID = Theme.renderOptions(lookup_lutGroup, state.pager.filter.groupe, false);
                const filter = filterTemplate(groupID, state.pager.filter.year);
                const pager = Pager.render(state.pager, NS, [20, 50], null, filter);
                const table = tableTemplate(tbody, state.pager);
                const tab = layout_5.tabTemplate(null, null, null);
                return pageTemplate(pager, table, tab, dirty, warning);
            });
            exports_40("postRender", postRender = () => {
                if (!inContext())
                    return;
            });
            exports_40("inContext", inContext = () => {
                return App.inContext(NS);
            });
            setSelectedRow = (id) => {
                if (uiSelectedRow == undefined)
                    uiSelectedRow = { id };
                uiSelectedRow.id = id;
            };
            isSelectedRow = (id) => {
                if (uiSelectedRow == undefined)
                    return false;
                return (uiSelectedRow.id == id);
            };
            exports_40("goto", goto = (pageNo, pageSize) => {
                state.pager.pageNo = pageNo;
                state.pager.pageSize = pageSize;
                refresh();
            });
            exports_40("sortBy", sortBy = (columnName, direction) => {
                state.pager.pageNo = 1;
                state.pager.sortColumn = columnName;
                state.pager.sortDirection = direction;
                refresh();
            });
            exports_40("search", search = (element) => {
                state.pager.searchText = element.value;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_40("filter_groupID", filter_groupID = (element) => {
                let value = element.options[element.selectedIndex].value;
                let groupe = (value.length > 0 ? value : undefined);
                if (groupe == state.pager.filter.groupe)
                    return;
                Router.goto(`#/admin/lookups/${groupe}`);
            });
            exports_40("filter_year", filter_year = (element) => {
                let value = element.value;
                let year = (value.length > 0 ? +value : undefined);
                if (year == state.pager.filter.year)
                    return;
                state.pager.filter.year = year;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_40("gotoDetail", gotoDetail = (id) => {
                setSelectedRow(id);
                Router.goto(`#/admin/lookup/${id}`);
            });
            exports_40("create", create = () => {
                Router.goto(`#/admin/lookup/new/${state.pager.filter.groupe}`);
            });
        }
    };
});
// File: lookup.ts
System.register("src/admin/lookup", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "src/admin/lookupdata", "src/permission", "src/admin/layout"], function (exports_41, context_41) {
    "use strict";
    var App, Router, Misc, Theme, Lookup, Perm, layout_6, NS, blackList, key, state, fetchedState, xtra, isNew, isDirty, formTemplate, pageTemplate, dirtyTemplate, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, onchange, cancel, create, save, drop, dirtyExit;
    var __moduleName = context_41 && context_41.id;
    return {
        setters: [
            function (App_14) {
                App = App_14;
            },
            function (Router_9) {
                Router = Router_9;
            },
            function (Misc_17) {
                Misc = Misc_17;
            },
            function (Theme_5) {
                Theme = Theme_5;
            },
            function (Lookup_4) {
                Lookup = Lookup_4;
            },
            function (Perm_6) {
                Perm = Perm_6;
            },
            function (layout_6_1) {
                layout_6 = layout_6_1;
            }
        ],
        execute: function () {
            exports_41("NS", NS = "App_lookup");
            blackList = ["cie_text", "created", "by"];
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            formTemplate = (item, cie) => {
                return `

    ${Perm.isSupport() ? Theme.renderDropdownField(NS, "cie", cie, i18n("CIE")) : ""}
    ${Theme.renderTextField(NS, "code", item.code, i18n("CODE"), 12)}
    ${Theme.renderTextField(NS, "description", item.description, i18n("DESCRIPTION"), 50, true)}
    ${Theme.renderTextField(NS, "value1", item.value1, i18n("VALUE1"), 50)}
    ${Theme.renderTextField(NS, "value2", item.value2, i18n("VALUE2"), 50)}
    ${Theme.renderTextField(NS, "value3", item.value3, i18n("VALUE3"), 1024)}
    ${Theme.renderNumberField(NS, "started", item.started, i18n("STARTED"), true)}
    ${Theme.renderNumberField(NS, "ended", item.ended, i18n("ENDED"))}
    ${Theme.renderNumberField(NS, "sortorder", item.sortorder, i18n("SORTORDER"))}
    ${Theme.renderBlame(item, isNew)}
`;
            };
            pageTemplate = (item, form, tab, warning, dirty) => {
                let canEdit = true;
                let readonly = !canEdit;
                let canInsert = canEdit && isNew; // && Perm.hasLookup_CanAddLookup;
                let canDelete = canEdit && !canInsert; // && Perm.hasLookup_CanDeleteLookup;
                let canAdd = canEdit && !canInsert; // && Perm.hasLookup_CanAddLookup;
                let canUpdate = canEdit && !isNew;
                let buttons = [];
                buttons.push(Theme.buttonCancel(NS));
                if (canInsert)
                    buttons.push(Theme.buttonInsert(NS));
                if (canDelete)
                    buttons.push(Theme.buttonDelete(NS));
                if (canAdd)
                    buttons.push(Theme.buttonAddNew(NS, `#/admin/lookup/new/${item.groupe.toLowerCase()}`));
                if (canUpdate)
                    buttons.push(Theme.buttonUpdate(NS));
                let actions = Theme.renderButtons(buttons);
                let title = layout_6.buildTitle(xtra, !isNew ? i18n("lookup Details") : i18n("New lookup"));
                let subtitle = layout_6.buildSubtitle(xtra, i18n("lookup subtitle"));
                return `
<form onsubmit="return false;" ${readonly ? "class='js-readonly'" : ""}>
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_6.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
            ${Theme.renderBlame(item, isNew)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-details", form)}
</div>
</div>

${Theme.renderModalDelete(`modalDelete_${NS}`, `${NS}.drop()`)}

</form>
`;
            };
            dirtyTemplate = () => {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            exports_41("fetchState", fetchState = (id, groupe) => {
                isNew = isNaN(id);
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                return App.GET(`/lookup/${isNew ? `new/${groupe}` : id}`)
                    .then((payload) => {
                    state = payload.item;
                    fetchedState = Misc.clone(state);
                    xtra = payload.xtra;
                    key = { id };
                })
                    .then(Lookup.fetch_cIE());
            });
            exports_41("fetch", fetch = (params) => {
                let id = +params[0];
                let groupe = (params.length > 1 ? params[1] : null);
                App.prepareRender(NS, i18n("lookup"));
                layout_6.prepareMenu();
                fetchState(id, groupe)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_41("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || Object.keys(state).length == 0)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let year = Perm.getCurrentYear(); //or something better
                let lookup_cIE = Lookup.get_cIE(year);
                let cie = Theme.renderOptions(lookup_cIE, state.cie, true);
                const form = formTemplate(state, cie);
                const tab = layout_6.tabTemplate(state.id, /*state.groupe.toLowerCase(),*/ null);
                const dirty = dirtyTemplate();
                const warning = App.warningTemplate();
                return pageTemplate(state, form, tab, warning, dirty);
            });
            exports_41("postRender", postRender = () => {
                if (!inContext())
                    return;
                App.setPageTitle(isNew ? i18n("New lookup") : xtra.title);
            });
            exports_41("inContext", inContext = () => {
                return App.inContext(NS);
            });
            getFormState = () => {
                let clone = Misc.clone(state);
                clone.cie = Misc.fromSelectNumber(`${NS}_cie`, state.cie);
                clone.groupe = Misc.fromInputText(`${NS}_groupe`, state.groupe);
                clone.code = Misc.fromInputTextNullable(`${NS}_code`, state.code);
                clone.description = Misc.fromInputText(`${NS}_description`, state.description);
                clone.value1 = Misc.fromInputTextNullable(`${NS}_value1`, state.value1);
                clone.value2 = Misc.fromInputTextNullable(`${NS}_value2`, state.value2);
                clone.value3 = Misc.fromInputTextNullable(`${NS}_value3`, state.value3);
                clone.started = Misc.fromInputNumber(`${NS}_started`, state.started);
                clone.ended = Misc.fromInputNumberNullable(`${NS}_ended`, state.ended);
                clone.sortorder = Misc.fromInputNumberNullable(`${NS}_sortorder`, state.sortorder);
                return clone;
            };
            valid = (formState) => {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = () => {
                document.getElementById(`${NS}_dummy_submit`).click();
                let form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_41("onchange", onchange = (input) => {
                state = getFormState();
                App.render();
            });
            exports_41("cancel", cancel = () => {
                Router.goBackOrResume(isDirty);
            });
            exports_41("create", create = () => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST("/lookup", Misc.createBlack(formState, blackList))
                    .then(payload => {
                    let newkey = payload;
                    Misc.toastSuccessSave();
                    Router.goto(`#/admin/lookup/${newkey.id}`, 10);
                })
                    .catch(App.render);
            });
            exports_41("save", save = (done = false) => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.PUT("/lookup", Misc.createBlack(formState, blackList))
                    .then(_ => {
                    Misc.toastSuccessSave();
                    if (done)
                        Router.goto(`#/admin/lookups/${state.groupe.toLowerCase()}`, 100);
                    else
                        Router.goto(`#/admin/lookup/${key.id}`, 10);
                })
                    .catch(App.render);
            });
            exports_41("drop", drop = () => {
                key.updated = state.updated;
                App.prepareRender();
                App.DELETE("/lookup", key)
                    .then(_ => {
                    Router.goto(`#/admin/lookups/${state.groupe.toLowerCase()}`, 250);
                })
                    .catch(App.render);
            });
            dirtyExit = () => {
                isDirty = !Misc.same(fetchedState, getFormState());
                if (isDirty) {
                    setTimeout(() => {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
System.register("src/admin/main", ["_BaseApp/src/core/router", "src/admin/accounts", "src/admin/account", "src/admin/company", "src/admin/lookups", "src/admin/lookup"], function (exports_42, context_42) {
    "use strict";
    var Router, accounts, account, company, lookups, lookup, startup, render, postRender;
    var __moduleName = context_42 && context_42.id;
    return {
        setters: [
            function (Router_10) {
                Router = Router_10;
            },
            function (accounts_1) {
                accounts = accounts_1;
            },
            function (account_1) {
                account = account_1;
            },
            function (company_1) {
                company = company_1;
            },
            function (lookups_1) {
                lookups = lookups_1;
            },
            function (lookup_1) {
                lookup = lookup_1;
            }
        ],
        execute: function () {
            //import * as DataFiles from "./datafiles"
            //import * as DataFile from "./datafile"
            //
            // Global references to application objects
            // These must match the "NS" values defined in modules
            // Mainly used for event handlers
            //
            window.App_accounts = accounts;
            window.App_account = account;
            //(<any>window).App_profile = profile;
            window.App_company = company;
            window.App_lookups = lookups;
            window.App_lookup = lookup;
            //(<any>window).App_DataFiles = DataFiles;
            //(<any>window).App_DataFile = DataFile;
            exports_42("startup", startup = () => {
                Router.addRoute("^#/admin/accounts/?(.*)?$", accounts.fetch);
                Router.addRoute("^#/admin/account/(.*)$", account.fetch);
                Router.addRoute("^#/admin/company/?(.*)$", company.fetch);
                Router.addRoute("^#/admin/lookups/?(.*)$", lookups.fetch);
                Router.addRoute("^#/admin/lookup/(.*)$", lookup.fetch);
                //Router.addRoute("^#/files/(.*)$", DataFiles.fetch);
                //Router.addRoute("^#/file/(.*)$", DataFile.fetch);
                //Router.addRoute("^#/admin/audittrails/?(.*)$", AuditTrails.fetch);
            });
            exports_42("render", render = () => {
                return `
    ${accounts.render()}
    ${account.render()}
    ${company.render()}
    ${lookups.render()}
    ${lookup.render()}
`;
                //${DataFiles.render()}
                //${DataFile.render()}
            });
            exports_42("postRender", postRender = () => {
                accounts.postRender();
                account.postRender();
                company.postRender();
                lookups.postRender();
                lookup.postRender();
                //DataFiles.postRender();
                //DataFile.postRender();
            });
        }
    };
});
System.register("src/support/layout", ["_BaseApp/src/core/app", "src/layout"], function (exports_43, context_43) {
    "use strict";
    var App, layout_7, icon, prepareMenu, tabTemplate, buildTitle, buildSubtitle;
    var __moduleName = context_43 && context_43.id;
    return {
        setters: [
            function (App_15) {
                App = App_15;
            },
            function (layout_7_1) {
                layout_7 = layout_7_1;
            }
        ],
        execute: function () {
            exports_43("icon", icon = "far fa-user");
            exports_43("prepareMenu", prepareMenu = () => {
                layout_7.setOpenedMenu("Administration-Management");
            });
            exports_43("tabTemplate", tabTemplate = (id, xtra, isNew = false) => {
                let isCompanys = App.inContext("App_companys");
                let isAnyLookups = App.inContext("App_any_lookups");
                let isFiles = window.location.hash.startsWith("#/files/company");
                let isFile = window.location.hash.startsWith("#/file/company");
                let showFiles = false && xtra != undefined;
                return `
<div class="tabs is-boxed">
    <ul>
        <li ${isCompanys ? "class='is-active'" : ""}>
            <a href="#/support/companys">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("Company List")}</span>
            </a>
        </li>
        <li ${isAnyLookups ? "class='is-active'" : ""}>
            <a href="#/support/any-lookups">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("Lookups")}</span>
            </a>
        </li>
${showFiles ? `
        <li ${isFiles ? "class='is-active'" : ""}>
            <a href="#/files/account/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("Files")} (${xtra.fileCount})</span>
            </a>
        </li>
` : ``}
${isFile ? `
        <li class="is-active">
            <a href="#/file/account/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("File Details")}</span>
            </a>
        </li>
` : ``}

    </ul>
</div>
`;
            });
            exports_43("buildTitle", buildTitle = (xtra, defaultText) => {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.title) !== null && _a !== void 0 ? _a : defaultText;
            });
            exports_43("buildSubtitle", buildSubtitle = (xtra, defaultText) => {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.subtitle) !== null && _a !== void 0 ? _a : defaultText;
            });
        }
    };
});
// File: companys.ts
System.register("src/support/companys", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/lookupdata", "src/support/layout"], function (exports_44, context_44) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, Lookup, layout_8, NS, key, state, xtra, uiSelectedRow, filterTemplate, trTemplate, tableTemplate, pageTemplate, fetchState, fetch, refresh, render, postRender, inContext, setSelectedRow, isSelectedRow, goto, sortBy, search, gotoDetail;
    var __moduleName = context_44 && context_44.id;
    return {
        setters: [
            function (App_16) {
                App = App_16;
            },
            function (Router_11) {
                Router = Router_11;
            },
            function (Perm_7) {
                Perm = Perm_7;
            },
            function (Misc_18) {
                Misc = Misc_18;
            },
            function (Theme_6) {
                Theme = Theme_6;
            },
            function (Pager_3) {
                Pager = Pager_3;
            },
            function (Lookup_5) {
                Lookup = Lookup_5;
            },
            function (layout_8_1) {
                layout_8 = layout_8_1;
            }
        ],
        execute: function () {
            exports_44("NS", NS = "App_companys");
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 20, sortColumn: "CIE", sortDirection: "ASC", filter: {} }
            };
            filterTemplate = () => {
                let filters = [];
                return filters.join("");
            };
            trTemplate = (item, rowNumber) => {
                return `
<tr class="${isSelectedRow(item.cie) ? "is-selected" : ""}" onclick="${NS}.gotoDetail(${item.cie});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.cie)}</td>
    <td>${Misc.toStaticText(item.name)}</td>
    <td>${item.accounts ? `<a href="#/admin/accounts/?cie=${item.cie}" onclick="event.stopPropagation()">${item.accounts} <i class="fal fa-link"></i></a>` : `<span style="opacity: 0.25">0</span>`}</td>
    <td>${item.lookups ? `<a href="#/admin/lookups/?cie=${item.cie}" onclick="event.stopPropagation()">${item.lookups} <i class="fal fa-link"></i></a>` : `<span style="opacity: 0.25">0</span>`}</td>
    <td>${Misc.toStaticCheckbox(item.archive)}</td>
</tr>`;
            };
            tableTemplate = (tbody, pager) => {
                return `
<div class="table-container">
<table class="table is-hoverable is-fullwidth">
    <thead>
        <tr>
            <th></th>
            ${Pager.sortableHeaderLink(pager, NS, i18n("CIE"), "cie", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NAME"), "name", "ASC")}
            ${Pager.headerLink(i18n("ACCOUNTS"))}
            ${Pager.headerLink(i18n("LOOKUPS"))}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ARCHIVE"), "archive", "ASC")}
        </tr>
    </thead>
    <tbody>
        ${tbody}
    </tbody>
</table>
</div>
`;
            };
            pageTemplate = (pager, table, tab, warning, dirty) => {
                let readonly = false;
                let buttons = [];
                buttons.push(Theme.buttonAddNew(NS, "#/admin/company/new", i18n("Add New")));
                let actions = Theme.renderButtons(buttons);
                let title = layout_8.buildTitle(xtra, i18n("companys title"));
                let subtitle = layout_8.buildSubtitle(xtra, i18n("companys subtitle"));
                return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_8.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    <div class="columns">
    <div class="column is-6 is-offset-3">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-pager", pager)}
    ${Theme.wrapContent("js-uc-list", table)}
    </div>
    </div>
</div>
</div>

</form>
`;
            };
            exports_44("fetchState", fetchState = (cie) => {
                Router.registerDirtyExit(null);
                return App.POST("/company/search", state.pager)
                    .then(payload => {
                    state = payload;
                    xtra = payload.xtra;
                    key = {};
                })
                    .then(Lookup.fetch_autreFournisseur())
                    .then(Lookup.fetch_compte());
            });
            exports_44("fetch", fetch = (params) => {
                let cie = +params[0];
                App.prepareRender(NS, i18n("companys"));
                fetchState(cie)
                    .then(App.render)
                    .catch(App.render);
            });
            refresh = () => {
                App.prepareRender(NS, i18n("companys"));
                App.POST("/company/search", state.pager)
                    .then(payload => {
                    state = payload;
                })
                    .then(App.render)
                    .catch(App.render);
            };
            exports_44("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let warning = App.warningTemplate();
                let dirty = "";
                const tbody = state.list.reduce((html, item, index) => {
                    let rowNumber = Pager.rowNumber(state.pager, index);
                    return html + trTemplate(item, rowNumber);
                }, "");
                let year = Perm.getCurrentYear(); //state.pager.filter.year;
                const filter = filterTemplate();
                const search = Pager.searchTemplate(state.pager, NS);
                const pager = Pager.render(state.pager, NS, [20, 50], search, filter);
                const table = tableTemplate(tbody, state.pager);
                const tab = layout_8.tabTemplate(null, null);
                return pageTemplate(pager, table, tab, dirty, warning);
            });
            exports_44("postRender", postRender = () => {
                if (!inContext())
                    return;
            });
            exports_44("inContext", inContext = () => {
                return App.inContext(NS);
            });
            setSelectedRow = (cie) => {
                if (uiSelectedRow == undefined)
                    uiSelectedRow = { cie };
                uiSelectedRow.cie = cie;
            };
            isSelectedRow = (cie) => {
                if (uiSelectedRow == undefined)
                    return false;
                return (uiSelectedRow.cie == cie);
            };
            exports_44("goto", goto = (pageNo, pageSize) => {
                state.pager.pageNo = pageNo;
                state.pager.pageSize = pageSize;
                refresh();
            });
            exports_44("sortBy", sortBy = (columnName, direction) => {
                state.pager.pageNo = 1;
                state.pager.sortColumn = columnName;
                state.pager.sortDirection = direction;
                refresh();
            });
            exports_44("search", search = (element) => {
                state.pager.searchText = element.value;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_44("gotoDetail", gotoDetail = (cie) => {
                setSelectedRow(cie);
                Router.goto(`#/admin/company/?cie=${cie}`);
            });
        }
    };
});
// File: network.ts
System.register("src/support/security", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "src/permission", "src/support/layout"], function (exports_45, context_45) {
    "use strict";
    var App, Router, Misc, Theme, Perm, layout_9, NS, key, state, fetchedState, isNew, isDirty, thKindTemplate, thRoleTemplate, trTemplate, tableTemplate, pageTemplate, dirtyTemplate, clearState, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, onchange, rowClick, cancel, create, save, dirtyExit;
    var __moduleName = context_45 && context_45.id;
    return {
        setters: [
            function (App_17) {
                App = App_17;
            },
            function (Router_12) {
                Router = Router_12;
            },
            function (Misc_19) {
                Misc = Misc_19;
            },
            function (Theme_7) {
                Theme = Theme_7;
            },
            function (Perm_8) {
                Perm = Perm_8;
            },
            function (layout_9_1) {
                layout_9 = layout_9_1;
            }
        ],
        execute: function () {
            exports_45("NS", NS = "App_security");
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            thKindTemplate = (item) => {
                return `
<th colspan="${item.ro.length}">${item.stnKind}</th>
`;
            };
            thRoleTemplate = (item) => {
                return `
<th>${item.role2.replace(" ", "<br>")}</th>
`;
            };
            trTemplate = (item, item2, index, masks, titles) => {
                let permID = item2.permID;
                let permValue = item2.perm[0].permValue;
                let tdCells = masks.reduce((html, mask, index) => {
                    let title = titles[index];
                    let checked = (mask & permValue) > 0;
                    return html + `<td data-mask="${mask}" data-checked="${checked}" title="${title}" class="js-cell">${checked ? `<i class="far fa-check"></i>` : ""}</td>`;
                }, "");
                return `
<tr onclick="${NS}.rowClick(${permID})">
    ${index == 0 ? `<td rowspan="${item.item.length}" data-group="1" style="text-align: left;">${item.groupe}</td>` : ``}
    <td style="text-align: left;">${item2.description}</td>
    <td>${permID}</td>
    ${tdCells}
</tr>
`;
            };
            tableTemplate = (thead1, thead2, tbody) => {
                return `
<form onsubmit="return false;">
    <input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="container">
<table class="table is-hoverable is-fullwidth is-bordered is-narrow">
    <thead>
        <tr>
            <th class="js-empty"></th>
            <th class="js-empty"></th>
            <th class="js-empty"></th>
            ${thead1}
        </tr>
        <tr>
            <th class="js-empty"></th>
            <th class="js-empty"></th>
            <th class="js-empty"></th>
            ${thead2}
        </tr>
    </thead>
    <tbody>
        ${tbody}
    </tbody>
</table>
</div>

</form>`;
            };
            pageTemplate = (item, table, tab, warning, dirty) => {
                let canUpdate = Perm.isSupport();
                let readonly = !canUpdate;
                return `
<style>
    .table thead th.js-empty { border: none; }
    .table thead th:not(.js-empty) { vertical-align: bottom; background-color: rgb(68, 70, 79); line-height: 1.25rem; }
    .table thead th { color: #aaa }
    .table td, .table th { text-align: center; }
    .table .js-cell[data-checked='true'] { background-color: #228b2240; }
    .table .js-cell[data-checked] { cursor: pointer; }
    .js-uc-details.js-readonly td { pointer-events: none; }
</style>

<section class="js-uc-heading">
    <div class="js-container">
        <div class="js-left">
            <h2><span class="icon"><i class="${layout_9.icon}"></i></span> Security Matrix: <span>${Misc.toInputText(item.xtra && item.xtra.title)}</span></h2>
            <h3>Editing Network Security</h3>
        </div>
        <div class="js-right">
        </div>
    </div>
</section>
${dirty}
${warning}
<div class="js-uc-details ${readonly ? "js-readonly" : ""}">
    ${tab}
    ${table}
    <hr>
    ${Theme.renderActionButtons(NS, isNew, null, null, !isNew)}
</div>
`;
            };
            dirtyTemplate = () => {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            clearState = () => {
                state = {};
            };
            exports_45("fetchState", fetchState = (cie) => {
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                clearState();
                let url = `/security/${cie}`;
                return App.GET(url)
                    .then(payload => {
                    state = payload;
                    fetchedState = Misc.clone(state);
                    key = { cie };
                    isNew = (state.items[0].item[0].perm[0].permValue == undefined);
                });
            });
            exports_45("fetch", fetch = (params) => {
                let cie = Perm.getCie(params);
                App.prepareRender(NS, i18n("Security"));
                fetchState(cie)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_45("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined)
                    return (App.serverError() ? pageTemplate(null, "", "", App.warningTemplate(), "") : "");
                const thead1 = state.roles
                    .reduce((html, item) => html + thKindTemplate(item), "");
                const thead2 = state.roles
                    .reduce((html, item) => html + item.ro.reduce((html2, item2) => html2 + thRoleTemplate(item2), ""), "");
                const masks = state.roles
                    .map(item => item.ro.map(item2 => item2.role_bit))
                    .reduce((acc, item) => acc.concat(item), []);
                const titles = state.roles
                    .map(item => item.ro.map(item2 => `${item.stnKind} [${item2.role2}]`))
                    .reduce((acc, item) => acc.concat(item), []);
                const tbody = state.items
                    .reduce((html, item) => html + item.item.reduce((html2, item2, index) => html2 + trTemplate(item, item2, index, masks, titles), ""), "");
                const table = tableTemplate(thead1, thead2, tbody);
                const tab = layout_9.tabTemplate(key.cie, null, isNew);
                const dirty = dirtyTemplate();
                const warning = App.warningTemplate();
                return pageTemplate(state, table, tab, warning, dirty);
            });
            exports_45("postRender", postRender = () => {
                if (!inContext())
                    return;
            });
            exports_45("inContext", inContext = () => {
                return App.inContext(NS);
            });
            getFormState = () => {
                let clone = Misc.clone(state);
                return clone;
            };
            valid = (formState) => {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = () => {
                document.getElementById(`${NS}_dummy_submit`).click();
                let form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_45("onchange", onchange = (input) => {
                state = getFormState();
                App.render();
            });
            exports_45("rowClick", rowClick = (permID) => {
                event.stopPropagation();
                let target = event.target.closest("td");
                if (target.dataset.mask == undefined)
                    return;
                let mask = +target.dataset.mask;
                state.items.forEach(group => group.item.forEach(item => {
                    if (item.permID == permID) {
                        let permValue = item.perm[0].permValue;
                        permValue = ((permValue & mask) == 0 ? permValue | mask : permValue & ~mask);
                        item.perm[0].permValue = permValue;
                    }
                }));
                App.render();
            });
            exports_45("cancel", cancel = () => {
                Router.goBackOrResume(isDirty);
            });
            exports_45("create", create = () => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST(`/security/${key.cie}`, {})
                    .then(_ => {
                    Misc.toastSuccessSave();
                    Router.goto(`#/support/security/${key.cie}`, 10);
                })
                    .catch(App.render);
            });
            exports_45("save", save = () => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                let uto = formState.items
                    .map(itm => itm.item.map(item => { return { id: item.permID, value: item.perm[0].permValue }; }))
                    .reduce((acc, item) => acc.concat(item), []);
                App.prepareRender();
                App.PUT(`/security/${key.cie}`, uto)
                    .then(_ => {
                    Misc.toastSuccessSave();
                    Router.goto(`#/support/security/${key.cie}`, 10);
                })
                    .catch(App.render);
            });
            dirtyExit = () => {
                isDirty = !Misc.same(fetchedState, getFormState());
                if (isDirty) {
                    setTimeout(() => {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
// File: lookup.ts
System.register("src/support/any-lookups", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "_BaseApp/src/theme/calendar", "src/admin/lookupdata", "src/support/layout"], function (exports_46, context_46) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, calendar_1, Lookup, layout_10, NS, table_id, blackList, state, fetchedState, xtra, isNew, isDirty, filterTemplate, trTemplateLeft, trTemplateRight, tableTemplateLeft, tableTemplateRight, pageTemplate, dirtyTemplate, fetchState, fetch, refresh, render, postRender, inContext, goto, sortBy, search, filter_cie, getFormState, valid, html5Valid, onchange, ondate, undo, addNew, create, save, selectfordrop, drop, hasChanges, dirtyExit, clearFilterPlus, addFilterPlus, removeFilterPlus;
    var __moduleName = context_46 && context_46.id;
    return {
        setters: [
            function (App_18) {
                App = App_18;
            },
            function (Router_13) {
                Router = Router_13;
            },
            function (Perm_9) {
                Perm = Perm_9;
            },
            function (Misc_20) {
                Misc = Misc_20;
            },
            function (Theme_8) {
                Theme = Theme_8;
            },
            function (Pager_4) {
                Pager = Pager_4;
            },
            function (calendar_1_1) {
                calendar_1 = calendar_1_1;
            },
            function (Lookup_6) {
                Lookup = Lookup_6;
            },
            function (layout_10_1) {
                layout_10 = layout_10_1;
            }
        ],
        execute: function () {
            exports_46("NS", NS = "App_any_lookups");
            table_id = "any_lookups_table";
            blackList = ["_editing", "_deleting", "_isNew", "totalcount", "cie_text", "created", "by"];
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: App.getPageState(NS, "pageSize", 20), sortColumn: "ID", sortDirection: "ASC", filter: { cie: undefined } }
            };
            fetchedState = {};
            isNew = false;
            isDirty = false;
            filterTemplate = (cie) => {
                let filters = [];
                filters.push(Theme.renderDropdownFilter(NS, "cie", cie, i18n("CIE")));
                return filters.join("");
            };
            trTemplateLeft = (item, editId, deleteId, rowNumber) => {
                let id = item.id;
                let tdConfirm = `<td class="js-td-33">&nbsp;</td>`;
                if (item._editing)
                    tdConfirm = `<td onclick="${NS}.save()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
                if (item._deleting)
                    tdConfirm = `<td onclick="${NS}.drop()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
                if (item._isNew)
                    tdConfirm = `<td onclick="${NS}.create()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
                let clickUndo = item._editing || item._deleting || item._isNew;
                let markDeletion = !clickUndo;
                let canEdit = true; //perm && perm.canEdit;
                let readonly = (deleteId != undefined) || (editId != undefined && id != editId) || (isNew && !item._isNew) || (!canEdit);
                let classList = [];
                if (item._editing || item._isNew)
                    classList.push("js-not-same");
                if (item._deleting)
                    classList.push("js-strikeout");
                if (item._isNew)
                    classList.push("js-new");
                if (readonly)
                    classList.push("js-readonly");
                if (!canEdit)
                    classList.push("js-noclick");
                return `
<tr data-id="${id}" class="${classList.join(" ")}" style="cursor: pointer;">
    <td class="js-index">${rowNumber}</td>

${markDeletion ? `<td onclick="${NS}.selectfordrop(${id})" class="has-text-danger js-td-33 js-drop" title="Click to mark for deletion"><i class='fas fa-times'></i></td>` : ``}
${clickUndo ? `<td onclick="${NS}.undo()" class="has-text-primary js-td-33" title="Click to undo"><i class='fa fa-undo'></i></td>` : ``}
${tdConfirm}

</tr>`;
            };
            trTemplateRight = (item, editId, deleteId, cie) => {
                let id = item.id;
                let canEdit = true; //perm && perm.canEdit;
                let readonly = (deleteId != undefined) || (editId != undefined && id != editId) || (isNew && !item._isNew) || (!canEdit);
                let classList = [];
                if (item._editing || item._isNew)
                    classList.push("js-not-same");
                if (item._deleting)
                    classList.push("js-strikeout");
                if (item._isNew)
                    classList.push("js-new");
                if (readonly)
                    classList.push("js-readonly");
                return `
<tr data-id="${id}" class="${classList.join(" ")}" style="cursor: pointer;">
${!readonly ? `
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `cie_${id}`, cie)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `groupe_${id}`, item.groupe, 12, true)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `code_${id}`, item.code, 12)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `description_${id}`, item.description, 50, true)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `value1_${id}`, item.value1, 50)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `value2_${id}`, item.value2, 50)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `value3_${id}`, item.value3, 1024)}</td>
    <td class="js-inline-input">${Theme.renderNumberInline(NS, `started_${id}`, item.started, true)}</td>
    <td class="js-inline-input">${Theme.renderNumberInline(NS, `ended_${id}`, item.ended)}</td>
    <td class="js-inline-input">${Theme.renderNumberInline(NS, `sortorder_${id}`, item.sortorder)}</td>
` : `
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.cie_text)}</div></td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.groupe)}</div></td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.code)}</div></td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.description)}</div></td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.value1)}</div></td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.value2)}</div></td>
    <td><div class="js-truncate" style="width:100px;">${Misc.toStaticText(item.value3)}</div></td>
    <td><div class="js-number">${Misc.toStaticNumber(item.started)}</div></td>
    <td><div class="js-number">${Misc.toStaticNumber(item.ended)}</div></td>
    <td><div class="js-number">${Misc.toStaticNumber(item.sortorder)}</div></td>
`}
</tr>`;
            };
            tableTemplateLeft = (tbody, editId, deleteId) => {
                let disableAddNew = (deleteId != undefined || editId != undefined || isNew);
                let canEdit = true; //perm && perm.canEdit;
                disableAddNew = disableAddNew || !canEdit;
                return `
<style>.js-td-33 { width: 33px; }</style>
<div>
<table class="table is-hoverable js-inline" style="width: 10px; table-layout: fixed;">
    <thead>
        <tr>
            <th style="width:99px" colspan="3">&nbsp;</th>
        </tr>
    </thead>
    <tbody>
        ${tbody}
        <tr class="js-insert-row ${disableAddNew ? "js-noclick" : ""}">
            <td class="js-index js-td-33">*</td>
            <td class="has-text-primary js-td-33 js-add" onclick="${NS}.addNew()" title="Click to add a new row"><i class="fas fa-plus"></i></td>
            <td></td>
        </tr>
    </tbody>
</table>
</div>
`;
            };
            tableTemplateRight = (tbody, pager) => {
                return `
<div id="${table_id}" class="table-container">
<table class="table is-hoverable js-inline" style="width: 100px; table-layout: fixed;">
    <thead>
        <tr>
            ${Pager.sortableHeaderLink(pager, NS, i18n("CIE"), "cie_text", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("GROUPE"), "groupe", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CODE"), "code", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DESCRIPTION"), "description", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE1"), "value1", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE2"), "value2", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VALUE3"), "value3", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("STARTED"), "started", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ENDED"), "ended", "ASC", "width:100px")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SORTORDER"), "sortorder", "ASC", "width:100px")}
        </tr>
    </thead>
    <tbody>
        ${tbody}
        <tr class="js-insert-row">
            <td colspan="${10 + 4}">&nbsp;</td>
        </tr>
    </tbody>
</table>
</div>
`;
            };
            pageTemplate = (xtra, pager, tableLeft, tableRight, tab, warning, dirty) => {
                let readonly = false;
                let buttons = [];
                let actions = Theme.renderButtons(buttons);
                let title = layout_10.buildTitle(xtra, i18n("AAA: AAA"));
                let subtitle = layout_10.buildSubtitle(xtra, i18n("AAA"));
                let table = `<div style="display: flex;">
    <div>${tableLeft}</div>
    <div style="width:calc(100% - 99px)">${tableRight}</div>
</div>`;
                return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_10.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-pager", pager)}
    ${Theme.wrapContent("js-uc-list", table)}
</div>
</div>

</form>
`;
            };
            dirtyTemplate = () => {
                return (isDirty ? App.dirtyTemplate(NS, null) : "");
            };
            exports_46("fetchState", fetchState = (id) => {
                isNew = false;
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                return App.POST("/lookup/search", state.pager)
                    .then(payload => {
                    state = payload;
                    fetchedState = Misc.clone(state);
                    xtra = payload.xtra;
                })
                    .then(Lookup.fetch_cIE());
            });
            exports_46("fetch", fetch = (params) => {
                let id = +params[0];
                App.prepareRender(NS, i18n("lookup"));
                layout_10.prepareMenu();
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            refresh = () => {
                App.prepareRender(NS, i18n("lookup"));
                clearFilterPlus();
                App.POST("/lookup/search", state.pager)
                    .then(payload => {
                    state = payload;
                    fetchedState = Misc.clone(state);
                })
                    .then(App.render)
                    .catch(App.render);
            };
            exports_46("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let editId;
                let deleteId;
                state.list.forEach((item, index) => {
                    let prevItem = fetchedState.list[index];
                    item._editing = !Misc.same(item, prevItem);
                    if (item._editing)
                        editId = item.id;
                    if (item._deleting)
                        deleteId = item.id;
                });
                let year = Perm.getCurrentYear(); //or something better
                let lookup_cIE = Lookup.get_cIE(year);
                const tbodyLeft = state.list.reduce((html, item, index) => {
                    let rowNumber = Pager.rowNumber(state.pager, index);
                    return html + trTemplateLeft(item, editId, deleteId, rowNumber);
                }, "");
                const tbodyRight = state.list.reduce((html, item) => {
                    let cie = Theme.renderOptions(lookup_cIE, item.cie, true);
                    return html + trTemplateRight(item, editId, deleteId, cie);
                }, "");
                let cie = Theme.renderOptions(lookup_cIE, state.pager.filter.cie, true);
                const filter = filterTemplate(cie);
                const search = Pager.searchTemplate(state.pager, NS);
                const pager = Pager.render(state.pager, NS, [10, 20, 50], search, filter);
                const tableLeft = tableTemplateLeft(tbodyLeft, editId, deleteId);
                const tableRight = tableTemplateRight(tbodyRight, state.pager);
                const tab = layout_10.tabTemplate(null, null);
                const dirty = dirtyTemplate();
                let warning = App.warningTemplate();
                return pageTemplate(xtra, pager, tableLeft, tableRight, tab, dirty, warning);
            });
            exports_46("postRender", postRender = () => {
                if (!inContext())
                    return;
            });
            exports_46("inContext", inContext = () => {
                return App.inContext(NS);
            });
            exports_46("goto", goto = (pageNo, pageSize) => {
                state.pager.pageNo = pageNo;
                state.pager.pageSize = App.setPageState(NS, "pageSize", pageSize);
                refresh();
            });
            exports_46("sortBy", sortBy = (columnName, direction) => {
                state.pager.pageNo = 1;
                state.pager.sortColumn = columnName;
                state.pager.sortDirection = direction;
                refresh();
            });
            exports_46("search", search = (element) => {
                state.pager.searchText = element.value;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_46("filter_cie", filter_cie = (element) => {
                let value = element.options[element.selectedIndex].value;
                let cie = (value.length > 0 ? +value : undefined);
                if (cie == state.pager.filter.cie)
                    return;
                state.pager.filter.cie = cie;
                state.pager.pageNo = 1;
                refresh();
            });
            getFormState = () => {
                let clone = Misc.clone(state);
                clone.list.forEach(item => {
                    let id = item.id;
                    item.cie = Misc.fromSelectNumber(`${NS}_cie_${id}`, item.cie);
                    item.groupe = Misc.fromInputText(`${NS}_groupe_${id}`, item.groupe);
                    item.code = Misc.fromInputTextNullable(`${NS}_code_${id}`, item.code);
                    item.description = Misc.fromInputText(`${NS}_description_${id}`, item.description);
                    item.value1 = Misc.fromInputTextNullable(`${NS}_value1_${id}`, item.value1);
                    item.value2 = Misc.fromInputTextNullable(`${NS}_value2_${id}`, item.value2);
                    item.value3 = Misc.fromInputTextNullable(`${NS}_value3_${id}`, item.value3);
                    item.started = Misc.fromInputNumber(`${NS}_started_${id}`, item.started);
                    item.ended = Misc.fromInputNumberNullable(`${NS}_ended_${id}`, item.ended);
                    item.sortorder = Misc.fromInputNumberNullable(`${NS}_sortorder_${id}`, item.sortorder);
                });
                return clone;
            };
            valid = (formState) => {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = () => {
                document.getElementById(`${NS}_dummy_submit`).click();
                let form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_46("onchange", onchange = (input) => {
                state = getFormState();
                let parts = input.id.replace(`${NS}_`, "").split("_");
                let field = parts[0];
                let id = +parts[1];
                let record = state.list.find(one => one.id == id);
                //if (field == "field_name") {
                //    record.some_field = null;
                //}
                App.render();
            });
            exports_46("ondate", ondate = (input, eventname) => {
                return calendar_1.eventMan(NS, input, eventname);
            });
            exports_46("undo", undo = () => {
                if (isNew) {
                    isNew = false;
                    fetchedState.list.pop();
                }
                state = Misc.clone(fetchedState);
                isDirty = false;
                App.render();
            });
            exports_46("addNew", addNew = () => {
                let url = "/lookup/new";
                return App.GET(url)
                    .then((payload) => {
                    state.list.push(payload.item);
                    fetchedState = Misc.clone(state);
                    isNew = true;
                    payload.item._isNew = true;
                })
                    .then(App.render)
                    .catch(App.render);
            });
            exports_46("create", create = () => {
                let formState = getFormState();
                let item = formState.list.find(one => one._isNew);
                if (!html5Valid())
                    return;
                if (!valid(item))
                    return App.render();
                App.prepareRender();
                App.POST("/lookup", Misc.createBlack(item, blackList))
                    .then((key) => {
                    addFilterPlus(key.id);
                    fetchedState = Misc.clone(state);
                    Router.gotoCurrent(1);
                })
                    .catch(App.render);
            });
            exports_46("save", save = () => {
                let formState = getFormState();
                let item = formState.list.find(one => one._editing);
                if (!html5Valid())
                    return;
                if (!valid(item))
                    return App.render();
                App.prepareRender();
                App.PUT("/lookup", Misc.createBlack(item, blackList))
                    .then(() => {
                    fetchedState = Misc.clone(state);
                    Router.gotoCurrent(1);
                })
                    .catch(App.render);
            });
            exports_46("selectfordrop", selectfordrop = (id) => {
                state = Misc.clone(fetchedState);
                state.list.find(one => one.id == id)._deleting = true;
                App.render();
            });
            exports_46("drop", drop = () => {
                App.prepareRender();
                let item = state.list.find(one => one._deleting);
                App.DELETE("/lookup", { id: item.id, updated: item.updated })
                    .then(() => {
                    removeFilterPlus(item.id);
                    fetchedState = Misc.clone(state);
                    Router.gotoCurrent(1);
                })
                    .catch(App.render);
            });
            exports_46("hasChanges", hasChanges = () => {
                return !Misc.same(fetchedState, state);
            });
            dirtyExit = () => {
                isDirty = !Misc.same(fetchedState, getFormState());
                if (isDirty) {
                    setTimeout(() => {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
            clearFilterPlus = () => {
                state.pager.filter.plus = undefined;
                isNew = false;
            };
            addFilterPlus = (id) => {
                if (state.pager.filter.plus)
                    state.pager.filter.plus += `,${id}`;
                else
                    state.pager.filter.plus = id.toString();
            };
            removeFilterPlus = (id) => {
            };
        }
    };
});
System.register("src/support/main", ["_BaseApp/src/core/router", "src/support/companys", "src/support/security", "src/support/any-lookups"], function (exports_47, context_47) {
    "use strict";
    var Router, companys, security, any_lookups, startup, render, postRender;
    var __moduleName = context_47 && context_47.id;
    return {
        setters: [
            function (Router_14) {
                Router = Router_14;
            },
            function (companys_1) {
                companys = companys_1;
            },
            function (security_1) {
                security = security_1;
            },
            function (any_lookups_1) {
                any_lookups = any_lookups_1;
            }
        ],
        execute: function () {
            //import * as DataFiles from "./datafiles"
            //import * as DataFile from "./datafile"
            //
            // Global references to application objects
            // These must match the "NS" values defined in modules
            // Mainly used for event handlers
            //
            window.App_companys = companys;
            window.App_security = security;
            window.App_any_lookups = any_lookups;
            //(<any>window).App_DataFiles = DataFiles;
            //(<any>window).App_DataFile = DataFile;
            exports_47("startup", startup = () => {
                Router.addRoute("^#/support/companys/?(.*)?$", companys.fetch);
                Router.addRoute("^#/support/security/?(.*)?$", security.fetch);
                Router.addRoute("^#/support/any-lookups/?(.*)?$", any_lookups.fetch);
                //Router.addRoute("^#/files/(.*)$", DataFiles.fetch);
                //Router.addRoute("^#/file/(.*)$", DataFile.fetch);
            });
            exports_47("render", render = () => {
                return `
    ${companys.render()}
    ${security.render()}
    ${any_lookups.render()}
`;
                //${DataFiles.render()}
                //${DataFile.render()}
            });
            exports_47("postRender", postRender = () => {
                companys.postRender();
                security.postRender();
                any_lookups.postRender();
                //DataFiles.postRender();
                //DataFile.postRender();
            });
        }
    };
});
System.register("src/christian/layout", ["_BaseApp/src/core/app", "src/layout"], function (exports_48, context_48) {
    "use strict";
    var App, layout_11, icon, prepareMenu, tabTemplate, buildTitle, buildSubtitle;
    var __moduleName = context_48 && context_48.id;
    return {
        setters: [
            function (App_19) {
                App = App_19;
            },
            function (layout_11_1) {
                layout_11 = layout_11_1;
            }
        ],
        execute: function () {
            exports_48("icon", icon = "far fa-user");
            exports_48("prepareMenu", prepareMenu = () => {
                layout_11.setOpenedMenu("Christian");
            });
            exports_48("tabTemplate", tabTemplate = (id, xtra, isNew = false) => {
                var _a, _b, _c;
                let isoffices = App.inContext("App_offices");
                let isoffice = App.inContext("App_office");
                let isstaffs = App.inContext("App_staffs");
                let isstaff = App.inContext("App_staff");
                let isrooms = App.inContext("App_rooms");
                let isroom = App.inContext("App_room");
                let isFiles = window.location.hash.startsWith("#/files/office");
                let isFile = window.location.hash.startsWith("#/file/office");
                let showOffice = !isoffices;
                let showStaff = !isoffices && !(isoffice && isNew);
                let showRoom = !isoffices && !(isoffice && isNew);
                let showFiles = !isoffices && !(isoffice && isNew);
                return `
<div class="tabs is-boxed">
    <ul>
        <li ${isoffices ? "class='is-active'" : ""}>
            <a href="#/offices">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("List")}</span>
            </a>
        </li>

${showOffice ? `
        <li ${isoffice ? "class='is-active'" : ""}>
            <a href="#/office/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("office Details")}</span>
            </a>
        </li>
` : ``}

${showStaff ? `
        <li ${isstaffs ? "class='is-active'" : ""}>
            <a href="#/staffs/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>Staff (${(_a = xtra === null || xtra === void 0 ? void 0 : xtra.staffcount) !== null && _a !== void 0 ? _a : -1})</span>
            </a>
        </li>
${isstaff ? `
        <li class="is-active">
            <a>
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>Staff</span>
            </a>
        </li>
` : ``}
` : ``}

${showRoom ? `
        <li ${isrooms ? "class='is-active'" : ""}>
            <a href="#/rooms/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>Rooms (${(_b = xtra === null || xtra === void 0 ? void 0 : xtra.roomcount) !== null && _b !== void 0 ? _b : -1})</span>
            </a>
        </li>
` : ``}

${showFiles ? `
        <li ${isFiles ? "class='is-active'" : ""}>
            <a href="#/files/office/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("Files")} (${(_c = xtra === null || xtra === void 0 ? void 0 : xtra.filecount) !== null && _c !== void 0 ? _c : -1})</span>
            </a>
        </li>
${isFile ? `
        <li ${isFile ? "class='is-active'" : ""}>
            <a>
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("File Details")}</span>
            </a>
        </li>
` : ``}
` : ``}

    </ul>
</div>
`;
            });
            exports_48("buildTitle", buildTitle = (xtra, defaultText) => {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.title) !== null && _a !== void 0 ? _a : defaultText;
            });
            exports_48("buildSubtitle", buildSubtitle = (xtra, defaultText) => {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.subtitle) !== null && _a !== void 0 ? _a : defaultText;
            });
        }
    };
});
// File: offices.ts
System.register("src/christian/offices", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/christian/layout"], function (exports_49, context_49) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, layout_12, NS, key, state, xtra, uiSelectedRow, filterTemplate, trTemplate, tableTemplate, pageTemplate, fetchState, fetch, refresh, render, postRender, inContext, setSelectedRow, isSelectedRow, goto, sortBy, search, gotoDetail;
    var __moduleName = context_49 && context_49.id;
    return {
        setters: [
            function (App_20) {
                App = App_20;
            },
            function (Router_15) {
                Router = Router_15;
            },
            function (Perm_10) {
                Perm = Perm_10;
            },
            function (Misc_21) {
                Misc = Misc_21;
            },
            function (Theme_9) {
                Theme = Theme_9;
            },
            function (Pager_5) {
                Pager = Pager_5;
            },
            function (layout_12_1) {
                layout_12 = layout_12_1;
            }
        ],
        execute: function () {
            exports_49("NS", NS = "App_offices");
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 20, sortColumn: "ID", sortDirection: "ASC", filter: {} }
            };
            filterTemplate = () => {
                let filters = [];
                return filters.join("");
            };
            trTemplate = (item, rowNumber) => {
                return `
<tr class="${isSelectedRow(item.id) ? "is-selected" : ""}" onclick="${NS}.gotoDetail(${item.id});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.id)}</td>
    <td>${Misc.toStaticText(item.name)}</td>
    <td>${Misc.toStaticText(item.location)}</td>
    <td>${Misc.toStaticDate(item.openedon)}</td>
    <td>${Misc.toStaticCheckbox(item.archive)}</td>
</tr>`;
            };
            tableTemplate = (tbody, pager) => {
                return `
<div class="table-container">
<table class="table is-hoverable is-fullwidth">
    <thead>
        <tr>
            <th></th>
            ${Pager.sortableHeaderLink(pager, NS, i18n("ID"), "id", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NAME"), "name", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LOCATION"), "location", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("OPENEDON"), "openedon", "DESC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ARCHIVE"), "archive", "ASC")}
        </tr>
    </thead>
    <tbody>
        ${tbody}
    </tbody>
</table>
</div>
`;
            };
            pageTemplate = (pager, table, tab, warning, dirty) => {
                let readonly = false;
                let buttons = [];
                buttons.push(Theme.buttonAddNew(NS, `#/office/new`, i18n("Add New")));
                let actions = Theme.renderButtons(buttons);
                let title = layout_12.buildTitle(xtra, i18n("offices title"));
                let subtitle = layout_12.buildSubtitle(xtra, i18n("offices subtitle"));
                return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_12.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-pager", pager)}
    ${Theme.wrapContent("js-uc-list", table)}
</div>
</div>

</form>
`;
            };
            exports_49("fetchState", fetchState = (id) => {
                Router.registerDirtyExit(null);
                return App.POST(`/office/search`, state.pager)
                    .then(payload => {
                    state = payload;
                    xtra = payload.xtra;
                    key = {};
                });
            });
            exports_49("fetch", fetch = (params) => {
                let id = +params[0];
                App.prepareRender(NS, i18n("offices"));
                layout_12.prepareMenu();
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            refresh = () => {
                App.prepareRender(NS, i18n("offices"));
                App.POST(`/office/search`, state.pager)
                    .then(payload => {
                    state = payload;
                })
                    .then(App.render)
                    .catch(App.render);
            };
            exports_49("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let warning = App.warningTemplate();
                let dirty = "";
                const tbody = state.list.reduce((html, item, index) => {
                    let rowNumber = Pager.rowNumber(state.pager, index);
                    return html + trTemplate(item, rowNumber);
                }, "");
                let year = Perm.getCurrentYear(); //state.pager.filter.year;
                const filter = filterTemplate();
                const search = Pager.searchTemplate(state.pager, NS);
                const pager = Pager.render(state.pager, NS, [20, 50], search, filter);
                const table = tableTemplate(tbody, state.pager);
                const tab = layout_12.tabTemplate(null, null);
                return pageTemplate(pager, table, tab, dirty, warning);
            });
            exports_49("postRender", postRender = () => {
                if (!inContext())
                    return;
            });
            exports_49("inContext", inContext = () => {
                return App.inContext(NS);
            });
            setSelectedRow = (id) => {
                if (uiSelectedRow == undefined)
                    uiSelectedRow = { id };
                uiSelectedRow.id = id;
            };
            isSelectedRow = (id) => {
                if (uiSelectedRow == undefined)
                    return false;
                return (uiSelectedRow.id == id);
            };
            exports_49("goto", goto = (pageNo, pageSize) => {
                state.pager.pageNo = pageNo;
                state.pager.pageSize = pageSize;
                refresh();
            });
            exports_49("sortBy", sortBy = (columnName, direction) => {
                state.pager.pageNo = 1;
                state.pager.sortColumn = columnName;
                state.pager.sortDirection = direction;
                refresh();
            });
            exports_49("search", search = (element) => {
                state.pager.searchText = element.value;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_49("gotoDetail", gotoDetail = (id) => {
                setSelectedRow(id);
                Router.goto(`#/office/${id}`);
            });
        }
    };
});
// File: office.ts
System.register("src/christian/office", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/calendar", "src/permission", "src/christian/layout"], function (exports_50, context_50) {
    "use strict";
    var App, Router, Misc, Theme, calendar_2, Perm, layout_13, NS, blackList, key, state, fetchedState, xtra, isNew, isDirty, openedonCalendar, formTemplate, pageTemplate, dirtyTemplate, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, oncalendar, onchange, cancel, create, save, drop, dirtyExit;
    var __moduleName = context_50 && context_50.id;
    return {
        setters: [
            function (App_21) {
                App = App_21;
            },
            function (Router_16) {
                Router = Router_16;
            },
            function (Misc_22) {
                Misc = Misc_22;
            },
            function (Theme_10) {
                Theme = Theme_10;
            },
            function (calendar_2_1) {
                calendar_2 = calendar_2_1;
            },
            function (Perm_11) {
                Perm = Perm_11;
            },
            function (layout_13_1) {
                layout_13 = layout_13_1;
            }
        ],
        execute: function () {
            exports_50("NS", NS = "App_office");
            blackList = ["created", "updatedby", "by"];
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            openedonCalendar = new calendar_2.Calendar(`${NS}_openedon`);
            formTemplate = (item) => {
                return `
${isNew ? `
` : `
    ${Theme.renderStaticField(Misc.toStaticNumber(item.id), i18n("ID"))}
`}
    ${Theme.renderTextField(NS, "name", item.name, i18n("NAME"), 50, true)}
    ${Theme.renderTextField(NS, "location", item.location, i18n("LOCATION"), 50, true)}
    ${Theme.renderCalendarField(NS, "openedon", openedonCalendar, i18n("OPENEDON"))}
    ${Theme.renderCheckboxField(NS, "archive", item.archive, i18n("ARCHIVE"))}
    ${Theme.renderBlame(item, isNew)}
`;
            };
            pageTemplate = (item, form, tab, warning, dirty) => {
                let canEdit = true;
                let readonly = !canEdit;
                let canInsert = canEdit && isNew; // && Perm.hasOffice_CanAddOffice;
                let canDelete = canEdit && !canInsert; // && Perm.hasOffice_CanDeleteOffice;
                let canAdd = canEdit && !canInsert; // && Perm.hasOffice_CanAddOffice;
                let canUpdate = canEdit && !isNew;
                let buttons = [];
                buttons.push(Theme.buttonCancel(NS));
                if (canInsert)
                    buttons.push(Theme.buttonInsert(NS));
                if (canDelete)
                    buttons.push(Theme.buttonDelete(NS));
                if (canAdd)
                    buttons.push(Theme.buttonAddNew(NS, `#/office/new`));
                if (canUpdate)
                    buttons.push(Theme.buttonUpdate(NS));
                let actions = Theme.renderButtons(buttons);
                let title = layout_13.buildTitle(xtra, !isNew ? i18n("office Details") : i18n("New office"));
                let subtitle = layout_13.buildSubtitle(xtra, i18n("office subtitle"));
                return `
<form onsubmit="return false;" ${readonly ? "class='js-readonly'" : ""}>
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_13.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
            ${Theme.renderBlame(item, isNew)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-details", form)}
</div>
</div>

${Theme.renderModalDelete(`modalDelete_${NS}`, `${NS}.drop()`)}

</form>
`;
            };
            dirtyTemplate = () => {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            exports_50("fetchState", fetchState = (id) => {
                isNew = isNaN(id);
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                return App.GET(`/office/${isNew ? "new" : id}`)
                    .then((payload) => {
                    state = payload.item;
                    fetchedState = Misc.clone(state);
                    xtra = payload.xtra;
                    key = { id };
                    openedonCalendar.setState(state.openedon);
                });
            });
            exports_50("fetch", fetch = (params) => {
                let id = +params[0];
                App.prepareRender(NS, i18n("office"));
                layout_13.prepareMenu();
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_50("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || Object.keys(state).length == 0)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let year = Perm.getCurrentYear(); //or something better
                const form = formTemplate(state);
                const tab = layout_13.tabTemplate(state.id, xtra, isNew);
                const dirty = dirtyTemplate();
                const warning = App.warningTemplate();
                return pageTemplate(state, form, tab, warning, dirty);
            });
            exports_50("postRender", postRender = () => {
                if (!inContext())
                    return;
                openedonCalendar.postRender();
                App.setPageTitle(isNew ? i18n("New office") : xtra.title);
            });
            exports_50("inContext", inContext = () => {
                return App.inContext(NS);
            });
            getFormState = () => {
                let clone = Misc.clone(state);
                clone.name = Misc.fromInputText(`${NS}_name`, state.name);
                clone.location = Misc.fromInputText(`${NS}_location`, state.location);
                clone.openedon = Misc.fromInputDateNullable(`${NS}_openedon`, state.openedon);
                clone.archive = Misc.fromInputCheckbox(`${NS}_archive`, state.archive);
                return clone;
            };
            valid = (formState) => {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = () => {
                document.getElementById(`${NS}_dummy_submit`).click();
                let form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_50("oncalendar", oncalendar = (id) => {
                if (openedonCalendar.id == id)
                    openedonCalendar.toggle();
            });
            exports_50("onchange", onchange = (input) => {
                state = getFormState();
                App.render();
            });
            exports_50("cancel", cancel = () => {
                Router.goBackOrResume(isDirty);
            });
            exports_50("create", create = () => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST("/office", Misc.createBlack(formState, blackList))
                    .then(payload => {
                    let newkey = payload;
                    Misc.toastSuccessSave();
                    Router.goto(`#/office/${newkey.id}`, 10);
                })
                    .catch(App.render);
            });
            exports_50("save", save = (done = false) => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.PUT("/office", Misc.createBlack(formState, blackList))
                    .then(_ => {
                    Misc.toastSuccessSave();
                    if (done)
                        Router.goto(`#/offices/`, 100);
                    else
                        Router.goto(`#/office/${key.id}`, 10);
                })
                    .catch(App.render);
            });
            exports_50("drop", drop = () => {
                key.updated = state.updated;
                App.prepareRender();
                App.DELETE("/office", key)
                    .then(_ => {
                    Router.goto(`#/offices/`, 250);
                })
                    .catch(App.render);
            });
            dirtyExit = () => {
                isDirty = !Misc.same(fetchedState, getFormState());
                if (isDirty) {
                    setTimeout(() => {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
// File: staffs.ts
System.register("src/christian/staffs", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/lookupdata", "src/christian/layout"], function (exports_51, context_51) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, Lookup, layout_14, NS, key, state, xtra, uiSelectedRow, filterTemplate, trTemplate, tableTemplate, pageTemplate, fetchState, fetch, refresh, render, postRender, inContext, setSelectedRow, isSelectedRow, goto, sortBy, search, gotoDetail;
    var __moduleName = context_51 && context_51.id;
    return {
        setters: [
            function (App_22) {
                App = App_22;
            },
            function (Router_17) {
                Router = Router_17;
            },
            function (Perm_12) {
                Perm = Perm_12;
            },
            function (Misc_23) {
                Misc = Misc_23;
            },
            function (Theme_11) {
                Theme = Theme_11;
            },
            function (Pager_6) {
                Pager = Pager_6;
            },
            function (Lookup_7) {
                Lookup = Lookup_7;
            },
            function (layout_14_1) {
                layout_14 = layout_14_1;
            }
        ],
        execute: function () {
            exports_51("NS", NS = "App_staffs");
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 20, sortColumn: "ID", sortDirection: "ASC", filter: {} }
            };
            filterTemplate = () => {
                let filters = [];
                return filters.join("");
            };
            trTemplate = (item, rowNumber) => {
                return `
<tr class="${isSelectedRow(item.id) ? "is-selected" : ""}" onclick="${NS}.gotoDetail(${item.id});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.id)}</td>
    <td>${Misc.toStaticText(item.firstname)}</td>
    <td>${Misc.toStaticText(item.lastname)}</td>
    <td>${Misc.toStaticText(item.jobid_text)}</td>
    <td>${Misc.toStaticCheckbox(item.archive)}</td>
</tr>`;
            };
            tableTemplate = (tbody, pager) => {
                return `
<div class="table-container">
<table class="table is-hoverable is-fullwidth">
    <thead>
        <tr>
            <th></th>
            ${Pager.sortableHeaderLink(pager, NS, i18n("ID"), "id", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FIRSTNAME"), "firstname", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LASTNAME"), "lastname", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("JOBID_TEXT"), "jobid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ARCHIVE"), "archive", "ASC")}
        </tr>
    </thead>
    <tbody>
        ${tbody}
    </tbody>
</table>
</div>
`;
            };
            pageTemplate = (pager, table, tab, warning, dirty) => {
                let readonly = false;
                let buttons = [];
                buttons.push(Theme.buttonAddNew(NS, `#/staff/new/${key.officeid}`, i18n("Add New")));
                let actions = Theme.renderButtons(buttons);
                let title = layout_14.buildTitle(xtra, i18n("staffs title"));
                let subtitle = layout_14.buildSubtitle(xtra, i18n("staffs subtitle"));
                return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_14.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-pager", pager)}
    ${Theme.wrapContent("js-uc-list", table)}
</div>
</div>

</form>
`;
            };
            exports_51("fetchState", fetchState = (officeid) => {
                Router.registerDirtyExit(null);
                state.pager.filter.officeid = officeid;
                return App.POST(`/staff/search/${officeid}/office`, state.pager)
                    .then(payload => {
                    state = payload;
                    xtra = payload.xtra;
                    key = { officeid };
                })
                    .then(Lookup.fetch_job());
            });
            exports_51("fetch", fetch = (params) => {
                let officeid = +params[0];
                App.prepareRender(NS, i18n("staffs"));
                layout_14.prepareMenu();
                fetchState(officeid)
                    .then(App.render)
                    .catch(App.render);
            });
            refresh = () => {
                App.prepareRender(NS, i18n("staffs"));
                App.POST(`/staff/search/${key.officeid}/office`, state.pager)
                    .then(payload => {
                    state = payload;
                })
                    .then(App.render)
                    .catch(App.render);
            };
            exports_51("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let warning = App.warningTemplate();
                let dirty = "";
                const tbody = state.list.reduce((html, item, index) => {
                    let rowNumber = Pager.rowNumber(state.pager, index);
                    return html + trTemplate(item, rowNumber);
                }, "");
                let year = Perm.getCurrentYear(); //state.pager.filter.year;
                const filter = filterTemplate();
                const search = Pager.searchTemplate(state.pager, NS);
                const pager = Pager.render(state.pager, NS, [20, 50], search, filter);
                const table = tableTemplate(tbody, state.pager);
                const tab = layout_14.tabTemplate(key.officeid, xtra);
                return pageTemplate(pager, table, tab, dirty, warning);
            });
            exports_51("postRender", postRender = () => {
                if (!inContext())
                    return;
            });
            exports_51("inContext", inContext = () => {
                return App.inContext(NS);
            });
            setSelectedRow = (id) => {
                if (uiSelectedRow == undefined)
                    uiSelectedRow = { id };
                uiSelectedRow.id = id;
            };
            isSelectedRow = (id) => {
                if (uiSelectedRow == undefined)
                    return false;
                return (uiSelectedRow.id == id);
            };
            exports_51("goto", goto = (pageNo, pageSize) => {
                state.pager.pageNo = pageNo;
                state.pager.pageSize = pageSize;
                refresh();
            });
            exports_51("sortBy", sortBy = (columnName, direction) => {
                state.pager.pageNo = 1;
                state.pager.sortColumn = columnName;
                state.pager.sortDirection = direction;
                refresh();
            });
            exports_51("search", search = (element) => {
                state.pager.searchText = element.value;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_51("gotoDetail", gotoDetail = (id) => {
                setSelectedRow(id);
                Router.goto(`#/staff/${id}/${key.officeid}`);
            });
        }
    };
});
// File: staff.ts
System.register("src/christian/staff", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "src/admin/lookupdata", "src/permission", "src/christian/layout"], function (exports_52, context_52) {
    "use strict";
    var App, Router, Misc, Theme, Lookup, Perm, layout_15, NS, blackList, key, state, fetchedState, xtra, isNew, isDirty, formTemplate, pageTemplate, dirtyTemplate, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, onchange, cancel, create, save, drop, dirtyExit;
    var __moduleName = context_52 && context_52.id;
    return {
        setters: [
            function (App_23) {
                App = App_23;
            },
            function (Router_18) {
                Router = Router_18;
            },
            function (Misc_24) {
                Misc = Misc_24;
            },
            function (Theme_12) {
                Theme = Theme_12;
            },
            function (Lookup_8) {
                Lookup = Lookup_8;
            },
            function (Perm_13) {
                Perm = Perm_13;
            },
            function (layout_15_1) {
                layout_15 = layout_15_1;
            }
        ],
        execute: function () {
            exports_52("NS", NS = "App_staff");
            blackList = ["officeid_text", "jobid_text", "created", "updatedby", "by"];
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            formTemplate = (item, jobid) => {
                return `
${isNew ? `
` : `
    ${Theme.renderStaticField(Misc.toStaticNumber(item.id), i18n("ID"))}
`}
    ${Theme.renderTextField(NS, "firstname", item.firstname, i18n("FIRSTNAME"), 50, true)}
    ${Theme.renderTextField(NS, "lastname", item.lastname, i18n("LASTNAME"), 50, true)}
    ${Theme.renderDropdownField(NS, "jobid", jobid, i18n("JOBID"))}
    ${Theme.renderCheckboxField(NS, "archive", item.archive, i18n("ARCHIVE"))}
    ${Theme.renderBlame(item, isNew)}
`;
            };
            pageTemplate = (item, form, tab, warning, dirty) => {
                let canEdit = true;
                let readonly = !canEdit;
                let canInsert = canEdit && isNew; // && Perm.hasStaff_CanAddStaff;
                let canDelete = canEdit && !canInsert; // && Perm.hasStaff_CanDeleteStaff;
                let canAdd = canEdit && !canInsert; // && Perm.hasStaff_CanAddStaff;
                let canUpdate = canEdit && !isNew;
                let buttons = [];
                buttons.push(Theme.buttonCancel(NS));
                if (canInsert)
                    buttons.push(Theme.buttonInsert(NS));
                if (canDelete)
                    buttons.push(Theme.buttonDelete(NS));
                if (canAdd)
                    buttons.push(Theme.buttonAddNew(NS, `#/staff/new/${state.officeid}`));
                if (canUpdate)
                    buttons.push(Theme.buttonUpdate(NS));
                let actions = Theme.renderButtons(buttons);
                let title = layout_15.buildTitle(xtra, !isNew ? i18n("staff Details") : i18n("New staff"));
                let subtitle = layout_15.buildSubtitle(xtra, `${i18n("Editing staff")}: <span>${item.firstname}</span>`);
                return `
<form onsubmit="return false;" ${readonly ? "class='js-readonly'" : ""}>
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_15.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
            ${Theme.renderBlame(item, isNew)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-details", form)}
</div>
</div>

${Theme.renderModalDelete(`modalDelete_${NS}`, `${NS}.drop()`)}

</form>
`;
            };
            dirtyTemplate = () => {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            exports_52("fetchState", fetchState = (id, officeid) => {
                isNew = isNaN(id);
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                return App.GET(`/staff/${isNew ? `new/${officeid}` : id}/office`)
                    .then((payload) => {
                    state = payload.item;
                    fetchedState = Misc.clone(state);
                    xtra = payload.xtra;
                    key = { id };
                })
                    .then(Lookup.fetch_job());
            });
            exports_52("fetch", fetch = (params) => {
                let id = +params[0];
                let officeid = +params[1];
                App.prepareRender(NS, i18n("staff"));
                layout_15.prepareMenu();
                fetchState(id, officeid)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_52("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || Object.keys(state).length == 0)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let year = Perm.getCurrentYear(); //or something better
                let lookup_job = Lookup.get_job(year);
                let jobid = Theme.renderOptions(lookup_job, state.jobid, true);
                const form = formTemplate(state, jobid);
                const tab = layout_15.tabTemplate(state.officeid, xtra, isNew);
                const dirty = dirtyTemplate();
                const warning = App.warningTemplate();
                return pageTemplate(state, form, tab, warning, dirty);
            });
            exports_52("postRender", postRender = () => {
                if (!inContext())
                    return;
                App.setPageTitle(isNew ? i18n("New staff") : xtra.title);
            });
            exports_52("inContext", inContext = () => {
                return App.inContext(NS);
            });
            getFormState = () => {
                let clone = Misc.clone(state);
                clone.firstname = Misc.fromInputText(`${NS}_firstname`, state.firstname);
                clone.lastname = Misc.fromInputText(`${NS}_lastname`, state.lastname);
                clone.officeid = Misc.fromSelectNumber(`${NS}_officeid`, state.officeid);
                clone.jobid = Misc.fromSelectNumber(`${NS}_jobid`, state.jobid);
                clone.archive = Misc.fromInputCheckbox(`${NS}_archive`, state.archive);
                return clone;
            };
            valid = (formState) => {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = () => {
                document.getElementById(`${NS}_dummy_submit`).click();
                let form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_52("onchange", onchange = (input) => {
                state = getFormState();
                App.render();
            });
            exports_52("cancel", cancel = () => {
                Router.goBackOrResume(isDirty);
            });
            exports_52("create", create = () => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST("/staff", Misc.createBlack(formState, blackList))
                    .then(payload => {
                    let newkey = payload;
                    Misc.toastSuccessSave();
                    Router.goto(`#/staff/${newkey.id}`, 10);
                })
                    .catch(App.render);
            });
            exports_52("save", save = (done = false) => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.PUT("/staff", Misc.createBlack(formState, blackList))
                    .then(_ => {
                    Misc.toastSuccessSave();
                    if (done)
                        Router.goto(`#/staffs/${state.officeid}`, 100);
                    else
                        Router.goto(`#/staff/${key.id}`, 10);
                })
                    .catch(App.render);
            });
            exports_52("drop", drop = () => {
                key.updated = state.updated;
                App.prepareRender();
                App.DELETE("/staff", key)
                    .then(_ => {
                    let officeid = state.officeid;
                    Router.goto(`#/staffs/${officeid}`, 250);
                })
                    .catch(App.render);
            });
            dirtyExit = () => {
                isDirty = !Misc.same(fetchedState, getFormState());
                if (isDirty) {
                    setTimeout(() => {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
System.register("src/christian/layout_2", ["_BaseApp/src/core/app", "src/layout"], function (exports_53, context_53) {
    "use strict";
    var App, layout_16, icon, prepareMenu, tabTemplate, buildTitle, buildSubtitle;
    var __moduleName = context_53 && context_53.id;
    return {
        setters: [
            function (App_24) {
                App = App_24;
            },
            function (layout_16_1) {
                layout_16 = layout_16_1;
            }
        ],
        execute: function () {
            exports_53("icon", icon = "far fa-user");
            exports_53("prepareMenu", prepareMenu = () => {
                layout_16.setOpenedMenu("Christian");
            });
            exports_53("tabTemplate", tabTemplate = (id, xtra, isNew = false) => {
                var _a, _b;
                let isstaffs = App.inContext("App_staffs_2");
                let isstaff = App.inContext("App_staff_2");
                let isequipments = App.inContext("App_equipments");
                let isequipment = App.inContext("App_equipment");
                let isFiles = window.location.hash.startsWith("#/files/staff");
                let isFile = window.location.hash.startsWith("#/file/staff");
                let showstaff = !isstaffs;
                let showequipment = !isstaffs && !(isstaff && isNew);
                let showFiles = !isstaffs && !(isstaff && isNew);
                return `
<div class="tabs is-boxed">
    <ul>
        <li ${isstaffs ? "class='is-active'" : ""}>
            <a href="#/staffs_2">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("List")}</span>
            </a>
        </li>

${showstaff ? `
        <li ${isstaff ? "class='is-active'" : ""}>
            <a href="#/staff_2/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("staff Details")}</span>
            </a>
        </li>
` : ``}

${showequipment ? `
        <li ${isequipments ? "class='is-active'" : ""}>
            <a href="#/equipments/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>equipment (${(_a = xtra === null || xtra === void 0 ? void 0 : xtra.equipmentcount) !== null && _a !== void 0 ? _a : -1})</span>
            </a>
        </li>
${isequipment ? `
        <li class="is-active">
            <a>
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>equipment</span>
            </a>
        </li>
` : ``}
` : ``}

${showFiles ? `
        <li ${isFiles ? "class='is-active'" : ""}>
            <a href="#/files/staff/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("Files")} (${(_b = xtra === null || xtra === void 0 ? void 0 : xtra.filecount) !== null && _b !== void 0 ? _b : -1})</span>
            </a>
        </li>
${isFile ? `
        <li ${isFile ? "class='is-active'" : ""}>
            <a>
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("File Details")}</span>
            </a>
        </li>
` : ``}
` : ``}

    </ul>
</div>
`;
            });
            exports_53("buildTitle", buildTitle = (xtra, defaultText) => {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.title) !== null && _a !== void 0 ? _a : defaultText;
            });
            exports_53("buildSubtitle", buildSubtitle = (xtra, defaultText) => {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.subtitle) !== null && _a !== void 0 ? _a : defaultText;
            });
        }
    };
});
// File: staffs.ts
System.register("src/christian/staffs_2", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/lookupdata", "src/christian/layout_2"], function (exports_54, context_54) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, Lookup, layout_2_2, NS, key, state, xtra, uiSelectedRow, filterTemplate, trTemplate, tableTemplate, pageTemplate, fetchState, fetch, refresh, render, postRender, inContext, setSelectedRow, isSelectedRow, goto, sortBy, search, filter_officeid, filter_jobid, gotoDetail;
    var __moduleName = context_54 && context_54.id;
    return {
        setters: [
            function (App_25) {
                App = App_25;
            },
            function (Router_19) {
                Router = Router_19;
            },
            function (Perm_14) {
                Perm = Perm_14;
            },
            function (Misc_25) {
                Misc = Misc_25;
            },
            function (Theme_13) {
                Theme = Theme_13;
            },
            function (Pager_7) {
                Pager = Pager_7;
            },
            function (Lookup_9) {
                Lookup = Lookup_9;
            },
            function (layout_2_2_1) {
                layout_2_2 = layout_2_2_1;
            }
        ],
        execute: function () {
            exports_54("NS", NS = "App_staffs_2");
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 20, sortColumn: "ID", sortDirection: "ASC", filter: {} }
            };
            filterTemplate = (officeid, jobid) => {
                let filters = [];
                filters.push(Theme.renderDropdownFilter(NS, "officeid", officeid, i18n("OFFICEID")));
                filters.push(Theme.renderDropdownFilter(NS, "jobid", jobid, i18n("JOBID")));
                return filters.join("");
            };
            trTemplate = (item, rowNumber) => {
                return `
<tr class="${isSelectedRow(item.id) ? "is-selected" : ""}" onclick="${NS}.gotoDetail(${item.id});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.id)}</td>
    <td>${Misc.toStaticText(item.firstname)}</td>
    <td>${Misc.toStaticText(item.lastname)}</td>
    <td>${Misc.toStaticText(item.officeid_text)}</td>
    <td>${Misc.toStaticText(item.jobid_text)}</td>
    <td>${Misc.toStaticCheckbox(item.archive)}</td>
</tr>`;
            };
            tableTemplate = (tbody, pager) => {
                return `
<div class="table-container">
<table class="table is-hoverable is-fullwidth">
    <thead>
        <tr>
            <th></th>
            ${Pager.sortableHeaderLink(pager, NS, i18n("ID"), "id", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FIRSTNAME"), "firstname", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LASTNAME"), "lastname", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("OFFICEID_TEXT"), "officeid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("JOBID_TEXT"), "jobid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ARCHIVE"), "archive", "ASC")}
        </tr>
    </thead>
    <tbody>
        ${tbody}
    </tbody>
</table>
</div>
`;
            };
            pageTemplate = (pager, table, tab, warning, dirty) => {
                let readonly = false;
                let buttons = [];
                buttons.push(Theme.buttonAddNew(NS, `#/staff_2/new`, i18n("Add New")));
                let actions = Theme.renderButtons(buttons);
                let title = layout_2_2.buildTitle(xtra, i18n("staffs title"));
                let subtitle = layout_2_2.buildSubtitle(xtra, i18n("staffs subtitle"));
                return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_2_2.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-pager", pager)}
    ${Theme.wrapContent("js-uc-list", table)}
</div>
</div>

</form>
`;
            };
            exports_54("fetchState", fetchState = (id) => {
                Router.registerDirtyExit(null);
                return App.POST(`/staff/search`, state.pager)
                    .then(payload => {
                    state = payload;
                    xtra = payload.xtra;
                    key = {};
                })
                    .then(Lookup.fetch_office())
                    .then(Lookup.fetch_job());
            });
            exports_54("fetch", fetch = (params) => {
                let id = +params[0];
                App.prepareRender(NS, i18n("staffs"));
                layout_2_2.prepareMenu();
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            refresh = () => {
                App.prepareRender(NS, i18n("staffs"));
                App.POST(`/staff/search`, state.pager)
                    .then(payload => {
                    state = payload;
                })
                    .then(App.render)
                    .catch(App.render);
            };
            exports_54("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let warning = App.warningTemplate();
                let dirty = "";
                const tbody = state.list.reduce((html, item, index) => {
                    let rowNumber = Pager.rowNumber(state.pager, index);
                    return html + trTemplate(item, rowNumber);
                }, "");
                let year = Perm.getCurrentYear(); //state.pager.filter.year;
                let lookup_office = Lookup.get_office(year);
                let lookup_job = Lookup.get_job(year);
                let officeid = Theme.renderOptions(lookup_office, state.pager.filter.officeid, true);
                let jobid = Theme.renderOptions(lookup_job, state.pager.filter.jobid, true);
                const filter = filterTemplate(officeid, jobid);
                const search = Pager.searchTemplate(state.pager, NS);
                const pager = Pager.render(state.pager, NS, [20, 50], search, filter);
                const table = tableTemplate(tbody, state.pager);
                const tab = layout_2_2.tabTemplate(null, null);
                return pageTemplate(pager, table, tab, dirty, warning);
            });
            exports_54("postRender", postRender = () => {
                if (!inContext())
                    return;
            });
            exports_54("inContext", inContext = () => {
                return App.inContext(NS);
            });
            setSelectedRow = (id) => {
                if (uiSelectedRow == undefined)
                    uiSelectedRow = { id };
                uiSelectedRow.id = id;
            };
            isSelectedRow = (id) => {
                if (uiSelectedRow == undefined)
                    return false;
                return (uiSelectedRow.id == id);
            };
            exports_54("goto", goto = (pageNo, pageSize) => {
                state.pager.pageNo = pageNo;
                state.pager.pageSize = pageSize;
                refresh();
            });
            exports_54("sortBy", sortBy = (columnName, direction) => {
                state.pager.pageNo = 1;
                state.pager.sortColumn = columnName;
                state.pager.sortDirection = direction;
                refresh();
            });
            exports_54("search", search = (element) => {
                state.pager.searchText = element.value;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_54("filter_officeid", filter_officeid = (element) => {
                let value = element.options[element.selectedIndex].value;
                let officeid = (value.length > 0 ? +value : undefined);
                if (officeid == state.pager.filter.officeid)
                    return;
                state.pager.filter.officeid = officeid;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_54("filter_jobid", filter_jobid = (element) => {
                let value = element.options[element.selectedIndex].value;
                let jobid = (value.length > 0 ? +value : undefined);
                if (jobid == state.pager.filter.jobid)
                    return;
                state.pager.filter.jobid = jobid;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_54("gotoDetail", gotoDetail = (id) => {
                setSelectedRow(id);
                Router.goto(`#/staff_2/${id}`);
            });
        }
    };
});
// File: staff.ts
System.register("src/christian/staff_2", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "src/admin/lookupdata", "src/permission", "src/christian/layout_2"], function (exports_55, context_55) {
    "use strict";
    var App, Router, Misc, Theme, Lookup, Perm, layout_2_3, NS, blackList, key, state, fetchedState, xtra, isNew, isDirty, formTemplate, pageTemplate, dirtyTemplate, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, onchange, cancel, create, save, drop, dirtyExit;
    var __moduleName = context_55 && context_55.id;
    return {
        setters: [
            function (App_26) {
                App = App_26;
            },
            function (Router_20) {
                Router = Router_20;
            },
            function (Misc_26) {
                Misc = Misc_26;
            },
            function (Theme_14) {
                Theme = Theme_14;
            },
            function (Lookup_10) {
                Lookup = Lookup_10;
            },
            function (Perm_15) {
                Perm = Perm_15;
            },
            function (layout_2_3_1) {
                layout_2_3 = layout_2_3_1;
            }
        ],
        execute: function () {
            exports_55("NS", NS = "App_staff_2");
            blackList = ["officeid_text", "jobid_text", "created", "updatedby", "by"];
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            formTemplate = (item, officeid, jobid) => {
                return `
${isNew ? `
` : `
    ${Theme.renderStaticField(Misc.toStaticNumber(item.id), i18n("ID"))}
`}
    ${Theme.renderTextField(NS, "firstname", item.firstname, i18n("FIRSTNAME"), 50, true)}
    ${Theme.renderTextField(NS, "lastname", item.lastname, i18n("LASTNAME"), 50, true)}
    ${Theme.renderDropdownField(NS, "officeid", officeid, i18n("OFFICEID"))}
    ${Theme.renderDropdownField(NS, "jobid", jobid, i18n("JOBID"))}
    ${Theme.renderCheckboxField(NS, "archive", item.archive, i18n("ARCHIVE"))}
    ${Theme.renderBlame(item, isNew)}
`;
            };
            pageTemplate = (item, form, tab, warning, dirty) => {
                let canEdit = true;
                let readonly = !canEdit;
                let canInsert = canEdit && isNew; // && Perm.hasStaff_CanAddStaff;
                let canDelete = canEdit && !canInsert; // && Perm.hasStaff_CanDeleteStaff;
                let canAdd = canEdit && !canInsert; // && Perm.hasStaff_CanAddStaff;
                let canUpdate = canEdit && !isNew;
                let buttons = [];
                buttons.push(Theme.buttonCancel(NS));
                if (canInsert)
                    buttons.push(Theme.buttonInsert(NS));
                if (canDelete)
                    buttons.push(Theme.buttonDelete(NS));
                if (canAdd)
                    buttons.push(Theme.buttonAddNew(NS, `#/staff_2/new`));
                if (canUpdate)
                    buttons.push(Theme.buttonUpdate(NS));
                let actions = Theme.renderButtons(buttons);
                let title = layout_2_3.buildTitle(xtra, !isNew ? i18n("staff Details") : i18n("New staff"));
                let subtitle = layout_2_3.buildSubtitle(xtra, i18n("staff subtitle"));
                return `
<form onsubmit="return false;" ${readonly ? "class='js-readonly'" : ""}>
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_2_3.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
            ${Theme.renderBlame(item, isNew)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-details", form)}
</div>
</div>

${Theme.renderModalDelete(`modalDelete_${NS}`, `${NS}.drop()`)}

</form>
`;
            };
            dirtyTemplate = () => {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            exports_55("fetchState", fetchState = (id) => {
                isNew = isNaN(id);
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                return App.GET(`/staff/${isNew ? "new" : id}`)
                    .then((payload) => {
                    state = payload.item;
                    fetchedState = Misc.clone(state);
                    xtra = payload.xtra;
                    key = { id };
                })
                    .then(Lookup.fetch_office())
                    .then(Lookup.fetch_job());
            });
            exports_55("fetch", fetch = (params) => {
                let id = +params[0];
                App.prepareRender(NS, i18n("staff"));
                layout_2_3.prepareMenu();
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_55("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || Object.keys(state).length == 0)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let year = Perm.getCurrentYear(); //or something better
                let lookup_office = Lookup.get_office(year);
                let lookup_job = Lookup.get_job(year);
                let officeid = Theme.renderOptions(lookup_office, state.officeid, true);
                let jobid = Theme.renderOptions(lookup_job, state.jobid, true);
                const form = formTemplate(state, officeid, jobid);
                const tab = layout_2_3.tabTemplate(state.id, xtra, isNew);
                const dirty = dirtyTemplate();
                const warning = App.warningTemplate();
                return pageTemplate(state, form, tab, warning, dirty);
            });
            exports_55("postRender", postRender = () => {
                if (!inContext())
                    return;
                App.setPageTitle(isNew ? i18n("New staff") : xtra.title);
            });
            exports_55("inContext", inContext = () => {
                return App.inContext(NS);
            });
            getFormState = () => {
                let clone = Misc.clone(state);
                clone.firstname = Misc.fromInputText(`${NS}_firstname`, state.firstname);
                clone.lastname = Misc.fromInputText(`${NS}_lastname`, state.lastname);
                clone.officeid = Misc.fromSelectNumber(`${NS}_officeid`, state.officeid);
                clone.jobid = Misc.fromSelectNumber(`${NS}_jobid`, state.jobid);
                clone.archive = Misc.fromInputCheckbox(`${NS}_archive`, state.archive);
                return clone;
            };
            valid = (formState) => {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = () => {
                document.getElementById(`${NS}_dummy_submit`).click();
                let form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_55("onchange", onchange = (input) => {
                state = getFormState();
                App.render();
            });
            exports_55("cancel", cancel = () => {
                Router.goBackOrResume(isDirty);
            });
            exports_55("create", create = () => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST("/staff", Misc.createBlack(formState, blackList))
                    .then(payload => {
                    let newkey = payload;
                    Misc.toastSuccessSave();
                    Router.goto(`#/staff_2/${newkey.id}`, 10);
                })
                    .catch(App.render);
            });
            exports_55("save", save = (done = false) => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.PUT("/staff", Misc.createBlack(formState, blackList))
                    .then(_ => {
                    Misc.toastSuccessSave();
                    if (done)
                        Router.goto(`#/staffs_2/`, 100);
                    else
                        Router.goto(`#/staff_2/${key.id}`, 10);
                })
                    .catch(App.render);
            });
            exports_55("drop", drop = () => {
                key.updated = state.updated;
                App.prepareRender();
                App.DELETE("/staff", key)
                    .then(_ => {
                    Router.goto(`#/staffs_2/`, 250);
                })
                    .catch(App.render);
            });
            dirtyExit = () => {
                isDirty = !Misc.same(fetchedState, getFormState());
                if (isDirty) {
                    setTimeout(() => {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
System.register("src/christian/main", ["_BaseApp/src/core/router", "src/christian/offices", "src/christian/office", "src/christian/staffs", "src/christian/staff", "src/christian/staffs_2", "src/christian/staff_2"], function (exports_56, context_56) {
    "use strict";
    var Router, offices, office, staffs, staff, staffs_2, staff_2, startup, render, postRender;
    var __moduleName = context_56 && context_56.id;
    return {
        setters: [
            function (Router_21) {
                Router = Router_21;
            },
            function (offices_1) {
                offices = offices_1;
            },
            function (office_1) {
                office = office_1;
            },
            function (staffs_1) {
                staffs = staffs_1;
            },
            function (staff_1) {
                staff = staff_1;
            },
            function (staffs_2_1) {
                staffs_2 = staffs_2_1;
            },
            function (staff_2_1) {
                staff_2 = staff_2_1;
            }
        ],
        execute: function () {
            //
            // Global references to application objects. Used for event handlers.
            //
            window[offices.NS] = offices;
            window[office.NS] = office;
            window[staffs.NS] = staffs;
            window[staff.NS] = staff;
            window[staffs_2.NS] = staffs_2;
            window[staff_2.NS] = staff_2;
            //
            // ***** For a brand new main.ts, don't forget to update the root main.ts and add call to startup() *****
            //
            exports_56("startup", startup = () => {
                Router.addRoute("^#/offices/?(.*)?$", offices.fetch);
                Router.addRoute("^#/office/?(.*)?$", office.fetch);
                Router.addRoute("^#/staffs_2/?(.*)?$", staffs_2.fetch);
                Router.addRoute("^#/staff_2/?(.*)?$", staff_2.fetch);
                Router.addRoute("^#/staffs/?(.*)?$", staffs.fetch);
                Router.addRoute("^#/staff/?(.*)?$", staff.fetch);
            });
            //
            // ***** For a brand new main.ts, don't forget to update the root layout.ts and add calls to render() and postRender() *****
            //
            exports_56("render", render = () => {
                return `
<div>
    ${offices.render()}
    ${office.render()}
    ${staffs.render()}
    ${staff.render()}
    ${staffs_2.render()}
    ${staff_2.render()}
</div>
`;
            });
            exports_56("postRender", postRender = () => {
                offices.postRender();
                office.postRender();
                staffs.postRender();
                staff.postRender();
                staffs_2.postRender();
                staff_2.postRender();
            });
        }
    };
});
System.register("src/fournisseur/layout", ["_BaseApp/src/core/app", "src/layout"], function (exports_57, context_57) {
    "use strict";
    var App, layout_17, icon, prepareMenu, tabTemplate, buildTitle, buildSubtitle;
    var __moduleName = context_57 && context_57.id;
    return {
        setters: [
            function (App_27) {
                App = App_27;
            },
            function (layout_17_1) {
                layout_17 = layout_17_1;
            }
        ],
        execute: function () {
            exports_57("icon", icon = "far fa-user");
            exports_57("prepareMenu", prepareMenu = () => {
                layout_17.setOpenedMenu("Fournisseur-Propriétaires");
            });
            exports_57("tabTemplate", tabTemplate = (id, xtra, isNew = false) => {
                let isProprietaires = App.inContext("App_proprietaires");
                let isProprietaire = App.inContext("App_proprietaire");
                let isFiles = window.location.hash.startsWith("#/files/proprietaire");
                let isFile = window.location.hash.startsWith("#/file/proprietaire");
                let showDetail = !isProprietaires;
                let showFiles = showDetail && xtra;
                let showFile = isFile;
                return `
<div class="tabs is-boxed">
    <ul>
        <li ${isProprietaires ? "class='is-active'" : ""}>
            <a href="#/proprietaires">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("List")}</span>
            </a>
        </li>
${showDetail ? `
        <li ${isProprietaire ? "class='is-active'" : ""}>
            <a href="#/proprietaire/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("Proprietaire Details")}</span>
            </a>
        </li>
` : ``}
${showFiles ? `
        <li ${isFiles ? "class='is-active'" : ""}>
            <a href="#/files/proprietaire/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("Files")} (${xtra.filecount})</span>
            </a>
        </li>
` : ``}
${showFile ? `
        <li ${isFile ? "class='is-active'" : ""}>
            <a href="#/file/proprietaire/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("File Details")}</span>
            </a>
        </li>
` : ``}

    </ul>
</div>
`;
            });
            exports_57("buildTitle", buildTitle = (xtra, defaultText) => {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.title) !== null && _a !== void 0 ? _a : defaultText;
            });
            exports_57("buildSubtitle", buildSubtitle = (xtra, defaultText) => {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.subtitle) !== null && _a !== void 0 ? _a : defaultText;
            });
        }
    };
});
// File: proprietaires.ts
System.register("src/fournisseur/proprietaires", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/lookupdata", "src/fournisseur/layout"], function (exports_58, context_58) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, Lookup, layout_18, NS, key, state, xtra, uiSelectedRow, filterTemplate, trTemplate, tableTemplate, pageTemplate, fetchState, fetch, refresh, render, postRender, inContext, setSelectedRow, isSelectedRow, goto, sortBy, search, filter_nom, gotoDetail;
    var __moduleName = context_58 && context_58.id;
    return {
        setters: [
            function (App_28) {
                App = App_28;
            },
            function (Router_22) {
                Router = Router_22;
            },
            function (Perm_16) {
                Perm = Perm_16;
            },
            function (Misc_27) {
                Misc = Misc_27;
            },
            function (Theme_15) {
                Theme = Theme_15;
            },
            function (Pager_8) {
                Pager = Pager_8;
            },
            function (Lookup_11) {
                Lookup = Lookup_11;
            },
            function (layout_18_1) {
                layout_18 = layout_18_1;
            }
        ],
        execute: function () {
            exports_58("NS", NS = "App_proprietaires");
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 20, sortColumn: "ID", sortDirection: "ASC", filter: { nom: undefined } }
            };
            filterTemplate = () => {
                let filters = [];
                // TODO (filters textbox)
                return filters.join("");
            };
            trTemplate = (item, rowNumber) => {
                return `
<tr class="${isSelectedRow(item.id) ? "is-selected" : ""}" onclick="${NS}.gotoDetail('${item.id}');">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.id)}</td>
    <td>${Misc.toStaticText(item.cletri)}</td>
    <td>${Misc.toStaticText(item.nom)}</td>
    <td>${Misc.toStaticText(item.ausoinsde)}</td>
    <td>${Misc.toStaticText(item.rue)}</td>
    <td>${Misc.toStaticText(item.ville)}</td>
    <td>${Misc.toStaticText(item.paysid_text)}</td>
    <td>${Misc.toStaticText(item.code_postal)}</td>
    <td>${Misc.toStaticText(item.telephone)}</td>
    <td>${Misc.toStaticText(item.telephone_poste)}</td>
    <td>${Misc.toStaticText(item.telecopieur)}</td>
    <td>${Misc.toStaticText(item.telephone2)}</td>
    <td>${Misc.toStaticText(item.telephone2_desc)}</td>
    <td>${Misc.toStaticText(item.telephone2_poste)}</td>
    <td>${Misc.toStaticText(item.telephone3)}</td>
    <td>${Misc.toStaticText(item.telephone3_desc)}</td>
    <td>${Misc.toStaticText(item.telephone3_poste)}</td>
    <td>${Misc.toStaticText(item.no_membre)}</td>
    <td>${Misc.toStaticText(item.resident)}</td>
    <td>${Misc.toStaticText(item.email)}</td>
    <td>${Misc.toStaticText(item.www)}</td>
    <td>${Misc.toStaticText(item.commentaires)}</td>
    <td>${Misc.toStaticCheckbox(item.affichercommentaires)}</td>
    <td>${Misc.toStaticCheckbox(item.depotdirect)}</td>
    <td>${Misc.toStaticText(item.institutionbanquaireid_text)}</td>
    <td>${Misc.toStaticText(item.banque_transit)}</td>
    <td>${Misc.toStaticText(item.banque_folio)}</td>
    <td>${Misc.toStaticText(item.no_tps)}</td>
    <td>${Misc.toStaticText(item.no_tvq)}</td>
    <td>${Misc.toStaticCheckbox(item.payera)}</td>
    <td>${Misc.toStaticText(item.payeraid)}</td>
    <td>${Misc.toStaticText(item.statut)}</td>
    <td>${Misc.toStaticText(item.rep_nom)}</td>
    <td>${Misc.toStaticText(item.rep_telephone)}</td>
    <td>${Misc.toStaticText(item.rep_telephone_poste)}</td>
    <td>${Misc.toStaticText(item.rep_email)}</td>
    <td>${Misc.toStaticCheckbox(item.enanglais)}</td>
    <td>${Misc.toStaticCheckbox(item.actif)}</td>
    <td>${Misc.toStaticText(item.mrcproducteurid)}</td>
    <td>${Misc.toStaticCheckbox(item.paiementmanuel)}</td>
    <td>${Misc.toStaticCheckbox(item.journal)}</td>
    <td>${Misc.toStaticCheckbox(item.recoittps)}</td>
    <td>${Misc.toStaticCheckbox(item.recoittvq)}</td>
    <td>${Misc.toStaticCheckbox(item.modifiertrigger)}</td>
    <td>${Misc.toStaticCheckbox(item.isproducteur)}</td>
    <td>${Misc.toStaticCheckbox(item.istransporteur)}</td>
    <td>${Misc.toStaticCheckbox(item.ischargeur)}</td>
    <td>${Misc.toStaticCheckbox(item.isautre)}</td>
    <td>${Misc.toStaticCheckbox(item.affichercommentairessurpermit)}</td>
    <td>${Misc.toStaticCheckbox(item.pasemissionpermis)}</td>
    <td>${Misc.toStaticCheckbox(item.generique)}</td>
    <td>${Misc.toStaticCheckbox(item.membre_ogc)}</td>
    <td>${Misc.toStaticCheckbox(item.inscrittps)}</td>
    <td>${Misc.toStaticCheckbox(item.inscrittvq)}</td>
    <td>${Misc.toStaticCheckbox(item.isogc)}</td>
    <td>${Misc.toStaticText(item.rep2_nom)}</td>
    <td>${Misc.toStaticText(item.rep2_telephone)}</td>
    <td>${Misc.toStaticText(item.rep2_telephone_poste)}</td>
    <td>${Misc.toStaticText(item.rep2_email)}</td>
    <td>${Misc.toStaticText(item.rep2_commentaires)}</td>
</tr>`;
            };
            tableTemplate = (tbody, pager) => {
                return `
<div class="table-container">
<table class="table is-hoverable is-fullwidth">
    <thead>
        <tr>
            <th></th>
            ${Pager.sortableHeaderLink(pager, NS, i18n("ID"), "id", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CLETRI"), "cletri", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NOM"), "nom", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AUSOINSDE"), "ausoinsde", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RUE"), "rue", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("VILLE"), "ville", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PAYSID_TEXT"), "paysid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CODE_POSTAL"), "code_postal", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE"), "telephone", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE_POSTE"), "telephone_poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELECOPIEUR"), "telecopieur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE2"), "telephone2", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE2_DESC"), "telephone2_desc", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE2_POSTE"), "telephone2_poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE3"), "telephone3", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE3_DESC"), "telephone3_desc", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE3_POSTE"), "telephone3_poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NO_MEMBRE"), "no_membre", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RESIDENT"), "resident", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("EMAIL"), "email", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("WWW"), "www", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COMMENTAIRES"), "commentaires", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERCOMMENTAIRES"), "affichercommentaires", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DEPOTDIRECT"), "depotdirect", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("INSTITUTIONBANQUAIREID_TEXT"), "institutionbanquaireid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("BANQUE_TRANSIT"), "banque_transit", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("BANQUE_FOLIO"), "banque_folio", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NO_TPS"), "no_tps", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NO_TVQ"), "no_tvq", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PAYERA"), "payera", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PAYERAID"), "payeraid", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("STATUT"), "statut", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP_NOM"), "rep_nom", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP_TELEPHONE"), "rep_telephone", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP_TELEPHONE_POSTE"), "rep_telephone_poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP_EMAIL"), "rep_email", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ENANGLAIS"), "enanglais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ACTIF"), "actif", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MRCPRODUCTEURID"), "mrcproducteurid", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PAIEMENTMANUEL"), "paiementmanuel", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("JOURNAL"), "journal", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RECOITTPS"), "recoittps", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RECOITTVQ"), "recoittvq", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MODIFIERTRIGGER"), "modifiertrigger", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISPRODUCTEUR"), "isproducteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISTRANSPORTEUR"), "istransporteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISCHARGEUR"), "ischargeur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISAUTRE"), "isautre", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERCOMMENTAIRESSURPERMIT"), "affichercommentairessurpermit", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PASEMISSIONPERMIS"), "pasemissionpermis", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("GENERIQUE"), "generique", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MEMBRE_OGC"), "membre_ogc", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("INSCRITTPS"), "inscrittps", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("INSCRITTVQ"), "inscrittvq", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ISOGC"), "isogc", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_NOM"), "rep2_nom", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_TELEPHONE"), "rep2_telephone", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_TELEPHONE_POSTE"), "rep2_telephone_poste", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_EMAIL"), "rep2_email", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REP2_COMMENTAIRES"), "rep2_commentaires", "ASC")}
            ${Pager.headerLink(i18n("TODO"))}
        </tr>
    </thead>
    <tbody>
        ${tbody}
    </tbody>
</table>
</div>
`;
            };
            pageTemplate = (pager, table, tab, warning, dirty) => {
                let readonly = false;
                let buttons = [];
                buttons.push(Theme.buttonAddNew(NS, "#/proprietaire/new", i18n("Add New")));
                let actions = Theme.renderButtons(buttons);
                let title = layout_18.buildTitle(xtra, i18n("fournisseurs title"));
                let subtitle = layout_18.buildSubtitle(xtra, i18n("fournisseurs subtitle"));
                return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_18.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-pager", pager)}
    ${Theme.wrapContent("js-uc-list", table)}
</div>
</div>

</form>
`;
            };
            exports_58("fetchState", fetchState = (id) => {
                Router.registerDirtyExit(null);
                return App.POST("/fournisseur/search", state.pager)
                    .then(payload => {
                    state = payload;
                    xtra = payload.xtra;
                    key = {};
                })
                    .then(Lookup.fetch_pays())
                    .then(Lookup.fetch_institutionBanquaire());
            });
            exports_58("fetch", fetch = (params) => {
                let id = params[0];
                App.prepareRender(NS, i18n("fournisseurs"));
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            refresh = () => {
                App.prepareRender(NS, i18n("fournisseurs"));
                App.POST("/fournisseur/search", state.pager)
                    .then(payload => {
                    state = payload;
                })
                    .then(App.render)
                    .catch(App.render);
            };
            exports_58("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let warning = App.warningTemplate();
                let dirty = "";
                const tbody = state.list.reduce((html, item, index) => {
                    let rowNumber = Pager.rowNumber(state.pager, index);
                    return html + trTemplate(item, rowNumber);
                }, "");
                let year = Perm.getCurrentYear(); //state.pager.filter.year;
                const filter = filterTemplate();
                const search = Pager.searchTemplate(state.pager, NS);
                const pager = Pager.render(state.pager, NS, [20, 50], search, filter);
                const table = tableTemplate(tbody, state.pager);
                const tab = layout_18.tabTemplate(null, null);
                return pageTemplate(pager, table, tab, dirty, warning);
            });
            exports_58("postRender", postRender = () => {
                if (!inContext())
                    return;
            });
            exports_58("inContext", inContext = () => {
                return App.inContext(NS);
            });
            setSelectedRow = (id) => {
                if (uiSelectedRow == undefined)
                    uiSelectedRow = { id };
                uiSelectedRow.id = id;
            };
            isSelectedRow = (id) => {
                if (uiSelectedRow == undefined)
                    return false;
                return (uiSelectedRow.id == id);
            };
            exports_58("goto", goto = (pageNo, pageSize) => {
                state.pager.pageNo = pageNo;
                state.pager.pageSize = pageSize;
                refresh();
            });
            exports_58("sortBy", sortBy = (columnName, direction) => {
                state.pager.pageNo = 1;
                state.pager.sortColumn = columnName;
                state.pager.sortDirection = direction;
                refresh();
            });
            exports_58("search", search = (element) => {
                state.pager.searchText = element.value;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_58("filter_nom", filter_nom = (element) => {
                // TODO (filterDef)
            });
            exports_58("gotoDetail", gotoDetail = (id) => {
                setSelectedRow(id);
                Router.goto(`#/proprietaire/${id}`);
            });
        }
    };
});
// File: lots2.ts
System.register("src/fournisseur/lots2", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/lookupdata"], function (exports_59, context_59) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, Lookup, NS, table_id, blackList, key, state, fetchedState, isNew, callerNS, isAddingNewParent, trTemplate, tableTemplate, pageTemplate, fetchState, preRender, render, postRender, inContext, getFormState, html5Valid, onchange, undo, addNew, create, save, selectfordrop, drop, hasChanges;
    var __moduleName = context_59 && context_59.id;
    return {
        setters: [
            function (App_29) {
                App = App_29;
            },
            function (Router_23) {
                Router = Router_23;
            },
            function (Perm_17) {
                Perm = Perm_17;
            },
            function (Misc_28) {
                Misc = Misc_28;
            },
            function (Theme_16) {
                Theme = Theme_16;
            },
            function (Pager_9) {
                Pager = Pager_9;
            },
            function (Lookup_12) {
                Lookup = Lookup_12;
            }
        ],
        execute: function () {
            exports_59("NS", NS = "App_lots2");
            table_id = "lots2_table";
            blackList = ["_editing", "_deleting", "_isNew", "totalcount", "cantonid_text", "municipaliteid_text", "proprietaireid_text", "contingentid_text", "droit_coupeid_text", "entente_paiementid_text", "zoneid_text"];
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 1000, sortColumn: "ID", sortDirection: "ASC", filter: {} }
            };
            fetchedState = {};
            isNew = false;
            isAddingNewParent = false;
            trTemplate = (item, editId, deleteId, rowNumber, cantonid, municipaliteid, contingentid, droit_coupeid, entente_paiementid, zoneid) => {
                let id = item.id;
                let tdConfirm = `<td class="js-td-33">&nbsp;</td>`;
                if (item._editing)
                    tdConfirm = `<td onclick="${NS}.save()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
                if (item._deleting)
                    tdConfirm = `<td onclick="${NS}.drop()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
                if (item._isNew)
                    tdConfirm = `<td onclick="${NS}.create()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
                let clickUndo = item._editing || item._deleting || item._isNew;
                let markDeletion = !clickUndo;
                let readonly = (deleteId != undefined) || (editId != undefined && id != editId) || (isNew && !item._isNew);
                let classList = [];
                if (item._editing || item._isNew)
                    classList.push("js-not-same");
                if (item._deleting)
                    classList.push("js-strikeout");
                if (item._isNew)
                    classList.push("js-new");
                if (readonly)
                    classList.push("js-readonly");
                return `
<tr data-id="${id}" class="${classList.join(" ")}" style="cursor: pointer;">
    <td class="js-index">${rowNumber}</td>

${markDeletion ? `<td onclick="${NS}.selectfordrop(${id})" class="has-text-danger js-td-33 js-drop" title="Click to mark for deletion"><i class='fas fa-times'></i></td>` : ``}
${clickUndo ? `<td onclick="${NS}.undo()" class="has-text-primary js-td-33" title="Click to undo"><i class='fa fa-undo'></i></td>` : ``}
${tdConfirm}

${!readonly ? `
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `cantonid_${id}`, cantonid)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `rang_${id}`, item.rang, 25)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `lot_${id}`, item.lot, 6)}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `municipaliteid_${id}`, municipaliteid)}</td>
    <td class="js-inline-input">${Theme.renderDecimalInline(NS, `superficie_total_${id}`, item.superficie_total, { required: true, places: 1, min: 0 })}</td>
    <td class="js-inline-input">${Theme.renderDecimalInline(NS, `superficie_boisee_${id}`, item.superficie_boisee, { required: true, places: 1, min: 0 })}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `contingentid_${id}`, contingentid)}</td>
    <td class="js-inline-input">${Theme.renderDateInline(NS, `contingent_date_${id}`, item.contingent_date, { required: false })}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `droit_coupeid_${id}`, droit_coupeid)}</td>
    <td class="js-inline-input">${Theme.renderDateInline(NS, `droit_coupe_date_${id}`, item.droit_coupe_date, { required: false })}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `entente_paiementid_${id}`, entente_paiementid)}</td>
    <td class="js-inline-input">${Theme.renderDateInline(NS, `entente_paiement_date_${id}`, item.entente_paiement_date, { required: false })}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `actif_${id}`, item.actif)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `sequence_${id}`, item.sequence, 6)}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `partie_${id}`, item.partie)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `matricule_${id}`, item.matricule, 20)}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `zoneid_${id}`, zoneid)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `secteur_${id}`, item.secteur, 2)}</td>
    <td class="js-inline-input">${Theme.renderNumberInline(NS, `cadastre_${id}`, item.cadastre)}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `reforme_${id}`, item.reforme)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `lotscomplementaires_${id}`, item.lotscomplementaires, 255)}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `certifie_${id}`, item.certifie)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `numerocertification_${id}`, item.numerocertification, 50)}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `ogc_${id}`, item.ogc)}</td>
` : `
    <td>${Misc.toStaticText(item.cantonid_text)}</td>
    <td>${Misc.toStaticText(item.rang)}</td>
    <td>${Misc.toStaticText(item.lot)}</td>
    <td>${Misc.toStaticText(item.municipaliteid_text)}</td>
    <td>${Misc.toStaticText(item.superficie_total)}</td>
    <td>${Misc.toStaticText(item.superficie_boisee)}</td>
    <td>${Misc.toStaticText(item.contingentid_text)}</td>
    <td>${Misc.toInputDate(item.contingent_date)}</td>
    <td>${Misc.toStaticText(item.droit_coupeid_text)}</td>
    <td>${Misc.toInputDate(item.droit_coupe_date)}</td>
    <td>${Misc.toStaticText(item.entente_paiementid_text)}</td>
    <td>${Misc.toInputDate(item.entente_paiement_date)}</td>
    <td>${Misc.toStaticCheckbox(item.actif)}</td>
    <td>${Misc.toStaticText(item.sequence)}</td>
    <td>${Misc.toStaticCheckbox(item.partie)}</td>
    <td>${Misc.toStaticText(item.matricule)}</td>
    <td>${Misc.toStaticText(item.zoneid_text)}</td>
    <td>${Misc.toStaticText(item.secteur)}</td>
    <td>${Misc.toStaticText(item.cadastre)}</td>
    <td>${Misc.toStaticCheckbox(item.reforme)}</td>
    <td>${Misc.toStaticText(item.lotscomplementaires)}</td>
    <td>${Misc.toStaticCheckbox(item.certifie)}</td>
    <td>${Misc.toStaticText(item.numerocertification)}</td>
    <td>${Misc.toStaticCheckbox(item.ogc)}</td>
`}
</tr>`;
            };
            tableTemplate = (tbody, editId, deleteId) => {
                let disableAddNew = (deleteId != undefined || editId != undefined || isNew);
                return `
<div id="${table_id}" class="table-container">
<table class="table is-hoverable js-inline" style="width: 100px; table-layout: fixed;">
    <thead>
        <tr>
            <th style="width:99px" colspan="3"></th>
            <th style="width:100px">${i18n("CANTON")}</th>
            <th style="width:100px">${i18n("RANG")}</th>
            <th style="width:100px">${i18n("LOT")}</th>
            <th style="width:100px">${i18n("MUNICIPALITE")}</th>
            <th style="width:100px">${i18n("SUPERFICIE_TOTAL")}</th>
            <th style="width:100px">${i18n("SUPERFICIE_BOISEE")}</th>
            <th style="width:100px">${i18n("CONTINGENT")}</th>
            <th style="width:100px">${i18n("CONTINGENT_DATE")}</th>
            <th style="width:100px">${i18n("DROIT_COUPE")}</th>
            <th style="width:100px">${i18n("DROIT_COUPE_DATE")}</th>
            <th style="width:100px">${i18n("ENTENTE_PAIEMENT")}</th>
            <th style="width:100px">${i18n("ENTENTE_PAIEMENT_DATE")}</th>
            <th style="width:100px">${i18n("ACTIF")}</th>
            <th style="width:100px">${i18n("SEQUENCE")}</th>
            <th style="width:100px">${i18n("PARTIE")}</th>
            <th style="width:100px">${i18n("MATRICULE")}</th>
            <th style="width:100px">${i18n("ZONE")}</th>
            <th style="width:100px">${i18n("SECTEUR")}</th>
            <th style="width:100px">${i18n("CADASTRE")}</th>
            <th style="width:100px">${i18n("REFORME")}</th>
            <th style="width:100px">${i18n("LOTSCOMPLEMENTAIRES")}</th>
            <th style="width:100px">${i18n("CERTIFIE")}</th>
            <th style="width:100px">${i18n("NUMEROCERTIFICATION")}</th>
            <th style="width:100px">${i18n("OGC")}</th>
        </tr>
    </thead>
    <tbody>
        ${tbody}
        <tr class="js-insert-row ${disableAddNew ? "js-disabled" : ""}">
            <td class="js-index js-td-33">*</td>
            <td class="has-text-primary js-td-33 js-add" onclick="${NS}.addNew()" title="Click to add a new row"><i class="fas fa-plus"></i></td>
            <td></td>
            <td colspan="24"></td>
        </tr>
    </tbody>
</table>
</div>
`;
            };
            pageTemplate = (table) => {
                return `
${Theme.wrapContent("js-uc-list", table)}
`;
            };
            exports_59("fetchState", fetchState = (proprietaireid, ownerNS) => {
                isAddingNewParent = (proprietaireid == "new");
                callerNS = ownerNS || callerNS;
                isNew = false;
                return App.POST(`/lot/search/${proprietaireid}`, state.pager)
                    .then(payload => {
                    state = payload;
                    fetchedState = Misc.clone(state);
                    key = { proprietaireid };
                })
                    .then(Lookup.fetch_canton())
                    .then(Lookup.fetch_municipalite())
                    .then(Lookup.fetch_contingent())
                    .then(Lookup.fetch_droit_coupe())
                    .then(Lookup.fetch_entente_paiement())
                    .then(Lookup.fetch_zone());
            });
            exports_59("preRender", preRender = () => {
            });
            exports_59("render", render = () => {
                if (isAddingNewParent)
                    return "";
                let editId;
                let deleteId;
                state.list.forEach((item, index) => {
                    let prevItem = fetchedState.list[index];
                    item._editing = !Misc.same(item, prevItem);
                    if (item._editing)
                        editId = item.id;
                    if (item._deleting)
                        deleteId = item.id;
                });
                let year = Perm.getCurrentYear(); //or something better
                let lookup_canton = Lookup.get_canton(year);
                let lookup_municipalite = Lookup.get_municipalite(year);
                let lookup_contingent = Lookup.get_contingent(year);
                let lookup_droit_coupe = Lookup.get_droit_coupe(year);
                let lookup_entente_paiement = Lookup.get_entente_paiement(year);
                let lookup_zone = Lookup.get_zone(year);
                const tbody = state.list.reduce((html, item, index) => {
                    let rowNumber = Pager.rowNumber(state.pager, index);
                    let cantonid = Theme.renderOptions(lookup_canton, item.cantonid, true);
                    let municipaliteid = Theme.renderOptions(lookup_municipalite, item.municipaliteid, true);
                    let contingentid = Theme.renderOptions(lookup_contingent, item.contingentid, true);
                    let droit_coupeid = Theme.renderOptions(lookup_droit_coupe, item.droit_coupeid, true);
                    let entente_paiementid = Theme.renderOptions(lookup_entente_paiement, item.entente_paiementid, true);
                    let zoneid = Theme.renderOptions(lookup_zone, item.zoneid, true);
                    return html + trTemplate(item, editId, deleteId, rowNumber, cantonid, municipaliteid, contingentid, droit_coupeid, entente_paiementid, zoneid);
                }, "");
                const table = tableTemplate(tbody, editId, deleteId);
                return pageTemplate(table);
            });
            exports_59("postRender", postRender = () => {
            });
            exports_59("inContext", inContext = () => {
                return App.inContext(NS);
            });
            getFormState = () => {
                let clone = Misc.clone(state);
                clone.list.forEach(item => {
                    let id = item.id;
                    item.cantonid = Misc.fromSelectText(`${NS}_cantonid_${id}`, item.cantonid);
                    item.rang = Misc.fromInputTextNullable(`${NS}_rang_${id}`, item.rang);
                    item.lot = Misc.fromInputTextNullable(`${NS}_lot_${id}`, item.lot);
                    item.municipaliteid = Misc.fromSelectText(`${NS}_municipaliteid_${id}`, item.municipaliteid);
                    item.superficie_total = Misc.fromInputNumberNullable(`${NS}_superficie_total_${id}`, item.superficie_total);
                    item.superficie_boisee = Misc.fromInputNumberNullable(`${NS}_superficie_boisee_${id}`, item.superficie_boisee);
                    item.proprietaireid = Misc.fromSelectText(`${NS}_proprietaireid_${id}`, item.proprietaireid);
                    item.contingentid = Misc.fromSelectText(`${NS}_contingentid_${id}`, item.contingentid);
                    item.contingent_date = Misc.fromInputDateNullable(`${NS}_contingent_date_${id}`, item.contingent_date);
                    item.droit_coupeid = Misc.fromSelectText(`${NS}_droit_coupeid_${id}`, item.droit_coupeid);
                    item.droit_coupe_date = Misc.fromInputDateNullable(`${NS}_droit_coupe_date_${id}`, item.droit_coupe_date);
                    item.entente_paiementid = Misc.fromSelectText(`${NS}_entente_paiementid_${id}`, item.entente_paiementid);
                    item.entente_paiement_date = Misc.fromInputDateNullable(`${NS}_entente_paiement_date_${id}`, item.entente_paiement_date);
                    item.actif = Misc.fromInputCheckbox(`${NS}_actif_${id}`, item.actif);
                    item.sequence = Misc.fromInputTextNullable(`${NS}_sequence_${id}`, item.sequence);
                    item.partie = Misc.fromInputCheckbox(`${NS}_partie_${id}`, item.partie);
                    item.matricule = Misc.fromInputTextNullable(`${NS}_matricule_${id}`, item.matricule);
                    item.zoneid = Misc.fromSelectText(`${NS}_zoneid_${id}`, item.zoneid);
                    item.secteur = Misc.fromInputTextNullable(`${NS}_secteur_${id}`, item.secteur);
                    item.cadastre = Misc.fromInputNumberNullable(`${NS}_cadastre_${id}`, item.cadastre);
                    item.reforme = Misc.fromInputCheckbox(`${NS}_reforme_${id}`, item.reforme);
                    item.lotscomplementaires = Misc.fromInputTextNullable(`${NS}_lotscomplementaires_${id}`, item.lotscomplementaires);
                    item.certifie = Misc.fromInputCheckbox(`${NS}_certifie_${id}`, item.certifie);
                    item.numerocertification = Misc.fromInputTextNullable(`${NS}_numerocertification_${id}`, item.numerocertification);
                    item.ogc = Misc.fromInputCheckbox(`${NS}_ogc_${id}`, item.ogc);
                });
                return clone;
            };
            html5Valid = () => {
                document.getElementById(`${callerNS}_dummy_submit`).click();
                let form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_59("onchange", onchange = (input) => {
                state = getFormState();
                App.render();
            });
            exports_59("undo", undo = () => {
                if (isNew) {
                    isNew = false;
                    fetchedState.list.pop();
                }
                state = Misc.clone(fetchedState);
                App.render();
            });
            exports_59("addNew", addNew = () => {
                let url = `/lot/new/${key.proprietaireid}`;
                return App.GET(url)
                    .then((payload) => {
                    state.list.push(payload);
                    fetchedState = Misc.clone(state);
                    isNew = true;
                    payload._isNew = true;
                })
                    .then(App.render)
                    .catch(App.render);
            });
            exports_59("create", create = () => {
                let formState = getFormState();
                let item = formState.list.find(one => one._isNew);
                if (!html5Valid())
                    return;
                App.prepareRender();
                App.POST("/lot", Misc.createBlack(item, blackList))
                    .then(() => {
                    fetchedState = Misc.clone(state);
                    Router.gotoCurrent(1);
                })
                    .catch(App.render);
            });
            exports_59("save", save = () => {
                let formState = getFormState();
                let item = formState.list.find(one => one._editing);
                if (!html5Valid())
                    return;
                App.prepareRender();
                App.PUT("/lot", Misc.createBlack(item, blackList))
                    .then(() => {
                    fetchedState = Misc.clone(state);
                    Router.gotoCurrent(1);
                })
                    .catch(App.render);
            });
            exports_59("selectfordrop", selectfordrop = (id) => {
                state = Misc.clone(fetchedState);
                state.list.find(one => one.id == id)._deleting = true;
                App.render();
            });
            exports_59("drop", drop = () => {
                App.prepareRender();
                let item = state.list.find(one => one._deleting);
                App.DELETE("/lot", { id: item.id })
                    .then(() => {
                    fetchedState = Misc.clone(state);
                    Router.gotoCurrent(1);
                })
                    .catch(App.render);
            });
            exports_59("hasChanges", hasChanges = () => {
                return !Misc.same(fetchedState, state);
            });
        }
    };
});
// File: proprietaire.ts
System.register("src/fournisseur/proprietaire", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "src/admin/lookupdata", "src/fournisseur/layout", "src/fournisseur/lots2"], function (exports_60, context_60) {
    "use strict";
    var App, Router, Misc, Theme, Lookup, layout_19, app_inline2, NS, blackList, key, state, xtra, fetchedState, isNew, isDirty, block_address, block_telephone, block_ciel, block_internet, block_autres, block_depotdirect, block_representant, block_camions, formTemplate, pageTemplate, dirtyTemplate, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, onchange, cancel, create, save, drop, dirtyExit;
    var __moduleName = context_60 && context_60.id;
    return {
        setters: [
            function (App_30) {
                App = App_30;
            },
            function (Router_24) {
                Router = Router_24;
            },
            function (Misc_29) {
                Misc = Misc_29;
            },
            function (Theme_17) {
                Theme = Theme_17;
            },
            function (Lookup_13) {
                Lookup = Lookup_13;
            },
            function (layout_19_1) {
                layout_19 = layout_19_1;
            },
            function (app_inline2_1) {
                app_inline2 = app_inline2_1;
            }
        ],
        execute: function () {
            exports_60("NS", NS = "App_proprietaire");
            blackList = ["paysid_text", "institutionbanquaireid_text"];
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            block_address = (item, paysid) => {
                return `
    ${Theme.renderTextField(NS, "nom", item.nom, i18n("NOM"), 40)}
    ${Theme.renderTextField(NS, "ausoinsde", item.ausoinsde, i18n("AUSOINSDE"), 30)}
    ${Theme.renderTextField(NS, "rue", item.rue, i18n("RUE"), 30)}
    ${Theme.renderTextField(NS, "ville", item.ville, i18n("VILLE"), 30)}
    ${Theme.renderDropdownField(NS, "paysid", paysid, i18n("PAYSID"))}
    ${Theme.renderTextField(NS, "code_postal", item.code_postal, i18n("CODE_POSTAL"), 7)}
`;
            };
            block_telephone = (item) => {
                return `
    ${Theme.renderTextField(NS, "telephone", item.telephone, i18n("TELEPHONE"), 12)}
    ${Theme.renderTextField(NS, "telephone_poste", item.telephone_poste, i18n("TELEPHONE_POSTE"), 4)}
    ${Theme.renderTextField(NS, "telecopieur", item.telecopieur, i18n("TELECOPIEUR"), 12)}

    ${Theme.renderTextField(NS, "telephone2_desc", item.telephone2_desc, i18n("TELEPHONE2_DESC"), 20)}
    ${Theme.renderTextField(NS, "telephone2", item.telephone2, i18n("TELEPHONE2"), 12)}
    ${Theme.renderTextField(NS, "telephone2_poste", item.telephone2_poste, i18n("TELEPHONE2_POSTE"), 4)}

    ${Theme.renderTextField(NS, "telephone3_desc", item.telephone3_desc, i18n("TELEPHONE3_DESC"), 20)}
    ${Theme.renderTextField(NS, "telephone3", item.telephone3, i18n("TELEPHONE3"), 12)}
    ${Theme.renderTextField(NS, "telephone3_poste", item.telephone3_poste, i18n("TELEPHONE3_POSTE"), 4)}
`;
            };
            block_ciel = (item) => {
                return `
    ${Theme.renderTextField(NS, "statut", item.statut, i18n("STATUT"), 50)}
    ${Theme.renderTextField(NS, "resident", item.resident, i18n("RESIDENT"), 1)}
    ${Theme.renderTextField(NS, "no_membre", item.no_membre, i18n("NO_MEMBRE"), 10)}
`;
            };
            block_internet = (item) => {
                return `
    ${Theme.renderTextField(NS, "email", item.email, i18n("EMAIL"), 80)}
    ${Theme.renderTextField(NS, "www", item.www, i18n("WWW"), 80)}
`;
            };
            block_autres = (item) => {
                return `
    ${Theme.renderTextField(NS, "id", item.id, i18n("ID"), 15, true)}

    ${Theme.renderCheckboxField(NS, "isproducteur", item.isproducteur, i18n("ISPRODUCTEUR"))}
    ${Theme.renderCheckboxField(NS, "istransporteur", item.istransporteur, i18n("ISTRANSPORTEUR"))}
    ${Theme.renderCheckboxField(NS, "ischargeur", item.ischargeur, i18n("ISCHARGEUR"))}
    ${Theme.renderCheckboxField(NS, "isogc", item.isogc, i18n("ISOGC"))}
    ${Theme.renderCheckboxField(NS, "isautre", item.isautre, i18n("ISAUTRE"))}

    ${Theme.renderTextareaField(NS, "commentaires", item.commentaires, i18n("COMMENTAIRES"), 255, false, null, 5)}
    ${Theme.renderCheckboxField(NS, "affichercommentaires", item.affichercommentaires, i18n("AFFICHERCOMMENTAIRES"))}
    ${Theme.renderCheckboxField(NS, "affichercommentairessurpermit", item.affichercommentairessurpermit, i18n("AFFICHERCOMMENTAIRESSURPERMIT"))}

    ${Theme.renderCheckboxField(NS, "actif", item.actif, i18n("ACTIF"))}
    ${Theme.renderCheckboxField(NS, "journal", item.journal, i18n("JOURNAL"))}
    ${Theme.renderCheckboxField(NS, "pasemissionpermis", item.pasemissionpermis, i18n("PASEMISSIONPERMIS"))}

    ${Theme.renderCheckboxField(NS, "enanglais", item.enanglais, i18n("ENANGLAIS"))}
    ${Theme.renderCheckboxField(NS, "generique", item.generique, i18n("GENERIQUE"))}
    ${Theme.renderCheckboxField(NS, "membre_ogc", item.membre_ogc, i18n("MEMBRE_OGC"))}
`;
            };
            block_depotdirect = (item, institutionbanquaireid) => {
                return `
    ${Theme.renderCheckboxField(NS, "depotdirect", item.depotdirect, i18n("DEPOTDIRECT"))}

    ${Theme.renderDropdownField(NS, "institutionbanquaireid", institutionbanquaireid, i18n("INSTITUTIONBANQUAIREID"))}
    ${Theme.renderTextField(NS, "banque_transit", item.banque_transit, i18n("BANQUE_TRANSIT"), 5)}
    ${Theme.renderTextField(NS, "banque_folio", item.banque_folio, i18n("BANQUE_FOLIO"), 12)}

    ${Theme.renderTextField(NS, "no_tps", item.no_tps, i18n("NO_TPS"), 25)}
    ${Theme.renderCheckboxField(NS, "recoittps", item.recoittps, i18n("RECOITTPS"))}
    ${Theme.renderCheckboxField(NS, "inscrittps", item.inscrittps, i18n("INSCRITTPS"))}

    ${Theme.renderTextField(NS, "no_tvq", item.no_tvq, i18n("NO_TVQ"), 25)}
    ${Theme.renderCheckboxField(NS, "recoittvq", item.recoittvq, i18n("RECOITTVQ"))}
    ${Theme.renderCheckboxField(NS, "inscrittvq", item.inscrittvq, i18n("INSCRITTVQ"))}

    ${Theme.renderCheckboxField(NS, "payera", item.payera, i18n("PAYERA"))}
    ${Theme.renderTextField(NS, "payeraid", item.payeraid, i18n("PAYERAID"), 15)}
    ${Theme.renderCheckboxField(NS, "paiementmanuel", item.paiementmanuel, i18n("PAIEMENTMANUEL"))}
`;
            };
            block_representant = (item) => {
                return `
    ${Theme.renderTextField(NS, "rep_nom", item.rep_nom, i18n("REP_NOM"), 30)}
    ${Theme.renderTextField(NS, "rep_telephone", item.rep_telephone, i18n("REP_TELEPHONE"), 12)}
    ${Theme.renderTextField(NS, "rep_telephone_poste", item.rep_telephone_poste, i18n("REP_TELEPHONE_POSTE"), 4)}
    ${Theme.renderTextField(NS, "rep_email", item.rep_email, i18n("REP_EMAIL"), 80)}

    ${Theme.renderTextField(NS, "rep2_nom", item.rep2_nom, i18n("REP2_NOM"), 80)}
    ${Theme.renderTextField(NS, "rep2_telephone", item.rep2_telephone, i18n("REP2_TELEPHONE"), 12)}
    ${Theme.renderTextField(NS, "rep2_telephone_poste", item.rep2_telephone_poste, i18n("REP2_TELEPHONE_POSTE"), 4)}
    ${Theme.renderTextField(NS, "rep2_email", item.rep2_email, i18n("REP2_EMAIL"), 80)}
    ${Theme.renderTextareaField(NS, "rep2_commentaires", item.rep2_commentaires, i18n("REP2_COMMENTAIRES"), 255, false, null, 3)}
`;
            };
            block_camions = (item) => {
                return `
`;
            };
            formTemplate = (item, paysid, institutionbanquaireid, inline2) => {
                return `
<div class="js-float-menu">
    <ul>
        <li>${Theme.float_menu_button("Adresse")}</li>
        <li>${Theme.float_menu_button("Téléphone")}</li>
        <li>${Theme.float_menu_button("Ciel")}</li>
        <li>${Theme.float_menu_button("Internet")}</li>
        <li>${Theme.float_menu_button("Autres")}</li>
        <li>${Theme.float_menu_button("Dépôt direct")}</li>
        <li>${Theme.float_menu_button("Représentant")}</li>
        <li>${Theme.float_menu_button("Camions")}</li>
        <li>${Theme.float_menu_button("Lots")}</li>
    </ul>
</div>

<div class="columns">
    <div class="column is-8 is-offset-3">
        ${Theme.wrapFieldset("Camions", block_camions(item))}
        ${Theme.wrapFieldset("Lots", `<h4>Lots propriétaire</h4>${inline2}`)}
        ${Theme.wrapFieldset("Adresse", block_address(item, paysid))}
        ${Theme.wrapFieldset("Téléphone", block_telephone(item))}
        ${Theme.wrapFieldset("Ciel", block_ciel(item))}
        ${Theme.wrapFieldset("Internet", block_internet(item))}
        ${Theme.wrapFieldset("Autres", block_autres(item))}
        ${Theme.wrapFieldset("Dépôt direct", block_depotdirect(item, institutionbanquaireid))}
        ${Theme.wrapFieldset("Représentant", block_representant(item))}
    </div>
</div>

    ${Theme.renderBlame(item, isNew)}
`;
                //    return `
                //    ${Theme.renderNumberField(NS, "mrcproducteurid", item.mrcproducteurid, i18n("MRCPRODUCTEURID"))}
                //    ${Theme.renderCheckboxField(NS, "modifiertrigger", item.modifiertrigger, i18n("MODIFIERTRIGGER"))}
                //`;
            };
            pageTemplate = (item, form, tab, warning, dirty) => {
                let canEdit = true;
                let readonly = !canEdit;
                let canInsert = canEdit && isNew; // && Perm.hasFournisseur_CanAddFournisseur;
                let canDelete = canEdit && !canInsert; // && Perm.hasFournisseur_CanDeleteFournisseur;
                let canAdd = canEdit && !canInsert; // && Perm.hasFournisseur_CanAddFournisseur;
                let canUpdate = canEdit && !isNew;
                let inline2_dirty = app_inline2.hasChanges();
                let buttons = [];
                buttons.push(Theme.buttonCancel(NS));
                if (canInsert)
                    buttons.push(Theme.buttonInsert(NS));
                if (canDelete)
                    buttons.push(Theme.buttonDelete(NS));
                if (canAdd)
                    buttons.push(Theme.buttonAddNew(NS, "#/proprietaire/new"));
                if (canUpdate)
                    buttons.push(Theme.buttonUpdate(NS, inline2_dirty));
                let actions = Theme.renderButtons(buttons);
                let title = layout_19.buildTitle(xtra, !isNew ? i18n("fournisseur Details") : i18n("New fournisseur"));
                let subtitle = layout_19.buildSubtitle(xtra, i18n("fournisseur subtitle"));
                return `
<form onsubmit="return false;" ${readonly ? "class='js-readonly'" : ""}>
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_19.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
            ${Theme.renderBlame(item, isNew)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-details", form)}
</div>
</div>

${Theme.renderModalDelete(`modalDelete_${NS}`, `${NS}.drop()`)}

</form>
`;
            };
            dirtyTemplate = () => {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            exports_60("fetchState", fetchState = (id) => {
                isNew = (id == "new");
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                return App.GET(`/fournisseur/${isNew ? "new" : id}`)
                    .then((payload) => {
                    state = payload.item;
                    xtra = payload.xtra;
                    fetchedState = Misc.clone(state);
                    key = { id };
                })
                    .then(Lookup.fetch_pays())
                    .then(Lookup.fetch_institutionBanquaire())
                    .then(() => { return app_inline2.fetchState(id, NS); });
            });
            exports_60("fetch", fetch = (params) => {
                let id = params[0];
                App.prepareRender(NS, i18n("proprietaire"));
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_60("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || Object.keys(state).length == 0)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let year = 2020; // Perm.getCurrentYear(); //or something better
                let lookup_pays = Lookup.get_pays(year);
                let lookup_institutionBanquaire = Lookup.get_institutionBanquaire(year);
                let paysid = Theme.renderOptions(lookup_pays, state.paysid, true);
                let institutionbanquaireid = Theme.renderOptions(lookup_institutionBanquaire, state.institutionbanquaireid, true);
                app_inline2.preRender();
                let inline2 = app_inline2.render();
                const form = formTemplate(state, paysid, institutionbanquaireid, inline2);
                const tab = layout_19.tabTemplate(state.id, xtra, isNew);
                const dirty = dirtyTemplate();
                const warning = App.warningTemplate();
                return pageTemplate(state, form, tab, warning, dirty);
            });
            exports_60("postRender", postRender = () => {
                if (!inContext())
                    return;
                app_inline2.postRender();
                App.setPageTitle(isNew ? i18n("New proprietaire") : xtra.title);
            });
            exports_60("inContext", inContext = () => {
                return App.inContext(NS);
            });
            getFormState = () => {
                let clone = Misc.clone(state);
                clone.cletri = Misc.fromInputTextNullable(`${NS}_cletri`, state.cletri);
                clone.nom = Misc.fromInputTextNullable(`${NS}_nom`, state.nom);
                clone.ausoinsde = Misc.fromInputTextNullable(`${NS}_ausoinsde`, state.ausoinsde);
                clone.rue = Misc.fromInputTextNullable(`${NS}_rue`, state.rue);
                clone.ville = Misc.fromInputTextNullable(`${NS}_ville`, state.ville);
                clone.paysid = Misc.fromSelectText(`${NS}_paysid`, state.paysid);
                clone.code_postal = Misc.fromInputTextNullable(`${NS}_code_postal`, state.code_postal);
                clone.telephone = Misc.fromInputTextNullable(`${NS}_telephone`, state.telephone);
                clone.telephone_poste = Misc.fromInputTextNullable(`${NS}_telephone_poste`, state.telephone_poste);
                clone.telecopieur = Misc.fromInputTextNullable(`${NS}_telecopieur`, state.telecopieur);
                clone.telephone2 = Misc.fromInputTextNullable(`${NS}_telephone2`, state.telephone2);
                clone.telephone2_desc = Misc.fromInputTextNullable(`${NS}_telephone2_desc`, state.telephone2_desc);
                clone.telephone2_poste = Misc.fromInputTextNullable(`${NS}_telephone2_poste`, state.telephone2_poste);
                clone.telephone3 = Misc.fromInputTextNullable(`${NS}_telephone3`, state.telephone3);
                clone.telephone3_desc = Misc.fromInputTextNullable(`${NS}_telephone3_desc`, state.telephone3_desc);
                clone.telephone3_poste = Misc.fromInputTextNullable(`${NS}_telephone3_poste`, state.telephone3_poste);
                clone.no_membre = Misc.fromInputTextNullable(`${NS}_no_membre`, state.no_membre);
                clone.resident = Misc.fromInputTextNullable(`${NS}_resident`, state.resident);
                clone.email = Misc.fromInputTextNullable(`${NS}_email`, state.email);
                clone.www = Misc.fromInputTextNullable(`${NS}_www`, state.www);
                clone.commentaires = Misc.fromInputTextNullable(`${NS}_commentaires`, state.commentaires);
                clone.affichercommentaires = Misc.fromInputCheckbox(`${NS}_affichercommentaires`, state.affichercommentaires);
                clone.depotdirect = Misc.fromInputCheckbox(`${NS}_depotdirect`, state.depotdirect);
                clone.institutionbanquaireid = Misc.fromSelectText(`${NS}_institutionbanquaireid`, state.institutionbanquaireid);
                clone.banque_transit = Misc.fromInputTextNullable(`${NS}_banque_transit`, state.banque_transit);
                clone.banque_folio = Misc.fromInputTextNullable(`${NS}_banque_folio`, state.banque_folio);
                clone.no_tps = Misc.fromInputTextNullable(`${NS}_no_tps`, state.no_tps);
                clone.no_tvq = Misc.fromInputTextNullable(`${NS}_no_tvq`, state.no_tvq);
                clone.payera = Misc.fromInputCheckbox(`${NS}_payera`, state.payera);
                clone.payeraid = Misc.fromInputTextNullable(`${NS}_payeraid`, state.payeraid);
                clone.statut = Misc.fromInputTextNullable(`${NS}_statut`, state.statut);
                clone.rep_nom = Misc.fromInputTextNullable(`${NS}_rep_nom`, state.rep_nom);
                clone.rep_telephone = Misc.fromInputTextNullable(`${NS}_rep_telephone`, state.rep_telephone);
                clone.rep_telephone_poste = Misc.fromInputTextNullable(`${NS}_rep_telephone_poste`, state.rep_telephone_poste);
                clone.rep_email = Misc.fromInputTextNullable(`${NS}_rep_email`, state.rep_email);
                clone.enanglais = Misc.fromInputCheckbox(`${NS}_enanglais`, state.enanglais);
                clone.actif = Misc.fromInputCheckbox(`${NS}_actif`, state.actif);
                clone.mrcproducteurid = Misc.fromInputNumberNullable(`${NS}_mrcproducteurid`, state.mrcproducteurid);
                clone.paiementmanuel = Misc.fromInputCheckbox(`${NS}_paiementmanuel`, state.paiementmanuel);
                clone.journal = Misc.fromInputCheckbox(`${NS}_journal`, state.journal);
                clone.recoittps = Misc.fromInputCheckbox(`${NS}_recoittps`, state.recoittps);
                clone.recoittvq = Misc.fromInputCheckbox(`${NS}_recoittvq`, state.recoittvq);
                clone.modifiertrigger = Misc.fromInputCheckbox(`${NS}_modifiertrigger`, state.modifiertrigger);
                clone.isproducteur = Misc.fromInputCheckbox(`${NS}_isproducteur`, state.isproducteur);
                clone.istransporteur = Misc.fromInputCheckbox(`${NS}_istransporteur`, state.istransporteur);
                clone.ischargeur = Misc.fromInputCheckbox(`${NS}_ischargeur`, state.ischargeur);
                clone.isautre = Misc.fromInputCheckbox(`${NS}_isautre`, state.isautre);
                clone.affichercommentairessurpermit = Misc.fromInputCheckbox(`${NS}_affichercommentairessurpermit`, state.affichercommentairessurpermit);
                clone.pasemissionpermis = Misc.fromInputCheckbox(`${NS}_pasemissionpermis`, state.pasemissionpermis);
                clone.generique = Misc.fromInputCheckbox(`${NS}_generique`, state.generique);
                clone.membre_ogc = Misc.fromInputCheckbox(`${NS}_membre_ogc`, state.membre_ogc);
                clone.inscrittps = Misc.fromInputCheckbox(`${NS}_inscrittps`, state.inscrittps);
                clone.inscrittvq = Misc.fromInputCheckbox(`${NS}_inscrittvq`, state.inscrittvq);
                clone.isogc = Misc.fromInputCheckbox(`${NS}_isogc`, state.isogc);
                clone.rep2_nom = Misc.fromInputTextNullable(`${NS}_rep2_nom`, state.rep2_nom);
                clone.rep2_telephone = Misc.fromInputTextNullable(`${NS}_rep2_telephone`, state.rep2_telephone);
                clone.rep2_telephone_poste = Misc.fromInputTextNullable(`${NS}_rep2_telephone_poste`, state.rep2_telephone_poste);
                clone.rep2_email = Misc.fromInputTextNullable(`${NS}_rep2_email`, state.rep2_email);
                clone.rep2_commentaires = Misc.fromInputTextNullable(`${NS}_rep2_commentaires`, state.rep2_commentaires);
                return clone;
            };
            valid = (formState) => {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = () => {
                document.getElementById(`${NS}_dummy_submit`).click();
                let form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_60("onchange", onchange = (input) => {
                state = getFormState();
                App.render();
            });
            exports_60("cancel", cancel = () => {
                Router.goBackOrResume(isDirty);
            });
            exports_60("create", create = () => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST("/fournisseur", Misc.createBlack(formState, blackList))
                    .then(payload => {
                    let newkey = payload;
                    Misc.toastSuccessSave();
                    Router.goto(`#/proprietaire/${newkey.id}`, 10);
                })
                    .catch(App.render);
            });
            exports_60("save", save = (done = false) => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.PUT("/fournisseur", Misc.createBlack(formState, blackList))
                    .then(_ => {
                    Misc.toastSuccessSave();
                    if (done)
                        Router.goto(`#/proprietaires/`, 100);
                    else
                        Router.goto(`#/proprietaire/${key.id}`, 10);
                })
                    .catch(App.render);
            });
            exports_60("drop", drop = () => {
                //(<any>key).updatedUtc = state.updatedUtc;
                App.prepareRender();
                App.DELETE("/fournisseur", key)
                    .then(_ => {
                    Router.goto(`#/proprietaires/`, 250);
                })
                    .catch(App.render);
            });
            dirtyExit = () => {
                let masterHasChange = !Misc.same(fetchedState, getFormState());
                let detailsHasChange = app_inline2.hasChanges();
                isDirty = masterHasChange || detailsHasChange;
                if (isDirty) {
                    setTimeout(() => {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
System.register("src/fournisseur/main", ["_BaseApp/src/core/router", "src/fournisseur/proprietaires", "src/fournisseur/proprietaire", "src/fournisseur/lots2"], function (exports_61, context_61) {
    "use strict";
    var Router, proprietaires, proprietaire, lots2, startup, render, postRender;
    var __moduleName = context_61 && context_61.id;
    return {
        setters: [
            function (Router_25) {
                Router = Router_25;
            },
            function (proprietaires_1) {
                proprietaires = proprietaires_1;
            },
            function (proprietaire_1) {
                proprietaire = proprietaire_1;
            },
            function (lots2_1) {
                lots2 = lots2_1;
            }
        ],
        execute: function () {
            //
            // Global references to application objects. Used for event handlers.
            //
            window[proprietaires.NS] = proprietaires;
            window[proprietaire.NS] = proprietaire;
            window[lots2.NS] = lots2;
            //
            // ***** Don't forget to update the root main.ts and add call to startup() *****
            //
            exports_61("startup", startup = () => {
                Router.addRoute("^#/proprietaires/?(.*)?$", proprietaires.fetch);
                Router.addRoute("^#/proprietaire/?(.*)?$", proprietaire.fetch);
            });
            //
            // ***** Don't forget to update the root layout.ts and add calls to render() and postRender() *****
            //
            exports_61("render", render = () => {
                return `
<div>
    ${proprietaires.render()}
    ${proprietaire.render()}
</div>
`;
            });
            exports_61("postRender", postRender = () => {
                proprietaires.postRender();
                proprietaire.postRender();
            });
        }
    };
});
System.register("src/territoire/layout", ["_BaseApp/src/core/app", "src/layout"], function (exports_62, context_62) {
    "use strict";
    var App, layout_20, icon, prepareMenu, tabTemplate, buildTitle, buildSubtitle;
    var __moduleName = context_62 && context_62.id;
    return {
        setters: [
            function (App_31) {
                App = App_31;
            },
            function (layout_20_1) {
                layout_20 = layout_20_1;
            }
        ],
        execute: function () {
            exports_62("icon", icon = "far fa-user");
            exports_62("prepareMenu", prepareMenu = () => {
                layout_20.setOpenedMenu("Territoire-Lots");
            });
            exports_62("tabTemplate", tabTemplate = (id, xtra, isNew = false) => {
                let isLots = App.inContext("App_lots");
                let isLot = App.inContext("App_lot");
                let isFiles = window.location.hash.startsWith("#/files/lot");
                let isFile = window.location.hash.startsWith("#/file/lot");
                let showDetail = !isLots;
                let showFiles = showDetail && xtra;
                let showFile = isFile;
                return `
<div class="tabs is-boxed">
    <ul>
        <li ${isLots ? "class='is-active'" : ""}>
            <a href="#/lots">
                <span class="icon"><i class="fas fa-list-ol" aria-hidden="true"></i></span>
                <span>${i18n("List")}</span>
            </a>
        </li>
${showDetail ? `
        <li ${isLot ? "class='is-active'" : ""}>
            <a href="#/lot/${id}">
                <span class="icon"><i class="${icon}" aria-hidden="true"></i></span>
                <span>${i18n("Lot Details")}</span>
            </a>
        </li>
` : ``}
${showFiles ? `
        <li ${isFiles ? "class='is-active'" : ""}>
            <a href="#/files/lot/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("Files")} (${xtra.filecount})</span>
            </a>
        </li>
` : ``}
${showFile ? `
        <li ${isFile ? "class='is-active'" : ""}>
            <a href="#/file/lot/${id}">
                <span class="icon"><i class="far fa-paperclip" aria-hidden="true"></i></span>
                <span>${i18n("File Details")}</span>
            </a>
        </li>
` : ``}

    </ul>
</div>
`;
            });
            exports_62("buildTitle", buildTitle = (xtra, defaultText) => {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.title) !== null && _a !== void 0 ? _a : defaultText;
            });
            exports_62("buildSubtitle", buildSubtitle = (xtra, defaultText) => {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.subtitle) !== null && _a !== void 0 ? _a : defaultText;
            });
        }
    };
});
// File: lots.ts
System.register("src/territoire/lots", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/lookupdata", "src/territoire/layout"], function (exports_63, context_63) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, Lookup, layout_21, NS, key, state, xtra, uiSelectedRow, filterTemplate, trTemplate, tableTemplate, pageTemplate, fetchState, fetch, refresh, render, postRender, inContext, setSelectedRow, isSelectedRow, goto, sortBy, search, gotoDetail;
    var __moduleName = context_63 && context_63.id;
    return {
        setters: [
            function (App_32) {
                App = App_32;
            },
            function (Router_26) {
                Router = Router_26;
            },
            function (Perm_18) {
                Perm = Perm_18;
            },
            function (Misc_30) {
                Misc = Misc_30;
            },
            function (Theme_18) {
                Theme = Theme_18;
            },
            function (Pager_10) {
                Pager = Pager_10;
            },
            function (Lookup_14) {
                Lookup = Lookup_14;
            },
            function (layout_21_1) {
                layout_21 = layout_21_1;
            }
        ],
        execute: function () {
            exports_63("NS", NS = "App_lots");
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 20, sortColumn: "ID", sortDirection: "ASC", filter: {} }
            };
            filterTemplate = () => {
                let filters = [];
                return filters.join("");
            };
            trTemplate = (item, rowNumber) => {
                return `
<tr class="${isSelectedRow(item.id) ? "is-selected" : ""}" onclick="${NS}.gotoDetail(${item.id});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.cantonid_text)}</td>
    <td>${Misc.toStaticText(item.rang)}</td>
    <td>${Misc.toStaticText(item.lot)}</td>
    <td>${Misc.toStaticText(item.municipaliteid_text)}</td>
    <td>${Misc.toStaticText(item.superficie_total)}</td>
    <td>${Misc.toStaticText(item.superficie_boisee)}</td>
    <td>${Misc.toStaticText(item.proprietaireid_text)}</td>
    <td>${Misc.toStaticText(item.contingentid_text)}</td>
    <td>${Misc.toStaticDate(item.contingent_date)}</td>
    <td>${Misc.toStaticText(item.droit_coupeid_text)}</td>
    <td>${Misc.toStaticDate(item.droit_coupe_date)}</td>
    <td>${Misc.toStaticText(item.entente_paiementid_text)}</td>
    <td>${Misc.toStaticDate(item.entente_paiement_date)}</td>
    <td>${Misc.toStaticCheckbox(item.actif)}</td>
    <td>${Misc.toStaticText(item.id)}</td>
    <td>${Misc.toStaticText(item.sequence)}</td>
    <td>${Misc.toStaticCheckbox(item.partie)}</td>
    <td>${Misc.toStaticText(item.matricule)}</td>
    <td>${Misc.toStaticText(item.zoneid_text)}</td>
    <td>${Misc.toStaticText(item.secteur)}</td>
    <td>${Misc.toStaticText(item.cadastre)}</td>
    <td>${Misc.toStaticCheckbox(item.reforme)}</td>
    <td>${Misc.toStaticText(item.lotscomplementaires)}</td>
    <td>${Misc.toStaticCheckbox(item.certifie)}</td>
    <td>${Misc.toStaticText(item.numerocertification)}</td>
    <td>${Misc.toStaticCheckbox(item.ogc)}</td>
</tr>`;
            };
            tableTemplate = (tbody, pager) => {
                return `
<div class="table-container">
<table class="table is-hoverable is-fullwidth">
    <thead>
        <tr>
            <th></th>
            ${Pager.sortableHeaderLink(pager, NS, i18n("CANTONID_TEXT"), "cantonid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("RANG"), "rang", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LOT"), "lot", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MUNICIPALITEID_TEXT"), "municipaliteid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SUPERFICIE_TOTAL"), "superficie_total", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SUPERFICIE_BOISEE"), "superficie_boisee", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PROPRIETAIREID_TEXT"), "proprietaireid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CONTINGENTID_TEXT"), "contingentid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CONTINGENT_DATE"), "contingent_date", "DESC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DROIT_COUPEID_TEXT"), "droit_coupeid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DROIT_COUPE_DATE"), "droit_coupe_date", "DESC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ENTENTE_PAIEMENTID_TEXT"), "entente_paiementid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ENTENTE_PAIEMENT_DATE"), "entente_paiement_date", "DESC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ACTIF"), "actif", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ID"), "id", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SEQUENCE"), "sequence", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PARTIE"), "partie", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MATRICULE"), "matricule", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ZONEID_TEXT"), "zoneid_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SECTEUR"), "secteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CADASTRE"), "cadastre", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("REFORME"), "reforme", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LOTSCOMPLEMENTAIRES"), "lotscomplementaires", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CERTIFIE"), "certifie", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NUMEROCERTIFICATION"), "numerocertification", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("OGC"), "ogc", "ASC")}
            ${Pager.headerLink(i18n("TODO"))}
        </tr>
    </thead>
    <tbody>
        ${tbody}
    </tbody>
</table>
</div>
`;
            };
            pageTemplate = (pager, table, tab, warning, dirty) => {
                let readonly = false;
                let buttons = [];
                buttons.push(Theme.buttonAddNew(NS, "#/lot/new", i18n("Add New")));
                let actions = Theme.renderButtons(buttons);
                let title = layout_21.buildTitle(xtra, i18n("lots title"));
                let subtitle = layout_21.buildSubtitle(xtra, i18n("lots subtitle"));
                return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_21.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-pager", pager)}
    ${Theme.wrapContent("js-uc-list", table)}
</div>
</div>

</form>
`;
            };
            exports_63("fetchState", fetchState = (id) => {
                Router.registerDirtyExit(null);
                return App.POST("/lot/search", state.pager)
                    .then(payload => {
                    state = payload;
                    xtra = payload.xtra;
                    key = {};
                })
                    .then(Lookup.fetch_canton())
                    .then(Lookup.fetch_municipalite())
                    //.then(Lookup.fetch_proprietaire())
                    .then(Lookup.fetch_contingent())
                    .then(Lookup.fetch_droit_coupe())
                    .then(Lookup.fetch_entente_paiement());
            });
            exports_63("fetch", fetch = (params) => {
                let id = +params[0];
                App.prepareRender(NS, i18n("lots"));
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            refresh = () => {
                App.prepareRender(NS, i18n("lots"));
                App.POST("/lot/search", state.pager)
                    .then(payload => {
                    state = payload;
                })
                    .then(App.render)
                    .catch(App.render);
            };
            exports_63("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let warning = App.warningTemplate();
                let dirty = "";
                const tbody = state.list.reduce((html, item, index) => {
                    let rowNumber = Pager.rowNumber(state.pager, index);
                    return html + trTemplate(item, rowNumber);
                }, "");
                let year = Perm.getCurrentYear(); //state.pager.filter.year;
                const filter = filterTemplate();
                const search = Pager.searchTemplate(state.pager, NS);
                const pager = Pager.render(state.pager, NS, [20, 50], search, filter);
                const table = tableTemplate(tbody, state.pager);
                const tab = layout_21.tabTemplate(null, null);
                return pageTemplate(pager, table, tab, dirty, warning);
            });
            exports_63("postRender", postRender = () => {
                if (!inContext())
                    return;
            });
            exports_63("inContext", inContext = () => {
                return App.inContext(NS);
            });
            setSelectedRow = (id) => {
                if (uiSelectedRow == undefined)
                    uiSelectedRow = { id };
                uiSelectedRow.id = id;
            };
            isSelectedRow = (id) => {
                if (uiSelectedRow == undefined)
                    return false;
                return (uiSelectedRow.id == id);
            };
            exports_63("goto", goto = (pageNo, pageSize) => {
                state.pager.pageNo = pageNo;
                state.pager.pageSize = pageSize;
                refresh();
            });
            exports_63("sortBy", sortBy = (columnName, direction) => {
                state.pager.pageNo = 1;
                state.pager.sortColumn = columnName;
                state.pager.sortDirection = direction;
                refresh();
            });
            exports_63("search", search = (element) => {
                state.pager.searchText = element.value;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_63("gotoDetail", gotoDetail = (id) => {
                setSelectedRow(id);
                Router.goto(`#/lot/${id}`);
            });
        }
    };
});
// File: lot.ts
System.register("src/territoire/lot", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/calendar", "_BaseApp/src/theme/autocomplete", "src/admin/lookupdata", "src/permission", "src/territoire/layout"], function (exports_64, context_64) {
    "use strict";
    var App, Router, Misc, Theme, calendar_3, autocomplete_1, Lookup, Perm, layout_22, NS, blackList, key, state, fetchedState, xtra, isNew, isDirty, contingent_dateCalendar, droit_coupe_dateCalendar, entente_paiement_dateCalendar, state_proprietaireid, proprietaireidAutocomplete, formTemplate, pageTemplate, dirtyTemplate, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, oncalendar, onautocomplete, onchange, cancel, create, save, drop, dirtyExit;
    var __moduleName = context_64 && context_64.id;
    return {
        setters: [
            function (App_33) {
                App = App_33;
            },
            function (Router_27) {
                Router = Router_27;
            },
            function (Misc_31) {
                Misc = Misc_31;
            },
            function (Theme_19) {
                Theme = Theme_19;
            },
            function (calendar_3_1) {
                calendar_3 = calendar_3_1;
            },
            function (autocomplete_1_1) {
                autocomplete_1 = autocomplete_1_1;
            },
            function (Lookup_15) {
                Lookup = Lookup_15;
            },
            function (Perm_19) {
                Perm = Perm_19;
            },
            function (layout_22_1) {
                layout_22 = layout_22_1;
            }
        ],
        execute: function () {
            exports_64("NS", NS = "App_lot");
            blackList = ["cantonid_text", "municipaliteid_text", "proprietaireid_text", "contingentid_text", "droit_coupeid_text", "entente_paiementid_text", "zoneid_text"];
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            contingent_dateCalendar = new calendar_3.Calendar(`${NS}_contingent_date`);
            droit_coupe_dateCalendar = new calendar_3.Calendar(`${NS}_droit_coupe_date`);
            entente_paiement_dateCalendar = new calendar_3.Calendar(`${NS}_entente_paiement_date`);
            state_proprietaireid = {
                list: [],
                pager: { pageNo: 1, pageSize: 5, sortColumn: "ID", sortDirection: "ASC", filter: {} }
            };
            proprietaireidAutocomplete = new autocomplete_1.Autocomplete(NS, "proprietaireid", true);
            proprietaireidAutocomplete.options = {
                keyTemplate: (one) => { return `${one.id}`; },
                valueTemplate: (one) => { return `${one.id} - ${one.nom}`; },
                detailTemplate: (one) => { return `<b>${one.id} - ${one.nom}</b>`; },
            };
            formTemplate = (item, cantonid, municipaliteid, proprietaireid, contingentid, droit_coupeid, entente_paiementid) => {
                let proprietaireidOption = {
                    addon: (item.proprietaireid ? `<a class="button is-text" href="#/proprietaire/${item.proprietaireid}">Voir</a>` : null),
                    required: true
                };
                return `

${isNew ? `
` : `
    ${Theme.renderStaticField(Misc.toStaticNumber(item.id), i18n("ID"))}
`}
    ${Theme.renderDropdownField(NS, "cantonid", cantonid, i18n("CANTONID"))}
    ${Theme.renderTextField(NS, "rang", item.rang, i18n("RANG"), 25)}
    ${Theme.renderTextField(NS, "lot", item.lot, i18n("LOT"), 6)}
    ${Theme.renderDropdownField(NS, "municipaliteid", municipaliteid, i18n("MUNICIPALITEID"))}
    ${Theme.renderNumberField(NS, "superficie_total", item.superficie_total, i18n("SUPERFICIE_TOTAL"))}
    ${Theme.renderNumberField(NS, "superficie_boisee", item.superficie_boisee, i18n("SUPERFICIE_BOISEE"))}
    ${Theme.renderAutocompleteField(NS, "proprietaireid", proprietaireid, i18n("PROPRIETAIREID"), proprietaireidOption)}
    ${Theme.renderDropdownField(NS, "contingentid", contingentid, i18n("CONTINGENTID"))}
    ${Theme.renderCalendarField(NS, "contingent_date", contingent_dateCalendar, i18n("CONTINGENT_DATE"))}
    ${Theme.renderDropdownField(NS, "droit_coupeid", droit_coupeid, i18n("DROIT_COUPEID"))}
    ${Theme.renderCalendarField(NS, "droit_coupe_date", droit_coupe_dateCalendar, i18n("DROIT_COUPE_DATE"))}
    ${Theme.renderDropdownField(NS, "entente_paiementid", entente_paiementid, i18n("ENTENTE_PAIEMENTID"))}
    ${Theme.renderCalendarField(NS, "entente_paiement_date", entente_paiement_dateCalendar, i18n("ENTENTE_PAIEMENT_DATE"))}
    ${Theme.renderCheckboxField(NS, "actif", item.actif, i18n("ACTIF"))}
    ${Theme.renderTextField(NS, "sequence", item.sequence, i18n("SEQUENCE"), 6)}
    ${Theme.renderCheckboxField(NS, "partie", item.partie, i18n("PARTIE"))}
    ${Theme.renderTextField(NS, "matricule", item.matricule, i18n("MATRICULE"), 20)}
    ${Theme.renderTextField(NS, "secteur", item.secteur, i18n("SECTEUR"), 2)}
    ${Theme.renderNumberField(NS, "cadastre", item.cadastre, i18n("CADASTRE"))}
    ${Theme.renderCheckboxField(NS, "reforme", item.reforme, i18n("REFORME"))}
    ${Theme.renderTextareaField(NS, "lotscomplementaires", item.lotscomplementaires, i18n("LOTSCOMPLEMENTAIRES"), 255)}
    ${Theme.renderCheckboxField(NS, "certifie", item.certifie, i18n("CERTIFIE"))}
    ${Theme.renderTextField(NS, "numerocertification", item.numerocertification, i18n("NUMEROCERTIFICATION"), 50)}
    ${Theme.renderCheckboxField(NS, "ogc", item.ogc, i18n("OGC"))}
    ${Theme.renderBlame(item, isNew)}
`;
            };
            pageTemplate = (item, form, tab, warning, dirty) => {
                let canEdit = true;
                let readonly = !canEdit;
                let canInsert = canEdit && isNew; // && Perm.hasLot_CanAddLot;
                let canDelete = canEdit && !canInsert; // && Perm.hasLot_CanDeleteLot;
                let canAdd = canEdit && !canInsert; // && Perm.hasLot_CanAddLot;
                let canUpdate = canEdit && !isNew;
                let buttons = [];
                buttons.push(Theme.buttonCancel(NS));
                if (canInsert)
                    buttons.push(Theme.buttonInsert(NS));
                if (canDelete)
                    buttons.push(Theme.buttonDelete(NS));
                if (canAdd)
                    buttons.push(Theme.buttonAddNew(NS, "#/lot/new"));
                if (canUpdate)
                    buttons.push(Theme.buttonUpdate(NS));
                let actions = Theme.renderButtons(buttons);
                let title = layout_22.buildTitle(xtra, !isNew ? i18n("lot Details") : i18n("New lot"));
                let subtitle = layout_22.buildSubtitle(xtra, i18n("lot subtitle"));
                return `
<form onsubmit="return false;" ${readonly ? "class='js-readonly'" : ""}>
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${layout_22.icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
            ${Theme.renderBlame(item, isNew)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-details", form)}
</div>
</div>

${Theme.renderModalDelete(`modalDelete_${NS}`, `${NS}.drop()`)}

</form>
`;
            };
            dirtyTemplate = () => {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            exports_64("fetchState", fetchState = (id) => {
                isNew = isNaN(id);
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                return App.GET(`/lot/${isNew ? "new" : id}`)
                    .then((payload) => {
                    state = payload.item;
                    fetchedState = Misc.clone(state);
                    xtra = payload.xtra;
                    key = { id };
                    contingent_dateCalendar.setState(state.contingent_date);
                    droit_coupe_dateCalendar.setState(state.droit_coupe_date);
                    entente_paiement_dateCalendar.setState(state.entente_paiement_date);
                    proprietaireidAutocomplete.setState(state.proprietaireid, state.proprietaireid_text);
                })
                    .then(Lookup.fetch_canton())
                    .then(Lookup.fetch_municipalite())
                    .then(Lookup.fetch_contingent())
                    .then(Lookup.fetch_droit_coupe())
                    .then(Lookup.fetch_entente_paiement());
            });
            exports_64("fetch", fetch = (params) => {
                let id = +params[0];
                App.prepareRender(NS, i18n("lot"));
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_64("render", render = () => {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || Object.keys(state).length == 0)
                    return App.warningTemplate() || App.unexpectedTemplate();
                let year = Perm.getCurrentYear(); //or something better
                let lookup_canton = Lookup.get_canton(year);
                let lookup_municipalite = Lookup.get_municipalite(year);
                let lookup_contingent = Lookup.get_contingent(year);
                let lookup_droit_coupe = Lookup.get_droit_coupe(year);
                let lookup_entente_paiement = Lookup.get_entente_paiement(year);
                let cantonid = Theme.renderOptions(lookup_canton, state.cantonid, true);
                let municipaliteid = Theme.renderOptions(lookup_municipalite, state.municipaliteid, true);
                let contingentid = Theme.renderOptions(lookup_contingent, state.contingentid, true);
                let droit_coupeid = Theme.renderOptions(lookup_droit_coupe, state.droit_coupeid, true);
                let entente_paiementid = Theme.renderOptions(lookup_entente_paiement, state.entente_paiementid, true);
                proprietaireidAutocomplete.pagedList = state_proprietaireid;
                const form = formTemplate(state, cantonid, municipaliteid, proprietaireidAutocomplete, contingentid, droit_coupeid, entente_paiementid);
                const tab = layout_22.tabTemplate(state.id, xtra, isNew);
                const dirty = dirtyTemplate();
                const warning = App.warningTemplate();
                return pageTemplate(state, form, tab, warning, dirty);
            });
            exports_64("postRender", postRender = () => {
                if (!inContext())
                    return;
                contingent_dateCalendar.postRender();
                droit_coupe_dateCalendar.postRender();
                entente_paiement_dateCalendar.postRender();
                App.setPageTitle(isNew ? i18n("New lot") : xtra.title);
            });
            exports_64("inContext", inContext = () => {
                return App.inContext(NS);
            });
            getFormState = () => {
                let clone = Misc.clone(state);
                clone.cantonid = Misc.fromSelectText(`${NS}_cantonid`, state.cantonid);
                clone.rang = Misc.fromInputTextNullable(`${NS}_rang`, state.rang);
                clone.lot = Misc.fromInputTextNullable(`${NS}_lot`, state.lot);
                clone.municipaliteid = Misc.fromSelectText(`${NS}_municipaliteid`, state.municipaliteid);
                clone.superficie_total = Misc.fromInputNumberNullable(`${NS}_superficie_total`, state.superficie_total);
                clone.superficie_boisee = Misc.fromInputNumberNullable(`${NS}_superficie_boisee`, state.superficie_boisee);
                clone.proprietaireid = Misc.fromAutocompleteText(`${NS}_proprietaireid`, state.proprietaireid);
                clone.contingentid = Misc.fromSelectText(`${NS}_contingentid`, state.contingentid);
                clone.contingent_date = Misc.fromInputDateNullable(`${NS}_contingent_date`, state.contingent_date);
                clone.droit_coupeid = Misc.fromSelectText(`${NS}_droit_coupeid`, state.droit_coupeid);
                clone.droit_coupe_date = Misc.fromInputDateNullable(`${NS}_droit_coupe_date`, state.droit_coupe_date);
                clone.entente_paiementid = Misc.fromSelectText(`${NS}_entente_paiementid`, state.entente_paiementid);
                clone.entente_paiement_date = Misc.fromInputDateNullable(`${NS}_entente_paiement_date`, state.entente_paiement_date);
                clone.actif = Misc.fromInputCheckbox(`${NS}_actif`, state.actif);
                clone.sequence = Misc.fromInputTextNullable(`${NS}_sequence`, state.sequence);
                clone.partie = Misc.fromInputCheckbox(`${NS}_partie`, state.partie);
                clone.matricule = Misc.fromInputTextNullable(`${NS}_matricule`, state.matricule);
                clone.secteur = Misc.fromInputTextNullable(`${NS}_secteur`, state.secteur);
                clone.cadastre = Misc.fromInputNumberNullable(`${NS}_cadastre`, state.cadastre);
                clone.reforme = Misc.fromInputCheckbox(`${NS}_reforme`, state.reforme);
                clone.lotscomplementaires = Misc.fromInputTextNullable(`${NS}_lotscomplementaires`, state.lotscomplementaires);
                clone.certifie = Misc.fromInputCheckbox(`${NS}_certifie`, state.certifie);
                clone.numerocertification = Misc.fromInputTextNullable(`${NS}_numerocertification`, state.numerocertification);
                clone.ogc = Misc.fromInputCheckbox(`${NS}_ogc`, state.ogc);
                return clone;
            };
            valid = (formState) => {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = () => {
                document.getElementById(`${NS}_dummy_submit`).click();
                let form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_64("oncalendar", oncalendar = (id) => {
                if (contingent_dateCalendar.id == id)
                    contingent_dateCalendar.toggle();
                if (droit_coupe_dateCalendar.id == id)
                    droit_coupe_dateCalendar.toggle();
                if (entente_paiement_dateCalendar.id == id)
                    entente_paiement_dateCalendar.toggle();
            });
            exports_64("onautocomplete", onautocomplete = (id) => {
                if (proprietaireidAutocomplete.id == id) {
                    state_proprietaireid.pager.searchText = proprietaireidAutocomplete.textValue;
                    App.POST("/fournisseur/search", state_proprietaireid.pager)
                        .then(payload => {
                        state_proprietaireid = payload;
                    })
                        .then(App.render);
                }
            });
            exports_64("onchange", onchange = (input) => {
                state = getFormState();
                App.render();
            });
            exports_64("cancel", cancel = () => {
                Router.goBackOrResume(isDirty);
            });
            exports_64("create", create = () => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST("/lot", Misc.createBlack(formState, blackList))
                    .then(payload => {
                    let newkey = payload;
                    Misc.toastSuccessSave();
                    Router.goto(`#/lot/${newkey.id}`, 10);
                })
                    .catch(App.render);
            });
            exports_64("save", save = (done = false) => {
                let formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.PUT("/lot", Misc.createBlack(formState, blackList))
                    .then(_ => {
                    Misc.toastSuccessSave();
                    if (done)
                        Router.goto(`#/lots/`, 100);
                    else
                        Router.goto(`#/lot/${key.id}`, 10);
                })
                    .catch(App.render);
            });
            exports_64("drop", drop = () => {
                //(<any>key).updated = state.updated;
                App.prepareRender();
                App.DELETE("/lot", key)
                    .then(_ => {
                    Router.goto(`#/lots/`, 250);
                })
                    .catch(App.render);
            });
            dirtyExit = () => {
                isDirty = !Misc.same(fetchedState, getFormState());
                if (isDirty) {
                    setTimeout(() => {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
System.register("src/territoire/main", ["_BaseApp/src/core/router", "src/territoire/lots", "src/territoire/lot"], function (exports_65, context_65) {
    "use strict";
    var Router, lots, lot, startup, render, postRender;
    var __moduleName = context_65 && context_65.id;
    return {
        setters: [
            function (Router_28) {
                Router = Router_28;
            },
            function (lots_1) {
                lots = lots_1;
            },
            function (lot_1) {
                lot = lot_1;
            }
        ],
        execute: function () {
            //
            // Global references to application objects
            // These must match the "NS" values defined in modules
            // Mainly used for event handlers
            //
            window[lots.NS] = lots;
            window[lot.NS] = lot;
            exports_65("startup", startup = () => {
                Router.addRoute("^#/lots/?(.*)?$", lots.fetch);
                Router.addRoute("^#/lot/?(.*)?$", lot.fetch);
            });
            exports_65("render", render = () => {
                return `
<div>
    ${lots.render()}
    ${lot.render()}
</div>
`;
            });
            exports_65("postRender", postRender = () => {
                lots.postRender();
                lot.postRender();
            });
        }
    };
});
System.register("src/layout", ["_BaseApp/src/core/app", "src/permission", "src/main", "src/home", "src/admin/main", "src/support/main", "src/christian/main", "src/fournisseur/main", "src/territoire/main"], function (exports_66, context_66) {
    "use strict";
    var App, Perm, Main, Home, Admin, Support, Christian, Fournisseur, Territoire, NS, render, postRender, renderHeader, menuTemplate, renderAsideMenu, isActive, menuClick, toggle, setOpenedMenu, editProfile, toggleProfileMenu;
    var __moduleName = context_66 && context_66.id;
    return {
        setters: [
            function (App_34) {
                App = App_34;
            },
            function (Perm_20) {
                Perm = Perm_20;
            },
            function (Main_1) {
                Main = Main_1;
            },
            function (Home_2) {
                Home = Home_2;
            },
            function (Admin_1) {
                Admin = Admin_1;
            },
            function (Support_1) {
                Support = Support_1;
            },
            function (Christian_1) {
                Christian = Christian_1;
            },
            function (Fournisseur_1) {
                Fournisseur = Fournisseur_1;
            },
            function (Territoire_1) {
                Territoire = Territoire_1;
            }
        ],
        execute: function () {
            exports_66("NS", NS = "App_Layout");
            exports_66("render", render = () => {
                Main.saveUIState();
                // Note: Render js-uc-main content first, before renderHeader() and renderAsideMenu(), 
                // so they can potentially have an impact over there.
                let ucMain = `
${Home.render()}
${Admin.render()}
${Support.render()}
${Christian.render()}
${Fournisseur.render()}
${Territoire.render()}
`;
                let menu = menuTemplate(Home.getMenuData());
                return `
<div class="js-layout ${Main.state.menuOpened ? "" : "js-close"}">
${renderHeader()}
${renderAsideMenu(menu)}
<section class="js-uc-main js-waitable">
${ucMain}
</section>
</div>
`;
            });
            exports_66("postRender", postRender = () => {
                Home.postRender();
                Admin.postRender();
                Support.postRender();
                Christian.postRender();
                Fournisseur.postRender();
                Territoire.postRender();
            });
            renderHeader = () => {
                return `
<header class="js-uc-header">

    <div class="js-logo">
        <div class="js-bars">
            <button class="button is-primary" onclick="${NS}.menuClick()">
                <div class="icon"><i class="fas fa-bars"></i></div>
            </button>
        </div>
        <a href="#" onclick="${NS}.toggle('opsfms')">
            <span>Gestion/Paye</span>
        </a>
        <div style="width:20px;margin-right:1rem;">&nbsp;</div>
    </div>

    <div class="js-navbar">
        <div class="js-navbar-items">
            <div class="js-items">
                <div>
                    <span class="has-text-grey-light">Année courante:</span> <span class="has-text-white">2020</span>
                </div>
            </div>
            <div class="js-items">
                <button class="button is-primary" onclick="${NS}.help()" style="font-size:125%">
                    <span class="icon"><i class="fas fa-question-circle"></i></span>
                </button>
                <div class="navbar-item has-dropdown" onclick="${NS}.toggleProfileMenu(this)">
                    <a class="navbar-link">
                        ${Perm.getEmail()}
                    </a>
                    <div class="navbar-dropdown">
                        <div class="navbar-item">
                            <div><b>${Perm.getName()}</b></div>
                        </div>
                        <div class="navbar-item">
                            <button class="button is-fullwidth is-primary" onclick="${NS}.toggleProfileMenu();${NS}.editProfile()">
                                <i class="far fa-user"></i>&nbsp;&nbsp;Edit Profile
                            </button>
                        </div>
                        <hr class="navbar-divider">
                        <div class="navbar-item">
                            <button class="button is-fullwidth is-outlined" onclick="${NS}.toggleProfileMenu();App_Auth.signout();">
                                <span class="icon"><i class="fas fa-sign-out-alt"></i></span>&nbsp;${i18n("Sign out")}
                            </button>
                        </div>
                        <hr class="navbar-divider">
                        <a href="#" class="navbar-item">
                            <div>Terms of Service</div>
                        </a>
                    </div>
                </div>
                <button class="button is-primary" onclick="App_Auth.signout();">
                    <span class="icon"><i class="fas fa-sign-out-alt"></i></span>&nbsp;${i18n("Sign out")}
                </button>
            </div>
        </div>
    </div>

</header>`;
            };
            menuTemplate = (menuItems) => {
                const linkTemplate = (link) => {
                    if (link.hidden || link.noSidebar)
                        return "";
                    let isDisabled = (link.href == undefined && link.onclick == undefined) && !link.markup;
                    let href = (link.href ? link.href : "#");
                    let isExternal = href.startsWith("http") || link.isExternal;
                    let classes = [];
                    let isActive = (link.ns && App.inContext(link.ns));
                    if (isDisabled)
                        classes.push("js-disabled");
                    if (isActive)
                        classes.push("is-active");
                    let liClasses = (link.classes ? `class="${link.classes}"` : "");
                    if (link.markup)
                        return `<li ${liClasses}>${link.markup}</li>`;
                    else
                        return `<li ${liClasses}><a href="${href}" ${classes.length ? `class="${classes.join(" ")}"` : ``} ${isExternal ? `target="_new"` : ``} ${link.onclick ? `onclick="${link.onclick}"` : ""}>${link.name}</a></li>`;
                };
                const sectionTemplate = (section, name) => {
                    if (section.hidden)
                        return "";
                    let key = `${name}-${section.name}`;
                    let opened = (Main.state.subMenu == key);
                    return `
        <li>
            <a onclick="${NS}.toggle('${key}')" class="${opened ? "js-opened" : ""}">${section.name}</a>
${opened ? `
            <ul>${section.links.filter(one => one.canView == undefined || one.canView).reduce((html, item) => { return html + linkTemplate(item); }, "")}</ul>
` : ``}
        </li>
`;
                };
                const menuItemTemplate = (menuItem) => {
                    return `
    <p class="menu-label">
        <i class="${menuItem.icon} fa-2x"></i> ${menuItem.name}
    </p>
    <ul class="menu-list">
        ${menuItem.sections.filter(one => one.canView == undefined || one.canView).reduce((html, item) => { return html + sectionTemplate(item, menuItem.name); }, "")}
    </ul>
`;
                };
                return menuItems.filter(one => one.canView).reduce((html, item) => { return html + menuItemTemplate(item); }, "");
            };
            renderAsideMenu = (menu) => {
                return `
<aside class="menu has-background-black-ter js-uc-aside">
    <div class="js-wrapper">
        <ul class="menu-list">
            <li><a href="#" class="${isActive(Home.NS)}" onclick="${NS}.toggle('home')"><i class="far fa-home"></i> ${i18n("HOME")}</a></li>
        </ul>
        ${menu}
    </div>
</aside>
`;
            };
            isActive = (ns) => {
                return App.inContext(ns) ? "is-active" : "";
            };
            exports_66("menuClick", menuClick = () => {
                Main.state.menuOpened = !Main.state.menuOpened;
                Main.saveUIState();
                App.render();
            });
            exports_66("toggle", toggle = (entry) => {
                Main.state.subMenu = (Main.state.subMenu == entry ? "" : entry);
                App.render();
            });
            exports_66("setOpenedMenu", setOpenedMenu = (entry) => {
                Main.state.subMenu = entry;
            });
            exports_66("editProfile", editProfile = () => {
                //Profile.fetch([Perm.getUID().toString()]);
                return false;
            });
            exports_66("toggleProfileMenu", toggleProfileMenu = (element) => {
                if (element)
                    element.classList.toggle("is-active");
            });
        }
    };
});
System.register("src/main", ["_BaseApp/src/core/app", "_BaseApp/src/main", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/latlong", "src/fr-CA", "src/permission", "src/layout", "src/home", "src/admin/main", "src/support/main", "src/christian/main", "src/fournisseur/main", "src/territoire/main"], function (exports_67, context_67) {
    "use strict";
    var App, BaseMain, Theme, LatLong, fr_CA_1, Perm, Layout, Home, AdminMain, SupportMain, ChristianMain, FournisseurMain, TerritoireMain, state, html_lang, startup, loadUIState, saveUIState;
    var __moduleName = context_67 && context_67.id;
    return {
        setters: [
            function (App_35) {
                App = App_35;
            },
            function (BaseMain_1) {
                BaseMain = BaseMain_1;
            },
            function (Theme_20) {
                Theme = Theme_20;
            },
            function (LatLong_1) {
                LatLong = LatLong_1;
            },
            function (fr_CA_1_1) {
                fr_CA_1 = fr_CA_1_1;
            },
            function (Perm_21) {
                Perm = Perm_21;
            },
            function (Layout_2) {
                Layout = Layout_2;
            },
            function (Home_3) {
                Home = Home_3;
            },
            function (AdminMain_1) {
                AdminMain = AdminMain_1;
            },
            function (SupportMain_1) {
                SupportMain = SupportMain_1;
            },
            function (ChristianMain_1) {
                ChristianMain = ChristianMain_1;
            },
            function (FournisseurMain_1) {
                FournisseurMain = FournisseurMain_1;
            },
            function (TerritoireMain_1) {
                TerritoireMain = TerritoireMain_1;
            }
        ],
        execute: function () {
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
            if (window.parent != window)
                window.parent.stopLoader();
            // Language files
            html_lang = document.documentElement.lang;
            i18n.translator.add(fr_CA_1.fr_CA);
            exports_67("startup", startup = (hasPublicHomePage = false) => {
                let main = BaseMain.startup(hasPublicHomePage, Layout, Theme);
                let router = main.router;
                // Routing table
                router.addRoute("^#/?$", Home.fetch);
                router.registerHashChanged((hash) => {
                    if (hash.startsWith("#/signin")) {
                        Home.clearMenuData();
                    }
                });
                AdminMain.startup();
                SupportMain.startup();
                ChristianMain.startup();
                FournisseurMain.startup();
                TerritoireMain.startup();
                loadUIState();
            });
            exports_67("loadUIState", loadUIState = () => {
                let uid = Perm.getUID();
                let key = (uid != undefined ? `home-state:${uid}` : "home-state");
                exports_67("state", state = JSON.parse(localStorage.getItem(key)));
                if (state == undefined) {
                    exports_67("state", state = {
                        menuOpened: true,
                        subMenu: ""
                    });
                }
            });
            exports_67("saveUIState", saveUIState = () => {
                let uid = Perm.getUID();
                let key = (uid != undefined ? `home-state:${uid}` : "home-state");
                localStorage.setItem(key, JSON.stringify(state));
            });
        }
    };
});
System.register("src/app", ["src/main"], function (exports_68, context_68) {
    "use strict";
    var main;
    var __moduleName = context_68 && context_68.id;
    return {
        setters: [
            function (main_1) {
                main = main_1;
            }
        ],
        execute: function () {
            //
            // Startup code
            //
            main.startup();
        }
    };
});
// File: commitcbeff.ts
System.register("src/territoire/lots2", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/lookupdata"], function (exports_69, context_69) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, Lookup, NS, table_id, blackList, key, state, fetchedState, isNew, callerNS, isAddingNewParent, trTemplate, tableTemplate, pageTemplate, fetchState, preRender, render, postRender, inContext, getFormState, html5Valid, onchange, undo, addNew, create, save, selectfordrop, drop, hasChanges;
    var __moduleName = context_69 && context_69.id;
    return {
        setters: [
            function (App_36) {
                App = App_36;
            },
            function (Router_29) {
                Router = Router_29;
            },
            function (Perm_22) {
                Perm = Perm_22;
            },
            function (Misc_32) {
                Misc = Misc_32;
            },
            function (Theme_21) {
                Theme = Theme_21;
            },
            function (Pager_11) {
                Pager = Pager_11;
            },
            function (Lookup_16) {
                Lookup = Lookup_16;
            }
        ],
        execute: function () {
            exports_69("NS", NS = "App_commitcbeff");
            table_id = "commitcbeff_table";
            blackList = ["_editing", "_deleting", "_isNew", "totalcount", "regionluid_text"];
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 1000, sortColumn: "ID", sortDirection: "ASC", filter: { year: undefined, regionluid: undefined } }
            };
            fetchedState = {};
            isNew = false;
            isAddingNewParent = false;
            trTemplate = (item, editId, deleteId, rowNumber, regionluid) => {
                let id = item.id;
                let tdConfirm = `<td class="js-td-33">&nbsp;</td>`;
                if (item._editing)
                    tdConfirm = `<td onclick="${NS}.save()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
                if (item._deleting)
                    tdConfirm = `<td onclick="${NS}.drop()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
                if (item._isNew)
                    tdConfirm = `<td onclick="${NS}.create()" class="js-td-33" title="Click to confirm"><i class="fa fa-check"></i></td>`;
                let clickUndo = item._editing || item._deleting || item._isNew;
                let markDeletion = !clickUndo;
                let readonly = (deleteId != undefined) || (editId != undefined && id != editId) || (isNew && !item._isNew);
                let classList = [];
                if (item._editing || item._isNew)
                    classList.push("js-not-same");
                if (item._deleting)
                    classList.push("js-strikeout");
                if (item._isNew)
                    classList.push("js-new");
                if (readonly)
                    classList.push("js-readonly");
                return `
<tr data-id="${id}" class="${classList.join(" ")}" style="cursor: pointer;">
    <td class="js-index">${rowNumber}</td>

${markDeletion ? `<td onclick="${NS}.selectfordrop(${id})" class="has-text-danger js-td-33 js-drop" title="Click to mark for deletion"><i class='fas fa-times'></i></td>` : ``}
${clickUndo ? `<td onclick="${NS}.undo()" class="has-text-primary js-td-33" title="Click to undo"><i class='fa fa-undo'></i></td>` : ``}
${tdConfirm}

${!readonly ? `
    <td class="js-inline-input">${Theme.renderNumberInline(NS, `year_${id}`, item.year, true)}</td>
    <td class="js-inline-select">${Theme.renderDropdownInline(NS, `regionluid_${id}`, regionluid, true)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `details_${id}`, item.details, 50)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `monthpaid_${id}`, item.monthpaid, 25)}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `paid_${id}`, item.paid)}</td>
    <td class="js-inline-input">${Theme.renderNumberInline(NS, `amount_${id}`, item.amount, true)}</td>
    <td class="js-inline-input">${Theme.renderTextInline(NS, `comment_${id}`, item.comment, 50)}</td>
    <td class="js-inline-input">${Theme.renderCheckboxInline(NS, `archive_${id}`, item.archive)}</td>
` : `
    <td>${Misc.toStaticText(item.year)}</td>
    <td>${Misc.toStaticText(item.regionluid_text)}</td>
    <td>${Misc.toStaticText(item.details)}</td>
    <td>${Misc.toStaticText(item.monthpaid)}</td>
    <td>${Misc.toStaticCheckbox(item.paid)}</td>
    <td>${Misc.toStaticText(item.amount)}</td>
    <td>${Misc.toStaticText(item.comment)}</td>
    <td>${Misc.toStaticCheckbox(item.archive)}</td>
`}
</tr>`;
            };
            tableTemplate = (tbody, editId, deleteId) => {
                let disableAddNew = (deleteId != undefined || editId != undefined || isNew);
                return `
<div id="${table_id}" class="table-container">
<table class="table is-hoverable js-inline" style="width: 100px; table-layout: fixed;">
    <thead>
        <tr>
            <th style="width:99px" colspan="3"></th>
            <th style="width:100px">${i18n("YEAR")}</th>
            <th style="width:100px">${i18n("REGION")}</th>
            <th style="width:100px">${i18n("DETAILS")}</th>
            <th style="width:100px">${i18n("MONTHPAID")}</th>
            <th style="width:100px">${i18n("PAID")}</th>
            <th style="width:100px">${i18n("AMOUNT")}</th>
            <th style="width:100px">${i18n("COMMENT")}</th>
            <th style="width:100px">${i18n("ARCHIVE")}</th>
        </tr>
    </thead>
    <tbody>
        ${tbody}
        <tr class="js-insert-row ${disableAddNew ? "js-disabled" : ""}">
            <td class="js-index js-td-33">*</td>
            <td class="has-text-primary js-td-33 js-add" onclick="${NS}.addNew()" title="Click to add a new row"><i class="fas fa-plus"></i></td>
            <td></td>
            <td colspan="8"></td>
        </tr>
    </tbody>
</table>
</div>
`;
            };
            pageTemplate = (table) => {
                return `
${Theme.wrapContent("js-uc-list", table)}
`;
            };
            exports_69("fetchState", fetchState = (id, ownerNS) => {
                isAddingNewParent = isNaN(id);
                callerNS = ownerNS || callerNS;
                isNew = false;
                return App.POST(`/commitcbeff/search`, state.pager)
                    .then(payload => {
                    state = payload;
                    fetchedState = Misc.clone(state);
                    key = {};
                })
                    .then(Lookup.fetch_region());
            });
            exports_69("preRender", preRender = () => {
            });
            exports_69("render", render = () => {
                if (isAddingNewParent)
                    return "";
                let editId;
                let deleteId;
                state.list.forEach((item, index) => {
                    let prevItem = fetchedState.list[index];
                    item._editing = !Misc.same(item, prevItem);
                    if (item._editing)
                        editId = item.id;
                    if (item._deleting)
                        deleteId = item.id;
                });
                let year = Perm.getCurrentYear(); //or something better
                let lookup_region = Lookup.get_region(year);
                const tbody = state.list.reduce((html, item, index) => {
                    let rowNumber = Pager.rowNumber(state.pager, index);
                    let regionluid = Theme.renderOptions(lookup_region, item.regionluid, isNew);
                    return html + trTemplate(item, editId, deleteId, rowNumber, regionluid);
                }, "");
                const table = tableTemplate(tbody, editId, deleteId);
                return pageTemplate(table);
            });
            exports_69("postRender", postRender = () => {
            });
            exports_69("inContext", inContext = () => {
                return App.inContext(NS);
            });
            getFormState = () => {
                let clone = Misc.clone(state);
                clone.list.forEach(item => {
                    let id = item.id;
                    item.year = Misc.fromInputNumber(`${NS}_year_${id}`, item.year);
                    item.regionluid = Misc.fromSelectNumber(`${NS}_regionluid_${id}`, item.regionluid);
                    item.details = Misc.fromInputTextNullable(`${NS}_details_${id}`, item.details);
                    item.monthpaid = Misc.fromInputTextNullable(`${NS}_monthpaid_${id}`, item.monthpaid);
                    item.paid = Misc.fromInputCheckbox(`${NS}_paid_${id}`, item.paid);
                    item.amount = Misc.fromInputNumber(`${NS}_amount_${id}`, item.amount);
                    item.comment = Misc.fromInputTextNullable(`${NS}_comment_${id}`, item.comment);
                    item.archive = Misc.fromInputCheckbox(`${NS}_archive_${id}`, item.archive);
                });
                return clone;
            };
            html5Valid = () => {
                document.getElementById(`${callerNS}_dummy_submit`).click();
                let form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_69("onchange", onchange = (input) => {
                state = getFormState();
                App.render();
            });
            exports_69("undo", undo = () => {
                if (isNew) {
                    isNew = false;
                    fetchedState.list.pop();
                }
                state = Misc.clone(fetchedState);
                App.render();
            });
            exports_69("addNew", addNew = () => {
                let url = `/commitcbeff/new`;
                return App.GET(url)
                    .then((payload) => {
                    state.list.push(payload);
                    fetchedState = Misc.clone(state);
                    isNew = true;
                    payload._isNew = true;
                })
                    .then(App.render)
                    .catch(App.render);
            });
            exports_69("create", create = () => {
                let formState = getFormState();
                let item = formState.list.find(one => one._isNew);
                if (!html5Valid())
                    return;
                App.prepareRender();
                App.POST("/commitcbeff", Misc.createBlack(item, blackList))
                    .then(() => {
                    fetchedState = Misc.clone(state);
                    Router.gotoCurrent(1);
                })
                    .catch(App.render);
            });
            exports_69("save", save = () => {
                let formState = getFormState();
                let item = formState.list.find(one => one._editing);
                if (!html5Valid())
                    return;
                App.prepareRender();
                App.PUT("/commitcbeff", Misc.createBlack(item, blackList))
                    .then(() => {
                    fetchedState = Misc.clone(state);
                    Router.gotoCurrent(1);
                })
                    .catch(App.render);
            });
            exports_69("selectfordrop", selectfordrop = (id) => {
                state = Misc.clone(fetchedState);
                state.list.find(one => one.id == id)._deleting = true;
                App.render();
            });
            exports_69("drop", drop = () => {
                App.prepareRender();
                let item = state.list.find(one => one._deleting);
                App.DELETE("/commitcbeff", { id: item.id, updated: item.updated })
                    .then(() => {
                    fetchedState = Misc.clone(state);
                    Router.gotoCurrent(1);
                })
                    .catch(App.render);
            });
            exports_69("hasChanges", hasChanges = () => {
                return !Misc.same(fetchedState, state);
            });
        }
    };
});
//# sourceMappingURL=app.js.map