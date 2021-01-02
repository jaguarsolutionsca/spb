// File: company.ts

"use strict"

import * as App from "../../_BaseApp/src/core/app"
import * as Router from "../../_BaseApp/src/core/router"
import * as Misc from "../../_BaseApp/src/lib-ts/misc"
import * as Theme from "../../_BaseApp/src/theme/theme"
import { Calendar } from "../../_BaseApp/src/theme/calendar"
import { Autocomplete } from "../../_BaseApp/src/theme/autocomplete"
import * as Pager from "../../_BaseApp/src/theme/pager"
import * as Auth from "../../_BaseApp/src/auth"
import * as Lookup from "../admin/lookupdata"
import * as Perm from "../permission"
import { tabTemplate, icon, ISummary, buildTitle, buildSubtitle } from "./layout2"

declare const i18n: any;


export const NS = "App_company";

interface IPayload {
    item: IState
    xtra: ISummary
}

interface IKey {
    cie: number
}

interface IState {
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
}

const blackList = ["created"];



let key: IKey;
let state = <IState>{};
let fetchedState = <IState>{};
let xtra: ISummary;
let isNew = false;
let isDirty = false;


const block_company = (item: IState) => {
    return `
    ${Theme.renderTextField(NS, "name", item.name, i18n("NAME"), 64, true)}
    ${Theme.renderTextField(NS, "features", item.features, i18n("FEATURES"), 2048)}
    ${Theme.renderCheckboxField(NS, "archive", item.archive, i18n("ARCHIVE"))}
`;
}

const block_system = (item: IState) => {
    return `
    ${Theme.renderTextField(NS, "xlstemplatespath", item.xlstemplatespath, i18n("XLSTEMPLATESPATH"), 500)}
    ${Theme.renderTextField(NS, "helpfilepath", item.helpfilepath, i18n("HELPFILEPATH"), 500)}

    ${Theme.renderNumberField(NS, "masselimitedefaut", item.masselimitedefaut, i18n("MASSELIMITEDEFAUT"), true)}
    ${Theme.renderNumberField(NS, "anneecourante", item.anneecourante, i18n("ANNEECOURANTE"), true)}
    ${Theme.renderNumberField(NS, "taux_tps", item.taux_tps, i18n("TAUX_TPS"))}
    ${Theme.renderNumberField(NS, "taux_tvq", item.taux_tvq, i18n("TAUX_TVQ"))}

    ${Theme.renderNumberField(NS, "massecontingentvoyagedefaut", item.massecontingentvoyagedefaut, i18n("MASSECONTINGENTVOYAGEDEFAUT"), true)}
    ${Theme.renderNumberField(NS, "superficiecontingenteesansdeduction", item.superficiecontingenteesansdeduction, i18n("SUPERFICIECONTINGENTEESANSDEDUCTION"))}
    ${Theme.renderNumberField(NS, "superficiecontingenteepourcentagededuction", item.superficiecontingenteepourcentagededuction, i18n("SUPERFICIECONTINGENTEEPOURCENTAGEDEDUCTION"))}

    ${Theme.renderCheckboxField(NS, "livraisonliertaux", item.livraisonliertaux, i18n("LIVRAISONLIERTAUX"))}
    ${Theme.renderCheckboxField(NS, "utiliserlotscontingentes", item.utiliserlotscontingentes, i18n("UTILISERLOTSCONTINGENTES"))}

    ${Theme.renderTextField(NS, "formicon", item.formicon, i18n("FORMICON"), 500)}
    ${Theme.renderTextField(NS, "formtext", item.formtext, i18n("FORMTEXT"), 500)}
`;
}

const block_personnalisation = (item: IState) => {
    return `
    ${Theme.renderTextField(NS, "syndicatouoffice", item.syndicatouoffice, i18n("SYNDICATOUOFFICE"), 500)}

    ${Theme.renderTextField(NS, "syndicat_nomanglais", item.syndicat_nomanglais, i18n("SYNDICAT_NOMANGLAIS"), 500)}
    ${Theme.renderTextField(NS, "syndicat_nomfrancais", item.syndicat_nomfrancais, i18n("SYNDICAT_NOMFRANCAIS"), 500)}

    ${Theme.renderTextField(NS, "syndicat_rue", item.syndicat_rue, i18n("SYNDICAT_RUE"), 500)}
    ${Theme.renderTextField(NS, "syndicat_ville", item.syndicat_ville, i18n("SYNDICAT_VILLE"), 500)}
    ${Theme.renderTextField(NS, "syndicat_codepostal", item.syndicat_codepostal, i18n("SYNDICAT_CODEPOSTAL"), 500)}
    ${Theme.renderTextField(NS, "syndicat_telephone", item.syndicat_telephone, i18n("SYNDICAT_TELEPHONE"), 500)}
    ${Theme.renderTextField(NS, "syndicat_fax", item.syndicat_fax, i18n("SYNDICAT_FAX"), 500)}
`;
}

const block_acomba = (item: IState) => {
    return `
    ${Theme.renderTextField(NS, "acombausername", item.acombausername, i18n("ACOMBAUSERNAME"), 500)}
    ${Theme.renderTextField(NS, "acombapassword", item.acombapassword, i18n("ACOMBAPASSWORD"), 500)}
    ${Theme.renderTextField(NS, "acombasocietepath", item.acombasocietepath, i18n("ACOMBASOCIETEPATH"), 500)}
    ${Theme.renderTextField(NS, "acombapath", item.acombapath, i18n("ACOMBAPATH"), 500)}

    ${Theme.renderCheckboxField(NS, "utiliselesychronisateurdirect", item.utiliselesychronisateurdirect, i18n("UTILISELESYCHRONISATEURDIRECT"))}
    ${Theme.renderTextField(NS, "acombasyncropath", item.acombasyncropath, i18n("ACOMBASYNCROPATH"), 500)}
`;
}

const block_comptes = (item: IState, fournisseur_planconjoint: string, fournisseur_surcharge: string, compte_paiements: string, compte_arecevoir: string, compte_apayer: string, compte_duauxproducteurs: string, compte_tpspercues: string, compte_tpspayees: string, compte_tvqpercues: string, compte_tvqpayees: string, fournisseur_fond_roulement: string, fournisseur_fond_forestier: string, fournisseur_preleve_divers: string) => {
    return `
    ${Theme.renderDropdownField(NS, "fournisseur_planconjoint", fournisseur_planconjoint, i18n("FOURNISSEUR_PLANCONJOINT"))}
    ${Theme.renderDropdownField(NS, "fournisseur_surcharge", fournisseur_surcharge, i18n("FOURNISSEUR_SURCHARGE"))}
    ${Theme.renderDropdownField(NS, "fournisseur_fond_roulement", fournisseur_fond_roulement, i18n("FOURNISSEUR_FOND_ROULEMENT"))}
    ${Theme.renderDropdownField(NS, "fournisseur_fond_forestier", fournisseur_fond_forestier, i18n("FOURNISSEUR_FOND_FORESTIER"))}
    ${Theme.renderDropdownField(NS, "fournisseur_preleve_divers", fournisseur_preleve_divers, i18n("FOURNISSEUR_PRELEVE_DIVERS"))}

    ${Theme.renderDropdownField(NS, "compte_paiements", compte_paiements, i18n("COMPTE_PAIEMENTS"))}
    ${Theme.renderDropdownField(NS, "compte_arecevoir", compte_arecevoir, i18n("COMPTE_ARECEVOIR"))}
    ${Theme.renderDropdownField(NS, "compte_apayer", compte_apayer, i18n("COMPTE_APAYER"))}
    ${Theme.renderDropdownField(NS, "compte_duauxproducteurs", compte_duauxproducteurs, i18n("COMPTE_DUAUXPRODUCTEURS"))}
    ${Theme.renderDropdownField(NS, "compte_tpspercues", compte_tpspercues, i18n("COMPTE_TPSPERCUES"))}
    ${Theme.renderDropdownField(NS, "compte_tpspayees", compte_tpspayees, i18n("COMPTE_TPSPAYEES"))}
    ${Theme.renderDropdownField(NS, "compte_tvqpercues", compte_tvqpercues, i18n("COMPTE_TVQPERCUES"))}
    ${Theme.renderDropdownField(NS, "compte_tvqpayees", compte_tvqpayees, i18n("COMPTE_TVQPAYEES"))}
`;
}

const block_preleve = (item: IState) => {
    return `
    ${Theme.renderTextField(NS, "preleves_notps", item.preleves_notps, i18n("PRELEVES_NOTPS"), 500)}
    ${Theme.renderTextField(NS, "preleves_notvq", item.preleves_notvq, i18n("PRELEVES_NOTVQ"), 500)}

    ${Theme.renderTextField(NS, "syndicat_notps", item.syndicat_notps, i18n("SYNDICAT_NOTPS"), 500)}
    ${Theme.renderTextField(NS, "syndicat_notvq", item.syndicat_notvq, i18n("SYNDICAT_NOTVQ"), 500)}
`;
}

const block_permis = (item: IState) => {
    return `
    ${Theme.renderNumberField(NS, "typepermis", item.typepermis, i18n("TYPEPERMIS"), true)}

    ${Theme.renderTextField(NS, "serveuremail", item.serveuremail, i18n("SERVEUREMAIL"), 500)}
    ${Theme.renderTextField(NS, "ccemail", item.ccemail, i18n("CCEMAIL"), 500)}
    ${Theme.renderTextField(NS, "fromemail", item.fromemail, i18n("FROMEMAIL"), 500)}

    ${Theme.renderCheckboxField(NS, "permisprintpreview", item.permisprintpreview, i18n("PERMISPRINTPREVIEW"))}
    ${Theme.renderTextField(NS, "typepermis1", item.typepermis1, i18n("TYPEPERMIS1"), 500)}
    ${Theme.renderTextField(NS, "typepermis1anglais", item.typepermis1anglais, i18n("TYPEPERMIS1ANGLAIS"), 500)}
    ${Theme.renderTextField(NS, "typepermis1francais", item.typepermis1francais, i18n("TYPEPERMIS1FRANCAIS"), 500)}
    ${Theme.renderCheckboxField(NS, "afficherpermit1", item.afficherpermit1, i18n("AFFICHERPERMIT1"))}
    ${Theme.renderCheckboxField(NS, "emailpermit1", item.emailpermit1, i18n("EMAILPERMIT1"))}
    ${Theme.renderCheckboxField(NS, "copiepermit1", item.copiepermit1, i18n("COPIEPERMIT1"))}

    ${Theme.renderTextField(NS, "typepermis2", item.typepermis2, i18n("TYPEPERMIS2"), 500)}
    ${Theme.renderTextField(NS, "typepermis2anglais", item.typepermis2anglais, i18n("TYPEPERMIS2ANGLAIS"), 500)}
    ${Theme.renderTextField(NS, "typepermis2francais", item.typepermis2francais, i18n("TYPEPERMIS2FRANCAIS"), 500)}
    ${Theme.renderCheckboxField(NS, "afficherpermit2", item.afficherpermit2, i18n("AFFICHERPERMIT2"))}
    ${Theme.renderCheckboxField(NS, "emailpermit2", item.emailpermit2, i18n("EMAILPERMIT2"))}
    ${Theme.renderCheckboxField(NS, "copiepermit2", item.copiepermit2, i18n("COPIEPERMIT2"))}

    ${Theme.renderTextField(NS, "typepermis3", item.typepermis3, i18n("TYPEPERMIS3"), 500)}
    ${Theme.renderTextField(NS, "typepermis3anglais", item.typepermis3anglais, i18n("TYPEPERMIS3ANGLAIS"), 500)}
    ${Theme.renderTextField(NS, "typepermis3francais", item.typepermis3francais, i18n("TYPEPERMIS3FRANCAIS"), 500)}
    ${Theme.renderCheckboxField(NS, "afficherpermit3", item.afficherpermit3, i18n("AFFICHERPERMIT3"))}
    ${Theme.renderCheckboxField(NS, "emailpermit3", item.emailpermit3, i18n("EMAILPERMIT3"))}
    ${Theme.renderCheckboxField(NS, "copiepermit3", item.copiepermit3, i18n("COPIEPERMIT3"))}

    ${Theme.renderTextField(NS, "typepermis4", item.typepermis4, i18n("TYPEPERMIS4"), 500)}
    ${Theme.renderTextField(NS, "typepermis4anglais", item.typepermis4anglais, i18n("TYPEPERMIS4ANGLAIS"), 500)}
    ${Theme.renderTextField(NS, "typepermis4francais", item.typepermis4francais, i18n("TYPEPERMIS4FRANCAIS"), 500)}
    ${Theme.renderCheckboxField(NS, "afficherpermit4", item.afficherpermit4, i18n("AFFICHERPERMIT4"))}
    ${Theme.renderCheckboxField(NS, "emailpermit4", item.emailpermit4, i18n("EMAILPERMIT4"))}
    ${Theme.renderCheckboxField(NS, "copiepermit4", item.copiepermit4, i18n("COPIEPERMIT4"))}

    ${Theme.renderTextField(NS, "messagespecpermitanglais", item.messagespecpermitanglais, i18n("MESSAGESPECPERMITANGLAIS"), 500)}
    ${Theme.renderTextField(NS, "messagespecpermitfrancais", item.messagespecpermitfrancais, i18n("MESSAGESPECPERMITFRANCAIS"), 500)}

    ${Theme.renderTextField(NS, "showyearsinpermislistview", item.showyearsinpermislistview, i18n("SHOWYEARSINPERMISLISTVIEW"), 500)}
`;
}

const block_print = (item: IState) => {
    return `
    ${Theme.renderCheckboxField(NS, "facturesaffichersurchargeproducteur", item.facturesaffichersurchargeproducteur, i18n("FACTURESAFFICHERSURCHARGEPRODUCTEUR"))}
    ${Theme.renderCheckboxField(NS, "facturesafficherfraischargeurproducteur", item.facturesafficherfraischargeurproducteur, i18n("FACTURESAFFICHERFRAISCHARGEURPRODUCTEUR"))}
    ${Theme.renderCheckboxField(NS, "facturesafficherfraischargeurtransporteur", item.facturesafficherfraischargeurtransporteur, i18n("FACTURESAFFICHERFRAISCHARGEURTRANSPORTEUR"))}
    ${Theme.renderCheckboxField(NS, "facturesafficherfraisautresproducteur", item.facturesafficherfraisautresproducteur, i18n("FACTURESAFFICHERFRAISAUTRESPRODUCTEUR"))}

    ${Theme.renderCheckboxField(NS, "facturesafficherfraisautrestransporteur", item.facturesafficherfraisautrestransporteur, i18n("FACTURESAFFICHERFRAISAUTRESTRANSPORTEUR"))}
    ${Theme.renderCheckboxField(NS, "facturesafficherfraiscompensationdedeplacement", item.facturesafficherfraiscompensationdedeplacement, i18n("FACTURESAFFICHERFRAISCOMPENSATIONDEDEPLACEMENT"))}
    ${Theme.renderCheckboxField(NS, "facturesafficherfraisautresrevenustransporteur", item.facturesafficherfraisautresrevenustransporteur, i18n("FACTURESAFFICHERFRAISAUTRESREVENUSTRANSPORTEUR"))}
    ${Theme.renderCheckboxField(NS, "facturesafficherfraisautresrevenusproducteur", item.facturesafficherfraisautresrevenusproducteur, i18n("FACTURESAFFICHERFRAISAUTRESREVENUSPRODUCTEUR"))}

    ${Theme.renderTextField(NS, "logopath", item.logopath, i18n("LOGOPATH"), 500)}

    ${Theme.renderCheckboxField(NS, "utiliserlesnomsdemachinedanslenomdeprinter", item.utiliserlesnomsdemachinedanslenomdeprinter, i18n("UTILISERLESNOMSDEMACHINEDANSLENOMDEPRINTER"))}

    ${Theme.renderTextareaField(NS, "message_autorisationdeslivraisons", item.message_autorisationdeslivraisons, i18n("MESSAGE_AUTORISATIONDESLIVRAISONS"), 500, false, null, 10)}
    ${Theme.renderTextareaField(NS, "message_demandecontingentement", item.message_demandecontingentement, i18n("MESSAGE_DEMANDECONTINGENTEMENT"), 500, false, null, 10)}
`;
}

const block_backup = (item: IState) => {
    return `
    ${Theme.renderCheckboxField(NS, "takeacombabackup", item.takeacombabackup, i18n("TAKEACOMBABACKUP"))}
    ${Theme.renderCheckboxField(NS, "takesqlbackup", item.takesqlbackup, i18n("TAKESQLBACKUP"))}
    ${Theme.renderTextField(NS, "nomdb", item.nomdb, i18n("NOMDB"), 500)}
    ${Theme.renderNumberField(NS, "timeoutsql", item.timeoutsql, i18n("TIMEOUTSQL"), true)}
    ${Theme.renderNumberField(NS, "tempsentrelesbackupsautomatiques", item.tempsentrelesbackupsautomatiques, i18n("TEMPSENTRELESBACKUPSAUTOMATIQUES"))}
`;
}

const block_security = (item: IState) => {
    return `
    ${Theme.renderTextField(NS, "caneditundeliveredpermits", item.caneditundeliveredpermits, i18n("CANEDITUNDELIVEREDPERMITS"), 500)}

    ${Theme.renderTextField(NS, "adminpassword", item.adminpassword, i18n("ADMINPASSWORD"), 500)}
    ${Theme.renderTextField(NS, "deletefichepassword", item.deletefichepassword, i18n("DELETEFICHEPASSWORD"), 500)}
`;
}

const block_default_profile = (item: IState) => {
    return `
    ${Theme.renderTextField(NS, "imprimantedepermis", item.imprimantedepermis, i18n("IMPRIMANTEDEPERMIS"), 500)}
    ${Theme.renderNumberField(NS, "permisprintermarginbottom", item.permisprintermarginbottom, i18n("PERMISPRINTERMARGINBOTTOM"))}
    ${Theme.renderNumberField(NS, "permisprintermarginleft", item.permisprintermarginleft, i18n("PERMISPRINTERMARGINLEFT"))}
    ${Theme.renderNumberField(NS, "permisprintermarginright", item.permisprintermarginright, i18n("PERMISPRINTERMARGINRIGHT"))}
    ${Theme.renderNumberField(NS, "permisprintermargintop", item.permisprintermargintop, i18n("PERMISPRINTERMARGINTOP"))}

    ${Theme.renderTextField(NS, "imprimanteautresrapports", item.imprimanteautresrapports, i18n("IMPRIMANTEAUTRESRAPPORTS"), 500)}
    ${Theme.renderNumberField(NS, "autresraportsprintermarginbottom", item.autresraportsprintermarginbottom, i18n("AUTRESRAPORTSPRINTERMARGINBOTTOM"))}
    ${Theme.renderNumberField(NS, "autresraportsprintermarginleft", item.autresraportsprintermarginleft, i18n("AUTRESRAPORTSPRINTERMARGINLEFT"))}
    ${Theme.renderNumberField(NS, "autresraportsprintermarginright", item.autresraportsprintermarginright, i18n("AUTRESRAPORTSPRINTERMARGINRIGHT"))}
    ${Theme.renderNumberField(NS, "autresraportsprintermargintop", item.autresraportsprintermargintop, i18n("AUTRESRAPORTSPRINTERMARGINTOP"))}

    ${Theme.renderTextField(NS, "excellanguage", item.excellanguage, i18n("EXCELLANGUAGE"), 500)}

    ${Theme.renderTextField(NS, "acrobatpath", item.acrobatpath, i18n("ACROBATPATH"), 500)}

    ${Theme.renderTextField(NS, "cletriclientnom", item.cletriclientnom, i18n("CLETRICLIENTNOM"), 500)}
`;
}

const block_todo = (item: IState) => {
    return `
    ${Theme.renderCheckboxField(NS, "facturesafficherfraisautrechargepourtransporteur", item.facturesafficherfraisautrechargepourtransporteur, i18n("FACTURESAFFICHERFRAISAUTRECHARGEPOURTRANSPORTEUR"))}
    ${Theme.renderNumberField(NS, "fournisseurpointerid", item.fournisseurpointerid, i18n("FOURNISSEURPOINTERID"), true)}
    ${Theme.renderTextField(NS, "gpversion", item.gpversion, i18n("GPVERSION"), 500)}
    ${Theme.renderTextField(NS, "logfile", item.logfile, i18n("LOGFILE"), 500)}
    ${Theme.renderTextField(NS, "messageimpressionsdefactures", item.messageimpressionsdefactures, i18n("MESSAGEIMPRESSIONSDEFACTURES"), 500)}
    ${Theme.renderTextField(NS, "messagelivraisonnonconforme", item.messagelivraisonnonconforme, i18n("MESSAGELIVRAISONNONCONFORME"), 500)}
    ${Theme.renderTextField(NS, "syndicat_nom", item.syndicat_nom, i18n("SYNDICAT_NOM"), 500)}
    ${Theme.renderTextField(NS, "updateotherdatabase", item.updateotherdatabase, i18n("UPDATEOTHERDATABASE"), 500)}
`;
}


const formTemplate = (item: IState, fournisseur_planconjoint: string, fournisseur_surcharge: string, compte_paiements: string, compte_arecevoir: string, compte_apayer: string, compte_duauxproducteurs: string, compte_tpspercues: string, compte_tpspayees: string, compte_tvqpercues: string, compte_tvqpayees: string, fournisseur_fond_roulement: string, fournisseur_fond_forestier: string, fournisseur_preleve_divers: string) => {
    return `
<div class="js-float-menu">
    <ul>
        <li>${Theme.float_menu_button("Compte")}</li>
        <li>${Theme.float_menu_button("Paramètres système")}</li>
        <li>${Theme.float_menu_button("Personnalisation")}</li>
        <li>${Theme.float_menu_button("Acomba")}</li>
        <li>${Theme.float_menu_button("Comptes/Fournisseurs")}</li>
        <li>${Theme.float_menu_button("Taxe")}</li>
        <li>${Theme.float_menu_button("Permis")}</li>
        <li>${Theme.float_menu_button("Paramètres imprimantes")}</li>
        <li>${Theme.float_menu_button("Backup")}</li>
        <li>${Theme.float_menu_button("Sécurité")}</li>
        <li>${Theme.float_menu_button("Profil par défaut")}</li>
        <li>${Theme.float_menu_button("TODO")}</li>
    </ul>
</div>

<div class="columns">
    <div class="column is-8 is-offset-3">
        ${Theme.wrapFieldset("Compte", block_company(item))}
        ${Theme.wrapFieldset("Paramètres système", block_system(item))}
        ${Theme.wrapFieldset("Personnalisation", block_personnalisation(item))}
        ${Theme.wrapFieldset("Acomba", block_acomba(item))}
        ${Theme.wrapFieldset("Comptes/Fournisseurs", block_comptes(item, fournisseur_planconjoint, fournisseur_surcharge, compte_paiements, compte_arecevoir, compte_apayer, compte_duauxproducteurs, compte_tpspercues, compte_tpspayees, compte_tvqpercues, compte_tvqpayees, fournisseur_fond_roulement, fournisseur_fond_forestier, fournisseur_preleve_divers))}
        ${Theme.wrapFieldset("Taxe", block_preleve(item))}
        ${Theme.wrapFieldset("Permis", block_permis(item))}
        ${Theme.wrapFieldset("Paramètres imprimantes", block_print(item))}
        ${Theme.wrapFieldset("Backup", block_backup(item))}
        ${Theme.wrapFieldset("Sécurité", block_security(item))}
        ${Theme.wrapFieldset("Profil par défaut", block_default_profile(item))}
        ${Theme.wrapFieldset("TODO", block_todo(item))}
    </div>
</div>

    ${Theme.renderBlame(item, isNew)}
`;
};

const pageTemplate = (item: IState, form: string, tab: string, warning: string, dirty: string) => {
    let canEdit = true;
    let readonly = !canEdit;

    let canInsert = canEdit && isNew; // && Perm.hasCompany_CanAddCompany;
    let canDelete = canEdit && !canInsert; // && Perm.hasCompany_CanDeleteCompany;
    let canAdd = canEdit && !canInsert; // && Perm.hasCompany_CanAddCompany;
    let canUpdate = canEdit && !isNew;

    let buttons: string[] = [];
    buttons.push(Theme.buttonCancel(NS));
    if (canInsert) buttons.push(Theme.buttonInsert(NS));
    if (canDelete) buttons.push(Theme.buttonDelete(NS));
    if (canAdd) buttons.push(Theme.buttonAddNew(NS, "#/admin/company/new"));
    if (canUpdate) buttons.push(Theme.buttonUpdate(NS));
    let actions = Theme.renderButtons(buttons);

    let title = buildTitle(xtra, !isNew ? i18n("company Details") : i18n("New company"));
    let subtitle = buildSubtitle(xtra, i18n("company subtitle"));

    return `
<form onsubmit="return false;" ${readonly ? "class='js-readonly'" : ""}>
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
            ${Theme.renderBlame(item, isNew)}
        </div>
    </div>
    ${Theme.wrapContent("js-uc-tabs", tab)}
</div>
<div class="js-body">
    ${Theme.wrapContent("js-uc-notification", dirty)}
    ${Theme.wrapContent("js-uc-notification", warning)}
    ${Theme.wrapContent("js-uc-details", form)}
</div>
</div>

${Theme.renderModalDelete(`modalDelete_${NS}`, `${NS}.drop()`)}

</form>
`;
};

const dirtyTemplate = () => {
    return (isDirty ? App.dirtyTemplate(NS, Misc.changes(fetchedState, state)) : "");
}

export const fetchState = (cie: number) => {
    isNew = isNaN(cie);
    isDirty = false;
    Router.registerDirtyExit(dirtyExit);
    return App.GET(`/company/${isNew ? "new" : cie}`)
        .then((payload: IPayload) => {
            state = payload.item;
            fetchedState = Misc.clone(state) as IState;
            xtra = payload.xtra;
            key = <IKey>{ cie };


        })
        .then(Lookup.fetch_autreFournisseur())
        .then(Lookup.fetch_compte())
};

export const fetch = (params: string[]) => {
    let cie = +params[0];
    App.prepareRender(NS, i18n("company"));
    fetchState(cie)
        .then(App.render)
        .catch(App.render);
};

export const render = () => {
    if (!inContext()) return "";
    if (App.fatalError()) return App.fatalErrorTemplate();
    if (state == undefined || Object.keys(state).length == 0)
        return App.warningTemplate() || App.unexpectedTemplate();

    let year = Perm.getCurrentYear(); //or something better
    let lookup_autreFournisseur = Lookup.get_autreFournisseur(year);
    let lookup_compte = Lookup.get_compte(year);

    let fournisseur_planconjoint = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_planconjoint, true);
    let fournisseur_surcharge = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_surcharge, true);
    let compte_paiements = Theme.renderOptions(lookup_compte, state.compte_paiements, true);
    let compte_arecevoir = Theme.renderOptions(lookup_compte, state.compte_arecevoir, true);
    let compte_apayer = Theme.renderOptions(lookup_compte, state.compte_apayer, true);
    let compte_duauxproducteurs = Theme.renderOptions(lookup_compte, state.compte_duauxproducteurs, true);
    let compte_tpspercues = Theme.renderOptions(lookup_compte, state.compte_tpspercues, true);
    let compte_tpspayees = Theme.renderOptions(lookup_compte, state.compte_tpspayees, true);
    let compte_tvqpercues = Theme.renderOptions(lookup_compte, state.compte_tvqpercues, true);
    let compte_tvqpayees = Theme.renderOptions(lookup_compte, state.compte_tvqpayees, true);
    let fournisseur_fond_roulement = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_fond_roulement, true);
    let fournisseur_fond_forestier = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_fond_forestier, true);
    let fournisseur_preleve_divers = Theme.renderOptions(lookup_autreFournisseur, state.fournisseur_preleve_divers, true);


    const form = formTemplate(state, fournisseur_planconjoint, fournisseur_surcharge, compte_paiements, compte_arecevoir, compte_apayer, compte_duauxproducteurs, compte_tpspercues, compte_tpspayees, compte_tvqpercues, compte_tvqpayees, fournisseur_fond_roulement, fournisseur_fond_forestier, fournisseur_preleve_divers);

    const tab = tabTemplate(state.cie, xtra, isNew);
    const dirty = dirtyTemplate();
    const warning = App.warningTemplate();
    return pageTemplate(state, form, tab, warning, dirty);
};

export const postRender = () => {
    if (!inContext()) return;



    App.setPageTitle(isNew ? i18n("New company") : xtra.title);
};

export const inContext = () => {
    return App.inContext(NS);
};

const getFormState = () => {
    let clone = Misc.clone(state) as IState;
    clone.name = Misc.fromInputText(`${NS}_name`, state.name);
    clone.features = Misc.fromInputTextNullable(`${NS}_features`, state.features);
    clone.archive = Misc.fromInputCheckbox(`${NS}_archive`, state.archive);
    clone.acombapassword = Misc.fromInputTextNullable(`${NS}_acombapassword`, state.acombapassword);
    clone.acombapath = Misc.fromInputTextNullable(`${NS}_acombapath`, state.acombapath);
    clone.acombasocietepath = Misc.fromInputTextNullable(`${NS}_acombasocietepath`, state.acombasocietepath);
    clone.acombasyncropath = Misc.fromInputTextNullable(`${NS}_acombasyncropath`, state.acombasyncropath);
    clone.acombausername = Misc.fromInputTextNullable(`${NS}_acombausername`, state.acombausername);
    clone.acrobatpath = Misc.fromInputTextNullable(`${NS}_acrobatpath`, state.acrobatpath);
    clone.adminpassword = Misc.fromInputTextNullable(`${NS}_adminpassword`, state.adminpassword);
    clone.afficherpermit1 = Misc.fromInputCheckbox(`${NS}_afficherpermit1`, state.afficherpermit1);
    clone.afficherpermit2 = Misc.fromInputCheckbox(`${NS}_afficherpermit2`, state.afficherpermit2);
    clone.afficherpermit3 = Misc.fromInputCheckbox(`${NS}_afficherpermit3`, state.afficherpermit3);
    clone.afficherpermit4 = Misc.fromInputCheckbox(`${NS}_afficherpermit4`, state.afficherpermit4);
    clone.anneecourante = Misc.fromInputNumber(`${NS}_anneecourante`, state.anneecourante);
    clone.autresraportsprintermarginbottom = Misc.fromInputNumberNullable(`${NS}_autresraportsprintermarginbottom`, state.autresraportsprintermarginbottom);
    clone.autresraportsprintermarginleft = Misc.fromInputNumberNullable(`${NS}_autresraportsprintermarginleft`, state.autresraportsprintermarginleft);
    clone.autresraportsprintermarginright = Misc.fromInputNumberNullable(`${NS}_autresraportsprintermarginright`, state.autresraportsprintermarginright);
    clone.autresraportsprintermargintop = Misc.fromInputNumberNullable(`${NS}_autresraportsprintermargintop`, state.autresraportsprintermargintop);
    clone.caneditundeliveredpermits = Misc.fromInputTextNullable(`${NS}_caneditundeliveredpermits`, state.caneditundeliveredpermits);
    clone.ccemail = Misc.fromInputTextNullable(`${NS}_ccemail`, state.ccemail);
    clone.cletriclientnom = Misc.fromInputTextNullable(`${NS}_cletriclientnom`, state.cletriclientnom);
    clone.copiepermit1 = Misc.fromInputCheckbox(`${NS}_copiepermit1`, state.copiepermit1);
    clone.copiepermit2 = Misc.fromInputCheckbox(`${NS}_copiepermit2`, state.copiepermit2);
    clone.copiepermit3 = Misc.fromInputCheckbox(`${NS}_copiepermit3`, state.copiepermit3);
    clone.copiepermit4 = Misc.fromInputCheckbox(`${NS}_copiepermit4`, state.copiepermit4);
    clone.deletefichepassword = Misc.fromInputTextNullable(`${NS}_deletefichepassword`, state.deletefichepassword);
    clone.emailpermit1 = Misc.fromInputCheckbox(`${NS}_emailpermit1`, state.emailpermit1);
    clone.emailpermit2 = Misc.fromInputCheckbox(`${NS}_emailpermit2`, state.emailpermit2);
    clone.emailpermit3 = Misc.fromInputCheckbox(`${NS}_emailpermit3`, state.emailpermit3);
    clone.emailpermit4 = Misc.fromInputCheckbox(`${NS}_emailpermit4`, state.emailpermit4);
    clone.excellanguage = Misc.fromInputTextNullable(`${NS}_excellanguage`, state.excellanguage);
    clone.facturesafficherfraisautrechargepourtransporteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraisautrechargepourtransporteur`, state.facturesafficherfraisautrechargepourtransporteur);
    clone.facturesafficherfraisautresproducteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraisautresproducteur`, state.facturesafficherfraisautresproducteur);
    clone.facturesafficherfraisautresrevenusproducteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraisautresrevenusproducteur`, state.facturesafficherfraisautresrevenusproducteur);
    clone.facturesafficherfraisautresrevenustransporteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraisautresrevenustransporteur`, state.facturesafficherfraisautresrevenustransporteur);
    clone.facturesafficherfraisautrestransporteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraisautrestransporteur`, state.facturesafficherfraisautrestransporteur);
    clone.facturesafficherfraischargeurproducteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraischargeurproducteur`, state.facturesafficherfraischargeurproducteur);
    clone.facturesafficherfraischargeurtransporteur = Misc.fromInputCheckbox(`${NS}_facturesafficherfraischargeurtransporteur`, state.facturesafficherfraischargeurtransporteur);
    clone.facturesafficherfraiscompensationdedeplacement = Misc.fromInputCheckbox(`${NS}_facturesafficherfraiscompensationdedeplacement`, state.facturesafficherfraiscompensationdedeplacement);
    clone.facturesaffichersurchargeproducteur = Misc.fromInputCheckbox(`${NS}_facturesaffichersurchargeproducteur`, state.facturesaffichersurchargeproducteur);
    clone.formicon = Misc.fromInputTextNullable(`${NS}_formicon`, state.formicon);
    clone.formtext = Misc.fromInputTextNullable(`${NS}_formtext`, state.formtext);
    clone.fournisseurpointerid = Misc.fromInputNumber(`${NS}_fournisseurpointerid`, state.fournisseurpointerid);
    clone.fromemail = Misc.fromInputTextNullable(`${NS}_fromemail`, state.fromemail);
    clone.gpversion = Misc.fromInputTextNullable(`${NS}_gpversion`, state.gpversion);
    clone.helpfilepath = Misc.fromInputTextNullable(`${NS}_helpfilepath`, state.helpfilepath);
    clone.imprimanteautresrapports = Misc.fromInputTextNullable(`${NS}_imprimanteautresrapports`, state.imprimanteautresrapports);
    clone.imprimantedepermis = Misc.fromInputTextNullable(`${NS}_imprimantedepermis`, state.imprimantedepermis);
    clone.livraisonliertaux = Misc.fromInputCheckbox(`${NS}_livraisonliertaux`, state.livraisonliertaux);
    clone.logfile = Misc.fromInputTextNullable(`${NS}_logfile`, state.logfile);
    clone.logopath = Misc.fromInputTextNullable(`${NS}_logopath`, state.logopath);
    clone.massecontingentvoyagedefaut = Misc.fromInputNumber(`${NS}_massecontingentvoyagedefaut`, state.massecontingentvoyagedefaut);
    clone.masselimitedefaut = Misc.fromInputNumber(`${NS}_masselimitedefaut`, state.masselimitedefaut);
    clone.message_autorisationdeslivraisons = Misc.fromInputTextNullable(`${NS}_message_autorisationdeslivraisons`, state.message_autorisationdeslivraisons);
    clone.message_demandecontingentement = Misc.fromInputTextNullable(`${NS}_message_demandecontingentement`, state.message_demandecontingentement);
    clone.messageimpressionsdefactures = Misc.fromInputTextNullable(`${NS}_messageimpressionsdefactures`, state.messageimpressionsdefactures);
    clone.messagelivraisonnonconforme = Misc.fromInputTextNullable(`${NS}_messagelivraisonnonconforme`, state.messagelivraisonnonconforme);
    clone.messagespecpermitanglais = Misc.fromInputTextNullable(`${NS}_messagespecpermitanglais`, state.messagespecpermitanglais);
    clone.messagespecpermitfrancais = Misc.fromInputTextNullable(`${NS}_messagespecpermitfrancais`, state.messagespecpermitfrancais);
    clone.nomdb = Misc.fromInputTextNullable(`${NS}_nomdb`, state.nomdb);
    clone.permisprintermarginbottom = Misc.fromInputNumberNullable(`${NS}_permisprintermarginbottom`, state.permisprintermarginbottom);
    clone.permisprintermarginleft = Misc.fromInputNumberNullable(`${NS}_permisprintermarginleft`, state.permisprintermarginleft);
    clone.permisprintermarginright = Misc.fromInputNumberNullable(`${NS}_permisprintermarginright`, state.permisprintermarginright);
    clone.permisprintermargintop = Misc.fromInputNumberNullable(`${NS}_permisprintermargintop`, state.permisprintermargintop);
    clone.permisprintpreview = Misc.fromInputCheckbox(`${NS}_permisprintpreview`, state.permisprintpreview);
    clone.preleves_notps = Misc.fromInputTextNullable(`${NS}_preleves_notps`, state.preleves_notps);
    clone.preleves_notvq = Misc.fromInputTextNullable(`${NS}_preleves_notvq`, state.preleves_notvq);
    clone.serveuremail = Misc.fromInputTextNullable(`${NS}_serveuremail`, state.serveuremail);
    clone.showyearsinpermislistview = Misc.fromInputTextNullable(`${NS}_showyearsinpermislistview`, state.showyearsinpermislistview);
    clone.superficiecontingenteepourcentagededuction = Misc.fromInputNumberNullable(`${NS}_superficiecontingenteepourcentagededuction`, state.superficiecontingenteepourcentagededuction);
    clone.superficiecontingenteesansdeduction = Misc.fromInputNumberNullable(`${NS}_superficiecontingenteesansdeduction`, state.superficiecontingenteesansdeduction);
    clone.syndicat_codepostal = Misc.fromInputTextNullable(`${NS}_syndicat_codepostal`, state.syndicat_codepostal);
    clone.syndicat_fax = Misc.fromInputTextNullable(`${NS}_syndicat_fax`, state.syndicat_fax);
    clone.syndicat_nom = Misc.fromInputTextNullable(`${NS}_syndicat_nom`, state.syndicat_nom);
    clone.syndicat_nomanglais = Misc.fromInputTextNullable(`${NS}_syndicat_nomanglais`, state.syndicat_nomanglais);
    clone.syndicat_nomfrancais = Misc.fromInputTextNullable(`${NS}_syndicat_nomfrancais`, state.syndicat_nomfrancais);
    clone.syndicat_notps = Misc.fromInputTextNullable(`${NS}_syndicat_notps`, state.syndicat_notps);
    clone.syndicat_notvq = Misc.fromInputTextNullable(`${NS}_syndicat_notvq`, state.syndicat_notvq);
    clone.syndicat_rue = Misc.fromInputTextNullable(`${NS}_syndicat_rue`, state.syndicat_rue);
    clone.syndicat_telephone = Misc.fromInputTextNullable(`${NS}_syndicat_telephone`, state.syndicat_telephone);
    clone.syndicat_ville = Misc.fromInputTextNullable(`${NS}_syndicat_ville`, state.syndicat_ville);
    clone.syndicatouoffice = Misc.fromInputTextNullable(`${NS}_syndicatouoffice`, state.syndicatouoffice);
    clone.takeacombabackup = Misc.fromInputCheckbox(`${NS}_takeacombabackup`, state.takeacombabackup);
    clone.takesqlbackup = Misc.fromInputCheckbox(`${NS}_takesqlbackup`, state.takesqlbackup);
    clone.tempsentrelesbackupsautomatiques = Misc.fromInputNumberNullable(`${NS}_tempsentrelesbackupsautomatiques`, state.tempsentrelesbackupsautomatiques);
    clone.timeoutsql = Misc.fromInputNumber(`${NS}_timeoutsql`, state.timeoutsql);
    clone.typepermis = Misc.fromInputNumber(`${NS}_typepermis`, state.typepermis);
    clone.typepermis1 = Misc.fromInputTextNullable(`${NS}_typepermis1`, state.typepermis1);
    clone.typepermis1anglais = Misc.fromInputTextNullable(`${NS}_typepermis1anglais`, state.typepermis1anglais);
    clone.typepermis1francais = Misc.fromInputTextNullable(`${NS}_typepermis1francais`, state.typepermis1francais);
    clone.typepermis2 = Misc.fromInputTextNullable(`${NS}_typepermis2`, state.typepermis2);
    clone.typepermis2anglais = Misc.fromInputTextNullable(`${NS}_typepermis2anglais`, state.typepermis2anglais);
    clone.typepermis2francais = Misc.fromInputTextNullable(`${NS}_typepermis2francais`, state.typepermis2francais);
    clone.typepermis3 = Misc.fromInputTextNullable(`${NS}_typepermis3`, state.typepermis3);
    clone.typepermis3anglais = Misc.fromInputTextNullable(`${NS}_typepermis3anglais`, state.typepermis3anglais);
    clone.typepermis3francais = Misc.fromInputTextNullable(`${NS}_typepermis3francais`, state.typepermis3francais);
    clone.typepermis4 = Misc.fromInputTextNullable(`${NS}_typepermis4`, state.typepermis4);
    clone.typepermis4anglais = Misc.fromInputTextNullable(`${NS}_typepermis4anglais`, state.typepermis4anglais);
    clone.typepermis4francais = Misc.fromInputTextNullable(`${NS}_typepermis4francais`, state.typepermis4francais);
    clone.updateotherdatabase = Misc.fromInputTextNullable(`${NS}_updateotherdatabase`, state.updateotherdatabase);
    clone.utiliselesychronisateurdirect = Misc.fromInputCheckbox(`${NS}_utiliselesychronisateurdirect`, state.utiliselesychronisateurdirect);
    clone.utiliserlesnomsdemachinedanslenomdeprinter = Misc.fromInputCheckbox(`${NS}_utiliserlesnomsdemachinedanslenomdeprinter`, state.utiliserlesnomsdemachinedanslenomdeprinter);
    clone.utiliserlotscontingentes = Misc.fromInputCheckbox(`${NS}_utiliserlotscontingentes`, state.utiliserlotscontingentes);
    clone.xlstemplatespath = Misc.fromInputTextNullable(`${NS}_xlstemplatespath`, state.xlstemplatespath);
    clone.fournisseur_planconjoint = Misc.fromSelectText(`${NS}_fournisseur_planconjoint`, state.fournisseur_planconjoint);
    clone.fournisseur_surcharge = Misc.fromSelectText(`${NS}_fournisseur_surcharge`, state.fournisseur_surcharge);
    clone.compte_paiements = Misc.fromSelectNumber(`${NS}_compte_paiements`, state.compte_paiements);
    clone.compte_arecevoir = Misc.fromSelectNumber(`${NS}_compte_arecevoir`, state.compte_arecevoir);
    clone.compte_apayer = Misc.fromSelectNumber(`${NS}_compte_apayer`, state.compte_apayer);
    clone.compte_duauxproducteurs = Misc.fromSelectNumber(`${NS}_compte_duauxproducteurs`, state.compte_duauxproducteurs);
    clone.compte_tpspercues = Misc.fromSelectNumber(`${NS}_compte_tpspercues`, state.compte_tpspercues);
    clone.compte_tpspayees = Misc.fromSelectNumber(`${NS}_compte_tpspayees`, state.compte_tpspayees);
    clone.compte_tvqpercues = Misc.fromSelectNumber(`${NS}_compte_tvqpercues`, state.compte_tvqpercues);
    clone.compte_tvqpayees = Misc.fromSelectNumber(`${NS}_compte_tvqpayees`, state.compte_tvqpayees);
    clone.taux_tps = Misc.fromInputNumberNullable(`${NS}_taux_tps`, state.taux_tps);
    clone.taux_tvq = Misc.fromInputNumberNullable(`${NS}_taux_tvq`, state.taux_tvq);
    clone.fournisseur_fond_roulement = Misc.fromSelectText(`${NS}_fournisseur_fond_roulement`, state.fournisseur_fond_roulement);
    clone.fournisseur_fond_forestier = Misc.fromSelectText(`${NS}_fournisseur_fond_forestier`, state.fournisseur_fond_forestier);
    clone.fournisseur_preleve_divers = Misc.fromSelectText(`${NS}_fournisseur_preleve_divers`, state.fournisseur_preleve_divers);
    return clone;
};

const valid = (formState: IState): boolean => {
    //if (formState.somefield.length == 0) App.setError("Somefield is required");
    return App.hasNoError();
};

const html5Valid = (): boolean => {
    document.getElementById(`${NS}_dummy_submit`).click();
    let form = document.getElementsByTagName("form")[0];
    form.classList.add("js-error");
    return form.checkValidity();
};

export const onchange = (input: HTMLInputElement) => {
    state = getFormState();
    App.render();
};

export const cancel = () => {
    Router.goBackOrResume(isDirty);
}

export const create = () => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
    App.prepareRender();
    App.POST("/company", Misc.createBlack(formState, blackList))
        .then(payload => {
            let newkey = <IKey>payload;
            Misc.toastSuccessSave();
            Router.goto(`#/admin/company/${newkey.cie}`, 10);
        })
        .catch(App.render);
}

export const save = (done = false) => {
    let formState = getFormState();
    if (!html5Valid()) return;
    if (!valid(formState)) return App.render();
    App.prepareRender();
    App.PUT("/company", Misc.createBlack(formState, blackList))
        .then(_ => {
            Misc.toastSuccessSave();
            if (done)
                Router.goto(`#/admin/companys/`, 100);
            else
                Router.goto(`#/admin/company/${key.cie}`, 10);
        })
        .catch(App.render);
}

export const drop = () => {
    (<any>key).updated = state.updated;
    App.prepareRender();
    App.DELETE("/company", key)
        .then(_ => {

            Router.goto(`#/admin/companys/`, 250);
        })
        .catch(App.render);
}

const dirtyExit = () => {
    isDirty = !Misc.same(fetchedState, getFormState());
    if (isDirty) {
        setTimeout(() => {
            state = getFormState();
            App.render();
        }, 10);
    }
    return isDirty;
};
