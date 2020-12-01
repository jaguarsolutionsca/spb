"use strict"

import { IOpt } from "./theme";



export interface IOptSelect extends IOpt {
}


export const rawSelect = (ns: string, propName: string, options: string, option: IOptSelect) => {
    return `
<div class="control ${option.size || ""}">
    <div class="select" style="width:100%">
        <select id="${ns}_${propName}" style="width:100%" onchange="${ns}.onchange(this)" ${option.required ? "required='required'" : ""} ${option.disabled ? "disabled tabindex='-1'" : ""}>
            ${options}
        </select>
    </div>
</div>`;
}
