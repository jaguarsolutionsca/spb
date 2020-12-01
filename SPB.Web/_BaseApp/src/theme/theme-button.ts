"use strict"


declare const i18n: any;

export interface IChoice {
    text: string
    onclick: string
    icon?: string
}


export const renderButtonWithConfirm = (title: string, icon: string, items: string | string[], onclick: string, disabled = false, active = false, hoverable = false, ontoggle: string = null, valid = true) => {
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
};

export const renderButtonWithConfirmChoices = (title: string, icon: string, helpText: string, choices: IChoice[], disabled = false) => {
    let uid = new Date().getTime();
    let tag = (disabled ? "p" : "a");

    let choiceTemplate = (item: IChoice) => {
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
};

export const renderButton = (title: string, icon: string, onclick: string, disabled = false) => {
    return `
<button class="button" onclick="${onclick}" ${disabled ? "disabled" : ""}>
    <span class="icon"><i class="${icon}"></i></span>
    <span>${title}</span>
</button>`;
};
