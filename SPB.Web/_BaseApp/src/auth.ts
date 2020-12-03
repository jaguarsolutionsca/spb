"use strict"

import * as App from "./core/app"
import * as Router from "./core/router"
import * as Misc from "./lib-ts/misc"
import * as domlib from "./lib-ts/domlib"

declare const i18n: any;


export const NS = "App_Auth";

interface LoginData {
    token: string
    user: UserCaps
    expiry: number
}

export interface UserCaps {
    email: string
    name: string
    roles: number[]
    permissions: number[]
    uid: number
    cid: number
}

var loginData = <LoginData>{};

interface IState {
    email: string
    password: string
}

let state = <IState>{};
let returnUrl = "/";
let storage: Storage;

enum steps {
    normal,
    forgotten,
    reminded,
    invited,
    resetted
}
let currentStep = steps.normal;

const formTemplate = (item: IState) => {
    let enablePasswordChange = (<any>window).APP.portalbag.feature.enableEmail ?? false;

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
}

const formForgottenTemplate = (item: IState) => {
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
}

const formRemindedTemplate = (item: IState) => {
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
}

const formNewPasswordTemplate = (item: IState, step: steps) => {
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
    <div style="margin: 1rem;">
        <p style="margin: 1rem;">Passwords must meet the following complexity requirements:</p>
        <ul style="padding-left: 5rem; list-style: disc;">
            <li>8 characters minimum</li>
            <li>At least one lower case character</li>
            <li>At least one upper case character</li>
            <li>At least one special character</li>
        </ul>
    </div>
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
}

const pageTemplate = (item: IState, form: string, alert: string) => {
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

export const fetch = (params: string[]) => {
    returnUrl = "/";
    if (params != undefined && params.length > 0) {
        returnUrl = decodeURIComponent(params[0]);
    }
    App.prepareRender(NS, i18n("Signin"));
    Router.registerDirtyExit(null);
    App.render();
};

export const fetchInvitation = (params: string[]) => {
    returnUrl = "/";
    let guid = params[0];
    App.prepareRender(NS, i18n("Signin"));
    App.GET(`/auth/accept-invitation/${guid}`)
        .then(json => {
            currentStep = steps.invited;
            state = <IState>json;
            App.render();
        })
        .catch(App.render);
};

export const fetchReset = (params: string[]) => {
    returnUrl = "/";
    let guid = params[0];
    App.prepareRender(NS, i18n("Signin"));
    App.GET(`/auth/reset-password/${guid}`)
        .then(json => {
            currentStep = steps.resetted;
            state = <IState>json;
            App.render();
        })
        .catch(App.render);
};

export const render = () => {
    if (App.fatalError()) return App.fatalErrorTemplate();
    if (state == undefined) return (App.serverError() ? pageTemplate(null, "", App.warningTemplate()) : "");

    let form: string;
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
};

export const postRender = () => {
    if (!App.inContext(NS)) return;
};

const getFormState = () => {
    return <IState>{
        email: Misc.fromInputText("App_Auth_email"),
        password: Misc.fromInputText("App_Auth_password")
    };
};

const valid = (formState: IState): boolean => {
    if (formState.email.length == 0)
        App.setError("Email is required");
    if (formState.password && formState.password.length == 0)
        App.setError("Password is required");
    return App.hasNoError();
};

const html5Valid = (): boolean => {
    document.getElementById("App_Auth_dummy_submit").click();
    let form = document.getElementsByTagName("form")[0];
    form.classList.add("js-error");
    return form.checkValidity();
};

export const ensurePasswordMatch = () => {
    let password = <HTMLInputElement>document.getElementById("App_Auth_password");
    let password2 = <HTMLInputElement>document.getElementById("App_Auth_password2");
    if (password.value != password2.value)
        password2.setCustomValidity(i18n("Passwords don't match"));
    else if (!ensureComplexityRequirement(password.value))
        password2.setCustomValidity("Password doesn't meet complexity requirement");
    else
        password2.setCustomValidity("");
}

const ensureComplexityRequirement = (password: string) => {
    if (password.length < 8) return false;
    if (password == password.toUpperCase()) return false;
    if (password == password.toLowerCase()) return false;
    return /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/.test(password);
}

export const signin = (step: number = 0) => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
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
}

export const signout = () => {
    App.transitionUI();
    App.POST("/auth/signout", null)
        .then(json => {
            destroyLoginData();
            returnUrl = "/";
            Router.goto(returnUrl, 10);
        })
        .catch(App.render);
};

export const forgotPassword = () => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
    App.transitionUI();
    App.POST("/auth/request-password-reset", formState)
        .then(_ => {
            state = formState;
            currentStep = steps.reminded;
            App.render();
        })
        .catch(App.render);
};

export const setCurrentStep = (step: steps) => {
    state = getFormState();
    currentStep = step;
    App.render();
}

export const getAuthorization = () => {
    if (!hasLoginData())
        return "";
    if (loginData == undefined || loginData.token == undefined)
        return "";
    if (new Date().getTime() / 1000 > loginData.expiry)
        return "";
    return "Bearer " + loginData.token;
}

export const getEmail = () => {
    if (loginData == undefined || loginData.user == undefined)
        return null;
    return loginData.user.email;
}

export const getName = () => {
    if (loginData == undefined || loginData.user == undefined)
        return null;
    return loginData.user.name;
}

export const getUID = () => {
    if (loginData == undefined || loginData.user == undefined)
        return null;
    return loginData.user.uid;
}

export const getPermissions = () => {
    if (loginData == undefined || loginData.user == undefined)
        return [];
    return loginData.user.permissions || [];
}

export const hasPerm = (permissionID: number) => {
    return (getPermissions().indexOf(permissionID) != -1);
}

export const getRoles = () => {
    if (loginData == undefined || loginData.user == undefined)
        return [];
    return loginData.user.roles || [];
}

export const hasRole = (roleID: number) => {
    return (getRoles().indexOf(roleID) != -1);
}

export const getUserCaps = () => {
    if (loginData == undefined || loginData.user == undefined)
        return null;
    return loginData.user;
}

export const requireAuthentication = () => {
    let logging = (window.location.hash.indexOf("#/signin/") == 0) ||
        (window.location.hash.indexOf("#/accept-invitation/") == 0) ||
        (window.location.hash.indexOf("#/reset-password/") == 0);
    return !(logging || isAuthenticated());
};

export const isAuthenticated = () => {
    return getAuthorization().length > 0;
};

export const redirectToSignin = () => {
    destroyLoginData();
    let url = window.location.hash;
    Router.goto(`#/signin/${encodeURIComponent(url)}`, 100);
}

export const refreshLoginData = () => {
    return App.POST("/auth/refresh", null)
        .then(json => {
            createLoginData(json.token);
            persistLoginData();
            Router.reload();
        })
}

const createLoginData = (token: string) => {
    let payloadBase64 = token.split('.')[1].replace(/-/g, '+').replace(/_/g, '/');
    let payloadUTF8 = b64DecodeUnicode(payloadBase64);
    let payload = JSON.parse(payloadUTF8);

    let perms: number | number[] = payload["perms"] || [];
    if (!Array.isArray(perms)) {
        perms = [perms];
    }

    let role: number | number[] = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
    if (!Array.isArray(role)) {
        role = [role];
    }

    loginData = <LoginData>{};
    loginData.token = token;
    loginData.user = <UserCaps>{
        email: payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
        name: payload["name"],
        permissions: perms,
        roles: role,
        uid: +payload["uid"],
        cid: +payload["cid"],
    };
    loginData.expiry = payload["exp"];
}

const b64DecodeUnicode = (b64: string) => {
    return decodeURIComponent(Array.prototype.map.call(atob(b64), function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2)
    }).join(''))
}

const persistLoginData = () => {
    storage.setItem("signin", JSON.stringify(loginData));
}

const restoreLoginData = () => {
    loginData = JSON.parse(storage.getItem("signin")) as LoginData;
}

const destroyLoginData = () => {
    storage.removeItem("signin");
    loginData = <LoginData>{};
}

const hasLoginData = () => {
    return storage.getItem("signin") != undefined;
}


//
// Restore loginData from storage on startup
//
storage = sessionStorage;
restoreLoginData();
