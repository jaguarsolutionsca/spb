"use strict"

export const NS = "App_LatLong";



export const onfocusLatLon = (element: HTMLInputElement) => {
    if (element.dataset.isddmmcc == "true") {
        element.value = element.value.replace("°", "").replace("′", "").replace(" ", "");
        element.type = "number";
        element.select()
    }
    else {
        element.value = element.value.replace(/\D+/g, "")
        element.type = "number";
        element.select()
    }
}

export const onchangeLatLon = (element: HTMLInputElement) => {
    if (element.dataset.isddmmcc == "true") {
        let isLongitude = (element.dataset.islongitude == "true");
        let text = "0000000" + (+element.value).toFixed(2);
        let cc = text.slice(-2);
        let mm = text.slice(-5, -3);
        let dd = text.slice((isLongitude ? -8 : -7), -5);
        text = `${dd}° ${mm}.${cc}′`;
        if (text[0] == "0")
            text = text.slice(1);
        element.type = "text";
        element.value = text;
        element.setAttribute("value", text);
    }
    else {
        let isLongitude = (element.dataset.islongitude == "true");
        let text = "0000000" + element.value;
        let ss = text.slice(-2);
        let mm = text.slice(-4, -2);
        let dd = text.slice((isLongitude ? -7 : -6), -4);
        text = `${dd}° ${mm}′ ${ss}″`;
        if (text[0] == "0")
            text = text.slice(1);
        element.type = "text";
        element.value = text;
        element.setAttribute("value", text);
    }
}

export const onblurLatLon = (element: HTMLInputElement) => {
    if (isNaN(+element.value))
        return;
    onchangeLatLon(element);
}
