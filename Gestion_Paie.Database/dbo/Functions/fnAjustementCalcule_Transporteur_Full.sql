﻿CREATE FUNCTION [dbo].[fnAjustementCalcule_Transporteur_Full]
(@ID INT=Null, @AjustementID INT=Null, @UniteID VARCHAR (6)=Null, @MunicipaliteID VARCHAR (6)=Null, @LivraisonID INT=Null, @TransporteurID VARCHAR (15)=Null, @FactureID INT=Null, @ZoneID VARCHAR (2)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [AjustementCalcule_Transporteur].[ID]
,[AjustementCalcule_Transporteur].[DateCalcul]
,[AjustementCalcule_Transporteur].[AjustementID]
,[AjustementCalcule_Transporteur].[UniteID]
,[AjustementCalcule_Transporteur].[MunicipaliteID]
,[AjustementCalcule_Transporteur].[LivraisonID]
,[AjustementCalcule_Transporteur].[TransporteurID]
,[AjustementCalcule_Transporteur].[Volume]
,[AjustementCalcule_Transporteur].[Taux]
,[AjustementCalcule_Transporteur].[Montant]
,[AjustementCalcule_Transporteur].[Facture]
,[AjustementCalcule_Transporteur].[FactureID]
,[AjustementCalcule_Transporteur].[ErreurCalcul]
,[AjustementCalcule_Transporteur].[ErreurDescription]
,[AjustementCalcule_Transporteur].[ZoneID]
,[Ajustement_Transporteur1].[AjustementID] [AjustementID_AjustementID]
,[Ajustement_Transporteur1].[UniteID] [AjustementID_UniteID]
,[Ajustement_Transporteur1].[MunicipaliteID] [AjustementID_MunicipaliteID]
,[Ajustement_Transporteur1].[ContratID] [AjustementID_ContratID]
,[Ajustement_Transporteur1].[Taux_transporteur] [AjustementID_Taux_transporteur]
,[Ajustement_Transporteur1].[Date_Modification] [AjustementID_Date_Modification]
,[Ajustement_Transporteur1].[ZoneID] [AjustementID_ZoneID]
,[Ajustement_Transporteur2].[AjustementID] [UniteID_AjustementID]
,[Ajustement_Transporteur2].[UniteID] [UniteID_UniteID]
,[Ajustement_Transporteur2].[MunicipaliteID] [UniteID_MunicipaliteID]
,[Ajustement_Transporteur2].[ContratID] [UniteID_ContratID]
,[Ajustement_Transporteur2].[Taux_transporteur] [UniteID_Taux_transporteur]
,[Ajustement_Transporteur2].[Date_Modification] [UniteID_Date_Modification]
,[Ajustement_Transporteur2].[ZoneID] [UniteID_ZoneID]
,[Ajustement_Transporteur3].[AjustementID] [MunicipaliteID_AjustementID]
,[Ajustement_Transporteur3].[UniteID] [MunicipaliteID_UniteID]
,[Ajustement_Transporteur3].[MunicipaliteID] [MunicipaliteID_MunicipaliteID]
,[Ajustement_Transporteur3].[ContratID] [MunicipaliteID_ContratID]
,[Ajustement_Transporteur3].[Taux_transporteur] [MunicipaliteID_Taux_transporteur]
,[Ajustement_Transporteur3].[Date_Modification] [MunicipaliteID_Date_Modification]
,[Ajustement_Transporteur3].[ZoneID] [MunicipaliteID_ZoneID]
,[Livraison4].[ID] [LivraisonID_ID]
,[Livraison4].[DateLivraison] [LivraisonID_DateLivraison]
,[Livraison4].[DatePaye] [LivraisonID_DatePaye]
,[Livraison4].[ContratID] [LivraisonID_ContratID]
,[Livraison4].[UniteMesureID] [LivraisonID_UniteMesureID]
,[Livraison4].[EssenceID] [LivraisonID_EssenceID]
,[Livraison4].[Sciage] [LivraisonID_Sciage]
,[Livraison4].[NumeroFactureUsine] [LivraisonID_NumeroFactureUsine]
,[Livraison4].[DroitCoupeID] [LivraisonID_DroitCoupeID]
,[Livraison4].[EntentePaiementID] [LivraisonID_EntentePaiementID]
,[Livraison4].[TransporteurID] [LivraisonID_TransporteurID]
,[Livraison4].[VR] [LivraisonID_VR]
,[Livraison4].[MasseLimite] [LivraisonID_MasseLimite]
,[Livraison4].[VolumeBrut] [LivraisonID_VolumeBrut]
,[Livraison4].[VolumeTare] [LivraisonID_VolumeTare]
,[Livraison4].[VolumeTransporte] [LivraisonID_VolumeTransporte]
,[Livraison4].[VolumeSurcharge] [LivraisonID_VolumeSurcharge]
,[Livraison4].[VolumeAPayer] [LivraisonID_VolumeAPayer]
,[Livraison4].[Annee] [LivraisonID_Annee]
,[Livraison4].[Periode] [LivraisonID_Periode]
,[Livraison4].[DateCalcul] [LivraisonID_DateCalcul]
,[Livraison4].[Taux_Transporteur] [LivraisonID_Taux_Transporteur]
,[Livraison4].[Montant_Transporteur] [LivraisonID_Montant_Transporteur]
,[Livraison4].[Montant_Usine] [LivraisonID_Montant_Usine]
,[Livraison4].[Montant_Producteur1] [LivraisonID_Montant_Producteur1]
,[Livraison4].[Montant_Producteur2] [LivraisonID_Montant_Producteur2]
,[Livraison4].[Montant_Preleve_Plan_Conjoint] [LivraisonID_Montant_Preleve_Plan_Conjoint]
,[Livraison4].[Montant_Preleve_Fond_Roulement] [LivraisonID_Montant_Preleve_Fond_Roulement]
,[Livraison4].[Montant_Preleve_Fond_Forestier] [LivraisonID_Montant_Preleve_Fond_Forestier]
,[Livraison4].[Montant_Preleve_Divers] [LivraisonID_Montant_Preleve_Divers]
,[Livraison4].[Montant_Surcharge] [LivraisonID_Montant_Surcharge]
,[Livraison4].[Montant_MiseEnCommun] [LivraisonID_Montant_MiseEnCommun]
,[Livraison4].[Facture] [LivraisonID_Facture]
,[Livraison4].[Producteur1_FactureID] [LivraisonID_Producteur1_FactureID]
,[Livraison4].[Producteur2_FactureID] [LivraisonID_Producteur2_FactureID]
,[Livraison4].[Transporteur_FactureID] [LivraisonID_Transporteur_FactureID]
,[Livraison4].[Usine_FactureID] [LivraisonID_Usine_FactureID]
,[Livraison4].[ErreurCalcul] [LivraisonID_ErreurCalcul]
,[Livraison4].[ErreurDescription] [LivraisonID_ErreurDescription]
,[Livraison4].[LotID] [LivraisonID_LotID]
,[Livraison4].[Taux_Transporteur_Override] [LivraisonID_Taux_Transporteur_Override]
,[Livraison4].[PaieTransporteur] [LivraisonID_PaieTransporteur]
,[Livraison4].[VolumeSurcharge_Override] [LivraisonID_VolumeSurcharge_Override]
,[Livraison4].[SurchargeManuel] [LivraisonID_SurchargeManuel]
,[Livraison4].[Code] [LivraisonID_Code]
,[Livraison4].[NombrePermis] [LivraisonID_NombrePermis]
,[Livraison4].[ZoneID] [LivraisonID_ZoneID]
,[Livraison4].[MunicipaliteID] [LivraisonID_MunicipaliteID]
,[Livraison4].[ChargeurID] [LivraisonID_ChargeurID]
,[Livraison4].[Montant_Chargeur] [LivraisonID_Montant_Chargeur]
,[Livraison4].[Frais_ChargeurAuProducteur] [LivraisonID_Frais_ChargeurAuProducteur]
,[Livraison4].[Frais_ChargeurAuTransporteur] [LivraisonID_Frais_ChargeurAuTransporteur]
,[Livraison4].[Frais_AutresAuProducteur] [LivraisonID_Frais_AutresAuProducteur]
,[Livraison4].[Frais_AutresAuProducteurDescription] [LivraisonID_Frais_AutresAuProducteurDescription]
,[Livraison4].[Frais_AutresAuTransporteur] [LivraisonID_Frais_AutresAuTransporteur]
,[Livraison4].[Frais_AutresAuTransporteurDescription] [LivraisonID_Frais_AutresAuTransporteurDescription]
,[Livraison4].[Frais_CompensationDeDeplacement] [LivraisonID_Frais_CompensationDeDeplacement]
,[Livraison4].[Chargeur_FactureID] [LivraisonID_Chargeur_FactureID]
,[Livraison4].[Commentaires_Producteur] [LivraisonID_Commentaires_Producteur]
,[Livraison4].[Commentaires_Transporteur] [LivraisonID_Commentaires_Transporteur]
,[Livraison4].[Commentaires_Chargeur] [LivraisonID_Commentaires_Chargeur]
,[Livraison4].[TauxChargeurAuProducteur] [LivraisonID_TauxChargeurAuProducteur]
,[Livraison4].[TauxChargeurAuTransporteur] [LivraisonID_TauxChargeurAuTransporteur]
,[Livraison4].[Frais_AutresRevenusTransporteur] [LivraisonID_Frais_AutresRevenusTransporteur]
,[Livraison4].[Frais_AutresRevenusTransporteurDescription] [LivraisonID_Frais_AutresRevenusTransporteurDescription]
,[Livraison4].[Frais_AutresRevenusProducteur] [LivraisonID_Frais_AutresRevenusProducteur]
,[Livraison4].[Frais_AutresRevenusProducteurDescription] [LivraisonID_Frais_AutresRevenusProducteurDescription]
,[Livraison4].[Montant_SurchargeProducteur] [LivraisonID_Montant_SurchargeProducteur]
,[Fournisseur5].[ID] [TransporteurID_ID]
,[Fournisseur5].[CleTri] [TransporteurID_CleTri]
,[Fournisseur5].[Nom] [TransporteurID_Nom]
,[Fournisseur5].[AuSoinsDe] [TransporteurID_AuSoinsDe]
,[Fournisseur5].[Rue] [TransporteurID_Rue]
,[Fournisseur5].[Ville] [TransporteurID_Ville]
,[Fournisseur5].[PaysID] [TransporteurID_PaysID]
,[Fournisseur5].[Code_postal] [TransporteurID_Code_postal]
,[Fournisseur5].[Telephone] [TransporteurID_Telephone]
,[Fournisseur5].[Telephone_Poste] [TransporteurID_Telephone_Poste]
,[Fournisseur5].[Telecopieur] [TransporteurID_Telecopieur]
,[Fournisseur5].[Telephone2] [TransporteurID_Telephone2]
,[Fournisseur5].[Telephone2_Desc] [TransporteurID_Telephone2_Desc]
,[Fournisseur5].[Telephone2_Poste] [TransporteurID_Telephone2_Poste]
,[Fournisseur5].[Telephone3] [TransporteurID_Telephone3]
,[Fournisseur5].[Telephone3_Desc] [TransporteurID_Telephone3_Desc]
,[Fournisseur5].[Telephone3_Poste] [TransporteurID_Telephone3_Poste]
,[Fournisseur5].[No_membre] [TransporteurID_No_membre]
,[Fournisseur5].[Resident] [TransporteurID_Resident]
,[Fournisseur5].[Email] [TransporteurID_Email]
,[Fournisseur5].[WWW] [TransporteurID_WWW]
,[Fournisseur5].[Commentaires] [TransporteurID_Commentaires]
,[Fournisseur5].[AfficherCommentaires] [TransporteurID_AfficherCommentaires]
,[Fournisseur5].[DepotDirect] [TransporteurID_DepotDirect]
,[Fournisseur5].[InstitutionBanquaireID] [TransporteurID_InstitutionBanquaireID]
,[Fournisseur5].[Banque_transit] [TransporteurID_Banque_transit]
,[Fournisseur5].[Banque_folio] [TransporteurID_Banque_folio]
,[Fournisseur5].[No_TPS] [TransporteurID_No_TPS]
,[Fournisseur5].[No_TVQ] [TransporteurID_No_TVQ]
,[Fournisseur5].[PayerA] [TransporteurID_PayerA]
,[Fournisseur5].[PayerAID] [TransporteurID_PayerAID]
,[Fournisseur5].[Statut] [TransporteurID_Statut]
,[Fournisseur5].[Rep_Nom] [TransporteurID_Rep_Nom]
,[Fournisseur5].[Rep_Telephone] [TransporteurID_Rep_Telephone]
,[Fournisseur5].[Rep_Telephone_Poste] [TransporteurID_Rep_Telephone_Poste]
,[Fournisseur5].[Rep_Email] [TransporteurID_Rep_Email]
,[Fournisseur5].[EnAnglais] [TransporteurID_EnAnglais]
,[Fournisseur5].[Actif] [TransporteurID_Actif]
,[Fournisseur5].[MRCProducteurID] [TransporteurID_MRCProducteurID]
,[Fournisseur5].[PaiementManuel] [TransporteurID_PaiementManuel]
,[Fournisseur5].[Journal] [TransporteurID_Journal]
,[Fournisseur5].[RecoitTPS] [TransporteurID_RecoitTPS]
,[Fournisseur5].[RecoitTVQ] [TransporteurID_RecoitTVQ]
,[Fournisseur5].[ModifierTrigger] [TransporteurID_ModifierTrigger]
,[Fournisseur5].[IsProducteur] [TransporteurID_IsProducteur]
,[Fournisseur5].[IsTransporteur] [TransporteurID_IsTransporteur]
,[Fournisseur5].[IsChargeur] [TransporteurID_IsChargeur]
,[Fournisseur5].[IsAutre] [TransporteurID_IsAutre]
,[Fournisseur5].[AfficherCommentairesSurPermit] [TransporteurID_AfficherCommentairesSurPermit]
,[Fournisseur5].[PasEmissionPermis] [TransporteurID_PasEmissionPermis]
,[Fournisseur5].[Generique] [TransporteurID_Generique]
,[FactureFournisseur6].[ID] [FactureID_ID]
,[FactureFournisseur6].[NoFacture] [FactureID_NoFacture]
,[FactureFournisseur6].[DateFacture] [FactureID_DateFacture]
,[FactureFournisseur6].[Annee] [FactureID_Annee]
,[FactureFournisseur6].[TypeFactureFournisseur] [FactureID_TypeFactureFournisseur]
,[FactureFournisseur6].[TypeFacture] [FactureID_TypeFacture]
,[FactureFournisseur6].[TypeInvoiceAcomba] [FactureID_TypeInvoiceAcomba]
,[FactureFournisseur6].[FournisseurID] [FactureID_FournisseurID]
,[FactureFournisseur6].[PayerAID] [FactureID_PayerAID]
,[FactureFournisseur6].[Montant_Total] [FactureID_Montant_Total]
,[FactureFournisseur6].[Montant_TPS] [FactureID_Montant_TPS]
,[FactureFournisseur6].[Montant_TVQ] [FactureID_Montant_TVQ]
,[FactureFournisseur6].[Description] [FactureID_Description]
,[FactureFournisseur6].[Status] [FactureID_Status]
,[FactureFournisseur6].[StatusDescription] [FactureID_StatusDescription]
,[FactureFournisseur6].[NumeroCheque] [FactureID_NumeroCheque]
,[FactureFournisseur6].[NumeroPaiement] [FactureID_NumeroPaiement]
,[FactureFournisseur6].[NumeroPaiementUnique] [FactureID_NumeroPaiementUnique]
,[FactureFournisseur6].[DateFactureAcomba] [FactureID_DateFactureAcomba]
,[FactureFournisseur6].[DatePaiementAcomba] [FactureID_DatePaiementAcomba]
,[Ajustement_Transporteur7].[AjustementID] [ZoneID_AjustementID]
,[Ajustement_Transporteur7].[UniteID] [ZoneID_UniteID]
,[Ajustement_Transporteur7].[MunicipaliteID] [ZoneID_MunicipaliteID]
,[Ajustement_Transporteur7].[ContratID] [ZoneID_ContratID]
,[Ajustement_Transporteur7].[Taux_transporteur] [ZoneID_Taux_transporteur]
,[Ajustement_Transporteur7].[Date_Modification] [ZoneID_Date_Modification]
,[Ajustement_Transporteur7].[ZoneID] [ZoneID_ZoneID]

From [dbo].[AjustementCalcule_Transporteur] [AjustementCalcule_Transporteur]
    Left Outer Join [dbo].[Ajustement_Transporteur] [Ajustement_Transporteur1] On [AjustementCalcule_Transporteur].[AjustementID] = [Ajustement_Transporteur1].[AjustementID]
        Left Outer Join [dbo].[Ajustement_Transporteur] [Ajustement_Transporteur2] On [AjustementCalcule_Transporteur].[UniteID] = [Ajustement_Transporteur2].[UniteID]
            Left Outer Join [dbo].[Ajustement_Transporteur] [Ajustement_Transporteur3] On [AjustementCalcule_Transporteur].[MunicipaliteID] = [Ajustement_Transporteur3].[MunicipaliteID]
                Left Outer Join [dbo].[Livraison] [Livraison4] On [AjustementCalcule_Transporteur].[LivraisonID] = [Livraison4].[ID]
                    Left Outer Join [dbo].[Fournisseur] [Fournisseur5] On [AjustementCalcule_Transporteur].[TransporteurID] = [Fournisseur5].[ID]
                        Left Outer Join [dbo].[FactureFournisseur] [FactureFournisseur6] On [AjustementCalcule_Transporteur].[FactureID] = [FactureFournisseur6].[ID]
                            Left Outer Join [dbo].[Ajustement_Transporteur] [Ajustement_Transporteur7] On [AjustementCalcule_Transporteur].[ZoneID] = [Ajustement_Transporteur7].[ZoneID]

Where

    ((@ID Is Null) Or ([AjustementCalcule_Transporteur].[ID] = @ID))
And ((@AjustementID Is Null) Or ([AjustementCalcule_Transporteur].[AjustementID] = @AjustementID))
And ((@UniteID Is Null) Or ([AjustementCalcule_Transporteur].[UniteID] = @UniteID))
And ((@MunicipaliteID Is Null) Or ([AjustementCalcule_Transporteur].[MunicipaliteID] = @MunicipaliteID))
And ((@LivraisonID Is Null) Or ([AjustementCalcule_Transporteur].[LivraisonID] = @LivraisonID))
And ((@TransporteurID Is Null) Or ([AjustementCalcule_Transporteur].[TransporteurID] = @TransporteurID))
And ((@FactureID Is Null) Or ([AjustementCalcule_Transporteur].[FactureID] = @FactureID))
And ((@ZoneID Is Null) Or ([AjustementCalcule_Transporteur].[ZoneID] = @ZoneID))
)


