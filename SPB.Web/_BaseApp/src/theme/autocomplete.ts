"use strict"

import * as App from "../core/app"
import { IPagedList } from "./pager"

declare const i18n: any

export interface IOption {
    keyTemplate: (one: any) => string
    valueTemplate: (one: any) => string
    detailTemplate: (one: any) => string
}

export class Autocomplete {
    id: string
    private initialKey: string
    private initialText: string
    private key: string
    private text: string
    pagedList: IPagedList<any, any>
    options: IOption
    isActive = false
    disabled = false
    private input_id: string
    private typingTimer
    private blurTimer

    constructor (public ns: string, public propName: string, public required = false) {
        this.input_id = `${this.ns}_${this.propName}`
        this.id = `${this.ns}_${this.propName}Autocomplete`
        window[this.id] = this
    }

    public setState(key: string, text: string) {
        this.initialKey = this.key = key
        this.initialText = this.text = text
    }

    public render = () => {
        let hasIndex = this.pagedList.list.reduce((selected: boolean, one) => one.selected ? true : selected, false);
        if (!hasIndex) {
            let index = (this.required || this.text == undefined || this.text.length == 0 ? 0 : 1)
            if (this.pagedList.list.length > index)
                this.pagedList.list[index].selected = true;
        }

        let opt = this.options
        let textRows = this.pagedList.list.map((one, index) => {
            let key = opt.keyTemplate(one);
            let value = opt.valueTemplate(one).replace(/"/g, "&quot;");
            let active = (one.selected ? "is-active" : "");
            let detail = opt.detailTemplate(one);
            return `<a href="#" data-key="${key}" data-value="${value}" data-index="${index}" onclick="${this.handle('a.onclick')}; return false;" class="dropdown-item ${active}"><p>${detail}</p></a>`
        })
        let text = textRows.join('<hr class="dropdown-divider">')

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
    }

    public postRender = () => {
    }

    public handle = (eventName: string) => {
        return `${this.id}.on(this, '${eventName}')`
    }

    public on = (element: HTMLInputElement | HTMLAnchorElement, eventName: string) => {
        if (eventName == 'onfocus') {
            this.isActive = true
            this.text = (<HTMLInputElement>element).value
            window[this.ns].onautocomplete(this.id)
        }
        else if (eventName == 'onkeydown') {
            let kevent = <KeyboardEvent>event
            if (kevent.key == "ArrowUp") {
                event.preventDefault()
                let index = this.pagedList.list.findIndex(one => one.selected)
                if (index > 0) {
                    this.pagedList.list[index].selected = false
                    this.pagedList.list[index - 1].selected = true
                    App.render()
                }
            }
            else if (kevent.key == "ArrowDown") {
                event.preventDefault()
                let index = this.pagedList.list.findIndex(one => one.selected)
                if (index < this.pagedList.list.length - 1) {
                    this.pagedList.list[index].selected = false
                    this.pagedList.list[index + 1].selected = true
                    App.render()
                }
            }
            else if (this.isActive && ["Tab", "Enter", "Escape"].indexOf(kevent.key) > -1) {
                event.preventDefault()
                clearTimeout(this.blurTimer)

                let one = this.pagedList.list.find(one => one.selected)
                let key = this.options.keyTemplate(one)
                let text = this.options.valueTemplate(one).replace(/"/g, "&quot;")
                this.setState(key, text)
                this.isActive = false

                let input = document.getElementById(this.input_id)
                input.dataset["key"] = this.key
                input.blur()
                window[this.ns].onchange(input)
            }
            else {
                clearTimeout(this.typingTimer)
                this.typingTimer = setTimeout(_ => {
                    this.isActive = true
                    this.text = (<HTMLInputElement>element).value
                    window[this.ns].onautocomplete(this.id)
                }, 50)
            }
        }
        else if (eventName == "a.onclick") {
            clearTimeout(this.blurTimer)

            let key = element.dataset["key"]
            let text = element.dataset["value"]
            this.setState(key, text)
            this.isActive = false

            let input = document.getElementById(this.input_id)
            input.dataset["key"] = this.key
            window[this.ns].onchange(input)
        }
        else if (eventName == "onblur") {
            this.blurTimer = setTimeout(_ => {
                this.isActive = false
                let required = element.hasAttribute("required")
                if (required) {
                    this.setState(this.initialKey, this.initialText)
                    App.render()
                }
                else {
                    let value = (<HTMLInputElement>element).value.trim()
                    if (value.length == 0 || value != this.initialText) {
                        this.setState(null, null)
                        element.dataset["key"] = this.key
                        window[this.ns].onchange(element)
                    }
                    else {
                        App.render()
                    }
                }
            }, 500)
        }
    }

    public get keyValue() {
        return this.key
    }

    public get textValue(): string {
        return this.text
    }
}
