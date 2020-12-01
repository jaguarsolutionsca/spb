"use strict"

export const closest = function (element: Element | HTMLElement, tagName: string) {
    let el = element;
    let tagname = tagName.toLowerCase();
    if (el.tagName && el.tagName.toLowerCase() == tagname)
        return el;

    while (el && el.parentElement) {
        el = el.parentElement;
        if (el.tagName && el.tagName.toLowerCase() == tagname) {
            return el;
        }
    }
    return null;
}

export const closestByClassName = function (element: Element | HTMLElement, className: string) {
    let el = element;
    if (el.classList.contains(className))
        return el;

    while (el && el.parentElement) {
        el = el.parentElement;
        if (el.classList.contains(className)) {
            return el;
        }
    }
    return null;
}

export const live = (eventType: string, className: string, callback) => {
    document.addEventListener(eventType, function (event) {
        var el = <HTMLElement>event.target;
        var found = false;
        while (el) {
            found = (el.classList && el.classList.contains(className));
            if (found) break;
            el = el.parentElement;
        }
        if (found) callback.call(el, event);
    });
}

export const setCookie = function (cname: string, cvalue: string, exdays: number = 0) {
    if (exdays > 0) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        document.cookie = cname + "=" + cvalue + ";expires=" + d.toUTCString() + ";path=/";
    }
    else {
        document.cookie = cname + "=" + cvalue + ";path=/";
    }
}

export const getCookie = function (cname: string) {
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
}

export const duplicateEntity = function (targetElement: Element) {
    let newElement = document.createElement(targetElement.tagName);
    for (let i = 0; i < targetElement.attributes.length; i++) {
        let attr = targetElement.attributes[i];
        newElement.setAttribute(attr.name, attr.value);
    }
    return newElement;
}

export const getElementPosition = (el: HTMLElement) => {
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

        el = <HTMLElement>el.offsetParent;
    }
    return {
        x: xPos,
        y: yPos
    };
}
