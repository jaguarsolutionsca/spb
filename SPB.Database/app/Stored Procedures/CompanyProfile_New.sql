﻿CREATE PROCEDURE [app].[CompanyProfile_New]
(
    @_uid int
)
AS
BEGIN
SET NOCOUNT ON
;

SELECT
    NULL [AcombaPassword],
    NULL [AcombaPath],
    NULL [AcombaSocietePath],
    NULL [AcombaSyncroPath],
    NULL [AcombaUserName],
    NULL [AcrobatPath],
    NULL [AdminPassword],
    0 [AfficherPermit1],
    0 [AfficherPermit2],
    0 [AfficherPermit3],
    0 [AfficherPermit4],
    0 [AnneeCourante],
    NULL [AutresRaportsPrinterMarginBottom],
    NULL [AutresRaportsPrinterMarginLeft],
    NULL [AutresRaportsPrinterMarginRight],
    NULL [AutresRaportsPrinterMarginTop],
    NULL [CanEditUndeliveredPermits],
    NULL [CCEmail],
    NULL [CleTriClientNom],
    0 [CopiePermit1],
    0 [CopiePermit2],
    0 [CopiePermit3],
    0 [CopiePermit4],
    NULL [DeleteFichePassword],
    0 [EmailPermit1],
    0 [EmailPermit2],
    0 [EmailPermit3],
    0 [EmailPermit4],
    NULL [ExcelLanguage],
    0 [FacturesAfficherFraisAutreChargePourTransporteur],
    0 [FacturesAfficherFraisAutresProducteur],
    0 [FacturesAfficherFraisAutresRevenusProducteur],
    0 [FacturesAfficherFraisAutresRevenusTransporteur],
    0 [FacturesAfficherFraisAutresTransporteur],
    0 [FacturesAfficherFraisChargeurProducteur],
    0 [FacturesAfficherFraisChargeurTransporteur],
    0 [FacturesAfficherFraisCompensationDeDeplacement],
    0 [FacturesAfficherSurchargeProducteur],
    NULL [FormIcon],
    NULL [FormText],
    0 [FournisseurPointerID],
    NULL [FromEmail],
    NULL [GPVersion],
    NULL [HelpFilePath],
    NULL [ImprimanteAutresRapports],
    NULL [ImprimanteDePermis],
    0 [LivraisonLierTaux],
    NULL [LogFile],
    NULL [LogoPath],
    0 [MasseContingentVoyageDefaut],
    0 [MasseLimiteDefaut],
    NULL [Message_AutorisationDesLivraisons],
    NULL [Message_DemandeContingentement],
    NULL [MessageImpressionsDeFactures],
    NULL [MessageLivraisonNonConforme],
    NULL [MessageSpecPermitAnglais],
    NULL [MessageSpecPermitFrancais],
    NULL [NomDB],
    NULL [PermisPrinterMarginBottom],
    NULL [PermisPrinterMarginLeft],
    NULL [PermisPrinterMarginRight],
    NULL [PermisPrinterMarginTop],
    0 [PermisPrintPreview],
    NULL [Preleves_NoTPS],
    NULL [Preleves_NoTVQ],
    NULL [ServeurEmail],
    NULL [ShowYearsInPermisListview],
    NULL [SuperficieContingenteePourcentageDeduction],
    NULL [SuperficieContingenteeSansDeduction],
    NULL [Syndicat_CodePostal],
    NULL [Syndicat_Fax],
    NULL [Syndicat_Nom],
    NULL [Syndicat_NomAnglais],
    NULL [Syndicat_NomFrancais],
    NULL [Syndicat_NoTPS],
    NULL [Syndicat_NoTVQ],
    NULL [Syndicat_Rue],
    NULL [Syndicat_Telephone],
    NULL [Syndicat_Ville],
    NULL [SyndicatOuOffice],
    0 [TakeAcombaBackup],
    0 [TakeSQLBackup],
    NULL [TempsEntreLesBackupsAutomatiques],
    0 [TimeoutSQL],
    0 [TypePermis],
    NULL [TypePermis1],
    NULL [TypePermis1Anglais],
    NULL [TypePermis1Francais],
    NULL [TypePermis2],
    NULL [TypePermis2Anglais],
    NULL [TypePermis2Francais],
    NULL [TypePermis3],
    NULL [TypePermis3Anglais],
    NULL [TypePermis3Francais],
    NULL [TypePermis4],
    NULL [TypePermis4Anglais],
    NULL [TypePermis4Francais],
    NULL [UpdateOtherDataBase],
    0 [UtiliseLeSychronisateurDirect],
    0 [UtiliserLesNomsDeMachineDansLeNomDePrinter],
    0 [UtiliserLotsContingentes],
    NULL [XLSTemplatesPath]
;

SELECT
    NULL [Fournisseur_PlanConjoint],
    '' [Fournisseur_PlanConjoint_Text],
    NULL [Fournisseur_Surcharge],
    '' [Fournisseur_Surcharge_Text],
    NULL [Compte_Paiements],
    '' [Compte_Paiements_Text],
    NULL [Compte_ARecevoir],
    '' [Compte_ARecevoir_Text],
    NULL [Compte_APayer],
    '' [Compte_APayer_Text],
    NULL [Compte_DuAuxProducteurs],
    '' [Compte_DuAuxProducteurs_Text],
    NULL [Compte_TPSpercues],
    '' [Compte_TPSpercues_Text],
    NULL [Compte_TPSpayees],
    '' [Compte_TPSpayees_Text],
    NULL [Compte_TVQpercues],
    '' [Compte_TVQpercues_Text],
    NULL [Compte_TVQpayees],
    '' [Compte_TVQpayees_Text],
    NULL [Taux_TPS],
    NULL [Taux_TVQ],
    NULL [Fournisseur_Fond_Roulement],
    '' [Fournisseur_Fond_Roulement_Text],
    NULL [Fournisseur_Fond_Forestier],
    '' [Fournisseur_Fond_Forestier_Text],
    NULL [Fournisseur_Preleve_Divers],
    '' [Fournisseur_Preleve_Divers_Text]
;

END