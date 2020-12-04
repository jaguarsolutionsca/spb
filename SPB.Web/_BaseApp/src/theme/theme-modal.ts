"use strict"

import * as domlib from "../lib-ts/domlib"
import * as Misc from "../lib-ts/misc"
import * as Lookup from "../admin/lookupdata"

declare const i18n: any;


export const renderModalDelete = (id: string, onclick: string) => {
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
};

export const openModal = (id: string) => {
    document.getElementById(id).classList.add("is-active");
};

export const closeModal = (element: Element) => {
    domlib.closestByClassName(element, "modal").classList.remove("is-active");
};
