﻿

Create Procedure [spS_GestionVolume_Full]

/*
Retrieve specific records from the [GestionVolume] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Usine] (via [UsineID])
	[UniteMesure] (via [UniteMesureID])
	[Fournisseur] (via [ProducteurID])
	[Lot] (via [LotID])
*/

(
 @ID [int] = Null -- for [GestionVolume].[ID] column
,@UsineID [varchar](6) = Null -- for [GestionVolume].[UsineID] column
,@UniteMesureID [varchar](6) = Null -- for [GestionVolume].[UniteMesureID] column
,@ProducteurID [varchar](15) = Null -- for [GestionVolume].[ProducteurID] column
,@LotID [int] = Null -- for [GestionVolume].[LotID] column
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

		 [GestionVolume_Records].[ID]
		,[GestionVolume_Records].[DateLivraison]
		,[GestionVolume_Records].[UsineID]
		,[GestionVolume_Records].[UniteMesureID]
		,[GestionVolume_Records].[ProducteurID]
		,[GestionVolume_Records].[Annee]
		,[GestionVolume_Records].[Periode]
		,[GestionVolume_Records].[LotID]
		,[GestionVolume_Records].[DateEntree]
		,[GestionVolume_Records].[UsineID_ID]
		,[GestionVolume_Records].[UsineID_Description]
		,[GestionVolume_Records].[UsineID_UtilisationID]
		,[GestionVolume_Records].[UsineID_Paye_producteur]
		,[GestionVolume_Records].[UsineID_Paye_transporteur]
		,[GestionVolume_Records].[UsineID_Specification]
		,[GestionVolume_Records].[UsineID_Compte_a_recevoir]
		,[GestionVolume_Records].[UsineID_Compte_ajustement]
		,[GestionVolume_Records].[UsineID_Compte_transporteur]
		,[GestionVolume_Records].[UsineID_Compte_producteur]
		,[GestionVolume_Records].[UsineID_Compte_preleve_plan_conjoint]
		,[GestionVolume_Records].[UsineID_Compte_preleve_fond_roulement]
		,[GestionVolume_Records].[UsineID_Compte_preleve_fond_forestier]
		,[GestionVolume_Records].[UsineID_Compte_preleve_divers]
		,[GestionVolume_Records].[UsineID_Compte_mise_en_commun]
		,[GestionVolume_Records].[UsineID_Compte_surcharge]
		,[GestionVolume_Records].[UsineID_Compte_indexation_carburant]
		,[GestionVolume_Records].[UsineID_Actif]
		,[GestionVolume_Records].[UsineID_NePaiePasTPS]
		,[GestionVolume_Records].[UsineID_NePaiePasTVQ]
		,[GestionVolume_Records].[UsineID_NoTPS]
		,[GestionVolume_Records].[UsineID_NoTVQ]
		,[GestionVolume_Records].[UsineID_Compte_chargeur]
		,[GestionVolume_Records].[UsineID_UsineGestionVolume]
		,[GestionVolume_Records].[UsineID_AuSoinsDe]
		,[GestionVolume_Records].[UsineID_Rue]
		,[GestionVolume_Records].[UsineID_Ville]
		,[GestionVolume_Records].[UsineID_PaysID]
		,[GestionVolume_Records].[UsineID_Code_postal]
		,[GestionVolume_Records].[UsineID_Telephone]
		,[GestionVolume_Records].[UsineID_Telephone_Poste]
		,[GestionVolume_Records].[UsineID_Telecopieur]
		,[GestionVolume_Records].[UsineID_Telephone2]
		,[GestionVolume_Records].[UsineID_Telephone2_Desc]
		,[GestionVolume_Records].[UsineID_Telephone2_Poste]
		,[GestionVolume_Records].[UsineID_Telephone3]
		,[GestionVolume_Records].[UsineID_Telephone3_Desc]
		,[GestionVolume_Records].[UsineID_Telephone3_Poste]
		,[GestionVolume_Records].[UsineID_Email]
		,[GestionVolume_Records].[UniteMesureID_ID]
		,[GestionVolume_Records].[UniteMesureID_Description]
		,[GestionVolume_Records].[UniteMesureID_Nb_decimale]
		,[GestionVolume_Records].[UniteMesureID_Actif]
		,[GestionVolume_Records].[UniteMesureID_UseMontant]
		,[GestionVolume_Records].[UniteMesureID_Montant_Preleve_plan_conjoint]
		,[GestionVolume_Records].[UniteMesureID_Montant_Preleve_fond_roulement]
		,[GestionVolume_Records].[UniteMesureID_Montant_Preleve_fond_forestier]
		,[GestionVolume_Records].[UniteMesureID_Montant_Preleve_divers]
		,[GestionVolume_Records].[UniteMesureID_Pourc_Preleve_plan_conjoint]
		,[GestionVolume_Records].[UniteMesureID_Pourc_Preleve_fond_roulement]
		,[GestionVolume_Records].[UniteMesureID_Pourc_Preleve_fond_forestier]
		,[GestionVolume_Records].[UniteMesureID_Pourc_Preleve_divers]
		,[GestionVolume_Records].[ProducteurID_ID]
		,[GestionVolume_Records].[ProducteurID_CleTri]
		,[GestionVolume_Records].[ProducteurID_Nom]
		,[GestionVolume_Records].[ProducteurID_AuSoinsDe]
		,[GestionVolume_Records].[ProducteurID_Rue]
		,[GestionVolume_Records].[ProducteurID_Ville]
		,[GestionVolume_Records].[ProducteurID_PaysID]
		,[GestionVolume_Records].[ProducteurID_Code_postal]
		,[GestionVolume_Records].[ProducteurID_Telephone]
		,[GestionVolume_Records].[ProducteurID_Telephone_Poste]
		,[GestionVolume_Records].[ProducteurID_Telecopieur]
		,[GestionVolume_Records].[ProducteurID_Telephone2]
		,[GestionVolume_Records].[ProducteurID_Telephone2_Desc]
		,[GestionVolume_Records].[ProducteurID_Telephone2_Poste]
		,[GestionVolume_Records].[ProducteurID_Telephone3]
		,[GestionVolume_Records].[ProducteurID_Telephone3_Desc]
		,[GestionVolume_Records].[ProducteurID_Telephone3_Poste]
		,[GestionVolume_Records].[ProducteurID_No_membre]
		,[GestionVolume_Records].[ProducteurID_Resident]
		,[GestionVolume_Records].[ProducteurID_Email]
		,[GestionVolume_Records].[ProducteurID_WWW]
		,[GestionVolume_Records].[ProducteurID_Commentaires]
		,[GestionVolume_Records].[ProducteurID_AfficherCommentaires]
		,[GestionVolume_Records].[ProducteurID_DepotDirect]
		,[GestionVolume_Records].[ProducteurID_InstitutionBanquaireID]
		,[GestionVolume_Records].[ProducteurID_Banque_transit]
		,[GestionVolume_Records].[ProducteurID_Banque_folio]
		,[GestionVolume_Records].[ProducteurID_No_TPS]
		,[GestionVolume_Records].[ProducteurID_No_TVQ]
		,[GestionVolume_Records].[ProducteurID_PayerA]
		,[GestionVolume_Records].[ProducteurID_PayerAID]
		,[GestionVolume_Records].[ProducteurID_Statut]
		,[GestionVolume_Records].[ProducteurID_Rep_Nom]
		,[GestionVolume_Records].[ProducteurID_Rep_Telephone]
		,[GestionVolume_Records].[ProducteurID_Rep_Telephone_Poste]
		,[GestionVolume_Records].[ProducteurID_Rep_Email]
		,[GestionVolume_Records].[ProducteurID_EnAnglais]
		,[GestionVolume_Records].[ProducteurID_Actif]
		,[GestionVolume_Records].[ProducteurID_MRCProducteurID]
		,[GestionVolume_Records].[ProducteurID_PaiementManuel]
		,[GestionVolume_Records].[ProducteurID_Journal]
		,[GestionVolume_Records].[ProducteurID_RecoitTPS]
		,[GestionVolume_Records].[ProducteurID_RecoitTVQ]
		,[GestionVolume_Records].[ProducteurID_ModifierTrigger]
		,[GestionVolume_Records].[ProducteurID_IsProducteur]
		,[GestionVolume_Records].[ProducteurID_IsTransporteur]
		,[GestionVolume_Records].[ProducteurID_IsChargeur]
		,[GestionVolume_Records].[ProducteurID_IsAutre]
		,[GestionVolume_Records].[ProducteurID_AfficherCommentairesSurPermit]
		,[GestionVolume_Records].[ProducteurID_PasEmissionPermis]
		,[GestionVolume_Records].[ProducteurID_Generique]
		,[GestionVolume_Records].[LotID_CantonID]
		,[GestionVolume_Records].[LotID_Rang]
		,[GestionVolume_Records].[LotID_Lot]
		,[GestionVolume_Records].[LotID_MunicipaliteID]
		,[GestionVolume_Records].[LotID_Superficie_total]
		,[GestionVolume_Records].[LotID_Superficie_boisee]
		,[GestionVolume_Records].[LotID_ProprietaireID]
		,[GestionVolume_Records].[LotID_ContingentID]
		,[GestionVolume_Records].[LotID_Contingent_Date]
		,[GestionVolume_Records].[LotID_Droit_coupeID]
		,[GestionVolume_Records].[LotID_Droit_coupe_Date]
		,[GestionVolume_Records].[LotID_Entente_paiementID]
		,[GestionVolume_Records].[LotID_Entente_paiement_Date]
		,[GestionVolume_Records].[LotID_Actif]
		,[GestionVolume_Records].[LotID_ID]
		,[GestionVolume_Records].[LotID_Sequence]
		,[GestionVolume_Records].[LotID_Partie]
		,[GestionVolume_Records].[LotID_Matricule]
		,[GestionVolume_Records].[LotID_ZoneID]
		,[GestionVolume_Records].[LotID_Secteur]
		,[GestionVolume_Records].[LotID_Cadastre]

		From [fnGestionVolume_Full](@ID, @UsineID, @UniteMesureID, @ProducteurID, @LotID) As [GestionVolume_Records]
	End

Else

	Begin
		Select

		 [GestionVolume_Records].[ID]
		,[GestionVolume_Records].[DateLivraison]
		,[GestionVolume_Records].[UsineID]
		,[GestionVolume_Records].[UniteMesureID]
		,[GestionVolume_Records].[ProducteurID]
		,[GestionVolume_Records].[Annee]
		,[GestionVolume_Records].[Periode]
		,[GestionVolume_Records].[LotID]
		,[GestionVolume_Records].[DateEntree]
		,[GestionVolume_Records].[UsineID_ID]
		,[GestionVolume_Records].[UsineID_Description]
		,[GestionVolume_Records].[UsineID_UtilisationID]
		,[GestionVolume_Records].[UsineID_Paye_producteur]
		,[GestionVolume_Records].[UsineID_Paye_transporteur]
		,[GestionVolume_Records].[UsineID_Specification]
		,[GestionVolume_Records].[UsineID_Compte_a_recevoir]
		,[GestionVolume_Records].[UsineID_Compte_ajustement]
		,[GestionVolume_Records].[UsineID_Compte_transporteur]
		,[GestionVolume_Records].[UsineID_Compte_producteur]
		,[GestionVolume_Records].[UsineID_Compte_preleve_plan_conjoint]
		,[GestionVolume_Records].[UsineID_Compte_preleve_fond_roulement]
		,[GestionVolume_Records].[UsineID_Compte_preleve_fond_forestier]
		,[GestionVolume_Records].[UsineID_Compte_preleve_divers]
		,[GestionVolume_Records].[UsineID_Compte_mise_en_commun]
		,[GestionVolume_Records].[UsineID_Compte_surcharge]
		,[GestionVolume_Records].[UsineID_Compte_indexation_carburant]
		,[GestionVolume_Records].[UsineID_Actif]
		,[GestionVolume_Records].[UsineID_NePaiePasTPS]
		,[GestionVolume_Records].[UsineID_NePaiePasTVQ]
		,[GestionVolume_Records].[UsineID_NoTPS]
		,[GestionVolume_Records].[UsineID_NoTVQ]
		,[GestionVolume_Records].[UsineID_Compte_chargeur]
		,[GestionVolume_Records].[UsineID_UsineGestionVolume]
		,[GestionVolume_Records].[UsineID_AuSoinsDe]
		,[GestionVolume_Records].[UsineID_Rue]
		,[GestionVolume_Records].[UsineID_Ville]
		,[GestionVolume_Records].[UsineID_PaysID]
		,[GestionVolume_Records].[UsineID_Code_postal]
		,[GestionVolume_Records].[UsineID_Telephone]
		,[GestionVolume_Records].[UsineID_Telephone_Poste]
		,[GestionVolume_Records].[UsineID_Telecopieur]
		,[GestionVolume_Records].[UsineID_Telephone2]
		,[GestionVolume_Records].[UsineID_Telephone2_Desc]
		,[GestionVolume_Records].[UsineID_Telephone2_Poste]
		,[GestionVolume_Records].[UsineID_Telephone3]
		,[GestionVolume_Records].[UsineID_Telephone3_Desc]
		,[GestionVolume_Records].[UsineID_Telephone3_Poste]
		,[GestionVolume_Records].[UsineID_Email]
		,[GestionVolume_Records].[UniteMesureID_ID]
		,[GestionVolume_Records].[UniteMesureID_Description]
		,[GestionVolume_Records].[UniteMesureID_Nb_decimale]
		,[GestionVolume_Records].[UniteMesureID_Actif]
		,[GestionVolume_Records].[UniteMesureID_UseMontant]
		,[GestionVolume_Records].[UniteMesureID_Montant_Preleve_plan_conjoint]
		,[GestionVolume_Records].[UniteMesureID_Montant_Preleve_fond_roulement]
		,[GestionVolume_Records].[UniteMesureID_Montant_Preleve_fond_forestier]
		,[GestionVolume_Records].[UniteMesureID_Montant_Preleve_divers]
		,[GestionVolume_Records].[UniteMesureID_Pourc_Preleve_plan_conjoint]
		,[GestionVolume_Records].[UniteMesureID_Pourc_Preleve_fond_roulement]
		,[GestionVolume_Records].[UniteMesureID_Pourc_Preleve_fond_forestier]
		,[GestionVolume_Records].[UniteMesureID_Pourc_Preleve_divers]
		,[GestionVolume_Records].[ProducteurID_ID]
		,[GestionVolume_Records].[ProducteurID_CleTri]
		,[GestionVolume_Records].[ProducteurID_Nom]
		,[GestionVolume_Records].[ProducteurID_AuSoinsDe]
		,[GestionVolume_Records].[ProducteurID_Rue]
		,[GestionVolume_Records].[ProducteurID_Ville]
		,[GestionVolume_Records].[ProducteurID_PaysID]
		,[GestionVolume_Records].[ProducteurID_Code_postal]
		,[GestionVolume_Records].[ProducteurID_Telephone]
		,[GestionVolume_Records].[ProducteurID_Telephone_Poste]
		,[GestionVolume_Records].[ProducteurID_Telecopieur]
		,[GestionVolume_Records].[ProducteurID_Telephone2]
		,[GestionVolume_Records].[ProducteurID_Telephone2_Desc]
		,[GestionVolume_Records].[ProducteurID_Telephone2_Poste]
		,[GestionVolume_Records].[ProducteurID_Telephone3]
		,[GestionVolume_Records].[ProducteurID_Telephone3_Desc]
		,[GestionVolume_Records].[ProducteurID_Telephone3_Poste]
		,[GestionVolume_Records].[ProducteurID_No_membre]
		,[GestionVolume_Records].[ProducteurID_Resident]
		,[GestionVolume_Records].[ProducteurID_Email]
		,[GestionVolume_Records].[ProducteurID_WWW]
		,[GestionVolume_Records].[ProducteurID_Commentaires]
		,[GestionVolume_Records].[ProducteurID_AfficherCommentaires]
		,[GestionVolume_Records].[ProducteurID_DepotDirect]
		,[GestionVolume_Records].[ProducteurID_InstitutionBanquaireID]
		,[GestionVolume_Records].[ProducteurID_Banque_transit]
		,[GestionVolume_Records].[ProducteurID_Banque_folio]
		,[GestionVolume_Records].[ProducteurID_No_TPS]
		,[GestionVolume_Records].[ProducteurID_No_TVQ]
		,[GestionVolume_Records].[ProducteurID_PayerA]
		,[GestionVolume_Records].[ProducteurID_PayerAID]
		,[GestionVolume_Records].[ProducteurID_Statut]
		,[GestionVolume_Records].[ProducteurID_Rep_Nom]
		,[GestionVolume_Records].[ProducteurID_Rep_Telephone]
		,[GestionVolume_Records].[ProducteurID_Rep_Telephone_Poste]
		,[GestionVolume_Records].[ProducteurID_Rep_Email]
		,[GestionVolume_Records].[ProducteurID_EnAnglais]
		,[GestionVolume_Records].[ProducteurID_Actif]
		,[GestionVolume_Records].[ProducteurID_MRCProducteurID]
		,[GestionVolume_Records].[ProducteurID_PaiementManuel]
		,[GestionVolume_Records].[ProducteurID_Journal]
		,[GestionVolume_Records].[ProducteurID_RecoitTPS]
		,[GestionVolume_Records].[ProducteurID_RecoitTVQ]
		,[GestionVolume_Records].[ProducteurID_ModifierTrigger]
		,[GestionVolume_Records].[ProducteurID_IsProducteur]
		,[GestionVolume_Records].[ProducteurID_IsTransporteur]
		,[GestionVolume_Records].[ProducteurID_IsChargeur]
		,[GestionVolume_Records].[ProducteurID_IsAutre]
		,[GestionVolume_Records].[ProducteurID_AfficherCommentairesSurPermit]
		,[GestionVolume_Records].[ProducteurID_PasEmissionPermis]
		,[GestionVolume_Records].[ProducteurID_Generique]
		,[GestionVolume_Records].[LotID_CantonID]
		,[GestionVolume_Records].[LotID_Rang]
		,[GestionVolume_Records].[LotID_Lot]
		,[GestionVolume_Records].[LotID_MunicipaliteID]
		,[GestionVolume_Records].[LotID_Superficie_total]
		,[GestionVolume_Records].[LotID_Superficie_boisee]
		,[GestionVolume_Records].[LotID_ProprietaireID]
		,[GestionVolume_Records].[LotID_ContingentID]
		,[GestionVolume_Records].[LotID_Contingent_Date]
		,[GestionVolume_Records].[LotID_Droit_coupeID]
		,[GestionVolume_Records].[LotID_Droit_coupe_Date]
		,[GestionVolume_Records].[LotID_Entente_paiementID]
		,[GestionVolume_Records].[LotID_Entente_paiement_Date]
		,[GestionVolume_Records].[LotID_Actif]
		,[GestionVolume_Records].[LotID_ID]
		,[GestionVolume_Records].[LotID_Sequence]
		,[GestionVolume_Records].[LotID_Partie]
		,[GestionVolume_Records].[LotID_Matricule]
		,[GestionVolume_Records].[LotID_ZoneID]
		,[GestionVolume_Records].[LotID_Secteur]
		,[GestionVolume_Records].[LotID_Cadastre]

		From [fnGestionVolume_Full](@ID, @UsineID, @UniteMesureID, @ProducteurID, @LotID) As [GestionVolume_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


