
"use strict"

import * as Auth from "./auth"


export const buttonTemplate = (pageid: number) => {
    return `
<a class="button" href="#/page/${pageid}" style="margin-left: 4px;">
    <span class="icon is-small">
        <i class="fa fa-lock"></i>
    </span>
</a>`;
}

export const isAdmin = () => { return (Auth.getRoles().indexOf(1) != -1); }

export let pageTODO = -1;
//
