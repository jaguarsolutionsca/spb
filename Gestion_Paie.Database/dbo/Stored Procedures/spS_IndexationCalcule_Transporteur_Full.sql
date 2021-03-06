﻿

Create Procedure [spS_IndexationCalcule_Transporteur_Full]

/*
Retrieve specific records from the [IndexationCalcule_Transporteur] table, as well as all its foreign tables, depending on the input parameters you supply:
	[TypeIndexation] (via [TypeIndexation])
	[Indexation] (via [IndexationID])
	[Indexation_Municipalite] (via [IndexationDetailID])
	[Livraison] (via [LivraisonID])
	[Fournisseur] (via [TransporteurID])
	[FactureFournisseur] (via [FactureID])
*/

(
 @ID [int] = Null -- for [IndexationCalcule_Transporteur].[ID] column
,@TypeIndexation [char](1) = Null -- for [IndexationCalcule_Transporteur].[TypeIndexation] column
,@IndexationID [int] = Null -- for [IndexationCalcule_Transporteur].[IndexationID] column
,@IndexationDetailID [int] = Null -- for [IndexationCalcule_Transporteur].[IndexationDetailID] column
,@LivraisonID [int] = Null -- for [IndexationCalcule_Transporteur].[LivraisonID] column
,@TransporteurID [varchar](15) = Null -- for [IndexationCalcule_Transporteur].[TransporteurID] column
,@FactureID [int] = Null -- for [IndexationCalcule_Transporteur].[FactureID] column
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

		 [IndexationCalcule_Transporteur_Records].[ID]
		,[IndexationCalcule_Transporteur_Records].[DateCalcul]
		,[IndexationCalcule_Transporteur_Records].[TypeIndexation]
		,[IndexationCalcule_Transporteur_Records].[IndexationID]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID]
		,[IndexationCalcule_Transporteur_Records].[MontantDejaPaye]
		,[IndexationCalcule_Transporteur_Records].[PourcentageDuMontant]
		,[IndexationCalcule_Transporteur_Records].[Montant]
		,[IndexationCalcule_Transporteur_Records].[Facture]
		,[IndexationCalcule_Transporteur_Records].[FactureID]
		,[IndexationCalcule_Transporteur_Records].[ErreurCalcul]
		,[IndexationCalcule_Transporteur_Records].[ErreurDescription]
		,[IndexationCalcule_Transporteur_Records].[TypeIndexation_ID]
		,[IndexationCalcule_Transporteur_Records].[TypeIndexation_Description]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_ID]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_DateIndexation]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_ContratID]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_Periode_Debut]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_Periode_Fin]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_TypeIndexation]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_PourcentageDuMontant]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_Facture]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_IndexationTransporteur]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_Date_Debut]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_Date_Fin]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_IndexationManuelle]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID_ID]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID_IndexationID]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID_MunicipaliteID]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID_Montant]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID_ZoneID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_ID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_DateLivraison]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_DatePaye]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_ContratID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_UniteMesureID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_EssenceID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Sciage]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_NumeroFactureUsine]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_DroitCoupeID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_EntentePaiementID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_TransporteurID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VR]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_MasseLimite]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VolumeBrut]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VolumeTare]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VolumeTransporte]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VolumeSurcharge]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VolumeAPayer]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Annee]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Periode]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_DateCalcul]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Taux_Transporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Transporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Usine]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Producteur1]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Producteur2]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Preleve_Plan_Conjoint]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Preleve_Fond_Roulement]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Preleve_Fond_Forestier]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Preleve_Divers]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Surcharge]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_MiseEnCommun]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Facture]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Producteur1_FactureID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Producteur2_FactureID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Transporteur_FactureID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Usine_FactureID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_ErreurCalcul]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_ErreurDescription]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_LotID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Taux_Transporteur_Override]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_PaieTransporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VolumeSurcharge_Override]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_SurchargeManuel]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Code]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_NombrePermis]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_ZoneID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_MunicipaliteID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_ChargeurID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Chargeur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_ChargeurAuProducteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_ChargeurAuTransporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresAuProducteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresAuProducteurDescription]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresAuTransporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresAuTransporteurDescription]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_CompensationDeDeplacement]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Chargeur_FactureID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Commentaires_Producteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Commentaires_Transporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Commentaires_Chargeur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_TauxChargeurAuProducteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_TauxChargeurAuTransporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresRevenusTransporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresRevenusTransporteurDescription]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresRevenusProducteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresRevenusProducteurDescription]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_SurchargeProducteur]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_ID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_CleTri]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Nom]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_AuSoinsDe]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Rue]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Ville]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_PaysID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Code_postal]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone_Poste]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telecopieur]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone2]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone2_Desc]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone2_Poste]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone3]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone3_Desc]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone3_Poste]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_No_membre]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Resident]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Email]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_WWW]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Commentaires]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_AfficherCommentaires]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_DepotDirect]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_InstitutionBanquaireID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Banque_transit]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Banque_folio]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_No_TPS]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_No_TVQ]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_PayerA]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_PayerAID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Statut]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Rep_Nom]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Rep_Telephone]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Rep_Telephone_Poste]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Rep_Email]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_EnAnglais]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Actif]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_MRCProducteurID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_PaiementManuel]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Journal]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_RecoitTPS]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_RecoitTVQ]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_ModifierTrigger]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_IsProducteur]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_IsTransporteur]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_IsChargeur]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_IsAutre]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_AfficherCommentairesSurPermit]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_PasEmissionPermis]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Generique]
		,[IndexationCalcule_Transporteur_Records].[FactureID_ID]
		,[IndexationCalcule_Transporteur_Records].[FactureID_NoFacture]
		,[IndexationCalcule_Transporteur_Records].[FactureID_DateFacture]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Annee]
		,[IndexationCalcule_Transporteur_Records].[FactureID_TypeFactureFournisseur]
		,[IndexationCalcule_Transporteur_Records].[FactureID_TypeFacture]
		,[IndexationCalcule_Transporteur_Records].[FactureID_TypeInvoiceAcomba]
		,[IndexationCalcule_Transporteur_Records].[FactureID_FournisseurID]
		,[IndexationCalcule_Transporteur_Records].[FactureID_PayerAID]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Montant_Total]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Montant_TPS]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Montant_TVQ]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Description]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Status]
		,[IndexationCalcule_Transporteur_Records].[FactureID_StatusDescription]
		,[IndexationCalcule_Transporteur_Records].[FactureID_NumeroCheque]
		,[IndexationCalcule_Transporteur_Records].[FactureID_NumeroPaiement]
		,[IndexationCalcule_Transporteur_Records].[FactureID_NumeroPaiementUnique]
		,[IndexationCalcule_Transporteur_Records].[FactureID_DateFactureAcomba]
		,[IndexationCalcule_Transporteur_Records].[FactureID_DatePaiementAcomba]

		From [fnIndexationCalcule_Transporteur_Full](@ID, @TypeIndexation, @IndexationID, @IndexationDetailID, @LivraisonID, @TransporteurID, @FactureID) As [IndexationCalcule_Transporteur_Records]
	End

Else

	Begin
		Select

		 [IndexationCalcule_Transporteur_Records].[ID]
		,[IndexationCalcule_Transporteur_Records].[DateCalcul]
		,[IndexationCalcule_Transporteur_Records].[TypeIndexation]
		,[IndexationCalcule_Transporteur_Records].[IndexationID]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID]
		,[IndexationCalcule_Transporteur_Records].[MontantDejaPaye]
		,[IndexationCalcule_Transporteur_Records].[PourcentageDuMontant]
		,[IndexationCalcule_Transporteur_Records].[Montant]
		,[IndexationCalcule_Transporteur_Records].[Facture]
		,[IndexationCalcule_Transporteur_Records].[FactureID]
		,[IndexationCalcule_Transporteur_Records].[ErreurCalcul]
		,[IndexationCalcule_Transporteur_Records].[ErreurDescription]
		,[IndexationCalcule_Transporteur_Records].[TypeIndexation_ID]
		,[IndexationCalcule_Transporteur_Records].[TypeIndexation_Description]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_ID]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_DateIndexation]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_ContratID]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_Periode_Debut]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_Periode_Fin]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_TypeIndexation]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_PourcentageDuMontant]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_Facture]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_IndexationTransporteur]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_Date_Debut]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_Date_Fin]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_IndexationManuelle]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID_ID]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID_IndexationID]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID_MunicipaliteID]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID_Montant]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID_ZoneID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_ID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_DateLivraison]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_DatePaye]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_ContratID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_UniteMesureID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_EssenceID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Sciage]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_NumeroFactureUsine]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_DroitCoupeID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_EntentePaiementID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_TransporteurID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VR]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_MasseLimite]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VolumeBrut]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VolumeTare]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VolumeTransporte]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VolumeSurcharge]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VolumeAPayer]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Annee]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Periode]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_DateCalcul]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Taux_Transporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Transporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Usine]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Producteur1]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Producteur2]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Preleve_Plan_Conjoint]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Preleve_Fond_Roulement]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Preleve_Fond_Forestier]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Preleve_Divers]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Surcharge]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_MiseEnCommun]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Facture]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Producteur1_FactureID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Producteur2_FactureID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Transporteur_FactureID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Usine_FactureID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_ErreurCalcul]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_ErreurDescription]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_LotID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Taux_Transporteur_Override]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_PaieTransporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_VolumeSurcharge_Override]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_SurchargeManuel]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Code]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_NombrePermis]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_ZoneID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_MunicipaliteID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_ChargeurID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_Chargeur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_ChargeurAuProducteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_ChargeurAuTransporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresAuProducteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresAuProducteurDescription]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresAuTransporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresAuTransporteurDescription]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_CompensationDeDeplacement]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Chargeur_FactureID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Commentaires_Producteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Commentaires_Transporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Commentaires_Chargeur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_TauxChargeurAuProducteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_TauxChargeurAuTransporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresRevenusTransporteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresRevenusTransporteurDescription]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresRevenusProducteur]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Frais_AutresRevenusProducteurDescription]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Montant_SurchargeProducteur]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_ID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_CleTri]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Nom]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_AuSoinsDe]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Rue]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Ville]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_PaysID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Code_postal]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone_Poste]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telecopieur]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone2]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone2_Desc]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone2_Poste]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone3]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone3_Desc]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Telephone3_Poste]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_No_membre]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Resident]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Email]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_WWW]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Commentaires]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_AfficherCommentaires]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_DepotDirect]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_InstitutionBanquaireID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Banque_transit]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Banque_folio]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_No_TPS]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_No_TVQ]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_PayerA]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_PayerAID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Statut]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Rep_Nom]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Rep_Telephone]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Rep_Telephone_Poste]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Rep_Email]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_EnAnglais]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Actif]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_MRCProducteurID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_PaiementManuel]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Journal]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_RecoitTPS]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_RecoitTVQ]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_ModifierTrigger]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_IsProducteur]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_IsTransporteur]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_IsChargeur]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_IsAutre]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_AfficherCommentairesSurPermit]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_PasEmissionPermis]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Generique]
		,[IndexationCalcule_Transporteur_Records].[FactureID_ID]
		,[IndexationCalcule_Transporteur_Records].[FactureID_NoFacture]
		,[IndexationCalcule_Transporteur_Records].[FactureID_DateFacture]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Annee]
		,[IndexationCalcule_Transporteur_Records].[FactureID_TypeFactureFournisseur]
		,[IndexationCalcule_Transporteur_Records].[FactureID_TypeFacture]
		,[IndexationCalcule_Transporteur_Records].[FactureID_TypeInvoiceAcomba]
		,[IndexationCalcule_Transporteur_Records].[FactureID_FournisseurID]
		,[IndexationCalcule_Transporteur_Records].[FactureID_PayerAID]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Montant_Total]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Montant_TPS]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Montant_TVQ]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Description]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Status]
		,[IndexationCalcule_Transporteur_Records].[FactureID_StatusDescription]
		,[IndexationCalcule_Transporteur_Records].[FactureID_NumeroCheque]
		,[IndexationCalcule_Transporteur_Records].[FactureID_NumeroPaiement]
		,[IndexationCalcule_Transporteur_Records].[FactureID_NumeroPaiementUnique]
		,[IndexationCalcule_Transporteur_Records].[FactureID_DateFactureAcomba]
		,[IndexationCalcule_Transporteur_Records].[FactureID_DatePaiementAcomba]

		From [fnIndexationCalcule_Transporteur_Full](@ID, @TypeIndexation, @IndexationID, @IndexationDetailID, @LivraisonID, @TransporteurID, @FactureID) As [IndexationCalcule_Transporteur_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


