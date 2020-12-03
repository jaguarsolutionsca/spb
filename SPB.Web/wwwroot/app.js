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
    var ESC_MAP, tolerance, escapeHTML, keepAttr, keepClass, clone, same, changes, toInputText, fromInputText, fromInputTextNullable, toInputNumber, fromInputNumber, fromInputNumberNullable, toInputDate, fromInputDate, fromInputDateNullable, fromInputTime, fromInputTimeComboNullable, fromInputTimeNullable, toInputCheckbox, fromInputCheckbox, fromInputCheckboxMask, toStaticText, toStaticTextNA, toStaticNumber, toStaticNumberNA, toStaticNumberDecimal, toStaticMoney, toStaticDateTime, toStaticDateTimeNA, toStaticDate, toStaticDateNA, toStaticCheckbox, toStaticCheckboxYesNo, filesizeText, fromSelectNumber, fromSelectString, fromSelectBoolean, fromRadioNumber, fromRadioString, fromAutocompleteNumber, toastSuccess, toastSuccessSave, toastSuccessUpload, toastFailure, blameText, toInputTimeHHMM, toInputTimeHHMMSS, toInputDateTime_2rows, toInputDateTime_hhmm_2rows, toInputDateTime_hhmm, toInputDateTime_hhmmssNA, toInputDateTime_hhmm24, formatYYYYMMDD, formatYYYYMMDDHHMM, formatMMDDYYYY, parseYYYYMMDD, parseYYYYMMDD_number, dateOnly, previousDate, nextDate, formatDuration, isDateInstance, isValidDateString, isValidTimeString, formatLatLong, toInputLatLong, toInputLatLongDDMMCC, fromInputLatLong, fromInputLatLongNullable, getLatLongFullPrecision;
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
            exports_3("fromSelectString", fromSelectString = function (id, defValue) {
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
    var App, Router, Misc, NS, loginData, state, returnUrl, storage, steps, currentStep, formTemplate, formForgottenTemplate, formRemindedTemplate, formNewPasswordTemplate, pageTemplate, fetch, fetchInvitation, fetchReset, render, postRender, getFormState, valid, html5Valid, ensurePasswordMatch, ensureComplexityRequirement, signin, signout, forgotPassword, setCurrentStep, getAuthorization, getEmail, getName, getUID, getPermissions, hasPerm, getRoles, hasRole, getUserCaps, requireAuthentication, isAuthenticated, redirectToSignin, refreshLoginData, createLoginData, b64DecodeUnicode, persistLoginData, restoreLoginData, destroyLoginData, hasLoginData;
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
                return "\n<form onsubmit=\"App_Auth.signin(" + step + "); return false;\">\n<input type=\"submit\" style=\"display:none;\" id=\"App_Auth_dummy_submit\">\n    <div class=\"has-text-centered js-help\">\n        <h2>\n            " + i18n("Now, let's set your password") + "\n        </h2>\n        <div class=\"content\">\n            <p>\n                " + i18n("You need to enter your password twice below") + "\n            </p>\n        </div>\n    </div>\n    <div class=\"field\">\n        <div class=\"control has-icons-left\">\n            <input type=\"email\" class=\"input\" id=\"App_Auth_email\" placeholder=\"" + i18n("EMAIL") + "\" value=\"" + Misc.toInputText(item.email) + "\">\n            <span class=\"icon is-small is-left\">\n                <i class=\"fas fa-envelope\"></i>\n            </span>\n        </div>\n    </div>\n    <div style=\"margin: 1rem;\">\n        <p style=\"margin: 1rem;\">Passwords must meet the following complexity requirements:</p>\n        <ul style=\"padding-left: 5rem; list-style: disc;\">\n            <li>8 characters minimum</li>\n            <li>At least one lower case character</li>\n            <li>At least one upper case character</li>\n            <li>At least one special character</li>\n        </ul>\n    </div>\n    <div class=\"field\">\n        <div class=\"control has-icons-left\">\n            <input type=\"password\" class=\"input\" id=\"App_Auth_password\" placeholder=\"" + i18n("PASSWORD") + "\" onkeyup=\"App_Auth.ensurePasswordMatch()\" required>\n            <span class=\"icon is-small is-left\">\n                <i class=\"fas fa-lock\"></i>\n            </span>\n        </div>\n    </div>\n    <div class=\"field\">\n        <div class=\"control has-icons-left\">\n            <input type=\"password\" class=\"input\" id=\"App_Auth_password2\" placeholder=\"" + i18n("ENTER PASSWORD AGAIN") + "\" onkeyup=\"App_Auth.ensurePasswordMatch()\" required>\n            <span class=\"icon is-small is-left\">\n                <i class=\"fas fa-lock\"></i>\n            </span>\n        </div>\n    </div>\n    <button type=\"submit\" class=\"button is-block is-primary is-fullwidth\">\n        <i class=\"fas fa-sign-in-alt\"></i>&nbsp;" + i18n("Sign In") + "\n    </button>\n</form>\n";
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
                if (password.length < 8)
                    return false;
                if (password == password.toUpperCase())
                    return false;
                if (password == password.toLowerCase())
                    return false;
                return /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/.test(password);
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
                    cid: +payload["cid"],
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
System.register("_BaseApp/src/theme/pager", ["_BaseApp/src/lib-ts/misc"], function (exports_10, context_10) {
    "use strict";
    var Misc, NullPager, render, renderStatic, sortableHeaderLink, headerLink, rowNumber, asParams, searchTemplate;
    var __moduleName = context_10 && context_10.id;
    return {
        setters: [
            function (Misc_2) {
                Misc = Misc_2;
            }
        ],
        execute: function () {
            exports_10("NullPager", NullPager = { pageNo: 1, pageSize: 1000, rowCount: 0, searchText: "", sortColumn: "", sortDirection: "", filter: {} });
            exports_10("render", render = function (pager, ns, sizes, searchHtml, customHtml) {
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
            exports_10("renderStatic", renderStatic = function (pager) {
                return "\n<div class=\"js-container\">\n    <div class=\"js-filter-column\"></div>\n    <div class=\"js-control\">\n        <span><em>" + pager.rowCount + " records found</strong></em>\n    </div>\n</div>";
            });
            exports_10("sortableHeaderLink", sortableHeaderLink = function (pager, ns, linkText, columnName, defaultDirection /*"ASC"*/, style) {
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
            exports_10("headerLink", headerLink = function (linkText) {
                return "<th class=\"js-no-sorting\">" + linkText + "</th>";
            });
            exports_10("rowNumber", rowNumber = function (pager, index) {
                return 1 + index + ((pager.pageNo - 1) * pager.pageSize);
            });
            exports_10("asParams", asParams = function (pager) {
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
            exports_10("searchTemplate", searchTemplate = function (pager, ns, xtra) {
                return "\n    <div class=\"field\">\n        <label class=\"label\">" + i18n("Search") + "</label>\n        <div class=\"control has-icons-left\" style=\"width:125px;\">\n            <input class=\"input\" type=\"text\" placeholder=\"" + i18n("Search") + "\" value=\"" + Misc.toInputText(pager.searchText) + "\" xonchange=\"" + ns + ".search(this)\" onkeydown=\"if (event.keyCode == 13) " + ns + ".search(event.target)\" " + (xtra || "") + ">\n            <span class=\"icon is-small is-left\">\n                <i class=\"fas fa-search\"></i>\n            </span>\n        </div>\n    </div>";
            });
        }
    };
});
System.register("_BaseApp/src/admin/lookupdata", ["_BaseApp/src/core/app"], function (exports_11, context_11) {
    "use strict";
    var App, authrole, lutGroup, fetch_authrole, fetch_lutGroup;
    var __moduleName = context_11 && context_11.id;
    return {
        setters: [
            function (App_4) {
                App = App_4;
            }
        ],
        execute: function () {
            exports_11("fetch_authrole", fetch_authrole = function () {
                return function (data) {
                    if (authrole != undefined && authrole.length > 0)
                        return;
                    return App.GET("/auth/role").then(function (json) { exports_11("authrole", authrole = json); });
                };
            });
            exports_11("fetch_lutGroup", fetch_lutGroup = function () {
                return function (data) {
                    if (lutGroup != undefined && lutGroup.length > 0)
                        return;
                    return App.GET("/lookup/lutGroup").then(function (json) { exports_11("lutGroup", lutGroup = json); });
                };
            });
        }
    };
});
System.register("_BaseApp/src/lang/en-CA", [], function (exports_12, context_12) {
    "use strict";
    var en_CA;
    var __moduleName = context_12 && context_12.id;
    return {
        setters: [],
        execute: function () {
            exports_12("en_CA", en_CA = {
                values: {
                    "EMAIL": "Email",
                    "PASSWORD": "Password"
                }
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
                return "\n<div class=\"modal js-modal-delete\" id=\"" + id + "\" js-skip-render-class=\"is-active\">\n    <div class=\"modal-background\" onclick=\"App_Theme.closeModal(this);\"></div>\n    <div class=\"modal-card\">\n<div>\n        <header class=\"modal-card-head\">\n            <p class=\"modal-card-title\">" + i18n("Confirm Delete") + "</p>\n            <button class=\"delete\" onclick=\"App_Theme.closeModal(this);\"></button>\n        </header>\n        <section class=\"modal-card-body\">\n            <div class=\"level\">\n                <div class=\"level-item has-text-centered\">\n                    <div>\n                        <p class=\"heading has-text-weight-bold\">" + i18n("Are you sure you want to delete this item?") + "</p>\n                        <p class=\"heading\">" + i18n("This operation cannot be undone.") + "</p>\n                    </div>\n                </div>\n            </div>\n        </section>\n        <footer class=\"modal-card-foot\">\n            <button class=\"button\" onclick=\"App_Theme.closeModal(this);\">\n                <!--<span class=\"icon\"><i class=\"fa fa-reply\"></i></span>--> <span>" + i18n("CANCEL") + "</span>\n            </button>\n            <button class=\"button is-danger\" onclick=\"App_Theme.closeModal(this);" + onclick + "\">\n                <span class=\"icon\"><i class=\"fa fa-times\"></i></span> <span>" + i18n("Yes, Delete") + "</span>\n            </button>\n        </footer>\n</div>\n    </div>\n</div>";
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
                if (isNew || obj == undefined || obj.updatedUtc == undefined || obj.by == undefined)
                    return "";
                return "\n    <div class=\"has-text-right js-blame\">\n        <span>Last updated on " + Misc.toStaticDateTime(obj.updatedUtc) + (obj.by ? " by " + obj.by : "") + "</span>\n    </div>\n";
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
    var App, yearFilter, dateFilter, district, fetch_district, get_district_plus_hq, get_district, get_district_plus_hq_inRegion, get_district_inRegion, region, fetch_region, get_region_plus_hq, get_region, fcause, fetch_fcause, get_fcause, tools, fetch_tools, get_tools;
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
                    "lutGroup": lookupdata_1_1["lutGroup"]
                });
            }
        ],
        execute: function () {
            yearFilter = function (one, year) { return year >= one.started && (one.ended == undefined || year <= one.ended); };
            dateFilter = function (one, date) { return date >= one.started && (one.ended == undefined || date <= one.ended); };
            exports_34("fetch_district", fetch_district = function () {
                return function (data) {
                    if (district != undefined && district.length > 0)
                        return;
                    return App.GET("/lookup/district").then(function (json) { district = json; });
                };
            });
            exports_34("get_district_plus_hq", get_district_plus_hq = function (year) { return district.filter(function (one) { return yearFilter(one, year); }); });
            exports_34("get_district", get_district = function (year) { return district.filter(function (one) { return yearFilter(one, year) && one.value1 != "HQ"; }); });
            exports_34("get_district_plus_hq_inRegion", get_district_plus_hq_inRegion = function (regionLUID, year) {
                return district
                    .filter(function (one) { return yearFilter(one, year); })
                    .filter(function (one) { return +one.value2 == regionLUID; })
                    .map(function (one) { return ({
                    id: one.id,
                    code: one.code,
                    description: one.description,
                    disabled: false
                }); });
            });
            exports_34("get_district_inRegion", get_district_inRegion = function (regionLUID, year) {
                return district
                    .filter(function (one) { return yearFilter(one, year); })
                    .filter(function (one) { return +one.value2 == regionLUID; })
                    .filter(function (one) { return one.value1 != "HQ"; })
                    .map(function (one) { return ({
                    id: one.id,
                    code: one.code,
                    description: one.description,
                    disabled: false
                }); });
            });
            exports_34("fetch_region", fetch_region = function () {
                return function (data) {
                    if (region != undefined && region.length > 0)
                        return;
                    return App.GET("/lookup/region").then(function (json) { region = json; });
                };
            });
            exports_34("get_region_plus_hq", get_region_plus_hq = function (year) { return region.filter(function (one) { return yearFilter(one, year); }); });
            exports_34("get_region", get_region = function (year) { return region.filter(function (one) { return yearFilter(one, year) && one.code != "HQ"; }); });
            exports_34("fetch_fcause", fetch_fcause = function () {
                return function (data) {
                    if (fcause != undefined && fcause.length > 0)
                        return;
                    return App.GET("/lookup/cause").then(function (json) { fcause = json; });
                };
            });
            exports_34("get_fcause", get_fcause = function (year) { return fcause.filter(function (one) { return yearFilter(one, year); }); });
            exports_34("fetch_tools", fetch_tools = function () {
                return function (data) {
                    if (tools != undefined && tools.length > 0)
                        return;
                    return App.GET("/lookup/by/tools").then(function (json) { tools = json; });
                };
            });
            exports_34("get_tools", get_tools = function (year) { return tools; });
        }
    };
});
System.register("src/home", ["_BaseApp/src/core/app", "_BaseApp/src/core/router", "_BaseApp/src/lib-ts/misc", "src/layout"], function (exports_35, context_35) {
    "use strict";
    var App, Router, Misc, Layout, NS, menuData, yesterday, today, tomorrow, tomorrow_2, tomorrow_3, tomorrow_4, region, getMenuData, clearMenuData, renderDropdown, menuTemplate, pageTemplate, fetchState, fetch, render, postRender, getFormState, onchange, gotoFire, uploadPerimeter, gotoTicket, ongotoFire, ongotoTicket, loadToolsState, saveToolsState;
    var __moduleName = context_35 && context_35.id;
    return {
        setters: [
            function (App_8) {
                App = App_8;
            },
            function (Router_4) {
                Router = Router_4;
            },
            function (Misc_13) {
                Misc = Misc_13;
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
                        name: "Territoires",
                        icon: "far fa-fire",
                        columnClass: "is-half-tablet is-one-third-widescreen",
                        canView: true,
                        sections: [
                            {
                                name: "Entrée de données", icon: "fal fa-table",
                                links: [
                                    { name: "Daily Fire", href: "#/firedays", ns: ["App_firedays", "App_fireday", "App_firemap"] },
                                    { name: "Fire History", href: "#/fires", ns: ["App_fires", "App_fire"] },
                                ]
                            },
                            {
                                name: "Rapports", icon: "fal fa-file-alt", canView: true,
                                links: [
                                    { name: "Daily Fire", onclick: "App_rpt_bydate.fetch_dailyfire()" },
                                    { name: "Fire History", onclick: "App_rpt_byfire.fetch_firehistory()" },
                                ]
                            },
                        ]
                    },
                    {
                        name: "Essences",
                        icon: "far fa-sun-cloud",
                        columnClass: "is-half-tablet is-one-third-widescreen",
                        canView: true,
                        sections: [
                            {
                                name: "Entrée de données", icon: "fal fa-table",
                                links: [
                                    { name: "Weather/Day", hidden: true },
                                    { name: "Weather/Station", hidden: true },
                                ]
                            },
                            {
                                name: "Rapports", icon: "fal fa-file-alt",
                                links: [
                                    { name: "Weather/Day", onclick: "App_rpt_wxbydate.fetch_wxbyday()" },
                                    { name: "Weather/Station", onclick: "App_rpt_wxbystation.fetch()" },
                                ]
                            },
                        ]
                    },
                    {
                        name: "Administration",
                        icon: "fa fa-cogs",
                        columnClass: "is-half-tablet",
                        canView: true,
                        sections: [
                            {
                                name: "Gestion", icon: "fas fa-lock",
                                links: [
                                    { name: "Comptes", href: "#/admin/accounts", ns: ["App_accounts", "App_account"] },
                                    { name: "Matrice de sécurité", href: "#/admin/apages", ns: ["App_Apages", "App_Apage"] },
                                    { name: "Audit", href: "#/admin/audittrails", ns: ["App_auditTrails"] },
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
                var sectionTemplate = function (section, columnClass) {
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
                    return "\n        <div class=\"column " + (section.maxrows == undefined ? columnClass : "") + "\">\n            <h3><i class=\"" + section.icon + "\"></i> " + section.name + "</h3>\n            <div class=\"js-links\">" + reduceSection() + "</div>\n        </div>\n";
                };
                var menuItemTemplate = function (menuItem) {
                    return "\n<div class=\"column is-half-tablet is-one-third-fullhd\">\n    <div class=\"box\">\n        <div class=\"js-widget\">\n            <div class=\"tile\">\n                <i class=\"" + menuItem.icon + " fa-4x\"></i>\n                <div>" + menuItem.name + "</div>\n            </div>\n            <div class=\"columns is-mobile is-multiline\">\n                " + menuItem.sections.filter(function (one) { return one.canView == undefined || one.canView; }).reduce(function (html, item) { return html + sectionTemplate(item, menuItem.columnClass); }, "") + "\n            </div>\n        </div>\n    </div>\n</div>\n";
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
                App.prepareRender(NS, "Home");
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
            gotoFire = function () {
                return "\n<div class=\"control has-icons-right\" style=\"width: 110px; margin: 0.5rem 0;\">\n    <input class=\"input is-primary\" type=\"text\" placeholder=\"Quick Fire\" maxlength=\"5\" onkeydown=\"if(event.keyCode==13)" + NS + ".ongotoFire(event.target)\">\n    <span class=\"icon is-right\"><i class=\"far fa-link\"></i></span>\n</div>\n";
            };
            uploadPerimeter = function () {
                return "\n<a href=\"#/fireperimeter/new\">\n    <span class=\"icon is-small\">\n        <i class=\"far fa-cloud-upload-alt\"></i>\n    </span>\n    <span>Upload Perimeter</span>\n</a>\n";
            };
            gotoTicket = function () {
                return "\n<div class=\"control has-icons-right\" style=\"width: 125px; margin: 0.5rem 0;\">\n    <input class=\"input is-primary js-no-spinner\" type=\"number\" placeholder=\"Quick Ticket\" maxlength=\"5\" onkeydown=\"if(event.keyCode==13)" + NS + ".ongotoTicket(event.target)\">\n    <span class=\"icon is-right\"><i class=\"far fa-link\"></i></span>\n</div>\n";
            };
            exports_35("ongotoFire", ongotoFire = function (element) {
                App.prepareRender();
                var fireno = element.value;
                App.GET("/fire/exists/" + fireno)
                    .then(function (fireid) {
                    if (fireid != undefined) {
                        Router.goto("#/fire/" + fireid, 10);
                    }
                    else {
                        Misc.toastFailure("Invalid Fire number", 2500);
                        App.render();
                    }
                })
                    .catch(App.render);
            });
            exports_35("ongotoTicket", ongotoTicket = function (element) {
                App.prepareRender();
                var ticketno = element.value;
                App.GET("/ticket/exists/" + ticketno)
                    .then(function (ticketid) {
                    if (ticketid != undefined) {
                        Router.goto("#/ticket/" + ticketid, 10);
                    }
                    else {
                        Misc.toastFailure("Invalid Ticket number", 2500);
                        App.render();
                    }
                })
                    .catch(App.render);
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
System.register("src/layout", ["_BaseApp/src/core/app", "src/permission", "src/main", "src/home"], function (exports_36, context_36) {
    "use strict";
    var App, Perm, Main, Home, NS, render, postRender, renderHeader, menuTemplate, renderAsideMenu, isActive, menuClick, toggle, setOpenedMenu, editProfile, toggleProfileMenu;
    var __moduleName = context_36 && context_36.id;
    return {
        setters: [
            function (App_9) {
                App = App_9;
            },
            function (Perm_1) {
                Perm = Perm_1;
            },
            function (Main_1) {
                Main = Main_1;
            },
            function (Home_2) {
                Home = Home_2;
            }
        ],
        execute: function () {
            exports_36("NS", NS = "App_Layout");
            exports_36("render", render = function () {
                Main.saveUIState();
                // Note: Render js-uc-main content first, before renderHeader() and renderAsideMenu(), 
                // so they can potentially have an impact over there.
                var ucMain = "\n" + Home.render() + "\n";
                var menu = menuTemplate(Home.getMenuData());
                return "\n<div class=\"js-layout " + (Main.state.menuOpened ? "" : "js-close") + "\">\n" + renderHeader() + "\n" + renderAsideMenu(menu) + "\n<section class=\"js-uc-main js-waitable\">\n" + ucMain + "\n</section>\n</div>\n";
            });
            exports_36("postRender", postRender = function () {
                Home.postRender();
            });
            renderHeader = function () {
                return "\n<header class=\"js-uc-header\">\n\n    <div class=\"js-logo\">\n        <div class=\"js-bars\">\n            <button class=\"button is-primary\" onclick=\"" + NS + ".menuClick()\">\n                <div class=\"icon\"><i class=\"fas fa-bars\"></i></div>\n            </button>\n        </div>\n        <a href=\"#\" onclick=\"" + NS + ".toggle('opsfms')\">\n            <span>OpsFMS</span>\n        </a>\n        <div style=\"width:20px;margin-right:1rem;\">&nbsp;</div>\n    </div>\n\n    <div class=\"js-navbar\">\n        <div class=\"js-navbar-items\">\n            <div class=\"js-items\">\n                <button class=\"button is-primary\" onclick=\"" + NS + ".help()\" style=\"font-size:125%\">\n                    <span class=\"icon\"><i class=\"fas fa-question-circle\"></i></span>\n                </button>\n                <div class=\"navbar-item has-dropdown\" onclick=\"" + NS + ".toggleProfileMenu(this)\">\n                    <a class=\"navbar-link\">\n                        " + Perm.getEmail() + "\n                    </a>\n                    <div class=\"navbar-dropdown\">\n                        <div class=\"navbar-item\">\n                            <div><b>" + Perm.getName() + "</b></div>\n                        </div>\n                        <div class=\"navbar-item\">\n                            <button class=\"button is-fullwidth is-primary\" onclick=\"" + NS + ".toggleProfileMenu();" + NS + ".editProfile()\">\n                                <i class=\"far fa-user\"></i>&nbsp;&nbsp;Edit Profile\n                            </button>\n                        </div>\n                        <hr class=\"navbar-divider\">\n                        <div class=\"navbar-item\">\n                            <button class=\"button is-fullwidth is-outlined\" onclick=\"" + NS + ".toggleProfileMenu();App_Auth.signout();\">\n                                <span class=\"icon\"><i class=\"fas fa-sign-out-alt\"></i></span>&nbsp;" + i18n("Sign out") + "\n                            </button>\n                        </div>\n                        <hr class=\"navbar-divider\">\n                        <a href=\"#\" class=\"navbar-item\">\n                            <div>Terms of Service</div>\n                        </a>\n                    </div>\n                </div>\n                <button class=\"button is-primary\" onclick=\"App_Auth.signout();\">\n                    <span class=\"icon\"><i class=\"fas fa-sign-out-alt\"></i></span>&nbsp;" + i18n("Sign out") + "\n                </button>\n            </div>\n        </div>\n    </div>\n\n</header>";
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
                return "\n<aside class=\"menu has-background-black-ter js-uc-aside\">\n    <div class=\"js-wrapper\">\n        <ul class=\"menu-list\">\n            <li><a href=\"#\" class=\"" + isActive(Home.NS) + "\" onclick=\"" + NS + ".toggle('home')\"><i class=\"far fa-home\"></i> Home</a></li>\n        </ul>\n        " + menu + "\n    </div>\n</aside>\n";
            };
            isActive = function (ns) {
                return App.inContext(ns) ? "is-active" : "";
            };
            exports_36("menuClick", menuClick = function () {
                Main.state.menuOpened = !Main.state.menuOpened;
                Main.saveUIState();
                App.render();
            });
            exports_36("toggle", toggle = function (entry) {
                Main.state.subMenu = (Main.state.subMenu == entry ? "" : entry);
                App.render();
            });
            exports_36("setOpenedMenu", setOpenedMenu = function (entry) {
                Main.state.subMenu = entry;
            });
            exports_36("editProfile", editProfile = function () {
                //Profile.fetch([Perm.getUID().toString()]);
                return false;
            });
            exports_36("toggleProfileMenu", toggleProfileMenu = function (element) {
                if (element)
                    element.classList.toggle("is-active");
            });
        }
    };
});
System.register("src/main", ["_BaseApp/src/core/app", "_BaseApp/src/main", "_BaseApp/src/theme/theme", "_BaseApp/src/theme/latlong", "src/fr-CA", "src/permission", "src/layout", "src/home"], function (exports_37, context_37) {
    "use strict";
    var App, BaseMain, Theme, LatLong, fr_CA_1, Perm, Layout, Home, state, html_lang, startup, loadUIState, saveUIState;
    var __moduleName = context_37 && context_37.id;
    return {
        setters: [
            function (App_10) {
                App = App_10;
            },
            function (BaseMain_1) {
                BaseMain = BaseMain_1;
            },
            function (Theme_1) {
                Theme = Theme_1;
            },
            function (LatLong_1) {
                LatLong = LatLong_1;
            },
            function (fr_CA_1_1) {
                fr_CA_1 = fr_CA_1_1;
            },
            function (Perm_2) {
                Perm = Perm_2;
            },
            function (Layout_2) {
                Layout = Layout_2;
            },
            function (Home_3) {
                Home = Home_3;
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
            exports_37("startup", startup = function (hasPublicHomePage) {
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
                //AdminMain.startup();
                //FireMain.startup();
                //WeatherMain.startup();
                //AircraftMain.startup();
                //CostMain.startup();
                //ConfigMain.startup();
                loadUIState();
            });
            exports_37("loadUIState", loadUIState = function () {
                var uid = Perm.getUID();
                var key = (uid != undefined ? "home-state:" + uid : "home-state");
                exports_37("state", state = JSON.parse(localStorage.getItem(key)));
                if (state == undefined) {
                    exports_37("state", state = {
                        menuOpened: true,
                        subMenu: ""
                    });
                }
            });
            exports_37("saveUIState", saveUIState = function () {
                var uid = Perm.getUID();
                var key = (uid != undefined ? "home-state:" + uid : "home-state");
                localStorage.setItem(key, JSON.stringify(state));
            });
        }
    };
});
System.register("src/app", ["src/main"], function (exports_38, context_38) {
    "use strict";
    var main;
    var __moduleName = context_38 && context_38.id;
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
//# sourceMappingURL=app.js.map