"use strict"

declare const i18n: any;


export const renderActionButtons = (ns: string, isNew: boolean, addUrl: string, buttons: string[] = null, updateOnly = false) => {
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
}

export const renderActionButtons2 = (ns: string, isNew: boolean, addUrl: string, buttons: string[] = null, canDelete = true, canAdd = true) => {
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
}

export const renderButtons = (buttons: string[]) => {
    let buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("") : "");
    return `
    <div class="buttons">
        ${buttonsHtml}
    </div>
`;
}

export const renderButtonsInline = (buttons: string[]) => {
    let buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("") : "");
    return `
    <div class="js-actions js-flex-end">
        <div class="buttons are-small">
            ${buttonsHtml}
        </div>
    </div>
`;
}

export const renderInlineActionButtons = (ns: string, isNew: boolean, disableDelete: boolean, disableAddNew: boolean, disableUpdate: boolean) => {
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
}


export const buttonCancelInline = (ns: string) => {
    return `<button class="button is-outlined" onclick="${ns}.undo()"><span class="icon"><i class="fa fa-undo"></i></span><span>${i18n("Undo")}</span></button>`;
}

export const buttonInsertInline = (ns: string) => {
    return `<a class="button is-primary is-outlined" onclick="${ns}.create()><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Insert")}</span></a>`;
}

export const buttonDeleteInline = (ns: string) => {
    return `<a class="button is-danger is-outlined" onclick="${ns}.drop()"><span class="icon"><i class="fa fa-times"></i></span><span>${i18n("Delete")}</span></a>`;
}

export const buttonAddNewInline = (ns: string, addUrl: string) => {
    return `<a class="button is-primary is-outlined" onclick="${ns}.addNew()"><span class="icon"><i class="fa fa-plus"></i></span><span>${i18n("Add New")}</span></a>`;
}

export const buttonUpdateInline = (ns: string) => {
    return `<a class="button is-primary is-outlined" onclick="${ns}.save()"><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Update")}</span></a>`;
}


export const renderListActionButtons = (ns: string, label: string, buttons: string[] = null) => {
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
}

export const renderListActionButtons2 = (ns: string, label: string, buttons: string[] = null) => {
    let buttonsHtml = (buttons && buttons.length > 0 ? buttons.join("&nbsp;") : "");
    return `
    <div class="buttons">
        ${buttonsHtml}
        ${label ? `<button class="button is-primary" onclick="${ns}.create()"><span class="icon"><i class="fa fa-plus"></i></span><span>${label}</span></button>` : ``}
    </div>
`;
}

export const renderListFloatingActionButtons = (ns: string, label: string) => {
    return `
        <button class="button is-primary is-rounded js-floating" title="${label}" onclick="${ns}.create()"><span class="icon"><i class="fa fa-plus"></i></span></button>
    `;
}

export const buttonCancel = (ns: string) => {
    return `<button class="button" onclick="${ns}.cancel()"><span>${i18n("Cancel")}</span></button>`;
}

export const buttonInsert = (ns: string, label = "Insert") => {
    return `<button class="button is-primary" onclick="${ns}.create()"><span class="icon"><i class="fa fa-check"></i></span><span>${i18n(label)}</span></button>`;
}

export const buttonDelete = (ns: string) => {
    return `<button class="button is-danger" onclick="App_Theme.openModal('modalDelete_${ns}')"><span class="icon"><i class="fa fa-times"></i></span><span>${i18n("Delete")}</span></button>`;
}

export const buttonAddNew = (ns: string, addUrl: string, label: string = null) => {
    return `<a class="button is-primary" href="${addUrl}"><span class="icon"><i class="fa fa-plus"></i></span><span>${label ? label : i18n("Add New")}</span></a>`;
}

export const buttonUpdate = (ns: string, disabled = false) => {
    return `<button class="button is-primary" ${disabled ? "disabled" : ""} onclick="${ns}.save()"><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Update")}</span></button>
            <button class="button is-primary" ${disabled ? "disabled" : ""} onclick="${ns}.save(true)"><span class="icon"><i class="fa fa-reply"></i></span><span>${i18n("Done")}</span></button>
`;
}

export const buttonUpdateNoDone = (ns: string, disabled = false) => {
    return `<button class="button is-primary" ${disabled ? "disabled" : ""} onclick="${ns}.save()"><span class="icon"><i class="fa fa-check"></i></span><span>${i18n("Update")}</span></button>
`;
}

export const buttonUpload = (ns: string, disabled = false, label = "Upload File") => {
    return `<button class="button is-primary" ${disabled ? "disabled" : ""} onclick="${ns}.create()"><span class="icon"><i class="far fa-cloud-upload-alt"></i></span><span>${i18n(label)}</span></button>`;
}
