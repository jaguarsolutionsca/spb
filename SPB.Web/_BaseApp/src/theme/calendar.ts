"use strict"

import * as App from "../core/app"
import * as Misc from "../lib-ts/misc"


let days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"]
let months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"]


/*
    WATCH OUT!

    new Date(“1995-01-01”) => Sat Dec 31 1994 19:00:00 GMT-0500 (Eastern Standard Time)
    new Date(1995, 0, 1) => Sun Jan 01 1995 00:00:00 GMT-0500 (Eastern Standard Time)

*/

export class Calendar {
    id: string
    initialDate: Date
    isNullDate = false
    //
    selectedYear: number
    selectedMonth: number // Jan == 1
    selectedDay: number
    selectedHour: number
    selectedMinute: number
    //
    displayedYear: number
    displayedMonth: number
    //
    viewName = "jscal-days"
    hidden = true
    hasButtons = true;
    //
    forcedYear: number
    minValue: Date
    maxValue: Date
    public isValid = true
    public disableDate = false


    constructor (private input_id: string, public required = false, public alwaysOpened = false, private asFilter = false, public hasTime = false, public hasChanger = false, public hasToday = false) {
        this.id = this.input_id + "Calendar"
        this.hidden = !alwaysOpened;
        this.hasButtons = !alwaysOpened && !asFilter;
    }

    public setState = (date: Date, forcedYear?: number, min?: Date, max?: Date) => {
        if (date != undefined) {
            this.selectedYear = this.displayedYear = date.getFullYear()
            this.selectedMonth = this.displayedMonth = date.getMonth() + 1
            this.selectedDay = date.getDate()
            this.selectedHour = date.getHours();
            this.selectedMinute = date.getMinutes();

            this.initialDate = new Date(date.getTime())
            this.isNullDate = false
        }
        else {
            let now = new Date()
            this.selectedYear = this.displayedYear = (forcedYear != undefined ? forcedYear : now.getFullYear())
            this.selectedMonth = this.displayedMonth = now.getMonth() + 1
            this.selectedDay = now.getDate()
            this.selectedHour = 0;
            this.selectedMinute = 0;

            this.initialDate = null
            this.isNullDate = true
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
    }

    public render = () => {
        let date = new Date(this.displayedYear, this.displayedMonth - 1, 1, 0, 0, 0, 0)
        let year = date.getFullYear()
        let month = date.getMonth()
        
        let firstDate = new Date(date)
        //
        while (true) {
            while (firstDate.getDay() != 0)
                firstDate.setDate(firstDate.getDate() - 1)
            if (firstDate.getMonth() != month || firstDate.getDate() == 1) break;
            firstDate.setDate(firstDate.getDate() - 1)
        }
    
        let lastDate = new Date(date)
        let lastOfMonth = new Date(year, month + 1, 0)
        //
        while (true) {
            while (lastDate.getDay() != 6)
                lastDate.setDate(lastDate.getDate() + 1)
            if (lastDate.getMonth() != month || lastDate.getTime() == lastOfMonth.getTime()) break;
            lastDate.setDate(lastDate.getDate() + 1)
        }
    
        let selectedDate = new Date(this.selectedYear, this.selectedMonth - 1, this.selectedDay, 0, 0, 0, 0)
        var tr = "";
        while (true) {
            tr += "<tr>";
            for (var iday = 0; iday < 7; iday++) {
                let selected = (firstDate.getTime() == selectedDate.getTime())
                let other = (firstDate.getMonth() != month)
                let outside = ((this.minValue && firstDate < this.minValue) || (this.maxValue && firstDate > this.maxValue))
                let dateText = [firstDate.getFullYear(), firstDate.getMonth() + 1, firstDate.getDate()].join("/");
                let classes = []
                if (selected) classes.push("selected")
                if (other) classes.push("other")
                if (outside) classes.push("outside")
                tr += `<td ${classes.length ? `class="${classes.join(" ")}"` : ""} data-select="${dateText}">${firstDate.getDate()}</td>`
                firstDate.setDate(firstDate.getDate() + 1)
            }
            tr += "</tr>";
            if (firstDate.getTime() >= lastDate.getTime()) break;
        }
    
        let prevMonth = this.displayedMonth - 1
        let prevYear = this.displayedYear
        if (prevMonth == 0) {
            prevMonth = 12
            prevYear--
        }
    
        let nextMonth = this.displayedMonth + 1
        let nextYear = this.displayedYear
        if (nextMonth == 13) {
            nextMonth = 1
            nextYear++
        }
    
        let trMonths = months.reduce((html, item, index) => {
            let month = index +1
            let name = item.substr(0, 3)
            return html + `<div data-month="${month}"${this.displayedMonth == month ? " class='selected'" : ""}>${name}</div>`
        }, "")
    
        let trYears = ""
        for (var ix = 0; ix < 9; ix++) {
            let year = this.displayedYear - 4 + ix
            trYears += `<div ${this.displayedYear == year ? "class='selected'" : ""}>${year}</div>`
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
    
    </div>`
    }
    
    public postRender = () => {
        let wrapperElem = document.getElementById(this.input_id + "_wrapper")
        if (wrapperElem == undefined) return

        // Remove event listeners
        wrapperElem.outerHTML = wrapperElem.outerHTML
        wrapperElem = document.getElementById(this.id)


        wrapperElem.querySelector(".jscal-container tbody").addEventListener("click", event => {
            var td = <HTMLTableCellElement>event.target
            if (td.dataset.select == undefined) return

            let parts = td.dataset.select.split("/")
            let selectedYear = +parts[0]
            let selectedMonth = +parts[1]
            let selectedDay = +parts[2]
            let newDate = new Date(selectedYear, selectedMonth - 1, selectedDay, 0, 0, 0, 0)
            if (this.minValue && newDate < this.minValue) return
            if (this.maxValue && newDate > this.maxValue) return

            this.selectedYear = selectedYear
            this.selectedMonth = selectedMonth
            this.selectedDay = selectedDay
            this.isNullDate = false
            if (!this.asFilter) {
                App.render()
            }
            else {
                this.initialDate = this.dateValue
                this.hidden = (true && !this.alwaysOpened)
                //
                let parts = this.input_id.split("_")
                let ns = parts.slice(0, -1).join("_")
                let name = parts[parts.length - 1]
                window[ns].oncalendar_filter(name, this.dateValue)
            }
        })
    
        wrapperElem.querySelector(".jscal-container .jscal-nav .previous").addEventListener("click", event => {
            let element = (<HTMLElement>event.target).closest("a")
            let parts = element.dataset.display.split("/")
            this.displayedYear = +parts[0]
            this.displayedMonth = +parts[1]
            App.render()
        })
    
        wrapperElem.querySelector(".jscal-container .jscal-nav .next").addEventListener("click", event => {
            let element = (<HTMLElement>event.target).closest("a")
            let parts = element.dataset.display.split("/")
            this.displayedYear = +parts[0]
            this.displayedMonth = +parts[1]
            App.render()
        })
    
        wrapperElem.querySelector(".jscal-container .jscal-date").addEventListener("click", event => {
            let element = <HTMLDivElement>(<HTMLElement>event.target).closest(".jscal-date")
            let parts = element.dataset.date.split("/")
            this.selectedYear = this.displayedYear = +parts[0]
            this.selectedMonth = this.displayedMonth = +parts[1]
            this.selectedDay = +parts[2]
            this.viewName = "jscal-days"
            App.render()
        })
    
        wrapperElem.querySelector(".jscal-container .jscal-months").addEventListener("click", event => {
            let element = <HTMLTableCellElement>event.target;
            this.displayedMonth = +element.dataset.month
            this.viewName = "jscal-days"
            App.render()
        })
    
        wrapperElem.querySelector(".jscal-container .jscal-years div").addEventListener("click", event => {
            let element = <HTMLTableCellElement>event.target;
            this.displayedYear = +element.innerText
            this.viewName = "jscal-days"
            App.render()
        })
    
        wrapperElem.querySelector(".jscal-container .jscal-years .previous").addEventListener("click", event => {
            this.displayedYear = this.displayedYear - 4
            App.render()
        })
    
        wrapperElem.querySelector(".jscal-container .jscal-years .next").addEventListener("click", event => {
            this.displayedYear = this.displayedYear + 4
            App.render()
        })
    
        wrapperElem.querySelector(".jscal-container .select-month").addEventListener("click", event => {
            this.viewName = "jscal-months"
            App.render()
        })
    
        wrapperElem.querySelector(".jscal-container .select-year").addEventListener("click", event => {
            this.viewName = "jscal-years"
            App.render()
        })

        if (this.hasButtons) {
            wrapperElem.querySelector(".jscal-container .cancel").addEventListener("click", event => {
                this.setState(this.initialDate)
                this.hidden = (true && !this.alwaysOpened);
                App.render()
            })

            wrapperElem.querySelector(".jscal-container .ok").addEventListener("click", event => {
                this.initialDate = this.dateValue
                this.hidden = (true && !this.alwaysOpened);
                //
                //App.render()
                let dateElem = <HTMLInputElement>document.getElementById(this.input_id)
                let parts = this.input_id.split("_")
                let ns = parts.slice(0, -1).join("_")
                let name = parts[parts.length - 1]
                window[ns].onchange(dateElem)
            })

            if (!this.required) {
                wrapperElem.querySelector(".jscal-container .clear")?.addEventListener("click", event => {
                    this.isNullDate = true
                    App.render()
                })
            }

            if (this.hasToday) {
                wrapperElem.querySelector(".jscal-container .today")?.addEventListener("click", event => {
                    let today = new Date(new Date().setHours(0, 0, 0, 0))
                    this.setState(today)
                    this.hidden = (true && !this.alwaysOpened);
                    //
                    //App.render()
                    let dateElem = <HTMLInputElement>document.getElementById(this.input_id)
                    dateElem.value = Misc.toInputDate(today)
                    let parts = this.input_id.split("_")
                    let ns = parts.slice(0, -1).join("_")
                    let name = parts[parts.length - 1]
                    window[ns].onchange(dateElem)
                })
            }
        }


        //
        // Date input
        //
        let dateElem = <HTMLInputElement>document.getElementById(this.input_id)
        if (dateElem) {
            dateElem.addEventListener("focus", event => {
                dateElem.value = dateElem.value.replace(/\D+/g, "")
                try {
                    if (this.forcedYear) {
                        dateElem.setSelectionRange(4, 8);
                    }
                    else {
                        dateElem.select()
                    }
                }
                catch (error) { }
                dateElem.type = "number";
            })

            const ondatechange = (event: Event) => {
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
                    date = new Date(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), this.selectedHour, this.selectedMinute, 0, 0)
                    this.setState(date, this.forcedYear, this.min, this.max)
                    //
                    let parts = this.input_id.split("_")
                    let ns = parts.slice(0, -1).join("_")
                    let name = parts[parts.length - 1]
                    if (!this.asFilter) {
                        window[ns].onchange(dateElem)
                    }
                    else {
                        window[ns].oncalendar_filter(name, this.dateValue)
                    }
                    return true;
                }

                dateElem.style.borderColor = "red";
                dateElem.style.zIndex = "1";
                this.isValid = false;
            }

            dateElem.addEventListener("change", ondatechange)

            dateElem.addEventListener("blur", (event: Event) => {
                if (isNaN(+dateElem.value)) //return if formatted yyyy-mm-dd
                    return;
                ondatechange(event);
            })
        }


        //
        // Time input
        //
        let timeElem = <HTMLInputElement>document.getElementById(this.input_id + "_time")
        if (timeElem) {
            timeElem.addEventListener("focus", event => {
                timeElem.value = timeElem.value.replace(/\D+/g, "")
                timeElem.select()
                timeElem.type = "number";
            })

            const ontimechange = (event: Event) => {
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
                    let date = new Date(this.dateValue)
                    date.setHours(+hh);
                    date.setMinutes(+mm);
                    this.setState(date, this.forcedYear, this.min, this.max)
                    //
                    let parts = this.input_id.split("_")
                    let ns = parts.slice(0, -1).join("_")
                    let name = parts[parts.length - 1]
                    window[ns].onchange(timeElem)
                    return true;
                }

                timeElem.style.borderColor = "red";
                timeElem.style.zIndex = "1";
                this.isValid = false;
            }

            timeElem.addEventListener("change", ontimechange)

            timeElem.addEventListener("blur", (event: Event) => {
                if (isNaN(+timeElem.value)) //return if formatted hh:mm
                    return;
                ontimechange(event);
            })
        }


        //
        // Clear button
        //
        let clearElem = <HTMLInputElement>document.getElementById(this.input_id + "_clear")
        if (clearElem) {
            clearElem.addEventListener("click", event => {
                this.isNullDate = true
                //
                let parts = this.input_id.split("_")
                let ns = parts.slice(0, -1).join("_")
                let name = parts[parts.length - 1]
                if (!this.asFilter) {
                    window[ns].onchange(dateElem)
                }
                else {
                    window[ns].oncalendar_filter(name, this.dateValue)
                }
            })
        }


        //
        // Popup button
        //
        let popupElem = <HTMLInputElement>document.getElementById(this.input_id + "_popup")
        if (popupElem) {
            popupElem.addEventListener("click", event => {
                this.toggle()
            })
        }


        //
        // Previous button
        //
        let previousElem = <HTMLInputElement>document.getElementById(this.input_id + "_previous")
        if (previousElem) {
            previousElem.addEventListener("click", event => {
                let prevDay = new Date(this.dateValue.getTime());
                prevDay.setDate(prevDay.getDate() - 1);

                this.setState(prevDay, this.forcedYear, this.min, this.max)
                dateElem.setAttribute("value", Misc.toInputDate(this.dateValue));
                //
                let parts = this.input_id.split("_")
                let ns = parts.slice(0, -1).join("_")
                let name = parts[parts.length - 1]
                if (!this.asFilter) {
                    window[ns].onchange(dateElem)
                }
                else {
                    window[ns].oncalendar_filter(name, this.dateValue)
                }
            })
        }


        //
        // Next button
        //
        let nextElem = <HTMLInputElement>document.getElementById(this.input_id + "_next")
        if (nextElem) {
            nextElem.addEventListener("click", event => {
                let nextDay = new Date(this.dateValue.getTime());
                nextDay.setDate(nextDay.getDate() + 1);

                this.setState(nextDay, this.forcedYear, this.min, this.max)
                dateElem.setAttribute("value", Misc.toInputDate(this.dateValue));
                //
                let parts = this.input_id.split("_")
                let ns = parts.slice(0, -1).join("_")
                let name = parts[parts.length - 1]
                if (!this.asFilter) {
                    window[ns].onchange(dateElem)
                }
                else {
                    window[ns].oncalendar_filter(name, this.dateValue)
                }
            })
        }
    }

    public toggle = () => {
        this.hidden = (!this.hidden && !this.alwaysOpened);
        App.render()
    }

    public get dateValue() {
        if (this.isNullDate)
            return null
        return new Date(this.selectedYear, this.selectedMonth -1, this.selectedDay, this.selectedHour, this.selectedMinute, 0, 0)
    }

    public get year() {
        return this.dateValue.getFullYear();
    }

    get hasValidYear() {
        if (this.isNullDate)
            return false
        return this.forcedYear == undefined || this.year == this.forcedYear;
    }

    public set min(date: Date) {
        this.minValue = date
    }

    public set max(date: Date) {
        this.maxValue = date
    }
}



export const eventMan = (ns: string, dateElem: HTMLInputElement, eventname: string) => {

    const ondatechange = () => {
        if (!dateElem.getAttribute("required") && dateElem.value.length == 0) {
            window[ns].onchange(dateElem)
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
            date = new Date(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), 0, 0, 0, 0)
            //
            window[ns].onchange(dateElem)
            return true;
        }

        dateElem.style.borderColor = "red";
        dateElem.style.zIndex = "1";
    }

    if (eventname == "focus") {
        dateElem.value = dateElem.value.replace(/\D+/g, "")
        try {
            dateElem.select()
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
}