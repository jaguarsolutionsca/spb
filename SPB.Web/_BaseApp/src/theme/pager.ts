"use strict"

import * as Misc from "../lib-ts/misc"

declare const i18n: any;


export interface IPager<IF> {
    pageNo: number
    pageSize: number
    rowCount: number
    sortColumn: string
    sortDirection: string
    searchText: string
    filter: IF
}

export interface IPagedList<T, IF> {
    xtra: any
    pager: IPager<IF>
    list: Array<T>
    perm: any
}

export const NullPager: IPager<any> = { pageNo: 1, pageSize: 1000, rowCount: 0, searchText: "", sortColumn: "", sortDirection: "", filter: {} };


export const render = (pager: IPager<any>, ns: string, sizes: number[], searchHtml: string = null, customHtml: string = null) => {
    let rowFirst = ((pager.pageNo - 1) * pager.pageSize) + 1;
    if (pager.rowCount == 0) rowFirst = 0;
    let rowLast = Math.min(rowFirst + pager.pageSize - 1, pager.rowCount);
    let pageCount = Math.floor((Math.max(pager.rowCount - 1, 0) / pager.pageSize) + 1);
    let firstPage = `${ns}.goto(1, ${pager.pageSize})`;
    let prevPage = `${ns}.goto(${pager.pageNo - 1}, ${pager.pageSize})`;
    let nextPage = `${ns}.goto(${pager.pageNo + 1}, ${pager.pageSize})`;
    let lastPage = `${ns}.goto(${pageCount}, ${pager.pageSize})`;
    let allSizes = "";
    if (sizes.length > 0) {
        allSizes = sizes.reduce((html: string, size: number) => {
            return html + `
            <a class="dropdown-item" href="#" onclick="${ns}.goto(1, ${size});return false;">
                <span class="fa fa-check" style="width: 15px; ${size != pager.pageSize ? "visibility: hidden" : ""}"></span>
                ${i18n("%n Records per Page", size)}
            </a>`;
        }, ``);
    }

    return `
<div class="level">
    <div class="level-left">
        <div class="field is-horizontal">
            <div class="field-body">
                ${searchHtml != undefined && searchHtml.length > 0 ? searchHtml : ""}
                ${customHtml != undefined && customHtml.length > 0 ? customHtml : ""}
            </div>
        </div>
    </div>
    <div class="level-right">
        <div class="field is-grouped">
            <div class="dropdown is-right is-hoverable" xx-js-skip-render-class="is-active">
                <div class="dropdown-trigger">
                    <button class="button" aria-haspopup="true" aria-controls="dropdown-menu" title="${i18n("Options")}">
                        <span>${i18n("%{rowFirst}-%{rowLast} of %{rowCount} Records", { rowFirst: rowFirst, rowLast: rowLast, rowCount: pager.rowCount })}</span>
                        <span class="icon is-small"><i class="fas fa-angle-down" aria-hidden="true"></i></span>
                    </button>
                </div>
                <div class="dropdown-menu" id="dropdown-menu" role="menu">
                    <div class="dropdown-content">
                        <a class="dropdown-item" href="#" onclick="${firstPage};return false;">
                            <span class="far fa-fast-backward" style="width: 15px;"></span>
                            ${i18n("Go To First Page")}
                        </a>
                        <a class="dropdown-item" href="#" onclick="${lastPage};return false;">
                            <span class="far fa-fast-forward" style="width: 15px;"></span>
                            ${i18n("Go To Last Page")}
                        </a>
                        <hr class="dropdown-divider">
                        ${allSizes}
                    </div>
                </div>
            </div>
            <div class="buttons has-addons" style="margin-left: 4px;">
                <button type="button" class="button" ${pager.pageNo == 1 ? "disabled" : ""} onclick="${firstPage}"><i class="fal fa-fast-backward"></i></button>
                <button type="button" class="button" ${pager.pageNo == 1 ? "disabled" : ""} onclick="${prevPage}"><i class="fal fa-step-backward"></i></button>
                <button type="button" class="button" ${pager.pageNo == pageCount ? "disabled" : ""} onclick="${nextPage}"><i class="fal fa-step-forward"></i></button>
                <button type="button" class="button" ${pager.pageNo == pageCount ? "disabled" : ""} onclick="${lastPage}"><i class="fal fa-fast-forward"></i></button>
            </div>
        </div>
    </div>
</div>`;
};

export const renderStatic = (pager: IPager<any>) => {
    return `
<div class="js-container">
    <div class="js-filter-column"></div>
    <div class="js-control">
        <span><em>${pager.rowCount} records found</strong></em>
    </div>
</div>`;
};

export const sortableHeaderLink = (pager: IPager<any>, ns: string, linkText: string, columnName: string, defaultDirection: string /*"ASC"*/, style = "") => {
    var indicator = "";
    var sorting = "";
    var nextDir = defaultDirection;
    if (columnName.toUpperCase() == pager.sortColumn.toUpperCase())
        nextDir = (pager.sortDirection == "ASC" ? "DESC" : "ASC");

    if (columnName.toUpperCase() == pager.sortColumn.toUpperCase()) {
        indicator = `&nbsp;<i class="fa ${pager.sortDirection == "DESC" ? "fa-sort-down" : "fa-sort-up"}"></i>`;
        sorting = " class=\"js-sorting\"";
    }

    if (indicator.length == 0)
        indicator = '&nbsp;<i class="fa fa-sort-down" style="visibility: hidden;"></i>';

    return `<th${sorting} ${style ? `style="${style}"` : ""}><a href="#" onclick="${ns}.sortBy('${columnName}', '${nextDir}');return false;">${linkText}${indicator}</a></th>`;
};

export const headerLink = (linkText: string) => {
    return `<th class="js-no-sorting">${linkText}</th>`;
};

export const rowNumber = (pager: IPager<any>, index: number) => {
    return 1 + index + ((pager.pageNo - 1) * pager.pageSize);
};

export const asParams = (pager: IPager<any>) => {
    let searchText = (pager.searchText != undefined ? encodeURIComponent(pager.searchText) : "");
    let params = `pn=${pager.pageNo}&ps=${pager.pageSize}&sc=${pager.sortColumn}&sd=${pager.sortDirection}&st=${searchText}`;
    if (pager.filter != undefined) {
        Object.keys(pager.filter).forEach(key => {
            if (pager.filter[key] != undefined) {
                let value = pager.filter[key];
                if (value != null && typeof value.getTime === "function") {
                    let text = JSON.stringify(value).replace(/"/g, "");
                    params += `&${key}=${text}`;
                }
                else if (Array.isArray(value)) {
                    params += `&${key}=${value.join(",")}`;
                }
                else {
                    params += `&${key}=${value}`;
                }
            }
        });
    }
    return params;
}

export const searchTemplate = (pager: IPager<any>, ns: string, xtra?: string) => {
    return `
    <div class="field">
        <label class="label">${i18n("Search")}</label>
        <div class="control has-icons-left" style="width:125px;">
            <input class="input" type="text" placeholder="${i18n("Search")}" value="${Misc.toInputText(pager.searchText)}" xonchange="${ns}.search(this)" onkeydown="if (event.keyCode == 13) ${ns}.search(event.target)" ${xtra || ""}>
            <span class="icon is-small is-left">
                <i class="fas fa-search"></i>
            </span>
        </div>
    </div>`;
}
