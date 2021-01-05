System.register("_BaseApp/src/core/app", ["_BaseApp/src/auth"], function (exports_1, context_1) {
    "use strict";
    var Auth, context, root, api, name, Layout, Theme, Feature, error, sessionExpired, rendering, title, myPublicHomePage, initialize, requireAuthentication, myrender, postRender, render, renderOnNextTick, pauseRender, setRenderDomain, prepareRender, transitionUI, setPageTitle, setContext, inContext, setError, clearErrors, hasError, hasNoError, warningTemplate, serverError, fatalError, fatalErrorTemplate, dirtyTemplate, unexpectedTemplate, setSessionExpired, clearSessionExpired, handleFetch, parseJson, catchFetch, apiurl, url, POST, GET, PUT, DELETE, UPLOAD, DOWNLOAD, download, view, getPageState, setPageState;
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
            exports_1("Feature", Feature = {
                emailEnabled: window.APP.emailEnabled
            });
            error = { hasError: false };
            sessionExpired = false;
            rendering = false;
            title = "";
            //
            myPublicHomePage = false;
            exports_1("initialize", initialize = function (hasPublicHomePage, layout, theme) {
                myPublicHomePage = hasPublicHomePage;
                Layout = layout;
                Theme = theme;
            });
            exports_1("requireAuthentication", requireAuthentication = function () {
                if (myPublicHomePage) {
                    if (window.location.hash.length == 0 || window.location.hash == "/#" || window.location.hash == "/#/")
                        return false;
                }
                return Auth.requireAuthentication();
            });
            myrender = function (pageRender, pagePostRender) {
                if (!rendering) {
                    if (requireAuthentication()) {
                        Auth.redirectToSignin();
                        return;
                    }
                    rendering = true;
                    //
                    var hasServerError = (serverError() ? "js-server-error" : "");
                    var hasFatalError = (fatalError() ? "js-fatal-error" : "");
                    //
                    var html = (context == Auth.NS ? Auth.render() : pageRender());
                    var element = document.getElementById("app-root");
                    (window.morphdom)(element, "<div id=\"app-root\" class=\"js-fadein " + hasServerError + " " + hasFatalError + "\">" + html + "</div>", {
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
            postRender = function () {
                document.title = title;
                document.body.id = context.toLowerCase().replace("_", "-");
                if (!sessionExpired)
                    clearErrors();
            };
            exports_1("render", render = function () {
                myrender(Layout.render, Layout.postRender);
            });
            exports_1("renderOnNextTick", renderOnNextTick = function () {
                setTimeout(render, 0);
            });
            exports_1("pauseRender", pauseRender = function (pause) {
                if (pause === void 0) { pause = true; }
                rendering = pause;
            });
            exports_1("setRenderDomain", setRenderDomain = function (layout) {
                Layout = layout;
            });
            exports_1("prepareRender", prepareRender = function (ns, title) {
                if (ns === void 0) { ns = ""; }
                if (title === void 0) { title = ""; }
                transitionUI();
                if (!sessionExpired)
                    clearErrors();
                if (title.length > 0)
                    setPageTitle(title);
                if (ns.length > 0)
                    setContext(ns);
            });
            exports_1("transitionUI", transitionUI = function () {
                var element = document.getElementById("app-root");
                element.classList.remove("js-fadein");
                element.classList.add("js-waiting");
            });
            exports_1("setPageTitle", setPageTitle = function (newtitle) {
                title = newtitle + " | " + name;
            });
            setContext = function (ns) {
                context = ns;
            };
            exports_1("inContext", inContext = function (ns) {
                if (context == undefined)
                    return false;
                if (typeof ns === "string")
                    return (context == ns);
                else
                    return (ns.indexOf(context) != -1);
            });
            exports_1("setError", setError = function (text) {
                error.hasError = true;
                error.messages.push(text);
                return false;
            });
            exports_1("clearErrors", clearErrors = function () {
                error.hasError = false;
                error.status = 0;
                error.messages = [];
            });
            exports_1("hasError", hasError = function () {
                return (error != undefined && error.hasError);
            });
            exports_1("hasNoError", hasNoError = function () {
                return !hasError();
            });
            exports_1("warningTemplate", warningTemplate = function () {
                if (hasNoError())
                    return "";
                return Theme.warningTemplate(error.messages);
            });
            exports_1("serverError", serverError = function () {
                return (hasError() && error.status == 500);
            });
            exports_1("fatalError", fatalError = function () {
                return (hasError() && (error.status == 403 || error.status == -404));
            });
            exports_1("fatalErrorTemplate", fatalErrorTemplate = function () {
                if (hasError() && error.status == 403)
                    return Theme.fatalErrorTemplate403();
                if (hasError() && error.status == -404)
                    return Theme.fatalErrorTemplate404();
            });
            exports_1("dirtyTemplate", dirtyTemplate = function (ns, details) {
                if (details === void 0) { details = null; }
                return Theme.dirtyTemplate(ns, details);
            });
            exports_1("unexpectedTemplate", unexpectedTemplate = function () {
                return Theme.unexpectedTemplate();
            });
            setSessionExpired = function () {
                sessionExpired = true;
            };
            clearSessionExpired = function () {
                sessionExpired = false;
                clearErrors();
            };
            handleFetch = function (response) {
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
            parseJson = function (response) {
                if (response == null)
                    return null;
                return response
                    .text()
                    .then(function (text) {
                    var datetimeFormat = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}/;
                    var reviver = function (key, value) {
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
            catchFetch = function (reason) {
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
            exports_1("apiurl", apiurl = function (resource) {
                return "" + root + api + resource;
            });
            exports_1("url", url = function (resource) {
                return "" + root + resource;
            });
            exports_1("POST", POST = function (url, body) {
                return window.fetch("" + root + api + url, {
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
            exports_1("GET", GET = function (url) {
                return window.fetch("" + root + api + url, {
                    method: "get",
                    headers: { "Authorization": Auth.getAuthorization(), "Cache-Control": "no-cache", "Pragma": "no-cache" },
                    credentials: "include",
                    mode: "cors",
                })
                    .then(handleFetch)
                    .then(parseJson)
                    .catch(catchFetch);
            });
            exports_1("PUT", PUT = function (url, body) {
                return window.fetch("" + root + api + url, {
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
            exports_1("DELETE", DELETE = function (url, body) {
                return window.fetch("" + root + api + url, {
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
            exports_1("UPLOAD", UPLOAD = function (url, body) {
                return window.fetch("" + root + api + url, {
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
            exports_1("DOWNLOAD", DOWNLOAD = function (url) {
                return window.fetch("" + root + api + url, {
                    method: "get",
                    headers: { "Authorization": Auth.getAuthorization() },
                    credentials: "include",
                    mode: "cors",
                })
                    .then(handleFetch)
                    .then(function (response) { return response.blob(); })
                    .catch(catchFetch);
            });
            exports_1("download", download = function (url, name, event) {
                if (event) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                var anchor = document.createElement("a");
                document.body.appendChild(anchor);
                DOWNLOAD(url)
                    .then(function (blob) {
                    if (window.navigator.msSaveBlob != undefined) {
                        window.navigator.msSaveBlob(blob, name);
                    }
                    else {
                        var objectUrl_1 = window.URL.createObjectURL(blob);
                        anchor.href = objectUrl_1;
                        anchor.rel = "noopener";
                        anchor.download = name;
                        anchor.click();
                        setTimeout(function (_) { window.URL.revokeObjectURL(objectUrl_1); }, 1000);
                    }
                })
                    .catch(render);
                return false;
            });
            exports_1("view", view = function (url, name, event) {
                if (event) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                var anchor = document.createElement("a");
                document.body.appendChild(anchor);
                DOWNLOAD(url)
                    .then(function (blob) {
                    if (window.navigator.msSaveOrOpenBlob != undefined) {
                        window.navigator.msSaveOrOpenBlob(blob, name);
                    }
                    else {
                        var objectUrl_2 = window.URL.createObjectURL(blob);
                        window.open(objectUrl_2, "_blank");
                        setTimeout(function (_) { window.URL.revokeObjectURL(objectUrl_2); }, 1000);
                    }
                })
                    .catch(render);
                return false;
            });
            exports_1("getPageState", getPageState = function (ns, key, defaultValue) {
                var uid = Auth.getUID();
                var id = "pages-state:" + uid;
                var pageState = JSON.parse(localStorage.getItem(id));
                if (pageState == undefined || pageState[ns] == undefined || pageState[ns][key] == undefined)
                    return defaultValue;
                return pageState[ns][key];
            });
            exports_1("setPageState", setPageState = function (ns, key, value) {
                var uid = Auth.getUID();
                var id = "pages-state:" + uid;
                var pageState = JSON.parse(localStorage.getItem(id));
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
            exports_2("reload", reload = function () {
                dirtyExit = null;
                location.reload(true);
            });
            exports_2("registerDirtyExit", registerDirtyExit = function (dirtyExitFunction) {
                dirtyExit = dirtyExitFunction;
            });
            exports_2("registerHashChanged", registerHashChanged = function (hashChangeFunction) {
                onHashChange = hashChangeFunction;
            });
            exports_2("addRoute", addRoute = function (url, callback) {
                router.push({ url: url, callback: callback });
            });
            exports_2("goto", goto = function (url, delay, thenReload) {
                if (delay === void 0) { delay = 0; }
                if (thenReload === void 0) { thenReload = false; }
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
                    setTimeout(function () { goto(url, 0, thenReload); }, delay);
                }
            });
            exports_2("gotoCurrent", gotoCurrent = function (delay) {
                if (delay === void 0) { delay = 0; }
                if (delay == 0)
                    hashChange();
                else
                    setTimeout(function () { gotoCurrent(0); }, delay);
            });
            exports_2("goBackOrResume", goBackOrResume = function (isDirty) {
                if (isDirty)
                    goto(resumeTo);
                else
                    history.back();
            });
            hashChange = function () {
                var hash = window.location.hash;
                if (hash.length == 0)
                    hash = "#/";
                var route = router.filter(function (one) { return hash.match(new RegExp(one.url)); })[0];
                if (route) {
                    if (!reverting) {
                        if (dirtyExit != undefined) {
                            var warning = dirtyExit();
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
                            var parameters = new RegExp(route.url).exec(hash);
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
            exports_3("escapeHTML", escapeHTML = function (text, forAttribute) {
                if (forAttribute === void 0) { forAttribute = true; }
                return text.replace((forAttribute ? /[&<>'"]/g : /[&<>]/g), function (c) { return ESC_MAP[c]; });
            });
            exports_3("keepAttr", keepAttr = function (id, bsAttr) {
                var element = document.getElementById(id);
                if (element == undefined)
                    return "id=\"" + id + "\"";
                return "id=\"" + id + "\" " + bsAttr + "=\"" + element.getAttribute(bsAttr) + "\"";
            });
            exports_3("keepClass", keepClass = function (id, myClass, bsClass) {
                var element = document.getElementById(id);
                if (element == undefined)
                    return "id=\"" + id + "\" class=\"" + myClass + "\"";
                var exist = element.classList.contains(bsClass);
                return "id=\"" + id + "\" class=\"" + myClass + " " + (exist ? bsClass : "") + "\"";
            });
            exports_3("clone", clone = function (state) {
                var cloned = {};
                Object.keys(state).forEach(function (key) {
                    if (state.hasOwnProperty(key)) {
                        if (state[key] == null) {
                            cloned[key] = null;
                        }
                        else if (typeof state[key].getTime === "function") {
                            cloned[key] = new Date(state[key].getTime());
                        }
                        else if (Array.isArray(state[key])) {
                            cloned[key] = [];
                            state[key].forEach(function (one) { return cloned[key].push(clone(one)); });
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
            exports_3("same", same = function (state1, state2) {
                var isSame = true;
                Object.keys(state1).forEach(function (key) {
                    if (isSame && state1.hasOwnProperty(key) && key.charAt(0) != "_") {
                        var value1 = state1[key];
                        var value2 = state2[key];
                        var isPrimitiveType = false;
                        //console.log(`key=${key} value1=${value1}, value2=${value2}`)
                        if (value1 != undefined) {
                            if (typeof value1.getTime === "function") {
                                value1 = value1.getTime();
                                isPrimitiveType = true;
                            }
                            else if (Array.isArray(value1)) {
                                for (var ix = 0; ix < value1.length; ix++) {
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
                                for (var ix = 0; ix < value2.length; ix++) {
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
            exports_3("changes", changes = function (state1, state2) {
                var names = [];
                Object.keys(state1).forEach(function (key) {
                    if (key != "xtra" && key != "perm") {
                        var value1 = state1[key];
                        var value2 = state2[key];
                        if (value1 != null && typeof value1.getTime === "function")
                            value1 = value1.getTime();
                        if (value2 != null && typeof value2.getTime === "function")
                            value2 = value2.getTime();
                        if (value1 !== value2) {
                            var wrong = true;
                            if ((key == "lat" || key == "lng") && Math.abs(value1 - value2) < tolerance)
                                wrong = false;
                            if (wrong) {
                                var translated = i18n(key.toUpperCase());
                                names.push(translated);
                                console.log(key + "[" + translated + "] BEFORE=" + state1[key] + ", AFTER=" + state2[key]);
                            }
                        }
                    }
                });
                if (names.length == 0)
                    return null;
                return "Fields: [" + names.join(", ") + "]";
            });
            exports_3("toInputText", toInputText = function (value) {
                return (value == undefined ? "" : escapeHTML(value.toString()));
            });
            exports_3("fromInputText", fromInputText = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var element = document.getElementById(id);
                return (element == undefined ? defValue : element.value);
            });
            exports_3("fromInputTextNullable", fromInputTextNullable = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var element = document.getElementById(id);
                return (element == undefined ? defValue : element.value == "" ? null : element.value);
            });
            exports_3("toInputNumber", toInputNumber = function (value) {
                return (value == undefined ? "" : value.toString());
            });
            exports_3("fromInputNumber", fromInputNumber = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var element = document.getElementById(id);
                return (element == undefined ? defValue : +element.value);
            });
            exports_3("fromInputNumberNullable", fromInputNumberNullable = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var element = document.getElementById(id);
                return (element == undefined ? defValue : element.value == "" ? null : +element.value);
            });
            exports_3("toInputDate", toInputDate = function (value) {
                if (value == undefined || value.toString().toLowerCase() == "invalid date")
                    return "";
                return moment(value).format("YYYY-MM-DD");
            });
            exports_3("fromInputDate", fromInputDate = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var element = document.getElementById(id);
                if (element == undefined)
                    return defValue;
                var parts = element.value.split("-");
                if (defValue == null)
                    return new Date(+parts[0], +parts[1] - 1, +parts[2], 0, 0, 0, 0);
                try {
                    var date = new Date(defValue.getTime());
                    date.setFullYear(+parts[0], +parts[1] - 1, +parts[2]);
                    return date;
                }
                catch (error) {
                    return null;
                }
            });
            exports_3("fromInputDateNullable", fromInputDateNullable = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var element = document.getElementById(id);
                if (element == undefined)
                    return defValue;
                if (element.value == "")
                    return null;
                var parts = element.value.split("-");
                if (defValue == null)
                    return new Date(+parts[0], +parts[1] - 1, +parts[2], 0, 0, 0, 0);
                try {
                    var date = new Date(defValue.getTime());
                    date.setFullYear(+parts[0], +parts[1] - 1, +parts[2]);
                    return date;
                }
                catch (error) {
                    return null;
                }
            });
            exports_3("fromInputTime", fromInputTime = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var element = document.getElementById(id);
                if (element == undefined)
                    return defValue;
                var parts = element.value.split(":");
                if (defValue == null) {
                    var date = new Date();
                    date.setHours(+parts[0]);
                    date.setMinutes(+parts[1]);
                    return date;
                }
                try {
                    var date = new Date(defValue.getTime());
                    date.setHours(+parts[0]);
                    date.setMinutes(+parts[1]);
                    return date;
                }
                catch (error) {
                    return null;
                }
            });
            exports_3("fromInputTimeComboNullable", fromInputTimeComboNullable = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                if (defValue == null)
                    return null;
                return fromInputTimeNullable(id, defValue);
            });
            exports_3("fromInputTimeNullable", fromInputTimeNullable = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var element = document.getElementById(id);
                if (element == undefined)
                    return defValue;
                if (element.value == "")
                    return defValue;
                var parts = element.value.split(":");
                if (defValue == null) {
                    var date = new Date();
                    date.setHours(+parts[0]);
                    date.setMinutes(+parts[1]);
                    return date;
                }
                try {
                    var date = new Date(defValue.getTime());
                    date.setHours(+parts[0]);
                    date.setMinutes(+parts[1]);
                    return date;
                }
                catch (error) {
                    return null;
                }
            });
            exports_3("toInputCheckbox", toInputCheckbox = function (value) {
                return value.toString();
            });
            exports_3("fromInputCheckbox", fromInputCheckbox = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var element = document.getElementById(id);
                return (element == undefined ? defValue : element.checked);
            });
            exports_3("fromInputCheckboxMask", fromInputCheckboxMask = function (name, defValue) {
                if (defValue === void 0) { defValue = null; }
                var elements = document.getElementsByName(name);
                if (elements == undefined || elements.length == 0)
                    return defValue;
                var value = 0;
                for (var ix = 0; ix < elements.length; ix++) {
                    var element = elements[ix];
                    value += (element.checked ? +element.dataset.mask : 0);
                }
                return value;
            });
            exports_3("toStaticText", toStaticText = function (value) {
                return (value == undefined ? "" : value);
            });
            exports_3("toStaticTextNA", toStaticTextNA = function (value) {
                return (value == undefined ? "n/a" : value.replace(/\n/g, "<br>"));
            });
            exports_3("toStaticNumber", toStaticNumber = function (value) {
                return (value == undefined ? "" : value.toString());
            });
            exports_3("toStaticNumberNA", toStaticNumberNA = function (value) {
                return (value == undefined ? "n/a" : value.toString());
            });
            exports_3("toStaticNumberDecimal", toStaticNumberDecimal = function (value, places, forced) {
                if (forced === void 0) { forced = false; }
                if (value == undefined)
                    return "";
                var scale = Math.pow(10, places);
                if (forced)
                    return (Math.fround(value * scale) / scale).toFixed(places);
                else
                    return (Math.fround(value * scale) / scale).toString();
            });
            exports_3("toStaticMoney", toStaticMoney = function (value) {
                return "$" + (value !== null && value !== void 0 ? value : 0).toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
            });
            exports_3("toStaticDateTime", toStaticDateTime = function (value) {
                return (value != undefined ? moment(value).format("LLL") : "");
            });
            exports_3("toStaticDateTimeNA", toStaticDateTimeNA = function (value) {
                return (value != undefined ? moment(value).format("LLL") : "n/a");
            });
            exports_3("toStaticDate", toStaticDate = function (value) {
                return (value != undefined ? moment(value).format("LL") : "");
            });
            exports_3("toStaticDateNA", toStaticDateNA = function (value) {
                return (value != undefined ? moment(value).format("LL") : "n/a");
            });
            exports_3("toStaticCheckbox", toStaticCheckbox = function (value) {
                return (value ? "<i class='far fa-check-square js-static-checkbox'></i>" : "<i class='far fa-square js-static-checkbox'></i>");
            });
            exports_3("toStaticCheckboxYesNo", toStaticCheckboxYesNo = function (value) {
                return (value == undefined ? "n/a" : value ? i18n("YES") : i18n("NO"));
            });
            exports_3("filesizeText", filesizeText = function (filesize) {
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
            exports_3("fromSelectNumber", fromSelectNumber = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var select = document.getElementById(id);
                if (select == undefined || select.selectedIndex == -1)
                    return defValue;
                var value = select.options[select.selectedIndex].value;
                return (value.length > 0 ? +value : null);
            });
            exports_3("fromSelectText", fromSelectText = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var select = document.getElementById(id);
                if (select == undefined || select.selectedIndex == -1)
                    return defValue;
                var value = select.options[select.selectedIndex].value;
                return (value.length > 0 ? value : null);
            });
            exports_3("fromSelectBoolean", fromSelectBoolean = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var select = document.getElementById(id);
                if (select == undefined || select.selectedIndex == -1)
                    return defValue;
                var value = select.options[select.selectedIndex].value;
                return (value.length > 0 ? (value == "true") : null);
            });
            exports_3("fromRadioNumber", fromRadioNumber = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var radios = document.getElementsByName(id);
                if (radios == undefined || radios.length == 0)
                    return defValue;
                for (var ix = 0; ix < radios.length; ix++) {
                    var radio = radios[ix];
                    if (radio.checked) {
                        var value = radio.dataset.value;
                        return (value.length > 0 ? +value : null);
                    }
                }
            });
            exports_3("fromRadioString", fromRadioString = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var radios = document.getElementsByName(id);
                if (radios == undefined || radios.length == 0)
                    return defValue;
                for (var ix = 0; ix < radios.length; ix++) {
                    var radio = radios[ix];
                    if (radio.checked) {
                        var value = radio.dataset.value;
                        return (value.length > 0 ? value : null);
                    }
                }
            });
            exports_3("fromAutocompleteNumber", fromAutocompleteNumber = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var input = document.getElementById(id);
                if (input == undefined)
                    return defValue;
                var key = input.dataset["key"];
                if (key === "undefined")
                    return defValue;
                if (key.length == 0)
                    return null;
                return +key;
            });
            exports_3("fromAutocompleteText", fromAutocompleteText = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var input = document.getElementById(id);
                if (input == undefined)
                    return defValue;
                var key = input.dataset["key"];
                if (key === "undefined")
                    return defValue;
                if (key.length == 0)
                    return null;
                return key;
            });
            exports_3("toastSuccess", toastSuccess = function (text) {
                var div = document.createElement("div");
                div.classList.add("js-toast");
                div.style.display = "none";
                document.body.appendChild(div);
                var style = getComputedStyle(div);
                var bgcolor = style.backgroundColor;
                div.parentNode.removeChild(div);
                Toastify({
                    text: text,
                    className: "js-toast",
                    backgroundColor: bgcolor,
                    position: "left",
                }).showToast();
            });
            exports_3("toastSuccessSave", toastSuccessSave = function () {
                toastSuccess(i18n("Data was saved successfully"));
            });
            exports_3("toastSuccessUpload", toastSuccessUpload = function () {
                toastSuccess(i18n("File was uploaded successfully"));
            });
            exports_3("toastFailure", toastFailure = function (text, duration) {
                if (text === void 0) { text = "Your last action failed to execute"; }
                if (duration === void 0) { duration = 15000; }
                var div = document.createElement("div");
                div.classList.add("js-toast-bad");
                div.style.display = "none";
                document.body.appendChild(div);
                var style = getComputedStyle(div);
                var bgcolor = style.backgroundColor;
                div.parentNode.removeChild(div);
                Toastify({
                    text: "<i class=\"far fa-frown\" style=\"opacity:0.5\"></i>&nbsp;" + text,
                    className: "js-toast-bad",
                    backgroundColor: bgcolor,
                    position: "center",
                    gravity: "top",
                    duration: duration,
                    close: true
                }).showToast();
            });
            exports_3("blameText", blameText = function (obj) {
                return "Last updated on " + toStaticDateTime(obj.updatedUtc) + " by " + obj.by;
            });
            exports_3("toInputTimeHHMM", toInputTimeHHMM = function (date) {
                if (date == undefined)
                    return "";
                var hours = date.getHours();
                var minutes = date.getMinutes();
                return (hours < 10 ? "0" + hours : hours) + ":" + (minutes < 10 ? "0" + minutes : minutes);
            });
            exports_3("toInputTimeHHMMSS", toInputTimeHHMMSS = function (date) {
                if (date == undefined)
                    return "";
                var hours = date.getHours();
                var minutes = date.getMinutes();
                var secs = date.getSeconds();
                return (hours < 10 ? "0" + hours : hours) + ":" + (minutes < 10 ? "0" + minutes : minutes) + ":" + (secs < 10 ? "0" + secs : secs);
            });
            exports_3("toInputDateTime_2rows", toInputDateTime_2rows = function (date) {
                var hours = date.getHours();
                var minutes = date.getMinutes();
                var secs = date.getSeconds();
                var ampm = (hours < 12 ? "AM" : "PM");
                hours = hours % 12;
                hours = (hours ? hours : 12);
                var time = (hours < 10 ? "0" + hours : hours) + ":" + (minutes < 10 ? "0" + minutes : minutes) + ":" + (secs < 10 ? "0" + secs : secs) + " " + ampm;
                return toInputDate(date) + "<br/>" + time;
            });
            exports_3("toInputDateTime_hhmm_2rows", toInputDateTime_hhmm_2rows = function (date) {
                var hours = date.getHours();
                var minutes = date.getMinutes();
                var ampm = (hours < 12 ? "AM" : "PM");
                hours = hours % 12;
                hours = (hours ? hours : 12);
                var time = (hours < 10 ? "0" + hours : hours) + ":" + (minutes < 10 ? "0" + minutes : minutes) + " " + ampm;
                return toInputDate(date) + "<br/>" + time;
            });
            exports_3("toInputDateTime_hhmm", toInputDateTime_hhmm = function (date) {
                if (date == undefined)
                    return "";
                return toInputDateTime_hhmm_2rows(date).replace("<br/>", "&nbsp;");
            });
            exports_3("toInputDateTime_hhmmssNA", toInputDateTime_hhmmssNA = function (date) {
                if (date == undefined)
                    return "n/a";
                var hours = date.getHours();
                var minutes = date.getMinutes();
                var seconds = date.getSeconds();
                var ampm = (hours < 12 ? "AM" : "PM");
                hours = hours % 12;
                hours = (hours ? hours : 12);
                var time = (hours < 10 ? "0" + hours : hours) + ":" + (minutes < 10 ? "0" + minutes : minutes) + ":" + (seconds < 10 ? "0" + seconds : seconds) + " " + ampm;
                return toInputDate(date) + "&nbsp;" + time;
            });
            exports_3("toInputDateTime_hhmm24", toInputDateTime_hhmm24 = function (date) {
                if (date == undefined)
                    return "";
                var hours = date.getHours();
                var minutes = date.getMinutes();
                var time = (hours < 10 ? "0" + hours : hours) + ":" + (minutes < 10 ? "0" + minutes : minutes);
                return toInputDate(date) + " " + time;
            });
            exports_3("formatYYYYMMDD", formatYYYYMMDD = function (date, separator) {
                if (separator === void 0) { separator = "/"; }
                var month = "" + (date.getMonth() + 1);
                var day = "" + date.getDate();
                var year = date.getFullYear();
                if (month.length < 2)
                    month = "0" + month;
                if (day.length < 2)
                    day = "0" + day;
                return [year, month, day].join(separator);
            });
            exports_3("formatYYYYMMDDHHMM", formatYYYYMMDDHHMM = function (date) {
                var year = date.getFullYear();
                var month = "" + (date.getMonth() + 1);
                var day = "" + date.getDate();
                var hour = "" + date.getHours();
                var minute = "" + date.getMinutes();
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
            exports_3("formatMMDDYYYY", formatMMDDYYYY = function (date, separator) {
                if (separator === void 0) { separator = "/"; }
                var month = "" + (date.getMonth() + 1);
                var day = "" + date.getDate();
                var year = date.getFullYear();
                if (month.length < 2)
                    month = "0" + month;
                if (day.length < 2)
                    day = "0" + day;
                return [month, day, year].join(separator);
            });
            exports_3("parseYYYYMMDD", parseYYYYMMDD = function (text) {
                return new Date(text);
            });
            exports_3("parseYYYYMMDD_number", parseYYYYMMDD_number = function (dateNumber) {
                var yy = Math.floor(dateNumber / 10000);
                var mm = Math.floor((dateNumber - 10000 * yy) / 100) - 1;
                var dd = dateNumber % 100;
                return new Date(yy, mm, dd, 0, 0, 0, 0);
            });
            exports_3("dateOnly", dateOnly = function (date) {
                return new Date(formatYYYYMMDD(date));
            });
            exports_3("previousDate", previousDate = function (date) {
                var newDate = new Date(date);
                newDate.setDate(newDate.getDate() - 1);
                return newDate;
            });
            exports_3("nextDate", nextDate = function (date) {
                var newDate = new Date(date);
                newDate.setDate(newDate.getDate() + 1);
                return newDate;
            });
            exports_3("formatDuration", formatDuration = function (startTime, endTime) {
                var diff = Math.floor((endTime.getTime() - startTime.getTime()) / 1000);
                var sec = diff % 60;
                var min = Math.floor(diff / 60);
                if (min == 0)
                    return sec + " sec";
                min = min % 60;
                var hour = Math.floor(diff / (60 * 60));
                if (hour == 0)
                    return min + "m " + sec + "s";
                return hour + "h " + min + "m " + sec + "s";
            });
            exports_3("isDateInstance", isDateInstance = function (d) {
                return !isNaN(d) && d instanceof Date;
            });
            exports_3("isValidDateString", isValidDateString = function (dateString) {
                if (!dateString.match(/^\d{4}-\d{2}-\d{2}$/))
                    return false;
                var date = new Date(dateString);
                var time = date.getTime();
                if (!time && time != 0)
                    return false;
                return date.toISOString().slice(0, 10) == dateString;
            });
            exports_3("isValidTimeString", isValidTimeString = function (timeString) {
                var regs = timeString.match(/^(\d{1,2}):(\d{2})([ap]m)?$/);
                if (!regs)
                    return false;
                return (!(+regs[1] > 23 || +regs[2] > 59));
            });
            exports_3("formatLatLong", formatLatLong = function (latlon) {
                if (latlon == undefined)
                    return "";
                var deg = Math.trunc(latlon);
                var min = Math.trunc(60 * (latlon - deg));
                var sec = Math.round(60 * 60 * (latlon - (deg + min / 60)));
                if (sec == 60) {
                    sec = 0;
                    min++;
                }
                if (min == 60) {
                    min = 0;
                    deg++;
                }
                return (deg < 10 ? "0" + deg : deg) + "\u00B0&nbsp;" + (min < 10 ? "0" + min : min) + "\u2032&nbsp;" + (sec < 10 ? "0" + sec : sec) + "\u2033";
            });
            exports_3("toInputLatLong", toInputLatLong = function (latlon) {
                if (latlon == undefined)
                    return "";
                var deg = Math.trunc(latlon);
                var min = Math.trunc(60 * (latlon - deg));
                var sec = Math.round(60 * 60 * (latlon - (deg + min / 60)));
                if (sec == 60) {
                    sec = 0;
                    min++;
                }
                if (min == 60) {
                    min = 0;
                    deg++;
                }
                return (deg < 10 ? "0" + deg : deg) + "\u00B0 " + (min < 10 ? "0" + min : min) + "\u2032 " + (sec < 10 ? "0" + sec : sec) + "\u2033";
            });
            exports_3("toInputLatLongDDMMCC", toInputLatLongDDMMCC = function (latlon) {
                if (latlon == undefined)
                    return "";
                var deg = Math.trunc(latlon);
                var min = 60 * (latlon - deg);
                if (min == 60) {
                    min = 0;
                    deg++;
                }
                return (deg < 10 ? "0" + deg : deg) + "\u00B0 " + (min < 10 ? "0" + min.toFixed(2) : min.toFixed(2)) + "\u2032";
            });
            exports_3("fromInputLatLong", fromInputLatLong = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var element = document.getElementById(id);
                if (element == undefined)
                    return defValue;
                if (element.dataset.isddmmcc == "true") {
                    var text = element.value.replace("°", "").replace("′", "");
                    var dmc = text.split(" ");
                    if (dmc.length != 2)
                        return defValue;
                    var deg = +dmc[0];
                    if (isNaN(deg))
                        return defValue;
                    var min = +dmc[1];
                    if (isNaN(min) || min > 59)
                        return defValue;
                    return deg + min / 60;
                }
                else {
                    var text = element.value.replace("°", "").replace("′", "").replace("″", "");
                    var dms = text.split(" ");
                    if (dms.length != 3)
                        return defValue;
                    var deg = +dms[0];
                    if (isNaN(deg))
                        return defValue;
                    var min = +dms[1];
                    if (isNaN(min) || min > 59)
                        return defValue;
                    var sec = +dms[2];
                    if (isNaN(sec) || sec > 59)
                        return defValue;
                    return deg + min / 60 + sec / 3600;
                }
            });
            exports_3("fromInputLatLongNullable", fromInputLatLongNullable = function (id, defValue) {
                if (defValue === void 0) { defValue = null; }
                var element = document.getElementById(id);
                if (element == undefined)
                    return defValue;
                if (element.value == "")
                    return null;
                return fromInputLatLong(id, defValue);
            });
            exports_3("getLatLongFullPrecision", getLatLongFullPrecision = function (latlon) {
                if (latlon == undefined)
                    return latlon;
                // I used to recompute the value from its DDMMSS representation to make sure it wouldn't be considered dirty when exiting a page.
                // It's not necessary anymore because I'm using a tolerance when comparing before and after lat/lng values.
                // This change in methodology became necessary when adding support for DDMMCC.
                return latlon;
            });
            exports_3("createWhite", createWhite = function (formState, props) {
                return props.reduce(function (acc, key) { {
                    acc[key] = formState[key];
                    return acc;
                } ; }, {});
            });
            exports_3("createBlack", createBlack = function (formState, props) {
                var cloned = clone(formState);
                props.forEach(function (prop) { return delete cloned[prop]; });
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
                var el = element;
                var tagname = tagName.toLowerCase();
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
                var el = element;
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
            exports_4("live", live = function (eventType, className, callback) {
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
            exports_4("setCookie", setCookie = function (cname, cvalue, exdays) {
                if (exdays === void 0) { exdays = 0; }
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
                var newElement = document.createElement(targetElement.tagName);
                for (var i = 0; i < targetElement.attributes.length; i++) {
                    var attr = targetElement.attributes[i];
                    newElement.setAttribute(attr.name, attr.value);
                }
                return newElement;
            });
            exports_4("getElementPosition", getElementPosition = function (el) {
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
    var App, Router, Misc, NS, loginData, state, returnUrl, storage, steps, currentStep, formTemplate, formForgottenTemplate, formRemindedTemplate, formNewPasswordTemplate, pageTemplate, fetch, fetchInvitation, fetchReset, render, postRender, getFormState, valid, html5Valid, ensurePasswordMatch, ensureComplexityRequirement, signin, signout, forgotPassword, setCurrentStep, getAuthorization, getEmail, getName, getUID, getCurrentYear, getPermissions, hasPerm, getRoles, hasRole, getUserCaps, requireAuthentication, isAuthenticated, redirectToSignin, refreshLoginData, createLoginData, b64DecodeUnicode, persistLoginData, restoreLoginData, destroyLoginData, hasLoginData;
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
            formTemplate = function (item) {
                var _a;
                var enablePasswordChange = (_a = window.APP.portalbag.feature.enableEmail) !== null && _a !== void 0 ? _a : false;
                return "\n<form onsubmit=\"App_Auth.signin(); return false;\">\n<input type=\"submit\" style=\"display:none;\" id=\"App_Auth_dummy_submit\">\n    <div class=\"has-text-centered js-help\">\n        <h2>\n            " + i18n("Sign in to start your session") + "\n        </h2>\n    </div>\n    <div class=\"field\">\n        <div class=\"control has-icons-left\">\n            <input type=\"email\" class=\"input\" id=\"App_Auth_email\" placeholder=\"" + i18n("EMAIL") + "\" value=\"" + Misc.toInputText(item.email) + "\" required>\n            <span class=\"icon is-small is-left\">\n                <i class=\"fas fa-envelope\"></i>\n            </span>\n        </div>\n    </div>\n    <div class=\"field\">\n        <div class=\"control has-icons-left\">\n            <input type=\"password\" class=\"input\" id=\"App_Auth_password\" placeholder=\"" + i18n("PASSWORD") + "\" required>\n            <span class=\"icon is-small is-left\">\n                <i class=\"fas fa-lock\"></i>\n            </span>\n        </div>\n    </div>\n    <button type=\"submit\" class=\"button is-block is-primary is-fullwidth\">\n        <i class=\"fas fa-sign-in-alt\"></i>&nbsp;" + i18n("Sign In") + "\n    </button>\n" + (enablePasswordChange ? "\n    <div class=\"has-text-right js-submenu\">\n        <button type=\"button\" class=\"button is-text is-italic is-white\" onclick=\"App_Auth.setCurrentStep(" + steps.forgotten + ")\">\n            " + i18n("I need a new password!") + "\n        </button>\n    </div>\n" : "") + "\n</form>\n";
            };
            formForgottenTemplate = function (item) {
                return "\n<form onsubmit=\"App_Auth.forgotPassword(); return false;\">\n<input type=\"submit\" style=\"display:none;\" id=\"App_Auth_dummy_submit\">\n    <div class=\"has-text-centered js-help\">\n        <h2>\n            " + i18n("Let's fix that!") + "\n        </h2>\n        <div class=\"content\">\n            <p>\n                " + i18n("Enter your email address below. You will receive an email with a link to allow you to enter a new password") + "\n            </p>\n            <p>\n                " + i18n("The email link will expire in one week") + "\n            </p>\n        </div>\n    </div>\n    <div class=\"field\">\n        <div class=\"control has-icons-left\">\n            <input type=\"email\" class=\"input\" id=\"App_Auth_email\" placeholder=\"" + i18n("EMAIL") + "\" value=\"" + Misc.toInputText(item.email) + "\" required>\n            <span class=\"icon is-small is-left\">\n                <i class=\"fas fa-lock\"></i>\n            </span>\n        </div>\n    </div>\n    <button type=\"submit\" class=\"button is-block is-primary is-fullwidth\">\n        <i class=\"fas fa-envelope\"></i>&nbsp;" + i18n("Send Email") + "\n    </button>\n    <div class=\"has-text-left js-submenu\">\n        <button type=\"button\" class=\"button is-text is-italic is-white\" onclick=\"App_Auth.setCurrentStep(" + steps.normal + ")\">\n            " + i18n("Cancel that, I remember my password now!") + "\n        </button>\n    </div>\n</form>\n";
            };
            formRemindedTemplate = function (item) {
                return "\n<form onsubmit=\"App_Auth.forgotPassword(); return false;\">\n<input type=\"submit\" style=\"display:none;\" id=\"App_Auth_dummy_submit\">\n    <div class=\"has-text-centered js-help\">\n        <div class=\"section\">\n            <p class=\"has-text-success\">\n                <span class=\"fa-stack fa-2x\">\n                    <i class=\"far fa-circle fa-stack-2x\"></i>\n                    <i class=\"fa fa-check fa-stack-1x\"></i>\n                </span>\n            </p>\n        </div>\n        <h2>\n            " + i18n("Password reset email sent") + "\n        </h2>\n        <div class=\"content\">\n            <p>\n                " + i18n("An email has been sent to") + " <b>" + item.email + "</b>\n            </p>\n            <p>\n                " + i18n("Check out the spam folder if you don't see the email in your inbox within 5 minutes") + "\n            </p>\n        </div>\n        <button type=\"button\" class=\"button is-text is-white\" onclick=\"App_Auth.setCurrentStep(" + steps.normal + ")\">" + i18n("Done") + "</a>\n    </div>\n</form>\n";
            };
            formNewPasswordTemplate = function (item, step) {
                return "\n<form onsubmit=\"App_Auth.signin(" + step + "); return false;\">\n<input type=\"submit\" style=\"display:none;\" id=\"App_Auth_dummy_submit\">\n    <div class=\"has-text-centered js-help\">\n        <h2>\n            " + i18n("Now, let's set your password") + "\n        </h2>\n        <div class=\"content\">\n            <p>\n                " + i18n("You need to enter your password twice below") + "\n            </p>\n        </div>\n    </div>\n    <div class=\"field\">\n        <div class=\"control has-icons-left\">\n            <input type=\"email\" class=\"input\" id=\"App_Auth_email\" placeholder=\"" + i18n("EMAIL") + "\" value=\"" + Misc.toInputText(item.email) + "\">\n            <span class=\"icon is-small is-left\">\n                <i class=\"fas fa-envelope\"></i>\n            </span>\n        </div>\n    </div>\n<!--\n    <div style=\"margin: 1rem;\">\n        <p style=\"margin: 1rem;\">Passwords must meet the following complexity requirements:</p>\n        <ul style=\"padding-left: 5rem; list-style: disc;\">\n            <li>8 characters minimum</li>\n            <li>At least one lower case character</li>\n            <li>At least one upper case character</li>\n            <li>At least one special character</li>\n        </ul>\n    </div>\n-->\n    <div class=\"field\">\n        <div class=\"control has-icons-left\">\n            <input type=\"password\" class=\"input\" id=\"App_Auth_password\" placeholder=\"" + i18n("PASSWORD") + "\" onkeyup=\"App_Auth.ensurePasswordMatch()\" required>\n            <span class=\"icon is-small is-left\">\n                <i class=\"fas fa-lock\"></i>\n            </span>\n        </div>\n    </div>\n    <div class=\"field\">\n        <div class=\"control has-icons-left\">\n            <input type=\"password\" class=\"input\" id=\"App_Auth_password2\" placeholder=\"" + i18n("ENTER PASSWORD AGAIN") + "\" onkeyup=\"App_Auth.ensurePasswordMatch()\" required>\n            <span class=\"icon is-small is-left\">\n                <i class=\"fas fa-lock\"></i>\n            </span>\n        </div>\n    </div>\n    <button type=\"submit\" class=\"button is-block is-primary is-fullwidth\">\n        <i class=\"fas fa-sign-in-alt\"></i>&nbsp;" + i18n("Sign In") + "\n    </button>\n</form>\n";
            };
            pageTemplate = function (item, form, alert) {
                return "\n<section class=\"is-fullheight\">\n    <div class=\"container\">\n        <div class=\"column is-4 is-offset-4\">\n        <div class=\"box\">\n            <h1 class=\"has-text-centered has-text-dark\">" + i18n("APP WELCOME") + "</h1>\n            <div id=\"js_signin_box\">\n                <figure>\n                    <img>\n                </figure>\n            </div>\n" + alert + "\n" + form + "\n        </div>\n        </div>\n    </div>\n</section>";
            };
            exports_5("fetch", fetch = function (params) {
                returnUrl = "/";
                if (params != undefined && params.length > 0) {
                    returnUrl = decodeURIComponent(params[0]);
                }
                App.prepareRender(NS, i18n("Signin"));
                Router.registerDirtyExit(null);
                App.render();
            });
            exports_5("fetchInvitation", fetchInvitation = function (params) {
                returnUrl = "/";
                var guid = params[0];
                App.prepareRender(NS, i18n("Signin"));
                App.GET("/auth/accept-invitation/" + guid)
                    .then(function (json) {
                    currentStep = steps.invited;
                    state = json;
                    App.render();
                })
                    .catch(App.render);
            });
            exports_5("fetchReset", fetchReset = function (params) {
                returnUrl = "/";
                var guid = params[0];
                App.prepareRender(NS, i18n("Signin"));
                App.GET("/auth/reset-password/" + guid)
                    .then(function (json) {
                    currentStep = steps.resetted;
                    state = json;
                    App.render();
                })
                    .catch(App.render);
            });
            exports_5("render", render = function () {
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined)
                    return (App.serverError() ? pageTemplate(null, "", App.warningTemplate()) : "");
                var form;
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
                var alert = App.warningTemplate();
                return pageTemplate(state, form, alert);
            });
            exports_5("postRender", postRender = function () {
                if (!App.inContext(NS))
                    return;
            });
            getFormState = function () {
                return {
                    email: Misc.fromInputText("App_Auth_email"),
                    password: Misc.fromInputText("App_Auth_password")
                };
            };
            valid = function (formState) {
                if (formState.email.length == 0)
                    App.setError("Email is required");
                if (formState.password && formState.password.length == 0)
                    App.setError("Password is required");
                return App.hasNoError();
            };
            html5Valid = function () {
                document.getElementById("App_Auth_dummy_submit").click();
                var form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_5("ensurePasswordMatch", ensurePasswordMatch = function () {
                var password = document.getElementById("App_Auth_password");
                var password2 = document.getElementById("App_Auth_password2");
                if (password.value != password2.value)
                    password2.setCustomValidity(i18n("Passwords don't match"));
                else if (!ensureComplexityRequirement(password.value))
                    password2.setCustomValidity("Password doesn't meet complexity requirement");
                else
                    password2.setCustomValidity("");
            });
            ensureComplexityRequirement = function (password) {
                return password.length > 0;
                //if (password.length < 8) return false;
                //if (password == password.toUpperCase()) return false;
                //if (password == password.toLowerCase()) return false;
                //return /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/.test(password);
            };
            exports_5("signin", signin = function (step) {
                if (step === void 0) { step = 0; }
                var formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                var kind = (step == steps.invited ? "invited" : step == steps.resetted ? "resetted" : "signin");
                App.transitionUI();
                App.POST("/auth/" + kind, formState)
                    .then(function (json) {
                    createLoginData(json.token);
                    persistLoginData();
                    currentStep = steps.normal;
                    Router.goto(returnUrl, 1, true);
                })
                    .catch(App.render);
            });
            exports_5("signout", signout = function () {
                App.transitionUI();
                App.POST("/auth/signout", null)
                    .then(function (json) {
                    destroyLoginData();
                    returnUrl = "/";
                    Router.goto(returnUrl, 10);
                })
                    .catch(App.render);
            });
            exports_5("forgotPassword", forgotPassword = function () {
                var formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.transitionUI();
                App.POST("/auth/request-password-reset", formState)
                    .then(function (_) {
                    state = formState;
                    currentStep = steps.reminded;
                    App.render();
                })
                    .catch(App.render);
            });
            exports_5("setCurrentStep", setCurrentStep = function (step) {
                state = getFormState();
                currentStep = step;
                App.render();
            });
            exports_5("getAuthorization", getAuthorization = function () {
                if (!hasLoginData())
                    return "";
                if (loginData == undefined || loginData.token == undefined)
                    return "";
                if (new Date().getTime() / 1000 > loginData.expiry)
                    return "";
                return "Bearer " + loginData.token;
            });
            exports_5("getEmail", getEmail = function () {
                if (loginData == undefined || loginData.user == undefined)
                    return null;
                return loginData.user.email;
            });
            exports_5("getName", getName = function () {
                if (loginData == undefined || loginData.user == undefined)
                    return null;
                return loginData.user.name;
            });
            exports_5("getUID", getUID = function () {
                if (loginData == undefined || loginData.user == undefined)
                    return null;
                return loginData.user.uid;
            });
            exports_5("getCurrentYear", getCurrentYear = function () {
                if (loginData == undefined || loginData.user == undefined)
                    return null;
                return loginData.user.year;
            });
            exports_5("getPermissions", getPermissions = function () {
                if (loginData == undefined || loginData.user == undefined)
                    return [];
                return loginData.user.permissions || [];
            });
            exports_5("hasPerm", hasPerm = function (permissionID) {
                return (getPermissions().indexOf(permissionID) != -1);
            });
            exports_5("getRoles", getRoles = function () {
                if (loginData == undefined || loginData.user == undefined)
                    return [];
                return loginData.user.roles || [];
            });
            exports_5("hasRole", hasRole = function (roleID) {
                return (getRoles().indexOf(roleID) != -1);
            });
            exports_5("getUserCaps", getUserCaps = function () {
                if (loginData == undefined || loginData.user == undefined)
                    return null;
                return loginData.user;
            });
            exports_5("requireAuthentication", requireAuthentication = function () {
                var logging = (window.location.hash.indexOf("#/signin/") == 0) ||
                    (window.location.hash.indexOf("#/accept-invitation/") == 0) ||
                    (window.location.hash.indexOf("#/reset-password/") == 0);
                return !(logging || isAuthenticated());
            });
            exports_5("isAuthenticated", isAuthenticated = function () {
                return getAuthorization().length > 0;
            });
            exports_5("redirectToSignin", redirectToSignin = function () {
                destroyLoginData();
                var url = window.location.hash;
                Router.goto("#/signin/" + encodeURIComponent(url), 100);
            });
            exports_5("refreshLoginData", refreshLoginData = function () {
                return App.POST("/auth/refresh", null)
                    .then(function (json) {
                    createLoginData(json.token);
                    persistLoginData();
                    Router.reload();
                });
            });
            createLoginData = function (token) {
                var payloadBase64 = token.split('.')[1].replace(/-/g, '+').replace(/_/g, '/');
                var payloadUTF8 = b64DecodeUnicode(payloadBase64);
                var payload = JSON.parse(payloadUTF8);
                var perms = payload["perms"] || [];
                if (!Array.isArray(perms)) {
                    perms = [perms];
                }
                var role = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
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
            b64DecodeUnicode = function (b64) {
                return decodeURIComponent(Array.prototype.map.call(atob(b64), function (c) {
                    return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
                }).join(''));
            };
            persistLoginData = function () {
                storage.setItem("signin", JSON.stringify(loginData));
            };
            restoreLoginData = function () {
                loginData = JSON.parse(storage.getItem("signin"));
            };
            destroyLoginData = function () {
                storage.removeItem("signin");
                loginData = {};
            };
            hasLoginData = function () {
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
            exports_6("buttonTemplate", buttonTemplate = function (pageid) {
                return "\n<a class=\"button\" href=\"#/page/" + pageid + "\" style=\"margin-left: 4px;\">\n    <span class=\"icon is-small\">\n        <i class=\"fa fa-lock\"></i>\n    </span>\n</a>";
            });
            exports_6("isAdmin", isAdmin = function () { return (Auth.getRoles().indexOf(1) != -1); });
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
            exports_7("fetch", fetch = function () {
                App.prepareRender(NS, "Home");
                Router.registerDirtyExit(null);
                App.render();
            });
            exports_7("render", render = function () {
                if (!App.inContext(NS))
                    return "";
                return "";
            });
            exports_7("postRender", postRender = function () {
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
            exports_8("render", render = function () {
                return "\n" + renderHeader() + "\n" + renderMenu() + "\n" + Home.render() + "\n" + renderFooter() + "\n";
            });
            exports_8("postRender", postRender = function () {
                Home.postRender();
            });
            renderHeader = function () {
                return "";
            };
            renderMenu = function () {
                return "";
            };
            renderFooter = function () {
                return "";
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
            Router.addRoute("^#/signin/(.*)$", function (params) { Auth.fetch(params); });
            Router.addRoute("^#/signout/?$", Auth.signout);
            Router.addRoute("^#/accept-invitation/(.*)$", Auth.fetchInvitation);
            Router.addRoute("^#/reset-password/(.*)$", Auth.fetchReset);
            checkAuthenticationExpiryLoop = function () {
                var updater = function () {
                    if (App.requireAuthentication()) {
                        console.log("Authentication required");
                        Router.reload();
                    }
                };
                setInterval(updater, 2000);
            };
            exports_9("startup", startup = function (hasPublicHomePage, layout, theme) {
                App.initialize(hasPublicHomePage, layout, theme);
                // We need to wait before the caller initializes its routes before Router.gotoCurrent()
                setTimeout(function () {
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
    var App, authrole, fetch_authrole;
    var __moduleName = context_10 && context_10.id;
    return {
        setters: [
            function (App_4) {
                App = App_4;
            }
        ],
        execute: function () {
            exports_10("fetch_authrole", fetch_authrole = function () {
                return function (data) {
                    if (authrole != undefined && authrole.length > 0)
                        return;
                    return App.GET("/account/role").then(function (json) { exports_10("authrole", authrole = json); });
                };
            });
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
    var Misc, NullPager, render, renderStatic, sortableHeaderLink, headerLink, rowNumber, asParams, asDico, searchTemplate;
    var __moduleName = context_12 && context_12.id;
    return {
        setters: [
            function (Misc_2) {
                Misc = Misc_2;
            }
        ],
        execute: function () {
            exports_12("NullPager", NullPager = { pageNo: 1, pageSize: 1000, rowCount: 0, searchText: "", sortColumn: "", sortDirection: "", filter: {} });
            exports_12("render", render = function (pager, ns, sizes, searchHtml, customHtml) {
                if (searchHtml === void 0) { searchHtml = null; }
                if (customHtml === void 0) { customHtml = null; }
                var rowFirst = ((pager.pageNo - 1) * pager.pageSize) + 1;
                if (pager.rowCount == 0)
                    rowFirst = 0;
                var rowLast = Math.min(rowFirst + pager.pageSize - 1, pager.rowCount);
                var pageCount = Math.floor((Math.max(pager.rowCount - 1, 0) / pager.pageSize) + 1);
                var firstPage = ns + ".goto(1, " + pager.pageSize + ")";
                var prevPage = ns + ".goto(" + (pager.pageNo - 1) + ", " + pager.pageSize + ")";
                var nextPage = ns + ".goto(" + (pager.pageNo + 1) + ", " + pager.pageSize + ")";
                var lastPage = ns + ".goto(" + pageCount + ", " + pager.pageSize + ")";
                var allSizes = "";
                if (sizes.length > 0) {
                    allSizes = sizes.reduce(function (html, size) {
                        return html + ("\n            <a class=\"dropdown-item\" href=\"#\" onclick=\"" + ns + ".goto(1, " + size + ");return false;\">\n                <span class=\"fa fa-check\" style=\"width: 15px; " + (size != pager.pageSize ? "visibility: hidden" : "") + "\"></span>\n                " + i18n("%n Records per Page", size) + "\n            </a>");
                    }, "");
                }
                return "\n<div class=\"level\">\n    <div class=\"level-left\">\n        <div class=\"field is-horizontal\">\n            <div class=\"field-body\">\n                " + (searchHtml != undefined && searchHtml.length > 0 ? searchHtml : "") + "\n                " + (customHtml != undefined && customHtml.length > 0 ? customHtml : "") + "\n            </div>\n        </div>\n    </div>\n    <div class=\"level-right\">\n        <div class=\"field is-grouped\">\n            <div class=\"dropdown is-right is-hoverable\" xx-js-skip-render-class=\"is-active\">\n                <div class=\"dropdown-trigger\">\n                    <button class=\"button\" aria-haspopup=\"true\" aria-controls=\"dropdown-menu\" title=\"" + i18n("Options") + "\">\n                        <span>" + i18n("%{rowFirst}-%{rowLast} of %{rowCount} Records", { rowFirst: rowFirst, rowLast: rowLast, rowCount: pager.rowCount }) + "</span>\n                        <span class=\"icon is-small\"><i class=\"fas fa-angle-down\" aria-hidden=\"true\"></i></span>\n                    </button>\n                </div>\n                <div class=\"dropdown-menu\" id=\"dropdown-menu\" role=\"menu\">\n                    <div class=\"dropdown-content\">\n                        <a class=\"dropdown-item\" href=\"#\" onclick=\"" + firstPage + ";return false;\">\n                            <span class=\"far fa-fast-backward\" style=\"width: 15px;\"></span>\n                            " + i18n("Go To First Page") + "\n                        </a>\n                        <a class=\"dropdown-item\" href=\"#\" onclick=\"" + lastPage + ";return false;\">\n                            <span class=\"far fa-fast-forward\" style=\"width: 15px;\"></span>\n                            " + i18n("Go To Last Page") + "\n                        </a>\n                        <hr class=\"dropdown-divider\">\n                        " + allSizes + "\n                    </div>\n                </div>\n            </div>\n            <div class=\"buttons has-addons\" style=\"margin-left: 4px;\">\n                <button type=\"button\" class=\"button\" " + (pager.pageNo == 1 ? "disabled" : "") + " onclick=\"" + firstPage + "\"><i class=\"fal fa-fast-backward\"></i></button>\n                <button type=\"button\" class=\"button\" " + (pager.pageNo == 1 ? "disabled" : "") + " onclick=\"" + prevPage + "\"><i class=\"fal fa-step-backward\"></i></button>\n                <button type=\"button\" class=\"button\" " + (pager.pageNo == pageCount ? "disabled" : "") + " onclick=\"" + nextPage + "\"><i class=\"fal fa-step-forward\"></i></button>\n                <button type=\"button\" class=\"button\" " + (pager.pageNo == pageCount ? "disabled" : "") + " onclick=\"" + lastPage + "\"><i class=\"fal fa-fast-forward\"></i></button>\n            </div>\n        </div>\n    </div>\n</div>";
            });
            exports_12("renderStatic", renderStatic = function (pager) {
                return "\n<div class=\"js-container\">\n    <div class=\"js-filter-column\"></div>\n    <div class=\"js-control\">\n        <span><em>" + pager.rowCount + " records found</strong></em>\n    </div>\n</div>";
            });
            exports_12("sortableHeaderLink", sortableHeaderLink = function (pager, ns, linkText, columnName, defaultDirection /*"ASC"*/, style) {
                if (style === void 0) { style = ""; }
                var indicator = "";
                var sorting = "";
                var nextDir = defaultDirection;
                if (columnName.toUpperCase() == pager.sortColumn.toUpperCase())
                    nextDir = (pager.sortDirection == "ASC" ? "DESC" : "ASC");
                if (columnName.toUpperCase() == pager.sortColumn.toUpperCase()) {
                    indicator = "&nbsp;<i class=\"fa " + (pager.sortDirection == "DESC" ? "fa-sort-down" : "fa-sort-up") + "\"></i>";
                    sorting = " class=\"js-sorting\"";
                }
                if (indicator.length == 0)
                    indicator = '&nbsp;<i class="fa fa-sort-down" style="visibility: hidden;"></i>';
                return "<th" + sorting + " " + (style ? "style=\"" + style + "\"" : "") + "><a href=\"#\" onclick=\"" + ns + ".sortBy('" + columnName + "', '" + nextDir + "');return false;\">" + linkText + indicator + "</a></th>";
            });
            exports_12("headerLink", headerLink = function (linkText) {
                return "<th class=\"js-no-sorting\">" + linkText + "</th>";
            });
            exports_12("rowNumber", rowNumber = function (pager, index) {
                return 1 + index + ((pager.pageNo - 1) * pager.pageSize);
            });
            exports_12("asParams", asParams = function (pager) {
                var searchText = (pager.searchText != undefined ? encodeURIComponent(pager.searchText) : "");
                var params = "pn=" + pager.pageNo + "&ps=" + pager.pageSize + "&sc=" + pager.sortColumn + "&sd=" + pager.sortDirection + "&st=" + searchText;
                if (pager.filter != undefined) {
                    Object.keys(pager.filter).forEach(function (key) {
                        if (pager.filter[key] != undefined) {
                            var value = pager.filter[key];
                            if (value != null && typeof value.getTime === "function") {
                                var text = JSON.stringify(value).replace(/"/g, "");
                                params += "&" + key + "=" + text;
                            }
                            else if (Array.isArray(value)) {
                                params += "&" + key + "=" + value.join(",");
                            }
                            else {
                                params += "&" + key + "=" + value;
                            }
                        }
                    });
                }
                return params;
            });
            exports_12("asDico", asDico = function (pager) {
                var dico = {
                    pageNo: pager.pageNo,
                    pageSize: pager.pageSize,
                    sortColumn: pager.sortColumn,
                    sortDirection: pager.sortDirection,
                    searchText: pager.searchText
                };
                if (pager.filter != undefined) {
                    Object.keys(pager.filter).forEach(function (key) {
                        if (pager.filter[key] != undefined) {
                            dico[key] = pager.filter[key];
                        }
                    });
                }
                return dico;
            });
            exports_12("searchTemplate", searchTemplate = function (pager, ns, xtra) {
                return "\n    <div class=\"field\">\n        <label class=\"label\">" + i18n("SEARCH") + "</label>\n        <div class=\"control has-icons-left\" style=\"width:125px;\">\n            <input class=\"input\" type=\"text\" placeholder=\"" + i18n("SEARCH") + "\" value=\"" + Misc.toInputText(pager.searchText) + "\" xonchange=\"" + ns + ".search(this)\" onkeydown=\"if (event.keyCode == 13) " + ns + ".search(event.target)\" " + (xtra || "") + ">\n            <span class=\"icon is-small is-left\">\n                <i class=\"fas fa-search\"></i>\n            </span>\n        </div>\n    </div>";
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
            Autocomplete = /** @class */ (function () {
                function Autocomplete(ns, propName, required) {
                    var _this = this;
                    if (required === void 0) { required = false; }
                    this.ns = ns;
                    this.propName = propName;
                    this.required = required;
                    this.isActive = false;
                    this.disabled = false;
                    this.render = function () {
                        var hasIndex = _this.pagedList.list.reduce(function (selected, one) { return one.selected ? true : selected; }, false);
                        if (!hasIndex) {
                            var index = (_this.required || _this.text == undefined || _this.text.length == 0 ? 0 : 1);
                            if (_this.pagedList.list.length > index)
                                _this.pagedList.list[index].selected = true;
                        }
                        var opt = _this.options;
                        var textRows = _this.pagedList.list.map(function (one, index) {
                            var key = opt.keyTemplate(one);
                            var value = opt.valueTemplate(one).replace(/"/g, "&quot;");
                            var active = (one.selected ? "is-active" : "");
                            var detail = opt.detailTemplate(one);
                            return "<a href=\"#\" data-key=\"" + key + "\" data-value=\"" + value + "\" data-index=\"" + index + "\" onclick=\"" + _this.handle('a.onclick') + "; return false;\" class=\"dropdown-item " + active + "\"><p>" + detail + "</p></a>";
                        });
                        var text = textRows.join('<hr class="dropdown-divider">');
                        var html = "\n<div class=\"dropdown-menu\">\n    <div class=\"dropdown-content\">\n        " + text + "\n" + (textRows.length > 0 ? "\n        <div class=\"dropdown-item\">\n            <div>&nbsp;\n                <div class=\"is-pulled-right has-text-grey-light\">" + textRows.length + " out of " + _this.pagedList.pager.rowCount + " results</div>\n            </div>\n        </div>\n" : "\n        <div class=\"dropdown-item\">\n            <div>&nbsp;\n                <div class=\"is-pulled-right has-text-grey-light\">" + i18n("No results") + "</div>\n            </div>\n        </div>\n") + "\n    </div>\n</div>\n";
                        return html;
                    };
                    this.postRender = function () {
                    };
                    this.handle = function (eventName) {
                        return _this.id + ".on(this, '" + eventName + "')";
                    };
                    this.on = function (element, eventName) {
                        if (eventName == 'onfocus') {
                            _this.isActive = true;
                            _this.text = element.value;
                            window[_this.ns].onautocomplete(_this.id);
                        }
                        else if (eventName == 'onkeydown') {
                            var kevent = event;
                            if (kevent.key == "ArrowUp") {
                                event.preventDefault();
                                var index = _this.pagedList.list.findIndex(function (one) { return one.selected; });
                                if (index > 0) {
                                    _this.pagedList.list[index].selected = false;
                                    _this.pagedList.list[index - 1].selected = true;
                                    App.render();
                                }
                            }
                            else if (kevent.key == "ArrowDown") {
                                event.preventDefault();
                                var index = _this.pagedList.list.findIndex(function (one) { return one.selected; });
                                if (index < _this.pagedList.list.length - 1) {
                                    _this.pagedList.list[index].selected = false;
                                    _this.pagedList.list[index + 1].selected = true;
                                    App.render();
                                }
                            }
                            else if (_this.isActive && ["Tab", "Enter", "Escape"].indexOf(kevent.key) > -1) {
                                event.preventDefault();
                                clearTimeout(_this.blurTimer);
                                var one = _this.pagedList.list.find(function (one) { return one.selected; });
                                var key = _this.options.keyTemplate(one);
                                var text = _this.options.valueTemplate(one).replace(/"/g, "&quot;");
                                _this.setState(key, text);
                                _this.isActive = false;
                                var input = document.getElementById(_this.input_id);
                                input.dataset["key"] = _this.key;
                                input.blur();
                                window[_this.ns].onchange(input);
                            }
                            else {
                                clearTimeout(_this.typingTimer);
                                _this.typingTimer = setTimeout(function (_) {
                                    _this.isActive = true;
                                    _this.text = element.value;
                                    window[_this.ns].onautocomplete(_this.id);
                                }, 50);
                            }
                        }
                        else if (eventName == "a.onclick") {
                            clearTimeout(_this.blurTimer);
                            var key = element.dataset["key"];
                            var text = element.dataset["value"];
                            _this.setState(key, text);
                            _this.isActive = false;
                            var input = document.getElementById(_this.input_id);
                            input.dataset["key"] = _this.key;
                            window[_this.ns].onchange(input);
                        }
                        else if (eventName == "onblur") {
                            _this.blurTimer = setTimeout(function (_) {
                                _this.isActive = false;
                                var required = element.hasAttribute("required");
                                if (required) {
                                    _this.setState(_this.initialKey, _this.initialText);
                                    App.render();
                                }
                                else {
                                    var value = element.value.trim();
                                    if (value.length == 0 || value != _this.initialText) {
                                        _this.setState(null, null);
                                        element.dataset["key"] = _this.key;
                                        window[_this.ns].onchange(element);
                                    }
                                    else {
                                        App.render();
                                    }
                                }
                            }, 500);
                        }
                    };
                    this.input_id = this.ns + "_" + this.propName;
                    this.id = this.ns + "_" + this.propName + "Autocomplete";
                    window[this.id] = this;
                }
                Autocomplete.prototype.setState = function (key, text) {
                    this.initialKey = this.key = key;
                    this.initialText = this.text = text;
                };
                Object.defineProperty(Autocomplete.prototype, "keyValue", {
                    get: function () {
                        return this.key;
                    },
                    enumerable: false,
                    configurable: true
                });
                Object.defineProperty(Autocomplete.prototype, "textValue", {
                    get: function () {
                        return this.text;
                    },
                    enumerable: false,
                    configurable: true
                });
                return Autocomplete;
            }());
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
            Calendar = /** @class */ (function () {
                function Calendar(input_id, required, alwaysOpened, asFilter, hasTime, hasChanger, hasToday) {
                    var _this = this;
                    if (required === void 0) { required = false; }
                    if (alwaysOpened === void 0) { alwaysOpened = false; }
                    if (asFilter === void 0) { asFilter = false; }
                    if (hasTime === void 0) { hasTime = false; }
                    if (hasChanger === void 0) { hasChanger = false; }
                    if (hasToday === void 0) { hasToday = false; }
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
                    this.setState = function (date, forcedYear, min, max) {
                        if (date != undefined) {
                            _this.selectedYear = _this.displayedYear = date.getFullYear();
                            _this.selectedMonth = _this.displayedMonth = date.getMonth() + 1;
                            _this.selectedDay = date.getDate();
                            _this.selectedHour = date.getHours();
                            _this.selectedMinute = date.getMinutes();
                            _this.initialDate = new Date(date.getTime());
                            _this.isNullDate = false;
                        }
                        else {
                            var now = new Date();
                            _this.selectedYear = _this.displayedYear = (forcedYear != undefined ? forcedYear : now.getFullYear());
                            _this.selectedMonth = _this.displayedMonth = now.getMonth() + 1;
                            _this.selectedDay = now.getDate();
                            _this.selectedHour = 0;
                            _this.selectedMinute = 0;
                            _this.initialDate = null;
                            _this.isNullDate = true;
                        }
                        if (min != undefined)
                            _this.min = min;
                        if (max != undefined)
                            _this.max = max;
                        if (forcedYear) {
                            _this.forcedYear = forcedYear;
                            _this.min = new Date(forcedYear, 0, 1);
                            _this.max = new Date(forcedYear, 11, 31);
                        }
                    };
                    this.render = function () {
                        var date = new Date(_this.displayedYear, _this.displayedMonth - 1, 1, 0, 0, 0, 0);
                        var year = date.getFullYear();
                        var month = date.getMonth();
                        var firstDate = new Date(date);
                        //
                        while (true) {
                            while (firstDate.getDay() != 0)
                                firstDate.setDate(firstDate.getDate() - 1);
                            if (firstDate.getMonth() != month || firstDate.getDate() == 1)
                                break;
                            firstDate.setDate(firstDate.getDate() - 1);
                        }
                        var lastDate = new Date(date);
                        var lastOfMonth = new Date(year, month + 1, 0);
                        //
                        while (true) {
                            while (lastDate.getDay() != 6)
                                lastDate.setDate(lastDate.getDate() + 1);
                            if (lastDate.getMonth() != month || lastDate.getTime() == lastOfMonth.getTime())
                                break;
                            lastDate.setDate(lastDate.getDate() + 1);
                        }
                        var selectedDate = new Date(_this.selectedYear, _this.selectedMonth - 1, _this.selectedDay, 0, 0, 0, 0);
                        var tr = "";
                        while (true) {
                            tr += "<tr>";
                            for (var iday = 0; iday < 7; iday++) {
                                var selected = (firstDate.getTime() == selectedDate.getTime());
                                var other = (firstDate.getMonth() != month);
                                var outside = ((_this.minValue && firstDate < _this.minValue) || (_this.maxValue && firstDate > _this.maxValue));
                                var dateText = [firstDate.getFullYear(), firstDate.getMonth() + 1, firstDate.getDate()].join("/");
                                var classes = [];
                                if (selected)
                                    classes.push("selected");
                                if (other)
                                    classes.push("other");
                                if (outside)
                                    classes.push("outside");
                                tr += "<td " + (classes.length ? "class=\"" + classes.join(" ") + "\"" : "") + " data-select=\"" + dateText + "\">" + firstDate.getDate() + "</td>";
                                firstDate.setDate(firstDate.getDate() + 1);
                            }
                            tr += "</tr>";
                            if (firstDate.getTime() >= lastDate.getTime())
                                break;
                        }
                        var prevMonth = _this.displayedMonth - 1;
                        var prevYear = _this.displayedYear;
                        if (prevMonth == 0) {
                            prevMonth = 12;
                            prevYear--;
                        }
                        var nextMonth = _this.displayedMonth + 1;
                        var nextYear = _this.displayedYear;
                        if (nextMonth == 13) {
                            nextMonth = 1;
                            nextYear++;
                        }
                        var trMonths = months.reduce(function (html, item, index) {
                            var month = index + 1;
                            var name = item.substr(0, 3);
                            return html + ("<div data-month=\"" + month + "\"" + (_this.displayedMonth == month ? " class='selected'" : "") + ">" + name + "</div>");
                        }, "");
                        var trYears = "";
                        for (var ix = 0; ix < 9; ix++) {
                            var year_1 = _this.displayedYear - 4 + ix;
                            trYears += "<div " + (_this.displayedYear == year_1 ? "class='selected'" : "") + ">" + year_1 + "</div>";
                        }
                        return "\n    <div id=\"" + _this.id + "\" class=\"jscal-container " + (_this.hidden ? "js-display-none" : "") + "\">\n    \n    <div class=\"jscal-banner\">\n        <div class=\"jscal-day\">\n            " + days[selectedDate.getDay()] + "\n        </div>\n        <div class=\"jscal-date\" data-date=\"" + _this.selectedYear + "/" + _this.selectedMonth + "/" + _this.selectedDay + "\" data-time=\"" + _this.selectedHour + ":" + _this.selectedMinute + "\">\n            <div>" + ("0" + selectedDate.getDate()).slice(-2) + "</div>\n            <div>\n                <div>" + months[selectedDate.getMonth()].substr(0, 3) + "</div>\n                <div>" + selectedDate.getFullYear() + "</div>\n            </div>\n        </div>\n    </div>\n    <div class=\"jscal-nav\">\n        <a class=\"previous\" data-display=\"" + prevYear + "/" + prevMonth + "\"><i class=\"fas fa-chevron-left\"></i></a>\n        <div>\n            <a class=\"select-month\">" + months[date.getMonth()] + "</a>\n            <a class=\"select-year\">" + year + "</a>\n        </div>\n        <a class=\"next\" data-display=\"" + nextYear + "/" + nextMonth + "\"><i class=\"fas fa-chevron-right\"></i></a>\n    </div>\n    <div class=\"jscal-years " + (_this.viewName != "jscal-years" ? "js-hidden" : "") + "\">\n        <a class=\"previous\"><i class=\"fas fa-chevron-left\"></i></a>\n        <div>\n            " + trYears + "\n        </div>\n        <a class=\"next\"><i class=\"fas fa-chevron-right\"></i></a>\n    </div>\n    <div class=\"jscal-months " + (_this.viewName != "jscal-months" ? "js-hidden" : "") + "\">\n        " + trMonths + "\n    </div>\n    <div class=\"jscal-days " + (_this.viewName != "jscal-days" ? "js-hidden" : "") + "\">\n        <table>\n            <thead>\n                <tr>\n                    <th>Sun</th> <th>Mon</th> <th>Tue</th> <th>Wed</th> <th>Thu</th> <th>Fri</th> <th>Sat</th>\n                </tr>\n            </thead>\n            <tbody>\n                " + tr + "\n            </tbody>\n        </table>\n        <hr>\n\n" + (_this.hasButtons ? "\n        <div class=\"buttons\">\n            <button class=\"button cancel\"><span>Cancel</span></button>\n" + (!_this.required ? "\n            <button class=\"button clear\"><span>Clear</span></button>\n" : "") + "\n" + (_this.hasToday ? "\n            <button class=\"button today is-primary\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><span>Today</span></button>\n" : "") + "\n            <button class=\"button ok is-primary\" " + (!_this.hasValidYear ? "disabled" : "") + "><span class=\"icon\"><i class=\"fa fa-check\"></i></span><span>Select</span></button>\n        </div>\n" : "") + "\n\n    </div>\n    \n    </div>";
                    };
                    this.postRender = function () {
                        var _a, _b;
                        var wrapperElem = document.getElementById(_this.input_id + "_wrapper");
                        if (wrapperElem == undefined)
                            return;
                        // Remove event listeners
                        wrapperElem.outerHTML = wrapperElem.outerHTML;
                        wrapperElem = document.getElementById(_this.id);
                        wrapperElem.querySelector(".jscal-container tbody").addEventListener("click", function (event) {
                            var td = event.target;
                            if (td.dataset.select == undefined)
                                return;
                            var parts = td.dataset.select.split("/");
                            var selectedYear = +parts[0];
                            var selectedMonth = +parts[1];
                            var selectedDay = +parts[2];
                            var newDate = new Date(selectedYear, selectedMonth - 1, selectedDay, 0, 0, 0, 0);
                            if (_this.minValue && newDate < _this.minValue)
                                return;
                            if (_this.maxValue && newDate > _this.maxValue)
                                return;
                            _this.selectedYear = selectedYear;
                            _this.selectedMonth = selectedMonth;
                            _this.selectedDay = selectedDay;
                            _this.isNullDate = false;
                            if (!_this.asFilter) {
                                App.render();
                            }
                            else {
                                _this.initialDate = _this.dateValue;
                                _this.hidden = (true && !_this.alwaysOpened);
                                //
                                var parts_1 = _this.input_id.split("_");
                                var ns = parts_1.slice(0, -1).join("_");
                                var name_1 = parts_1[parts_1.length - 1];
                                window[ns].oncalendar_filter(name_1, _this.dateValue);
                            }
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-nav .previous").addEventListener("click", function (event) {
                            var element = event.target.closest("a");
                            var parts = element.dataset.display.split("/");
                            _this.displayedYear = +parts[0];
                            _this.displayedMonth = +parts[1];
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-nav .next").addEventListener("click", function (event) {
                            var element = event.target.closest("a");
                            var parts = element.dataset.display.split("/");
                            _this.displayedYear = +parts[0];
                            _this.displayedMonth = +parts[1];
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-date").addEventListener("click", function (event) {
                            var element = event.target.closest(".jscal-date");
                            var parts = element.dataset.date.split("/");
                            _this.selectedYear = _this.displayedYear = +parts[0];
                            _this.selectedMonth = _this.displayedMonth = +parts[1];
                            _this.selectedDay = +parts[2];
                            _this.viewName = "jscal-days";
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-months").addEventListener("click", function (event) {
                            var element = event.target;
                            _this.displayedMonth = +element.dataset.month;
                            _this.viewName = "jscal-days";
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-years div").addEventListener("click", function (event) {
                            var element = event.target;
                            _this.displayedYear = +element.innerText;
                            _this.viewName = "jscal-days";
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-years .previous").addEventListener("click", function (event) {
                            _this.displayedYear = _this.displayedYear - 4;
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .jscal-years .next").addEventListener("click", function (event) {
                            _this.displayedYear = _this.displayedYear + 4;
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .select-month").addEventListener("click", function (event) {
                            _this.viewName = "jscal-months";
                            App.render();
                        });
                        wrapperElem.querySelector(".jscal-container .select-year").addEventListener("click", function (event) {
                            _this.viewName = "jscal-years";
                            App.render();
                        });
                        if (_this.hasButtons) {
                            wrapperElem.querySelector(".jscal-container .cancel").addEventListener("click", function (event) {
                                _this.setState(_this.initialDate);
                                _this.hidden = (true && !_this.alwaysOpened);
                                App.render();
                            });
                            wrapperElem.querySelector(".jscal-container .ok").addEventListener("click", function (event) {
                                _this.initialDate = _this.dateValue;
                                _this.hidden = (true && !_this.alwaysOpened);
                                //
                                //App.render()
                                var dateElem = document.getElementById(_this.input_id);
                                var parts = _this.input_id.split("_");
                                var ns = parts.slice(0, -1).join("_");
                                var name = parts[parts.length - 1];
                                window[ns].onchange(dateElem);
                            });
                            if (!_this.required) {
                                (_a = wrapperElem.querySelector(".jscal-container .clear")) === null || _a === void 0 ? void 0 : _a.addEventListener("click", function (event) {
                                    _this.isNullDate = true;
                                    App.render();
                                });
                            }
                            if (_this.hasToday) {
                                (_b = wrapperElem.querySelector(".jscal-container .today")) === null || _b === void 0 ? void 0 : _b.addEventListener("click", function (event) {
                                    var today = new Date(new Date().setHours(0, 0, 0, 0));
                                    _this.setState(today);
                                    _this.hidden = (true && !_this.alwaysOpened);
                                    //
                                    //App.render()
                                    var dateElem = document.getElementById(_this.input_id);
                                    dateElem.value = Misc.toInputDate(today);
                                    var parts = _this.input_id.split("_");
                                    var ns = parts.slice(0, -1).join("_");
                                    var name = parts[parts.length - 1];
                                    window[ns].onchange(dateElem);
                                });
                            }
                        }
                        //
                        // Date input
                        //
                        var dateElem = document.getElementById(_this.input_id);
                        if (dateElem) {
                            dateElem.addEventListener("focus", function (event) {
                                dateElem.value = dateElem.value.replace(/\D+/g, "");
                                try {
                                    if (_this.forcedYear) {
                                        dateElem.setSelectionRange(4, 8);
                                    }
                                    else {
                                        dateElem.select();
                                    }
                                }
                                catch (error) { }
                                dateElem.type = "number";
                            });
                            var ondatechange_1 = function (event) {
                                var text = "00000000" + dateElem.value.replace(/\D+/g, "");
                                var dd = text.slice(-2);
                                var mm = text.slice(-4, -2);
                                var yy = (_this.forcedYear != undefined ? _this.forcedYear : text.slice(-8, -4));
                                text = yy + "-" + mm + "-" + dd;
                                dateElem.type = "text";
                                dateElem.value = text;
                                dateElem.setAttribute("value", text);
                                var date = new Date(text);
                                var min = dateElem.dataset.min;
                                var max = dateElem.dataset.max;
                                var outside = ((min != undefined) && date < (new Date(min))) || ((max != undefined) && date > (new Date(max)));
                                if (Misc.isValidDateString(text) && !outside) {
                                    dateElem.style.borderColor = "";
                                    dateElem.style.zIndex = "";
                                    _this.isValid = true;
                                    //
                                    date = new Date(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), _this.selectedHour, _this.selectedMinute, 0, 0);
                                    _this.setState(date, _this.forcedYear, _this.min, _this.max);
                                    //
                                    var parts = _this.input_id.split("_");
                                    var ns = parts.slice(0, -1).join("_");
                                    var name_2 = parts[parts.length - 1];
                                    if (!_this.asFilter) {
                                        window[ns].onchange(dateElem);
                                    }
                                    else {
                                        window[ns].oncalendar_filter(name_2, _this.dateValue);
                                    }
                                    return true;
                                }
                                dateElem.style.borderColor = "red";
                                dateElem.style.zIndex = "1";
                                _this.isValid = false;
                            };
                            dateElem.addEventListener("change", ondatechange_1);
                            dateElem.addEventListener("blur", function (event) {
                                if (isNaN(+dateElem.value)) //return if formatted yyyy-mm-dd
                                    return;
                                ondatechange_1(event);
                            });
                        }
                        //
                        // Time input
                        //
                        var timeElem = document.getElementById(_this.input_id + "_time");
                        if (timeElem) {
                            timeElem.addEventListener("focus", function (event) {
                                timeElem.value = timeElem.value.replace(/\D+/g, "");
                                timeElem.select();
                                timeElem.type = "number";
                            });
                            var ontimechange_1 = function (event) {
                                var text = "0000" + timeElem.value.replace(/\D+/g, "");
                                var mm = text.slice(-2);
                                var hh = text.slice(-4, -2);
                                text = hh + ":" + mm;
                                timeElem.type = "text";
                                timeElem.value = text;
                                timeElem.setAttribute("value", text);
                                if (Misc.isValidTimeString(text)) {
                                    timeElem.style.borderColor = "";
                                    timeElem.style.zIndex = "";
                                    _this.isValid = true;
                                    //
                                    var date = new Date(_this.dateValue);
                                    date.setHours(+hh);
                                    date.setMinutes(+mm);
                                    _this.setState(date, _this.forcedYear, _this.min, _this.max);
                                    //
                                    var parts = _this.input_id.split("_");
                                    var ns = parts.slice(0, -1).join("_");
                                    var name_3 = parts[parts.length - 1];
                                    window[ns].onchange(timeElem);
                                    return true;
                                }
                                timeElem.style.borderColor = "red";
                                timeElem.style.zIndex = "1";
                                _this.isValid = false;
                            };
                            timeElem.addEventListener("change", ontimechange_1);
                            timeElem.addEventListener("blur", function (event) {
                                if (isNaN(+timeElem.value)) //return if formatted hh:mm
                                    return;
                                ontimechange_1(event);
                            });
                        }
                        //
                        // Clear button
                        //
                        var clearElem = document.getElementById(_this.input_id + "_clear");
                        if (clearElem) {
                            clearElem.addEventListener("click", function (event) {
                                _this.isNullDate = true;
                                //
                                var parts = _this.input_id.split("_");
                                var ns = parts.slice(0, -1).join("_");
                                var name = parts[parts.length - 1];
                                if (!_this.asFilter) {
                                    window[ns].onchange(dateElem);
                                }
                                else {
                                    window[ns].oncalendar_filter(name, _this.dateValue);
                                }
                            });
                        }
                        //
                        // Popup button
                        //
                        var popupElem = document.getElementById(_this.input_id + "_popup");
                        if (popupElem) {
                            popupElem.addEventListener("click", function (event) {
                                _this.toggle();
                            });
                        }
                        //
                        // Previous button
                        //
                        var previousElem = document.getElementById(_this.input_id + "_previous");
                        if (previousElem) {
                            previousElem.addEventListener("click", function (event) {
                                var prevDay = new Date(_this.dateValue.getTime());
                                prevDay.setDate(prevDay.getDate() - 1);
                                _this.setState(prevDay, _this.forcedYear, _this.min, _this.max);
                                dateElem.setAttribute("value", Misc.toInputDate(_this.dateValue));
                                //
                                var parts = _this.input_id.split("_");
                                var ns = parts.slice(0, -1).join("_");
                                var name = parts[parts.length - 1];
                                if (!_this.asFilter) {
                                    window[ns].onchange(dateElem);
                                }
                                else {
                                    window[ns].oncalendar_filter(name, _this.dateValue);
                                }
                            });
                        }
                        //
                        // Next button
                        //
                        var nextElem = document.getElementById(_this.input_id + "_next");
                        if (nextElem) {
                            nextElem.addEventListener("click", function (event) {
                                var nextDay = new Date(_this.dateValue.getTime());
                                nextDay.setDate(nextDay.getDate() + 1);
                                _this.setState(nextDay, _this.forcedYear, _this.min, _this.max);
                                dateElem.setAttribute("value", Misc.toInputDate(_this.dateValue));
                                //
                                var parts = _this.input_id.split("_");
                                var ns = parts.slice(0, -1).join("_");
                                var name = parts[parts.length - 1];
                                if (!_this.asFilter) {
                                    window[ns].onchange(dateElem);
                                }
                                else {
                                    window[ns].oncalendar_filter(name, _this.dateValue);
                                }
                            });
                        }
                    };
                    this.toggle = function () {
                        _this.hidden = (!_this.hidden && !_this.alwaysOpened);
                        App.render();
                    };
                    this.id = this.input_id + "Calendar";
                    this.hidden = !alwaysOpened;
                    this.hasButtons = !alwaysOpened && !asFilter;
                }
                Object.defineProperty(Calendar.prototype, "dateValue", {
                    get: function () {
                        if (this.isNullDate)
                            return null;
                        return new Date(this.selectedYear, this.selectedMonth - 1, this.selectedDay, this.selectedHour, this.selectedMinute, 0, 0);
                    },
                    enumerable: false,
                    configurable: true
                });
                Object.defineProperty(Calendar.prototype, "year", {
                    get: function () {
                        return this.dateValue.getFullYear();
                    },
                    enumerable: false,
                    configurable: true
                });
                Object.defineProperty(Calendar.prototype, "hasValidYear", {
                    get: function () {
                        if (this.isNullDate)
                            return false;
                        return this.forcedYear == undefined || this.year == this.forcedYear;
                    },
                    enumerable: false,
                    configurable: true
                });
                Object.defineProperty(Calendar.prototype, "min", {
                    set: function (date) {
                        this.minValue = date;
                    },
                    enumerable: false,
                    configurable: true
                });
                Object.defineProperty(Calendar.prototype, "max", {
                    set: function (date) {
                        this.maxValue = date;
                    },
                    enumerable: false,
                    configurable: true
                });
                return Calendar;
            }());
            exports_14("Calendar", Calendar);
            exports_14("eventMan", eventMan = function (ns, dateElem, eventname) {
                var ondatechange = function () {
                    if (!dateElem.getAttribute("required") && dateElem.value.length == 0) {
                        window[ns].onchange(dateElem);
                        return true;
                    }
                    var text = "00000000" + dateElem.value.replace(/\D+/g, "");
                    var dd = text.slice(-2);
                    var mm = text.slice(-4, -2);
                    var yy = text.slice(-8, -4);
                    text = yy + "-" + mm + "-" + dd;
                    dateElem.type = "text";
                    dateElem.value = text;
                    dateElem.setAttribute("value", text);
                    var date = new Date(text);
                    var min = dateElem.dataset.min;
                    var max = dateElem.dataset.max;
                    var outside = ((min != undefined) && date < (new Date(min))) || ((max != undefined) && date > (new Date(max)));
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
            exports_15("onfocusLatLon", onfocusLatLon = function (element) {
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
            exports_15("onchangeLatLon", onchangeLatLon = function (element) {
                if (element.dataset.isddmmcc == "true") {
                    var isLongitude = (element.dataset.islongitude == "true");
                    var text = "0000000" + (+element.value).toFixed(2);
                    var cc = text.slice(-2);
                    var mm = text.slice(-5, -3);
                    var dd = text.slice((isLongitude ? -8 : -7), -5);
                    text = dd + "\u00B0 " + mm + "." + cc + "\u2032";
                    if (text[0] == "0")
                        text = text.slice(1);
                    element.type = "text";
                    element.value = text;
                    element.setAttribute("value", text);
                }
                else {
                    var isLongitude = (element.dataset.islongitude == "true");
                    var text = "0000000" + element.value;
                    var ss = text.slice(-2);
                    var mm = text.slice(-4, -2);
                    var dd = text.slice((isLongitude ? -7 : -6), -4);
                    text = dd + "\u00B0 " + mm + "\u2032 " + ss + "\u2033";
                    if (text[0] == "0")
                        text = text.slice(1);
                    element.type = "text";
                    element.value = text;
                    element.setAttribute("value", text);
                }
            });
            exports_15("onblurLatLon", onblurLatLon = function (element) {
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
            exports_16("renderActionButtons", renderActionButtons = function (ns, isNew, addUrl, buttons, updateOnly) {
                if (buttons === void 0) { buttons = null; }
                if (updateOnly === void 0) { updateOnly = false; }
                var buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("&nbsp;") : "");
                return "\n    <div class=\"level js-actions\">\n        <div class=\"level-left\">\n            <div class=\"level-item\">\n                <div class=\"buttons\">\n                    " + buttonsHtml + "\n                </div>\n            </div>\n        </div>\n        <div class=\"level-right\">\n            <div class=\"level-item\">\n                <div class=\"buttons\">\n                    <button class=\"button is-outlined\" onclick=\"" + ns + ".cancel()\"><!--<span class=\"icon\"><i class=\"fa fa-reply\"></i></span>--><span>" + i18n("Cancel") + "</span></button>\n" + (isNew && !updateOnly ? "\n                    <button class=\"button is-primary is-outlined\" onclick=\"" + ns + ".create()\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><span>" + i18n("Insert") + "</span></button>\n" : "\n" + (!updateOnly ? "\n                    <button class=\"button is-danger is-outlined\" onclick=\"App_Theme.openModal('modalDelete_" + ns + "')\"><span class=\"icon\"><i class=\"fa fa-times\"></i></span><span>" + i18n("Delete") + "</span></button>\n                    <a class=\"button is-primary is-outlined\" href=\"" + addUrl + "\"><span class=\"icon\"><i class=\"fa fa-plus\"></i></span><span>" + i18n("Add New") + "</span></a>\n" : "") + "\n                    <button class=\"button is-primary is-outlined\" onclick=\"" + ns + ".save()\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><span>" + i18n("Update") + "</span></button>\n                    <button class=\"button is-primary is-outlined\" onclick=\"" + ns + ".save(true)\"><span class=\"icon\"><i class=\"fa fa-reply\"></i></span><span>" + i18n("Done") + "</span></button>\n                </div>\n            </div>\n") + "\n        </div>\n    </div>\n";
            });
            exports_16("renderActionButtons2", renderActionButtons2 = function (ns, isNew, addUrl, buttons, canDelete, canAdd) {
                if (buttons === void 0) { buttons = null; }
                if (canDelete === void 0) { canDelete = true; }
                if (canAdd === void 0) { canAdd = true; }
                var buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("") : "");
                return "\n    <div class=\"buttons\">\n        " + buttonsHtml + "\n        <button class=\"button\" onclick=\"" + ns + ".cancel()\"><!--<span class=\"icon\"><i class=\"fa fa-reply\"></i></span>--><span>" + i18n("Cancel") + "</span></button>\n" + (isNew && canAdd ? "\n        <button class=\"button is-primary\" onclick=\"" + ns + ".create()\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><span>" + i18n("Insert") + "</span></button>\n" : "\n        " + (canDelete ? "\n                <button class=\"button is-danger\" onclick=\"App_Theme.openModal('modalDelete_" + ns + "')\"><span class=\"icon\"><i class=\"fa fa-times\"></i></span><span>" + i18n("Delete") + "</span></button>\n        " : "") + "\n        " + (canAdd ? "\n                <a class=\"button is-primary\" href=\"" + addUrl + "\"><span class=\"icon\"><i class=\"fa fa-plus\"></i></span><span>" + i18n("Add New") + "</span></a>\n        " : "") + "\n        <button class=\"button is-primary\" onclick=\"" + ns + ".save()\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><span>" + i18n("Update") + "</span></button>\n        <button class=\"button is-primary\" onclick=\"" + ns + ".save(true)\"><span class=\"icon\"><i class=\"fa fa-reply\"></i></span><span>" + i18n("Done") + "</span></button>\n") + "\n    </div>\n";
            });
            exports_16("renderButtons", renderButtons = function (buttons) {
                var buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("") : "");
                return "\n    <div class=\"buttons\">\n        " + buttonsHtml + "\n    </div>\n";
            });
            exports_16("renderButtonsInline", renderButtonsInline = function (buttons) {
                var buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("") : "");
                return "\n    <div class=\"js-actions js-flex-end\">\n        <div class=\"buttons are-small\">\n            " + buttonsHtml + "\n        </div>\n    </div>\n";
            });
            exports_16("renderInlineActionButtons", renderInlineActionButtons = function (ns, isNew, disableDelete, disableAddNew, disableUpdate) {
                return "\n    <div class=\"js-actions js-flex-end\">\n        <div class=\"buttons are-small\">\n            <button class=\"button is-outlined\" onclick=\"" + ns + ".undo()\"><span class=\"icon\"><i class=\"fa fa-undo\"></i></span><span>" + i18n("Undo") + "</span></button>\n" + (!disableDelete ? "\n            <a class=\"button is-danger is-outlined\" " + (disableDelete ? "disabled" : "onclick=\"" + ns + ".drop()\"") + "><span class=\"icon\"><i class=\"fa fa-times\"></i></span><span>" + i18n("Delete") + "</span></a>\n" : "") + "\n" + (!disableAddNew ? "\n            <a class=\"button is-primary is-outlined\" " + (disableAddNew ? "disabled" : "onclick=\"" + ns + ".addNew()\"") + "><span class=\"icon\"><i class=\"fa fa-plus\"></i></span><span>" + i18n("Add New") + "</span></a>\n" : "") + "\n" + (isNew && !disableUpdate ? "\n            <a class=\"button is-primary is-outlined\" " + (disableUpdate ? "disabled" : "onclick=\"" + ns + ".create()\"") + "><span class=\"icon\"><i class=\"fa fa-check\"></i></span><span>" + i18n("Insert") + "</span></a>\n" : "\n" + (!disableUpdate ? "\n            <a class=\"button is-primary is-outlined\" " + (disableUpdate ? "disabled" : "onclick=\"" + ns + ".save()\"") + "><span class=\"icon\"><i class=\"fa fa-check\"></i></span><span>" + i18n("Update") + "</span></a>\n" : "") + "\n") + "\n        </div>\n    </div>\n";
            });
            exports_16("buttonCancelInline", buttonCancelInline = function (ns) {
                return "<button class=\"button is-outlined\" onclick=\"" + ns + ".undo()\"><span class=\"icon\"><i class=\"fa fa-undo\"></i></span><span>" + i18n("Undo") + "</span></button>";
            });
            exports_16("buttonInsertInline", buttonInsertInline = function (ns) {
                return "<a class=\"button is-primary is-outlined\" onclick=\"" + ns + ".create()><span class=\"icon\"><i class=\"fa fa-check\"></i></span><span>" + i18n("Insert") + "</span></a>";
            });
            exports_16("buttonDeleteInline", buttonDeleteInline = function (ns) {
                return "<a class=\"button is-danger is-outlined\" onclick=\"" + ns + ".drop()\"><span class=\"icon\"><i class=\"fa fa-times\"></i></span><span>" + i18n("Delete") + "</span></a>";
            });
            exports_16("buttonAddNewInline", buttonAddNewInline = function (ns, addUrl) {
                return "<a class=\"button is-primary is-outlined\" onclick=\"" + ns + ".addNew()\"><span class=\"icon\"><i class=\"fa fa-plus\"></i></span><span>" + i18n("Add New") + "</span></a>";
            });
            exports_16("buttonUpdateInline", buttonUpdateInline = function (ns) {
                return "<a class=\"button is-primary is-outlined\" onclick=\"" + ns + ".save()\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><span>" + i18n("Update") + "</span></a>";
            });
            exports_16("renderListActionButtons", renderListActionButtons = function (ns, label, buttons) {
                if (buttons === void 0) { buttons = null; }
                var buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("&nbsp;") : "");
                return "\n    <div class=\"level js-actions\">\n        <div class=\"level-left\">\n            " + buttonsHtml + "\n        </div>\n" + (label != null ? "\n        <div class=\"level-right\">\n            <div class=\"level-item\">\n                <div class=\"buttons\">\n                    <button class=\"button is-primary is-outlined\" onclick=\"" + ns + ".create()\"><span class=\"icon\"><i class=\"fa fa-plus\"></i></span><span>" + label + "</span></button>\n                </div>\n            </div>\n        </div>\n" : "") + "\n    </div>\n    ";
            });
            exports_16("renderListActionButtons2", renderListActionButtons2 = function (ns, label, buttons) {
                if (buttons === void 0) { buttons = null; }
                var buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("&nbsp;") : "");
                return "\n    <div class=\"buttons\">\n        " + buttonsHtml + "\n        " + (label ? "<button class=\"button is-primary\" onclick=\"" + ns + ".create()\"><span class=\"icon\"><i class=\"fa fa-plus\"></i></span><span>" + label + "</span></button>" : "") + "\n    </div>\n";
            });
            exports_16("renderListFloatingActionButtons", renderListFloatingActionButtons = function (ns, label) {
                return "\n        <button class=\"button is-primary is-rounded js-floating\" title=\"" + label + "\" onclick=\"" + ns + ".create()\"><span class=\"icon\"><i class=\"fa fa-plus\"></i></span></button>\n    ";
            });
            exports_16("buttonCancel", buttonCancel = function (ns) {
                return "<button class=\"button\" onclick=\"" + ns + ".cancel()\"><span>" + i18n("Cancel") + "</span></button>";
            });
            exports_16("buttonInsert", buttonInsert = function (ns, label) {
                if (label === void 0) { label = "Insert"; }
                return "<button class=\"button is-primary\" onclick=\"" + ns + ".create()\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><span>" + i18n(label) + "</span></button>";
            });
            exports_16("buttonDelete", buttonDelete = function (ns) {
                return "<button class=\"button is-danger\" onclick=\"App_Theme.openModal('modalDelete_" + ns + "')\"><span class=\"icon\"><i class=\"fa fa-times\"></i></span><span>" + i18n("Delete") + "</span></button>";
            });
            exports_16("buttonAddNew", buttonAddNew = function (ns, addUrl, label) {
                if (label === void 0) { label = null; }
                return "<a class=\"button is-primary\" href=\"" + addUrl + "\"><span class=\"icon\"><i class=\"fa fa-plus\"></i></span><span>" + (label ? label : i18n("Add New")) + "</span></a>";
            });
            exports_16("buttonUpdate", buttonUpdate = function (ns, disabled) {
                if (disabled === void 0) { disabled = false; }
                return "<button class=\"button is-primary\" " + (disabled ? "disabled" : "") + " onclick=\"" + ns + ".save()\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><span>" + i18n("Update") + "</span></button>\n            <button class=\"button is-primary\" " + (disabled ? "disabled" : "") + " onclick=\"" + ns + ".save(true)\"><span class=\"icon\"><i class=\"fa fa-reply\"></i></span><span>" + i18n("Done") + "</span></button>\n";
            });
            exports_16("buttonUpdateNoDone", buttonUpdateNoDone = function (ns, disabled) {
                if (disabled === void 0) { disabled = false; }
                return "<button class=\"button is-primary\" " + (disabled ? "disabled" : "") + " onclick=\"" + ns + ".save()\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><span>" + i18n("Update") + "</span></button>\n";
            });
            exports_16("buttonUpload", buttonUpload = function (ns, disabled, label) {
                if (disabled === void 0) { disabled = false; }
                if (label === void 0) { label = "Upload File"; }
                return "<button class=\"button is-primary\" " + (disabled ? "disabled" : "") + " onclick=\"" + ns + ".create()\"><span class=\"icon\"><i class=\"far fa-cloud-upload-alt\"></i></span><span>" + i18n(label) + "</span></button>";
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
            exports_17("renderCheckboxField", renderCheckboxField = function (ns, propName, value, label, text, help, disabled) {
                if (disabled === void 0) { disabled = false; }
                return "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label\">" + label + "</label></div>\n        <div class=\"field-body\">\n            " + renderCheckboxInline(ns, propName, value, label, (text == undefined ? label : text), help, disabled) + "\n        </div>\n    </div>";
            });
            exports_17("renderCheckboxInline", renderCheckboxInline = function (ns, propName, value, label, text, help, disabled) {
                if (label === void 0) { label = ""; }
                if (text === void 0) { text = ""; }
                if (disabled === void 0) { disabled = false; }
                return "\n    <div class=\"field\">\n        " + rawCheckbox(ns, propName, value, text, disabled) + "\n        " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n    </div>";
            });
            exports_17("renderCheckboxFilter", renderCheckboxFilter = function (ns, propName, value, label, text) {
                if (label === void 0) { label = ""; }
                return "\n    <div class=\"field\">\n        <label class=\"label\">" + label + "</label>\n        <div class=\"field-body\">\n            <label class=\"checkbox\">\n                <input type=\"checkbox\" onchange=\"" + ns + ".filter_" + propName + "(this)\" " + (value ? "checked" : "") + "> " + text + "\n            </label>\n        </div>\n    </div>";
            });
            exports_17("renderCheckboxListField", renderCheckboxListField = function (ns, propName, maskValue, label, list) {
                var checkboxTemplate = function (entry) {
                    var selected = (+entry.code & maskValue) != 0;
                    return "\n        <div>\n            <label class=\"checkbox\">\n                <input type=\"checkbox\" " + (selected ? "checked" : "") + " name=\"" + ns + "_" + propName + "\" onchange=\"" + ns + ".onchange(this)\" data-mask=\"" + entry.code + "\"> " + entry.description + "\n            </label>\n        </div>";
                };
                var checkboxes = list.reduce(function (html, one, index) { return html + checkboxTemplate(one); }, "");
                return "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label\" for=\"" + ns + "_" + propName + "\">" + label + "</label></div>\n        <div class=\"field-body\">\n            <div class=\"field js-checkbox-row\">\n                " + checkboxes + "\n            </div>\n        </div>\n    </div>\n";
            });
            exports_17("rawCheckbox", rawCheckbox = function (ns, propName, value, text, disabled) {
                if (disabled === void 0) { disabled = false; }
                return "\n    <div class=\"control\">\n        <label class=\"checkbox " + (disabled ? "js-disabled" : "") + "\">\n            <input type=\"checkbox\" id=\"" + ns + "_" + propName + "\" onchange=\"" + ns + ".onchange(this)\" " + (value ? "checked" : "") + " " + (disabled ? "disabled" : "") + "> " + text + "\n        </label>\n    </div>";
            });
            exports_17("rawToggle", rawToggle = function (ns, propName, value, text_on, text_off) {
                return "\n<div class=\"js-toggle\">\n    <label for=\"" + ns + "_" + propName + "\">" + (value ? text_on : text_off) + "</label>\n    <input type=\"checkbox\" id=\"" + ns + "_" + propName + "\" onchange=\"" + ns + ".onchange(this)\" " + (value ? "checked" : "") + ">\n</div>\n";
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
            exports_18("renderDropdownField", renderDropdownField = function (ns, propName, options, label, required, size, help, disabled) {
                if (required === void 0) { required = false; }
                if (size === void 0) { size = "js-width-50"; }
                if (disabled === void 0) { disabled = false; }
                return "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label " + (required ? "js-required" : "") + "\" for=\"" + ns + "_" + propName + "\">" + label + "</label></div>\n        <div class=\"field-body\">\n            <div class=\"field\">\n                <div class=\"select " + size + "\">\n                    " + renderDropdownNaked(ns, propName, options, required, disabled) + "\n                </div>\n                " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n            </div>\n        </div>\n    </div>";
            });
            exports_18("renderDropdownInline", renderDropdownInline = function (ns, propName, options, required, disabled) {
                if (required === void 0) { required = false; }
                if (disabled === void 0) { disabled = false; }
                return "\n    <div class=\"field\">\n        <div class=\"select\">\n            <select id=\"" + ns + "_" + propName + "\" \nonchange=\"" + ns + ".onchange(this)\" \n" + (required ? "required='required'" : "") + "\n" + (disabled ? "disabled tabindex='-1'" : "") + ">\n                " + options + "\n            </select>\n        </div>\n    </div>\n";
            });
            exports_18("renderDropdownExInline", renderDropdownExInline = function (ns, propName, text, items, option) {
                return "\n    <div class=\"field\">\n<div class=\"dropdown " + (option.hoverable ? "is-hoverable" : "") + "\" " + (!option.hoverable ? "onclick=\"this.classList.toggle('is-active')\"" : "") + ">\n    <div class=\"dropdown-trigger\">\n        <div aria-controls=\"dropdown-menu-" + propName + "\">\n            <span>" + text + "</span>\n            <span class=\"icon is-small\">\n                <i class=\"fas fa-angle-down\" aria-hidden=\"true\"></i>\n            </span>\n        </div>\n    </div>\n    <div class=\"dropdown-menu\" id=\"dropdown-menu-" + propName + "\" role=\"menu\">\n        <div class=\"dropdown-content\">\n            " + items + "\n        </div>\n    </div>\n</div>\n    </div>\n";
            });
            exports_18("renderDropdownNaked", renderDropdownNaked = function (ns, propName, options, required, disabled) {
                if (required === void 0) { required = false; }
                if (disabled === void 0) { disabled = false; }
                return "\n    <select id=\"" + ns + "_" + propName + "\" onchange=\"" + ns + ".onchange(this)\" " + (required ? "required='required'" : "") + " " + (disabled ? "disabled tabindex='-1'" : "") + ">\n        " + options + "\n    </select>";
            });
            exports_18("renderDropdownFilter", renderDropdownFilter = function (ns, propName, options, label, required, size, help) {
                if (required === void 0) { required = false; }
                if (size === void 0) { size = ""; }
                return "\n    <div class=\"field\">\n        <label class=\"label " + (required ? "js-required" : "") + "\">" + label + "</label>\n        <div class=\"control\">\n            <div class=\"select\">\n                <select onchange=\"" + ns + ".filter_" + propName + "(this)\" " + (required ? "required='required'" : "") + ">\n                    " + options + "\n                </select>\n            </div>\n        </div>\n        " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n    </div>";
            });
            exports_18("renderOptions", renderOptions = function (list, selectedId, hasEmptyOption, emptyText) {
                if (emptyText === void 0) { emptyText = ""; }
                return renderOptionsFun(list, selectedId, hasEmptyOption, emptyText, function (item) { return item.description; });
            });
            exports_18("renderOptionsShowCode", renderOptionsShowCode = function (list, selectedId, hasEmptyOption, emptyText) {
                if (emptyText === void 0) { emptyText = ""; }
                return renderOptionsFun(list, selectedId, hasEmptyOption, emptyText, function (item) { return item.code; });
            });
            exports_18("renderOptionsShowBoth", renderOptionsShowBoth = function (list, selectedId, hasEmptyOption, emptyText) {
                if (emptyText === void 0) { emptyText = ""; }
                return renderOptionsFun(list, selectedId, hasEmptyOption, emptyText, function (item) { return item.code + "     " + item.description; });
            });
            exports_18("renderOptionsFun", renderOptionsFun = function (list, selectedId, hasEmptyOption, emptyText, fun) {
                if (emptyText === void 0) { emptyText = ""; }
                if (hasEmptyOption) {
                    var emptySelected = (selectedId == undefined) || (list.findIndex(function (one) { return one.id == selectedId; }) == -1);
                    return list.reduce(function (html, entry) {
                        var selected = (selectedId != undefined && selectedId == entry.id);
                        return html + ("<option value=\"" + entry.id + "\" " + (selected ? "selected" : "") + ">" + fun(entry) + "</option>");
                    }, "<option value=\"\" " + (emptySelected ? "selected" : "") + ">" + emptyText + "</option>");
                }
                else
                    return list.reduce(function (html, entry, index) {
                        var selected = (selectedId != undefined && selectedId == entry.id);
                        selected = selected || (selectedId == undefined && index == 0);
                        return html + ("<option value=\"" + entry.id + "\" " + (selected ? "selected" : "") + ">" + fun(entry) + "</option>");
                    }, "");
            });
            exports_18("renderItems", renderItems = function (list, selectedId, hasEmptyOption, emptyText) {
                if (emptyText === void 0) { emptyText = ""; }
                if (hasEmptyOption) {
                    var emptySelected = (selectedId == undefined) || (list.findIndex(function (one) { return one.id == selectedId; }) == -1);
                    return list.reduce(function (html, entry) {
                        var selected = (selectedId != undefined && selectedId == entry.id);
                        return html + ("<div data-value=\"" + entry.id + "\" class=\"dropdown-item " + (selected ? "is-active" : "") + "\">" + entry.description + "</div>");
                    }, "<div data-value=\"\" class=\"dropdown-item " + (emptySelected ? "is-active" : "") + "\">" + emptyText + "</div>");
                }
                else
                    return list.reduce(function (html, entry, index) {
                        var selected = (selectedId != undefined && selectedId == entry.id);
                        selected = selected || (selectedId == undefined && index == 0);
                        return html + ("<div data-value=\"" + entry.id + "\" class=\"dropdown-item " + (selected ? "is-active" : "") + "\">" + entry.description + "</div>");
                    }, "");
            });
            exports_18("renderNullableBooleanOptions", renderNullableBooleanOptions = function (value, description) {
                return "\n    <option value=\"\" " + (value == undefined ? "selected" : "") + ">" + description[0] + "</option>\n    <option value=\"true\" " + (value != undefined && value ? "selected" : "") + ">" + description[1] + "</option>\n    <option value=\"false\" " + (value != undefined && !value ? "selected" : "") + ">" + description[2] + "</option>\n    ";
            });
            exports_18("renderNullableBooleanOptionsReverse", renderNullableBooleanOptionsReverse = function (value, description) {
                return "\n    <option value=\"false\" " + (value != undefined && !value ? "selected" : "") + ">" + description[2] + "</option>\n    <option value=\"true\" " + (value != undefined && value ? "selected" : "") + ">" + description[1] + "</option>\n    <option value=\"\" " + (value == undefined ? "selected" : "") + ">" + description[0] + "</option>\n    ";
            });
            exports_18("renderDatalistOptions", renderDatalistOptions = function (list) {
                return list.reduce(function (html, entry) {
                    return html + ("<option value=\"" + entry.description + "\">");
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
            exports_19("rawSelect", rawSelect = function (ns, propName, options, option) {
                return "\n<div class=\"control " + (option.size || "") + "\">\n    <div class=\"select\" style=\"width:100%\">\n        <select id=\"" + ns + "_" + propName + "\" style=\"width:100%\" onchange=\"" + ns + ".onchange(this)\" " + (option.required ? "required='required'" : "") + " " + (option.disabled ? "disabled tabindex='-1'" : "") + ">\n            " + options + "\n        </select>\n    </div>\n</div>";
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
            exports_20("renderRadioField", renderRadioField = function (radios, label, disabled) {
                if (disabled === void 0) { disabled = false; }
                return "\n    <div class=\"field is-horizontal js-radio\">\n        <div class=\"field-label\"><label class=\"label\">" + label + "</label></div>\n        <div class=\"field-body\">\n            <div class=\"control " + (disabled ? "js-disabled" : "") + "\">\n                " + radios + "\n            </div>\n        </div>\n    </div>";
            });
            exports_20("renderRadios", renderRadios = function (ns, propName, list, selectedId, hasEmptyOption, emptyText) {
                if (emptyText === void 0) { emptyText = ""; }
                if (hasEmptyOption) {
                    return list.reduce(function (html, entry) {
                        var checked = (selectedId != undefined && selectedId == entry.id);
                        var disabled = (entry.disabled != undefined && entry.disabled);
                        return html + ("\n            <label class=\"radio " + (disabled ? "js-disabled" : "") + "\">\n                <input type=\"radio\" name=\"" + ns + "_" + propName + "\" data-value=\"" + entry.id + "\" onchange=\"" + ns + ".onchange(this)\" " + (checked ? "checked" : "") + " " + (disabled ? "disabled" : "") + ">\n                " + entry.description + "\n            </label>");
                    }, "<label class=\"radio\">\n                <input type=\"radio\" name=\"" + ns + "_" + propName + "\" data-value=\"\" onchange=\"" + ns + ".onchange(this)\" " + (selectedId == undefined ? "checked" : "") + ">\n                " + emptyText + "\n            </label>");
                }
                else {
                    return list.reduce(function (html, entry, index) {
                        var checked = (selectedId != undefined && selectedId == entry.id);
                        checked = checked || (selectedId == undefined && index == 0);
                        var disabled = (entry.disabled != undefined && entry.disabled);
                        return html + ("\n            <label class=\"radio " + (disabled ? "js-disabled" : "") + "\">\n                <input type=\"radio\" name=\"" + ns + "_" + propName + "\" data-value=\"" + entry.id + "\" onchange=\"" + ns + ".onchange(this)\" " + (checked ? "checked" : "") + " " + (disabled ? "disabled" : "") + ">\n                " + entry.description + "\n            </label>");
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
            exports_21("renderNumberFilter", renderNumberFilter = function (ns, propName, value, label, required, help) {
                if (label === void 0) { label = ""; }
                if (required === void 0) { required = false; }
                return "\n    <div class=\"field\">\n        <label class=\"label " + (required ? "js-required" : "") + "\">" + label + "</label>\n        <div class=\"control\" style=\"width: 100px\">\n            <input type=\"number\" class=\"input\" id=\"" + ns + "_" + propName + "\" value=\"" + Misc.toInputNumber(value) + "\" onchange=\"" + ns + ".filter_" + propName + "(this)\" " + (required ? "required='required'" : "") + ">\n        </div>\n        " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n    </div>";
            });
            exports_21("renderDateFilter", renderDateFilter = function (ns, propName, value, label, required, help, min, max) {
                if (label === void 0) { label = ""; }
                if (required === void 0) { required = false; }
                if (min === void 0) { min = null; }
                if (max === void 0) { max = null; }
                return "\n    <div class=\"field\">\n        <label class=\"label " + (required ? "js-required" : "") + "\">" + label + "</label>\n        <div class=\"control\">\n            <input type=\"date\" class=\"input\"\nid=\"" + ns + "_" + propName + "\" \nvalue=\"" + Misc.toInputDate(value) + "\" \nonchange=\"" + ns + ".filter_" + propName + "(this)\" \n" + (required ? "required='required'" : "") + "\n" + (min ? "min=\"" + Misc.toInputDate(min) + "\"" : "") + "\n" + (max ? "max=\"" + Misc.toInputDate(max) + "\"" : "") + "\n" + (required ? "required='required'" : "") + ">\n        </div>\n        " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n    </div>";
            });
            exports_21("renderDateChanger", renderDateChanger = function (ns, propName, disabled) {
                if (disabled === void 0) { disabled = false; }
                return "\n<div class=\"field\" style=\"margin-left: -0.75rem;\">\n    <label class=\"label\">&nbsp;</label>\n    <div class=\"buttons has-addons\">\n        <button class=\"button\" " + (disabled ? "disabled" : "") + " onclick=\"" + ns + ".filter_" + propName + "(this, 'previous')\"><i class=\"fas fa-angle-left\"></i></button>\n        <button class=\"button\" " + (disabled ? "disabled" : "") + " onclick=\"" + ns + ".filter_" + propName + "(this, 'next')\"><i class=\"fas fa-angle-right\"></i></button>\n    </div>\n</div>\n";
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
            exports_22("renderNumberField", renderNumberField = function (ns, propName, value, label, required, size, help) {
                if (required === void 0) { required = false; }
                if (size === void 0) { size = "js-width-10"; }
                return "\n<div class=\"field is-horizontal\">\n    <div class=\"field-label\"><label class=\"label " + (required ? "js-required" : "") + "\" for=\"" + ns + "_" + propName + "\">" + label + "</label></div>\n    <div class=\"field-body\">\n        <div class=\"field\">\n            <div class=\"control " + size + "\">\n                <input type=\"number\" class=\"input has-text-right\"\n                    id=\"" + ns + "_" + propName + "\" \n                    value=\"" + Misc.toInputNumber(value) + "\" \n                    onchange=\"" + ns + ".onchange(this)\" \n                    " + (required ? "required='required'" : "") + ">\n            </div>\n            " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n        </div>\n    </div>\n</div>";
            });
            exports_22("renderNumberInline", renderNumberInline = function (ns, propName, value, required, disabled) {
                if (required === void 0) { required = false; }
                if (disabled === void 0) { disabled = false; }
                return "\n<div class=\"field\">\n    <div class=\"control\">\n        <input type=\"number\" class=\"input has-text-right\"\n            id=\"" + ns + "_" + propName + "\" \n            value=\"" + Misc.toInputNumber(value) + "\" \n            onchange=\"" + ns + ".onchange(this)\" \n            min=\"0\"\n            " + (required ? "required='required'" : "") + "\n            " + (disabled ? "tabindex='-1'" : "") + ">\n    </div>\n</div>";
            });
            exports_22("renderDecimalField", renderDecimalField = function (ns, propName, value, label, option) {
                return "\n<div class=\"field is-horizontal\">\n    <div class=\"field-label\"><label class=\"label " + (option.required ? "js-required" : "") + "\" for=\"" + ns + "_" + propName + "\">" + label + "</label></div>\n    <div class=\"field-body\">\n        " + renderDecimalInline(ns, propName, value, option) + "\n    </div>\n</div>";
            });
            exports_22("renderDecimalInline", renderDecimalInline = function (ns, propName, value, option) {
                var hasAddonStatic = (option.addonStatic != undefined);
                var hasAddon = (option.addon != undefined);
                return "\n<div class=\"field\">\n    <div class=\"field " + (hasAddon || hasAddonStatic ? "has-addons" : "") + "\" style=\"margin-bottom:0;\">\n        <div class=\"control " + (option.size ? option.size : "") + "\">\n            <input type=\"text\" class=\"input has-text-right\"\n                id=\"" + ns + "_" + propName + "\" \n                value=\"" + Misc.toStaticNumberDecimal(value, option.places, true) + "\" \n                onchange=\"" + ns + ".onchange(this)\" \n                " + (option.required ? "required='required'" : "") + "\n                " + (option.disabled ? "disabled tabindex='-1'" : "") + "\n                " + (option.places ? "pattern=\"^" + (option.allowNegative ? "(-)?" : "") + "[0-9]+(\\.[0-9]{0," + option.places + "})?$\"" : "") + "\n                " + (option.autoselect ? "onfocus=\"this.select()\"" : "") + " >\n        </div>\n" + (hasAddonStatic ? "\n        <div class=\"control\">\n            <a class=\"button js-static\">\n                " + option.addonStatic + "\n            </a>\n        </div>\n" : "") + "\n" + (hasAddon ? "\n        <div class=\"control\">\n            " + option.addon + "\n        </div>\n" : "") + "\n    </div>\n    " + (option.help != undefined ? "<p class=\"help\">" + option.help + "</p>" : "") + "\n</div>";
            });
            exports_22("renderNumberField2", renderNumberField2 = function (ns, propName, value, label, option) {
                return "\n<div class=\"field is-horizontal\">\n    <div class=\"field-label\"><label class=\"label " + (option.required ? "js-required" : "") + "\" for=\"" + ns + "_" + propName + "\">" + label + "</label></div>\n    <div class=\"field-body\">\n        " + renderNumberInline2(ns, propName, value, option) + "\n    </div>\n</div>";
            });
            exports_22("renderNumberInline2", renderNumberInline2 = function (ns, propName, value, option) {
                var hasAddonStatic = (option.addonStatic != undefined);
                var hasAddon = (option.addon != undefined);
                return "\n<div class=\"field\">\n    <div class=\"field " + (hasAddon || hasAddonStatic ? "has-addons" : "") + "\" style=\"margin-bottom:0;\">\n        <div class=\"control " + (option.size ? option.size : "") + "\">\n            <input type=\"number\" class=\"input has-text-right\"\n                id=\"" + ns + "_" + propName + "\" \n                value=\"" + Misc.toInputNumber(value) + "\"\n                onchange=\"" + ns + ".onchange(this)\"\n                " + (option.required ? "required='required'" : "") + "\n                " + (option.min != undefined ? "min=" + option.min : "") + "\n                " + (option.max != undefined ? "max=" + option.max : "") + "\n                " + (option.step ? "step=" + option.step : "") + "\n                " + (option.disabled ? "disabled tabindex='-1'" : "") + ">\n        </div>\n" + (hasAddonStatic ? "\n        <div class=\"control\">\n            <a class=\"button js-static\">\n                " + option.addonStatic + "\n            </a>\n        </div>\n" : "") + "\n" + (hasAddon ? "\n        <div class=\"control\">\n            " + option.addon + "\n        </div>\n" : "") + "\n    </div>\n    " + (option.help != undefined ? "<p class=\"help\">" + option.help + "</p>" : "") + "\n</div>";
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
            exports_23("renderDDMMCC", renderDDMMCC = function (ns, isDDMMCC) {
                return "\n<div class=\"field is-horizontal\">\n    <div class=\"field-label\">\n        <label class=\"label\">&nbsp;</label>\n    </div>\n    <div class=\"field-body\">\n        <div class=\"field\">\n            <div class=\"control\">\n                <label class=\"checkbox\">\n                    <input type=\"checkbox\" onchange=\"" + ns + ".onDDMMCC(this)\" " + (isDDMMCC ? "checked" : "") + "> Enter latitude and longitude using <b>DD MM.CC</b> instead of <b>DD MM SS</b>\n                </label>\n            </div>\n        </div>\n    </div>\n</div>\n";
            });
            exports_23("renderLatField", renderLatField = function (ns, propName, value, label, required, size, help, isDDMMCC) {
                if (required === void 0) { required = false; }
                if (size === void 0) { size = ""; }
                if (isDDMMCC === void 0) { isDDMMCC = false; }
                return "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label " + (required ? "js-required" : "") + "\" for=\"" + ns + "_" + propName + "\">" + label + "</label></div>\n        <div class=\"field-body\">\n            " + renderLatLongInline(ns, propName, value, required, size, help, false, isDDMMCC) + "\n        </div>\n    </div>";
            });
            exports_23("renderLongField", renderLongField = function (ns, propName, value, label, required, size, help, isDDMMCC) {
                if (required === void 0) { required = false; }
                if (size === void 0) { size = ""; }
                if (isDDMMCC === void 0) { isDDMMCC = false; }
                return "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label " + (required ? "js-required" : "") + "\" for=\"" + ns + "_" + propName + "\">" + label + "</label></div>\n        <div class=\"field-body\">\n            " + renderLatLongInline(ns, propName, value, required, size, help, true, isDDMMCC) + "\n        </div>\n    </div>";
            });
            exports_23("renderLatLongInline", renderLatLongInline = function (ns, propName, value, required, size, help, isLongitude, isDDMMCC) {
                if (required === void 0) { required = false; }
                if (size === void 0) { size = ""; }
                if (isLongitude === void 0) { isLongitude = false; }
                if (isDDMMCC === void 0) { isDDMMCC = false; }
                return "\n    <div class=\"field has-addons\">\n        <div class=\"control " + size + "\">\n            <input type=\"text\" class=\"input js-no-spinner\"\n                id=\"" + ns + "_" + propName + "\" \n                data-islongitude=\"" + isLongitude + "\"\n                data-isddmmcc=\"" + (isDDMMCC ? "true" : "false") + "\"\n                value=\"" + (isDDMMCC ? Misc.toInputLatLongDDMMCC(value) : Misc.toInputLatLong(value)) + "\" \n                onfocus=\"" + latlong_1.NS + ".onfocusLatLon(this)\"\n                onchange=\"" + latlong_1.NS + ".onchangeLatLon(this); " + ns + ".onchange(this);\"\n                onblur=\"" + latlong_1.NS + ".onblurLatLon(this)\"\n                " + (required ? "required='required'" : "") + "\n                autocomplete=\"off\">\n        </div>\n" + (isDDMMCC ? "\n        <div class=\"control\">\n            <a class=\"button js-static\">" + Misc.toInputLatLong(value) + "</a>\n        </div>\n" : "") + "\n        " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n    </div>\n";
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
            exports_24("renderTextField", renderTextField = function (ns, propName, value, label, maxlength, required, size, help) {
                if (required === void 0) { required = false; }
                if (size === void 0) { size = ""; }
                return "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label " + (required ? "js-required" : "") + "\" for=\"" + ns + "_" + propName + "\">" + label + "</label></div>\n        <div class=\"field-body\">\n            " + renderTextInline(ns, propName, value, maxlength, required, size, help) + "\n        </div>\n    </div>";
            });
            exports_24("renderTextField2", renderTextField2 = function (ns, propName, value, label, maxlength, option) {
                return "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label " + (option.required ? "js-required" : "") + "\" for=\"" + ns + "_" + propName + "\">" + label + "</label></div>\n        <div class=\"field-body\">\n            " + renderTextInline2(ns, propName, value, maxlength, option) + "\n        </div>\n    </div>";
            });
            exports_24("renderTextInline", renderTextInline = function (ns, propName, value, maxlength, required, size, help, datalist) {
                if (required === void 0) { required = false; }
                if (size === void 0) { size = ""; }
                return "\n    <div class=\"field\">\n        <div class=\"control " + size + "\">\n            <input type=\"text\" class=\"input\" id=\"" + ns + "_" + propName + "\" value=\"" + Misc.toInputText(value) + "\" onchange=\"" + ns + ".onchange(this)\" " + (maxlength != undefined ? "maxlength=\"" + maxlength + "\"" : "") + " " + (required ? "required='required'" : "") + " " + (datalist ? "list=\"" + datalist + "\"" : "") + ">\n        </div>\n        " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n    </div>";
            });
            exports_24("renderTextInline2", renderTextInline2 = function (ns, propName, value, maxlength, option) {
                var hasAddonStatic = (option.addonStatic != undefined);
                var hasAddon = (option.addon != undefined);
                var hasAddonHead = (option.addonHead != undefined);
                return "\n    <div class=\"field\">\n    <div class=\"field " + (hasAddon || hasAddonStatic || hasAddonHead ? "has-addons" : "") + "\" style=\"margin-bottom:0;\">\n" + (hasAddonHead ? "\n        <p class=\"control\">\n            " + option.addonHead + "\n        </p>\n" : "") + "\n        <div class=\"control " + (option.size != undefined ? option.size : "") + "\">\n            <input type=\"text\" class=\"input\" id=\"" + ns + "_" + propName + "\" value=\"" + Misc.toInputText(value) + "\" \n                onchange=\"" + ns + ".onchange(this)\"\n                " + (maxlength != undefined ? "maxlength=\"" + maxlength + "\"" : "") + "\n                " + (option.required ? "required='required'" : "") + "\n                " + (option.noautocomplete ? "autocomplete='off'" : "") + "\n                " + (option.disabled ? "disabled" : "") + "\n                " + (option.listid ? "list=\"" + option.listid + "\"" : "") + ">\n        </div>\n" + (hasAddonStatic ? "\n        <div class=\"control\">\n            <a class=\"button js-static\" " + (option.addonHref != undefined ? "href=\"" + option.addonHref + "\"" : "") + ">\n                " + option.addonStatic + "\n            </a>\n        </div>\n" : "") + "\n" + (hasAddon ? "\n        <div class=\"control\">\n            " + option.addon + "\n        </div>\n" : "") + "\n    </div>\n    " + (option.help != undefined ? "<p class=\"help\">" + option.help + "</p>" : "") + "\n    </div>";
            });
            exports_24("renderTextareaField", renderTextareaField = function (ns, propName, value, label, maxlength, required, help, rows) {
                if (maxlength === void 0) { maxlength = 0; }
                if (required === void 0) { required = false; }
                if (rows === void 0) { rows = 2; }
                return "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label " + (required ? "js-required" : "") + "\" for=\"" + ns + "_" + propName + "\">" + label + "</label></div>\n        <div class=\"field-body\">\n            " + renderTextareaInline(ns, propName, value, maxlength, required, help, rows) + "\n        </div>\n    </div>";
            });
            exports_24("renderTextareaField_V", renderTextareaField_V = function (ns, propName, value, label, maxlength, required, help, rows, event) {
                if (maxlength === void 0) { maxlength = 0; }
                if (required === void 0) { required = false; }
                if (rows === void 0) { rows = 2; }
                if (event === void 0) { event = "onchange"; }
                return "\n    <div class=\"field\">\n        <label class=\"label " + (required ? "js-required" : "") + "\" for=\"" + ns + "_" + propName + "\">" + label + "</label>\n        <div class=\"control\">\n            <textarea class=\"textarea\" rows=\"" + rows + "\" spellcheck=\"false\" id=\"" + ns + "_" + propName + "\" " + event + "=\"" + ns + "." + event + "(this, event)\" maxlength=\"" + maxlength + "\" " + (required ? "required='required'" : "") + ">" + Misc.toInputText(value) + "</textarea>\n        </div>\n        " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n    </div>";
            });
            exports_24("renderTextareaInline", renderTextareaInline = function (ns, propName, value, maxlength, required, help, rows) {
                if (maxlength === void 0) { maxlength = 0; }
                if (required === void 0) { required = false; }
                if (rows === void 0) { rows = 2; }
                return "\n    <div class=\"field\">\n        <div class=\"control\">\n            <textarea class=\"textarea\" rows=\"" + rows + "\" spellcheck=\"false\" id=\"" + ns + "_" + propName + "\" onchange=\"" + ns + ".onchange(this)\" " + (maxlength > 0 ? "maxlength=\"" + maxlength + "\"" : "") + " " + (required ? "required='required'" : "") + ">" + Misc.toInputText(value) + "</textarea>\n        </div>\n        " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n    </div>";
            });
            exports_24("renderTextareaFieldWithMarkdown", renderTextareaFieldWithMarkdown = function (ns, propName, value, label, maxlength, required, help, rows, showHtml) {
                if (maxlength === void 0) { maxlength = 0; }
                if (required === void 0) { required = false; }
                if (rows === void 0) { rows = 2; }
                if (showHtml === void 0) { showHtml = false; }
                return "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label " + (required ? "js-required" : "") + "\" for=\"" + ns + "_" + propName + "\">" + label + "</label></div>\n        <div class=\"field-body\">\n            <div class=\"field\">\n                <div class=\"js-wrap-markdown\" style=\"background-color: yellow; position: relative;\">\n                    <div class=\"control\">\n                        <textarea class=\"textarea\" rows=\"" + rows + "\" spellcheck=\"false\" id=\"" + ns + "_" + propName + "\" onchange=\"" + ns + ".onchange(this)\" " + (maxlength > 0 ? "maxlength=\"" + maxlength + "\"" : "") + " " + (required ? "required='required'" : "") + ">" + Misc.toInputText(value) + "</textarea>\n                    </div>\n                    <div style=\"position:absolute; top:0; left:0; width:100%; height:100%; overflow:auto; padding:0 8px; background-color:white; border: 1px solid #e7eaec; " + (!showHtml ? "display:none;" : "") + "\">\n                        " + marked(value || "") + "\n                    </div>\n                </div>\n                " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n            </div>\n        </div>\n    </div>";
            });
            exports_24("rawText", rawText = function (ns, propName, value, option) {
                return "\n<input type=\"text\" class=\"input " + (option.size || "") + " " + (option.class || "") + "\" " + (option.style ? "style=\"" + option.style + "\"" : "") + " id=\"" + ns + "_" + propName + "\" value=\"" + Misc.toInputText(value) + "\" onchange=\"" + ns + ".onchange(this)\" " + (option.max != undefined ? "maxlength=\"" + option.max + "\"" : "") + " " + (option.required ? "required='required'" : "") + ">\n";
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
            exports_25("renderDateInline", renderDateInline = function (ns, propName, value, option) {
                return "\n    <div class=\"field\">\n        <div class=\"control\">\n            <input type=\"date\" class=\"input\"\nid=\"" + ns + "_" + propName + "\" \nvalue=\"" + Misc.toInputDate(value) + "\" \n" + (option.min ? "min=\"" + option.min + "\"" : "") + "\n" + (option.max ? "max=\"" + option.max + "\"" : "") + "\nonchange=\"" + ns + ".onchange(this)\" \n" + (option.required ? "required='required'" : "") + "\n" + (option.disabled ? "tabindex='-1' style='pointer-events:none'" : "") + ">\n        </div>\n    </div>";
            });
            renderDateField = function (ns, propName, value, label, option) {
                return "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label " + (option.required ? "js-required" : "") + "\" for=\"" + ns + "_" + propName + "\">" + label + "</label></div>\n        <div class=\"field-body\">\n            <div class=\"field\">\n                <!--<div class=\"field has-addons\">-->\n                <div class=\"field\">\n                    <div class=\"control " + (option.size ? option.size : "js-width-20") + "\">\n                        <input type=\"date\" class=\"input\" \n                            id=\"" + ns + "_" + propName + "\" \n                            value=\"" + Misc.toInputDate(value) + "\" \n                            onchange=\"" + ns + ".onchange(this)\" \n                            " + (option.required ? "required='required'" : "") + ">\n                    </div>\n<!--\n                    <div class=\"control\">\n                        <a class=\"button\">\n                            <i class=\"far fa-calendar-alt\"></i>\n                        </a>\n                    </div>\n-->\n                </div>\n                " + (option.help ? "<p class=\"help\">" + option.help + "</p>" : "") + "\n            </div>\n        </div>\n    </div>";
            };
            renderDateTimeField = function (ns, propName, value, label, option) {
                return "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label " + (option.required ? "js-required" : "") + "\" for=\"" + ns + "_" + propName + "\">" + label + "</label></div>\n        <div class=\"field-body\">\n            <div class=\"field\">\n                <div class=\"field\">\n                    <div class=\"control\" style=\"display: inline-block;\">\n                        <input type=\"date\" class=\"input\" \n                            id=\"" + ns + "_" + propName + "\" \n                            value=\"" + Misc.toInputDate(value) + "\" \n                            " + (option.min ? "min=\"" + option.min + "\"" : "") + "\n                            " + (option.max ? "max=\"" + option.max + "\"" : "") + "\n                            onchange=\"" + ns + ".onchange(this)\" \n                            " + (option.required ? "required='required'" : "") + ">\n                    </div>\n                    <div class=\"control\" style=\"display: inline-block;\">\n                        <input type=\"time\" class=\"input\"\n                            id=\"" + ns + "_" + propName + "_time\" \n                            value=\"" + Misc.toInputTimeHHMM(value) + "\" \n                            onchange=\"" + ns + ".onchange(this)\" \n                            " + (option.required ? "required='required'" : "") + ">\n                    </div>\n                </div>\n                " + (option.help ? "<p class=\"help\">" + option.help + "</p>" : "") + "\n            </div>\n        </div>\n    </div>";
            };
            exports_25("renderDateExInline", renderDateExInline = function (ns, propName, value, option) {
                return "\n    <div class=\"field\">\n        <div class=\"control\" style=\"width: 90px;\">\n            <input type=\"text\" class=\"input js-no-spinner\" \nid=\"" + ns + "_" + propName + "\" \nvalue=\"" + Misc.toInputDate(value) + "\" \n" + (option.min ? "min=\"" + option.min + "\"" : "") + "\n" + (option.max ? "max=\"" + option.max + "\"" : "") + "\nonfocus=\"" + ns + ".ondate(this, 'focus')\" onchange=\"" + ns + ".ondate(this, 'change')\" onblur=\"" + ns + ".ondate(this, 'blur')\" \nautocomplete=\"off\"\n" + (option.required ? "required='required'" : "") + "\n" + (option.disabled ? "tabindex='-1' style='pointer-events:none'" : "") + ">\n        </div>\n    </div>";
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
            exports_26("renderCalendarField", renderCalendarField = function (ns, propName, calendar, label, option) {
                if (option === void 0) { option = {}; }
                var input_id = ns + "_" + propName;
                return "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label " + (calendar.required ? "js-required" : "") + "\" for=\"" + input_id + "\">" + label + "</label></div>\n        <div class=\"field-body\">\n            " + renderCalendarInline(ns, propName, calendar, option) + "\n        </div>\n    </div>";
            });
            exports_26("renderCalendarFilter", renderCalendarFilter = function (ns, propName, calendar, label, option) {
                if (option === void 0) { option = {}; }
                return "\n    <div class=\"field\">\n        <label class=\"label " + (option.required ? "js-required" : "") + "\">" + label + "</label>\n" + renderCalendarInline(ns, propName, calendar, option) + "\n    </div>";
            });
            exports_26("renderCalendarInline", renderCalendarInline = function (ns, propName, calendar, option) {
                var input_id = ns + "_" + propName;
                return "\n    <div id=\"" + input_id + "_wrapper\" class=\"field-body\">\n    <div class=\"field\">\n        <div class=\"js-calendar\">\n            " + calendar.render() + "\n        </div>\n        <div class=\"field has-addons\">\n            <div class=\"control\" style=\"width: 90px;\">\n                <input type=\"text\" class=\"input js-no-spinner\" \n                    id=\"" + input_id + "\" \n                    value=\"" + Misc.toInputDate(calendar.dateValue) + "\" \n                    " + (calendar.minValue ? "data-min=\"" + Misc.toInputDate(calendar.minValue) + "\"" : "") + "\n                    " + (calendar.maxValue ? "data-max=\"" + Misc.toInputDate(calendar.maxValue) + "\"" : "") + "\n                    autocomplete=\"off\"\n                    " + (calendar.required ? "required=\"required\"" : "") + " \n                    " + (calendar.disableDate ? "disabled" : "") + ">\n            </div>\n\n" + (calendar.hasTime ? "\n            <div class=\"control\" style=\"width: 60px;\">\n                <input type=\"text\" class=\"input js-no-spinner\"\n                    id=\"" + input_id + "_time\" \n                    value=\"" + Misc.toInputTimeHHMM(calendar.dateValue) + "\" \n                    autocomplete=\"off\"\n                    " + (calendar.required ? "required='required'" : "") + "\n                    " + (calendar.isNullDate ? "disabled" : "") + " >\n            </div>\n" : "") + "\n\n" + (!calendar.required && !calendar.disableDate ? "\n            <div class=\"control\">\n                <button id=\"" + input_id + "_clear\" class=\"button\"><i class=\"far fa-times\"></i></button>\n            </div>\n" : "") + "\n\n" + (!calendar.disableDate ? "\n            <div class=\"control\">\n                <a id=\"" + input_id + "_popup\" class=\"button\"><i class=\"far fa-calendar-alt\"></i></a>\n            </div>\n" : "") + "\n\n" + (calendar.hasChanger ? "\n            <div class=\"control\">\n                <button id=\"" + input_id + "_previous\" class=\"button\" " + (calendar.isNullDate ? "disabled" : "") + ">\n                    <i class=\"fas fa-angle-left\"></i>" + (option.changerCaption ? "&nbsp;Previous Day" : "") + "\n                </button>\n            </div>\n            <div class=\"control\">\n                <button id=\"" + input_id + "_next\" class=\"button\" " + (calendar.isNullDate ? "disabled" : "") + ">\n                    <i class=\"fas fa-angle-right\"></i>" + (option.changerCaption ? "&nbsp;Next Day" : "") + "\n                </button>\n            </div>\n" : "") + "\n\n        </div>\n        " + (option.help ? "<p class=\"help\">" + option.help + "</p>" : "") + "\n    </div>\n    </div>";
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
            exports_27("renderStaticField", renderStaticField = function (value, label, help, required) {
                if (required === void 0) { required = false; }
                return "\n    <div class=\"field is-horizontal js-field-static\">\n        <div class=\"field-label\"><label class=\"label " + (required ? "js-required" : "") + "\">" + label + "</label></div>\n        <div class=\"field-body\">\n            <div style=\"width: 100%; height: 2.534em; padding-top: 6px;\">\n                " + Misc.toInputText(value) + "\n                " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n            </div>\n        </div>\n    </div>";
            });
            exports_27("renderStaticField2", renderStaticField2 = function (value, label, option) {
                return "\n<div class=\"field is-horizontal js-field-static\">\n    <div class=\"field-label\"><label class=\"label\">" + label + "</label></div>\n    <div class=\"field-body\">\n        " + renderStaticInline2(value, option) + "\n    </div>\n</div>";
            });
            exports_27("renderStaticHtmlField", renderStaticHtmlField = function (value, label, help) {
                return "\n    <div class=\"field is-horizontal js-field-static\">\n        <div class=\"field-label\"><label class=\"label\">" + label + "</label></div>\n        <div class=\"field-body\">\n            <div style=\"width: 100%; padding-top: 6px;\">\n                " + (value == undefined ? "" : value) + "\n                " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n            </div>\n        </div>\n    </div>";
            });
            exports_27("renderStaticField_V", renderStaticField_V = function (value, label, help, extraStyle) {
                if (extraStyle === void 0) { extraStyle = ""; }
                return "\n    <div class=\"field\">\n        <label class=\"label\">" + label + "</label>\n        <div class=\"control\" style=\"" + extraStyle + "\">" + Misc.toInputText(value) + "</div>\n        " + (help != undefined ? "<p class=\"help\">" + help + "</p>" : "") + "\n    </div>";
            });
            exports_27("renderStaticInline", renderStaticInline = function (value) {
                return "\n    <div class=\"field\">\n        <div class=\"field-body\"><span>" + value + "</span></div>\n    </div>";
            });
            exports_27("renderStaticInline2", renderStaticInline2 = function (value, option) {
                var hasAddonStatic = (option.addonStatic != undefined);
                var hasAddon = (option.addon != undefined);
                return "\n<div class=\"field\" " + (!hasAddon && !hasAddonStatic ? "style=\"padding-bottom: 6px;\"" : "") + ">\n    <div class=\"field " + (hasAddon || hasAddonStatic ? "has-addons" : "") + "\">\n        <div class=\"control\">\n            <div class=\"field-body\"><span style=\"margin-right: 8px;\">" + value + "</span></div>\n        </div>\n" + (hasAddonStatic ? "\n        <div class=\"control\">\n            <a class=\"button js-static\">\n                " + option.addonStatic + "\n            </a>\n        </div>\n" : "") + "\n" + (hasAddon ? "\n        <div class=\"control\">\n            " + option.addon + "\n        </div>\n" : "") + "\n    </div>\n    " + (option.help != undefined ? "<p class=\"help\">" + option.help + "</p>" : "") + "\n</div>";
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
            exports_28("renderButtonWithConfirm", renderButtonWithConfirm = function (title, icon, items, onclick, disabled, active, hoverable, ontoggle, valid) {
                if (disabled === void 0) { disabled = false; }
                if (active === void 0) { active = false; }
                if (hoverable === void 0) { hoverable = false; }
                if (ontoggle === void 0) { ontoggle = null; }
                if (valid === void 0) { valid = true; }
                var uid = new Date().getTime();
                var tag = (disabled ? "p" : "a");
                var itemsHtml = "";
                if (typeof items === "string")
                    itemsHtml = "<div class=\"dropdown-item\">" + items + "</div>";
                else
                    itemsHtml = items.reduce(function (html, item) { return html + ("<div class=\"dropdown-item\">" + item + "</div>"); }, "");
                return "\n<div class=\"dropdown " + (active ? "is-active" : "") + " " + (hoverable ? "is-hoverable" : "") + "\">\n    <div class=\"dropdown-trigger\" onclick=\"" + (ontoggle != undefined ? ontoggle : "App_Theme.toggleActive(this)") + "\">\n      <button class=\"button\" aria-haspopup=\"true\" aria-controls=\"dropdown-" + uid + "\" " + (disabled ? "disabled" : "") + ">\n        " + (icon != undefined ? "<span class=\"icon\"><i class=\"" + icon + "\"></i></span>" : "") + "\n        <span>" + title + "</span>\n      </button>\n    </div>\n    <div class=\"dropdown-menu\" id=\"dropdown-" + uid + "\" role=\"menu\">\n      <div class=\"dropdown-content\">\n        " + itemsHtml + "\n        <hr class=\"dropdown-divider\">\n" + (valid ? "\n        <" + tag + " href=\"#\" class=\"dropdown-item\" onclick=\"" + onclick + ";return false;\">\n          <span class=\"icon\"><i class=\"fa fa-check\"></i></span> " + i18n("Yes, do that") + "\n        </" + tag + ">\n" : "\n        <p href=\"#\" class=\"dropdown-item\" style=\"opacity:0.5\">\n          <span class=\"icon\"><i class=\"fa fa-check\"></i></span> " + i18n("Yes, do that") + "\n        </p>\n") + "\n      </div>\n    </div>\n</div>";
            });
            exports_28("renderButtonWithConfirmChoices", renderButtonWithConfirmChoices = function (title, icon, helpText, choices, disabled) {
                if (disabled === void 0) { disabled = false; }
                var uid = new Date().getTime();
                var tag = (disabled ? "p" : "a");
                var choiceTemplate = function (item) {
                    return "\n            <" + tag + " href=\"#\" class=\"dropdown-item\" onclick=\"" + item.onclick + ";return false;\">\n                <span class=\"icon\"><i class=\"" + (item.icon != undefined ? item.icon : "far fa-arrow-circle-right") + "\"></i></span> " + item.text + "\n            </" + tag + ">";
                };
                var lines = choices.reduce(function (html, item) { return html + choiceTemplate(item); }, "");
                return "\n<div class=\"dropdown is-up\" onclick=\"App_Theme.toggleActive(this)\">\n    <div class=\"dropdown-trigger\">\n      <button class=\"button\" aria-haspopup=\"true\" aria-controls=\"dropdown-" + uid + "\" " + (disabled ? "disabled" : "") + ">\n        " + (icon != undefined ? "<span class=\"icon\"><i class=\"" + icon + "\"></i></span>" : "") + "\n        <span>" + title + "</span>\n      </button>\n    </div>\n    <div class=\"dropdown-menu\" id=\"dropdown-" + uid + "\" role=\"menu\">\n      <div class=\"dropdown-content\">\n        <div class=\"dropdown-item\">\n            " + helpText + "\n        </div>\n        <hr class=\"dropdown-divider\">\n        " + lines + "\n      </div>\n    </div>\n</div>";
            });
            exports_28("renderButton", renderButton = function (title, icon, onclick, disabled) {
                if (disabled === void 0) { disabled = false; }
                return "\n<button class=\"button\" onclick=\"" + onclick + "\" " + (disabled ? "disabled" : "") + ">\n    <span class=\"icon\"><i class=\"" + icon + "\"></i></span>\n    <span>" + title + "</span>\n</button>";
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
            exports_29("renderModalDelete", renderModalDelete = function (id, onclick) {
                return "\n<div class=\"modal js-modal-delete\" id=\"" + id + "\" js-skip-render-class=\"is-active\">\n    <div class=\"modal-background\" onclick=\"App_Theme.closeModal(this);\"></div>\n    <div class=\"modal-card\">\n<div>\n        <header class=\"modal-card-head\">\n            <p class=\"modal-card-title\">" + i18n("Confirm Delete") + "</p>\n            <button class=\"delete\" onclick=\"App_Theme.closeModal(this);\"></button>\n        </header>\n        <section class=\"modal-card-body\">\n            <div class=\"level\">\n                <div class=\"level-item has-text-centered\">\n                    <div>\n                        <p class=\"heading has-text-weight-bold\">" + i18n("Are you sure you want to delete this item?") + "</p>\n                        <p class=\"heading\">" + i18n("This operation cannot be undone.") + "</p>\n                    </div>\n                </div>\n            </div>\n        </section>\n        <footer class=\"modal-card-foot\">\n            <button class=\"button\" onclick=\"App_Theme.closeModal(this);\">\n                <span>" + i18n("CANCEL") + "</span>\n            </button>\n            <button class=\"button is-danger\" onclick=\"App_Theme.closeModal(this);" + onclick + "\">\n                <span class=\"icon\"><i class=\"fa fa-times\"></i></span> <span>" + i18n("Yes, Delete") + "</span>\n            </button>\n        </footer>\n</div>\n    </div>\n</div>";
            });
            exports_29("openModal", openModal = function (id) {
                document.getElementById(id).classList.add("is-active");
            });
            exports_29("closeModal", closeModal = function (element) {
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
            exports_30("toggleActive", toggleActive = function (element) {
                element.classList.toggle("is-active");
            });
            exports_30("wrapContent", wrapContent = function (contentClass, html) {
                if (html != undefined && html.length > 0)
                    return "<div class=\"content " + contentClass + "\">" + html + "</div>";
                return "";
            });
            exports_30("warningTemplate", warningTemplate = function (errorMessages) {
                return errorMessages.reduce(function (text, error) { return text +
                    ("<div class=\"notification is-danger\">\n        <i class=\"fa fa-exclamation-triangle\"></i>&nbsp;" + error + "\n    </div>"); }, "");
            });
            exports_30("fatalErrorTemplate403", fatalErrorTemplate403 = function () {
                return "\n    <div class=\"notification is-danger\">\n        <h3><i class=\"fas fa-skull-crossbones\"></i>&nbsp;" + i18n("Unauthorized") + "</h3>\n        " + i18n("You don't have the required permission for this operation") + "\n    </div>";
            });
            exports_30("fatalErrorTemplate404", fatalErrorTemplate404 = function () {
                return "\n    <div class=\"notification is-danger\">\n        <h3><i class=\"fas fa-skull-crossbones\"></i>&nbsp;" + i18n("Failed to fetch page data") + "</h3>\n        " + i18n("You don't have the required permission for this operation") + "\n    </div>";
            });
            exports_30("dirtyTemplate", dirtyTemplate = function (ns, details) {
                if (details === void 0) { details = null; }
                return "\n    <div class=\"notification is-warning\">\n        <i class=\"fa fa-exclamation-triangle\"></i>\n        <div style=\"display:inline-table;\">You have changes that are not saved. Click Update to save your changes or " + (ns != undefined ? "<a onclick=\"" + ns + ".cancel(); return false;\">continue</a> without saving" : "Cancel") + ".\n        " + (details != undefined ? "<br>" + details : "") + "</div>\n    </div>";
            });
            exports_30("unexpectedTemplate", unexpectedTemplate = function () {
                return "<div class=\"notification is-danger\">\n        <i class=\"fa fa-exclamation-triangle\"></i>&nbsp;UNEXPECTED ERROR\n    </div>";
            });
            exports_30("inConstruction", inConstruction = function (text) {
                if (text === void 0) { text = "In Construction"; }
                return "\n    <div class=\"notification is-size-4 has-text-centered\">\n        <span class=\"icon\"><i class=\"fas fa-wrench\"></i></span> " + text + "\n    </div>\n    ";
            });
            exports_30("onburger", onburger = function (element) {
                var target = document.getElementById(element.dataset.target);
                element.classList.toggle("is-active");
                target.classList.toggle("is-active");
            });
            exports_30("renderBlame", renderBlame = function (obj, isNew) {
                if (isNew || obj == undefined || obj.updated == undefined || obj.by == undefined)
                    return "";
                return "\n    <div class=\"has-text-right js-blame\">\n        <span>Last updated on " + Misc.toStaticDateTime(obj.updated) + (obj.by ? " by " + obj.by : "") + "</span>\n    </div>\n";
            });
            exports_30("renderFileUpload", renderFileUpload = function (ns, propName, label, accept, isBusy) {
                if (accept === void 0) { accept = "image/*"; }
                if (isBusy === void 0) { isBusy = false; }
                if (!isBusy)
                    return "\n<div class=\"level-item\">\n    <div class=\"file\">\n        <label class=\"file-label\">\n            <input class=\"file-input\" type=\"file\" id=\"" + ns + "_" + propName + "\" name=\"" + ns + "_" + propName + "\" accept=\"" + accept + "\" onchange=\"" + ns + ".fileUpload(this)\">\n            <span class=\"file-cta\">\n                <span class=\"file-icon\">\n                    <i class=\"fas fa-upload\"></i>\n                </span>\n                <span class=\"file-label\">\n                    " + label + "\u2026\n                </span>\n            </span>\n        </label>\n    </div>\n</div>\n    ";
                return "\n<div class=\"level-item\">\n    <a class=\"button is-loading\">Upoading</a>\n</div>\n    ";
            });
            exports_30("renderStyleForFixedWidthTable", renderStyleForFixedWidthTable = function (id, widths) {
                var table_width = widths.reduce(function (sum, width) { return sum + width; }, 0);
                var thead = widths.reduce(function (html, width, index) {
                    return html + ("#" + id + " thead th:nth-child(" + (index + 1) + ") { width: " + width + "px; min-width: " + width + "px; }");
                }, "");
                var tbody = widths.reduce(function (html, width, index) {
                    return html + ("#" + id + " tbody td:nth-child(" + (index + 1) + ") { width: " + width + "px; min-width: " + width + "px; }");
                }, "");
                return "\n<style>\n    #" + id + " table { width: " + table_width + "px; }\n    " + thead + "\n    " + tbody + "\n</style>\n";
            });
            exports_30("renderStyleForScrollableTable", renderStyleForScrollableTable = function (id, rows, widths) {
                var table_width = widths.reduce(function (sum, width) { return sum + width; }, 0);
                var table_th_height = 32;
                var scrollbar_width = 16 + 4;
                var scrollbar_height = 16;
                var height = 32 * (rows + 1);
                var thead = widths.reduce(function (html, width, index) {
                    return html + ("#" + id + " thead th:nth-child(" + (index + 1) + ") { min-width: " + (width + (index == widths.length - 1 ? scrollbar_width : 0)) + "px; }");
                }, "");
                var tbody = widths.reduce(function (html, width, index) {
                    return html + ("#" + id + " tbody td:nth-child(" + (index + 1) + ") { width: " + width + "px; min-width: " + width + "px; }");
                }, "");
                return "\n<style>\n    #" + id + " { overflow: hidden; }\n    #" + id + " table thead { display: block; }\n    #" + id + " table tbody { display: block; overflow: auto; scroll-behavior: smooth; }\n\n    #" + id + " { height: " + (height + scrollbar_height) + "px; }\n    #" + id + " table { width: " + (table_width + scrollbar_width) + "px; }\n    #" + id + " tbody { height: " + (height - table_th_height) + "px; }\n\n    " + thead + "\n    " + tbody + "\n</style>\n";
            });
            exports_30("wrapFieldset", wrapFieldset = function (legend, content, actions) {
                if (actions === void 0) { actions = null; }
                var id = legend.split(" ").join("");
                return "\n<fieldset id=\"" + id + "\">\n    <legend class=\"js-legend\"><span>" + legend + "</span>" + (actions ? "<div>" + actions + "</div>" : "") + "</legend>\n    " + content + "\n</fieldset>\n";
            });
            exports_30("float_menu_button", float_menu_button = function (title, id) {
                return "<button class=\"button is-text\" onclick=\"" + NS + ".scrollTo('" + (id || title) + "')\">" + title + "</button>";
            });
            exports_30("scrollTo", scrollTo = function (anchor) {
                var id = anchor.replace(/ /g, "");
                var fieldset = document.getElementById(id);
                //
                fieldset.scrollIntoView();
                setTimeout(function () { window.scrollBy(0, -180); }, 10);
            });
            exports_30("field", field = function (label, controls, required, cssclass) {
                if (required === void 0) { required = false; }
                var html;
                if (typeof controls === "string")
                    html = "<div class=\"field\">" + controls + "</div>";
                else
                    html = "<div class=\"field js-addons\">" + controls.reduce(function (html, one) { return html + one; }, "") + "</div>";
                return "\n<div class=\"field is-horizontal " + (cssclass || "") + "\">\n    <div class=\"field-label\"><label class=\"label " + (required ? "js-required" : "") + "\">" + label + "</label></div>\n    <div class=\"field-body\">\n        " + html + "\n    </div>\n</div>";
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
            exports_31("renderAutocompleteField", renderAutocompleteField = function (ns, propName, autocomplete, label, option) {
                var input_id = ns + "_" + propName;
                return "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label " + (option.required ? "js-required" : "") + "\" for=\"" + input_id + "\">" + label + "</label></div>\n        <div class=\"field-body\">\n            " + renderAutocompleteInline(ns, propName, autocomplete, option) + "\n        </div>\n    </div>";
            });
            exports_31("renderAutocompleteInline", renderAutocompleteInline = function (ns, propName, autocomplete, option) {
                var hasAddonStatic = (option.addonStatic != undefined);
                var hasAddon = (option.addon != undefined);
                var hasAddonHead = (option.addonHead != undefined);
                var input_id = ns + "_" + propName;
                return "\n    <div class=\"field\">\n    <div class=\"field js-autocomplete\" id=\"" + autocomplete.id + "\">\n        <div class=\"dropdown " + (autocomplete.isActive ? "is-active" : "") + " " + (option.size ? option.size : "js-width-25") + "\">\n            <div class=\"control has-icons-right\">\n                <input type=\"text\" class=\"input\"\n                    id=\"" + input_id + "\" \n                    data-key=\"" + autocomplete.keyValue + "\"\n                    value=\"" + Misc.toStaticText(autocomplete.textValue) + "\" \n                    onfocus=\"" + autocomplete.handle('onfocus') + "\"\n                    onkeydown=\"" + autocomplete.handle('onkeydown') + "\"\n                    onblur=\"" + autocomplete.handle('onblur') + "\"\n                    " + (autocomplete.required ? "required='required'" : "") + "\n                    " + (autocomplete.disabled ? "disabled" : "") + "\n                    autocomplete=\"off\">\n                    \n                <span class=\"icon is-small is-right\">\n                    <i class=\"fas fa-search\"></i>\n                </span>\n            </div>\n            " + autocomplete.render() + "\n        </div>\n" + (hasAddonStatic ? "\n        <div class=\"control\" style=\"display:inline-block\">\n            <a class=\"button js-static\" " + (option.addonHref != undefined ? "href=\"" + option.addonHref + "\"" : "") + ">\n                " + option.addonStatic + "\n            </a>\n        </div>\n" : "") + "\n" + (hasAddon ? "\n        <div class=\"control\" style=\"display:inline-block\">\n            " + option.addon + "\n        </div>\n" : "") + "\n    </div>\n    " + (option.help != undefined ? "<p class=\"help\">" + option.help + "</p>" : "") + "\n    </div>";
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
System.register("src/permission", ["_BaseApp/src/auth"], function (exports_33, context_33) {
    "use strict";
    var Auth, ROLE_SUPPORT, isSupport, hasPermission, canDoThis, canDoThat, Feature, feature, assignFeature;
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
            }
        ],
        execute: function () {
            ROLE_SUPPORT = 1;
            isSupport = function () { return (Auth.getRoles().indexOf(ROLE_SUPPORT) != -1); };
            hasPermission = function (permid) { return (Auth.getPermissions().indexOf(permid) != -1) || isSupport(); };
            // Block 100
            exports_33("canDoThis", canDoThis = function () { return hasPermission(101); });
            exports_33("canDoThat", canDoThat = function () { return hasPermission(102); });
            Feature = /** @class */ (function () {
                function Feature() {
                    this.feat = {};
                }
                Feature.prototype.assignFeature = function (feature) { this.feat = feature; };
                Object.defineProperty(Feature.prototype, "private107", {
                    get: function () { var _a; return (_a = this.feat.private107) !== null && _a !== void 0 ? _a : []; },
                    enumerable: false,
                    configurable: true
                });
                Object.defineProperty(Feature.prototype, "private208", {
                    get: function () { var _a; return (_a = this.feat.private208) !== null && _a !== void 0 ? _a : []; },
                    enumerable: false,
                    configurable: true
                });
                Object.defineProperty(Feature.prototype, "private110", {
                    get: function () { var _a; return (_a = this.feat.private110) !== null && _a !== void 0 ? _a : []; },
                    enumerable: false,
                    configurable: true
                });
                return Feature;
            }());
            feature = new Feature();
            exports_33("assignFeature", assignFeature = function (newFeature) { return feature.assignFeature(newFeature); });
        }
    };
});
System.register("src/admin/lookupdata", ["_BaseApp/src/core/app", "_BaseApp/src/admin/lookupdata"], function (exports_34, context_34) {
    "use strict";
    var App, yearFilter, dateFilter, sortOrderKeys, fetch_sortOrderKeys, get_sortOrderKeys, pays, fetch_pays, get_pays, institutionBanquaire, fetch_institutionBanquaire, get_institutionBanquaire, compte, fetch_compte, get_compte, autreFournisseur, fetch_autreFournisseur, get_autreFournisseur, lot, fetch_lot, get_lot, canton, fetch_canton, get_canton, municipalite, fetch_municipalite, get_municipalite, proprietaire, fetch_proprietaire, get_proprietaire, contingent, fetch_contingent, get_contingent, droit_coupe, fetch_droit_coupe, get_droit_coupe, entente_paiement, fetch_entente_paiement, get_entente_paiement, zone, fetch_zone, get_zone;
    var __moduleName = context_34 && context_34.id;
    return {
        setters: [
            function (App_7) {
                App = App_7;
            },
            function (lookupdata_1_1) {
                exports_34({
                    "fetch_authrole": lookupdata_1_1["fetch_authrole"],
                    "authrole": lookupdata_1_1["authrole"]
                });
            }
        ],
        execute: function () {
            yearFilter = function (one, year) { return year >= one.started && (one.ended == undefined || year <= one.ended); };
            dateFilter = function (one, date) { return date >= one.started && (one.ended == undefined || date <= one.ended); };
            exports_34("fetch_sortOrderKeys", fetch_sortOrderKeys = function () {
                return function (data) {
                    var fill = function (id, description) {
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
            exports_34("get_sortOrderKeys", get_sortOrderKeys = function (year) { return sortOrderKeys; });
            exports_34("fetch_pays", fetch_pays = function () {
                return function (data) {
                    if (pays != undefined && pays.length > 0)
                        return;
                    return App.GET("/lookup/by/pays").then(function (json) { pays = json; });
                };
            });
            exports_34("get_pays", get_pays = function (year) { return pays; });
            exports_34("fetch_institutionBanquaire", fetch_institutionBanquaire = function () {
                return function (data) {
                    if (institutionBanquaire != undefined && institutionBanquaire.length > 0)
                        return;
                    return App.GET("/lookup/by/institutionBanquaire").then(function (json) { institutionBanquaire = json; });
                };
            });
            exports_34("get_institutionBanquaire", get_institutionBanquaire = function (year) { return institutionBanquaire; });
            exports_34("fetch_compte", fetch_compte = function () {
                return function (data) {
                    if (compte != undefined && compte.length > 0)
                        return;
                    return App.GET("/lookup/by/compte").then(function (json) { compte = json; });
                };
            });
            exports_34("get_compte", get_compte = function (year) { return compte; });
            exports_34("fetch_autreFournisseur", fetch_autreFournisseur = function () {
                return function (data) {
                    if (autreFournisseur != undefined && autreFournisseur.length > 0)
                        return;
                    return App.GET("/lookup/by/autreFournisseur").then(function (json) { autreFournisseur = json; });
                };
            });
            exports_34("get_autreFournisseur", get_autreFournisseur = function (year) { return autreFournisseur; });
            exports_34("fetch_lot", fetch_lot = function () {
                return function (data) {
                    if (lot != undefined && lot.length > 0)
                        return;
                    return App.GET("/lookup/by/lot").then(function (json) { lot = json; });
                };
            });
            exports_34("get_lot", get_lot = function (year) { return lot; });
            exports_34("fetch_canton", fetch_canton = function () {
                return function (data) {
                    if (canton != undefined && canton.length > 0)
                        return;
                    return App.GET("/lookup/by/canton").then(function (json) { canton = json; });
                };
            });
            exports_34("get_canton", get_canton = function (year) { return canton; });
            exports_34("fetch_municipalite", fetch_municipalite = function () {
                return function (data) {
                    if (municipalite != undefined && municipalite.length > 0)
                        return;
                    return App.GET("/lookup/by/municipalite").then(function (json) { municipalite = json; });
                };
            });
            exports_34("get_municipalite", get_municipalite = function (year) { return municipalite; });
            exports_34("fetch_proprietaire", fetch_proprietaire = function () {
                return function (data) {
                    if (proprietaire != undefined && proprietaire.length > 0)
                        return;
                    return App.GET("/lookup/by/proprietaire").then(function (json) { proprietaire = json; });
                };
            });
            exports_34("get_proprietaire", get_proprietaire = function (year) { return proprietaire; });
            exports_34("fetch_contingent", fetch_contingent = function () {
                return function (data) {
                    if (contingent != undefined && contingent.length > 0)
                        return;
                    return App.GET("/lookup/by/contingent").then(function (json) { contingent = json; });
                };
            });
            exports_34("get_contingent", get_contingent = function (year) { return contingent; });
            exports_34("fetch_droit_coupe", fetch_droit_coupe = function () {
                return function (data) {
                    if (droit_coupe != undefined && droit_coupe.length > 0)
                        return;
                    return App.GET("/lookup/by/droit_coupe").then(function (json) { droit_coupe = json; });
                };
            });
            exports_34("get_droit_coupe", get_droit_coupe = function (year) { return droit_coupe; });
            exports_34("fetch_entente_paiement", fetch_entente_paiement = function () {
                return function (data) {
                    if (entente_paiement != undefined && entente_paiement.length > 0)
                        return;
                    return App.GET("/lookup/by/entente_paiement").then(function (json) { entente_paiement = json; });
                };
            });
            exports_34("get_entente_paiement", get_entente_paiement = function (year) { return entente_paiement; });
            exports_34("fetch_zone", fetch_zone = function () {
                return function (data) {
                    if (zone != undefined && zone.length > 0)
                        return;
                    return App.GET("/lookup/by/zone").then(function (json) { zone = json; });
                };
            });
            exports_34("get_zone", get_zone = function (year) { return zone; });
        }
    };
});
System.register("src/home", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/layout"], function (exports_35, context_35) {
    "use strict";
    var App, Router, Layout, NS, menuData, yesterday, today, tomorrow, tomorrow_2, tomorrow_3, tomorrow_4, region, getMenuData, clearMenuData, renderDropdown, menuTemplate, pageTemplate, fetchState, fetch, render, postRender, getFormState, onchange, loadToolsState, saveToolsState;
    var __moduleName = context_35 && context_35.id;
    return {
        setters: [
            function (App_8) {
                App = App_8;
            },
            function (Router_4) {
                Router = Router_4;
            },
            function (Layout_1) {
                Layout = Layout_1;
            }
        ],
        execute: function () {
            exports_35("NS", NS = "App_Home");
            exports_35("getMenuData", getMenuData = function () {
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
            });
            exports_35("clearMenuData", clearMenuData = function () {
                menuData = null;
            });
            exports_35("renderDropdown", renderDropdown = function (propName, options) {
                return "\n    <div class=\"select is-small\">\n        <select id=\"" + NS + "_" + propName + "\" onchange=\"" + NS + ".onchange(this)\">\n            " + options + "\n        </select>\n    </div>";
            });
            menuTemplate = function (menuItems) {
                var linkTemplate = function (link) {
                    if (link.hidden)
                        return "";
                    var liClasses = (link.classes ? "class=\"" + link.classes + "\"" : "");
                    if (link.markup)
                        return "<li " + liClasses + ">" + link.markup + "</li>";
                    var isDisabled = (link.href == undefined && link.onclick == undefined);
                    var href = (link.href || "#");
                    var isExternal = href.startsWith("http") || link.isExternal;
                    return "<li " + liClasses + "><a href=\"" + href + "\" " + (isDisabled ? "class=\"js-disabled\"" : "") + " " + (isExternal ? "target=\"_new\"" : "") + " " + (link.onclick ? "onclick=\"" + link.onclick + "\"" : "") + ">" + link.name + "</a></li>";
                };
                var sectionTemplate = function (section, listColumnClass) {
                    if (section.hidden)
                        return "";
                    var reduceSection = function () {
                        var links = section.links.filter(function (one) { return one.canView == undefined || one.canView; });
                        var maxrows = (section.maxrows == undefined ? 32 : section.maxrows);
                        var html = "";
                        for (var ix = 0; ix < links.length; ix++) {
                            var ixe = ix % maxrows;
                            if (ixe == 0)
                                html += "<ul>";
                            html += linkTemplate(links[ix]);
                            if (ixe == (maxrows - 1) || ix == links.length - 1)
                                html += "</ul>";
                        }
                        return html;
                    };
                    var skipOpenDiv = (section.merge != undefined && section.merge == "end");
                    var skipCloseDiv = (section.merge != undefined && section.merge == "start");
                    return "\n        " + (!skipOpenDiv ? "<div class=\"column " + (section.maxrows == undefined ? listColumnClass : "") + "\">" : "") + "\n            " + (section.name ? "<h3><i class=\"" + section.icon + "\"></i> " + section.name + "</h3>" : "") + "\n            <div class=\"js-links\">" + reduceSection() + "</div>\n        " + (!skipCloseDiv ? "</div>" : "") + "\n";
                };
                var menuItemTemplate = function (menuItem) {
                    return "\n<div class=\"column " + menuItem.columnClass + "\">\n    <div class=\"box\">\n        <div class=\"js-widget\">\n            <div class=\"tile\">\n                <i class=\"" + menuItem.icon + " fa-4x\"></i>\n                <div>" + menuItem.name + "</div>\n            </div>\n            <div class=\"columns is-mobile is-multiline\">\n                " + menuItem.sections.filter(function (one) { return one.canView == undefined || one.canView; }).reduce(function (html, item) { return html + sectionTemplate(item, menuItem.listColumnClass); }, "") + "\n            </div>\n        </div>\n    </div>\n</div>\n";
                };
                return menuItems.filter(function (one) { return one.canView; }).reduce(function (html, item) { return html + menuItemTemplate(item); }, "");
            };
            pageTemplate = function (menu) {
                return "\n<form onsubmit=\"return false;\">\n<input type=\"submit\" style=\"display:none;\" id=\"" + NS + "_dummy_submit\">\n    <div style=\"padding:1rem;\">\n        <div class=\"columns is-multiline\">\n            " + menu + "\n        </div>\n    </div>\n</form>\n";
            };
            fetchState = function () {
                return Promise
                    .resolve();
                //.then(Lookup.fetch_tools())
                //.then(() => { saveToolsState(Lookup.get_tools(Perm.getCurrentYear())) })
            };
            exports_35("fetch", fetch = function () {
                App.setRenderDomain(Layout);
                App.prepareRender(NS, "HOME");
                Router.registerDirtyExit(null);
                fetchState()
                    .then(App.render)
                    .catch(App.render);
            });
            exports_35("render", render = function () {
                if (!App.inContext(NS))
                    return "";
                //
                // Build page
                //
                var menu = menuTemplate(getMenuData());
                return pageTemplate(menu);
            });
            exports_35("postRender", postRender = function () {
                if (!App.inContext(NS))
                    return "";
            });
            getFormState = function () {
            };
            exports_35("onchange", onchange = function (input) {
                //state = getFormState();
                App.render();
            });
            loadToolsState = function () {
                return JSON.parse(localStorage.getItem("tools-state"));
            };
            saveToolsState = function (uiTools) {
                localStorage.setItem("tools-state", JSON.stringify(uiTools));
            };
        }
    };
});
System.register("src/admin/layout", ["_BaseApp/src/core/app", "src/layout"], function (exports_36, context_36) {
    "use strict";
    var App, layout_1, icon, prepareMenu, tabTemplate, buildTitle, buildSubtitle;
    var __moduleName = context_36 && context_36.id;
    return {
        setters: [
            function (App_9) {
                App = App_9;
            },
            function (layout_1_1) {
                layout_1 = layout_1_1;
            }
        ],
        execute: function () {
            exports_36("icon", icon = "far fa-user");
            exports_36("prepareMenu", prepareMenu = function () {
                layout_1.setOpenedMenu("Administration-Management");
            });
            exports_36("tabTemplate", tabTemplate = function (id, xtra, isNew) {
                if (isNew === void 0) { isNew = false; }
                var isAccounts = App.inContext("App_accounts");
                var isAccount = App.inContext("App_account");
                var isFiles = window.location.hash.startsWith("#/files/account");
                var isFile = window.location.hash.startsWith("#/file/account");
                var showDetail = !isAccounts;
                var showFiles = showDetail && xtra;
                var showFile = isFile;
                return "\n<div class=\"tabs is-boxed\">\n    <ul>\n        <li " + (isAccounts ? "class='is-active'" : "") + ">\n            <a href=\"#/admin/accounts\">\n                <span class=\"icon\"><i class=\"fas fa-list-ol\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("List") + "</span>\n            </a>\n        </li>\n" + (showDetail ? "\n        <li " + (isAccount ? "class='is-active'" : "") + ">\n            <a href=\"#/admin/account/" + id + "\">\n                <span class=\"icon\"><i class=\"" + icon + "\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("Account Details") + "</span>\n            </a>\n        </li>\n" : "") + "\n" + (showFiles ? "\n        <li " + (isFiles ? "class='is-active'" : "") + ">\n            <a href=\"#/files/account/" + id + "\">\n                <span class=\"icon\"><i class=\"far fa-paperclip\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("Files") + " (" + xtra.fileCount + ")</span>\n            </a>\n        </li>\n" : "") + "\n" + (showFile ? "\n        <li " + (isFile ? "class='is-active'" : "") + ">\n            <a href=\"#/file/account/" + id + "\">\n                <span class=\"icon\"><i class=\"far fa-paperclip\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("File Details") + "</span>\n            </a>\n        </li>\n" : "") + "\n\n    </ul>\n</div>\n";
            });
            exports_36("buildTitle", buildTitle = function (xtra, defaultText) {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.title) !== null && _a !== void 0 ? _a : defaultText;
            });
            exports_36("buildSubtitle", buildSubtitle = function (xtra, defaultText) {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.subtitle) !== null && _a !== void 0 ? _a : defaultText;
            });
        }
    };
});
// File: accounts.ts
System.register("src/admin/accounts", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/layout"], function (exports_37, context_37) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, layout_2, NS, key, state, uiSelectedRow, autoArchiveButton, filterTemplate, trTemplate, tableTemplate, pageTemplate, fetchState, fetch, refresh, render, postRender, inContext, setSelectedRow, isSelectedRow, goto, sortBy, search, filter_archive, filter_readyToArchive, gotoDetail, create, autoArchive;
    var __moduleName = context_37 && context_37.id;
    return {
        setters: [
            function (App_10) {
                App = App_10;
            },
            function (Router_5) {
                Router = Router_5;
            },
            function (Perm_1) {
                Perm = Perm_1;
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
                pager: { pageNo: 1, pageSize: 20, sortColumn: "EMAIL", sortDirection: "ASC", filter: { archive: undefined, readyToArchive: undefined } }
            };
            autoArchiveButton = function () {
                var title = i18n("Auto Archive");
                var helpText = i18n("<p><b>Note:</b> This will archive all records having the <b><em>Ready to Archive</em></b> flag set.</p>");
                var onclick = NS + ".autoArchive()";
                return Theme.renderButtonWithConfirm(title, "far fa-lock-open-alt", helpText, onclick, false, false, true);
            };
            filterTemplate = function (archive, readyToArchive) {
                var filters = [];
                filters.push(Theme.renderDropdownFilter(NS, "archive", archive, i18n("ARCHIVE")));
                filters.push(Theme.renderDropdownFilter(NS, "readyToArchive", readyToArchive, i18n("READYTOARCHIVE")));
                return filters.join("");
            };
            trTemplate = function (item, rowNumber) {
                return "\n<tr class=\"" + (isSelectedRow(item.uid) ? "is-selected" : "") + "\" onclick=\"" + NS + ".gotoDetail(" + item.uid + ");\">\n    <td class=\"js-index\">" + rowNumber + "</td>\n    <td>" + Misc.toStaticText(item.email) + "</td>\n    <td>" + Misc.toStaticText(item.firstName) + "</td>\n    <td>" + Misc.toStaticText(item.lastName) + "</td>\n    <td>" + Misc.toStaticText(item.roleLUID_Text) + "</td>\n    <td>" + Misc.toStaticDateTime(item.lastActivity) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.readyToArchive) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.archive) + "</td>\n</tr>";
            };
            tableTemplate = function (tbody, pager) {
                return "\n<div class=\"table-container\">\n<table class=\"table is-hoverable is-fullwidth\">\n    <thead>\n        <tr>\n            <th></th>\n            " + Pager.sortableHeaderLink(pager, NS, i18n("EMAIL"), "email", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FIRSTNAME"), "firstName", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("LASTNAME"), "lastName", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ROLEMASK"), "roleLUID_Text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("LASTACTIVITY"), "lastActivity", "DESC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("READYTOARCHIVE"), "readyToArchive", "DESC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ARCHIVE"), "archive", "ASC") + "\n        </tr>\n    </thead>\n    <tbody>\n        " + tbody + "\n    </tbody>\n</table>\n</div>\n";
            };
            pageTemplate = function (pager, table, tab, warning, dirty) {
                var readonly = false;
                var buttons = [];
                buttons.push(autoArchiveButton());
                return "\n<form onsubmit=\"return false;\">\n<input type=\"submit\" style=\"display:none;\" id=\"" + NS + "_dummy_submit\">\n\n<div class=\"js-fixed-heading\">\n<div class=\"js-head\">\n    <div class=\"content js-uc-heading js-flex-space\">\n        <div>\n            <div class=\"title\"><i class=\"" + layout_2.icon + "\"></i> " + i18n("All accounts") + "</div>\n            <div class=\"subtitle\">" + i18n("List of accounts") + "</div>\n        </div>\n        <div>\n            " + Theme.wrapContent("js-uc-actions", Theme.renderListActionButtons2(NS, i18n("Add New"), buttons)) + "\n        </div>\n    </div>\n    " + Theme.wrapContent("js-uc-tabs", tab) + "\n</div>\n<div class=\"js-body\">\n    " + Theme.wrapContent("js-uc-notification", dirty) + "\n    " + Theme.wrapContent("js-uc-notification", warning) + "\n    " + Theme.wrapContent("js-uc-pager", pager) + "\n    " + Theme.wrapContent("js-uc-list", table) + "\n</div>\n</div>\n\n</form>\n";
            };
            exports_37("fetchState", fetchState = function (id) {
                Router.registerDirtyExit(null);
                return App.GET("/account/search/?" + Pager.asParams(state.pager))
                    .then(function (payload) {
                    state = payload;
                    key = {};
                });
            });
            exports_37("fetch", fetch = function (params) {
                var id = +params[0];
                App.prepareRender(NS, i18n("accounts"));
                layout_2.prepareMenu();
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            refresh = function () {
                App.prepareRender(NS, i18n("accounts"));
                App.GET("/account/search/?" + Pager.asParams(state.pager))
                    .then(function (payload) {
                    state = payload;
                })
                    .then(App.render)
                    .catch(App.render);
            };
            exports_37("render", render = function () {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
                    return App.warningTemplate() || App.unexpectedTemplate();
                var warning = App.warningTemplate();
                var dirty = "";
                var tbody = state.list.reduce(function (html, item, index) {
                    var rowNumber = Pager.rowNumber(state.pager, index);
                    return html + trTemplate(item, rowNumber);
                }, "");
                var year = Perm.getCurrentYear();
                var archive = Theme.renderNullableBooleanOptionsReverse(state.pager.filter.archive, ["All", i18n("Archived"), i18n("Active")]);
                var readyToArchive = Theme.renderNullableBooleanOptions(state.pager.filter.readyToArchive, ["All", i18n("Ready"), i18n("Not Ready")]);
                var filter = filterTemplate(archive, readyToArchive);
                var search = Pager.searchTemplate(state.pager, NS);
                var pager = Pager.render(state.pager, NS, [20, 50], search, filter);
                var table = tableTemplate(tbody, state.pager);
                var tab = layout_2.tabTemplate(null, null);
                return pageTemplate(pager, table, tab, dirty, warning);
            });
            exports_37("postRender", postRender = function () {
                if (!inContext())
                    return;
            });
            exports_37("inContext", inContext = function () {
                return App.inContext(NS);
            });
            setSelectedRow = function (uid) {
                if (uiSelectedRow == undefined)
                    uiSelectedRow = { uid: uid };
                uiSelectedRow.uid = uid;
            };
            isSelectedRow = function (uid) {
                if (uiSelectedRow == undefined)
                    return false;
                return (uiSelectedRow.uid == uid);
            };
            exports_37("goto", goto = function (pageNo, pageSize) {
                state.pager.pageNo = pageNo;
                state.pager.pageSize = pageSize;
                refresh();
            });
            exports_37("sortBy", sortBy = function (columnName, direction) {
                state.pager.pageNo = 1;
                state.pager.sortColumn = columnName;
                state.pager.sortDirection = direction;
                refresh();
            });
            exports_37("search", search = function (element) {
                state.pager.searchText = element.value;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_37("filter_archive", filter_archive = function (element) {
                var value = element.options[element.selectedIndex].value;
                var archive = (value.length > 0 ? value == "true" : undefined);
                if (archive == state.pager.filter.archive)
                    return;
                state.pager.filter.archive = archive;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_37("filter_readyToArchive", filter_readyToArchive = function (element) {
                var value = element.options[element.selectedIndex].value;
                var readyToArchive = (value.length > 0 ? value == "true" : undefined);
                if (readyToArchive == state.pager.filter.readyToArchive)
                    return;
                state.pager.filter.readyToArchive = readyToArchive;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_37("gotoDetail", gotoDetail = function (cid) {
                setSelectedRow(cid);
                Router.goto("#/admin/account/" + cid);
            });
            exports_37("create", create = function () {
                Router.goto("#/admin/account/new");
            });
            exports_37("autoArchive", autoArchive = function () {
                App.POST("/account/auto-archive", null)
                    .then(function (_) {
                    Misc.toastSuccess(i18n("Auto Archive Executed"));
                    Router.goto("#/admin/accounts", 10);
                })
                    .catch(App.render);
            });
        }
    };
});
// File: account.ts
System.register("src/admin/account", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/auth", "src/admin/lookupdata", "src/admin/layout"], function (exports_38, context_38) {
    "use strict";
    var App, Router, Misc, Theme, Auth, Lookup, layout_3, NS, blackList, key, state, fetchedState, isNew, isDirty, emailSubject, emailBody, block_account, block_profile, formTemplate, resetPasswordButton, canUpdate, pageTemplate, dirtyTemplate, clearState, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, onchange, cancel, create, save, drop, resetPassword, createInvitation, dirtyExit;
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
            blackList = ["cie_Text", "roleLUID_Text", "resetGuid", "created", "updatedBy", "by", "profileJson", "xtra"];
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            block_account = function (item, roleList) {
                var roleLUID = Theme.renderRadios(NS, "roleLUID", Lookup.authrole, state.roleLUID, false);
                var canCreateFullAccount = true; //Perm.canCreateFullAccount();
                return "\n    <div class=\"columns js-2-columns\">\n    <div class=\"column\">\n    " + (canCreateFullAccount ? Theme.renderCheckboxField(NS, "useRealEmail", item.useRealEmail, i18n("USEREALEMAIL"), i18n("USEREALEMAIL_TEXT"), i18n("USEREALEMAIL_HELP_" + item.useRealEmail)) : "") + "\n\n" + (item.useRealEmail ? "\n    " + Theme.renderTextField2(NS, "email", item.email, i18n("EMAIL"), 50, { required: true, size: "js-width-50" }) + "\n    " + (!isNew ? "\n        <div class=\"field is-horizontal\">\n            <div class=\"field-label\"><label class=\"label\">&nbsp;</label></div>\n            <div class=\"field-body\"><span><a href=\"mailto:" + item.email + "\"><i class=\"far fa-envelope\"></i> " + i18n("SEND EMAIL TO") + " " + item.email + "</a></span></div>\n        </div>\n    " : "") + "\n" : "\n    " + Theme.renderTextField2(NS, "email", item.email, i18n("USERNAME"), 50, { required: true, size: "js-width-50" }) + "\n    " + Theme.renderTextField2(NS, "password", item.password, i18n("PASSWORD"), 50, { required: isNew, size: "js-width-50", help: !isNew ? i18n("PASSWORD_HELP") : undefined, noautocomplete: true }) + "\n") + "\n\n    " + Theme.renderTextField(NS, "firstName", item.firstName, i18n("FIRSTNAME"), 50, true) + "\n    " + Theme.renderTextField(NS, "lastName", item.lastName, i18n("LASTNAME"), 50, true) + "\n\n" + (!isNew ? "\n    " + Theme.renderStaticField(Misc.toStaticDateTime(item.resetExpiry), i18n("RESETEXPIRY")) + "\n    " + Theme.renderStaticField(Misc.toStaticDateTime(item.lastActivity), i18n("LASTACTIVITY")) + "\n    <div class=\"field is-horizontal\">\n        <div class=\"field-label\"><label class=\"label\">&nbsp;</label></div>\n        <div class=\"field-body\">" + resetPasswordButton(item) + "</div>\n    </div>\n" : "") + "\n    </div>\n    <div class=\"column\">\n    " + Theme.renderNumberField(NS, "currentYear", item.currentYear, i18n("CURRENTYEAR"), true, "js-width-25", "User can only enter data for this fire season") + "\n    " + Theme.renderRadioField(roleLUID, i18n("ROLELUID")) + "\n    " + Theme.renderNumberField(NS, "archiveDays", item.archiveDays, i18n("ARCHIVEDAYS"), false, "js-width-25", "Duration in days after which an inactive account is archived") + "\n" + (!isNew ? "\n    " + Theme.renderCheckboxField(NS, "archive", item.archive, i18n("ARCHIVE"), "Disable Account", "User cannot sign-in to OpsFMS when the account is disabled") + "\n" : "") + "\n    </div>\n    </div>\n";
            };
            block_profile = function (profile, sortOrderKeysID) {
                return "\n    <div class=\"columns js-2-columns\">\n    <div class=\"column\">\n    " + Theme.renderTextField(NS, "profile.AcrobatPath", profile.AcrobatPath, "Chemin d'accès à Acrobat Reader", 100, false) + "\n    " + Theme.renderDropdownField(NS, "profile.FactureSortType", sortOrderKeysID, "Ordre de tri des factures (croissant)") + "\n    </div>\n    </div>\n";
            };
            formTemplate = function (item, roleList, sortOrderKeysID) {
                return "\n<div class=\"columns\">\n    <div class=\"column is-8 is-offset-2\">\n        " + Theme.wrapFieldset("Compte", block_account(item, roleList)) + "\n        " + Theme.wrapFieldset("Profile", block_profile(item.profile, sortOrderKeysID)) + "\n    </div>\n</div>\n\n    " + Theme.renderBlame(item, isNew) + "\n";
            };
            resetPasswordButton = function (item) {
                var title;
                var helpText;
                var onclick;
                if (item.canResetPassword) {
                    title = i18n("Reset Password");
                    helpText = i18n("<p><b>Note:</b> This will prevent the user from login until the user re-enters a new password.</p><br><p>An email will be sent to the user with a link to do so.</p>");
                    onclick = NS + ".resetPassword()";
                }
                if (item.canCreateInvitation) {
                    title = i18n("Create Invitation");
                    helpText = i18n("<p>Create an invitation for this user to join OpsFMS.</p><br><p>An email will be sent to the user with a link to do so.</p>");
                    onclick = NS + ".createInvitation()";
                }
                if (item.canExtendInvitation) {
                    title = i18n("Extend Invitation");
                    helpText = i18n("Re-invite this user to OpsFMS because he/she didn't go through the process before the <b>Password Reset Expiry</b>.</p><br><p>An email will be sent to the user with a link to do so.</p>");
                    onclick = NS + ".createInvitation()";
                }
                if (title)
                    return Theme.renderButtonWithConfirm(title, "fas fa-lock", helpText, onclick, false, false, true);
                else
                    return "";
            };
            canUpdate = function () {
                return (isNew || key.uid != 1 || Auth.getRoles().indexOf(1) != -1);
            };
            pageTemplate = function (item, form, tab, warning, dirty) {
                var readonly = !canUpdate();
                var buttons = [];
                return "\n<form onsubmit=\"return false;\" " + (readonly ? "class='js-readonly'" : "") + ">\n<input type=\"submit\" style=\"display:none;\" id=\"" + NS + "_dummy_submit\">\n\n<div class=\"js-fixed-heading\">\n<div class=\"js-head\">\n    <div class=\"content js-uc-heading js-flex-space\">\n        <div>\n            <div class=\"title\"><i class=\"" + layout_3.icon + "\"></i> <span>" + (isNew ? i18n("New Account") : item.xtra && item.xtra.title) + "</span></div>\n            <div class=\"subtitle\">" + (isNew ? i18n("Editing New account") : i18n("Editing account Details")) + "</div>\n        </div>\n        <div>\n            " + Theme.wrapContent("js-uc-actions", Theme.renderActionButtons2(NS, isNew, "#/admin/account/new", buttons)) + "\n            " + Theme.renderBlame(item, isNew) + "\n        </div>\n    </div>\n    " + Theme.wrapContent("js-uc-tabs", tab) + "\n</div>\n<div class=\"js-body\">\n    " + Theme.wrapContent("js-uc-notification", dirty) + "\n    " + Theme.wrapContent("js-uc-notification", warning) + "\n    " + Theme.wrapContent("js-uc-details", form) + "\n</div>\n</div>\n\n" + Theme.renderModalDelete("modalDelete_" + NS, NS + ".drop()") + "\n\n</form>\n";
            };
            dirtyTemplate = function () {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            clearState = function () {
                state = {};
            };
            exports_38("fetchState", fetchState = function (uid) {
                isNew = isNaN(uid);
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                clearState();
                var url = "/account/" + (isNew ? "new" : uid);
                return App.GET(url)
                    .then(function (payload) {
                    state = payload;
                    fetchedState = Misc.clone(state);
                    key = { uid: uid };
                })
                    .then(Lookup.fetch_authrole())
                    .then(Lookup.fetch_sortOrderKeys());
            });
            exports_38("fetch", fetch = function (params) {
                var id = +params[0];
                App.prepareRender(NS, i18n("account"));
                layout_3.prepareMenu();
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_38("render", render = function () {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || Object.keys(state).length == 0)
                    return App.warningTemplate() || App.unexpectedTemplate();
                var year = state.currentYear;
                var lookup_sortOrderKeys = Lookup.get_sortOrderKeys(year);
                var sortOrderKeysID = Theme.renderOptions(lookup_sortOrderKeys, state.profile.FactureSortType, false);
                var form = formTemplate(state, Lookup.authrole, sortOrderKeysID);
                emailBody = undefined;
                var tab = layout_3.tabTemplate(state.uid, state.xtra);
                var dirty = dirtyTemplate();
                var warning = App.warningTemplate();
                return pageTemplate(state, form, tab, warning, dirty);
            });
            exports_38("postRender", postRender = function () {
                if (!inContext())
                    return;
                App.setPageTitle(isNew ? i18n("New account") : state.xtra.title);
            });
            exports_38("inContext", inContext = function () {
                return App.inContext(NS);
            });
            getFormState = function () {
                var clone = Misc.clone(state);
                clone.useRealEmail = Misc.fromInputCheckbox(NS + "_useRealEmail", state.useRealEmail);
                clone.email = Misc.fromInputText(NS + "_email", state.email);
                clone.password = Misc.fromInputText(NS + "_password", state.password);
                clone.firstName = Misc.fromInputText(NS + "_firstName", state.firstName);
                clone.lastName = Misc.fromInputText(NS + "_lastName", state.lastName);
                clone.currentYear = Misc.fromInputNumber(NS + "_currentYear", state.currentYear);
                clone.roleLUID = Misc.fromRadioNumber(NS + "_roleLUID", state.roleLUID);
                clone.archiveDays = Misc.fromInputNumberNullable(NS + "_archiveDays", state.archiveDays);
                clone.archive = Misc.fromInputCheckbox(NS + "_archive", state.archive);
                //
                clone.profile.AcrobatPath = Misc.fromInputText(NS + "_profile.AcrobatPath", state.profile.AcrobatPath);
                clone.profile.FactureSortType = Misc.fromSelectNumber(NS + "_profile.FactureSortType", state.profile.FactureSortType);
                return clone;
            };
            valid = function (formState) {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = function () {
                document.getElementById(NS + "_dummy_submit").click();
                var form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_38("onchange", onchange = function (input) {
                state = getFormState();
                App.render();
            });
            exports_38("cancel", cancel = function () {
                Router.goBackOrResume(isDirty);
            });
            exports_38("create", create = function () {
                var formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST("/account", Misc.createBlack(formState, blackList))
                    .then(function (payload) {
                    var newkey = payload;
                    emailSubject = payload.emailSubject;
                    emailBody = payload.emailBody;
                    Misc.toastSuccessSave();
                    Router.goto("#/admin/account/" + newkey.uid, 10);
                })
                    .catch(App.render);
            });
            exports_38("save", save = function (done) {
                if (done === void 0) { done = false; }
                var formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.PUT("/account", Misc.createBlack(formState, blackList))
                    .then(function (_) {
                    Misc.toastSuccessSave();
                    if (done)
                        Router.goto("#/admin/accounts/", 100);
                    else
                        Router.goto("#/admin/account/" + key.uid, 10);
                })
                    .catch(App.render);
            });
            exports_38("drop", drop = function () {
                key.updated = state.updated;
                App.prepareRender();
                App.DELETE("/account", key)
                    .then(function (_) {
                    clearState();
                    Router.goto("#/admin/accounts/", 250);
                })
                    .catch(App.render);
            });
            exports_38("resetPassword", resetPassword = function () {
                App.POST("/account/reset-password", key)
                    .then(function (_) {
                    Misc.toastSuccess(i18n("Password reset sent"));
                    Router.goto("#/admin/account/" + key.uid, 10);
                })
                    .catch(App.render);
            });
            exports_38("createInvitation", createInvitation = function () {
                App.POST("/account/create-invitation", key)
                    .then(function (_) {
                    Misc.toastSuccess(i18n("Invitation sent"));
                    Router.goto("#/admin/account/" + key.uid, 10);
                })
                    .catch(App.render);
            });
            dirtyExit = function () {
                isDirty = !Misc.same(fetchedState, getFormState());
                if (isDirty) {
                    setTimeout(function () {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
System.register("src/admin/layout2", ["_BaseApp/src/core/app", "src/layout"], function (exports_39, context_39) {
    "use strict";
    var App, layout_4, icon, prepareMenu, tabTemplate, buildTitle, buildSubtitle;
    var __moduleName = context_39 && context_39.id;
    return {
        setters: [
            function (App_12) {
                App = App_12;
            },
            function (layout_4_1) {
                layout_4 = layout_4_1;
            }
        ],
        execute: function () {
            exports_39("icon", icon = "far fa-user");
            exports_39("prepareMenu", prepareMenu = function () {
                layout_4.setOpenedMenu("Administration-Management");
            });
            exports_39("tabTemplate", tabTemplate = function (id, xtra, isNew) {
                if (isNew === void 0) { isNew = false; }
                var isCompanys = App.inContext("App_companys");
                var isCompany = App.inContext("App_company");
                var isFiles = window.location.hash.startsWith("#/files/company");
                var isFile = window.location.hash.startsWith("#/file/company");
                var showDetail = !isCompanys;
                var showFiles = showDetail && xtra;
                var showFile = isFile;
                return "\n<div class=\"tabs is-boxed\">\n    <ul>\n        <li " + (isCompanys ? "class='is-active'" : "") + ">\n            <a href=\"#/admin/companys\">\n                <span class=\"icon\"><i class=\"fas fa-list-ol\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("List") + "</span>\n            </a>\n        </li>\n" + (showDetail ? "\n        <li " + (isCompany ? "class='is-active'" : "") + ">\n            <a href=\"#/admin/company/" + id + "\">\n                <span class=\"icon\"><i class=\"" + icon + "\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("Company Details") + "</span>\n            </a>\n        </li>\n" : "") + "\n" + (showFiles ? "\n        <li " + (isFiles ? "class='is-active'" : "") + ">\n            <a href=\"#/files/account/" + id + "\">\n                <span class=\"icon\"><i class=\"far fa-paperclip\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("Files") + " (" + xtra.fileCount + ")</span>\n            </a>\n        </li>\n" : "") + "\n" + (showFile ? "\n        <li " + (isFile ? "class='is-active'" : "") + ">\n            <a href=\"#/file/account/" + id + "\">\n                <span class=\"icon\"><i class=\"far fa-paperclip\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("File Details") + "</span>\n            </a>\n        </li>\n" : "") + "\n\n    </ul>\n</div>\n";
            });
            exports_39("buildTitle", buildTitle = function (xtra, defaultText) {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.title) !== null && _a !== void 0 ? _a : defaultText;
            });
            exports_39("buildSubtitle", buildSubtitle = function (xtra, defaultText) {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.subtitle) !== null && _a !== void 0 ? _a : defaultText;
            });
        }
    };
});
// File: companys.ts
System.register("src/admin/companys", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/lookupdata", "src/admin/layout2"], function (exports_40, context_40) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, Lookup, layout2_1, NS, key, state, xtra, uiSelectedRow, filterTemplate, trTemplate, tableTemplate, pageTemplate, fetchState, fetch, refresh, render, postRender, inContext, setSelectedRow, isSelectedRow, goto, sortBy, search, gotoDetail;
    var __moduleName = context_40 && context_40.id;
    return {
        setters: [
            function (App_13) {
                App = App_13;
            },
            function (Router_7) {
                Router = Router_7;
            },
            function (Perm_2) {
                Perm = Perm_2;
            },
            function (Misc_15) {
                Misc = Misc_15;
            },
            function (Theme_3) {
                Theme = Theme_3;
            },
            function (Pager_2) {
                Pager = Pager_2;
            },
            function (Lookup_2) {
                Lookup = Lookup_2;
            },
            function (layout2_1_1) {
                layout2_1 = layout2_1_1;
            }
        ],
        execute: function () {
            exports_40("NS", NS = "App_companys");
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 20, sortColumn: "CIE", sortDirection: "ASC", filter: {} }
            };
            filterTemplate = function () {
                var filters = [];
                return filters.join("");
            };
            trTemplate = function (item, rowNumber) {
                return "\n<tr class=\"" + (isSelectedRow(item.cie) ? "is-selected" : "") + "\" onclick=\"" + NS + ".gotoDetail(" + item.cie + ");\">\n    <td class=\"js-index\">" + rowNumber + "</td>\n    <td>" + Misc.toStaticText(item.cie) + "</td>\n    <td>" + Misc.toStaticText(item.name) + "</td>\n    <td>" + Misc.toStaticText(item.features) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.archive) + "</td>\n    <td>" + Misc.toStaticText(item.acombapassword) + "</td>\n    <td>" + Misc.toStaticText(item.acombapath) + "</td>\n    <td>" + Misc.toStaticText(item.acombasocietepath) + "</td>\n    <td>" + Misc.toStaticText(item.acombasyncropath) + "</td>\n    <td>" + Misc.toStaticText(item.acombausername) + "</td>\n    <td>" + Misc.toStaticText(item.acrobatpath) + "</td>\n    <td>" + Misc.toStaticText(item.adminpassword) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.afficherpermit1) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.afficherpermit2) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.afficherpermit3) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.afficherpermit4) + "</td>\n    <td>" + Misc.toStaticText(item.anneecourante) + "</td>\n    <td>" + Misc.toStaticText(item.autresraportsprintermarginbottom) + "</td>\n    <td>" + Misc.toStaticText(item.autresraportsprintermarginleft) + "</td>\n    <td>" + Misc.toStaticText(item.autresraportsprintermarginright) + "</td>\n    <td>" + Misc.toStaticText(item.autresraportsprintermargintop) + "</td>\n    <td>" + Misc.toStaticText(item.caneditundeliveredpermits) + "</td>\n    <td>" + Misc.toStaticText(item.ccemail) + "</td>\n    <td>" + Misc.toStaticText(item.cletriclientnom) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.copiepermit1) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.copiepermit2) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.copiepermit3) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.copiepermit4) + "</td>\n    <td>" + Misc.toStaticText(item.deletefichepassword) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.emailpermit1) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.emailpermit2) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.emailpermit3) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.emailpermit4) + "</td>\n    <td>" + Misc.toStaticText(item.excellanguage) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.facturesafficherfraisautrechargepourtransporteur) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.facturesafficherfraisautresproducteur) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.facturesafficherfraisautresrevenusproducteur) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.facturesafficherfraisautresrevenustransporteur) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.facturesafficherfraisautrestransporteur) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.facturesafficherfraischargeurproducteur) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.facturesafficherfraischargeurtransporteur) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.facturesafficherfraiscompensationdedeplacement) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.facturesaffichersurchargeproducteur) + "</td>\n    <td>" + Misc.toStaticText(item.formicon) + "</td>\n    <td>" + Misc.toStaticText(item.formtext) + "</td>\n    <td>" + Misc.toStaticText(item.fournisseurpointerid) + "</td>\n    <td>" + Misc.toStaticText(item.fromemail) + "</td>\n    <td>" + Misc.toStaticText(item.gpversion) + "</td>\n    <td>" + Misc.toStaticText(item.helpfilepath) + "</td>\n    <td>" + Misc.toStaticText(item.imprimanteautresrapports) + "</td>\n    <td>" + Misc.toStaticText(item.imprimantedepermis) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.livraisonliertaux) + "</td>\n    <td>" + Misc.toStaticText(item.logfile) + "</td>\n    <td>" + Misc.toStaticText(item.logopath) + "</td>\n    <td>" + Misc.toStaticText(item.massecontingentvoyagedefaut) + "</td>\n    <td>" + Misc.toStaticText(item.masselimitedefaut) + "</td>\n    <td>" + Misc.toStaticText(item.message_autorisationdeslivraisons) + "</td>\n    <td>" + Misc.toStaticText(item.message_demandecontingentement) + "</td>\n    <td>" + Misc.toStaticText(item.messageimpressionsdefactures) + "</td>\n    <td>" + Misc.toStaticText(item.messagelivraisonnonconforme) + "</td>\n    <td>" + Misc.toStaticText(item.messagespecpermitanglais) + "</td>\n    <td>" + Misc.toStaticText(item.messagespecpermitfrancais) + "</td>\n    <td>" + Misc.toStaticText(item.nomdb) + "</td>\n    <td>" + Misc.toStaticText(item.permisprintermarginbottom) + "</td>\n    <td>" + Misc.toStaticText(item.permisprintermarginleft) + "</td>\n    <td>" + Misc.toStaticText(item.permisprintermarginright) + "</td>\n    <td>" + Misc.toStaticText(item.permisprintermargintop) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.permisprintpreview) + "</td>\n    <td>" + Misc.toStaticText(item.preleves_notps) + "</td>\n    <td>" + Misc.toStaticText(item.preleves_notvq) + "</td>\n    <td>" + Misc.toStaticText(item.serveuremail) + "</td>\n    <td>" + Misc.toStaticText(item.showyearsinpermislistview) + "</td>\n    <td>" + Misc.toStaticText(item.superficiecontingenteepourcentagededuction) + "</td>\n    <td>" + Misc.toStaticText(item.superficiecontingenteesansdeduction) + "</td>\n    <td>" + Misc.toStaticText(item.syndicat_codepostal) + "</td>\n    <td>" + Misc.toStaticText(item.syndicat_fax) + "</td>\n    <td>" + Misc.toStaticText(item.syndicat_nom) + "</td>\n    <td>" + Misc.toStaticText(item.syndicat_nomanglais) + "</td>\n    <td>" + Misc.toStaticText(item.syndicat_nomfrancais) + "</td>\n    <td>" + Misc.toStaticText(item.syndicat_notps) + "</td>\n    <td>" + Misc.toStaticText(item.syndicat_notvq) + "</td>\n    <td>" + Misc.toStaticText(item.syndicat_rue) + "</td>\n    <td>" + Misc.toStaticText(item.syndicat_telephone) + "</td>\n    <td>" + Misc.toStaticText(item.syndicat_ville) + "</td>\n    <td>" + Misc.toStaticText(item.syndicatouoffice) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.takeacombabackup) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.takesqlbackup) + "</td>\n    <td>" + Misc.toStaticText(item.tempsentrelesbackupsautomatiques) + "</td>\n    <td>" + Misc.toStaticText(item.timeoutsql) + "</td>\n    <td>" + Misc.toStaticText(item.typepermis) + "</td>\n    <td>" + Misc.toStaticText(item.typepermis1) + "</td>\n    <td>" + Misc.toStaticText(item.typepermis1anglais) + "</td>\n    <td>" + Misc.toStaticText(item.typepermis1francais) + "</td>\n    <td>" + Misc.toStaticText(item.typepermis2) + "</td>\n    <td>" + Misc.toStaticText(item.typepermis2anglais) + "</td>\n    <td>" + Misc.toStaticText(item.typepermis2francais) + "</td>\n    <td>" + Misc.toStaticText(item.typepermis3) + "</td>\n    <td>" + Misc.toStaticText(item.typepermis3anglais) + "</td>\n    <td>" + Misc.toStaticText(item.typepermis3francais) + "</td>\n    <td>" + Misc.toStaticText(item.typepermis4) + "</td>\n    <td>" + Misc.toStaticText(item.typepermis4anglais) + "</td>\n    <td>" + Misc.toStaticText(item.typepermis4francais) + "</td>\n    <td>" + Misc.toStaticText(item.updateotherdatabase) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.utiliselesychronisateurdirect) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.utiliserlesnomsdemachinedanslenomdeprinter) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.utiliserlotscontingentes) + "</td>\n    <td>" + Misc.toStaticText(item.xlstemplatespath) + "</td>\n    <td>" + Misc.toStaticText(item.fournisseur_planconjoint_text) + "</td>\n    <td>" + Misc.toStaticText(item.fournisseur_surcharge_text) + "</td>\n    <td>" + Misc.toStaticText(item.compte_paiements_text) + "</td>\n    <td>" + Misc.toStaticText(item.compte_arecevoir_text) + "</td>\n    <td>" + Misc.toStaticText(item.compte_apayer_text) + "</td>\n    <td>" + Misc.toStaticText(item.compte_duauxproducteurs_text) + "</td>\n    <td>" + Misc.toStaticText(item.compte_tpspercues_text) + "</td>\n    <td>" + Misc.toStaticText(item.compte_tpspayees_text) + "</td>\n    <td>" + Misc.toStaticText(item.compte_tvqpercues_text) + "</td>\n    <td>" + Misc.toStaticText(item.compte_tvqpayees_text) + "</td>\n    <td>" + Misc.toStaticText(item.taux_tps) + "</td>\n    <td>" + Misc.toStaticText(item.taux_tvq) + "</td>\n    <td>" + Misc.toStaticText(item.fournisseur_fond_roulement_text) + "</td>\n    <td>" + Misc.toStaticText(item.fournisseur_fond_forestier_text) + "</td>\n    <td>" + Misc.toStaticText(item.fournisseur_preleve_divers_text) + "</td>\n</tr>";
            };
            tableTemplate = function (tbody, pager) {
                return "\n<div class=\"table-container\">\n<table class=\"table is-hoverable is-fullwidth\">\n    <thead>\n        <tr>\n            <th></th>\n            " + Pager.sortableHeaderLink(pager, NS, i18n("CIE"), "cie", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("NAME"), "name", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FEATURES"), "features", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ARCHIVE"), "archive", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ACOMBAPASSWORD"), "acombapassword", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ACOMBAPATH"), "acombapath", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ACOMBASOCIETEPATH"), "acombasocietepath", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ACOMBASYNCROPATH"), "acombasyncropath", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ACOMBAUSERNAME"), "acombausername", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ACROBATPATH"), "acrobatpath", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ADMINPASSWORD"), "adminpassword", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERPERMIT1"), "afficherpermit1", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERPERMIT2"), "afficherpermit2", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERPERMIT3"), "afficherpermit3", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERPERMIT4"), "afficherpermit4", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ANNEECOURANTE"), "anneecourante", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("AUTRESRAPORTSPRINTERMARGINBOTTOM"), "autresraportsprintermarginbottom", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("AUTRESRAPORTSPRINTERMARGINLEFT"), "autresraportsprintermarginleft", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("AUTRESRAPORTSPRINTERMARGINRIGHT"), "autresraportsprintermarginright", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("AUTRESRAPORTSPRINTERMARGINTOP"), "autresraportsprintermargintop", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("CANEDITUNDELIVEREDPERMITS"), "caneditundeliveredpermits", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("CCEMAIL"), "ccemail", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("CLETRICLIENTNOM"), "cletriclientnom", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("COPIEPERMIT1"), "copiepermit1", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("COPIEPERMIT2"), "copiepermit2", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("COPIEPERMIT3"), "copiepermit3", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("COPIEPERMIT4"), "copiepermit4", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("DELETEFICHEPASSWORD"), "deletefichepassword", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("EMAILPERMIT1"), "emailpermit1", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("EMAILPERMIT2"), "emailpermit2", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("EMAILPERMIT3"), "emailpermit3", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("EMAILPERMIT4"), "emailpermit4", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("EXCELLANGUAGE"), "excellanguage", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISAUTRECHARGEPOURTRANSPORTEUR"), "facturesafficherfraisautrechargepourtransporteur", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISAUTRESPRODUCTEUR"), "facturesafficherfraisautresproducteur", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISAUTRESREVENUSPRODUCTEUR"), "facturesafficherfraisautresrevenusproducteur", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISAUTRESREVENUSTRANSPORTEUR"), "facturesafficherfraisautresrevenustransporteur", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISAUTRESTRANSPORTEUR"), "facturesafficherfraisautrestransporteur", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISCHARGEURPRODUCTEUR"), "facturesafficherfraischargeurproducteur", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISCHARGEURTRANSPORTEUR"), "facturesafficherfraischargeurtransporteur", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISCOMPENSATIONDEDEPLACEMENT"), "facturesafficherfraiscompensationdedeplacement", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERSURCHARGEPRODUCTEUR"), "facturesaffichersurchargeproducteur", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FORMICON"), "formicon", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FORMTEXT"), "formtext", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FOURNISSEURPOINTERID"), "fournisseurpointerid", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FROMEMAIL"), "fromemail", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("GPVERSION"), "gpversion", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("HELPFILEPATH"), "helpfilepath", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("IMPRIMANTEAUTRESRAPPORTS"), "imprimanteautresrapports", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("IMPRIMANTEDEPERMIS"), "imprimantedepermis", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("LIVRAISONLIERTAUX"), "livraisonliertaux", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("LOGFILE"), "logfile", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("LOGOPATH"), "logopath", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("MASSECONTINGENTVOYAGEDEFAUT"), "massecontingentvoyagedefaut", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("MASSELIMITEDEFAUT"), "masselimitedefaut", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("MESSAGE_AUTORISATIONDESLIVRAISONS"), "message_autorisationdeslivraisons", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("MESSAGE_DEMANDECONTINGENTEMENT"), "message_demandecontingentement", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("MESSAGEIMPRESSIONSDEFACTURES"), "messageimpressionsdefactures", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("MESSAGELIVRAISONNONCONFORME"), "messagelivraisonnonconforme", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("MESSAGESPECPERMITANGLAIS"), "messagespecpermitanglais", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("MESSAGESPECPERMITFRANCAIS"), "messagespecpermitfrancais", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("NOMDB"), "nomdb", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PERMISPRINTERMARGINBOTTOM"), "permisprintermarginbottom", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PERMISPRINTERMARGINLEFT"), "permisprintermarginleft", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PERMISPRINTERMARGINRIGHT"), "permisprintermarginright", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PERMISPRINTERMARGINTOP"), "permisprintermargintop", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PERMISPRINTPREVIEW"), "permisprintpreview", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PRELEVES_NOTPS"), "preleves_notps", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PRELEVES_NOTVQ"), "preleves_notvq", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SERVEUREMAIL"), "serveuremail", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SHOWYEARSINPERMISLISTVIEW"), "showyearsinpermislistview", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SUPERFICIECONTINGENTEEPOURCENTAGEDEDUCTION"), "superficiecontingenteepourcentagededuction", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SUPERFICIECONTINGENTEESANSDEDUCTION"), "superficiecontingenteesansdeduction", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_CODEPOSTAL"), "syndicat_codepostal", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_FAX"), "syndicat_fax", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_NOM"), "syndicat_nom", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_NOMANGLAIS"), "syndicat_nomanglais", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_NOMFRANCAIS"), "syndicat_nomfrancais", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_NOTPS"), "syndicat_notps", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_NOTVQ"), "syndicat_notvq", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_RUE"), "syndicat_rue", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_TELEPHONE"), "syndicat_telephone", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_VILLE"), "syndicat_ville", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SYNDICATOUOFFICE"), "syndicatouoffice", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TAKEACOMBABACKUP"), "takeacombabackup", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TAKESQLBACKUP"), "takesqlbackup", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TEMPSENTRELESBACKUPSAUTOMATIQUES"), "tempsentrelesbackupsautomatiques", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TIMEOUTSQL"), "timeoutsql", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS"), "typepermis", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS1"), "typepermis1", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS1ANGLAIS"), "typepermis1anglais", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS1FRANCAIS"), "typepermis1francais", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS2"), "typepermis2", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS2ANGLAIS"), "typepermis2anglais", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS2FRANCAIS"), "typepermis2francais", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS3"), "typepermis3", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS3ANGLAIS"), "typepermis3anglais", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS3FRANCAIS"), "typepermis3francais", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS4"), "typepermis4", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS4ANGLAIS"), "typepermis4anglais", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS4FRANCAIS"), "typepermis4francais", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("UPDATEOTHERDATABASE"), "updateotherdatabase", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("UTILISELESYCHRONISATEURDIRECT"), "utiliselesychronisateurdirect", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("UTILISERLESNOMSDEMACHINEDANSLENOMDEPRINTER"), "utiliserlesnomsdemachinedanslenomdeprinter", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("UTILISERLOTSCONTINGENTES"), "utiliserlotscontingentes", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("XLSTEMPLATESPATH"), "xlstemplatespath", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FOURNISSEUR_PLANCONJOINT_TEXT"), "fournisseur_planconjoint_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FOURNISSEUR_SURCHARGE_TEXT"), "fournisseur_surcharge_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_PAIEMENTS_TEXT"), "compte_paiements_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_ARECEVOIR_TEXT"), "compte_arecevoir_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_APAYER_TEXT"), "compte_apayer_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_DUAUXPRODUCTEURS_TEXT"), "compte_duauxproducteurs_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_TPSPERCUES_TEXT"), "compte_tpspercues_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_TPSPAYEES_TEXT"), "compte_tpspayees_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_TVQPERCUES_TEXT"), "compte_tvqpercues_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_TVQPAYEES_TEXT"), "compte_tvqpayees_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TAUX_TPS"), "taux_tps", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TAUX_TVQ"), "taux_tvq", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FOURNISSEUR_FOND_ROULEMENT_TEXT"), "fournisseur_fond_roulement_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FOURNISSEUR_FOND_FORESTIER_TEXT"), "fournisseur_fond_forestier_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("FOURNISSEUR_PRELEVE_DIVERS_TEXT"), "fournisseur_preleve_divers_text", "ASC") + "\n            " + Pager.headerLink(i18n("TODO")) + "\n        </tr>\n    </thead>\n    <tbody>\n        " + tbody + "\n    </tbody>\n</table>\n</div>\n";
            };
            pageTemplate = function (pager, table, tab, warning, dirty) {
                var readonly = false;
                var buttons = [];
                buttons.push(Theme.buttonAddNew(NS, "#/admin/company/new", i18n("Add New")));
                var actions = Theme.renderButtons(buttons);
                var title = layout2_1.buildTitle(xtra, i18n("companys title"));
                var subtitle = layout2_1.buildSubtitle(xtra, i18n("companys subtitle"));
                return "\n<form onsubmit=\"return false;\">\n<input type=\"submit\" style=\"display:none;\" id=\"" + NS + "_dummy_submit\">\n\n<div class=\"js-fixed-heading\">\n<div class=\"js-head\">\n    <div class=\"content js-uc-heading js-flex-space\">\n        <div>\n            <div class=\"title\"><i class=\"" + layout2_1.icon + "\"></i> <span>" + title + "</span></div>\n            <div class=\"subtitle\">" + subtitle + "</div>\n        </div>\n        <div>\n            " + Theme.wrapContent("js-uc-actions", actions) + "\n        </div>\n    </div>\n    " + Theme.wrapContent("js-uc-tabs", tab) + "\n</div>\n<div class=\"js-body\">\n    " + Theme.wrapContent("js-uc-notification", dirty) + "\n    " + Theme.wrapContent("js-uc-notification", warning) + "\n    " + Theme.wrapContent("js-uc-pager", pager) + "\n    " + Theme.wrapContent("js-uc-list", table) + "\n</div>\n</div>\n\n</form>\n";
            };
            exports_40("fetchState", fetchState = function (cie) {
                Router.registerDirtyExit(null);
                return App.POST("/company/search", state.pager)
                    .then(function (payload) {
                    state = payload;
                    xtra = payload.xtra;
                    key = {};
                })
                    .then(Lookup.fetch_autreFournisseur())
                    .then(Lookup.fetch_compte());
            });
            exports_40("fetch", fetch = function (params) {
                var cie = +params[0];
                App.prepareRender(NS, i18n("companys"));
                fetchState(cie)
                    .then(App.render)
                    .catch(App.render);
            });
            refresh = function () {
                App.prepareRender(NS, i18n("companys"));
                App.POST("/company/search", state.pager)
                    .then(function (payload) {
                    state = payload;
                })
                    .then(App.render)
                    .catch(App.render);
            };
            exports_40("render", render = function () {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
                    return App.warningTemplate() || App.unexpectedTemplate();
                var warning = App.warningTemplate();
                var dirty = "";
                var tbody = state.list.reduce(function (html, item, index) {
                    var rowNumber = Pager.rowNumber(state.pager, index);
                    return html + trTemplate(item, rowNumber);
                }, "");
                var year = Perm.getCurrentYear(); //state.pager.filter.year;
                var filter = filterTemplate();
                var search = Pager.searchTemplate(state.pager, NS);
                var pager = Pager.render(state.pager, NS, [20, 50], search, filter);
                var table = tableTemplate(tbody, state.pager);
                var tab = layout2_1.tabTemplate(null, null);
                return pageTemplate(pager, table, tab, dirty, warning);
            });
            exports_40("postRender", postRender = function () {
                if (!inContext())
                    return;
            });
            exports_40("inContext", inContext = function () {
                return App.inContext(NS);
            });
            setSelectedRow = function (cie) {
                if (uiSelectedRow == undefined)
                    uiSelectedRow = { cie: cie };
                uiSelectedRow.cie = cie;
            };
            isSelectedRow = function (cie) {
                if (uiSelectedRow == undefined)
                    return false;
                return (uiSelectedRow.cie == cie);
            };
            exports_40("goto", goto = function (pageNo, pageSize) {
                state.pager.pageNo = pageNo;
                state.pager.pageSize = pageSize;
                refresh();
            });
            exports_40("sortBy", sortBy = function (columnName, direction) {
                state.pager.pageNo = 1;
                state.pager.sortColumn = columnName;
                state.pager.sortDirection = direction;
                refresh();
            });
            exports_40("search", search = function (element) {
                state.pager.searchText = element.value;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_40("gotoDetail", gotoDetail = function (cie) {
                setSelectedRow(cie);
                Router.goto("#/admin/company/" + cie);
            });
        }
    };
});
// File: company.ts
System.register("src/admin/company", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "src/admin/lookupdata", "src/permission", "src/admin/layout2"], function (exports_41, context_41) {
    "use strict";
    var App, Router, Misc, Theme, Lookup, Perm, layout2_2, NS, blackList, key, state, fetchedState, xtra, isNew, isDirty, block_company, block_system, block_personnalisation, block_acomba, block_comptes, block_preleve, block_permis, block_print, block_backup, block_security, block_default_profile, block_todo, formTemplate, pageTemplate, dirtyTemplate, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, onchange, cancel, create, save, drop, dirtyExit;
    var __moduleName = context_41 && context_41.id;
    return {
        setters: [
            function (App_14) {
                App = App_14;
            },
            function (Router_8) {
                Router = Router_8;
            },
            function (Misc_16) {
                Misc = Misc_16;
            },
            function (Theme_4) {
                Theme = Theme_4;
            },
            function (Lookup_3) {
                Lookup = Lookup_3;
            },
            function (Perm_3) {
                Perm = Perm_3;
            },
            function (layout2_2_1) {
                layout2_2 = layout2_2_1;
            }
        ],
        execute: function () {
            exports_41("NS", NS = "App_company");
            blackList = ["created"];
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            block_company = function (item) {
                return "\n    " + Theme.renderTextField(NS, "name", item.name, i18n("NAME"), 64, true) + "\n    " + Theme.renderTextField(NS, "features", item.features, i18n("FEATURES"), 2048) + "\n    " + Theme.renderCheckboxField(NS, "archive", item.archive, i18n("ARCHIVE")) + "\n";
            };
            block_system = function (item) {
                return "\n    " + Theme.renderTextField(NS, "xlstemplatespath", item.xlstemplatespath, i18n("XLSTEMPLATESPATH"), 500) + "\n    " + Theme.renderTextField(NS, "helpfilepath", item.helpfilepath, i18n("HELPFILEPATH"), 500) + "\n\n    " + Theme.renderNumberField(NS, "masselimitedefaut", item.masselimitedefaut, i18n("MASSELIMITEDEFAUT"), true) + "\n    " + Theme.renderNumberField(NS, "anneecourante", item.anneecourante, i18n("ANNEECOURANTE"), true) + "\n    " + Theme.renderNumberField(NS, "taux_tps", item.taux_tps, i18n("TAUX_TPS")) + "\n    " + Theme.renderNumberField(NS, "taux_tvq", item.taux_tvq, i18n("TAUX_TVQ")) + "\n\n    " + Theme.renderNumberField(NS, "massecontingentvoyagedefaut", item.massecontingentvoyagedefaut, i18n("MASSECONTINGENTVOYAGEDEFAUT"), true) + "\n    " + Theme.renderNumberField(NS, "superficiecontingenteesansdeduction", item.superficiecontingenteesansdeduction, i18n("SUPERFICIECONTINGENTEESANSDEDUCTION")) + "\n    " + Theme.renderNumberField(NS, "superficiecontingenteepourcentagededuction", item.superficiecontingenteepourcentagededuction, i18n("SUPERFICIECONTINGENTEEPOURCENTAGEDEDUCTION")) + "\n\n    " + Theme.renderCheckboxField(NS, "livraisonliertaux", item.livraisonliertaux, i18n("LIVRAISONLIERTAUX")) + "\n    " + Theme.renderCheckboxField(NS, "utiliserlotscontingentes", item.utiliserlotscontingentes, i18n("UTILISERLOTSCONTINGENTES")) + "\n\n    " + Theme.renderTextField(NS, "formicon", item.formicon, i18n("FORMICON"), 500) + "\n    " + Theme.renderTextField(NS, "formtext", item.formtext, i18n("FORMTEXT"), 500) + "\n";
            };
            block_personnalisation = function (item) {
                return "\n    " + Theme.renderTextField(NS, "syndicatouoffice", item.syndicatouoffice, i18n("SYNDICATOUOFFICE"), 500) + "\n\n    " + Theme.renderTextField(NS, "syndicat_nomanglais", item.syndicat_nomanglais, i18n("SYNDICAT_NOMANGLAIS"), 500) + "\n    " + Theme.renderTextField(NS, "syndicat_nomfrancais", item.syndicat_nomfrancais, i18n("SYNDICAT_NOMFRANCAIS"), 500) + "\n\n    " + Theme.renderTextField(NS, "syndicat_rue", item.syndicat_rue, i18n("SYNDICAT_RUE"), 500) + "\n    " + Theme.renderTextField(NS, "syndicat_ville", item.syndicat_ville, i18n("SYNDICAT_VILLE"), 500) + "\n    " + Theme.renderTextField(NS, "syndicat_codepostal", item.syndicat_codepostal, i18n("SYNDICAT_CODEPOSTAL"), 500) + "\n    " + Theme.renderTextField(NS, "syndicat_telephone", item.syndicat_telephone, i18n("SYNDICAT_TELEPHONE"), 500) + "\n    " + Theme.renderTextField(NS, "syndicat_fax", item.syndicat_fax, i18n("SYNDICAT_FAX"), 500) + "\n";
            };
            block_acomba = function (item) {
                return "\n    " + Theme.renderTextField(NS, "acombausername", item.acombausername, i18n("ACOMBAUSERNAME"), 500) + "\n    " + Theme.renderTextField(NS, "acombapassword", item.acombapassword, i18n("ACOMBAPASSWORD"), 500) + "\n    " + Theme.renderTextField(NS, "acombasocietepath", item.acombasocietepath, i18n("ACOMBASOCIETEPATH"), 500) + "\n    " + Theme.renderTextField(NS, "acombapath", item.acombapath, i18n("ACOMBAPATH"), 500) + "\n\n    " + Theme.renderCheckboxField(NS, "utiliselesychronisateurdirect", item.utiliselesychronisateurdirect, i18n("UTILISELESYCHRONISATEURDIRECT")) + "\n    " + Theme.renderTextField(NS, "acombasyncropath", item.acombasyncropath, i18n("ACOMBASYNCROPATH"), 500) + "\n";
            };
            block_comptes = function (item, fournisseur_planconjoint, fournisseur_surcharge, compte_paiements, compte_arecevoir, compte_apayer, compte_duauxproducteurs, compte_tpspercues, compte_tpspayees, compte_tvqpercues, compte_tvqpayees, fournisseur_fond_roulement, fournisseur_fond_forestier, fournisseur_preleve_divers) {
                return "\n    " + Theme.renderDropdownField(NS, "fournisseur_planconjoint", fournisseur_planconjoint, i18n("FOURNISSEUR_PLANCONJOINT")) + "\n    " + Theme.renderDropdownField(NS, "fournisseur_surcharge", fournisseur_surcharge, i18n("FOURNISSEUR_SURCHARGE")) + "\n    " + Theme.renderDropdownField(NS, "fournisseur_fond_roulement", fournisseur_fond_roulement, i18n("FOURNISSEUR_FOND_ROULEMENT")) + "\n    " + Theme.renderDropdownField(NS, "fournisseur_fond_forestier", fournisseur_fond_forestier, i18n("FOURNISSEUR_FOND_FORESTIER")) + "\n    " + Theme.renderDropdownField(NS, "fournisseur_preleve_divers", fournisseur_preleve_divers, i18n("FOURNISSEUR_PRELEVE_DIVERS")) + "\n\n    " + Theme.renderDropdownField(NS, "compte_paiements", compte_paiements, i18n("COMPTE_PAIEMENTS")) + "\n    " + Theme.renderDropdownField(NS, "compte_arecevoir", compte_arecevoir, i18n("COMPTE_ARECEVOIR")) + "\n    " + Theme.renderDropdownField(NS, "compte_apayer", compte_apayer, i18n("COMPTE_APAYER")) + "\n    " + Theme.renderDropdownField(NS, "compte_duauxproducteurs", compte_duauxproducteurs, i18n("COMPTE_DUAUXPRODUCTEURS")) + "\n    " + Theme.renderDropdownField(NS, "compte_tpspercues", compte_tpspercues, i18n("COMPTE_TPSPERCUES")) + "\n    " + Theme.renderDropdownField(NS, "compte_tpspayees", compte_tpspayees, i18n("COMPTE_TPSPAYEES")) + "\n    " + Theme.renderDropdownField(NS, "compte_tvqpercues", compte_tvqpercues, i18n("COMPTE_TVQPERCUES")) + "\n    " + Theme.renderDropdownField(NS, "compte_tvqpayees", compte_tvqpayees, i18n("COMPTE_TVQPAYEES")) + "\n";
            };
            block_preleve = function (item) {
                return "\n    " + Theme.renderTextField(NS, "preleves_notps", item.preleves_notps, i18n("PRELEVES_NOTPS"), 500) + "\n    " + Theme.renderTextField(NS, "preleves_notvq", item.preleves_notvq, i18n("PRELEVES_NOTVQ"), 500) + "\n\n    " + Theme.renderTextField(NS, "syndicat_notps", item.syndicat_notps, i18n("SYNDICAT_NOTPS"), 500) + "\n    " + Theme.renderTextField(NS, "syndicat_notvq", item.syndicat_notvq, i18n("SYNDICAT_NOTVQ"), 500) + "\n";
            };
            block_permis = function (item) {
                return "\n    " + Theme.renderNumberField(NS, "typepermis", item.typepermis, i18n("TYPEPERMIS"), true) + "\n\n    " + Theme.renderTextField(NS, "serveuremail", item.serveuremail, i18n("SERVEUREMAIL"), 500) + "\n    " + Theme.renderTextField(NS, "ccemail", item.ccemail, i18n("CCEMAIL"), 500) + "\n    " + Theme.renderTextField(NS, "fromemail", item.fromemail, i18n("FROMEMAIL"), 500) + "\n\n    " + Theme.renderCheckboxField(NS, "permisprintpreview", item.permisprintpreview, i18n("PERMISPRINTPREVIEW")) + "\n    " + Theme.renderTextField(NS, "typepermis1", item.typepermis1, i18n("TYPEPERMIS1"), 500) + "\n    " + Theme.renderTextField(NS, "typepermis1anglais", item.typepermis1anglais, i18n("TYPEPERMIS1ANGLAIS"), 500) + "\n    " + Theme.renderTextField(NS, "typepermis1francais", item.typepermis1francais, i18n("TYPEPERMIS1FRANCAIS"), 500) + "\n    " + Theme.renderCheckboxField(NS, "afficherpermit1", item.afficherpermit1, i18n("AFFICHERPERMIT1")) + "\n    " + Theme.renderCheckboxField(NS, "emailpermit1", item.emailpermit1, i18n("EMAILPERMIT1")) + "\n    " + Theme.renderCheckboxField(NS, "copiepermit1", item.copiepermit1, i18n("COPIEPERMIT1")) + "\n\n    " + Theme.renderTextField(NS, "typepermis2", item.typepermis2, i18n("TYPEPERMIS2"), 500) + "\n    " + Theme.renderTextField(NS, "typepermis2anglais", item.typepermis2anglais, i18n("TYPEPERMIS2ANGLAIS"), 500) + "\n    " + Theme.renderTextField(NS, "typepermis2francais", item.typepermis2francais, i18n("TYPEPERMIS2FRANCAIS"), 500) + "\n    " + Theme.renderCheckboxField(NS, "afficherpermit2", item.afficherpermit2, i18n("AFFICHERPERMIT2")) + "\n    " + Theme.renderCheckboxField(NS, "emailpermit2", item.emailpermit2, i18n("EMAILPERMIT2")) + "\n    " + Theme.renderCheckboxField(NS, "copiepermit2", item.copiepermit2, i18n("COPIEPERMIT2")) + "\n\n    " + Theme.renderTextField(NS, "typepermis3", item.typepermis3, i18n("TYPEPERMIS3"), 500) + "\n    " + Theme.renderTextField(NS, "typepermis3anglais", item.typepermis3anglais, i18n("TYPEPERMIS3ANGLAIS"), 500) + "\n    " + Theme.renderTextField(NS, "typepermis3francais", item.typepermis3francais, i18n("TYPEPERMIS3FRANCAIS"), 500) + "\n    " + Theme.renderCheckboxField(NS, "afficherpermit3", item.afficherpermit3, i18n("AFFICHERPERMIT3")) + "\n    " + Theme.renderCheckboxField(NS, "emailpermit3", item.emailpermit3, i18n("EMAILPERMIT3")) + "\n    " + Theme.renderCheckboxField(NS, "copiepermit3", item.copiepermit3, i18n("COPIEPERMIT3")) + "\n\n    " + Theme.renderTextField(NS, "typepermis4", item.typepermis4, i18n("TYPEPERMIS4"), 500) + "\n    " + Theme.renderTextField(NS, "typepermis4anglais", item.typepermis4anglais, i18n("TYPEPERMIS4ANGLAIS"), 500) + "\n    " + Theme.renderTextField(NS, "typepermis4francais", item.typepermis4francais, i18n("TYPEPERMIS4FRANCAIS"), 500) + "\n    " + Theme.renderCheckboxField(NS, "afficherpermit4", item.afficherpermit4, i18n("AFFICHERPERMIT4")) + "\n    " + Theme.renderCheckboxField(NS, "emailpermit4", item.emailpermit4, i18n("EMAILPERMIT4")) + "\n    " + Theme.renderCheckboxField(NS, "copiepermit4", item.copiepermit4, i18n("COPIEPERMIT4")) + "\n\n    " + Theme.renderTextField(NS, "messagespecpermitanglais", item.messagespecpermitanglais, i18n("MESSAGESPECPERMITANGLAIS"), 500) + "\n    " + Theme.renderTextField(NS, "messagespecpermitfrancais", item.messagespecpermitfrancais, i18n("MESSAGESPECPERMITFRANCAIS"), 500) + "\n\n    " + Theme.renderTextField(NS, "showyearsinpermislistview", item.showyearsinpermislistview, i18n("SHOWYEARSINPERMISLISTVIEW"), 500) + "\n";
            };
            block_print = function (item) {
                return "\n    " + Theme.renderCheckboxField(NS, "facturesaffichersurchargeproducteur", item.facturesaffichersurchargeproducteur, i18n("FACTURESAFFICHERSURCHARGEPRODUCTEUR")) + "\n    " + Theme.renderCheckboxField(NS, "facturesafficherfraischargeurproducteur", item.facturesafficherfraischargeurproducteur, i18n("FACTURESAFFICHERFRAISCHARGEURPRODUCTEUR")) + "\n    " + Theme.renderCheckboxField(NS, "facturesafficherfraischargeurtransporteur", item.facturesafficherfraischargeurtransporteur, i18n("FACTURESAFFICHERFRAISCHARGEURTRANSPORTEUR")) + "\n    " + Theme.renderCheckboxField(NS, "facturesafficherfraisautresproducteur", item.facturesafficherfraisautresproducteur, i18n("FACTURESAFFICHERFRAISAUTRESPRODUCTEUR")) + "\n\n    " + Theme.renderCheckboxField(NS, "facturesafficherfraisautrestransporteur", item.facturesafficherfraisautrestransporteur, i18n("FACTURESAFFICHERFRAISAUTRESTRANSPORTEUR")) + "\n    " + Theme.renderCheckboxField(NS, "facturesafficherfraiscompensationdedeplacement", item.facturesafficherfraiscompensationdedeplacement, i18n("FACTURESAFFICHERFRAISCOMPENSATIONDEDEPLACEMENT")) + "\n    " + Theme.renderCheckboxField(NS, "facturesafficherfraisautresrevenustransporteur", item.facturesafficherfraisautresrevenustransporteur, i18n("FACTURESAFFICHERFRAISAUTRESREVENUSTRANSPORTEUR")) + "\n    " + Theme.renderCheckboxField(NS, "facturesafficherfraisautresrevenusproducteur", item.facturesafficherfraisautresrevenusproducteur, i18n("FACTURESAFFICHERFRAISAUTRESREVENUSPRODUCTEUR")) + "\n\n    " + Theme.renderTextField(NS, "logopath", item.logopath, i18n("LOGOPATH"), 500) + "\n\n    " + Theme.renderCheckboxField(NS, "utiliserlesnomsdemachinedanslenomdeprinter", item.utiliserlesnomsdemachinedanslenomdeprinter, i18n("UTILISERLESNOMSDEMACHINEDANSLENOMDEPRINTER")) + "\n\n    " + Theme.renderTextareaField(NS, "message_autorisationdeslivraisons", item.message_autorisationdeslivraisons, i18n("MESSAGE_AUTORISATIONDESLIVRAISONS"), 500, false, null, 10) + "\n    " + Theme.renderTextareaField(NS, "message_demandecontingentement", item.message_demandecontingentement, i18n("MESSAGE_DEMANDECONTINGENTEMENT"), 500, false, null, 10) + "\n";
            };
            block_backup = function (item) {
                return "\n    " + Theme.renderCheckboxField(NS, "takeacombabackup", item.takeacombabackup, i18n("TAKEACOMBABACKUP")) + "\n    " + Theme.renderCheckboxField(NS, "takesqlbackup", item.takesqlbackup, i18n("TAKESQLBACKUP")) + "\n    " + Theme.renderTextField(NS, "nomdb", item.nomdb, i18n("NOMDB"), 500) + "\n    " + Theme.renderNumberField(NS, "timeoutsql", item.timeoutsql, i18n("TIMEOUTSQL"), true) + "\n    " + Theme.renderNumberField(NS, "tempsentrelesbackupsautomatiques", item.tempsentrelesbackupsautomatiques, i18n("TEMPSENTRELESBACKUPSAUTOMATIQUES")) + "\n";
            };
            block_security = function (item) {
                return "\n    " + Theme.renderTextField(NS, "caneditundeliveredpermits", item.caneditundeliveredpermits, i18n("CANEDITUNDELIVEREDPERMITS"), 500) + "\n\n    " + Theme.renderTextField(NS, "adminpassword", item.adminpassword, i18n("ADMINPASSWORD"), 500) + "\n    " + Theme.renderTextField(NS, "deletefichepassword", item.deletefichepassword, i18n("DELETEFICHEPASSWORD"), 500) + "\n";
            };
            block_default_profile = function (item) {
                return "\n    " + Theme.renderTextField(NS, "imprimantedepermis", item.imprimantedepermis, i18n("IMPRIMANTEDEPERMIS"), 500) + "\n    " + Theme.renderNumberField(NS, "permisprintermarginbottom", item.permisprintermarginbottom, i18n("PERMISPRINTERMARGINBOTTOM")) + "\n    " + Theme.renderNumberField(NS, "permisprintermarginleft", item.permisprintermarginleft, i18n("PERMISPRINTERMARGINLEFT")) + "\n    " + Theme.renderNumberField(NS, "permisprintermarginright", item.permisprintermarginright, i18n("PERMISPRINTERMARGINRIGHT")) + "\n    " + Theme.renderNumberField(NS, "permisprintermargintop", item.permisprintermargintop, i18n("PERMISPRINTERMARGINTOP")) + "\n\n    " + Theme.renderTextField(NS, "imprimanteautresrapports", item.imprimanteautresrapports, i18n("IMPRIMANTEAUTRESRAPPORTS"), 500) + "\n    " + Theme.renderNumberField(NS, "autresraportsprintermarginbottom", item.autresraportsprintermarginbottom, i18n("AUTRESRAPORTSPRINTERMARGINBOTTOM")) + "\n    " + Theme.renderNumberField(NS, "autresraportsprintermarginleft", item.autresraportsprintermarginleft, i18n("AUTRESRAPORTSPRINTERMARGINLEFT")) + "\n    " + Theme.renderNumberField(NS, "autresraportsprintermarginright", item.autresraportsprintermarginright, i18n("AUTRESRAPORTSPRINTERMARGINRIGHT")) + "\n    " + Theme.renderNumberField(NS, "autresraportsprintermargintop", item.autresraportsprintermargintop, i18n("AUTRESRAPORTSPRINTERMARGINTOP")) + "\n\n    " + Theme.renderTextField(NS, "excellanguage", item.excellanguage, i18n("EXCELLANGUAGE"), 500) + "\n\n    " + Theme.renderTextField(NS, "acrobatpath", item.acrobatpath, i18n("ACROBATPATH"), 500) + "\n\n    " + Theme.renderTextField(NS, "cletriclientnom", item.cletriclientnom, i18n("CLETRICLIENTNOM"), 500) + "\n";
            };
            block_todo = function (item) {
                return "\n    " + Theme.renderCheckboxField(NS, "facturesafficherfraisautrechargepourtransporteur", item.facturesafficherfraisautrechargepourtransporteur, i18n("FACTURESAFFICHERFRAISAUTRECHARGEPOURTRANSPORTEUR")) + "\n    " + Theme.renderNumberField(NS, "fournisseurpointerid", item.fournisseurpointerid, i18n("FOURNISSEURPOINTERID"), true) + "\n    " + Theme.renderTextField(NS, "gpversion", item.gpversion, i18n("GPVERSION"), 500) + "\n    " + Theme.renderTextField(NS, "logfile", item.logfile, i18n("LOGFILE"), 500) + "\n    " + Theme.renderTextField(NS, "messageimpressionsdefactures", item.messageimpressionsdefactures, i18n("MESSAGEIMPRESSIONSDEFACTURES"), 500) + "\n    " + Theme.renderTextField(NS, "messagelivraisonnonconforme", item.messagelivraisonnonconforme, i18n("MESSAGELIVRAISONNONCONFORME"), 500) + "\n    " + Theme.renderTextField(NS, "syndicat_nom", item.syndicat_nom, i18n("SYNDICAT_NOM"), 500) + "\n    " + Theme.renderTextField(NS, "updateotherdatabase", item.updateotherdatabase, i18n("UPDATEOTHERDATABASE"), 500) + "\n";
            };
            formTemplate = function (item, fournisseur_planconjoint, fournisseur_surcharge, compte_paiements, compte_arecevoir, compte_apayer, compte_duauxproducteurs, compte_tpspercues, compte_tpspayees, compte_tvqpercues, compte_tvqpayees, fournisseur_fond_roulement, fournisseur_fond_forestier, fournisseur_preleve_divers) {
                return "\n<div class=\"js-float-menu\">\n    <ul>\n        <li>" + Theme.float_menu_button("Compte") + "</li>\n        <li>" + Theme.float_menu_button("Paramètres système") + "</li>\n        <li>" + Theme.float_menu_button("Personnalisation") + "</li>\n        <li>" + Theme.float_menu_button("Acomba") + "</li>\n        <li>" + Theme.float_menu_button("Comptes/Fournisseurs") + "</li>\n        <li>" + Theme.float_menu_button("Taxe") + "</li>\n        <li>" + Theme.float_menu_button("Permis") + "</li>\n        <li>" + Theme.float_menu_button("Paramètres imprimantes") + "</li>\n        <li>" + Theme.float_menu_button("Backup") + "</li>\n        <li>" + Theme.float_menu_button("Sécurité") + "</li>\n        <li>" + Theme.float_menu_button("Profil par défaut") + "</li>\n        <li>" + Theme.float_menu_button("TODO") + "</li>\n    </ul>\n</div>\n\n<div class=\"columns\">\n    <div class=\"column is-8 is-offset-3\">\n        " + Theme.wrapFieldset("Compte", block_company(item)) + "\n        " + Theme.wrapFieldset("Paramètres système", block_system(item)) + "\n        " + Theme.wrapFieldset("Personnalisation", block_personnalisation(item)) + "\n        " + Theme.wrapFieldset("Acomba", block_acomba(item)) + "\n        " + Theme.wrapFieldset("Comptes/Fournisseurs", block_comptes(item, fournisseur_planconjoint, fournisseur_surcharge, compte_paiements, compte_arecevoir, compte_apayer, compte_duauxproducteurs, compte_tpspercues, compte_tpspayees, compte_tvqpercues, compte_tvqpayees, fournisseur_fond_roulement, fournisseur_fond_forestier, fournisseur_preleve_divers)) + "\n        " + Theme.wrapFieldset("Taxe", block_preleve(item)) + "\n        " + Theme.wrapFieldset("Permis", block_permis(item)) + "\n        " + Theme.wrapFieldset("Paramètres imprimantes", block_print(item)) + "\n        " + Theme.wrapFieldset("Backup", block_backup(item)) + "\n        " + Theme.wrapFieldset("Sécurité", block_security(item)) + "\n        " + Theme.wrapFieldset("Profil par défaut", block_default_profile(item)) + "\n        " + Theme.wrapFieldset("TODO", block_todo(item)) + "\n    </div>\n</div>\n\n    " + Theme.renderBlame(item, isNew) + "\n";
            };
            pageTemplate = function (item, form, tab, warning, dirty) {
                var canEdit = true;
                var readonly = !canEdit;
                var canInsert = canEdit && isNew; // && Perm.hasCompany_CanAddCompany;
                var canDelete = canEdit && !canInsert; // && Perm.hasCompany_CanDeleteCompany;
                var canAdd = canEdit && !canInsert; // && Perm.hasCompany_CanAddCompany;
                var canUpdate = canEdit && !isNew;
                var buttons = [];
                buttons.push(Theme.buttonCancel(NS));
                if (canInsert)
                    buttons.push(Theme.buttonInsert(NS));
                if (canDelete)
                    buttons.push(Theme.buttonDelete(NS));
                if (canAdd)
                    buttons.push(Theme.buttonAddNew(NS, "#/admin/company/new"));
                if (canUpdate)
                    buttons.push(Theme.buttonUpdate(NS));
                var actions = Theme.renderButtons(buttons);
                var title = layout2_2.buildTitle(xtra, !isNew ? i18n("company Details") : i18n("New company"));
                var subtitle = layout2_2.buildSubtitle(xtra, i18n("company subtitle"));
                return "\n<form onsubmit=\"return false;\" " + (readonly ? "class='js-readonly'" : "") + ">\n<input type=\"submit\" style=\"display:none;\" id=\"" + NS + "_dummy_submit\">\n\n<div class=\"js-fixed-heading\">\n<div class=\"js-head\">\n    <div class=\"content js-uc-heading js-flex-space\">\n        <div>\n            <div class=\"title\"><i class=\"" + layout2_2.icon + "\"></i> <span>" + title + "</span></div>\n            <div class=\"subtitle\">" + subtitle + "</div>\n        </div>\n        <div>\n            " + Theme.wrapContent("js-uc-actions", actions) + "\n            " + Theme.renderBlame(item, isNew) + "\n        </div>\n    </div>\n    " + Theme.wrapContent("js-uc-tabs", tab) + "\n</div>\n<div class=\"js-body\">\n    " + Theme.wrapContent("js-uc-notification", dirty) + "\n    " + Theme.wrapContent("js-uc-notification", warning) + "\n    " + Theme.wrapContent("js-uc-details", form) + "\n</div>\n</div>\n\n" + Theme.renderModalDelete("modalDelete_" + NS, NS + ".drop()") + "\n\n</form>\n";
            };
            dirtyTemplate = function () {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            exports_41("fetchState", fetchState = function (cie) {
                isNew = isNaN(cie);
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                return App.GET("/company/" + (isNew ? "new" : cie))
                    .then(function (payload) {
                    state = payload.item;
                    fetchedState = Misc.clone(state);
                    xtra = payload.xtra;
                    key = { cie: cie };
                })
                    .then(Lookup.fetch_autreFournisseur())
                    .then(Lookup.fetch_compte());
            });
            exports_41("fetch", fetch = function (params) {
                var cie = +params[0];
                App.prepareRender(NS, i18n("company"));
                fetchState(cie)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_41("render", render = function () {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || Object.keys(state).length == 0)
                    return App.warningTemplate() || App.unexpectedTemplate();
                var year = Perm.getCurrentYear(); //or something better
                var lookup_autreFournisseur = Lookup.get_autreFournisseur(year);
                var lookup_compte = Lookup.get_compte(year);
                var fournisseur_planconjoint = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_planconjoint, true);
                var fournisseur_surcharge = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_surcharge, true);
                var compte_paiements = Theme.renderOptions(lookup_compte, state.compte_paiements, true);
                var compte_arecevoir = Theme.renderOptions(lookup_compte, state.compte_arecevoir, true);
                var compte_apayer = Theme.renderOptions(lookup_compte, state.compte_apayer, true);
                var compte_duauxproducteurs = Theme.renderOptions(lookup_compte, state.compte_duauxproducteurs, true);
                var compte_tpspercues = Theme.renderOptions(lookup_compte, state.compte_tpspercues, true);
                var compte_tpspayees = Theme.renderOptions(lookup_compte, state.compte_tpspayees, true);
                var compte_tvqpercues = Theme.renderOptions(lookup_compte, state.compte_tvqpercues, true);
                var compte_tvqpayees = Theme.renderOptions(lookup_compte, state.compte_tvqpayees, true);
                var fournisseur_fond_roulement = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_fond_roulement, true);
                var fournisseur_fond_forestier = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_fond_forestier, true);
                var fournisseur_preleve_divers = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_preleve_divers, true);
                var form = formTemplate(state, fournisseur_planconjoint, fournisseur_surcharge, compte_paiements, compte_arecevoir, compte_apayer, compte_duauxproducteurs, compte_tpspercues, compte_tpspayees, compte_tvqpercues, compte_tvqpayees, fournisseur_fond_roulement, fournisseur_fond_forestier, fournisseur_preleve_divers);
                var tab = layout2_2.tabTemplate(state.cie, xtra, isNew);
                var dirty = dirtyTemplate();
                var warning = App.warningTemplate();
                return pageTemplate(state, form, tab, warning, dirty);
            });
            exports_41("postRender", postRender = function () {
                if (!inContext())
                    return;
                App.setPageTitle(isNew ? i18n("New company") : xtra.title);
            });
            exports_41("inContext", inContext = function () {
                return App.inContext(NS);
            });
            getFormState = function () {
                var clone = Misc.clone(state);
                clone.name = Misc.fromInputText(NS + "_name", state.name);
                clone.features = Misc.fromInputTextNullable(NS + "_features", state.features);
                clone.archive = Misc.fromInputCheckbox(NS + "_archive", state.archive);
                clone.acombapassword = Misc.fromInputTextNullable(NS + "_acombapassword", state.acombapassword);
                clone.acombapath = Misc.fromInputTextNullable(NS + "_acombapath", state.acombapath);
                clone.acombasocietepath = Misc.fromInputTextNullable(NS + "_acombasocietepath", state.acombasocietepath);
                clone.acombasyncropath = Misc.fromInputTextNullable(NS + "_acombasyncropath", state.acombasyncropath);
                clone.acombausername = Misc.fromInputTextNullable(NS + "_acombausername", state.acombausername);
                clone.acrobatpath = Misc.fromInputTextNullable(NS + "_acrobatpath", state.acrobatpath);
                clone.adminpassword = Misc.fromInputTextNullable(NS + "_adminpassword", state.adminpassword);
                clone.afficherpermit1 = Misc.fromInputCheckbox(NS + "_afficherpermit1", state.afficherpermit1);
                clone.afficherpermit2 = Misc.fromInputCheckbox(NS + "_afficherpermit2", state.afficherpermit2);
                clone.afficherpermit3 = Misc.fromInputCheckbox(NS + "_afficherpermit3", state.afficherpermit3);
                clone.afficherpermit4 = Misc.fromInputCheckbox(NS + "_afficherpermit4", state.afficherpermit4);
                clone.anneecourante = Misc.fromInputNumber(NS + "_anneecourante", state.anneecourante);
                clone.autresraportsprintermarginbottom = Misc.fromInputNumberNullable(NS + "_autresraportsprintermarginbottom", state.autresraportsprintermarginbottom);
                clone.autresraportsprintermarginleft = Misc.fromInputNumberNullable(NS + "_autresraportsprintermarginleft", state.autresraportsprintermarginleft);
                clone.autresraportsprintermarginright = Misc.fromInputNumberNullable(NS + "_autresraportsprintermarginright", state.autresraportsprintermarginright);
                clone.autresraportsprintermargintop = Misc.fromInputNumberNullable(NS + "_autresraportsprintermargintop", state.autresraportsprintermargintop);
                clone.caneditundeliveredpermits = Misc.fromInputTextNullable(NS + "_caneditundeliveredpermits", state.caneditundeliveredpermits);
                clone.ccemail = Misc.fromInputTextNullable(NS + "_ccemail", state.ccemail);
                clone.cletriclientnom = Misc.fromInputTextNullable(NS + "_cletriclientnom", state.cletriclientnom);
                clone.copiepermit1 = Misc.fromInputCheckbox(NS + "_copiepermit1", state.copiepermit1);
                clone.copiepermit2 = Misc.fromInputCheckbox(NS + "_copiepermit2", state.copiepermit2);
                clone.copiepermit3 = Misc.fromInputCheckbox(NS + "_copiepermit3", state.copiepermit3);
                clone.copiepermit4 = Misc.fromInputCheckbox(NS + "_copiepermit4", state.copiepermit4);
                clone.deletefichepassword = Misc.fromInputTextNullable(NS + "_deletefichepassword", state.deletefichepassword);
                clone.emailpermit1 = Misc.fromInputCheckbox(NS + "_emailpermit1", state.emailpermit1);
                clone.emailpermit2 = Misc.fromInputCheckbox(NS + "_emailpermit2", state.emailpermit2);
                clone.emailpermit3 = Misc.fromInputCheckbox(NS + "_emailpermit3", state.emailpermit3);
                clone.emailpermit4 = Misc.fromInputCheckbox(NS + "_emailpermit4", state.emailpermit4);
                clone.excellanguage = Misc.fromInputTextNullable(NS + "_excellanguage", state.excellanguage);
                clone.facturesafficherfraisautrechargepourtransporteur = Misc.fromInputCheckbox(NS + "_facturesafficherfraisautrechargepourtransporteur", state.facturesafficherfraisautrechargepourtransporteur);
                clone.facturesafficherfraisautresproducteur = Misc.fromInputCheckbox(NS + "_facturesafficherfraisautresproducteur", state.facturesafficherfraisautresproducteur);
                clone.facturesafficherfraisautresrevenusproducteur = Misc.fromInputCheckbox(NS + "_facturesafficherfraisautresrevenusproducteur", state.facturesafficherfraisautresrevenusproducteur);
                clone.facturesafficherfraisautresrevenustransporteur = Misc.fromInputCheckbox(NS + "_facturesafficherfraisautresrevenustransporteur", state.facturesafficherfraisautresrevenustransporteur);
                clone.facturesafficherfraisautrestransporteur = Misc.fromInputCheckbox(NS + "_facturesafficherfraisautrestransporteur", state.facturesafficherfraisautrestransporteur);
                clone.facturesafficherfraischargeurproducteur = Misc.fromInputCheckbox(NS + "_facturesafficherfraischargeurproducteur", state.facturesafficherfraischargeurproducteur);
                clone.facturesafficherfraischargeurtransporteur = Misc.fromInputCheckbox(NS + "_facturesafficherfraischargeurtransporteur", state.facturesafficherfraischargeurtransporteur);
                clone.facturesafficherfraiscompensationdedeplacement = Misc.fromInputCheckbox(NS + "_facturesafficherfraiscompensationdedeplacement", state.facturesafficherfraiscompensationdedeplacement);
                clone.facturesaffichersurchargeproducteur = Misc.fromInputCheckbox(NS + "_facturesaffichersurchargeproducteur", state.facturesaffichersurchargeproducteur);
                clone.formicon = Misc.fromInputTextNullable(NS + "_formicon", state.formicon);
                clone.formtext = Misc.fromInputTextNullable(NS + "_formtext", state.formtext);
                clone.fournisseurpointerid = Misc.fromInputNumber(NS + "_fournisseurpointerid", state.fournisseurpointerid);
                clone.fromemail = Misc.fromInputTextNullable(NS + "_fromemail", state.fromemail);
                clone.gpversion = Misc.fromInputTextNullable(NS + "_gpversion", state.gpversion);
                clone.helpfilepath = Misc.fromInputTextNullable(NS + "_helpfilepath", state.helpfilepath);
                clone.imprimanteautresrapports = Misc.fromInputTextNullable(NS + "_imprimanteautresrapports", state.imprimanteautresrapports);
                clone.imprimantedepermis = Misc.fromInputTextNullable(NS + "_imprimantedepermis", state.imprimantedepermis);
                clone.livraisonliertaux = Misc.fromInputCheckbox(NS + "_livraisonliertaux", state.livraisonliertaux);
                clone.logfile = Misc.fromInputTextNullable(NS + "_logfile", state.logfile);
                clone.logopath = Misc.fromInputTextNullable(NS + "_logopath", state.logopath);
                clone.massecontingentvoyagedefaut = Misc.fromInputNumber(NS + "_massecontingentvoyagedefaut", state.massecontingentvoyagedefaut);
                clone.masselimitedefaut = Misc.fromInputNumber(NS + "_masselimitedefaut", state.masselimitedefaut);
                clone.message_autorisationdeslivraisons = Misc.fromInputTextNullable(NS + "_message_autorisationdeslivraisons", state.message_autorisationdeslivraisons);
                clone.message_demandecontingentement = Misc.fromInputTextNullable(NS + "_message_demandecontingentement", state.message_demandecontingentement);
                clone.messageimpressionsdefactures = Misc.fromInputTextNullable(NS + "_messageimpressionsdefactures", state.messageimpressionsdefactures);
                clone.messagelivraisonnonconforme = Misc.fromInputTextNullable(NS + "_messagelivraisonnonconforme", state.messagelivraisonnonconforme);
                clone.messagespecpermitanglais = Misc.fromInputTextNullable(NS + "_messagespecpermitanglais", state.messagespecpermitanglais);
                clone.messagespecpermitfrancais = Misc.fromInputTextNullable(NS + "_messagespecpermitfrancais", state.messagespecpermitfrancais);
                clone.nomdb = Misc.fromInputTextNullable(NS + "_nomdb", state.nomdb);
                clone.permisprintermarginbottom = Misc.fromInputNumberNullable(NS + "_permisprintermarginbottom", state.permisprintermarginbottom);
                clone.permisprintermarginleft = Misc.fromInputNumberNullable(NS + "_permisprintermarginleft", state.permisprintermarginleft);
                clone.permisprintermarginright = Misc.fromInputNumberNullable(NS + "_permisprintermarginright", state.permisprintermarginright);
                clone.permisprintermargintop = Misc.fromInputNumberNullable(NS + "_permisprintermargintop", state.permisprintermargintop);
                clone.permisprintpreview = Misc.fromInputCheckbox(NS + "_permisprintpreview", state.permisprintpreview);
                clone.preleves_notps = Misc.fromInputTextNullable(NS + "_preleves_notps", state.preleves_notps);
                clone.preleves_notvq = Misc.fromInputTextNullable(NS + "_preleves_notvq", state.preleves_notvq);
                clone.serveuremail = Misc.fromInputTextNullable(NS + "_serveuremail", state.serveuremail);
                clone.showyearsinpermislistview = Misc.fromInputTextNullable(NS + "_showyearsinpermislistview", state.showyearsinpermislistview);
                clone.superficiecontingenteepourcentagededuction = Misc.fromInputNumberNullable(NS + "_superficiecontingenteepourcentagededuction", state.superficiecontingenteepourcentagededuction);
                clone.superficiecontingenteesansdeduction = Misc.fromInputNumberNullable(NS + "_superficiecontingenteesansdeduction", state.superficiecontingenteesansdeduction);
                clone.syndicat_codepostal = Misc.fromInputTextNullable(NS + "_syndicat_codepostal", state.syndicat_codepostal);
                clone.syndicat_fax = Misc.fromInputTextNullable(NS + "_syndicat_fax", state.syndicat_fax);
                clone.syndicat_nom = Misc.fromInputTextNullable(NS + "_syndicat_nom", state.syndicat_nom);
                clone.syndicat_nomanglais = Misc.fromInputTextNullable(NS + "_syndicat_nomanglais", state.syndicat_nomanglais);
                clone.syndicat_nomfrancais = Misc.fromInputTextNullable(NS + "_syndicat_nomfrancais", state.syndicat_nomfrancais);
                clone.syndicat_notps = Misc.fromInputTextNullable(NS + "_syndicat_notps", state.syndicat_notps);
                clone.syndicat_notvq = Misc.fromInputTextNullable(NS + "_syndicat_notvq", state.syndicat_notvq);
                clone.syndicat_rue = Misc.fromInputTextNullable(NS + "_syndicat_rue", state.syndicat_rue);
                clone.syndicat_telephone = Misc.fromInputTextNullable(NS + "_syndicat_telephone", state.syndicat_telephone);
                clone.syndicat_ville = Misc.fromInputTextNullable(NS + "_syndicat_ville", state.syndicat_ville);
                clone.syndicatouoffice = Misc.fromInputTextNullable(NS + "_syndicatouoffice", state.syndicatouoffice);
                clone.takeacombabackup = Misc.fromInputCheckbox(NS + "_takeacombabackup", state.takeacombabackup);
                clone.takesqlbackup = Misc.fromInputCheckbox(NS + "_takesqlbackup", state.takesqlbackup);
                clone.tempsentrelesbackupsautomatiques = Misc.fromInputNumberNullable(NS + "_tempsentrelesbackupsautomatiques", state.tempsentrelesbackupsautomatiques);
                clone.timeoutsql = Misc.fromInputNumber(NS + "_timeoutsql", state.timeoutsql);
                clone.typepermis = Misc.fromInputNumber(NS + "_typepermis", state.typepermis);
                clone.typepermis1 = Misc.fromInputTextNullable(NS + "_typepermis1", state.typepermis1);
                clone.typepermis1anglais = Misc.fromInputTextNullable(NS + "_typepermis1anglais", state.typepermis1anglais);
                clone.typepermis1francais = Misc.fromInputTextNullable(NS + "_typepermis1francais", state.typepermis1francais);
                clone.typepermis2 = Misc.fromInputTextNullable(NS + "_typepermis2", state.typepermis2);
                clone.typepermis2anglais = Misc.fromInputTextNullable(NS + "_typepermis2anglais", state.typepermis2anglais);
                clone.typepermis2francais = Misc.fromInputTextNullable(NS + "_typepermis2francais", state.typepermis2francais);
                clone.typepermis3 = Misc.fromInputTextNullable(NS + "_typepermis3", state.typepermis3);
                clone.typepermis3anglais = Misc.fromInputTextNullable(NS + "_typepermis3anglais", state.typepermis3anglais);
                clone.typepermis3francais = Misc.fromInputTextNullable(NS + "_typepermis3francais", state.typepermis3francais);
                clone.typepermis4 = Misc.fromInputTextNullable(NS + "_typepermis4", state.typepermis4);
                clone.typepermis4anglais = Misc.fromInputTextNullable(NS + "_typepermis4anglais", state.typepermis4anglais);
                clone.typepermis4francais = Misc.fromInputTextNullable(NS + "_typepermis4francais", state.typepermis4francais);
                clone.updateotherdatabase = Misc.fromInputTextNullable(NS + "_updateotherdatabase", state.updateotherdatabase);
                clone.utiliselesychronisateurdirect = Misc.fromInputCheckbox(NS + "_utiliselesychronisateurdirect", state.utiliselesychronisateurdirect);
                clone.utiliserlesnomsdemachinedanslenomdeprinter = Misc.fromInputCheckbox(NS + "_utiliserlesnomsdemachinedanslenomdeprinter", state.utiliserlesnomsdemachinedanslenomdeprinter);
                clone.utiliserlotscontingentes = Misc.fromInputCheckbox(NS + "_utiliserlotscontingentes", state.utiliserlotscontingentes);
                clone.xlstemplatespath = Misc.fromInputTextNullable(NS + "_xlstemplatespath", state.xlstemplatespath);
                clone.fournisseur_planconjoint = Misc.fromSelectText(NS + "_fournisseur_planconjoint", state.fournisseur_planconjoint);
                clone.fournisseur_surcharge = Misc.fromSelectText(NS + "_fournisseur_surcharge", state.fournisseur_surcharge);
                clone.compte_paiements = Misc.fromSelectNumber(NS + "_compte_paiements", state.compte_paiements);
                clone.compte_arecevoir = Misc.fromSelectNumber(NS + "_compte_arecevoir", state.compte_arecevoir);
                clone.compte_apayer = Misc.fromSelectNumber(NS + "_compte_apayer", state.compte_apayer);
                clone.compte_duauxproducteurs = Misc.fromSelectNumber(NS + "_compte_duauxproducteurs", state.compte_duauxproducteurs);
                clone.compte_tpspercues = Misc.fromSelectNumber(NS + "_compte_tpspercues", state.compte_tpspercues);
                clone.compte_tpspayees = Misc.fromSelectNumber(NS + "_compte_tpspayees", state.compte_tpspayees);
                clone.compte_tvqpercues = Misc.fromSelectNumber(NS + "_compte_tvqpercues", state.compte_tvqpercues);
                clone.compte_tvqpayees = Misc.fromSelectNumber(NS + "_compte_tvqpayees", state.compte_tvqpayees);
                clone.taux_tps = Misc.fromInputNumberNullable(NS + "_taux_tps", state.taux_tps);
                clone.taux_tvq = Misc.fromInputNumberNullable(NS + "_taux_tvq", state.taux_tvq);
                clone.fournisseur_fond_roulement = Misc.fromSelectText(NS + "_fournisseur_fond_roulement", state.fournisseur_fond_roulement);
                clone.fournisseur_fond_forestier = Misc.fromSelectText(NS + "_fournisseur_fond_forestier", state.fournisseur_fond_forestier);
                clone.fournisseur_preleve_divers = Misc.fromSelectText(NS + "_fournisseur_preleve_divers", state.fournisseur_preleve_divers);
                return clone;
            };
            valid = function (formState) {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = function () {
                document.getElementById(NS + "_dummy_submit").click();
                var form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_41("onchange", onchange = function (input) {
                state = getFormState();
                App.render();
            });
            exports_41("cancel", cancel = function () {
                Router.goBackOrResume(isDirty);
            });
            exports_41("create", create = function () {
                var formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST("/company", Misc.createBlack(formState, blackList))
                    .then(function (payload) {
                    var newkey = payload;
                    Misc.toastSuccessSave();
                    Router.goto("#/admin/company/" + newkey.cie, 10);
                })
                    .catch(App.render);
            });
            exports_41("save", save = function (done) {
                if (done === void 0) { done = false; }
                var formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.PUT("/company", Misc.createBlack(formState, blackList))
                    .then(function (_) {
                    Misc.toastSuccessSave();
                    if (done)
                        Router.goto("#/admin/companys/", 100);
                    else
                        Router.goto("#/admin/company/" + key.cie, 10);
                })
                    .catch(App.render);
            });
            exports_41("drop", drop = function () {
                key.updated = state.updated;
                App.prepareRender();
                App.DELETE("/company", key)
                    .then(function (_) {
                    Router.goto("#/admin/companys/", 250);
                })
                    .catch(App.render);
            });
            dirtyExit = function () {
                isDirty = !Misc.same(fetchedState, getFormState());
                if (isDirty) {
                    setTimeout(function () {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
System.register("src/admin/main", ["_BaseApp/src/core/router", "src/admin/accounts", "src/admin/account", "src/admin/companys", "src/admin/company"], function (exports_42, context_42) {
    "use strict";
    var Router, accounts, account, companys, company, startup, render, postRender;
    var __moduleName = context_42 && context_42.id;
    return {
        setters: [
            function (Router_9) {
                Router = Router_9;
            },
            function (accounts_1) {
                accounts = accounts_1;
            },
            function (account_1) {
                account = account_1;
            },
            function (companys_1) {
                companys = companys_1;
            },
            function (company_1) {
                company = company_1;
            }
        ],
        execute: function () {
            //import * as DataFiles from "./datafiles"
            //import * as DataFile from "./datafile"
            //import * as Lookups from "./lookups"
            //import * as Lookup from "./lookup"
            //
            // Global references to application objects
            // These must match the "NS" values defined in modules
            // Mainly used for event handlers
            //
            window.App_accounts = accounts;
            window.App_account = account;
            //(<any>window).App_profile = profile;
            window.App_companys = companys;
            window.App_company = company;
            //(<any>window).App_DataFiles = DataFiles;
            //(<any>window).App_DataFile = DataFile;
            //(<any>window).App_Lookups = Lookups;
            //(<any>window).App_Lookup = Lookup;
            exports_42("startup", startup = function () {
                Router.addRoute("^#/admin/accounts/?(.*)?$", accounts.fetch);
                Router.addRoute("^#/admin/account/(.*)$", account.fetch);
                Router.addRoute("^#/admin/companys/?(.*)?$", companys.fetch);
                Router.addRoute("^#/admin/company/(.*)$", company.fetch);
                //Router.addRoute("^#/files/(.*)$", DataFiles.fetch);
                //Router.addRoute("^#/file/(.*)$", DataFile.fetch);
                //Router.addRoute("^#/admin/lookups/?(.*)$", Lookups.fetch);
                //Router.addRoute("^#/admin/lookup/(.*)$", Lookup.fetch);
                //Router.addRoute("^#/admin/audittrails/?(.*)$", AuditTrails.fetch);
            });
            exports_42("render", render = function () {
                return "\n    " + accounts.render() + "\n    " + account.render() + "\n    " + companys.render() + "\n    " + company.render() + "\n";
                //${DataFiles.render()}
                //${DataFile.render()}
                //${Lookups.render()}
                //${Lookup.render()}
            });
            exports_42("postRender", postRender = function () {
                accounts.postRender();
                account.postRender();
                companys.postRender();
                company.postRender();
                //DataFiles.postRender();
                //DataFile.postRender();
                //Lookups.postRender();
                //Lookup.postRender();
            });
        }
    };
});
System.register("src/fournisseur/layout", ["_BaseApp/src/core/app", "src/layout"], function (exports_43, context_43) {
    "use strict";
    var App, layout_5, icon, prepareMenu, tabTemplate, buildTitle, buildSubtitle;
    var __moduleName = context_43 && context_43.id;
    return {
        setters: [
            function (App_15) {
                App = App_15;
            },
            function (layout_5_1) {
                layout_5 = layout_5_1;
            }
        ],
        execute: function () {
            exports_43("icon", icon = "far fa-user");
            exports_43("prepareMenu", prepareMenu = function () {
                layout_5.setOpenedMenu("Fournisseur-Propriétaires");
            });
            exports_43("tabTemplate", tabTemplate = function (id, xtra, isNew) {
                if (isNew === void 0) { isNew = false; }
                var isProprietaires = App.inContext("App_proprietaires");
                var isProprietaire = App.inContext("App_proprietaire");
                var isFiles = window.location.hash.startsWith("#/files/proprietaire");
                var isFile = window.location.hash.startsWith("#/file/proprietaire");
                var showDetail = !isProprietaires;
                var showFiles = showDetail && xtra;
                var showFile = isFile;
                return "\n<div class=\"tabs is-boxed\">\n    <ul>\n        <li " + (isProprietaires ? "class='is-active'" : "") + ">\n            <a href=\"#/proprietaires\">\n                <span class=\"icon\"><i class=\"fas fa-list-ol\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("List") + "</span>\n            </a>\n        </li>\n" + (showDetail ? "\n        <li " + (isProprietaire ? "class='is-active'" : "") + ">\n            <a href=\"#/proprietaire/" + id + "\">\n                <span class=\"icon\"><i class=\"" + icon + "\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("Proprietaire Details") + "</span>\n            </a>\n        </li>\n" : "") + "\n" + (showFiles ? "\n        <li " + (isFiles ? "class='is-active'" : "") + ">\n            <a href=\"#/files/proprietaire/" + id + "\">\n                <span class=\"icon\"><i class=\"far fa-paperclip\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("Files") + " (" + xtra.filecount + ")</span>\n            </a>\n        </li>\n" : "") + "\n" + (showFile ? "\n        <li " + (isFile ? "class='is-active'" : "") + ">\n            <a href=\"#/file/proprietaire/" + id + "\">\n                <span class=\"icon\"><i class=\"far fa-paperclip\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("File Details") + "</span>\n            </a>\n        </li>\n" : "") + "\n\n    </ul>\n</div>\n";
            });
            exports_43("buildTitle", buildTitle = function (xtra, defaultText) {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.title) !== null && _a !== void 0 ? _a : defaultText;
            });
            exports_43("buildSubtitle", buildSubtitle = function (xtra, defaultText) {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.subtitle) !== null && _a !== void 0 ? _a : defaultText;
            });
        }
    };
});
// File: proprietaires.ts
System.register("src/fournisseur/proprietaires", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/lookupdata", "src/fournisseur/layout"], function (exports_44, context_44) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, Lookup, layout_6, NS, key, state, xtra, uiSelectedRow, filterTemplate, trTemplate, tableTemplate, pageTemplate, fetchState, fetch, refresh, render, postRender, inContext, setSelectedRow, isSelectedRow, goto, sortBy, search, filter_nom, gotoDetail;
    var __moduleName = context_44 && context_44.id;
    return {
        setters: [
            function (App_16) {
                App = App_16;
            },
            function (Router_10) {
                Router = Router_10;
            },
            function (Perm_4) {
                Perm = Perm_4;
            },
            function (Misc_17) {
                Misc = Misc_17;
            },
            function (Theme_5) {
                Theme = Theme_5;
            },
            function (Pager_3) {
                Pager = Pager_3;
            },
            function (Lookup_4) {
                Lookup = Lookup_4;
            },
            function (layout_6_1) {
                layout_6 = layout_6_1;
            }
        ],
        execute: function () {
            exports_44("NS", NS = "App_proprietaires");
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 20, sortColumn: "ID", sortDirection: "ASC", filter: { nom: undefined } }
            };
            filterTemplate = function () {
                var filters = [];
                // TODO (filters textbox)
                return filters.join("");
            };
            trTemplate = function (item, rowNumber) {
                return "\n<tr class=\"" + (isSelectedRow(item.id) ? "is-selected" : "") + "\" onclick=\"" + NS + ".gotoDetail('" + item.id + "');\">\n    <td class=\"js-index\">" + rowNumber + "</td>\n    <td>" + Misc.toStaticText(item.id) + "</td>\n    <td>" + Misc.toStaticText(item.cletri) + "</td>\n    <td>" + Misc.toStaticText(item.nom) + "</td>\n    <td>" + Misc.toStaticText(item.ausoinsde) + "</td>\n    <td>" + Misc.toStaticText(item.rue) + "</td>\n    <td>" + Misc.toStaticText(item.ville) + "</td>\n    <td>" + Misc.toStaticText(item.paysid_text) + "</td>\n    <td>" + Misc.toStaticText(item.code_postal) + "</td>\n    <td>" + Misc.toStaticText(item.telephone) + "</td>\n    <td>" + Misc.toStaticText(item.telephone_poste) + "</td>\n    <td>" + Misc.toStaticText(item.telecopieur) + "</td>\n    <td>" + Misc.toStaticText(item.telephone2) + "</td>\n    <td>" + Misc.toStaticText(item.telephone2_desc) + "</td>\n    <td>" + Misc.toStaticText(item.telephone2_poste) + "</td>\n    <td>" + Misc.toStaticText(item.telephone3) + "</td>\n    <td>" + Misc.toStaticText(item.telephone3_desc) + "</td>\n    <td>" + Misc.toStaticText(item.telephone3_poste) + "</td>\n    <td>" + Misc.toStaticText(item.no_membre) + "</td>\n    <td>" + Misc.toStaticText(item.resident) + "</td>\n    <td>" + Misc.toStaticText(item.email) + "</td>\n    <td>" + Misc.toStaticText(item.www) + "</td>\n    <td>" + Misc.toStaticText(item.commentaires) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.affichercommentaires) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.depotdirect) + "</td>\n    <td>" + Misc.toStaticText(item.institutionbanquaireid_text) + "</td>\n    <td>" + Misc.toStaticText(item.banque_transit) + "</td>\n    <td>" + Misc.toStaticText(item.banque_folio) + "</td>\n    <td>" + Misc.toStaticText(item.no_tps) + "</td>\n    <td>" + Misc.toStaticText(item.no_tvq) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.payera) + "</td>\n    <td>" + Misc.toStaticText(item.payeraid) + "</td>\n    <td>" + Misc.toStaticText(item.statut) + "</td>\n    <td>" + Misc.toStaticText(item.rep_nom) + "</td>\n    <td>" + Misc.toStaticText(item.rep_telephone) + "</td>\n    <td>" + Misc.toStaticText(item.rep_telephone_poste) + "</td>\n    <td>" + Misc.toStaticText(item.rep_email) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.enanglais) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.actif) + "</td>\n    <td>" + Misc.toStaticText(item.mrcproducteurid) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.paiementmanuel) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.journal) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.recoittps) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.recoittvq) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.modifiertrigger) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.isproducteur) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.istransporteur) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.ischargeur) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.isautre) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.affichercommentairessurpermit) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.pasemissionpermis) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.generique) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.membre_ogc) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.inscrittps) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.inscrittvq) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.isogc) + "</td>\n    <td>" + Misc.toStaticText(item.rep2_nom) + "</td>\n    <td>" + Misc.toStaticText(item.rep2_telephone) + "</td>\n    <td>" + Misc.toStaticText(item.rep2_telephone_poste) + "</td>\n    <td>" + Misc.toStaticText(item.rep2_email) + "</td>\n    <td>" + Misc.toStaticText(item.rep2_commentaires) + "</td>\n</tr>";
            };
            tableTemplate = function (tbody, pager) {
                return "\n<div class=\"table-container\">\n<table class=\"table is-hoverable is-fullwidth\">\n    <thead>\n        <tr>\n            <th></th>\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ID"), "id", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("CLETRI"), "cletri", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("NOM"), "nom", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("AUSOINSDE"), "ausoinsde", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("RUE"), "rue", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("VILLE"), "ville", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PAYSID_TEXT"), "paysid_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("CODE_POSTAL"), "code_postal", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE"), "telephone", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE_POSTE"), "telephone_poste", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TELECOPIEUR"), "telecopieur", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE2"), "telephone2", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE2_DESC"), "telephone2_desc", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE2_POSTE"), "telephone2_poste", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE3"), "telephone3", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE3_DESC"), "telephone3_desc", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("TELEPHONE3_POSTE"), "telephone3_poste", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("NO_MEMBRE"), "no_membre", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("RESIDENT"), "resident", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("EMAIL"), "email", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("WWW"), "www", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("COMMENTAIRES"), "commentaires", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERCOMMENTAIRES"), "affichercommentaires", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("DEPOTDIRECT"), "depotdirect", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("INSTITUTIONBANQUAIREID_TEXT"), "institutionbanquaireid_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("BANQUE_TRANSIT"), "banque_transit", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("BANQUE_FOLIO"), "banque_folio", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("NO_TPS"), "no_tps", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("NO_TVQ"), "no_tvq", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PAYERA"), "payera", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PAYERAID"), "payeraid", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("STATUT"), "statut", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("REP_NOM"), "rep_nom", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("REP_TELEPHONE"), "rep_telephone", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("REP_TELEPHONE_POSTE"), "rep_telephone_poste", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("REP_EMAIL"), "rep_email", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ENANGLAIS"), "enanglais", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ACTIF"), "actif", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("MRCPRODUCTEURID"), "mrcproducteurid", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PAIEMENTMANUEL"), "paiementmanuel", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("JOURNAL"), "journal", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("RECOITTPS"), "recoittps", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("RECOITTVQ"), "recoittvq", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("MODIFIERTRIGGER"), "modifiertrigger", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ISPRODUCTEUR"), "isproducteur", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ISTRANSPORTEUR"), "istransporteur", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ISCHARGEUR"), "ischargeur", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ISAUTRE"), "isautre", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERCOMMENTAIRESSURPERMIT"), "affichercommentairessurpermit", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PASEMISSIONPERMIS"), "pasemissionpermis", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("GENERIQUE"), "generique", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("MEMBRE_OGC"), "membre_ogc", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("INSCRITTPS"), "inscrittps", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("INSCRITTVQ"), "inscrittvq", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ISOGC"), "isogc", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("REP2_NOM"), "rep2_nom", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("REP2_TELEPHONE"), "rep2_telephone", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("REP2_TELEPHONE_POSTE"), "rep2_telephone_poste", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("REP2_EMAIL"), "rep2_email", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("REP2_COMMENTAIRES"), "rep2_commentaires", "ASC") + "\n            " + Pager.headerLink(i18n("TODO")) + "\n        </tr>\n    </thead>\n    <tbody>\n        " + tbody + "\n    </tbody>\n</table>\n</div>\n";
            };
            pageTemplate = function (pager, table, tab, warning, dirty) {
                var readonly = false;
                var buttons = [];
                buttons.push(Theme.buttonAddNew(NS, "#/proprietaire/new", i18n("Add New")));
                var actions = Theme.renderButtons(buttons);
                var title = layout_6.buildTitle(xtra, i18n("fournisseurs title"));
                var subtitle = layout_6.buildSubtitle(xtra, i18n("fournisseurs subtitle"));
                return "\n<form onsubmit=\"return false;\">\n<input type=\"submit\" style=\"display:none;\" id=\"" + NS + "_dummy_submit\">\n\n<div class=\"js-fixed-heading\">\n<div class=\"js-head\">\n    <div class=\"content js-uc-heading js-flex-space\">\n        <div>\n            <div class=\"title\"><i class=\"" + layout_6.icon + "\"></i> <span>" + title + "</span></div>\n            <div class=\"subtitle\">" + subtitle + "</div>\n        </div>\n        <div>\n            " + Theme.wrapContent("js-uc-actions", actions) + "\n        </div>\n    </div>\n    " + Theme.wrapContent("js-uc-tabs", tab) + "\n</div>\n<div class=\"js-body\">\n    " + Theme.wrapContent("js-uc-notification", dirty) + "\n    " + Theme.wrapContent("js-uc-notification", warning) + "\n    " + Theme.wrapContent("js-uc-pager", pager) + "\n    " + Theme.wrapContent("js-uc-list", table) + "\n</div>\n</div>\n\n</form>\n";
            };
            exports_44("fetchState", fetchState = function (id) {
                Router.registerDirtyExit(null);
                return App.POST("/fournisseur/search", state.pager)
                    .then(function (payload) {
                    state = payload;
                    xtra = payload.xtra;
                    key = {};
                })
                    .then(Lookup.fetch_pays())
                    .then(Lookup.fetch_institutionBanquaire());
            });
            exports_44("fetch", fetch = function (params) {
                var id = params[0];
                App.prepareRender(NS, i18n("fournisseurs"));
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            refresh = function () {
                App.prepareRender(NS, i18n("fournisseurs"));
                App.POST("/fournisseur/search", state.pager)
                    .then(function (payload) {
                    state = payload;
                })
                    .then(App.render)
                    .catch(App.render);
            };
            exports_44("render", render = function () {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
                    return App.warningTemplate() || App.unexpectedTemplate();
                var warning = App.warningTemplate();
                var dirty = "";
                var tbody = state.list.reduce(function (html, item, index) {
                    var rowNumber = Pager.rowNumber(state.pager, index);
                    return html + trTemplate(item, rowNumber);
                }, "");
                var year = Perm.getCurrentYear(); //state.pager.filter.year;
                var filter = filterTemplate();
                var search = Pager.searchTemplate(state.pager, NS);
                var pager = Pager.render(state.pager, NS, [20, 50], search, filter);
                var table = tableTemplate(tbody, state.pager);
                var tab = layout_6.tabTemplate(null, null);
                return pageTemplate(pager, table, tab, dirty, warning);
            });
            exports_44("postRender", postRender = function () {
                if (!inContext())
                    return;
            });
            exports_44("inContext", inContext = function () {
                return App.inContext(NS);
            });
            setSelectedRow = function (id) {
                if (uiSelectedRow == undefined)
                    uiSelectedRow = { id: id };
                uiSelectedRow.id = id;
            };
            isSelectedRow = function (id) {
                if (uiSelectedRow == undefined)
                    return false;
                return (uiSelectedRow.id == id);
            };
            exports_44("goto", goto = function (pageNo, pageSize) {
                state.pager.pageNo = pageNo;
                state.pager.pageSize = pageSize;
                refresh();
            });
            exports_44("sortBy", sortBy = function (columnName, direction) {
                state.pager.pageNo = 1;
                state.pager.sortColumn = columnName;
                state.pager.sortDirection = direction;
                refresh();
            });
            exports_44("search", search = function (element) {
                state.pager.searchText = element.value;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_44("filter_nom", filter_nom = function (element) {
                // TODO (filterDef)
            });
            exports_44("gotoDetail", gotoDetail = function (id) {
                setSelectedRow(id);
                Router.goto("#/proprietaire/" + id);
            });
        }
    };
});
// File: lots2.ts
System.register("src/fournisseur/lots2", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/lookupdata"], function (exports_45, context_45) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, Lookup, NS, table_id, key, state, fetchedState, isNew, callerNS, isAddingNewParent, trTemplate, tableTemplate, pageTemplate, fetchState, preRender, render, postRender, inContext, getFormState, html5Valid, onchange, undo, addNew, create, save, selectfordrop, drop, hasChanges;
    var __moduleName = context_45 && context_45.id;
    return {
        setters: [
            function (App_17) {
                App = App_17;
            },
            function (Router_11) {
                Router = Router_11;
            },
            function (Perm_5) {
                Perm = Perm_5;
            },
            function (Misc_18) {
                Misc = Misc_18;
            },
            function (Theme_6) {
                Theme = Theme_6;
            },
            function (Pager_4) {
                Pager = Pager_4;
            },
            function (Lookup_5) {
                Lookup = Lookup_5;
            }
        ],
        execute: function () {
            exports_45("NS", NS = "App_lots2");
            table_id = "lots2_table";
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 1000, sortColumn: "ID", sortDirection: "ASC", filter: {} }
            };
            fetchedState = {};
            isNew = false;
            isAddingNewParent = false;
            trTemplate = function (item, editId, deleteId, rowNumber, lotid) {
                var id = item.id;
                var tdConfirm = "<td class=\"js-td-33\">&nbsp;</td>";
                if (item._editing)
                    tdConfirm = "<td onclick=\"" + NS + ".save()\" class=\"js-td-33\" title=\"Click to confirm\"><i class=\"fa fa-check\"></i></td>";
                if (item._deleting)
                    tdConfirm = "<td onclick=\"" + NS + ".drop()\" class=\"js-td-33\" title=\"Click to confirm\"><i class=\"fa fa-check\"></i></td>";
                if (item._isNew)
                    tdConfirm = "<td onclick=\"" + NS + ".create()\" class=\"js-td-33\" title=\"Click to confirm\"><i class=\"fa fa-check\"></i></td>";
                var clickUndo = item._editing || item._deleting || item._isNew;
                var markDeletion = !clickUndo;
                var readonly = (deleteId != undefined) || (editId != undefined && id != editId) || (isNew && !item._isNew);
                var classList = [];
                if (item._editing || item._isNew)
                    classList.push("js-not-same");
                if (item._deleting)
                    classList.push("js-strikeout");
                if (item._isNew)
                    classList.push("js-new");
                if (readonly)
                    classList.push("js-readonly");
                return "\n<tr data-id=\"" + id + "\" class=\"" + classList.join(" ") + "\" style=\"cursor: pointer;\">\n    <td class=\"js-index\">" + rowNumber + "</td>\n\n" + (markDeletion ? "<td onclick=\"" + NS + ".selectfordrop(" + id + ")\" class=\"has-text-danger\" title=\"Click to mark for deletion\"><i class='fas fa-times'></i></td>" : "") + "\n" + (clickUndo ? "<td onclick=\"" + NS + ".undo()\" class=\"has-text-primary\" title=\"Click to undo\"><i class='fa fa-undo'></i></td>" : "") + "\n" + tdConfirm + "\n\n" + (!readonly ? "\n    <td class=\"js-inline-input\">" + Theme.renderDateInline(NS, "datedebut_" + id, item.datedebut, { required: true }) + "</td>\n    <td class=\"js-inline-input\">" + Theme.renderDateInline(NS, "datefin_" + id, item.datefin, { required: false }) + "</td>\n    <td class=\"js-inline-select\">" + Theme.renderDropdownInline(NS, "lotid_" + id, lotid, true) + "</td>\n" : "\n    <td>" + Misc.toInputDate(item.datedebut) + "</td>\n    <td>" + Misc.toInputDate(item.datefin) + "</td>\n    <td>" + Misc.toStaticText(item.lotid_text) + "</td>\n") + "\n</tr>";
            };
            tableTemplate = function (tbody, editId, deleteId, perm) {
                var disableAddNew = (deleteId != undefined || editId != undefined || isNew);
                var canEdit = perm && perm.canEdit;
                disableAddNew = disableAddNew || !canEdit;
                return "\n<style>.js-td-33 { width: 33px; }</style>\n<div id=\"" + table_id + "\" class=\"table-container\">\n<table class=\"table is-hoverable js-inline\" style=\"width: 100px; table-layout: fixed;\">\n    <thead>\n        <tr>\n            <th style=\"width:99px\" colspan=\"3\">\n                <a class=\"button is-primary is-outlined is-small\" " + (disableAddNew ? "disabled" : "onclick=\"" + NS + ".addNew()\"") + ">\n                    <span class=\"icon\"><i class=\"fa fa-plus\"></i></span><span>" + i18n("Add New") + "</span>\n                </a>\n            </th>\n            <th style=\"width:100px\">" + i18n("DATEDEBUT") + "</th>\n            <th style=\"width:100px\">" + i18n("DATEFIN") + "</th>\n            <th style=\"width:100px\">" + i18n("LOT") + "</th>\n        </tr>\n    </thead>\n    <tbody>\n        " + tbody + "\n    </tbody>\n</table>\n</div>\n";
            };
            pageTemplate = function (table) {
                return "\n" + Theme.wrapContent("js-uc-list", table) + "\n";
            };
            exports_45("fetchState", fetchState = function (proprietaireid, ownerNS) {
                isAddingNewParent = (proprietaireid == "new");
                callerNS = ownerNS || callerNS;
                isNew = false;
                return App.GET("/lot_proprietaire/search/" + proprietaireid + "/?" + Pager.asParams(state.pager))
                    .then(function (payload) {
                    state = payload;
                    fetchedState = Misc.clone(state);
                    key = { proprietaireid: proprietaireid };
                })
                    .then(Lookup.fetch_lot());
            });
            exports_45("preRender", preRender = function () {
            });
            exports_45("render", render = function () {
                if (isAddingNewParent)
                    return "";
                var editId;
                var deleteId;
                state.list.forEach(function (item, index) {
                    var prevItem = fetchedState.list[index];
                    item._editing = !Misc.same(item, prevItem);
                    if (item._editing)
                        editId = item.id;
                    if (item._deleting)
                        deleteId = item.id;
                });
                var year = Perm.getCurrentYear();
                var lookup_lot = Lookup.get_lot(year);
                var tbody = state.list.reduce(function (html, item, index) {
                    var rowNumber = Pager.rowNumber(state.pager, index);
                    var lotid = Theme.renderOptions(lookup_lot, item.lotid, isNew);
                    return html + trTemplate(item, editId, deleteId, rowNumber, lotid);
                }, "");
                var table = tableTemplate(tbody, editId, deleteId, null);
                return pageTemplate(table);
            });
            exports_45("postRender", postRender = function () {
            });
            exports_45("inContext", inContext = function () {
                return App.inContext(NS);
            });
            getFormState = function () {
                var clone = Misc.clone(state);
                clone.list.forEach(function (item) {
                    var id = item.id;
                    item.proprietaireid = Misc.fromSelectText(NS + "_proprietaireid_" + id, item.proprietaireid);
                    item.datedebut = Misc.fromInputDate(NS + "_datedebut_" + id, item.datedebut);
                    item.datefin = Misc.fromInputDateNullable(NS + "_datefin_" + id, item.datefin);
                    item.lotid = Misc.fromSelectNumber(NS + "_lotid_" + id, item.lotid);
                });
                return clone;
            };
            html5Valid = function () {
                document.getElementById(callerNS + "_dummy_submit").click();
                var form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_45("onchange", onchange = function (input) {
                state = getFormState();
                App.render();
            });
            exports_45("undo", undo = function () {
                if (isNew) {
                    isNew = false;
                    fetchedState.list.pop();
                }
                state = Misc.clone(fetchedState);
                App.render();
            });
            exports_45("addNew", addNew = function () {
                var url = "/lot_proprietaire/new/" + key.proprietaireid;
                return App.GET(url)
                    .then(function (payload) {
                    state.list.push(payload);
                    fetchedState = Misc.clone(state);
                    isNew = true;
                    payload._isNew = true;
                })
                    .then(App.render)
                    .catch(App.render);
            });
            exports_45("create", create = function () {
                var formState = getFormState();
                var item = formState.list.find(function (one) { return one._isNew; });
                if (!html5Valid())
                    return;
                App.prepareRender();
                App.POST("/lot_proprietaire", item)
                    .then(function () {
                    fetchedState = Misc.clone(state);
                    Router.gotoCurrent(1);
                })
                    .catch(App.render);
            });
            exports_45("save", save = function () {
                var formState = getFormState();
                var item = formState.list.find(function (one) { return one._editing; });
                if (!html5Valid())
                    return;
                App.prepareRender();
                App.PUT("/lot_proprietaire", item)
                    .then(function () {
                    fetchedState = Misc.clone(state);
                    Router.gotoCurrent(1);
                })
                    .catch(App.render);
            });
            exports_45("selectfordrop", selectfordrop = function (id) {
                state = Misc.clone(fetchedState);
                state.list.find(function (one) { return one.id == id; })._deleting = true;
                App.render();
            });
            exports_45("drop", drop = function () {
                App.prepareRender();
                var item = state.list.find(function (one) { return one._deleting; });
                App.DELETE("/lot_proprietaire", { id: item.id })
                    .then(function () {
                    fetchedState = Misc.clone(state);
                    Router.gotoCurrent(1);
                })
                    .catch(App.render);
            });
            exports_45("hasChanges", hasChanges = function () {
                return !Misc.same(fetchedState, state);
            });
        }
    };
});
// File: proprietaire.ts
System.register("src/fournisseur/proprietaire", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "src/admin/lookupdata", "src/fournisseur/layout", "src/fournisseur/lots2"], function (exports_46, context_46) {
    "use strict";
    var App, Router, Misc, Theme, Lookup, layout_7, app_inline2, NS, blackList, key, state, xtra, fetchedState, isNew, isDirty, block_address, block_telephone, block_ciel, block_internet, block_autres, block_depotdirect, block_representant, block_camions, formTemplate, pageTemplate, dirtyTemplate, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, onchange, cancel, create, save, drop, dirtyExit;
    var __moduleName = context_46 && context_46.id;
    return {
        setters: [
            function (App_18) {
                App = App_18;
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
            function (Lookup_6) {
                Lookup = Lookup_6;
            },
            function (layout_7_1) {
                layout_7 = layout_7_1;
            },
            function (app_inline2_1) {
                app_inline2 = app_inline2_1;
            }
        ],
        execute: function () {
            exports_46("NS", NS = "App_proprietaire");
            blackList = ["paysid_text", "institutionbanquaireid_text"];
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            block_address = function (item, paysid) {
                return "\n    " + Theme.renderTextField(NS, "nom", item.nom, i18n("NOM"), 40) + "\n    " + Theme.renderTextField(NS, "ausoinsde", item.ausoinsde, i18n("AUSOINSDE"), 30) + "\n    " + Theme.renderTextField(NS, "rue", item.rue, i18n("RUE"), 30) + "\n    " + Theme.renderTextField(NS, "ville", item.ville, i18n("VILLE"), 30) + "\n    " + Theme.renderDropdownField(NS, "paysid", paysid, i18n("PAYSID")) + "\n    " + Theme.renderTextField(NS, "code_postal", item.code_postal, i18n("CODE_POSTAL"), 7) + "\n";
            };
            block_telephone = function (item) {
                return "\n    " + Theme.renderTextField(NS, "telephone", item.telephone, i18n("TELEPHONE"), 12) + "\n    " + Theme.renderTextField(NS, "telephone_poste", item.telephone_poste, i18n("TELEPHONE_POSTE"), 4) + "\n    " + Theme.renderTextField(NS, "telecopieur", item.telecopieur, i18n("TELECOPIEUR"), 12) + "\n\n    " + Theme.renderTextField(NS, "telephone2_desc", item.telephone2_desc, i18n("TELEPHONE2_DESC"), 20) + "\n    " + Theme.renderTextField(NS, "telephone2", item.telephone2, i18n("TELEPHONE2"), 12) + "\n    " + Theme.renderTextField(NS, "telephone2_poste", item.telephone2_poste, i18n("TELEPHONE2_POSTE"), 4) + "\n\n    " + Theme.renderTextField(NS, "telephone3_desc", item.telephone3_desc, i18n("TELEPHONE3_DESC"), 20) + "\n    " + Theme.renderTextField(NS, "telephone3", item.telephone3, i18n("TELEPHONE3"), 12) + "\n    " + Theme.renderTextField(NS, "telephone3_poste", item.telephone3_poste, i18n("TELEPHONE3_POSTE"), 4) + "\n";
            };
            block_ciel = function (item) {
                return "\n    " + Theme.renderTextField(NS, "statut", item.statut, i18n("STATUT"), 50) + "\n    " + Theme.renderTextField(NS, "resident", item.resident, i18n("RESIDENT"), 1) + "\n    " + Theme.renderTextField(NS, "no_membre", item.no_membre, i18n("NO_MEMBRE"), 10) + "\n";
            };
            block_internet = function (item) {
                return "\n    " + Theme.renderTextField(NS, "email", item.email, i18n("EMAIL"), 80) + "\n    " + Theme.renderTextField(NS, "www", item.www, i18n("WWW"), 80) + "\n";
            };
            block_autres = function (item) {
                return "\n    " + Theme.renderTextField(NS, "id", item.id, i18n("ID"), 15, true) + "\n\n    " + Theme.renderCheckboxField(NS, "isproducteur", item.isproducteur, i18n("ISPRODUCTEUR")) + "\n    " + Theme.renderCheckboxField(NS, "istransporteur", item.istransporteur, i18n("ISTRANSPORTEUR")) + "\n    " + Theme.renderCheckboxField(NS, "ischargeur", item.ischargeur, i18n("ISCHARGEUR")) + "\n    " + Theme.renderCheckboxField(NS, "isogc", item.isogc, i18n("ISOGC")) + "\n    " + Theme.renderCheckboxField(NS, "isautre", item.isautre, i18n("ISAUTRE")) + "\n\n    " + Theme.renderTextareaField(NS, "commentaires", item.commentaires, i18n("COMMENTAIRES"), 255, false, null, 5) + "\n    " + Theme.renderCheckboxField(NS, "affichercommentaires", item.affichercommentaires, i18n("AFFICHERCOMMENTAIRES")) + "\n    " + Theme.renderCheckboxField(NS, "affichercommentairessurpermit", item.affichercommentairessurpermit, i18n("AFFICHERCOMMENTAIRESSURPERMIT")) + "\n\n    " + Theme.renderCheckboxField(NS, "actif", item.actif, i18n("ACTIF")) + "\n    " + Theme.renderCheckboxField(NS, "journal", item.journal, i18n("JOURNAL")) + "\n    " + Theme.renderCheckboxField(NS, "pasemissionpermis", item.pasemissionpermis, i18n("PASEMISSIONPERMIS")) + "\n\n    " + Theme.renderCheckboxField(NS, "enanglais", item.enanglais, i18n("ENANGLAIS")) + "\n    " + Theme.renderCheckboxField(NS, "generique", item.generique, i18n("GENERIQUE")) + "\n    " + Theme.renderCheckboxField(NS, "membre_ogc", item.membre_ogc, i18n("MEMBRE_OGC")) + "\n";
            };
            block_depotdirect = function (item, institutionbanquaireid) {
                return "\n    " + Theme.renderCheckboxField(NS, "depotdirect", item.depotdirect, i18n("DEPOTDIRECT")) + "\n\n    " + Theme.renderDropdownField(NS, "institutionbanquaireid", institutionbanquaireid, i18n("INSTITUTIONBANQUAIREID")) + "\n    " + Theme.renderTextField(NS, "banque_transit", item.banque_transit, i18n("BANQUE_TRANSIT"), 5) + "\n    " + Theme.renderTextField(NS, "banque_folio", item.banque_folio, i18n("BANQUE_FOLIO"), 12) + "\n\n    " + Theme.renderTextField(NS, "no_tps", item.no_tps, i18n("NO_TPS"), 25) + "\n    " + Theme.renderCheckboxField(NS, "recoittps", item.recoittps, i18n("RECOITTPS")) + "\n    " + Theme.renderCheckboxField(NS, "inscrittps", item.inscrittps, i18n("INSCRITTPS")) + "\n\n    " + Theme.renderTextField(NS, "no_tvq", item.no_tvq, i18n("NO_TVQ"), 25) + "\n    " + Theme.renderCheckboxField(NS, "recoittvq", item.recoittvq, i18n("RECOITTVQ")) + "\n    " + Theme.renderCheckboxField(NS, "inscrittvq", item.inscrittvq, i18n("INSCRITTVQ")) + "\n\n    " + Theme.renderCheckboxField(NS, "payera", item.payera, i18n("PAYERA")) + "\n    " + Theme.renderTextField(NS, "payeraid", item.payeraid, i18n("PAYERAID"), 15) + "\n    " + Theme.renderCheckboxField(NS, "paiementmanuel", item.paiementmanuel, i18n("PAIEMENTMANUEL")) + "\n";
            };
            block_representant = function (item) {
                return "\n    " + Theme.renderTextField(NS, "rep_nom", item.rep_nom, i18n("REP_NOM"), 30) + "\n    " + Theme.renderTextField(NS, "rep_telephone", item.rep_telephone, i18n("REP_TELEPHONE"), 12) + "\n    " + Theme.renderTextField(NS, "rep_telephone_poste", item.rep_telephone_poste, i18n("REP_TELEPHONE_POSTE"), 4) + "\n    " + Theme.renderTextField(NS, "rep_email", item.rep_email, i18n("REP_EMAIL"), 80) + "\n\n    " + Theme.renderTextField(NS, "rep2_nom", item.rep2_nom, i18n("REP2_NOM"), 80) + "\n    " + Theme.renderTextField(NS, "rep2_telephone", item.rep2_telephone, i18n("REP2_TELEPHONE"), 12) + "\n    " + Theme.renderTextField(NS, "rep2_telephone_poste", item.rep2_telephone_poste, i18n("REP2_TELEPHONE_POSTE"), 4) + "\n    " + Theme.renderTextField(NS, "rep2_email", item.rep2_email, i18n("REP2_EMAIL"), 80) + "\n    " + Theme.renderTextareaField(NS, "rep2_commentaires", item.rep2_commentaires, i18n("REP2_COMMENTAIRES"), 255, false, null, 3) + "\n";
            };
            block_camions = function (item) {
                return "\n";
            };
            formTemplate = function (item, paysid, institutionbanquaireid, inline2) {
                return "\n<div class=\"js-float-menu\">\n    <ul>\n        <li>" + Theme.float_menu_button("Adresse") + "</li>\n        <li>" + Theme.float_menu_button("Téléphone") + "</li>\n        <li>" + Theme.float_menu_button("Ciel") + "</li>\n        <li>" + Theme.float_menu_button("Internet") + "</li>\n        <li>" + Theme.float_menu_button("Autres") + "</li>\n        <li>" + Theme.float_menu_button("Dépôt direct") + "</li>\n        <li>" + Theme.float_menu_button("Représentant") + "</li>\n        <li>" + Theme.float_menu_button("Camions") + "</li>\n        <li>" + Theme.float_menu_button("Lots") + "</li>\n    </ul>\n</div>\n\n<div class=\"columns\">\n    <div class=\"column is-8 is-offset-3\">\n        " + Theme.wrapFieldset("Adresse", block_address(item, paysid)) + "\n        " + Theme.wrapFieldset("Téléphone", block_telephone(item)) + "\n        " + Theme.wrapFieldset("Ciel", block_ciel(item)) + "\n        " + Theme.wrapFieldset("Internet", block_internet(item)) + "\n        " + Theme.wrapFieldset("Autres", block_autres(item)) + "\n        " + Theme.wrapFieldset("Dépôt direct", block_depotdirect(item, institutionbanquaireid)) + "\n        " + Theme.wrapFieldset("Représentant", block_representant(item)) + "\n        " + Theme.wrapFieldset("Camions", block_camions(item)) + "\n        " + Theme.wrapFieldset("Lots", inline2) + "\n    </div>\n</div>\n\n    " + Theme.renderBlame(item, isNew) + "\n";
                //    return `
                //    ${Theme.renderNumberField(NS, "mrcproducteurid", item.mrcproducteurid, i18n("MRCPRODUCTEURID"))}
                //    ${Theme.renderCheckboxField(NS, "modifiertrigger", item.modifiertrigger, i18n("MODIFIERTRIGGER"))}
                //`;
            };
            pageTemplate = function (item, form, tab, warning, dirty) {
                var canEdit = true;
                var readonly = !canEdit;
                var canInsert = canEdit && isNew; // && Perm.hasFournisseur_CanAddFournisseur;
                var canDelete = canEdit && !canInsert; // && Perm.hasFournisseur_CanDeleteFournisseur;
                var canAdd = canEdit && !canInsert; // && Perm.hasFournisseur_CanAddFournisseur;
                var canUpdate = canEdit && !isNew;
                var inline2_dirty = app_inline2.hasChanges();
                var buttons = [];
                buttons.push(Theme.buttonCancel(NS));
                if (canInsert)
                    buttons.push(Theme.buttonInsert(NS));
                if (canDelete)
                    buttons.push(Theme.buttonDelete(NS));
                if (canAdd)
                    buttons.push(Theme.buttonAddNew(NS, "#/proprietaire/new"));
                if (canUpdate)
                    buttons.push(Theme.buttonUpdate(NS, inline2_dirty));
                var actions = Theme.renderButtons(buttons);
                var title = layout_7.buildTitle(xtra, !isNew ? i18n("fournisseur Details") : i18n("New fournisseur"));
                var subtitle = layout_7.buildSubtitle(xtra, i18n("fournisseur subtitle"));
                return "\n<form onsubmit=\"return false;\" " + (readonly ? "class='js-readonly'" : "") + ">\n<input type=\"submit\" style=\"display:none;\" id=\"" + NS + "_dummy_submit\">\n\n<div class=\"js-fixed-heading\">\n<div class=\"js-head\">\n    <div class=\"content js-uc-heading js-flex-space\">\n        <div>\n            <div class=\"title\"><i class=\"" + layout_7.icon + "\"></i> <span>" + title + "</span></div>\n            <div class=\"subtitle\">" + subtitle + "</div>\n        </div>\n        <div>\n            " + Theme.wrapContent("js-uc-actions", actions) + "\n            " + Theme.renderBlame(item, isNew) + "\n        </div>\n    </div>\n    " + Theme.wrapContent("js-uc-tabs", tab) + "\n</div>\n<div class=\"js-body\">\n    " + Theme.wrapContent("js-uc-notification", dirty) + "\n    " + Theme.wrapContent("js-uc-notification", warning) + "\n    " + Theme.wrapContent("js-uc-details", form) + "\n</div>\n</div>\n\n" + Theme.renderModalDelete("modalDelete_" + NS, NS + ".drop()") + "\n\n</form>\n";
            };
            dirtyTemplate = function () {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            exports_46("fetchState", fetchState = function (id) {
                isNew = (id == "new");
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                return App.GET("/fournisseur/" + (isNew ? "new" : id))
                    .then(function (payload) {
                    state = payload.item;
                    xtra = payload.xtra;
                    fetchedState = Misc.clone(state);
                    key = { id: id };
                })
                    .then(Lookup.fetch_pays())
                    .then(Lookup.fetch_institutionBanquaire())
                    .then(function () { return app_inline2.fetchState(id, NS); });
            });
            exports_46("fetch", fetch = function (params) {
                var id = params[0];
                App.prepareRender(NS, i18n("proprietaire"));
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_46("render", render = function () {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || Object.keys(state).length == 0)
                    return App.warningTemplate() || App.unexpectedTemplate();
                var year = 2020; // Perm.getCurrentYear(); //or something better
                var lookup_pays = Lookup.get_pays(year);
                var lookup_institutionBanquaire = Lookup.get_institutionBanquaire(year);
                var paysid = Theme.renderOptions(lookup_pays, state.paysid, true);
                var institutionbanquaireid = Theme.renderOptions(lookup_institutionBanquaire, state.institutionbanquaireid, true);
                app_inline2.preRender();
                var inline2 = app_inline2.render();
                var form = formTemplate(state, paysid, institutionbanquaireid, inline2);
                var tab = layout_7.tabTemplate(state.id, xtra, isNew);
                var dirty = dirtyTemplate();
                var warning = App.warningTemplate();
                return pageTemplate(state, form, tab, warning, dirty);
            });
            exports_46("postRender", postRender = function () {
                if (!inContext())
                    return;
                app_inline2.postRender();
                App.setPageTitle(isNew ? i18n("New proprietaire") : xtra.title);
            });
            exports_46("inContext", inContext = function () {
                return App.inContext(NS);
            });
            getFormState = function () {
                var clone = Misc.clone(state);
                clone.cletri = Misc.fromInputTextNullable(NS + "_cletri", state.cletri);
                clone.nom = Misc.fromInputTextNullable(NS + "_nom", state.nom);
                clone.ausoinsde = Misc.fromInputTextNullable(NS + "_ausoinsde", state.ausoinsde);
                clone.rue = Misc.fromInputTextNullable(NS + "_rue", state.rue);
                clone.ville = Misc.fromInputTextNullable(NS + "_ville", state.ville);
                clone.paysid = Misc.fromSelectText(NS + "_paysid", state.paysid);
                clone.code_postal = Misc.fromInputTextNullable(NS + "_code_postal", state.code_postal);
                clone.telephone = Misc.fromInputTextNullable(NS + "_telephone", state.telephone);
                clone.telephone_poste = Misc.fromInputTextNullable(NS + "_telephone_poste", state.telephone_poste);
                clone.telecopieur = Misc.fromInputTextNullable(NS + "_telecopieur", state.telecopieur);
                clone.telephone2 = Misc.fromInputTextNullable(NS + "_telephone2", state.telephone2);
                clone.telephone2_desc = Misc.fromInputTextNullable(NS + "_telephone2_desc", state.telephone2_desc);
                clone.telephone2_poste = Misc.fromInputTextNullable(NS + "_telephone2_poste", state.telephone2_poste);
                clone.telephone3 = Misc.fromInputTextNullable(NS + "_telephone3", state.telephone3);
                clone.telephone3_desc = Misc.fromInputTextNullable(NS + "_telephone3_desc", state.telephone3_desc);
                clone.telephone3_poste = Misc.fromInputTextNullable(NS + "_telephone3_poste", state.telephone3_poste);
                clone.no_membre = Misc.fromInputTextNullable(NS + "_no_membre", state.no_membre);
                clone.resident = Misc.fromInputTextNullable(NS + "_resident", state.resident);
                clone.email = Misc.fromInputTextNullable(NS + "_email", state.email);
                clone.www = Misc.fromInputTextNullable(NS + "_www", state.www);
                clone.commentaires = Misc.fromInputTextNullable(NS + "_commentaires", state.commentaires);
                clone.affichercommentaires = Misc.fromInputCheckbox(NS + "_affichercommentaires", state.affichercommentaires);
                clone.depotdirect = Misc.fromInputCheckbox(NS + "_depotdirect", state.depotdirect);
                clone.institutionbanquaireid = Misc.fromSelectText(NS + "_institutionbanquaireid", state.institutionbanquaireid);
                clone.banque_transit = Misc.fromInputTextNullable(NS + "_banque_transit", state.banque_transit);
                clone.banque_folio = Misc.fromInputTextNullable(NS + "_banque_folio", state.banque_folio);
                clone.no_tps = Misc.fromInputTextNullable(NS + "_no_tps", state.no_tps);
                clone.no_tvq = Misc.fromInputTextNullable(NS + "_no_tvq", state.no_tvq);
                clone.payera = Misc.fromInputCheckbox(NS + "_payera", state.payera);
                clone.payeraid = Misc.fromInputTextNullable(NS + "_payeraid", state.payeraid);
                clone.statut = Misc.fromInputTextNullable(NS + "_statut", state.statut);
                clone.rep_nom = Misc.fromInputTextNullable(NS + "_rep_nom", state.rep_nom);
                clone.rep_telephone = Misc.fromInputTextNullable(NS + "_rep_telephone", state.rep_telephone);
                clone.rep_telephone_poste = Misc.fromInputTextNullable(NS + "_rep_telephone_poste", state.rep_telephone_poste);
                clone.rep_email = Misc.fromInputTextNullable(NS + "_rep_email", state.rep_email);
                clone.enanglais = Misc.fromInputCheckbox(NS + "_enanglais", state.enanglais);
                clone.actif = Misc.fromInputCheckbox(NS + "_actif", state.actif);
                clone.mrcproducteurid = Misc.fromInputNumberNullable(NS + "_mrcproducteurid", state.mrcproducteurid);
                clone.paiementmanuel = Misc.fromInputCheckbox(NS + "_paiementmanuel", state.paiementmanuel);
                clone.journal = Misc.fromInputCheckbox(NS + "_journal", state.journal);
                clone.recoittps = Misc.fromInputCheckbox(NS + "_recoittps", state.recoittps);
                clone.recoittvq = Misc.fromInputCheckbox(NS + "_recoittvq", state.recoittvq);
                clone.modifiertrigger = Misc.fromInputCheckbox(NS + "_modifiertrigger", state.modifiertrigger);
                clone.isproducteur = Misc.fromInputCheckbox(NS + "_isproducteur", state.isproducteur);
                clone.istransporteur = Misc.fromInputCheckbox(NS + "_istransporteur", state.istransporteur);
                clone.ischargeur = Misc.fromInputCheckbox(NS + "_ischargeur", state.ischargeur);
                clone.isautre = Misc.fromInputCheckbox(NS + "_isautre", state.isautre);
                clone.affichercommentairessurpermit = Misc.fromInputCheckbox(NS + "_affichercommentairessurpermit", state.affichercommentairessurpermit);
                clone.pasemissionpermis = Misc.fromInputCheckbox(NS + "_pasemissionpermis", state.pasemissionpermis);
                clone.generique = Misc.fromInputCheckbox(NS + "_generique", state.generique);
                clone.membre_ogc = Misc.fromInputCheckbox(NS + "_membre_ogc", state.membre_ogc);
                clone.inscrittps = Misc.fromInputCheckbox(NS + "_inscrittps", state.inscrittps);
                clone.inscrittvq = Misc.fromInputCheckbox(NS + "_inscrittvq", state.inscrittvq);
                clone.isogc = Misc.fromInputCheckbox(NS + "_isogc", state.isogc);
                clone.rep2_nom = Misc.fromInputTextNullable(NS + "_rep2_nom", state.rep2_nom);
                clone.rep2_telephone = Misc.fromInputTextNullable(NS + "_rep2_telephone", state.rep2_telephone);
                clone.rep2_telephone_poste = Misc.fromInputTextNullable(NS + "_rep2_telephone_poste", state.rep2_telephone_poste);
                clone.rep2_email = Misc.fromInputTextNullable(NS + "_rep2_email", state.rep2_email);
                clone.rep2_commentaires = Misc.fromInputTextNullable(NS + "_rep2_commentaires", state.rep2_commentaires);
                return clone;
            };
            valid = function (formState) {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = function () {
                document.getElementById(NS + "_dummy_submit").click();
                var form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_46("onchange", onchange = function (input) {
                state = getFormState();
                App.render();
            });
            exports_46("cancel", cancel = function () {
                Router.goBackOrResume(isDirty);
            });
            exports_46("create", create = function () {
                var formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST("/fournisseur", Misc.createBlack(formState, blackList))
                    .then(function (payload) {
                    var newkey = payload;
                    Misc.toastSuccessSave();
                    Router.goto("#/proprietaire/" + newkey.id, 10);
                })
                    .catch(App.render);
            });
            exports_46("save", save = function (done) {
                if (done === void 0) { done = false; }
                var formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.PUT("/fournisseur", Misc.createBlack(formState, blackList))
                    .then(function (_) {
                    Misc.toastSuccessSave();
                    if (done)
                        Router.goto("#/proprietaires/", 100);
                    else
                        Router.goto("#/proprietaire/" + key.id, 10);
                })
                    .catch(App.render);
            });
            exports_46("drop", drop = function () {
                //(<any>key).updatedUtc = state.updatedUtc;
                App.prepareRender();
                App.DELETE("/fournisseur", key)
                    .then(function (_) {
                    Router.goto("#/proprietaires/", 250);
                })
                    .catch(App.render);
            });
            dirtyExit = function () {
                var masterHasChange = !Misc.same(fetchedState, getFormState());
                var detailsHasChange = app_inline2.hasChanges();
                isDirty = masterHasChange || detailsHasChange;
                if (isDirty) {
                    setTimeout(function () {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
System.register("src/fournisseur/main", ["_BaseApp/src/core/router", "src/fournisseur/proprietaires", "src/fournisseur/proprietaire"], function (exports_47, context_47) {
    "use strict";
    var Router, proprietaires, proprietaire, startup, render, postRender;
    var __moduleName = context_47 && context_47.id;
    return {
        setters: [
            function (Router_13) {
                Router = Router_13;
            },
            function (proprietaires_1) {
                proprietaires = proprietaires_1;
            },
            function (proprietaire_1) {
                proprietaire = proprietaire_1;
            }
        ],
        execute: function () {
            //
            // Global references to application objects
            // These must match the "NS" values defined in modules
            // Mainly used for event handlers
            //
            window[proprietaires.NS] = proprietaires;
            window[proprietaire.NS] = proprietaire;
            exports_47("startup", startup = function () {
                Router.addRoute("^#/proprietaires/?(.*)?$", proprietaires.fetch);
                Router.addRoute("^#/proprietaire/?(.*)?$", proprietaire.fetch);
            });
            exports_47("render", render = function () {
                return "\n<div>\n    " + proprietaires.render() + "\n    " + proprietaire.render() + "\n</div>\n";
            });
            exports_47("postRender", postRender = function () {
                proprietaires.postRender();
                proprietaire.postRender();
            });
        }
    };
});
System.register("src/territoire/layout", ["_BaseApp/src/core/app", "src/layout"], function (exports_48, context_48) {
    "use strict";
    var App, layout_8, icon, prepareMenu, tabTemplate, buildTitle, buildSubtitle;
    var __moduleName = context_48 && context_48.id;
    return {
        setters: [
            function (App_19) {
                App = App_19;
            },
            function (layout_8_1) {
                layout_8 = layout_8_1;
            }
        ],
        execute: function () {
            exports_48("icon", icon = "far fa-user");
            exports_48("prepareMenu", prepareMenu = function () {
                layout_8.setOpenedMenu("Territoire-Lots");
            });
            exports_48("tabTemplate", tabTemplate = function (id, xtra, isNew) {
                if (isNew === void 0) { isNew = false; }
                var isLots = App.inContext("App_lots");
                var isLot = App.inContext("App_lot");
                var isFiles = window.location.hash.startsWith("#/files/lot");
                var isFile = window.location.hash.startsWith("#/file/lot");
                var showDetail = !isLots;
                var showFiles = showDetail && xtra;
                var showFile = isFile;
                return "\n<div class=\"tabs is-boxed\">\n    <ul>\n        <li " + (isLots ? "class='is-active'" : "") + ">\n            <a href=\"#/lots\">\n                <span class=\"icon\"><i class=\"fas fa-list-ol\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("List") + "</span>\n            </a>\n        </li>\n" + (showDetail ? "\n        <li " + (isLot ? "class='is-active'" : "") + ">\n            <a href=\"#/lot/" + id + "\">\n                <span class=\"icon\"><i class=\"" + icon + "\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("Lot Details") + "</span>\n            </a>\n        </li>\n" : "") + "\n" + (showFiles ? "\n        <li " + (isFiles ? "class='is-active'" : "") + ">\n            <a href=\"#/files/lot/" + id + "\">\n                <span class=\"icon\"><i class=\"far fa-paperclip\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("Files") + " (" + xtra.filecount + ")</span>\n            </a>\n        </li>\n" : "") + "\n" + (showFile ? "\n        <li " + (isFile ? "class='is-active'" : "") + ">\n            <a href=\"#/file/lot/" + id + "\">\n                <span class=\"icon\"><i class=\"far fa-paperclip\" aria-hidden=\"true\"></i></span>\n                <span>" + i18n("File Details") + "</span>\n            </a>\n        </li>\n" : "") + "\n\n    </ul>\n</div>\n";
            });
            exports_48("buildTitle", buildTitle = function (xtra, defaultText) {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.title) !== null && _a !== void 0 ? _a : defaultText;
            });
            exports_48("buildSubtitle", buildSubtitle = function (xtra, defaultText) {
                var _a;
                return (_a = xtra === null || xtra === void 0 ? void 0 : xtra.subtitle) !== null && _a !== void 0 ? _a : defaultText;
            });
        }
    };
});
// File: lots.ts
System.register("src/territoire/lots", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "src/permission", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/pager", "src/admin/lookupdata", "src/territoire/layout"], function (exports_49, context_49) {
    "use strict";
    var App, Router, Perm, Misc, Theme, Pager, Lookup, layout_9, NS, key, state, xtra, uiSelectedRow, filterTemplate, trTemplate, tableTemplate, pageTemplate, fetchState, fetch, refresh, render, postRender, inContext, setSelectedRow, isSelectedRow, goto, sortBy, search, gotoDetail;
    var __moduleName = context_49 && context_49.id;
    return {
        setters: [
            function (App_20) {
                App = App_20;
            },
            function (Router_14) {
                Router = Router_14;
            },
            function (Perm_6) {
                Perm = Perm_6;
            },
            function (Misc_20) {
                Misc = Misc_20;
            },
            function (Theme_8) {
                Theme = Theme_8;
            },
            function (Pager_5) {
                Pager = Pager_5;
            },
            function (Lookup_7) {
                Lookup = Lookup_7;
            },
            function (layout_9_1) {
                layout_9 = layout_9_1;
            }
        ],
        execute: function () {
            exports_49("NS", NS = "App_lots");
            state = {
                list: [],
                pager: { pageNo: 1, pageSize: 20, sortColumn: "ID", sortDirection: "ASC", filter: {} }
            };
            filterTemplate = function () {
                var filters = [];
                return filters.join("");
            };
            trTemplate = function (item, rowNumber) {
                return "\n<tr class=\"" + (isSelectedRow(item.id) ? "is-selected" : "") + "\" onclick=\"" + NS + ".gotoDetail(" + item.id + ");\">\n    <td class=\"js-index\">" + rowNumber + "</td>\n    <td>" + Misc.toStaticText(item.cantonid_text) + "</td>\n    <td>" + Misc.toStaticText(item.rang) + "</td>\n    <td>" + Misc.toStaticText(item.lot) + "</td>\n    <td>" + Misc.toStaticText(item.municipaliteid_text) + "</td>\n    <td>" + Misc.toStaticText(item.superficie_total) + "</td>\n    <td>" + Misc.toStaticText(item.superficie_boisee) + "</td>\n    <td>" + Misc.toStaticText(item.proprietaireid_text) + "</td>\n    <td>" + Misc.toStaticText(item.contingentid_text) + "</td>\n    <td>" + Misc.toStaticDate(item.contingent_date) + "</td>\n    <td>" + Misc.toStaticText(item.droit_coupeid_text) + "</td>\n    <td>" + Misc.toStaticDate(item.droit_coupe_date) + "</td>\n    <td>" + Misc.toStaticText(item.entente_paiementid_text) + "</td>\n    <td>" + Misc.toStaticDate(item.entente_paiement_date) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.actif) + "</td>\n    <td>" + Misc.toStaticText(item.id) + "</td>\n    <td>" + Misc.toStaticText(item.sequence) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.partie) + "</td>\n    <td>" + Misc.toStaticText(item.matricule) + "</td>\n    <td>" + Misc.toStaticText(item.zoneid_text) + "</td>\n    <td>" + Misc.toStaticText(item.secteur) + "</td>\n    <td>" + Misc.toStaticText(item.cadastre) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.reforme) + "</td>\n    <td>" + Misc.toStaticText(item.lotscomplementaires) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.certifie) + "</td>\n    <td>" + Misc.toStaticText(item.numerocertification) + "</td>\n    <td>" + Misc.toStaticCheckbox(item.ogc) + "</td>\n</tr>";
            };
            tableTemplate = function (tbody, pager) {
                return "\n<div class=\"table-container\">\n<table class=\"table is-hoverable is-fullwidth\">\n    <thead>\n        <tr>\n            <th></th>\n            " + Pager.sortableHeaderLink(pager, NS, i18n("CANTONID_TEXT"), "cantonid_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("RANG"), "rang", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("LOT"), "lot", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("MUNICIPALITEID_TEXT"), "municipaliteid_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SUPERFICIE_TOTAL"), "superficie_total", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SUPERFICIE_BOISEE"), "superficie_boisee", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PROPRIETAIREID_TEXT"), "proprietaireid_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("CONTINGENTID_TEXT"), "contingentid_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("CONTINGENT_DATE"), "contingent_date", "DESC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("DROIT_COUPEID_TEXT"), "droit_coupeid_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("DROIT_COUPE_DATE"), "droit_coupe_date", "DESC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ENTENTE_PAIEMENTID_TEXT"), "entente_paiementid_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ENTENTE_PAIEMENT_DATE"), "entente_paiement_date", "DESC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ACTIF"), "actif", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ID"), "id", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SEQUENCE"), "sequence", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("PARTIE"), "partie", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("MATRICULE"), "matricule", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("ZONEID_TEXT"), "zoneid_text", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("SECTEUR"), "secteur", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("CADASTRE"), "cadastre", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("REFORME"), "reforme", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("LOTSCOMPLEMENTAIRES"), "lotscomplementaires", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("CERTIFIE"), "certifie", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("NUMEROCERTIFICATION"), "numerocertification", "ASC") + "\n            " + Pager.sortableHeaderLink(pager, NS, i18n("OGC"), "ogc", "ASC") + "\n            " + Pager.headerLink(i18n("TODO")) + "\n        </tr>\n    </thead>\n    <tbody>\n        " + tbody + "\n    </tbody>\n</table>\n</div>\n";
            };
            pageTemplate = function (pager, table, tab, warning, dirty) {
                var readonly = false;
                var buttons = [];
                buttons.push(Theme.buttonAddNew(NS, "#/lot/new", i18n("Add New")));
                var actions = Theme.renderButtons(buttons);
                var title = layout_9.buildTitle(xtra, i18n("lots title"));
                var subtitle = layout_9.buildSubtitle(xtra, i18n("lots subtitle"));
                return "\n<form onsubmit=\"return false;\">\n<input type=\"submit\" style=\"display:none;\" id=\"" + NS + "_dummy_submit\">\n\n<div class=\"js-fixed-heading\">\n<div class=\"js-head\">\n    <div class=\"content js-uc-heading js-flex-space\">\n        <div>\n            <div class=\"title\"><i class=\"" + layout_9.icon + "\"></i> <span>" + title + "</span></div>\n            <div class=\"subtitle\">" + subtitle + "</div>\n        </div>\n        <div>\n            " + Theme.wrapContent("js-uc-actions", actions) + "\n        </div>\n    </div>\n    " + Theme.wrapContent("js-uc-tabs", tab) + "\n</div>\n<div class=\"js-body\">\n    " + Theme.wrapContent("js-uc-notification", dirty) + "\n    " + Theme.wrapContent("js-uc-notification", warning) + "\n    " + Theme.wrapContent("js-uc-pager", pager) + "\n    " + Theme.wrapContent("js-uc-list", table) + "\n</div>\n</div>\n\n</form>\n";
            };
            exports_49("fetchState", fetchState = function (id) {
                Router.registerDirtyExit(null);
                return App.POST("/lot/search", state.pager)
                    .then(function (payload) {
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
            exports_49("fetch", fetch = function (params) {
                var id = +params[0];
                App.prepareRender(NS, i18n("lots"));
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            refresh = function () {
                App.prepareRender(NS, i18n("lots"));
                App.POST("/lot/search", state.pager)
                    .then(function (payload) {
                    state = payload;
                })
                    .then(App.render)
                    .catch(App.render);
            };
            exports_49("render", render = function () {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
                    return App.warningTemplate() || App.unexpectedTemplate();
                var warning = App.warningTemplate();
                var dirty = "";
                var tbody = state.list.reduce(function (html, item, index) {
                    var rowNumber = Pager.rowNumber(state.pager, index);
                    return html + trTemplate(item, rowNumber);
                }, "");
                var year = Perm.getCurrentYear(); //state.pager.filter.year;
                var filter = filterTemplate();
                var search = Pager.searchTemplate(state.pager, NS);
                var pager = Pager.render(state.pager, NS, [20, 50], search, filter);
                var table = tableTemplate(tbody, state.pager);
                var tab = layout_9.tabTemplate(null, null);
                return pageTemplate(pager, table, tab, dirty, warning);
            });
            exports_49("postRender", postRender = function () {
                if (!inContext())
                    return;
            });
            exports_49("inContext", inContext = function () {
                return App.inContext(NS);
            });
            setSelectedRow = function (id) {
                if (uiSelectedRow == undefined)
                    uiSelectedRow = { id: id };
                uiSelectedRow.id = id;
            };
            isSelectedRow = function (id) {
                if (uiSelectedRow == undefined)
                    return false;
                return (uiSelectedRow.id == id);
            };
            exports_49("goto", goto = function (pageNo, pageSize) {
                state.pager.pageNo = pageNo;
                state.pager.pageSize = pageSize;
                refresh();
            });
            exports_49("sortBy", sortBy = function (columnName, direction) {
                state.pager.pageNo = 1;
                state.pager.sortColumn = columnName;
                state.pager.sortDirection = direction;
                refresh();
            });
            exports_49("search", search = function (element) {
                state.pager.searchText = element.value;
                state.pager.pageNo = 1;
                refresh();
            });
            exports_49("gotoDetail", gotoDetail = function (id) {
                setSelectedRow(id);
                Router.goto("#/lot/" + id);
            });
        }
    };
});
// File: lot.ts
System.register("src/territoire/lot", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/calendar", "_BaseApp/src/theme/autocomplete", "src/admin/lookupdata", "src/permission", "src/territoire/layout"], function (exports_50, context_50) {
    "use strict";
    var App, Router, Misc, Theme, calendar_1, autocomplete_1, Lookup, Perm, layout_10, NS, blackList, key, state, fetchedState, xtra, isNew, isDirty, contingent_dateCalendar, droit_coupe_dateCalendar, entente_paiement_dateCalendar, state_proprietaire, proprietaireidAutocomplete, formTemplate, pageTemplate, dirtyTemplate, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, oncalendar, onautocomplete, onchange, cancel, create, save, drop, dirtyExit;
    var __moduleName = context_50 && context_50.id;
    return {
        setters: [
            function (App_21) {
                App = App_21;
            },
            function (Router_15) {
                Router = Router_15;
            },
            function (Misc_21) {
                Misc = Misc_21;
            },
            function (Theme_9) {
                Theme = Theme_9;
            },
            function (calendar_1_1) {
                calendar_1 = calendar_1_1;
            },
            function (autocomplete_1_1) {
                autocomplete_1 = autocomplete_1_1;
            },
            function (Lookup_8) {
                Lookup = Lookup_8;
            },
            function (Perm_7) {
                Perm = Perm_7;
            },
            function (layout_10_1) {
                layout_10 = layout_10_1;
            }
        ],
        execute: function () {
            exports_50("NS", NS = "App_lot");
            blackList = ["cantonid", "municipaliteid", "proprietaireid", "contingentid", "droit_coupeid", "entente_paiementid", "zoneid"];
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            contingent_dateCalendar = new calendar_1.Calendar(NS + "_contingent_date");
            droit_coupe_dateCalendar = new calendar_1.Calendar(NS + "_droit_coupe_date");
            entente_paiement_dateCalendar = new calendar_1.Calendar(NS + "_entente_paiement_date");
            state_proprietaire = {
                list: [],
                pager: { pageNo: 1, pageSize: 5, sortColumn: "ID", sortDirection: "ASC", filter: { nom: undefined } }
            };
            proprietaireidAutocomplete = new autocomplete_1.Autocomplete(NS, "proprietaireid", true);
            proprietaireidAutocomplete.options = {
                keyTemplate: function (one) { return "" + one.id; },
                valueTemplate: function (one) { return one.id + " - " + one.nom; },
                detailTemplate: function (one) { return "<b>" + one.id + " - " + one.nom + "</b><br>" + one.email; },
            };
            formTemplate = function (item, cantonid, municipaliteid, proprietaireid, contingentid, droit_coupeid, entente_paiementid) {
                //${Theme.renderDropdownField(NS, "proprietaireid", proprietaireid, i18n("PROPRIETAIREID"))}
                var proprietaireOption = {
                    addon: (item.proprietaireid ? "<a class=\"button is-text\" href=\"#/proprietaire/" + item.proprietaireid + "\">Voir</a>" : null),
                    required: true
                };
                return "\n\n" + (isNew ? "\n" : "\n    " + Theme.renderStaticField(Misc.toStaticNumber(item.id), i18n("ID")) + "\n") + "\n    " + Theme.renderDropdownField(NS, "cantonid", cantonid, i18n("CANTONID")) + "\n    " + Theme.renderTextField(NS, "rang", item.rang, i18n("RANG"), 25) + "\n    " + Theme.renderTextField(NS, "lot", item.lot, i18n("LOT"), 6) + "\n    " + Theme.renderDropdownField(NS, "municipaliteid", municipaliteid, i18n("MUNICIPALITEID")) + "\n    " + Theme.renderNumberField(NS, "superficie_total", item.superficie_total, i18n("SUPERFICIE_TOTAL")) + "\n    " + Theme.renderNumberField(NS, "superficie_boisee", item.superficie_boisee, i18n("SUPERFICIE_BOISEE")) + "\n\n    " + Theme.renderAutocompleteField(NS, "proprietaireid", proprietaireid, i18n("PROPRIETAIREID"), proprietaireOption) + "\n\n    " + Theme.renderDropdownField(NS, "contingentid", contingentid, i18n("CONTINGENTID")) + "\n    " + Theme.renderCalendarField(NS, "contingent_date", contingent_dateCalendar, i18n("CONTINGENT_DATE")) + "\n    " + Theme.renderDropdownField(NS, "droit_coupeid", droit_coupeid, i18n("DROIT_COUPEID")) + "\n    " + Theme.renderCalendarField(NS, "droit_coupe_date", droit_coupe_dateCalendar, i18n("DROIT_COUPE_DATE")) + "\n    " + Theme.renderDropdownField(NS, "entente_paiementid", entente_paiementid, i18n("ENTENTE_PAIEMENTID")) + "\n    " + Theme.renderCalendarField(NS, "entente_paiement_date", entente_paiement_dateCalendar, i18n("ENTENTE_PAIEMENT_DATE")) + "\n    " + Theme.renderCheckboxField(NS, "actif", item.actif, i18n("ACTIF")) + "\n    " + Theme.renderTextField(NS, "sequence", item.sequence, i18n("SEQUENCE"), 6) + "\n    " + Theme.renderCheckboxField(NS, "partie", item.partie, i18n("PARTIE")) + "\n    " + Theme.renderTextField(NS, "matricule", item.matricule, i18n("MATRICULE"), 20) + "\n    " + Theme.renderTextField(NS, "secteur", item.secteur, i18n("SECTEUR"), 2) + "\n    " + Theme.renderNumberField(NS, "cadastre", item.cadastre, i18n("CADASTRE")) + "\n    " + Theme.renderCheckboxField(NS, "reforme", item.reforme, i18n("REFORME")) + "\n    " + Theme.renderTextareaField(NS, "lotscomplementaires", item.lotscomplementaires, i18n("LOTSCOMPLEMENTAIRES"), 255) + "\n    " + Theme.renderCheckboxField(NS, "certifie", item.certifie, i18n("CERTIFIE")) + "\n    " + Theme.renderTextField(NS, "numerocertification", item.numerocertification, i18n("NUMEROCERTIFICATION"), 50) + "\n    " + Theme.renderCheckboxField(NS, "ogc", item.ogc, i18n("OGC")) + "\n    " + Theme.renderBlame(item, isNew) + "\n";
            };
            pageTemplate = function (item, form, tab, warning, dirty) {
                var canEdit = true;
                var readonly = !canEdit;
                var canInsert = canEdit && isNew; // && Perm.hasLot_CanAddLot;
                var canDelete = canEdit && !canInsert; // && Perm.hasLot_CanDeleteLot;
                var canAdd = canEdit && !canInsert; // && Perm.hasLot_CanAddLot;
                var canUpdate = canEdit && !isNew;
                var buttons = [];
                buttons.push(Theme.buttonCancel(NS));
                if (canInsert)
                    buttons.push(Theme.buttonInsert(NS));
                if (canDelete)
                    buttons.push(Theme.buttonDelete(NS));
                if (canAdd)
                    buttons.push(Theme.buttonAddNew(NS, "#/lot/new"));
                if (canUpdate)
                    buttons.push(Theme.buttonUpdate(NS));
                var actions = Theme.renderButtons(buttons);
                var title = layout_10.buildTitle(xtra, !isNew ? i18n("lot Details") : i18n("New lot"));
                var subtitle = layout_10.buildSubtitle(xtra, i18n("lot subtitle"));
                return "\n<form onsubmit=\"return false;\" " + (readonly ? "class='js-readonly'" : "") + ">\n<input type=\"submit\" style=\"display:none;\" id=\"" + NS + "_dummy_submit\">\n\n<div class=\"js-fixed-heading\">\n<div class=\"js-head\">\n    <div class=\"content js-uc-heading js-flex-space\">\n        <div>\n            <div class=\"title\"><i class=\"" + layout_10.icon + "\"></i> <span>" + title + "</span></div>\n            <div class=\"subtitle\">" + subtitle + "</div>\n        </div>\n        <div>\n            " + Theme.wrapContent("js-uc-actions", actions) + "\n            " + Theme.renderBlame(item, isNew) + "\n        </div>\n    </div>\n    " + Theme.wrapContent("js-uc-tabs", tab) + "\n</div>\n<div class=\"js-body\">\n    " + Theme.wrapContent("js-uc-notification", dirty) + "\n    " + Theme.wrapContent("js-uc-notification", warning) + "\n    " + Theme.wrapContent("js-uc-details", form) + "\n</div>\n</div>\n\n" + Theme.renderModalDelete("modalDelete_" + NS, NS + ".drop()") + "\n\n</form>\n";
            };
            dirtyTemplate = function () {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            exports_50("fetchState", fetchState = function (id) {
                isNew = isNaN(id);
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                return App.GET("/lot/" + (isNew ? "new" : id))
                    .then(function (payload) {
                    state = payload.item;
                    fetchedState = Misc.clone(state);
                    xtra = payload.xtra;
                    key = { id: id };
                    contingent_dateCalendar.setState(state.contingent_date);
                    droit_coupe_dateCalendar.setState(state.droit_coupe_date);
                    entente_paiement_dateCalendar.setState(state.entente_paiement_date);
                    proprietaireidAutocomplete.setState(state.proprietaireid, state.proprietaireid_text);
                })
                    .then(Lookup.fetch_canton())
                    .then(Lookup.fetch_municipalite())
                    //.then(Lookup.fetch_proprietaire())
                    .then(Lookup.fetch_contingent())
                    .then(Lookup.fetch_droit_coupe())
                    .then(Lookup.fetch_entente_paiement());
            });
            exports_50("fetch", fetch = function (params) {
                var id = +params[0];
                App.prepareRender(NS, i18n("lot"));
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_50("render", render = function () {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || Object.keys(state).length == 0)
                    return App.warningTemplate() || App.unexpectedTemplate();
                var year = Perm.getCurrentYear(); //or something better
                var lookup_canton = Lookup.get_canton(year);
                var lookup_municipalite = Lookup.get_municipalite(year);
                //let lookup_proprietaire = Lookup.get_proprietaire(year);
                var lookup_contingent = Lookup.get_contingent(year);
                var lookup_droit_coupe = Lookup.get_droit_coupe(year);
                var lookup_entente_paiement = Lookup.get_entente_paiement(year);
                var cantonid = Theme.renderOptions(lookup_canton, state.cantonid, true);
                var municipaliteid = Theme.renderOptions(lookup_municipalite, state.municipaliteid, true);
                //let proprietaireid = Theme.renderOptions(lookup_proprietaire, state.proprietaireid, true);
                var contingentid = Theme.renderOptions(lookup_contingent, state.contingentid, true);
                var droit_coupeid = Theme.renderOptions(lookup_droit_coupe, state.droit_coupeid, true);
                var entente_paiementid = Theme.renderOptions(lookup_entente_paiement, state.entente_paiementid, true);
                proprietaireidAutocomplete.pagedList = state_proprietaire;
                var form = formTemplate(state, cantonid, municipaliteid, proprietaireidAutocomplete, contingentid, droit_coupeid, entente_paiementid);
                var tab = layout_10.tabTemplate(state.id, xtra, isNew);
                var dirty = dirtyTemplate();
                var warning = App.warningTemplate();
                return pageTemplate(state, form, tab, warning, dirty);
            });
            exports_50("postRender", postRender = function () {
                if (!inContext())
                    return;
                contingent_dateCalendar.postRender();
                droit_coupe_dateCalendar.postRender();
                entente_paiement_dateCalendar.postRender();
                App.setPageTitle(isNew ? i18n("New lot") : xtra.title);
            });
            exports_50("inContext", inContext = function () {
                return App.inContext(NS);
            });
            getFormState = function () {
                var clone = Misc.clone(state);
                clone.cantonid = Misc.fromSelectText(NS + "_cantonid", state.cantonid);
                clone.rang = Misc.fromInputTextNullable(NS + "_rang", state.rang);
                clone.lot = Misc.fromInputTextNullable(NS + "_lot", state.lot);
                clone.municipaliteid = Misc.fromSelectText(NS + "_municipaliteid", state.municipaliteid);
                clone.superficie_total = Misc.fromInputNumberNullable(NS + "_superficie_total", state.superficie_total);
                clone.superficie_boisee = Misc.fromInputNumberNullable(NS + "_superficie_boisee", state.superficie_boisee);
                clone.proprietaireid = Misc.fromAutocompleteText(NS + "_proprietaireid", state.proprietaireid);
                //clone.proprietaireid = Misc.fromSelectText(`${NS}_proprietaireid`, state.proprietaireid);
                clone.contingentid = Misc.fromSelectText(NS + "_contingentid", state.contingentid);
                clone.contingent_date = Misc.fromInputDateNullable(NS + "_contingent_date", state.contingent_date);
                clone.droit_coupeid = Misc.fromSelectText(NS + "_droit_coupeid", state.droit_coupeid);
                clone.droit_coupe_date = Misc.fromInputDateNullable(NS + "_droit_coupe_date", state.droit_coupe_date);
                clone.entente_paiementid = Misc.fromSelectText(NS + "_entente_paiementid", state.entente_paiementid);
                clone.entente_paiement_date = Misc.fromInputDateNullable(NS + "_entente_paiement_date", state.entente_paiement_date);
                clone.actif = Misc.fromInputCheckbox(NS + "_actif", state.actif);
                clone.sequence = Misc.fromInputTextNullable(NS + "_sequence", state.sequence);
                clone.partie = Misc.fromInputCheckbox(NS + "_partie", state.partie);
                clone.matricule = Misc.fromInputTextNullable(NS + "_matricule", state.matricule);
                clone.zoneid = Misc.fromSelectText(NS + "_zoneid", state.zoneid);
                clone.secteur = Misc.fromInputTextNullable(NS + "_secteur", state.secteur);
                clone.cadastre = Misc.fromInputNumberNullable(NS + "_cadastre", state.cadastre);
                clone.reforme = Misc.fromInputCheckbox(NS + "_reforme", state.reforme);
                clone.lotscomplementaires = Misc.fromInputTextNullable(NS + "_lotscomplementaires", state.lotscomplementaires);
                clone.certifie = Misc.fromInputCheckbox(NS + "_certifie", state.certifie);
                clone.numerocertification = Misc.fromInputTextNullable(NS + "_numerocertification", state.numerocertification);
                clone.ogc = Misc.fromInputCheckbox(NS + "_ogc", state.ogc);
                return clone;
            };
            valid = function (formState) {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = function () {
                document.getElementById(NS + "_dummy_submit").click();
                var form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_50("oncalendar", oncalendar = function (id) {
                if (contingent_dateCalendar.id == id)
                    contingent_dateCalendar.toggle();
                if (droit_coupe_dateCalendar.id == id)
                    droit_coupe_dateCalendar.toggle();
                if (entente_paiement_dateCalendar.id == id)
                    entente_paiement_dateCalendar.toggle();
            });
            exports_50("onautocomplete", onautocomplete = function (id) {
                if (proprietaireidAutocomplete.id == id) {
                    state_proprietaire.pager.searchText = proprietaireidAutocomplete.textValue;
                    App.POST("/fournisseur/search", state_proprietaire.pager)
                        .then(function (payload) {
                        state_proprietaire = payload;
                    })
                        .then(App.render);
                }
            });
            exports_50("onchange", onchange = function (input) {
                state = getFormState();
                App.render();
            });
            exports_50("cancel", cancel = function () {
                Router.goBackOrResume(isDirty);
            });
            exports_50("create", create = function () {
                var formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST("/lot", Misc.createBlack(formState, blackList))
                    .then(function (payload) {
                    var newkey = payload;
                    Misc.toastSuccessSave();
                    Router.goto("#/lot/" + newkey.id, 10);
                })
                    .catch(App.render);
            });
            exports_50("save", save = function (done) {
                if (done === void 0) { done = false; }
                var formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.PUT("/lot", Misc.createBlack(formState, blackList))
                    .then(function (_) {
                    Misc.toastSuccessSave();
                    if (done)
                        Router.goto("#/lots/", 100);
                    else
                        Router.goto("#/lot/" + key.id, 10);
                })
                    .catch(App.render);
            });
            exports_50("drop", drop = function () {
                //(<any>key).updated = state.updated;
                App.prepareRender();
                App.DELETE("/lot", key)
                    .then(function (_) {
                    Router.goto("#/lots/", 250);
                })
                    .catch(App.render);
            });
            dirtyExit = function () {
                //console.log(fetchedState, getFormState());
                isDirty = !Misc.same(fetchedState, getFormState());
                if (isDirty) {
                    setTimeout(function () {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
System.register("src/territoire/main", ["_BaseApp/src/core/router", "src/territoire/lots", "src/territoire/lot"], function (exports_51, context_51) {
    "use strict";
    var Router, lots, lot, startup, render, postRender;
    var __moduleName = context_51 && context_51.id;
    return {
        setters: [
            function (Router_16) {
                Router = Router_16;
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
            exports_51("startup", startup = function () {
                Router.addRoute("^#/lots/?(.*)?$", lots.fetch);
                Router.addRoute("^#/lot/?(.*)?$", lot.fetch);
            });
            exports_51("render", render = function () {
                return "\n<div>\n    " + lots.render() + "\n    " + lot.render() + "\n</div>\n";
            });
            exports_51("postRender", postRender = function () {
                lots.postRender();
                lot.postRender();
            });
        }
    };
});
System.register("src/layout", ["_BaseApp/src/core/app", "src/permission", "src/main", "src/home", "src/admin/main", "src/fournisseur/main", "src/territoire/main"], function (exports_52, context_52) {
    "use strict";
    var App, Perm, Main, Home, Admin, Fournisseur, Territoire, NS, render, postRender, renderHeader, menuTemplate, renderAsideMenu, isActive, menuClick, toggle, setOpenedMenu, editProfile, toggleProfileMenu;
    var __moduleName = context_52 && context_52.id;
    return {
        setters: [
            function (App_22) {
                App = App_22;
            },
            function (Perm_8) {
                Perm = Perm_8;
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
            function (Fournisseur_1) {
                Fournisseur = Fournisseur_1;
            },
            function (Territoire_1) {
                Territoire = Territoire_1;
            }
        ],
        execute: function () {
            exports_52("NS", NS = "App_Layout");
            exports_52("render", render = function () {
                Main.saveUIState();
                // Note: Render js-uc-main content first, before renderHeader() and renderAsideMenu(), 
                // so they can potentially have an impact over there.
                var ucMain = "\n" + Home.render() + "\n" + Admin.render() + "\n" + Fournisseur.render() + "\n" + Territoire.render() + "\n";
                var menu = menuTemplate(Home.getMenuData());
                return "\n<div class=\"js-layout " + (Main.state.menuOpened ? "" : "js-close") + "\">\n" + renderHeader() + "\n" + renderAsideMenu(menu) + "\n<section class=\"js-uc-main js-waitable\">\n" + ucMain + "\n</section>\n</div>\n";
            });
            exports_52("postRender", postRender = function () {
                Home.postRender();
                Admin.postRender();
                Fournisseur.postRender();
                Territoire.postRender();
            });
            renderHeader = function () {
                return "\n<header class=\"js-uc-header\">\n\n    <div class=\"js-logo\">\n        <div class=\"js-bars\">\n            <button class=\"button is-primary\" onclick=\"" + NS + ".menuClick()\">\n                <div class=\"icon\"><i class=\"fas fa-bars\"></i></div>\n            </button>\n        </div>\n        <a href=\"#\" onclick=\"" + NS + ".toggle('opsfms')\">\n            <span>Gestion/Paye</span>\n        </a>\n        <div style=\"width:20px;margin-right:1rem;\">&nbsp;</div>\n    </div>\n\n    <div class=\"js-navbar\">\n        <div class=\"js-navbar-items\">\n            <div class=\"js-items\">\n                <div>\n                    <span class=\"has-text-grey-light\">Ann\u00E9e courante:</span> <span class=\"has-text-white\">2020</span>\n                </div>\n            </div>\n            <div class=\"js-items\">\n                <button class=\"button is-primary\" onclick=\"" + NS + ".help()\" style=\"font-size:125%\">\n                    <span class=\"icon\"><i class=\"fas fa-question-circle\"></i></span>\n                </button>\n                <div class=\"navbar-item has-dropdown\" onclick=\"" + NS + ".toggleProfileMenu(this)\">\n                    <a class=\"navbar-link\">\n                        " + Perm.getEmail() + "\n                    </a>\n                    <div class=\"navbar-dropdown\">\n                        <div class=\"navbar-item\">\n                            <div><b>" + Perm.getName() + "</b></div>\n                        </div>\n                        <div class=\"navbar-item\">\n                            <button class=\"button is-fullwidth is-primary\" onclick=\"" + NS + ".toggleProfileMenu();" + NS + ".editProfile()\">\n                                <i class=\"far fa-user\"></i>&nbsp;&nbsp;Edit Profile\n                            </button>\n                        </div>\n                        <hr class=\"navbar-divider\">\n                        <div class=\"navbar-item\">\n                            <button class=\"button is-fullwidth is-outlined\" onclick=\"" + NS + ".toggleProfileMenu();App_Auth.signout();\">\n                                <span class=\"icon\"><i class=\"fas fa-sign-out-alt\"></i></span>&nbsp;" + i18n("Sign out") + "\n                            </button>\n                        </div>\n                        <hr class=\"navbar-divider\">\n                        <a href=\"#\" class=\"navbar-item\">\n                            <div>Terms of Service</div>\n                        </a>\n                    </div>\n                </div>\n                <button class=\"button is-primary\" onclick=\"App_Auth.signout();\">\n                    <span class=\"icon\"><i class=\"fas fa-sign-out-alt\"></i></span>&nbsp;" + i18n("Sign out") + "\n                </button>\n            </div>\n        </div>\n    </div>\n\n</header>";
            };
            menuTemplate = function (menuItems) {
                var linkTemplate = function (link) {
                    if (link.hidden || link.noSidebar)
                        return "";
                    var isDisabled = (link.href == undefined && link.onclick == undefined) && !link.markup;
                    var href = (link.href ? link.href : "#");
                    var isExternal = href.startsWith("http") || link.isExternal;
                    var classes = [];
                    var isActive = (link.ns && App.inContext(link.ns));
                    if (isDisabled)
                        classes.push("js-disabled");
                    if (isActive)
                        classes.push("is-active");
                    var liClasses = (link.classes ? "class=\"" + link.classes + "\"" : "");
                    if (link.markup)
                        return "<li " + liClasses + ">" + link.markup + "</li>";
                    else
                        return "<li " + liClasses + "><a href=\"" + href + "\" " + (classes.length ? "class=\"" + classes.join(" ") + "\"" : "") + " " + (isExternal ? "target=\"_new\"" : "") + " " + (link.onclick ? "onclick=\"" + link.onclick + "\"" : "") + ">" + link.name + "</a></li>";
                };
                var sectionTemplate = function (section, name) {
                    if (section.hidden)
                        return "";
                    var key = name + "-" + section.name;
                    var opened = (Main.state.subMenu == key);
                    return "\n        <li>\n            <a onclick=\"" + NS + ".toggle('" + key + "')\" class=\"" + (opened ? "js-opened" : "") + "\">" + section.name + "</a>\n" + (opened ? "\n            <ul>" + section.links.filter(function (one) { return one.canView == undefined || one.canView; }).reduce(function (html, item) { return html + linkTemplate(item); }, "") + "</ul>\n" : "") + "\n        </li>\n";
                };
                var menuItemTemplate = function (menuItem) {
                    return "\n    <p class=\"menu-label\">\n        <i class=\"" + menuItem.icon + " fa-2x\"></i> " + menuItem.name + "\n    </p>\n    <ul class=\"menu-list\">\n        " + menuItem.sections.filter(function (one) { return one.canView == undefined || one.canView; }).reduce(function (html, item) { return html + sectionTemplate(item, menuItem.name); }, "") + "\n    </ul>\n";
                };
                return menuItems.filter(function (one) { return one.canView; }).reduce(function (html, item) { return html + menuItemTemplate(item); }, "");
            };
            renderAsideMenu = function (menu) {
                return "\n<aside class=\"menu has-background-black-ter js-uc-aside\">\n    <div class=\"js-wrapper\">\n        <ul class=\"menu-list\">\n            <li><a href=\"#\" class=\"" + isActive(Home.NS) + "\" onclick=\"" + NS + ".toggle('home')\"><i class=\"far fa-home\"></i> " + i18n("HOME") + "</a></li>\n        </ul>\n        " + menu + "\n    </div>\n</aside>\n";
            };
            isActive = function (ns) {
                return App.inContext(ns) ? "is-active" : "";
            };
            exports_52("menuClick", menuClick = function () {
                Main.state.menuOpened = !Main.state.menuOpened;
                Main.saveUIState();
                App.render();
            });
            exports_52("toggle", toggle = function (entry) {
                Main.state.subMenu = (Main.state.subMenu == entry ? "" : entry);
                App.render();
            });
            exports_52("setOpenedMenu", setOpenedMenu = function (entry) {
                Main.state.subMenu = entry;
            });
            exports_52("editProfile", editProfile = function () {
                //Profile.fetch([Perm.getUID().toString()]);
                return false;
            });
            exports_52("toggleProfileMenu", toggleProfileMenu = function (element) {
                if (element)
                    element.classList.toggle("is-active");
            });
        }
    };
});
System.register("src/main", ["_BaseApp/src/core/app", "_BaseApp/src/main", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/latlong", "src/fr-CA", "src/permission", "src/layout", "src/home", "src/admin/main", "src/fournisseur/main", "src/territoire/main"], function (exports_53, context_53) {
    "use strict";
    var App, BaseMain, Theme, LatLong, fr_CA_1, Perm, Layout, Home, AdminMain, FournisseurMain, TerritoireMain, state, html_lang, startup, loadUIState, saveUIState;
    var __moduleName = context_53 && context_53.id;
    return {
        setters: [
            function (App_23) {
                App = App_23;
            },
            function (BaseMain_1) {
                BaseMain = BaseMain_1;
            },
            function (Theme_10) {
                Theme = Theme_10;
            },
            function (LatLong_1) {
                LatLong = LatLong_1;
            },
            function (fr_CA_1_1) {
                fr_CA_1 = fr_CA_1_1;
            },
            function (Perm_9) {
                Perm = Perm_9;
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
            exports_53("startup", startup = function (hasPublicHomePage) {
                if (hasPublicHomePage === void 0) { hasPublicHomePage = false; }
                var main = BaseMain.startup(hasPublicHomePage, Layout, Theme);
                var router = main.router;
                // Routing table
                router.addRoute("^#/?$", Home.fetch);
                router.registerHashChanged(function (hash) {
                    if (hash.startsWith("#/signin")) {
                        Home.clearMenuData();
                    }
                });
                AdminMain.startup();
                FournisseurMain.startup();
                TerritoireMain.startup();
                loadUIState();
            });
            exports_53("loadUIState", loadUIState = function () {
                var uid = Perm.getUID();
                var key = (uid != undefined ? "home-state:" + uid : "home-state");
                exports_53("state", state = JSON.parse(localStorage.getItem(key)));
                if (state == undefined) {
                    exports_53("state", state = {
                        menuOpened: true,
                        subMenu: ""
                    });
                }
            });
            exports_53("saveUIState", saveUIState = function () {
                var uid = Perm.getUID();
                var key = (uid != undefined ? "home-state:" + uid : "home-state");
                localStorage.setItem(key, JSON.stringify(state));
            });
        }
    };
});
System.register("src/app", ["src/main"], function (exports_54, context_54) {
    "use strict";
    var main;
    var __moduleName = context_54 && context_54.id;
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
// File: lot.ts
System.register("src/territoire/laura", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/calendar", "_BaseApp/src/theme/autocomplete", "src/admin/lookupdata", "src/permission", "src/territoire/layout"], function (exports_55, context_55) {
    "use strict";
    var App, Router, Misc, Theme, calendar_2, autocomplete_2, Lookup, Perm, layout_11, NS, blackList, key, state, fetchedState, xtra, isNew, isDirty, contingent_dateCalendar, droit_coupe_dateCalendar, entente_paiement_dateCalendar, state_proprietaireid, proprietaireidAutocomplete, formTemplate, pageTemplate, dirtyTemplate, fetchState, fetch, render, postRender, inContext, getFormState, valid, html5Valid, oncalendar, onautocomplete, onchange, cancel, create, save, drop, dirtyExit;
    var __moduleName = context_55 && context_55.id;
    return {
        setters: [
            function (App_24) {
                App = App_24;
            },
            function (Router_17) {
                Router = Router_17;
            },
            function (Misc_22) {
                Misc = Misc_22;
            },
            function (Theme_11) {
                Theme = Theme_11;
            },
            function (calendar_2_1) {
                calendar_2 = calendar_2_1;
            },
            function (autocomplete_2_1) {
                autocomplete_2 = autocomplete_2_1;
            },
            function (Lookup_9) {
                Lookup = Lookup_9;
            },
            function (Perm_10) {
                Perm = Perm_10;
            },
            function (layout_11_1) {
                layout_11 = layout_11_1;
            }
        ],
        execute: function () {
            exports_55("NS", NS = "App_lot");
            blackList = ["cantonid_text", "municipaliteid_text", "proprietaireid_text", "contingentid_text", "droit_coupeid_text", "entente_paiementid_text", "zoneid_text"];
            state = {};
            fetchedState = {};
            isNew = false;
            isDirty = false;
            contingent_dateCalendar = new calendar_2.Calendar(NS + "_contingent_date");
            droit_coupe_dateCalendar = new calendar_2.Calendar(NS + "_droit_coupe_date");
            entente_paiement_dateCalendar = new calendar_2.Calendar(NS + "_entente_paiement_date");
            state_proprietaireid = {
                list: [],
                pager: { pageNo: 1, pageSize: 5, sortColumn: "ID", sortDirection: "ASC", filter: { nom: undefined } }
            };
            proprietaireidAutocomplete = new autocomplete_2.Autocomplete(NS, "proprietaireid", true);
            proprietaireidAutocomplete.options = {
                keyTemplate: function (one) { return "" + one.id; },
                valueTemplate: function (one) { return one.id + " - " + one.description; },
                detailTemplate: function (one) { return "<b>" + one.id + " - " + one.description + "</b>"; },
            };
            formTemplate = function (item, cantonid, municipaliteid, proprietaireid, contingentid, droit_coupeid, entente_paiementid, zoneid) {
                var proprietaireidOption = {
                    addon: (item.proprietaireid ? "<a class=\"button is-text\" href=\"#/proprietaire/" + item.proprietaireid + "\">Voir</a>" : null),
                    required: true
                };
                return "\n\n" + (isNew ? "\n" : "\n    " + Theme.renderStaticField(Misc.toStaticNumber(item.id), i18n("ID")) + "\n") + "\n    " + Theme.renderDropdownField(NS, "cantonid", cantonid, i18n("CANTONID")) + "\n    " + Theme.renderTextField(NS, "rang", item.rang, i18n("RANG"), 25) + "\n    " + Theme.renderTextField(NS, "lot", item.lot, i18n("LOT"), 6) + "\n    " + Theme.renderDropdownField(NS, "municipaliteid", municipaliteid, i18n("MUNICIPALITEID")) + "\n    " + Theme.renderNumberField(NS, "superficie_total", item.superficie_total, i18n("SUPERFICIE_TOTAL")) + "\n    " + Theme.renderNumberField(NS, "superficie_boisee", item.superficie_boisee, i18n("SUPERFICIE_BOISEE")) + "\n    " + Theme.renderAutocompleteField(NS, "proprietaireid", proprietaireid, i18n("PROPRIETAIREID"), proprietaireidOption) + "\n    " + Theme.renderDropdownField(NS, "contingentid", contingentid, i18n("CONTINGENTID")) + "\n    " + Theme.renderCalendarField(NS, "contingent_date", contingent_dateCalendar, i18n("CONTINGENT_DATE")) + "\n    " + Theme.renderDropdownField(NS, "droit_coupeid", droit_coupeid, i18n("DROIT_COUPEID")) + "\n    " + Theme.renderCalendarField(NS, "droit_coupe_date", droit_coupe_dateCalendar, i18n("DROIT_COUPE_DATE")) + "\n    " + Theme.renderDropdownField(NS, "entente_paiementid", entente_paiementid, i18n("ENTENTE_PAIEMENTID")) + "\n    " + Theme.renderCalendarField(NS, "entente_paiement_date", entente_paiement_dateCalendar, i18n("ENTENTE_PAIEMENT_DATE")) + "\n    " + Theme.renderCheckboxField(NS, "actif", item.actif, i18n("ACTIF")) + "\n    " + Theme.renderTextField(NS, "sequence", item.sequence, i18n("SEQUENCE"), 6) + "\n    " + Theme.renderCheckboxField(NS, "partie", item.partie, i18n("PARTIE")) + "\n    " + Theme.renderTextField(NS, "matricule", item.matricule, i18n("MATRICULE"), 20) + "\n    " + Theme.renderDropdownField(NS, "zoneid", zoneid, i18n("ZONEID")) + "\n    " + Theme.renderTextField(NS, "secteur", item.secteur, i18n("SECTEUR"), 2) + "\n    " + Theme.renderNumberField(NS, "cadastre", item.cadastre, i18n("CADASTRE")) + "\n    " + Theme.renderCheckboxField(NS, "reforme", item.reforme, i18n("REFORME")) + "\n    " + Theme.renderTextField(NS, "lotscomplementaires", item.lotscomplementaires, i18n("LOTSCOMPLEMENTAIRES"), 255) + "\n    " + Theme.renderCheckboxField(NS, "certifie", item.certifie, i18n("CERTIFIE")) + "\n    " + Theme.renderTextField(NS, "numerocertification", item.numerocertification, i18n("NUMEROCERTIFICATION"), 50) + "\n    " + Theme.renderCheckboxField(NS, "ogc", item.ogc, i18n("OGC")) + "\n    " + Theme.renderBlame(item, isNew) + "\n";
            };
            pageTemplate = function (item, form, tab, warning, dirty) {
                var canEdit = true;
                var readonly = !canEdit;
                var canInsert = canEdit && isNew; // && Perm.hasLot_CanAddLot;
                var canDelete = canEdit && !canInsert; // && Perm.hasLot_CanDeleteLot;
                var canAdd = canEdit && !canInsert; // && Perm.hasLot_CanAddLot;
                var canUpdate = canEdit && !isNew;
                var buttons = [];
                buttons.push(Theme.buttonCancel(NS));
                if (canInsert)
                    buttons.push(Theme.buttonInsert(NS));
                if (canDelete)
                    buttons.push(Theme.buttonDelete(NS));
                if (canAdd)
                    buttons.push(Theme.buttonAddNew(NS, "#/lot/new"));
                if (canUpdate)
                    buttons.push(Theme.buttonUpdate(NS));
                var actions = Theme.renderButtons(buttons);
                var title = layout_11.buildTitle(xtra, !isNew ? i18n("lot Details") : i18n("New lot"));
                var subtitle = layout_11.buildSubtitle(xtra, i18n("lot subtitle"));
                return "\n<form onsubmit=\"return false;\" " + (readonly ? "class='js-readonly'" : "") + ">\n<input type=\"submit\" style=\"display:none;\" id=\"" + NS + "_dummy_submit\">\n\n<div class=\"js-fixed-heading\">\n<div class=\"js-head\">\n    <div class=\"content js-uc-heading js-flex-space\">\n        <div>\n            <div class=\"title\"><i class=\"" + layout_11.icon + "\"></i> <span>" + title + "</span></div>\n            <div class=\"subtitle\">" + subtitle + "</div>\n        </div>\n        <div>\n            " + Theme.wrapContent("js-uc-actions", actions) + "\n            " + Theme.renderBlame(item, isNew) + "\n        </div>\n    </div>\n    " + Theme.wrapContent("js-uc-tabs", tab) + "\n</div>\n<div class=\"js-body\">\n    " + Theme.wrapContent("js-uc-notification", dirty) + "\n    " + Theme.wrapContent("js-uc-notification", warning) + "\n    " + Theme.wrapContent("js-uc-details", form) + "\n</div>\n</div>\n\n" + Theme.renderModalDelete("modalDelete_" + NS, NS + ".drop()") + "\n\n</form>\n";
            };
            dirtyTemplate = function () {
                return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
            };
            exports_55("fetchState", fetchState = function (id) {
                isNew = isNaN(id);
                isDirty = false;
                Router.registerDirtyExit(dirtyExit);
                return App.GET("/lot/" + (isNew ? "new" : id))
                    .then(function (payload) {
                    state = payload.item;
                    fetchedState = Misc.clone(state);
                    xtra = payload.xtra;
                    key = { id: id };
                    contingent_dateCalendar.setState(state.contingent_date);
                    droit_coupe_dateCalendar.setState(state.droit_coupe_date);
                    entente_paiement_dateCalendar.setState(state.entente_paiement_date);
                    proprietaireidAutocomplete.setState(state.proprietaireid, state.proprietaireid_text);
                })
                    .then(Lookup.fetch_canton())
                    .then(Lookup.fetch_municipalite())
                    .then(Lookup.fetch_contingent())
                    .then(Lookup.fetch_droit_coupe())
                    .then(Lookup.fetch_entente_paiement())
                    .then(Lookup.fetch_zone());
            });
            exports_55("fetch", fetch = function (params) {
                var id = +params[0];
                App.prepareRender(NS, i18n("lot"));
                fetchState(id)
                    .then(App.render)
                    .catch(App.render);
            });
            exports_55("render", render = function () {
                if (!inContext())
                    return "";
                if (App.fatalError())
                    return App.fatalErrorTemplate();
                if (state == undefined || Object.keys(state).length == 0)
                    return App.warningTemplate() || App.unexpectedTemplate();
                var year = Perm.getCurrentYear(); //or something better
                var lookup_canton = Lookup.get_canton(year);
                var lookup_municipalite = Lookup.get_municipalite(year);
                var lookup_contingent = Lookup.get_contingent(year);
                var lookup_droit_coupe = Lookup.get_droit_coupe(year);
                var lookup_entente_paiement = Lookup.get_entente_paiement(year);
                var lookup_zone = Lookup.get_zone(year);
                var cantonid = Theme.renderOptions(lookup_canton, state.cantonid, true);
                var municipaliteid = Theme.renderOptions(lookup_municipalite, state.municipaliteid, true);
                var contingentid = Theme.renderOptions(lookup_contingent, state.contingentid, true);
                var droit_coupeid = Theme.renderOptions(lookup_droit_coupe, state.droit_coupeid, true);
                var entente_paiementid = Theme.renderOptions(lookup_entente_paiement, state.entente_paiementid, true);
                var zoneid = Theme.renderOptions(lookup_zone, state.zoneid, true);
                proprietaireidAutocomplete.pagedList = state_proprietaireid;
                var form = formTemplate(state, cantonid, municipaliteid, proprietaireidAutocomplete, contingentid, droit_coupeid, entente_paiementid, zoneid);
                var tab = layout_11.tabTemplate(state.id, xtra, isNew);
                var dirty = dirtyTemplate();
                var warning = App.warningTemplate();
                return pageTemplate(state, form, tab, warning, dirty);
            });
            exports_55("postRender", postRender = function () {
                if (!inContext())
                    return;
                contingent_dateCalendar.postRender();
                droit_coupe_dateCalendar.postRender();
                entente_paiement_dateCalendar.postRender();
                App.setPageTitle(isNew ? i18n("New lot") : xtra.title);
            });
            exports_55("inContext", inContext = function () {
                return App.inContext(NS);
            });
            getFormState = function () {
                var clone = Misc.clone(state);
                clone.cantonid = Misc.fromSelectText(NS + "_cantonid", state.cantonid);
                clone.rang = Misc.fromInputTextNullable(NS + "_rang", state.rang);
                clone.lot = Misc.fromInputTextNullable(NS + "_lot", state.lot);
                clone.municipaliteid = Misc.fromSelectText(NS + "_municipaliteid", state.municipaliteid);
                clone.superficie_total = Misc.fromInputNumberNullable(NS + "_superficie_total", state.superficie_total);
                clone.superficie_boisee = Misc.fromInputNumberNullable(NS + "_superficie_boisee", state.superficie_boisee);
                clone.proprietaireid = Misc.fromAutocompleteText(NS + "_proprietaireid", state.proprietaireid);
                clone.contingentid = Misc.fromSelectText(NS + "_contingentid", state.contingentid);
                clone.contingent_date = Misc.fromInputDateNullable(NS + "_contingent_date", state.contingent_date);
                clone.droit_coupeid = Misc.fromSelectText(NS + "_droit_coupeid", state.droit_coupeid);
                clone.droit_coupe_date = Misc.fromInputDateNullable(NS + "_droit_coupe_date", state.droit_coupe_date);
                clone.entente_paiementid = Misc.fromSelectText(NS + "_entente_paiementid", state.entente_paiementid);
                clone.entente_paiement_date = Misc.fromInputDateNullable(NS + "_entente_paiement_date", state.entente_paiement_date);
                clone.actif = Misc.fromInputCheckbox(NS + "_actif", state.actif);
                clone.sequence = Misc.fromInputTextNullable(NS + "_sequence", state.sequence);
                clone.partie = Misc.fromInputCheckbox(NS + "_partie", state.partie);
                clone.matricule = Misc.fromInputTextNullable(NS + "_matricule", state.matricule);
                clone.zoneid = Misc.fromSelectText(NS + "_zoneid", state.zoneid);
                clone.secteur = Misc.fromInputTextNullable(NS + "_secteur", state.secteur);
                clone.cadastre = Misc.fromInputNumberNullable(NS + "_cadastre", state.cadastre);
                clone.reforme = Misc.fromInputCheckbox(NS + "_reforme", state.reforme);
                clone.lotscomplementaires = Misc.fromInputTextNullable(NS + "_lotscomplementaires", state.lotscomplementaires);
                clone.certifie = Misc.fromInputCheckbox(NS + "_certifie", state.certifie);
                clone.numerocertification = Misc.fromInputTextNullable(NS + "_numerocertification", state.numerocertification);
                clone.ogc = Misc.fromInputCheckbox(NS + "_ogc", state.ogc);
                return clone;
            };
            valid = function (formState) {
                //if (formState.somefield.length == 0) App.setError("Somefield is required");
                return App.hasNoError();
            };
            html5Valid = function () {
                document.getElementById(NS + "_dummy_submit").click();
                var form = document.getElementsByTagName("form")[0];
                form.classList.add("js-error");
                return form.checkValidity();
            };
            exports_55("oncalendar", oncalendar = function (id) {
                if (contingent_dateCalendar.id == id)
                    contingent_dateCalendar.toggle();
                if (droit_coupe_dateCalendar.id == id)
                    droit_coupe_dateCalendar.toggle();
                if (entente_paiement_dateCalendar.id == id)
                    entente_paiement_dateCalendar.toggle();
            });
            exports_55("onautocomplete", onautocomplete = function (id) {
                if (proprietaireidAutocomplete.id == id) {
                    state_proprietaireid.pager.searchText = proprietaireidAutocomplete.textValue;
                    App.POST("/fournisseur/search", state_proprietaireid.pager)
                        .then(function (payload) {
                        state_proprietaireid = payload;
                    })
                        .then(App.render);
                }
            });
            exports_55("onchange", onchange = function (input) {
                state = getFormState();
                App.render();
            });
            exports_55("cancel", cancel = function () {
                Router.goBackOrResume(isDirty);
            });
            exports_55("create", create = function () {
                var formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.POST("/lot", Misc.createBlack(formState, blackList))
                    .then(function (payload) {
                    var newkey = payload;
                    Misc.toastSuccessSave();
                    Router.goto("#/lot/" + newkey.id, 10);
                })
                    .catch(App.render);
            });
            exports_55("save", save = function (done) {
                if (done === void 0) { done = false; }
                var formState = getFormState();
                if (!html5Valid())
                    return;
                if (!valid(formState))
                    return App.render();
                App.prepareRender();
                App.PUT("/lot", Misc.createBlack(formState, blackList))
                    .then(function (_) {
                    Misc.toastSuccessSave();
                    if (done)
                        Router.goto("#/lots/", 100);
                    else
                        Router.goto("#/lot/" + key.id, 10);
                })
                    .catch(App.render);
            });
            exports_55("drop", drop = function () {
                //(<any>key).updated = state.updated;
                App.prepareRender();
                App.DELETE("/lot", key)
                    .then(function (_) {
                    Router.goto("#/lots/", 250);
                })
                    .catch(App.render);
            });
            dirtyExit = function () {
                //console.log(fetchedState, getFormState());
                isDirty = !Misc.same(fetchedState, getFormState());
                if (isDirty) {
                    setTimeout(function () {
                        state = getFormState();
                        App.render();
                    }, 10);
                }
                return isDirty;
            };
        }
    };
});
//# sourceMappingURL=app.js.map