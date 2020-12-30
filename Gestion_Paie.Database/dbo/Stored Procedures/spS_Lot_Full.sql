﻿
CREATE Procedure [spS_Lot_Full]

/*
Retrieve specific records from the [Lot] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Canton] (via [CantonID])
	[Municipalite_Zone] (via [MunicipaliteID])
	[Fournisseur] (via [ProprietaireID])
	[Fournisseur] (via [ContingentID])
	[Fournisseur] (via [Droit_coupeID])
	[Fournisseur] (via [Entente_paiementID])
	[Municipalite_Zone] (via [ZoneID])
*/

(
 @ID [int] = Null -- for [Lot].[ID] column
,@CantonID [varchar](6) = Null -- for [Lot].[CantonID] column
,@MunicipaliteID [varchar](6) = Null -- for [Lot].[MunicipaliteID] column
,@ProprietaireID [varchar](15) = Null -- for [Lot].[ProprietaireID] column
,@ContingentID [varchar](15) = Null -- for [Lot].[ContingentID] column
,@Droit_coupeID [varchar](15) = Null -- for [Lot].[Droit_coupeID] column
,@Entente_paiementID [varchar](15) = Null -- for [Lot].[Entente_paiementID] column
,@ZoneID [varchar](2) = Null -- for [Lot].[ZoneID] column
,@ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [Lot_Records].[CantonID]
		,[Lot_Records].[Rang]
		,[Lot_Records].[Lot]
		,[Lot_Records].[MunicipaliteID]
		,[Lot_Records].[Superficie_total]
		,[Lot_Records].[Superficie_boisee]
		,[Lot_Records].[ProprietaireID]
		,[Lot_Records].[ContingentID]
		,[Lot_Records].[Contingent_Date]
		,[Lot_Records].[Droit_coupeID]
		,[Lot_Records].[Droit_coupe_Date]
		,[Lot_Records].[Entente_paiementID]
		,[Lot_Records].[Entente_paiement_Date]
		,[Lot_Records].[Actif]
		,[Lot_Records].[ID]
		,[Lot_Records].[Sequence]
		,[Lot_Records].[Partie]
		,[Lot_Records].[Matricule]
		,[Lot_Records].[ZoneID]
		,[Lot_Records].[Secteur]
		,[Lot_Records].[Cadastre]
		,[Lot_Records].[Reforme]
		,[Lot_Records].[LotsComplementaires]
		,[Lot_Records].[Certifie]
		,[Lot_Records].[NumeroCertification]
		,[Lot_Records].[OGC]
		,[Lot_Records].[CantonID_ID]
		,[Lot_Records].[CantonID_Description]
		,[Lot_Records].[CantonID_Actif]
		,[Lot_Records].[MunicipaliteID_ID]
		,[Lot_Records].[MunicipaliteID_MunicipaliteID]
		,[Lot_Records].[MunicipaliteID_Description]
		,[Lot_Records].[MunicipaliteID_Actif]
		,[Lot_Records].[ProprietaireID_ID]
		,[Lot_Records].[ProprietaireID_CleTri]
		,[Lot_Records].[ProprietaireID_Nom]
		,[Lot_Records].[ProprietaireID_AuSoinsDe]
		,[Lot_Records].[ProprietaireID_Rue]
		,[Lot_Records].[ProprietaireID_Ville]
		,[Lot_Records].[ProprietaireID_PaysID]
		,[Lot_Records].[ProprietaireID_Code_postal]
		,[Lot_Records].[ProprietaireID_Telephone]
		,[Lot_Records].[ProprietaireID_Telephone_Poste]
		,[Lot_Records].[ProprietaireID_Telecopieur]
		,[Lot_Records].[ProprietaireID_Telephone2]
		,[Lot_Records].[ProprietaireID_Telephone2_Desc]
		,[Lot_Records].[ProprietaireID_Telephone2_Poste]
		,[Lot_Records].[ProprietaireID_Telephone3]
		,[Lot_Records].[ProprietaireID_Telephone3_Desc]
		,[Lot_Records].[ProprietaireID_Telephone3_Poste]
		,[Lot_Records].[ProprietaireID_No_membre]
		,[Lot_Records].[ProprietaireID_Resident]
		,[Lot_Records].[ProprietaireID_Email]
		,[Lot_Records].[ProprietaireID_WWW]
		,[Lot_Records].[ProprietaireID_Commentaires]
		,[Lot_Records].[ProprietaireID_AfficherCommentaires]
		,[Lot_Records].[ProprietaireID_DepotDirect]
		,[Lot_Records].[ProprietaireID_InstitutionBanquaireID]
		,[Lot_Records].[ProprietaireID_Banque_transit]
		,[Lot_Records].[ProprietaireID_Banque_folio]
		,[Lot_Records].[ProprietaireID_No_TPS]
		,[Lot_Records].[ProprietaireID_No_TVQ]
		,[Lot_Records].[ProprietaireID_PayerA]
		,[Lot_Records].[ProprietaireID_PayerAID]
		,[Lot_Records].[ProprietaireID_Statut]
		,[Lot_Records].[ProprietaireID_Rep_Nom]
		,[Lot_Records].[ProprietaireID_Rep_Telephone]
		,[Lot_Records].[ProprietaireID_Rep_Telephone_Poste]
		,[Lot_Records].[ProprietaireID_Rep_Email]
		,[Lot_Records].[ProprietaireID_EnAnglais]
		,[Lot_Records].[ProprietaireID_Actif]
		,[Lot_Records].[ProprietaireID_MRCProducteurID]
		,[Lot_Records].[ProprietaireID_PaiementManuel]
		,[Lot_Records].[ProprietaireID_Journal]
		,[Lot_Records].[ProprietaireID_RecoitTPS]
		,[Lot_Records].[ProprietaireID_RecoitTVQ]
		,[Lot_Records].[ProprietaireID_ModifierTrigger]
		,[Lot_Records].[ProprietaireID_IsProducteur]
		,[Lot_Records].[ProprietaireID_IsTransporteur]
		,[Lot_Records].[ProprietaireID_IsChargeur]
		,[Lot_Records].[ProprietaireID_IsAutre]
		,[Lot_Records].[ProprietaireID_AfficherCommentairesSurPermit]
		,[Lot_Records].[ProprietaireID_PasEmissionPermis]
		,[Lot_Records].[ProprietaireID_Generique]
		,[Lot_Records].[ProprietaireID_Membre_OGC]
		,[Lot_Records].[ProprietaireID_InscritTPS]
		,[Lot_Records].[ProprietaireID_InscritTVQ]
		,[Lot_Records].[ContingentID_ID]
		,[Lot_Records].[ContingentID_CleTri]
		,[Lot_Records].[ContingentID_Nom]
		,[Lot_Records].[ContingentID_AuSoinsDe]
		,[Lot_Records].[ContingentID_Rue]
		,[Lot_Records].[ContingentID_Ville]
		,[Lot_Records].[ContingentID_PaysID]
		,[Lot_Records].[ContingentID_Code_postal]
		,[Lot_Records].[ContingentID_Telephone]
		,[Lot_Records].[ContingentID_Telephone_Poste]
		,[Lot_Records].[ContingentID_Telecopieur]
		,[Lot_Records].[ContingentID_Telephone2]
		,[Lot_Records].[ContingentID_Telephone2_Desc]
		,[Lot_Records].[ContingentID_Telephone2_Poste]
		,[Lot_Records].[ContingentID_Telephone3]
		,[Lot_Records].[ContingentID_Telephone3_Desc]
		,[Lot_Records].[ContingentID_Telephone3_Poste]
		,[Lot_Records].[ContingentID_No_membre]
		,[Lot_Records].[ContingentID_Resident]
		,[Lot_Records].[ContingentID_Email]
		,[Lot_Records].[ContingentID_WWW]
		,[Lot_Records].[ContingentID_Commentaires]
		,[Lot_Records].[ContingentID_AfficherCommentaires]
		,[Lot_Records].[ContingentID_DepotDirect]
		,[Lot_Records].[ContingentID_InstitutionBanquaireID]
		,[Lot_Records].[ContingentID_Banque_transit]
		,[Lot_Records].[ContingentID_Banque_folio]
		,[Lot_Records].[ContingentID_No_TPS]
		,[Lot_Records].[ContingentID_No_TVQ]
		,[Lot_Records].[ContingentID_PayerA]
		,[Lot_Records].[ContingentID_PayerAID]
		,[Lot_Records].[ContingentID_Statut]
		,[Lot_Records].[ContingentID_Rep_Nom]
		,[Lot_Records].[ContingentID_Rep_Telephone]
		,[Lot_Records].[ContingentID_Rep_Telephone_Poste]
		,[Lot_Records].[ContingentID_Rep_Email]
		,[Lot_Records].[ContingentID_EnAnglais]
		,[Lot_Records].[ContingentID_Actif]
		,[Lot_Records].[ContingentID_MRCProducteurID]
		,[Lot_Records].[ContingentID_PaiementManuel]
		,[Lot_Records].[ContingentID_Journal]
		,[Lot_Records].[ContingentID_RecoitTPS]
		,[Lot_Records].[ContingentID_RecoitTVQ]
		,[Lot_Records].[ContingentID_ModifierTrigger]
		,[Lot_Records].[ContingentID_IsProducteur]
		,[Lot_Records].[ContingentID_IsTransporteur]
		,[Lot_Records].[ContingentID_IsChargeur]
		,[Lot_Records].[ContingentID_IsAutre]
		,[Lot_Records].[ContingentID_AfficherCommentairesSurPermit]
		,[Lot_Records].[ContingentID_PasEmissionPermis]
		,[Lot_Records].[ContingentID_Generique]
		,[Lot_Records].[ContingentID_Membre_OGC]
		,[Lot_Records].[ContingentID_InscritTPS]
		,[Lot_Records].[ContingentID_InscritTVQ]
		,[Lot_Records].[Droit_coupeID_ID]
		,[Lot_Records].[Droit_coupeID_CleTri]
		,[Lot_Records].[Droit_coupeID_Nom]
		,[Lot_Records].[Droit_coupeID_AuSoinsDe]
		,[Lot_Records].[Droit_coupeID_Rue]
		,[Lot_Records].[Droit_coupeID_Ville]
		,[Lot_Records].[Droit_coupeID_PaysID]
		,[Lot_Records].[Droit_coupeID_Code_postal]
		,[Lot_Records].[Droit_coupeID_Telephone]
		,[Lot_Records].[Droit_coupeID_Telephone_Poste]
		,[Lot_Records].[Droit_coupeID_Telecopieur]
		,[Lot_Records].[Droit_coupeID_Telephone2]
		,[Lot_Records].[Droit_coupeID_Telephone2_Desc]
		,[Lot_Records].[Droit_coupeID_Telephone2_Poste]
		,[Lot_Records].[Droit_coupeID_Telephone3]
		,[Lot_Records].[Droit_coupeID_Telephone3_Desc]
		,[Lot_Records].[Droit_coupeID_Telephone3_Poste]
		,[Lot_Records].[Droit_coupeID_No_membre]
		,[Lot_Records].[Droit_coupeID_Resident]
		,[Lot_Records].[Droit_coupeID_Email]
		,[Lot_Records].[Droit_coupeID_WWW]
		,[Lot_Records].[Droit_coupeID_Commentaires]
		,[Lot_Records].[Droit_coupeID_AfficherCommentaires]
		,[Lot_Records].[Droit_coupeID_DepotDirect]
		,[Lot_Records].[Droit_coupeID_InstitutionBanquaireID]
		,[Lot_Records].[Droit_coupeID_Banque_transit]
		,[Lot_Records].[Droit_coupeID_Banque_folio]
		,[Lot_Records].[Droit_coupeID_No_TPS]
		,[Lot_Records].[Droit_coupeID_No_TVQ]
		,[Lot_Records].[Droit_coupeID_PayerA]
		,[Lot_Records].[Droit_coupeID_PayerAID]
		,[Lot_Records].[Droit_coupeID_Statut]
		,[Lot_Records].[Droit_coupeID_Rep_Nom]
		,[Lot_Records].[Droit_coupeID_Rep_Telephone]
		,[Lot_Records].[Droit_coupeID_Rep_Telephone_Poste]
		,[Lot_Records].[Droit_coupeID_Rep_Email]
		,[Lot_Records].[Droit_coupeID_EnAnglais]
		,[Lot_Records].[Droit_coupeID_Actif]
		,[Lot_Records].[Droit_coupeID_MRCProducteurID]
		,[Lot_Records].[Droit_coupeID_PaiementManuel]
		,[Lot_Records].[Droit_coupeID_Journal]
		,[Lot_Records].[Droit_coupeID_RecoitTPS]
		,[Lot_Records].[Droit_coupeID_RecoitTVQ]
		,[Lot_Records].[Droit_coupeID_ModifierTrigger]
		,[Lot_Records].[Droit_coupeID_IsProducteur]
		,[Lot_Records].[Droit_coupeID_IsTransporteur]
		,[Lot_Records].[Droit_coupeID_IsChargeur]
		,[Lot_Records].[Droit_coupeID_IsAutre]
		,[Lot_Records].[Droit_coupeID_AfficherCommentairesSurPermit]
		,[Lot_Records].[Droit_coupeID_PasEmissionPermis]
		,[Lot_Records].[Droit_coupeID_Generique]
		,[Lot_Records].[Droit_coupeID_Membre_OGC]
		,[Lot_Records].[Droit_coupeID_InscritTPS]
		,[Lot_Records].[Droit_coupeID_InscritTVQ]
		,[Lot_Records].[Entente_paiementID_ID]
		,[Lot_Records].[Entente_paiementID_CleTri]
		,[Lot_Records].[Entente_paiementID_Nom]
		,[Lot_Records].[Entente_paiementID_AuSoinsDe]
		,[Lot_Records].[Entente_paiementID_Rue]
		,[Lot_Records].[Entente_paiementID_Ville]
		,[Lot_Records].[Entente_paiementID_PaysID]
		,[Lot_Records].[Entente_paiementID_Code_postal]
		,[Lot_Records].[Entente_paiementID_Telephone]
		,[Lot_Records].[Entente_paiementID_Telephone_Poste]
		,[Lot_Records].[Entente_paiementID_Telecopieur]
		,[Lot_Records].[Entente_paiementID_Telephone2]
		,[Lot_Records].[Entente_paiementID_Telephone2_Desc]
		,[Lot_Records].[Entente_paiementID_Telephone2_Poste]
		,[Lot_Records].[Entente_paiementID_Telephone3]
		,[Lot_Records].[Entente_paiementID_Telephone3_Desc]
		,[Lot_Records].[Entente_paiementID_Telephone3_Poste]
		,[Lot_Records].[Entente_paiementID_No_membre]
		,[Lot_Records].[Entente_paiementID_Resident]
		,[Lot_Records].[Entente_paiementID_Email]
		,[Lot_Records].[Entente_paiementID_WWW]
		,[Lot_Records].[Entente_paiementID_Commentaires]
		,[Lot_Records].[Entente_paiementID_AfficherCommentaires]
		,[Lot_Records].[Entente_paiementID_DepotDirect]
		,[Lot_Records].[Entente_paiementID_InstitutionBanquaireID]
		,[Lot_Records].[Entente_paiementID_Banque_transit]
		,[Lot_Records].[Entente_paiementID_Banque_folio]
		,[Lot_Records].[Entente_paiementID_No_TPS]
		,[Lot_Records].[Entente_paiementID_No_TVQ]
		,[Lot_Records].[Entente_paiementID_PayerA]
		,[Lot_Records].[Entente_paiementID_PayerAID]
		,[Lot_Records].[Entente_paiementID_Statut]
		,[Lot_Records].[Entente_paiementID_Rep_Nom]
		,[Lot_Records].[Entente_paiementID_Rep_Telephone]
		,[Lot_Records].[Entente_paiementID_Rep_Telephone_Poste]
		,[Lot_Records].[Entente_paiementID_Rep_Email]
		,[Lot_Records].[Entente_paiementID_EnAnglais]
		,[Lot_Records].[Entente_paiementID_Actif]
		,[Lot_Records].[Entente_paiementID_MRCProducteurID]
		,[Lot_Records].[Entente_paiementID_PaiementManuel]
		,[Lot_Records].[Entente_paiementID_Journal]
		,[Lot_Records].[Entente_paiementID_RecoitTPS]
		,[Lot_Records].[Entente_paiementID_RecoitTVQ]
		,[Lot_Records].[Entente_paiementID_ModifierTrigger]
		,[Lot_Records].[Entente_paiementID_IsProducteur]
		,[Lot_Records].[Entente_paiementID_IsTransporteur]
		,[Lot_Records].[Entente_paiementID_IsChargeur]
		,[Lot_Records].[Entente_paiementID_IsAutre]
		,[Lot_Records].[Entente_paiementID_AfficherCommentairesSurPermit]
		,[Lot_Records].[Entente_paiementID_PasEmissionPermis]
		,[Lot_Records].[Entente_paiementID_Generique]
		,[Lot_Records].[Entente_paiementID_Membre_OGC]
		,[Lot_Records].[Entente_paiementID_InscritTPS]
		,[Lot_Records].[Entente_paiementID_InscritTVQ]
		,[Lot_Records].[ZoneID_ID]
		,[Lot_Records].[ZoneID_MunicipaliteID]
		,[Lot_Records].[ZoneID_Description]
		,[Lot_Records].[ZoneID_Actif]

		From [fnLot_Full](@ID, @CantonID, @MunicipaliteID, @ProprietaireID, @ContingentID, @Droit_coupeID, @Entente_paiementID, @ZoneID) As [Lot_Records]
	End

Else

	Begin
		Select

		 [Lot_Records].[CantonID]
		,[Lot_Records].[Rang]
		,[Lot_Records].[Lot]
		,[Lot_Records].[MunicipaliteID]
		,[Lot_Records].[Superficie_total]
		,[Lot_Records].[Superficie_boisee]
		,[Lot_Records].[ProprietaireID]
		,[Lot_Records].[ContingentID]
		,[Lot_Records].[Contingent_Date]
		,[Lot_Records].[Droit_coupeID]
		,[Lot_Records].[Droit_coupe_Date]
		,[Lot_Records].[Entente_paiementID]
		,[Lot_Records].[Entente_paiement_Date]
		,[Lot_Records].[Actif]
		,[Lot_Records].[ID]
		,[Lot_Records].[Sequence]
		,[Lot_Records].[Partie]
		,[Lot_Records].[Matricule]
		,[Lot_Records].[ZoneID]
		,[Lot_Records].[Secteur]
		,[Lot_Records].[Cadastre]
		,[Lot_Records].[Reforme]
		,[Lot_Records].[LotsComplementaires]
		,[Lot_Records].[Certifie]
		,[Lot_Records].[NumeroCertification]
		,[Lot_Records].[OGC]
		,[Lot_Records].[CantonID_ID]
		,[Lot_Records].[CantonID_Description]
		,[Lot_Records].[CantonID_Actif]
		,[Lot_Records].[MunicipaliteID_ID]
		,[Lot_Records].[MunicipaliteID_MunicipaliteID]
		,[Lot_Records].[MunicipaliteID_Description]
		,[Lot_Records].[MunicipaliteID_Actif]
		,[Lot_Records].[ProprietaireID_ID]
		,[Lot_Records].[ProprietaireID_CleTri]
		,[Lot_Records].[ProprietaireID_Nom]
		,[Lot_Records].[ProprietaireID_AuSoinsDe]
		,[Lot_Records].[ProprietaireID_Rue]
		,[Lot_Records].[ProprietaireID_Ville]
		,[Lot_Records].[ProprietaireID_PaysID]
		,[Lot_Records].[ProprietaireID_Code_postal]
		,[Lot_Records].[ProprietaireID_Telephone]
		,[Lot_Records].[ProprietaireID_Telephone_Poste]
		,[Lot_Records].[ProprietaireID_Telecopieur]
		,[Lot_Records].[ProprietaireID_Telephone2]
		,[Lot_Records].[ProprietaireID_Telephone2_Desc]
		,[Lot_Records].[ProprietaireID_Telephone2_Poste]
		,[Lot_Records].[ProprietaireID_Telephone3]
		,[Lot_Records].[ProprietaireID_Telephone3_Desc]
		,[Lot_Records].[ProprietaireID_Telephone3_Poste]
		,[Lot_Records].[ProprietaireID_No_membre]
		,[Lot_Records].[ProprietaireID_Resident]
		,[Lot_Records].[ProprietaireID_Email]
		,[Lot_Records].[ProprietaireID_WWW]
		,[Lot_Records].[ProprietaireID_Commentaires]
		,[Lot_Records].[ProprietaireID_AfficherCommentaires]
		,[Lot_Records].[ProprietaireID_DepotDirect]
		,[Lot_Records].[ProprietaireID_InstitutionBanquaireID]
		,[Lot_Records].[ProprietaireID_Banque_transit]
		,[Lot_Records].[ProprietaireID_Banque_folio]
		,[Lot_Records].[ProprietaireID_No_TPS]
		,[Lot_Records].[ProprietaireID_No_TVQ]
		,[Lot_Records].[ProprietaireID_PayerA]
		,[Lot_Records].[ProprietaireID_PayerAID]
		,[Lot_Records].[ProprietaireID_Statut]
		,[Lot_Records].[ProprietaireID_Rep_Nom]
		,[Lot_Records].[ProprietaireID_Rep_Telephone]
		,[Lot_Records].[ProprietaireID_Rep_Telephone_Poste]
		,[Lot_Records].[ProprietaireID_Rep_Email]
		,[Lot_Records].[ProprietaireID_EnAnglais]
		,[Lot_Records].[ProprietaireID_Actif]
		,[Lot_Records].[ProprietaireID_MRCProducteurID]
		,[Lot_Records].[ProprietaireID_PaiementManuel]
		,[Lot_Records].[ProprietaireID_Journal]
		,[Lot_Records].[ProprietaireID_RecoitTPS]
		,[Lot_Records].[ProprietaireID_RecoitTVQ]
		,[Lot_Records].[ProprietaireID_ModifierTrigger]
		,[Lot_Records].[ProprietaireID_IsProducteur]
		,[Lot_Records].[ProprietaireID_IsTransporteur]
		,[Lot_Records].[ProprietaireID_IsChargeur]
		,[Lot_Records].[ProprietaireID_IsAutre]
		,[Lot_Records].[ProprietaireID_AfficherCommentairesSurPermit]
		,[Lot_Records].[ProprietaireID_PasEmissionPermis]
		,[Lot_Records].[ProprietaireID_Generique]
		,[Lot_Records].[ProprietaireID_Membre_OGC]
		,[Lot_Records].[ProprietaireID_InscritTPS]
		,[Lot_Records].[ProprietaireID_InscritTVQ]
		,[Lot_Records].[ContingentID_ID]
		,[Lot_Records].[ContingentID_CleTri]
		,[Lot_Records].[ContingentID_Nom]
		,[Lot_Records].[ContingentID_AuSoinsDe]
		,[Lot_Records].[ContingentID_Rue]
		,[Lot_Records].[ContingentID_Ville]
		,[Lot_Records].[ContingentID_PaysID]
		,[Lot_Records].[ContingentID_Code_postal]
		,[Lot_Records].[ContingentID_Telephone]
		,[Lot_Records].[ContingentID_Telephone_Poste]
		,[Lot_Records].[ContingentID_Telecopieur]
		,[Lot_Records].[ContingentID_Telephone2]
		,[Lot_Records].[ContingentID_Telephone2_Desc]
		,[Lot_Records].[ContingentID_Telephone2_Poste]
		,[Lot_Records].[ContingentID_Telephone3]
		,[Lot_Records].[ContingentID_Telephone3_Desc]
		,[Lot_Records].[ContingentID_Telephone3_Poste]
		,[Lot_Records].[ContingentID_No_membre]
		,[Lot_Records].[ContingentID_Resident]
		,[Lot_Records].[ContingentID_Email]
		,[Lot_Records].[ContingentID_WWW]
		,[Lot_Records].[ContingentID_Commentaires]
		,[Lot_Records].[ContingentID_AfficherCommentaires]
		,[Lot_Records].[ContingentID_DepotDirect]
		,[Lot_Records].[ContingentID_InstitutionBanquaireID]
		,[Lot_Records].[ContingentID_Banque_transit]
		,[Lot_Records].[ContingentID_Banque_folio]
		,[Lot_Records].[ContingentID_No_TPS]
		,[Lot_Records].[ContingentID_No_TVQ]
		,[Lot_Records].[ContingentID_PayerA]
		,[Lot_Records].[ContingentID_PayerAID]
		,[Lot_Records].[ContingentID_Statut]
		,[Lot_Records].[ContingentID_Rep_Nom]
		,[Lot_Records].[ContingentID_Rep_Telephone]
		,[Lot_Records].[ContingentID_Rep_Telephone_Poste]
		,[Lot_Records].[ContingentID_Rep_Email]
		,[Lot_Records].[ContingentID_EnAnglais]
		,[Lot_Records].[ContingentID_Actif]
		,[Lot_Records].[ContingentID_MRCProducteurID]
		,[Lot_Records].[ContingentID_PaiementManuel]
		,[Lot_Records].[ContingentID_Journal]
		,[Lot_Records].[ContingentID_RecoitTPS]
		,[Lot_Records].[ContingentID_RecoitTVQ]
		,[Lot_Records].[ContingentID_ModifierTrigger]
		,[Lot_Records].[ContingentID_IsProducteur]
		,[Lot_Records].[ContingentID_IsTransporteur]
		,[Lot_Records].[ContingentID_IsChargeur]
		,[Lot_Records].[ContingentID_IsAutre]
		,[Lot_Records].[ContingentID_AfficherCommentairesSurPermit]
		,[Lot_Records].[ContingentID_PasEmissionPermis]
		,[Lot_Records].[ContingentID_Generique]
		,[Lot_Records].[ContingentID_Membre_OGC]
		,[Lot_Records].[ContingentID_InscritTPS]
		,[Lot_Records].[ContingentID_InscritTVQ]
		,[Lot_Records].[Droit_coupeID_ID]
		,[Lot_Records].[Droit_coupeID_CleTri]
		,[Lot_Records].[Droit_coupeID_Nom]
		,[Lot_Records].[Droit_coupeID_AuSoinsDe]
		,[Lot_Records].[Droit_coupeID_Rue]
		,[Lot_Records].[Droit_coupeID_Ville]
		,[Lot_Records].[Droit_coupeID_PaysID]
		,[Lot_Records].[Droit_coupeID_Code_postal]
		,[Lot_Records].[Droit_coupeID_Telephone]
		,[Lot_Records].[Droit_coupeID_Telephone_Poste]
		,[Lot_Records].[Droit_coupeID_Telecopieur]
		,[Lot_Records].[Droit_coupeID_Telephone2]
		,[Lot_Records].[Droit_coupeID_Telephone2_Desc]
		,[Lot_Records].[Droit_coupeID_Telephone2_Poste]
		,[Lot_Records].[Droit_coupeID_Telephone3]
		,[Lot_Records].[Droit_coupeID_Telephone3_Desc]
		,[Lot_Records].[Droit_coupeID_Telephone3_Poste]
		,[Lot_Records].[Droit_coupeID_No_membre]
		,[Lot_Records].[Droit_coupeID_Resident]
		,[Lot_Records].[Droit_coupeID_Email]
		,[Lot_Records].[Droit_coupeID_WWW]
		,[Lot_Records].[Droit_coupeID_Commentaires]
		,[Lot_Records].[Droit_coupeID_AfficherCommentaires]
		,[Lot_Records].[Droit_coupeID_DepotDirect]
		,[Lot_Records].[Droit_coupeID_InstitutionBanquaireID]
		,[Lot_Records].[Droit_coupeID_Banque_transit]
		,[Lot_Records].[Droit_coupeID_Banque_folio]
		,[Lot_Records].[Droit_coupeID_No_TPS]
		,[Lot_Records].[Droit_coupeID_No_TVQ]
		,[Lot_Records].[Droit_coupeID_PayerA]
		,[Lot_Records].[Droit_coupeID_PayerAID]
		,[Lot_Records].[Droit_coupeID_Statut]
		,[Lot_Records].[Droit_coupeID_Rep_Nom]
		,[Lot_Records].[Droit_coupeID_Rep_Telephone]
		,[Lot_Records].[Droit_coupeID_Rep_Telephone_Poste]
		,[Lot_Records].[Droit_coupeID_Rep_Email]
		,[Lot_Records].[Droit_coupeID_EnAnglais]
		,[Lot_Records].[Droit_coupeID_Actif]
		,[Lot_Records].[Droit_coupeID_MRCProducteurID]
		,[Lot_Records].[Droit_coupeID_PaiementManuel]
		,[Lot_Records].[Droit_coupeID_Journal]
		,[Lot_Records].[Droit_coupeID_RecoitTPS]
		,[Lot_Records].[Droit_coupeID_RecoitTVQ]
		,[Lot_Records].[Droit_coupeID_ModifierTrigger]
		,[Lot_Records].[Droit_coupeID_IsProducteur]
		,[Lot_Records].[Droit_coupeID_IsTransporteur]
		,[Lot_Records].[Droit_coupeID_IsChargeur]
		,[Lot_Records].[Droit_coupeID_IsAutre]
		,[Lot_Records].[Droit_coupeID_AfficherCommentairesSurPermit]
		,[Lot_Records].[Droit_coupeID_PasEmissionPermis]
		,[Lot_Records].[Droit_coupeID_Generique]
		,[Lot_Records].[Droit_coupeID_Membre_OGC]
		,[Lot_Records].[Droit_coupeID_InscritTPS]
		,[Lot_Records].[Droit_coupeID_InscritTVQ]
		,[Lot_Records].[Entente_paiementID_ID]
		,[Lot_Records].[Entente_paiementID_CleTri]
		,[Lot_Records].[Entente_paiementID_Nom]
		,[Lot_Records].[Entente_paiementID_AuSoinsDe]
		,[Lot_Records].[Entente_paiementID_Rue]
		,[Lot_Records].[Entente_paiementID_Ville]
		,[Lot_Records].[Entente_paiementID_PaysID]
		,[Lot_Records].[Entente_paiementID_Code_postal]
		,[Lot_Records].[Entente_paiementID_Telephone]
		,[Lot_Records].[Entente_paiementID_Telephone_Poste]
		,[Lot_Records].[Entente_paiementID_Telecopieur]
		,[Lot_Records].[Entente_paiementID_Telephone2]
		,[Lot_Records].[Entente_paiementID_Telephone2_Desc]
		,[Lot_Records].[Entente_paiementID_Telephone2_Poste]
		,[Lot_Records].[Entente_paiementID_Telephone3]
		,[Lot_Records].[Entente_paiementID_Telephone3_Desc]
		,[Lot_Records].[Entente_paiementID_Telephone3_Poste]
		,[Lot_Records].[Entente_paiementID_No_membre]
		,[Lot_Records].[Entente_paiementID_Resident]
		,[Lot_Records].[Entente_paiementID_Email]
		,[Lot_Records].[Entente_paiementID_WWW]
		,[Lot_Records].[Entente_paiementID_Commentaires]
		,[Lot_Records].[Entente_paiementID_AfficherCommentaires]
		,[Lot_Records].[Entente_paiementID_DepotDirect]
		,[Lot_Records].[Entente_paiementID_InstitutionBanquaireID]
		,[Lot_Records].[Entente_paiementID_Banque_transit]
		,[Lot_Records].[Entente_paiementID_Banque_folio]
		,[Lot_Records].[Entente_paiementID_No_TPS]
		,[Lot_Records].[Entente_paiementID_No_TVQ]
		,[Lot_Records].[Entente_paiementID_PayerA]
		,[Lot_Records].[Entente_paiementID_PayerAID]
		,[Lot_Records].[Entente_paiementID_Statut]
		,[Lot_Records].[Entente_paiementID_Rep_Nom]
		,[Lot_Records].[Entente_paiementID_Rep_Telephone]
		,[Lot_Records].[Entente_paiementID_Rep_Telephone_Poste]
		,[Lot_Records].[Entente_paiementID_Rep_Email]
		,[Lot_Records].[Entente_paiementID_EnAnglais]
		,[Lot_Records].[Entente_paiementID_Actif]
		,[Lot_Records].[Entente_paiementID_MRCProducteurID]
		,[Lot_Records].[Entente_paiementID_PaiementManuel]
		,[Lot_Records].[Entente_paiementID_Journal]
		,[Lot_Records].[Entente_paiementID_RecoitTPS]
		,[Lot_Records].[Entente_paiementID_RecoitTVQ]
		,[Lot_Records].[Entente_paiementID_ModifierTrigger]
		,[Lot_Records].[Entente_paiementID_IsProducteur]
		,[Lot_Records].[Entente_paiementID_IsTransporteur]
		,[Lot_Records].[Entente_paiementID_IsChargeur]
		,[Lot_Records].[Entente_paiementID_IsAutre]
		,[Lot_Records].[Entente_paiementID_AfficherCommentairesSurPermit]
		,[Lot_Records].[Entente_paiementID_PasEmissionPermis]
		,[Lot_Records].[Entente_paiementID_Generique]
		,[Lot_Records].[Entente_paiementID_Membre_OGC]
		,[Lot_Records].[Entente_paiementID_InscritTPS]
		,[Lot_Records].[Entente_paiementID_InscritTVQ]
		,[Lot_Records].[ZoneID_ID]
		,[Lot_Records].[ZoneID_MunicipaliteID]
		,[Lot_Records].[ZoneID_Description]
		,[Lot_Records].[ZoneID_Actif]

		From [fnLot_Full](@ID, @CantonID, @MunicipaliteID, @ProprietaireID, @ContingentID, @Droit_coupeID, @Entente_paiementID, @ZoneID) As [Lot_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)

