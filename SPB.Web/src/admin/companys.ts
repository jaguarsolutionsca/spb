// File: companys.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Perm from "../permission"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import * as Pager from "../../_BaseApp/src/theme/pager"
import * as Lookup from "../admin/lookupdata"
import * as Layout from "./layout"
import { tabTemplate, icon, buildTitle, buildSubtitle } from "./layout2"

declare const i18n: any;


export const NS = "App_companys";

interface IState {
    totalcount: number
    cie: number
    name: string
    features: string
    archive: boolean
    created: Date
    updated: Date
    updatedby: number
    acombapassword: string
    acombapath: string
    acombasocietepath: string
    acombasyncropath: string
    acombausername: string
    acrobatpath: string
    adminpassword: string
    afficherpermit1: boolean
    afficherpermit2: boolean
    afficherpermit3: boolean
    afficherpermit4: boolean
    anneecourante: number
    autresraportsprintermarginbottom: number
    autresraportsprintermarginleft: number
    autresraportsprintermarginright: number
    autresraportsprintermargintop: number
    caneditundeliveredpermits: string
    ccemail: string
    cletriclientnom: string
    copiepermit1: boolean
    copiepermit2: boolean
    copiepermit3: boolean
    copiepermit4: boolean
    deletefichepassword: string
    emailpermit1: boolean
    emailpermit2: boolean
    emailpermit3: boolean
    emailpermit4: boolean
    excellanguage: string
    facturesafficherfraisautrechargepourtransporteur: boolean
    facturesafficherfraisautresproducteur: boolean
    facturesafficherfraisautresrevenusproducteur: boolean
    facturesafficherfraisautresrevenustransporteur: boolean
    facturesafficherfraisautrestransporteur: boolean
    facturesafficherfraischargeurproducteur: boolean
    facturesafficherfraischargeurtransporteur: boolean
    facturesafficherfraiscompensationdedeplacement: boolean
    facturesaffichersurchargeproducteur: boolean
    formicon: string
    formtext: string
    fournisseurpointerid: number
    fromemail: string
    gpversion: string
    helpfilepath: string
    imprimanteautresrapports: string
    imprimantedepermis: string
    livraisonliertaux: boolean
    logfile: string
    logopath: string
    massecontingentvoyagedefaut: number
    masselimitedefaut: number
    message_autorisationdeslivraisons: string
    message_demandecontingentement: string
    messageimpressionsdefactures: string
    messagelivraisonnonconforme: string
    messagespecpermitanglais: string
    messagespecpermitfrancais: string
    nomdb: string
    permisprintermarginbottom: number
    permisprintermarginleft: number
    permisprintermarginright: number
    permisprintermargintop: number
    permisprintpreview: boolean
    preleves_notps: string
    preleves_notvq: string
    serveuremail: string
    showyearsinpermislistview: string
    superficiecontingenteepourcentagededuction: number
    superficiecontingenteesansdeduction: number
    syndicat_codepostal: string
    syndicat_fax: string
    syndicat_nom: string
    syndicat_nomanglais: string
    syndicat_nomfrancais: string
    syndicat_notps: string
    syndicat_notvq: string
    syndicat_rue: string
    syndicat_telephone: string
    syndicat_ville: string
    syndicatouoffice: string
    takeacombabackup: boolean
    takesqlbackup: boolean
    tempsentrelesbackupsautomatiques: number
    timeoutsql: number
    typepermis: number
    typepermis1: string
    typepermis1anglais: string
    typepermis1francais: string
    typepermis2: string
    typepermis2anglais: string
    typepermis2francais: string
    typepermis3: string
    typepermis3anglais: string
    typepermis3francais: string
    typepermis4: string
    typepermis4anglais: string
    typepermis4francais: string
    updateotherdatabase: string
    utiliselesychronisateurdirect: boolean
    utiliserlesnomsdemachinedanslenomdeprinter: boolean
    utiliserlotscontingentes: boolean
    xlstemplatespath: string
    fournisseur_planconjoint: string
    fournisseur_planconjoint_text: string
    fournisseur_surcharge: string
    fournisseur_surcharge_text: string
    compte_paiements: number
    compte_paiements_text: string
    compte_arecevoir: number
    compte_arecevoir_text: string
    compte_apayer: number
    compte_apayer_text: string
    compte_duauxproducteurs: number
    compte_duauxproducteurs_text: string
    compte_tpspercues: number
    compte_tpspercues_text: string
    compte_tpspayees: number
    compte_tpspayees_text: string
    compte_tvqpercues: number
    compte_tvqpercues_text: string
    compte_tvqpayees: number
    compte_tvqpayees_text: string
    taux_tps: number
    taux_tvq: number
    fournisseur_fond_roulement: string
    fournisseur_fond_roulement_text: string
    fournisseur_fond_forestier: string
    fournisseur_fond_forestier_text: string
    fournisseur_preleve_divers: string
    fournisseur_preleve_divers_text: string
    json: string
}

interface IKey {

}

interface IFilter {

}



let key: IKey;
let state = <Pager.IPagedList<IState, IFilter>>{
    list: [],
    pager: { pageNo: 1, pageSize: 20, sortColumn: "CIE", sortDirection: "ASC", filter: {} }
};
let xtra: any;
let uiSelectedRow: { cie: number };



const filterTemplate = () => {
    let filters: string[] = [];

    return filters.join("");
}

const trTemplate = (item: IState, rowNumber: number) => {
    return `
<tr class="${isSelectedRow(item.cie) ? "is-selected" : ""}" onclick="${NS}.gotoDetail(${item.cie});">
    <td class="js-index">${rowNumber}</td>
    <td>${Misc.toStaticText(item.cie)}</td>
    <td>${Misc.toStaticText(item.name)}</td>
    <td>${Misc.toStaticText(item.features)}</td>
    <td>${Misc.toStaticCheckbox(item.archive)}</td>
    <td>${Misc.toStaticText(item.acombapassword)}</td>
    <td>${Misc.toStaticText(item.acombapath)}</td>
    <td>${Misc.toStaticText(item.acombasocietepath)}</td>
    <td>${Misc.toStaticText(item.acombasyncropath)}</td>
    <td>${Misc.toStaticText(item.acombausername)}</td>
    <td>${Misc.toStaticText(item.acrobatpath)}</td>
    <td>${Misc.toStaticText(item.adminpassword)}</td>
    <td>${Misc.toStaticCheckbox(item.afficherpermit1)}</td>
    <td>${Misc.toStaticCheckbox(item.afficherpermit2)}</td>
    <td>${Misc.toStaticCheckbox(item.afficherpermit3)}</td>
    <td>${Misc.toStaticCheckbox(item.afficherpermit4)}</td>
    <td>${Misc.toStaticText(item.anneecourante)}</td>
    <td>${Misc.toStaticText(item.autresraportsprintermarginbottom)}</td>
    <td>${Misc.toStaticText(item.autresraportsprintermarginleft)}</td>
    <td>${Misc.toStaticText(item.autresraportsprintermarginright)}</td>
    <td>${Misc.toStaticText(item.autresraportsprintermargintop)}</td>
    <td>${Misc.toStaticText(item.caneditundeliveredpermits)}</td>
    <td>${Misc.toStaticText(item.ccemail)}</td>
    <td>${Misc.toStaticText(item.cletriclientnom)}</td>
    <td>${Misc.toStaticCheckbox(item.copiepermit1)}</td>
    <td>${Misc.toStaticCheckbox(item.copiepermit2)}</td>
    <td>${Misc.toStaticCheckbox(item.copiepermit3)}</td>
    <td>${Misc.toStaticCheckbox(item.copiepermit4)}</td>
    <td>${Misc.toStaticText(item.deletefichepassword)}</td>
    <td>${Misc.toStaticCheckbox(item.emailpermit1)}</td>
    <td>${Misc.toStaticCheckbox(item.emailpermit2)}</td>
    <td>${Misc.toStaticCheckbox(item.emailpermit3)}</td>
    <td>${Misc.toStaticCheckbox(item.emailpermit4)}</td>
    <td>${Misc.toStaticText(item.excellanguage)}</td>
    <td>${Misc.toStaticCheckbox(item.facturesafficherfraisautrechargepourtransporteur)}</td>
    <td>${Misc.toStaticCheckbox(item.facturesafficherfraisautresproducteur)}</td>
    <td>${Misc.toStaticCheckbox(item.facturesafficherfraisautresrevenusproducteur)}</td>
    <td>${Misc.toStaticCheckbox(item.facturesafficherfraisautresrevenustransporteur)}</td>
    <td>${Misc.toStaticCheckbox(item.facturesafficherfraisautrestransporteur)}</td>
    <td>${Misc.toStaticCheckbox(item.facturesafficherfraischargeurproducteur)}</td>
    <td>${Misc.toStaticCheckbox(item.facturesafficherfraischargeurtransporteur)}</td>
    <td>${Misc.toStaticCheckbox(item.facturesafficherfraiscompensationdedeplacement)}</td>
    <td>${Misc.toStaticCheckbox(item.facturesaffichersurchargeproducteur)}</td>
    <td>${Misc.toStaticText(item.formicon)}</td>
    <td>${Misc.toStaticText(item.formtext)}</td>
    <td>${Misc.toStaticText(item.fournisseurpointerid)}</td>
    <td>${Misc.toStaticText(item.fromemail)}</td>
    <td>${Misc.toStaticText(item.gpversion)}</td>
    <td>${Misc.toStaticText(item.helpfilepath)}</td>
    <td>${Misc.toStaticText(item.imprimanteautresrapports)}</td>
    <td>${Misc.toStaticText(item.imprimantedepermis)}</td>
    <td>${Misc.toStaticCheckbox(item.livraisonliertaux)}</td>
    <td>${Misc.toStaticText(item.logfile)}</td>
    <td>${Misc.toStaticText(item.logopath)}</td>
    <td>${Misc.toStaticText(item.massecontingentvoyagedefaut)}</td>
    <td>${Misc.toStaticText(item.masselimitedefaut)}</td>
    <td>${Misc.toStaticText(item.message_autorisationdeslivraisons)}</td>
    <td>${Misc.toStaticText(item.message_demandecontingentement)}</td>
    <td>${Misc.toStaticText(item.messageimpressionsdefactures)}</td>
    <td>${Misc.toStaticText(item.messagelivraisonnonconforme)}</td>
    <td>${Misc.toStaticText(item.messagespecpermitanglais)}</td>
    <td>${Misc.toStaticText(item.messagespecpermitfrancais)}</td>
    <td>${Misc.toStaticText(item.nomdb)}</td>
    <td>${Misc.toStaticText(item.permisprintermarginbottom)}</td>
    <td>${Misc.toStaticText(item.permisprintermarginleft)}</td>
    <td>${Misc.toStaticText(item.permisprintermarginright)}</td>
    <td>${Misc.toStaticText(item.permisprintermargintop)}</td>
    <td>${Misc.toStaticCheckbox(item.permisprintpreview)}</td>
    <td>${Misc.toStaticText(item.preleves_notps)}</td>
    <td>${Misc.toStaticText(item.preleves_notvq)}</td>
    <td>${Misc.toStaticText(item.serveuremail)}</td>
    <td>${Misc.toStaticText(item.showyearsinpermislistview)}</td>
    <td>${Misc.toStaticText(item.superficiecontingenteepourcentagededuction)}</td>
    <td>${Misc.toStaticText(item.superficiecontingenteesansdeduction)}</td>
    <td>${Misc.toStaticText(item.syndicat_codepostal)}</td>
    <td>${Misc.toStaticText(item.syndicat_fax)}</td>
    <td>${Misc.toStaticText(item.syndicat_nom)}</td>
    <td>${Misc.toStaticText(item.syndicat_nomanglais)}</td>
    <td>${Misc.toStaticText(item.syndicat_nomfrancais)}</td>
    <td>${Misc.toStaticText(item.syndicat_notps)}</td>
    <td>${Misc.toStaticText(item.syndicat_notvq)}</td>
    <td>${Misc.toStaticText(item.syndicat_rue)}</td>
    <td>${Misc.toStaticText(item.syndicat_telephone)}</td>
    <td>${Misc.toStaticText(item.syndicat_ville)}</td>
    <td>${Misc.toStaticText(item.syndicatouoffice)}</td>
    <td>${Misc.toStaticCheckbox(item.takeacombabackup)}</td>
    <td>${Misc.toStaticCheckbox(item.takesqlbackup)}</td>
    <td>${Misc.toStaticText(item.tempsentrelesbackupsautomatiques)}</td>
    <td>${Misc.toStaticText(item.timeoutsql)}</td>
    <td>${Misc.toStaticText(item.typepermis)}</td>
    <td>${Misc.toStaticText(item.typepermis1)}</td>
    <td>${Misc.toStaticText(item.typepermis1anglais)}</td>
    <td>${Misc.toStaticText(item.typepermis1francais)}</td>
    <td>${Misc.toStaticText(item.typepermis2)}</td>
    <td>${Misc.toStaticText(item.typepermis2anglais)}</td>
    <td>${Misc.toStaticText(item.typepermis2francais)}</td>
    <td>${Misc.toStaticText(item.typepermis3)}</td>
    <td>${Misc.toStaticText(item.typepermis3anglais)}</td>
    <td>${Misc.toStaticText(item.typepermis3francais)}</td>
    <td>${Misc.toStaticText(item.typepermis4)}</td>
    <td>${Misc.toStaticText(item.typepermis4anglais)}</td>
    <td>${Misc.toStaticText(item.typepermis4francais)}</td>
    <td>${Misc.toStaticText(item.updateotherdatabase)}</td>
    <td>${Misc.toStaticCheckbox(item.utiliselesychronisateurdirect)}</td>
    <td>${Misc.toStaticCheckbox(item.utiliserlesnomsdemachinedanslenomdeprinter)}</td>
    <td>${Misc.toStaticCheckbox(item.utiliserlotscontingentes)}</td>
    <td>${Misc.toStaticText(item.xlstemplatespath)}</td>
    <td>${Misc.toStaticText(item.fournisseur_planconjoint_text)}</td>
    <td>${Misc.toStaticText(item.fournisseur_surcharge_text)}</td>
    <td>${Misc.toStaticText(item.compte_paiements_text)}</td>
    <td>${Misc.toStaticText(item.compte_arecevoir_text)}</td>
    <td>${Misc.toStaticText(item.compte_apayer_text)}</td>
    <td>${Misc.toStaticText(item.compte_duauxproducteurs_text)}</td>
    <td>${Misc.toStaticText(item.compte_tpspercues_text)}</td>
    <td>${Misc.toStaticText(item.compte_tpspayees_text)}</td>
    <td>${Misc.toStaticText(item.compte_tvqpercues_text)}</td>
    <td>${Misc.toStaticText(item.compte_tvqpayees_text)}</td>
    <td>${Misc.toStaticText(item.taux_tps)}</td>
    <td>${Misc.toStaticText(item.taux_tvq)}</td>
    <td>${Misc.toStaticText(item.fournisseur_fond_roulement_text)}</td>
    <td>${Misc.toStaticText(item.fournisseur_fond_forestier_text)}</td>
    <td>${Misc.toStaticText(item.fournisseur_preleve_divers_text)}</td>
</tr>`;
};

const tableTemplate = (tbody: string, pager: Pager.IPager<IFilter>) => {
    return `
<div class="table-container">
<table class="table is-hoverable is-fullwidth">
    <thead>
        <tr>
            <th></th>
            ${Pager.sortableHeaderLink(pager, NS, i18n("CIE"), "cie", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NAME"), "name", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FEATURES"), "features", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ARCHIVE"), "archive", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ACOMBAPASSWORD"), "acombapassword", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ACOMBAPATH"), "acombapath", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ACOMBASOCIETEPATH"), "acombasocietepath", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ACOMBASYNCROPATH"), "acombasyncropath", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ACOMBAUSERNAME"), "acombausername", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ACROBATPATH"), "acrobatpath", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ADMINPASSWORD"), "adminpassword", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERPERMIT1"), "afficherpermit1", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERPERMIT2"), "afficherpermit2", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERPERMIT3"), "afficherpermit3", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AFFICHERPERMIT4"), "afficherpermit4", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("ANNEECOURANTE"), "anneecourante", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AUTRESRAPORTSPRINTERMARGINBOTTOM"), "autresraportsprintermarginbottom", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AUTRESRAPORTSPRINTERMARGINLEFT"), "autresraportsprintermarginleft", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AUTRESRAPORTSPRINTERMARGINRIGHT"), "autresraportsprintermarginright", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("AUTRESRAPORTSPRINTERMARGINTOP"), "autresraportsprintermargintop", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CANEDITUNDELIVEREDPERMITS"), "caneditundeliveredpermits", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CCEMAIL"), "ccemail", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("CLETRICLIENTNOM"), "cletriclientnom", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COPIEPERMIT1"), "copiepermit1", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COPIEPERMIT2"), "copiepermit2", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COPIEPERMIT3"), "copiepermit3", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COPIEPERMIT4"), "copiepermit4", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("DELETEFICHEPASSWORD"), "deletefichepassword", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("EMAILPERMIT1"), "emailpermit1", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("EMAILPERMIT2"), "emailpermit2", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("EMAILPERMIT3"), "emailpermit3", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("EMAILPERMIT4"), "emailpermit4", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("EXCELLANGUAGE"), "excellanguage", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISAUTRECHARGEPOURTRANSPORTEUR"), "facturesafficherfraisautrechargepourtransporteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISAUTRESPRODUCTEUR"), "facturesafficherfraisautresproducteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISAUTRESREVENUSPRODUCTEUR"), "facturesafficherfraisautresrevenusproducteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISAUTRESREVENUSTRANSPORTEUR"), "facturesafficherfraisautresrevenustransporteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISAUTRESTRANSPORTEUR"), "facturesafficherfraisautrestransporteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISCHARGEURPRODUCTEUR"), "facturesafficherfraischargeurproducteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISCHARGEURTRANSPORTEUR"), "facturesafficherfraischargeurtransporteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERFRAISCOMPENSATIONDEDEPLACEMENT"), "facturesafficherfraiscompensationdedeplacement", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FACTURESAFFICHERSURCHARGEPRODUCTEUR"), "facturesaffichersurchargeproducteur", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FORMICON"), "formicon", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FORMTEXT"), "formtext", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FOURNISSEURPOINTERID"), "fournisseurpointerid", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FROMEMAIL"), "fromemail", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("GPVERSION"), "gpversion", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("HELPFILEPATH"), "helpfilepath", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("IMPRIMANTEAUTRESRAPPORTS"), "imprimanteautresrapports", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("IMPRIMANTEDEPERMIS"), "imprimantedepermis", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LIVRAISONLIERTAUX"), "livraisonliertaux", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LOGFILE"), "logfile", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("LOGOPATH"), "logopath", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MASSECONTINGENTVOYAGEDEFAUT"), "massecontingentvoyagedefaut", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MASSELIMITEDEFAUT"), "masselimitedefaut", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MESSAGE_AUTORISATIONDESLIVRAISONS"), "message_autorisationdeslivraisons", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MESSAGE_DEMANDECONTINGENTEMENT"), "message_demandecontingentement", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MESSAGEIMPRESSIONSDEFACTURES"), "messageimpressionsdefactures", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MESSAGELIVRAISONNONCONFORME"), "messagelivraisonnonconforme", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MESSAGESPECPERMITANGLAIS"), "messagespecpermitanglais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("MESSAGESPECPERMITFRANCAIS"), "messagespecpermitfrancais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("NOMDB"), "nomdb", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PERMISPRINTERMARGINBOTTOM"), "permisprintermarginbottom", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PERMISPRINTERMARGINLEFT"), "permisprintermarginleft", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PERMISPRINTERMARGINRIGHT"), "permisprintermarginright", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PERMISPRINTERMARGINTOP"), "permisprintermargintop", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PERMISPRINTPREVIEW"), "permisprintpreview", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PRELEVES_NOTPS"), "preleves_notps", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("PRELEVES_NOTVQ"), "preleves_notvq", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SERVEUREMAIL"), "serveuremail", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SHOWYEARSINPERMISLISTVIEW"), "showyearsinpermislistview", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SUPERFICIECONTINGENTEEPOURCENTAGEDEDUCTION"), "superficiecontingenteepourcentagededuction", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SUPERFICIECONTINGENTEESANSDEDUCTION"), "superficiecontingenteesansdeduction", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_CODEPOSTAL"), "syndicat_codepostal", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_FAX"), "syndicat_fax", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_NOM"), "syndicat_nom", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_NOMANGLAIS"), "syndicat_nomanglais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_NOMFRANCAIS"), "syndicat_nomfrancais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_NOTPS"), "syndicat_notps", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_NOTVQ"), "syndicat_notvq", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_RUE"), "syndicat_rue", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_TELEPHONE"), "syndicat_telephone", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SYNDICAT_VILLE"), "syndicat_ville", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("SYNDICATOUOFFICE"), "syndicatouoffice", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TAKEACOMBABACKUP"), "takeacombabackup", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TAKESQLBACKUP"), "takesqlbackup", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TEMPSENTRELESBACKUPSAUTOMATIQUES"), "tempsentrelesbackupsautomatiques", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TIMEOUTSQL"), "timeoutsql", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS"), "typepermis", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS1"), "typepermis1", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS1ANGLAIS"), "typepermis1anglais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS1FRANCAIS"), "typepermis1francais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS2"), "typepermis2", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS2ANGLAIS"), "typepermis2anglais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS2FRANCAIS"), "typepermis2francais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS3"), "typepermis3", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS3ANGLAIS"), "typepermis3anglais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS3FRANCAIS"), "typepermis3francais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS4"), "typepermis4", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS4ANGLAIS"), "typepermis4anglais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TYPEPERMIS4FRANCAIS"), "typepermis4francais", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("UPDATEOTHERDATABASE"), "updateotherdatabase", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("UTILISELESYCHRONISATEURDIRECT"), "utiliselesychronisateurdirect", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("UTILISERLESNOMSDEMACHINEDANSLENOMDEPRINTER"), "utiliserlesnomsdemachinedanslenomdeprinter", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("UTILISERLOTSCONTINGENTES"), "utiliserlotscontingentes", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("XLSTEMPLATESPATH"), "xlstemplatespath", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FOURNISSEUR_PLANCONJOINT_TEXT"), "fournisseur_planconjoint_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FOURNISSEUR_SURCHARGE_TEXT"), "fournisseur_surcharge_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_PAIEMENTS_TEXT"), "compte_paiements_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_ARECEVOIR_TEXT"), "compte_arecevoir_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_APAYER_TEXT"), "compte_apayer_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_DUAUXPRODUCTEURS_TEXT"), "compte_duauxproducteurs_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_TPSPERCUES_TEXT"), "compte_tpspercues_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_TPSPAYEES_TEXT"), "compte_tpspayees_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_TVQPERCUES_TEXT"), "compte_tvqpercues_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("COMPTE_TVQPAYEES_TEXT"), "compte_tvqpayees_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TAUX_TPS"), "taux_tps", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("TAUX_TVQ"), "taux_tvq", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FOURNISSEUR_FOND_ROULEMENT_TEXT"), "fournisseur_fond_roulement_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FOURNISSEUR_FOND_FORESTIER_TEXT"), "fournisseur_fond_forestier_text", "ASC")}
            ${Pager.sortableHeaderLink(pager, NS, i18n("FOURNISSEUR_PRELEVE_DIVERS_TEXT"), "fournisseur_preleve_divers_text", "ASC")}
            ${Pager.headerLink(i18n("TODO"))}
        </tr>
    </thead>
    <tbody>
        ${tbody}
    </tbody>
</table>
</div>
`;
};

const pageTemplate = (pager: string, table: string, tab: string, warning: string, dirty: string) => {
    let readonly = false;

    let buttons: string[] = [];
    buttons.push(Theme.buttonAddNew(NS, "#/admin/company/new", i18n("Add New")));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, i18n("companys title"));
    let subtitle = buildSubtitle(xtra, i18n("companys subtitle"));

    return `
<form onsubmit="return false;">
<input type="submit" style="display:none;" id="${NS}_dummy_submit">

<div class="js-fixed-heading">
<div class="js-head">
    <div class="content js-uc-heading js-flex-space">
        <div>
            <div class="title"><i class="${icon}"></i> <span>${title}</span></div>
            <div class="subtitle">${subtitle}</div>
        </div>
        <div>
            ${Theme.wrapContent("js-uc-actions", actions)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-pager", pager)}
    ${Theme.wrapContent("js-uc-list", table)}
</div>
</div>

</form>
`;
};

export const fetchState = (cie: number) => {
    Router.registerDirtyExit(null);
    return App.POST("/company/search", state.pager)
        .then(payload => {
            state = payload;
            xtra = payload.xtra;
            key = {};
        })
        .then(Lookup.fetch_autreFournisseur())
        .then(Lookup.fetch_compte())
};

export const fetch = (params: string[]) => {
    let cie = +params[0];
    App.prepareRender(NS, i18n("companys"));
    fetchState(cie)
        .then(App.render)
        .catch(App.render);
};

const refresh = () => {
    App.prepareRender(NS, i18n("companys"));
    App.POST("/company/search", state.pager)
        .then(payload => {
            state = payload;
        })
        .then(App.render)
        .catch(App.render);
};

export const render = () => {
    if (!inContext()) return "";
    if (App.fatalError()) return App.fatalErrorTemplate();
    if (state == undefined || state.list == undefined || (state.list instanceof Array) == false)
        return App.warningTemplate() || App.unexpectedTemplate();

    let warning = App.warningTemplate();
    let dirty = "";
    const tbody = state.list.reduce((html, item, index) => {
        let rowNumber = Pager.rowNumber(state.pager, index);
        return html + trTemplate(item, rowNumber);
    }, "");

    let year = Perm.getCurrentYear();//state.pager.filter.year;



    const filter = filterTemplate();
    const search = Pager.searchTemplate(state.pager, NS);
    const pager = Pager.render(state.pager, NS, [20, 50], search, filter);
    const table = tableTemplate(tbody, state.pager);

    const tab = tabTemplate(null, null);
    return pageTemplate(pager, table, tab, dirty, warning);
};

export const postRender = () => {
    if (!inContext()) return;
};

export const inContext = () => {
    return App.inContext(NS);
};

const setSelectedRow = (cie: number) => {
    if (uiSelectedRow == undefined) uiSelectedRow = { cie };
    uiSelectedRow.cie = cie;
};

const isSelectedRow = (cie: number) => {
    if (uiSelectedRow == undefined) return false;
    return (uiSelectedRow.cie == cie);
};

export const goto = (pageNo: number, pageSize: number) => {
    state.pager.pageNo = pageNo;
    state.pager.pageSize = pageSize;
    refresh();
};

export const sortBy = (columnName: string, direction: string) => {
    state.pager.pageNo = 1;
    state.pager.sortColumn = columnName;
    state.pager.sortDirection = direction;
    refresh();
};

export const search = (element) => {
    state.pager.searchText = element.value;
    state.pager.pageNo = 1;
    refresh();
};

export const gotoDetail = (cie: number) => {
    setSelectedRow(cie);
    Router.goto(`#/admin/company/${cie}`);
};

