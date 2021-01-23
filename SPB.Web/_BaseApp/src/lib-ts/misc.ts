"use strict"

declare const moment: any;
declare const Toastify: any;
declare const i18n: any;

let ESC_MAP = {
    "&": "&amp;",
    "<": "&lt;",
    ">": "&gt;",
    '"': "&quot;",
    "'": "&#39;"
};
let tolerance = 0.00012; //for lat/lng fields

export const escapeHTML = (text: string, forAttribute = true) => {
    return text.replace((forAttribute ? /[&<>'"]/g : /[&<>]/g), function (c) { return ESC_MAP[c]; });
}

export const keepAttr = (id: string, bsAttr: string) => {
    let element = document.getElementById(id);
    if (element == undefined) return `id="${id}"`;
    return `id="${id}" ${bsAttr}="${element.getAttribute(bsAttr)}"`;
};

export const keepClass = (id: string, myClass: string, bsClass: string) => {
    let element = document.getElementById(id);
    if (element == undefined) return `id="${id}" class="${myClass}"`;
    let exist = element.classList.contains(bsClass);
    return `id="${id}" class="${myClass} ${exist ? bsClass : ""}"`;
};

export const clone = (state: any) => {
    let cloned = {};
    Object.keys(state).forEach(key => {
        if (state.hasOwnProperty(key)) {
            if (state[key] == null) {
                cloned[key] = null
            }
            else if (typeof state[key].getTime === "function") {
                cloned[key] = new Date(state[key].getTime());
            }
            else if (Array.isArray(state[key])) {
                cloned[key] = [];
                (state[key] as any[]).forEach(one => cloned[key].push(clone(one)))
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
};

export const same = (state1: any, state2: any) => {
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
};

export const changes = (state1: any, state2: any) => {
    let names: string[] = [];
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
};

export const toInputText = (value: any) => {
    return (value == undefined ? "" : escapeHTML(value.toString()));
};

export const fromInputText = (id: string, defValue: string = null) => {
    let element = <HTMLInputElement>document.getElementById(id);
    return (element == undefined ? defValue : element.value);
};

export const fromInputTextNullable = (id: string, defValue: string = null) => {
    let element = <HTMLInputElement>document.getElementById(id);
    return (element == undefined ? defValue : element.value == "" ? null : element.value);
};

export const toInputNumber = (value: number) => {
    return (value == undefined ? "" : value.toString());
};

export const fromInputNumber = (id: string, defValue: number = null) => {
    let element = <HTMLInputElement>document.getElementById(id);
    return (element == undefined ? defValue : +element.value);
};

export const fromInputNumberNullable = (id: string, defValue: number = null) => {
    let element = <HTMLInputElement>document.getElementById(id);
    return (element == undefined ? defValue : element.value == "" ? null : +element.value);
};

export const toInputDate = (value: Date) => {
    if (value == undefined || value.toString().toLowerCase() == "invalid date")
        return "";
    return moment(value).format("YYYY-MM-DD");
};

export const fromInputDate = (id: string, defValue: Date = null) => {
    let element = <HTMLInputElement>document.getElementById(id);
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
};

export const fromInputDateNullable = (id: string, defValue: Date = null) => {
    let element = <HTMLInputElement>document.getElementById(id);
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
};

export const fromInputTime = (id: string, defValue: Date = null) => {
    let element = <HTMLInputElement>document.getElementById(id);
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
};

export const fromInputTimeComboNullable = (id: string, defValue: Date = null) => {
    if (defValue == null)
        return null;

    return fromInputTimeNullable(id, defValue);
};

export const fromInputTimeNullable = (id: string, defValue: Date = null) => {
    let element = <HTMLInputElement>document.getElementById(id);
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
};

export const toInputCheckbox = (value: boolean) => {
    return value.toString();
};

export const fromInputCheckbox = (id: string, defValue: boolean = null) => {
    let element = <HTMLInputElement>document.getElementById(id);
    return (element == undefined ? defValue : element.checked);
};

export const fromInputCheckboxMask = (name: string, defValue: number = null) => {
    let elements = document.getElementsByName(name);
    if (elements == undefined || elements.length == 0)
        return defValue;
    let value = 0;
    for (let ix = 0; ix < elements.length; ix++) {
        let element = <HTMLInputElement>elements[ix];
        value += (element.checked ? +element.dataset.mask : 0);
    }
    return value;
};

export const toStaticText = (value: any) => {
    return (value == undefined ? "" : value);
};

export const toStaticTextNA = (value: string) => {
    return (value == undefined ? "n/a" : value.replace(/\n/g, "<br>"));
};

export const toStaticNumber = (value: number) => {
    return (value == undefined ? "" : value.toString());
};

export const toStaticNumberNA = (value: number) => {
    return (value == undefined ? "n/a" : value.toString());
};

export const toStaticNumberDecimal = (value: number, places: number, forced = false) => {
    if (value == undefined)
        return "";

    let scale = Math.pow(10, places);
    if (forced)
        return (Math.fround(value * scale) / scale).toFixed(places);
    else
        return (Math.fround(value * scale) / scale).toString();
};

export const toStaticMoney = (value: number) => {
    return "$" + (value ?? 0).toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
};

export const toStaticDateTime = (value: Date) => {
    return (value != undefined ? moment(value).format("LLL") : "");
};

export const toStaticDateTimeNA = (value: Date) => {
    return (value != undefined ? moment(value).format("LLL") : "n/a");
};

export const toStaticDate = (value: Date) => {
    return (value != undefined ? moment(value).format("LL") : "");
};

export const toStaticDateNA = (value: Date) => {
    return (value != undefined ? moment(value).format("LL") : "n/a");
};

export const toStaticCheckbox = (value: boolean) => {
    //return (value ? "<i class='far fa-check-square js-static-checkbox'></i>" : "<i class='far fa-square js-static-checkbox'></i>");
    return (value ? '<i class="fal fa-check-square"></i>' : '<span style="opacity: 0.25"><i class="fal fa-square"></i></span>');
}

export const toStaticCheckboxYesNo = (value: boolean) => {
    return (value == undefined ? "n/a" : value ? i18n("YES") : i18n("NO"));
}

export const filesizeText = (filesize: number) => {
    if (filesize == 0)
        return "n/a";

    var i = -1;
    var byteUnits = [' kB', ' MB', ' GB', ' TB', 'PB', 'EB', 'ZB', 'YB'];
    do {
        filesize = filesize / 1024;
        i++;
    } while (filesize > 1024);

    return Math.max(filesize, 0.1).toFixed(1) + byteUnits[i];
};

export const fromSelectNumber = (id: string, defValue: number = null) => {
    let select = <HTMLSelectElement>document.getElementById(id);
    if (select == undefined || select.selectedIndex == -1)
        return defValue;
    let value = select.options[select.selectedIndex].value;
    return (value.length > 0 ? +value : null);
};

export const fromSelectText = (id: string, defValue: string = null) => {
    let select = <HTMLSelectElement>document.getElementById(id);
    if (select == undefined || select.selectedIndex == -1)
        return defValue;
    let value = select.options[select.selectedIndex].value;
    return (value.length > 0 ? value : null);
};

export const fromSelectBoolean = (id: string, defValue: boolean = null) => {
    let select = <HTMLSelectElement>document.getElementById(id);
    if (select == undefined || select.selectedIndex == -1)
        return defValue;
    let value = select.options[select.selectedIndex].value;
    return (value.length > 0 ? (value == "true") : null);
};

export const fromRadioNumber = (id: string, defValue: number = null) => {
    let radios = document.getElementsByName(id);
    if (radios == undefined || radios.length == 0)
        return defValue;
    for (let ix = 0; ix < radios.length; ix++) {
        let radio = <HTMLInputElement>radios[ix];
        if (radio.checked) {
            let value = radio.dataset.value;
            return (value.length > 0 ? +value : null);
        }
    }
};

export const fromRadioString = (id: string, defValue: string = null) => {
    let radios = document.getElementsByName(id);
    if (radios == undefined || radios.length == 0)
        return defValue;
    for (let ix = 0; ix < radios.length; ix++) {
        let radio = <HTMLInputElement>radios[ix];
        if (radio.checked) {
            let value = radio.dataset.value;
            return (value.length > 0 ? value : null);
        }
    }
};

export const fromAutocompleteNumber = (id: string, defValue: number = null) => {
    let input = <HTMLInputElement>document.getElementById(id);
    if (input == undefined)
        return defValue;
    let key = input.dataset["key"];
    if (key === "undefined")
        return defValue;
    if (key.length == 0)
        return null;
    return +key;
}

export const fromAutocompleteText = (id: string, defValue: string = null) => {
    let input = <HTMLInputElement>document.getElementById(id);
    if (input == undefined)
        return defValue;
    let key = input.dataset["key"];
    if (key === "undefined")
        return defValue;
    if (key.length == 0)
        return null;
    return key;
}

export const toastSuccess = (text: string) => {
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
}

export const toastSuccessSave = () => {
    toastSuccess(i18n("Data was saved successfully"));
}

export const toastSuccessUpload = () => {
    toastSuccess(i18n("File was uploaded successfully"));
}

export const toastFailure = (text = "Your last action failed to execute", duration = 15000) => {
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
}

export const blameText = (obj: any) => {
    return `Last updated on ${toStaticDateTime(obj.updatedUtc)} by ${obj.by}`;
}


export const toInputTimeHHMM = (date: Date) => {
    if (date == undefined)
        return "";

    var hours = date.getHours();
    var minutes = date.getMinutes();
    return `${hours < 10 ? "0" + hours : hours}:${minutes < 10 ? "0" + minutes : minutes}`;
};

export const toInputTimeHHMMSS = (date: Date) => {
    if (date == undefined)
        return "";

    var hours = date.getHours();
    var minutes = date.getMinutes();
    let secs = date.getSeconds();
    return `${hours < 10 ? "0" + hours : hours}:${minutes < 10 ? "0" + minutes : minutes}:${secs < 10 ? "0" + secs : secs}`;
};

export const toInputDateTime_2rows = (date: Date) => {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    let secs = date.getSeconds();
    var ampm = (hours < 12 ? "AM" : "PM");
    hours = hours % 12;
    hours = (hours ? hours : 12);
    let time = `${hours < 10 ? "0" + hours : hours}:${minutes < 10 ? "0" + minutes : minutes}:${secs < 10 ? "0" + secs : secs} ${ampm}`;

    return `${toInputDate(date)}<br/>${time}`;
};

export const toInputDateTime_hhmm_2rows = (date: Date) => {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = (hours < 12 ? "AM" : "PM");
    hours = hours % 12;
    hours = (hours ? hours : 12);
    let time = `${hours < 10 ? "0" + hours : hours}:${minutes < 10 ? "0" + minutes : minutes} ${ampm}`;

    return `${toInputDate(date)}<br/>${time}`;
};

export const toInputDateTime_hhmm = (date: Date) => {
    if (date == undefined)
        return "";
    return toInputDateTime_hhmm_2rows(date).replace("<br/>", "&nbsp;");
};

export const toInputDateTime_hhmmssNA = (date: Date) => {
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
};

export const toInputDateTime_hhmm24 = (date: Date) => {
    if (date == undefined)
        return "";
    var hours = date.getHours();
    var minutes = date.getMinutes();
    let time = `${hours < 10 ? "0" + hours : hours}:${minutes < 10 ? "0" + minutes : minutes}`;

    return `${toInputDate(date)} ${time}`;
};

export const formatYYYYMMDD = (date: Date, separator = "/") => {
    let month = "" + (date.getMonth() + 1);
    let day = "" + date.getDate();
    let year = date.getFullYear();

    if (month.length < 2) month = "0" + month;
    if (day.length < 2) day = "0" + day;

    return [year, month, day].join(separator);
};

export const formatYYYYMMDDHHMM = (date: Date) => {
    let year = date.getFullYear();
    let month = "" + (date.getMonth() + 1);
    let day = "" + date.getDate();
    let hour = "" + date.getHours();
    let minute = "" + date.getMinutes();

    if (month.length < 2) month = "0" + month;
    if (day.length < 2) day = "0" + day;
    if (hour.length < 2) hour = "0" + hour;
    if (minute.length < 2) minute = "0" + minute;

    return [year, month, day, hour, minute].join("");
};

export const formatMMDDYYYY = (date: Date, separator = "/") => {
    let month = "" + (date.getMonth() + 1);
    let day = "" + date.getDate();
    let year = date.getFullYear();

    if (month.length < 2) month = "0" + month;
    if (day.length < 2) day = "0" + day;

    return [month, day, year].join(separator);
};

export const parseYYYYMMDD = (text: string) => {
    return new Date(text);
};

export const parseYYYYMMDD_number = (dateNumber: number) => {
    let yy = Math.floor(dateNumber / 10000);
    let mm = Math.floor((dateNumber - 10000 * yy) / 100) - 1;
    let dd = dateNumber % 100;
    return new Date(yy, mm, dd, 0, 0, 0, 0);
};

export const dateOnly = (date: Date) => {
    return new Date(formatYYYYMMDD(date));
};

export const previousDate = (date: Date) => {
    var newDate = new Date(date);
    newDate.setDate(newDate.getDate() - 1);
    return newDate;
};

export const nextDate = (date: Date) => {
    var newDate = new Date(date);
    newDate.setDate(newDate.getDate() + 1);
    return newDate;
};

export const formatDuration = (startTime: Date, endTime: Date) => {
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
};

export const isDateInstance = (d: any) => {
    return !isNaN(d) && d instanceof Date;
}

export const isValidDateString = (dateString: string) => {
    if (!dateString.match(/^\d{4}-\d{2}-\d{2}$/))
        return false;
    var date = new Date(dateString);
    var time = date.getTime();
    if (!time && time != 0)
        return false;
    return date.toISOString().slice(0, 10) == dateString;
}

export const isValidTimeString = (timeString: string) => {
    let regs = timeString.match(/^(\d{1,2}):(\d{2})([ap]m)?$/);
    if (!regs)
        return false;
    return (!(+regs[1] > 23 || +regs[2] > 59))
}



export const formatLatLong = (latlon: number) => {
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
}

export const toInputLatLong = (latlon: number) => {
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
}

export const toInputLatLongDDMMCC = (latlon: number) => {
    if (latlon == undefined)
        return "";

    let deg = Math.trunc(latlon);
    let min = 60 * (latlon - deg);

    if (min == 60) {
        min = 0;
        deg++;
    }

    return `${deg < 10 ? "0" + deg : deg}° ${min < 10 ? "0" + min.toFixed(2) : min.toFixed(2)}′`;
}

export const fromInputLatLong = (id: string, defValue: number = null) => {
    let element = <HTMLInputElement>document.getElementById(id);
    if (element == undefined)
        return defValue;

    if (element.dataset.isddmmcc == "true") {
        let text = element.value.replace("°", "").replace("′", "");
        let dmc = text.split(" ");
        if (dmc.length != 2)
            return defValue;

        let deg = +dmc[0]; if (isNaN(deg)) return defValue;
        let min = +dmc[1]; if (isNaN(min) || min > 59) return defValue;

        return deg + min / 60;
    }
    else {
        let text = element.value.replace("°", "").replace("′", "").replace("″", "");
        let dms = text.split(" ");
        if (dms.length != 3)
            return defValue;

        let deg = +dms[0]; if (isNaN(deg)) return defValue;
        let min = +dms[1]; if (isNaN(min) || min > 59) return defValue;
        let sec = +dms[2]; if (isNaN(sec) || sec > 59) return defValue;

        return deg + min / 60 + sec / 3600;
    }
}

export const fromInputLatLongNullable = (id: string, defValue: number = null) => {
    let element = <HTMLInputElement>document.getElementById(id);

    if (element == undefined)
        return defValue;
    if (element.value == "")
        return null;

    return fromInputLatLong(id, defValue);
};

export const getLatLongFullPrecision = (latlon: number) => {
    if (latlon == undefined)
        return latlon;

    // I used to recompute the value from its DDMMSS representation to make sure it wouldn't be considered dirty when exiting a page.
    // It's not necessary anymore because I'm using a tolerance when comparing before and after lat/lng values.
    // This change in methodology became necessary when adding support for DDMMCC.
    return latlon;
}

export const createWhite = (formState, props: string[]) => {
    return props.reduce((acc, key) => { { acc[key] = formState[key]; return acc; }; }, {})
}

export const createBlack = (formState, props: string[]) => {
    var cloned = clone(formState)
    props.forEach(prop => delete cloned[prop])
    return cloned;
}
