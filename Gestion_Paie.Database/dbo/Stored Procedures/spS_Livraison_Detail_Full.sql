﻿

Create Procedure [spS_Livraison_Detail_Full]

/*
Retrieve specific records from the [Livraison_Detail] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Livraison] (via [LivraisonID])
	[Contrat_EssenceUnite] (via [ContratID])
	[Contrat_EssenceUnite] (via [EssenceID])
	[Contrat_EssenceUnite] (via [UniteMesureID])
	[Fournisseur] (via [ProducteurID])
	[Contingentement] (via [ContingentementID])
	[Contrat_EssenceUnite] (via [Code])
*/

(
 @ID [int] = Null -- for [Livraison_Detail].[ID] column
,@LivraisonID [int] = Null -- for [Livraison_Detail].[LivraisonID] column
,@ContratID [varchar](10) = Null -- for [Livraison_Detail].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [Livraison_Detail].[EssenceID] column
,@UniteMesureID [varchar](6) = Null -- for [Livraison_Detail].[UniteMesureID] column
,@ProducteurID [varchar](15) = Null -- for [Livraison_Detail].[ProducteurID] column
,@ContingentementID [int] = Null -- for [Livraison_Detail].[ContingentementID] column
,@Code [char](4) = Null -- for [Livraison_Detail].[Code] column
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

		 [Livraison_Detail_Records].[ID]
		,[Livraison_Detail_Records].[LivraisonID]
		,[Livraison_Detail_Records].[ContratID]
		,[Livraison_Detail_Records].[EssenceID]
		,[Livraison_Detail_Records].[UniteMesureID]
		,[Livraison_Detail_Records].[ProducteurID]
		,[Livraison_Detail_Records].[Droit_Coupe]
		,[Livraison_Detail_Records].[VolumeBrut]
		,[Livraison_Detail_Records].[VolumeReduction]
		,[Livraison_Detail_Records].[VolumeNet]
		,[Livraison_Detail_Records].[VolumeContingente]
		,[Livraison_Detail_Records].[ContingentementID]
		,[Livraison_Detail_Records].[DateCalcul]
		,[Livraison_Detail_Records].[Taux_Usine]
		,[Livraison_Detail_Records].[Montant_Usine]
		,[Livraison_Detail_Records].[Taux_Producteur]
		,[Livraison_Detail_Records].[Montant_ProducteurBrut]
		,[Livraison_Detail_Records].[Taux_TransporteurMoyen]
		,[Livraison_Detail_Records].[Taux_TransporteurMoyen_Override]
		,[Livraison_Detail_Records].[Montant_TransporteurMoyen]
		,[Livraison_Detail_Records].[Taux_Preleve_Plan_Conjoint]
		,[Livraison_Detail_Records].[Montant_Preleve_Plan_Conjoint]
		,[Livraison_Detail_Records].[Taux_Preleve_Fond_Roulement]
		,[Livraison_Detail_Records].[Montant_Preleve_Fond_Roulement]
		,[Livraison_Detail_Records].[Taux_Preleve_Fond_Forestier]
		,[Livraison_Detail_Records].[Montant_Preleve_Fond_Forestier]
		,[Livraison_Detail_Records].[Taux_Preleve_Divers]
		,[Livraison_Detail_Records].[Montant_Preleve_Divers]
		,[Livraison_Detail_Records].[Montant_ProducteurNet]
		,[Livraison_Detail_Records].[Taux_Producteur_Override]
		,[Livraison_Detail_Records].[Taux_Usine_Override]
		,[Livraison_Detail_Records].[Code]
		,[Livraison_Detail_Records].[UsePreleveMontant]
		,[Livraison_Detail_Records].[LivraisonID_ID]
		,[Livraison_Detail_Records].[LivraisonID_DateLivraison]
		,[Livraison_Detail_Records].[LivraisonID_DatePaye]
		,[Livraison_Detail_Records].[LivraisonID_ContratID]
		,[Livraison_Detail_Records].[LivraisonID_UniteMesureID]
		,[Livraison_Detail_Records].[LivraisonID_EssenceID]
		,[Livraison_Detail_Records].[LivraisonID_Sciage]
		,[Livraison_Detail_Records].[LivraisonID_NumeroFactureUsine]
		,[Livraison_Detail_Records].[LivraisonID_DroitCoupeID]
		,[Livraison_Detail_Records].[LivraisonID_EntentePaiementID]
		,[Livraison_Detail_Records].[LivraisonID_TransporteurID]
		,[Livraison_Detail_Records].[LivraisonID_VR]
		,[Livraison_Detail_Records].[LivraisonID_MasseLimite]
		,[Livraison_Detail_Records].[LivraisonID_VolumeBrut]
		,[Livraison_Detail_Records].[LivraisonID_VolumeTare]
		,[Livraison_Detail_Records].[LivraisonID_VolumeTransporte]
		,[Livraison_Detail_Records].[LivraisonID_VolumeSurcharge]
		,[Livraison_Detail_Records].[LivraisonID_VolumeAPayer]
		,[Livraison_Detail_Records].[LivraisonID_Annee]
		,[Livraison_Detail_Records].[LivraisonID_Periode]
		,[Livraison_Detail_Records].[LivraisonID_DateCalcul]
		,[Livraison_Detail_Records].[LivraisonID_Taux_Transporteur]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Transporteur]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Usine]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Producteur1]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Producteur2]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Preleve_Plan_Conjoint]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Preleve_Fond_Roulement]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Preleve_Fond_Forestier]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Preleve_Divers]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Surcharge]
		,[Livraison_Detail_Records].[LivraisonID_Montant_MiseEnCommun]
		,[Livraison_Detail_Records].[LivraisonID_Facture]
		,[Livraison_Detail_Records].[LivraisonID_Producteur1_FactureID]
		,[Livraison_Detail_Records].[LivraisonID_Producteur2_FactureID]
		,[Livraison_Detail_Records].[LivraisonID_Transporteur_FactureID]
		,[Livraison_Detail_Records].[LivraisonID_Usine_FactureID]
		,[Livraison_Detail_Records].[LivraisonID_ErreurCalcul]
		,[Livraison_Detail_Records].[LivraisonID_ErreurDescription]
		,[Livraison_Detail_Records].[LivraisonID_LotID]
		,[Livraison_Detail_Records].[LivraisonID_Taux_Transporteur_Override]
		,[Livraison_Detail_Records].[LivraisonID_PaieTransporteur]
		,[Livraison_Detail_Records].[LivraisonID_VolumeSurcharge_Override]
		,[Livraison_Detail_Records].[LivraisonID_SurchargeManuel]
		,[Livraison_Detail_Records].[LivraisonID_Code]
		,[Livraison_Detail_Records].[LivraisonID_NombrePermis]
		,[Livraison_Detail_Records].[LivraisonID_ZoneID]
		,[Livraison_Detail_Records].[LivraisonID_MunicipaliteID]
		,[Livraison_Detail_Records].[LivraisonID_ChargeurID]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Chargeur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_ChargeurAuProducteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_ChargeurAuTransporteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresAuProducteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresAuProducteurDescription]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresAuTransporteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresAuTransporteurDescription]
		,[Livraison_Detail_Records].[LivraisonID_Frais_CompensationDeDeplacement]
		,[Livraison_Detail_Records].[LivraisonID_Chargeur_FactureID]
		,[Livraison_Detail_Records].[LivraisonID_Commentaires_Producteur]
		,[Livraison_Detail_Records].[LivraisonID_Commentaires_Transporteur]
		,[Livraison_Detail_Records].[LivraisonID_Commentaires_Chargeur]
		,[Livraison_Detail_Records].[LivraisonID_TauxChargeurAuProducteur]
		,[Livraison_Detail_Records].[LivraisonID_TauxChargeurAuTransporteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresRevenusTransporteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresRevenusTransporteurDescription]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresRevenusProducteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresRevenusProducteurDescription]
		,[Livraison_Detail_Records].[LivraisonID_Montant_SurchargeProducteur]
		,[Livraison_Detail_Records].[ContratID_ContratID]
		,[Livraison_Detail_Records].[ContratID_EssenceID]
		,[Livraison_Detail_Records].[ContratID_UniteID]
		,[Livraison_Detail_Records].[ContratID_Code]
		,[Livraison_Detail_Records].[ContratID_Quantite_prevue]
		,[Livraison_Detail_Records].[ContratID_Taux_usine]
		,[Livraison_Detail_Records].[ContratID_Taux_producteur]
		,[Livraison_Detail_Records].[ContratID_Actif]
		,[Livraison_Detail_Records].[ContratID_Description]
		,[Livraison_Detail_Records].[EssenceID_ContratID]
		,[Livraison_Detail_Records].[EssenceID_EssenceID]
		,[Livraison_Detail_Records].[EssenceID_UniteID]
		,[Livraison_Detail_Records].[EssenceID_Code]
		,[Livraison_Detail_Records].[EssenceID_Quantite_prevue]
		,[Livraison_Detail_Records].[EssenceID_Taux_usine]
		,[Livraison_Detail_Records].[EssenceID_Taux_producteur]
		,[Livraison_Detail_Records].[EssenceID_Actif]
		,[Livraison_Detail_Records].[EssenceID_Description]
		,[Livraison_Detail_Records].[UniteMesureID_ContratID]
		,[Livraison_Detail_Records].[UniteMesureID_EssenceID]
		,[Livraison_Detail_Records].[UniteMesureID_UniteID]
		,[Livraison_Detail_Records].[UniteMesureID_Code]
		,[Livraison_Detail_Records].[UniteMesureID_Quantite_prevue]
		,[Livraison_Detail_Records].[UniteMesureID_Taux_usine]
		,[Livraison_Detail_Records].[UniteMesureID_Taux_producteur]
		,[Livraison_Detail_Records].[UniteMesureID_Actif]
		,[Livraison_Detail_Records].[UniteMesureID_Description]
		,[Livraison_Detail_Records].[ProducteurID_ID]
		,[Livraison_Detail_Records].[ProducteurID_CleTri]
		,[Livraison_Detail_Records].[ProducteurID_Nom]
		,[Livraison_Detail_Records].[ProducteurID_AuSoinsDe]
		,[Livraison_Detail_Records].[ProducteurID_Rue]
		,[Livraison_Detail_Records].[ProducteurID_Ville]
		,[Livraison_Detail_Records].[ProducteurID_PaysID]
		,[Livraison_Detail_Records].[ProducteurID_Code_postal]
		,[Livraison_Detail_Records].[ProducteurID_Telephone]
		,[Livraison_Detail_Records].[ProducteurID_Telephone_Poste]
		,[Livraison_Detail_Records].[ProducteurID_Telecopieur]
		,[Livraison_Detail_Records].[ProducteurID_Telephone2]
		,[Livraison_Detail_Records].[ProducteurID_Telephone2_Desc]
		,[Livraison_Detail_Records].[ProducteurID_Telephone2_Poste]
		,[Livraison_Detail_Records].[ProducteurID_Telephone3]
		,[Livraison_Detail_Records].[ProducteurID_Telephone3_Desc]
		,[Livraison_Detail_Records].[ProducteurID_Telephone3_Poste]
		,[Livraison_Detail_Records].[ProducteurID_No_membre]
		,[Livraison_Detail_Records].[ProducteurID_Resident]
		,[Livraison_Detail_Records].[ProducteurID_Email]
		,[Livraison_Detail_Records].[ProducteurID_WWW]
		,[Livraison_Detail_Records].[ProducteurID_Commentaires]
		,[Livraison_Detail_Records].[ProducteurID_AfficherCommentaires]
		,[Livraison_Detail_Records].[ProducteurID_DepotDirect]
		,[Livraison_Detail_Records].[ProducteurID_InstitutionBanquaireID]
		,[Livraison_Detail_Records].[ProducteurID_Banque_transit]
		,[Livraison_Detail_Records].[ProducteurID_Banque_folio]
		,[Livraison_Detail_Records].[ProducteurID_No_TPS]
		,[Livraison_Detail_Records].[ProducteurID_No_TVQ]
		,[Livraison_Detail_Records].[ProducteurID_PayerA]
		,[Livraison_Detail_Records].[ProducteurID_PayerAID]
		,[Livraison_Detail_Records].[ProducteurID_Statut]
		,[Livraison_Detail_Records].[ProducteurID_Rep_Nom]
		,[Livraison_Detail_Records].[ProducteurID_Rep_Telephone]
		,[Livraison_Detail_Records].[ProducteurID_Rep_Telephone_Poste]
		,[Livraison_Detail_Records].[ProducteurID_Rep_Email]
		,[Livraison_Detail_Records].[ProducteurID_EnAnglais]
		,[Livraison_Detail_Records].[ProducteurID_Actif]
		,[Livraison_Detail_Records].[ProducteurID_MRCProducteurID]
		,[Livraison_Detail_Records].[ProducteurID_PaiementManuel]
		,[Livraison_Detail_Records].[ProducteurID_Journal]
		,[Livraison_Detail_Records].[ProducteurID_RecoitTPS]
		,[Livraison_Detail_Records].[ProducteurID_RecoitTVQ]
		,[Livraison_Detail_Records].[ProducteurID_ModifierTrigger]
		,[Livraison_Detail_Records].[ProducteurID_IsProducteur]
		,[Livraison_Detail_Records].[ProducteurID_IsTransporteur]
		,[Livraison_Detail_Records].[ProducteurID_IsChargeur]
		,[Livraison_Detail_Records].[ProducteurID_IsAutre]
		,[Livraison_Detail_Records].[ProducteurID_AfficherCommentairesSurPermit]
		,[Livraison_Detail_Records].[ProducteurID_PasEmissionPermis]
		,[Livraison_Detail_Records].[ProducteurID_Generique]
		,[Livraison_Detail_Records].[ContingentementID_ID]
		,[Livraison_Detail_Records].[ContingentementID_ContingentUsine]
		,[Livraison_Detail_Records].[ContingentementID_UsineID]
		,[Livraison_Detail_Records].[ContingentementID_RegroupementID]
		,[Livraison_Detail_Records].[ContingentementID_Annee]
		,[Livraison_Detail_Records].[ContingentementID_PeriodeContingentement]
		,[Livraison_Detail_Records].[ContingentementID_PeriodeDebut]
		,[Livraison_Detail_Records].[ContingentementID_PeriodeFin]
		,[Livraison_Detail_Records].[ContingentementID_EssenceID]
		,[Livraison_Detail_Records].[ContingentementID_UniteMesureID]
		,[Livraison_Detail_Records].[ContingentementID_Volume_Usine]
		,[Livraison_Detail_Records].[ContingentementID_Facteur]
		,[Livraison_Detail_Records].[ContingentementID_Volume_Fixe]
		,[Livraison_Detail_Records].[ContingentementID_Date_Calcul]
		,[Livraison_Detail_Records].[ContingentementID_CalculAccepte]
		,[Livraison_Detail_Records].[ContingentementID_Code]
		,[Livraison_Detail_Records].[Code_ContratID]
		,[Livraison_Detail_Records].[Code_EssenceID]
		,[Livraison_Detail_Records].[Code_UniteID]
		,[Livraison_Detail_Records].[Code_Code]
		,[Livraison_Detail_Records].[Code_Quantite_prevue]
		,[Livraison_Detail_Records].[Code_Taux_usine]
		,[Livraison_Detail_Records].[Code_Taux_producteur]
		,[Livraison_Detail_Records].[Code_Actif]
		,[Livraison_Detail_Records].[Code_Description]

		From [fnLivraison_Detail_Full](@ID, @LivraisonID, @ContratID, @EssenceID, @UniteMesureID, @ProducteurID, @ContingentementID, @Code) As [Livraison_Detail_Records]
	End

Else

	Begin
		Select

		 [Livraison_Detail_Records].[ID]
		,[Livraison_Detail_Records].[LivraisonID]
		,[Livraison_Detail_Records].[ContratID]
		,[Livraison_Detail_Records].[EssenceID]
		,[Livraison_Detail_Records].[UniteMesureID]
		,[Livraison_Detail_Records].[ProducteurID]
		,[Livraison_Detail_Records].[Droit_Coupe]
		,[Livraison_Detail_Records].[VolumeBrut]
		,[Livraison_Detail_Records].[VolumeReduction]
		,[Livraison_Detail_Records].[VolumeNet]
		,[Livraison_Detail_Records].[VolumeContingente]
		,[Livraison_Detail_Records].[ContingentementID]
		,[Livraison_Detail_Records].[DateCalcul]
		,[Livraison_Detail_Records].[Taux_Usine]
		,[Livraison_Detail_Records].[Montant_Usine]
		,[Livraison_Detail_Records].[Taux_Producteur]
		,[Livraison_Detail_Records].[Montant_ProducteurBrut]
		,[Livraison_Detail_Records].[Taux_TransporteurMoyen]
		,[Livraison_Detail_Records].[Taux_TransporteurMoyen_Override]
		,[Livraison_Detail_Records].[Montant_TransporteurMoyen]
		,[Livraison_Detail_Records].[Taux_Preleve_Plan_Conjoint]
		,[Livraison_Detail_Records].[Montant_Preleve_Plan_Conjoint]
		,[Livraison_Detail_Records].[Taux_Preleve_Fond_Roulement]
		,[Livraison_Detail_Records].[Montant_Preleve_Fond_Roulement]
		,[Livraison_Detail_Records].[Taux_Preleve_Fond_Forestier]
		,[Livraison_Detail_Records].[Montant_Preleve_Fond_Forestier]
		,[Livraison_Detail_Records].[Taux_Preleve_Divers]
		,[Livraison_Detail_Records].[Montant_Preleve_Divers]
		,[Livraison_Detail_Records].[Montant_ProducteurNet]
		,[Livraison_Detail_Records].[Taux_Producteur_Override]
		,[Livraison_Detail_Records].[Taux_Usine_Override]
		,[Livraison_Detail_Records].[Code]
		,[Livraison_Detail_Records].[UsePreleveMontant]
		,[Livraison_Detail_Records].[LivraisonID_ID]
		,[Livraison_Detail_Records].[LivraisonID_DateLivraison]
		,[Livraison_Detail_Records].[LivraisonID_DatePaye]
		,[Livraison_Detail_Records].[LivraisonID_ContratID]
		,[Livraison_Detail_Records].[LivraisonID_UniteMesureID]
		,[Livraison_Detail_Records].[LivraisonID_EssenceID]
		,[Livraison_Detail_Records].[LivraisonID_Sciage]
		,[Livraison_Detail_Records].[LivraisonID_NumeroFactureUsine]
		,[Livraison_Detail_Records].[LivraisonID_DroitCoupeID]
		,[Livraison_Detail_Records].[LivraisonID_EntentePaiementID]
		,[Livraison_Detail_Records].[LivraisonID_TransporteurID]
		,[Livraison_Detail_Records].[LivraisonID_VR]
		,[Livraison_Detail_Records].[LivraisonID_MasseLimite]
		,[Livraison_Detail_Records].[LivraisonID_VolumeBrut]
		,[Livraison_Detail_Records].[LivraisonID_VolumeTare]
		,[Livraison_Detail_Records].[LivraisonID_VolumeTransporte]
		,[Livraison_Detail_Records].[LivraisonID_VolumeSurcharge]
		,[Livraison_Detail_Records].[LivraisonID_VolumeAPayer]
		,[Livraison_Detail_Records].[LivraisonID_Annee]
		,[Livraison_Detail_Records].[LivraisonID_Periode]
		,[Livraison_Detail_Records].[LivraisonID_DateCalcul]
		,[Livraison_Detail_Records].[LivraisonID_Taux_Transporteur]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Transporteur]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Usine]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Producteur1]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Producteur2]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Preleve_Plan_Conjoint]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Preleve_Fond_Roulement]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Preleve_Fond_Forestier]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Preleve_Divers]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Surcharge]
		,[Livraison_Detail_Records].[LivraisonID_Montant_MiseEnCommun]
		,[Livraison_Detail_Records].[LivraisonID_Facture]
		,[Livraison_Detail_Records].[LivraisonID_Producteur1_FactureID]
		,[Livraison_Detail_Records].[LivraisonID_Producteur2_FactureID]
		,[Livraison_Detail_Records].[LivraisonID_Transporteur_FactureID]
		,[Livraison_Detail_Records].[LivraisonID_Usine_FactureID]
		,[Livraison_Detail_Records].[LivraisonID_ErreurCalcul]
		,[Livraison_Detail_Records].[LivraisonID_ErreurDescription]
		,[Livraison_Detail_Records].[LivraisonID_LotID]
		,[Livraison_Detail_Records].[LivraisonID_Taux_Transporteur_Override]
		,[Livraison_Detail_Records].[LivraisonID_PaieTransporteur]
		,[Livraison_Detail_Records].[LivraisonID_VolumeSurcharge_Override]
		,[Livraison_Detail_Records].[LivraisonID_SurchargeManuel]
		,[Livraison_Detail_Records].[LivraisonID_Code]
		,[Livraison_Detail_Records].[LivraisonID_NombrePermis]
		,[Livraison_Detail_Records].[LivraisonID_ZoneID]
		,[Livraison_Detail_Records].[LivraisonID_MunicipaliteID]
		,[Livraison_Detail_Records].[LivraisonID_ChargeurID]
		,[Livraison_Detail_Records].[LivraisonID_Montant_Chargeur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_ChargeurAuProducteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_ChargeurAuTransporteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresAuProducteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresAuProducteurDescription]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresAuTransporteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresAuTransporteurDescription]
		,[Livraison_Detail_Records].[LivraisonID_Frais_CompensationDeDeplacement]
		,[Livraison_Detail_Records].[LivraisonID_Chargeur_FactureID]
		,[Livraison_Detail_Records].[LivraisonID_Commentaires_Producteur]
		,[Livraison_Detail_Records].[LivraisonID_Commentaires_Transporteur]
		,[Livraison_Detail_Records].[LivraisonID_Commentaires_Chargeur]
		,[Livraison_Detail_Records].[LivraisonID_TauxChargeurAuProducteur]
		,[Livraison_Detail_Records].[LivraisonID_TauxChargeurAuTransporteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresRevenusTransporteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresRevenusTransporteurDescription]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresRevenusProducteur]
		,[Livraison_Detail_Records].[LivraisonID_Frais_AutresRevenusProducteurDescription]
		,[Livraison_Detail_Records].[LivraisonID_Montant_SurchargeProducteur]
		,[Livraison_Detail_Records].[ContratID_ContratID]
		,[Livraison_Detail_Records].[ContratID_EssenceID]
		,[Livraison_Detail_Records].[ContratID_UniteID]
		,[Livraison_Detail_Records].[ContratID_Code]
		,[Livraison_Detail_Records].[ContratID_Quantite_prevue]
		,[Livraison_Detail_Records].[ContratID_Taux_usine]
		,[Livraison_Detail_Records].[ContratID_Taux_producteur]
		,[Livraison_Detail_Records].[ContratID_Actif]
		,[Livraison_Detail_Records].[ContratID_Description]
		,[Livraison_Detail_Records].[EssenceID_ContratID]
		,[Livraison_Detail_Records].[EssenceID_EssenceID]
		,[Livraison_Detail_Records].[EssenceID_UniteID]
		,[Livraison_Detail_Records].[EssenceID_Code]
		,[Livraison_Detail_Records].[EssenceID_Quantite_prevue]
		,[Livraison_Detail_Records].[EssenceID_Taux_usine]
		,[Livraison_Detail_Records].[EssenceID_Taux_producteur]
		,[Livraison_Detail_Records].[EssenceID_Actif]
		,[Livraison_Detail_Records].[EssenceID_Description]
		,[Livraison_Detail_Records].[UniteMesureID_ContratID]
		,[Livraison_Detail_Records].[UniteMesureID_EssenceID]
		,[Livraison_Detail_Records].[UniteMesureID_UniteID]
		,[Livraison_Detail_Records].[UniteMesureID_Code]
		,[Livraison_Detail_Records].[UniteMesureID_Quantite_prevue]
		,[Livraison_Detail_Records].[UniteMesureID_Taux_usine]
		,[Livraison_Detail_Records].[UniteMesureID_Taux_producteur]
		,[Livraison_Detail_Records].[UniteMesureID_Actif]
		,[Livraison_Detail_Records].[UniteMesureID_Description]
		,[Livraison_Detail_Records].[ProducteurID_ID]
		,[Livraison_Detail_Records].[ProducteurID_CleTri]
		,[Livraison_Detail_Records].[ProducteurID_Nom]
		,[Livraison_Detail_Records].[ProducteurID_AuSoinsDe]
		,[Livraison_Detail_Records].[ProducteurID_Rue]
		,[Livraison_Detail_Records].[ProducteurID_Ville]
		,[Livraison_Detail_Records].[ProducteurID_PaysID]
		,[Livraison_Detail_Records].[ProducteurID_Code_postal]
		,[Livraison_Detail_Records].[ProducteurID_Telephone]
		,[Livraison_Detail_Records].[ProducteurID_Telephone_Poste]
		,[Livraison_Detail_Records].[ProducteurID_Telecopieur]
		,[Livraison_Detail_Records].[ProducteurID_Telephone2]
		,[Livraison_Detail_Records].[ProducteurID_Telephone2_Desc]
		,[Livraison_Detail_Records].[ProducteurID_Telephone2_Poste]
		,[Livraison_Detail_Records].[ProducteurID_Telephone3]
		,[Livraison_Detail_Records].[ProducteurID_Telephone3_Desc]
		,[Livraison_Detail_Records].[ProducteurID_Telephone3_Poste]
		,[Livraison_Detail_Records].[ProducteurID_No_membre]
		,[Livraison_Detail_Records].[ProducteurID_Resident]
		,[Livraison_Detail_Records].[ProducteurID_Email]
		,[Livraison_Detail_Records].[ProducteurID_WWW]
		,[Livraison_Detail_Records].[ProducteurID_Commentaires]
		,[Livraison_Detail_Records].[ProducteurID_AfficherCommentaires]
		,[Livraison_Detail_Records].[ProducteurID_DepotDirect]
		,[Livraison_Detail_Records].[ProducteurID_InstitutionBanquaireID]
		,[Livraison_Detail_Records].[ProducteurID_Banque_transit]
		,[Livraison_Detail_Records].[ProducteurID_Banque_folio]
		,[Livraison_Detail_Records].[ProducteurID_No_TPS]
		,[Livraison_Detail_Records].[ProducteurID_No_TVQ]
		,[Livraison_Detail_Records].[ProducteurID_PayerA]
		,[Livraison_Detail_Records].[ProducteurID_PayerAID]
		,[Livraison_Detail_Records].[ProducteurID_Statut]
		,[Livraison_Detail_Records].[ProducteurID_Rep_Nom]
		,[Livraison_Detail_Records].[ProducteurID_Rep_Telephone]
		,[Livraison_Detail_Records].[ProducteurID_Rep_Telephone_Poste]
		,[Livraison_Detail_Records].[ProducteurID_Rep_Email]
		,[Livraison_Detail_Records].[ProducteurID_EnAnglais]
		,[Livraison_Detail_Records].[ProducteurID_Actif]
		,[Livraison_Detail_Records].[ProducteurID_MRCProducteurID]
		,[Livraison_Detail_Records].[ProducteurID_PaiementManuel]
		,[Livraison_Detail_Records].[ProducteurID_Journal]
		,[Livraison_Detail_Records].[ProducteurID_RecoitTPS]
		,[Livraison_Detail_Records].[ProducteurID_RecoitTVQ]
		,[Livraison_Detail_Records].[ProducteurID_ModifierTrigger]
		,[Livraison_Detail_Records].[ProducteurID_IsProducteur]
		,[Livraison_Detail_Records].[ProducteurID_IsTransporteur]
		,[Livraison_Detail_Records].[ProducteurID_IsChargeur]
		,[Livraison_Detail_Records].[ProducteurID_IsAutre]
		,[Livraison_Detail_Records].[ProducteurID_AfficherCommentairesSurPermit]
		,[Livraison_Detail_Records].[ProducteurID_PasEmissionPermis]
		,[Livraison_Detail_Records].[ProducteurID_Generique]
		,[Livraison_Detail_Records].[ContingentementID_ID]
		,[Livraison_Detail_Records].[ContingentementID_ContingentUsine]
		,[Livraison_Detail_Records].[ContingentementID_UsineID]
		,[Livraison_Detail_Records].[ContingentementID_RegroupementID]
		,[Livraison_Detail_Records].[ContingentementID_Annee]
		,[Livraison_Detail_Records].[ContingentementID_PeriodeContingentement]
		,[Livraison_Detail_Records].[ContingentementID_PeriodeDebut]
		,[Livraison_Detail_Records].[ContingentementID_PeriodeFin]
		,[Livraison_Detail_Records].[ContingentementID_EssenceID]
		,[Livraison_Detail_Records].[ContingentementID_UniteMesureID]
		,[Livraison_Detail_Records].[ContingentementID_Volume_Usine]
		,[Livraison_Detail_Records].[ContingentementID_Facteur]
		,[Livraison_Detail_Records].[ContingentementID_Volume_Fixe]
		,[Livraison_Detail_Records].[ContingentementID_Date_Calcul]
		,[Livraison_Detail_Records].[ContingentementID_CalculAccepte]
		,[Livraison_Detail_Records].[ContingentementID_Code]
		,[Livraison_Detail_Records].[Code_ContratID]
		,[Livraison_Detail_Records].[Code_EssenceID]
		,[Livraison_Detail_Records].[Code_UniteID]
		,[Livraison_Detail_Records].[Code_Code]
		,[Livraison_Detail_Records].[Code_Quantite_prevue]
		,[Livraison_Detail_Records].[Code_Taux_usine]
		,[Livraison_Detail_Records].[Code_Taux_producteur]
		,[Livraison_Detail_Records].[Code_Actif]
		,[Livraison_Detail_Records].[Code_Description]

		From [fnLivraison_Detail_Full](@ID, @LivraisonID, @ContratID, @EssenceID, @UniteMesureID, @ProducteurID, @ContingentementID, @Code) As [Livraison_Detail_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


