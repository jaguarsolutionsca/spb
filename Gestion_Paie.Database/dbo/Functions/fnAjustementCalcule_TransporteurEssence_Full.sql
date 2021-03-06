﻿Create Function [dbo].[fnAjustementCalcule_TransporteurEssence_Full]

(
 @ID [int] = Null
,@AjustementID [int] = Null
,@EssenceID [varchar](6) = Null
,@UniteID [varchar](6) = Null
,@LivraisonDetailID [int] = Null
,@TransporteurID [varchar](15) = Null
,@FactureID [int] = Null
,@Code [char](4) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
 [AjustementCalcule_TransporteurEssence].[ID]
,[AjustementCalcule_TransporteurEssence].[DateCalcul]
,[AjustementCalcule_TransporteurEssence].[AjustementID]
,[AjustementCalcule_TransporteurEssence].[EssenceID]
,[AjustementCalcule_TransporteurEssence].[UniteID]
,[AjustementCalcule_TransporteurEssence].[LivraisonDetailID]
,[AjustementCalcule_TransporteurEssence].[TransporteurID]
,[AjustementCalcule_TransporteurEssence].[Volume]
,[AjustementCalcule_TransporteurEssence].[Taux]
,[AjustementCalcule_TransporteurEssence].[Montant]
,[AjustementCalcule_TransporteurEssence].[Facture]
,[AjustementCalcule_TransporteurEssence].[FactureID]
,[AjustementCalcule_TransporteurEssence].[ErreurCalcul]
,[AjustementCalcule_TransporteurEssence].[ErreurDescription]
,[AjustementCalcule_TransporteurEssence].[Code]
,[Ajustement_EssenceUnite1].[AjustementID] [AjustementID_AjustementID]
,[Ajustement_EssenceUnite1].[EssenceID] [AjustementID_EssenceID]
,[Ajustement_EssenceUnite1].[UniteID] [AjustementID_UniteID]
,[Ajustement_EssenceUnite1].[ContratID] [AjustementID_ContratID]
,[Ajustement_EssenceUnite1].[Taux_usine] [AjustementID_Taux_usine]
,[Ajustement_EssenceUnite1].[Taux_producteur] [AjustementID_Taux_producteur]
,[Ajustement_EssenceUnite1].[Taux_transporteur] [AjustementID_Taux_transporteur]
,[Ajustement_EssenceUnite1].[Date_Modification] [AjustementID_Date_Modification]
,[Ajustement_EssenceUnite1].[Code] [AjustementID_Code]
,[Ajustement_EssenceUnite2].[AjustementID] [EssenceID_AjustementID]
,[Ajustement_EssenceUnite2].[EssenceID] [EssenceID_EssenceID]
,[Ajustement_EssenceUnite2].[UniteID] [EssenceID_UniteID]
,[Ajustement_EssenceUnite2].[ContratID] [EssenceID_ContratID]
,[Ajustement_EssenceUnite2].[Taux_usine] [EssenceID_Taux_usine]
,[Ajustement_EssenceUnite2].[Taux_producteur] [EssenceID_Taux_producteur]
,[Ajustement_EssenceUnite2].[Taux_transporteur] [EssenceID_Taux_transporteur]
,[Ajustement_EssenceUnite2].[Date_Modification] [EssenceID_Date_Modification]
,[Ajustement_EssenceUnite2].[Code] [EssenceID_Code]
,[Ajustement_EssenceUnite3].[AjustementID] [UniteID_AjustementID]
,[Ajustement_EssenceUnite3].[EssenceID] [UniteID_EssenceID]
,[Ajustement_EssenceUnite3].[UniteID] [UniteID_UniteID]
,[Ajustement_EssenceUnite3].[ContratID] [UniteID_ContratID]
,[Ajustement_EssenceUnite3].[Taux_usine] [UniteID_Taux_usine]
,[Ajustement_EssenceUnite3].[Taux_producteur] [UniteID_Taux_producteur]
,[Ajustement_EssenceUnite3].[Taux_transporteur] [UniteID_Taux_transporteur]
,[Ajustement_EssenceUnite3].[Date_Modification] [UniteID_Date_Modification]
,[Ajustement_EssenceUnite3].[Code] [UniteID_Code]
,[Livraison_Detail4].[ID] [LivraisonDetailID_ID]
,[Livraison_Detail4].[LivraisonID] [LivraisonDetailID_LivraisonID]
,[Livraison_Detail4].[ContratID] [LivraisonDetailID_ContratID]
,[Livraison_Detail4].[EssenceID] [LivraisonDetailID_EssenceID]
,[Livraison_Detail4].[UniteMesureID] [LivraisonDetailID_UniteMesureID]
,[Livraison_Detail4].[ProducteurID] [LivraisonDetailID_ProducteurID]
,[Livraison_Detail4].[Droit_Coupe] [LivraisonDetailID_Droit_Coupe]
,[Livraison_Detail4].[VolumeBrut] [LivraisonDetailID_VolumeBrut]
,[Livraison_Detail4].[VolumeReduction] [LivraisonDetailID_VolumeReduction]
,[Livraison_Detail4].[VolumeNet] [LivraisonDetailID_VolumeNet]
,[Livraison_Detail4].[VolumeContingente] [LivraisonDetailID_VolumeContingente]
,[Livraison_Detail4].[ContingentementID] [LivraisonDetailID_ContingentementID]
,[Livraison_Detail4].[DateCalcul] [LivraisonDetailID_DateCalcul]
,[Livraison_Detail4].[Taux_Usine] [LivraisonDetailID_Taux_Usine]
,[Livraison_Detail4].[Montant_Usine] [LivraisonDetailID_Montant_Usine]
,[Livraison_Detail4].[Taux_Producteur] [LivraisonDetailID_Taux_Producteur]
,[Livraison_Detail4].[Montant_ProducteurBrut] [LivraisonDetailID_Montant_ProducteurBrut]
,[Livraison_Detail4].[Taux_TransporteurMoyen] [LivraisonDetailID_Taux_TransporteurMoyen]
,[Livraison_Detail4].[Taux_TransporteurMoyen_Override] [LivraisonDetailID_Taux_TransporteurMoyen_Override]
,[Livraison_Detail4].[Montant_TransporteurMoyen] [LivraisonDetailID_Montant_TransporteurMoyen]
,[Livraison_Detail4].[Taux_Preleve_Plan_Conjoint] [LivraisonDetailID_Taux_Preleve_Plan_Conjoint]
,[Livraison_Detail4].[Montant_Preleve_Plan_Conjoint] [LivraisonDetailID_Montant_Preleve_Plan_Conjoint]
,[Livraison_Detail4].[Taux_Preleve_Fond_Roulement] [LivraisonDetailID_Taux_Preleve_Fond_Roulement]
,[Livraison_Detail4].[Montant_Preleve_Fond_Roulement] [LivraisonDetailID_Montant_Preleve_Fond_Roulement]
,[Livraison_Detail4].[Taux_Preleve_Fond_Forestier] [LivraisonDetailID_Taux_Preleve_Fond_Forestier]
,[Livraison_Detail4].[Montant_Preleve_Fond_Forestier] [LivraisonDetailID_Montant_Preleve_Fond_Forestier]
,[Livraison_Detail4].[Taux_Preleve_Divers] [LivraisonDetailID_Taux_Preleve_Divers]
,[Livraison_Detail4].[Montant_Preleve_Divers] [LivraisonDetailID_Montant_Preleve_Divers]
,[Livraison_Detail4].[Montant_ProducteurNet] [LivraisonDetailID_Montant_ProducteurNet]
,[Livraison_Detail4].[Taux_Producteur_Override] [LivraisonDetailID_Taux_Producteur_Override]
,[Livraison_Detail4].[Taux_Usine_Override] [LivraisonDetailID_Taux_Usine_Override]
,[Livraison_Detail4].[Code] [LivraisonDetailID_Code]
,[Livraison_Detail4].[UsePreleveMontant] [LivraisonDetailID_UsePreleveMontant]
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
,[Fournisseur5].[Membre_OGC] [TransporteurID_Membre_OGC]
,[Fournisseur5].[InscritTPS] [TransporteurID_InscritTPS]
,[Fournisseur5].[InscritTVQ] [TransporteurID_InscritTVQ]
,[Fournisseur5].[IsOGC] [TransporteurID_IsOGC]
,[Fournisseur5].[Rep2_Nom] [TransporteurID_Rep2_Nom]
,[Fournisseur5].[Rep2_Telephone] [TransporteurID_Rep2_Telephone]
,[Fournisseur5].[Rep2_Telephone_Poste] [TransporteurID_Rep2_Telephone_Poste]
,[Fournisseur5].[Rep2_Email] [TransporteurID_Rep2_Email]
,[Fournisseur5].[Rep2_Commentaires] [TransporteurID_Rep2_Commentaires]
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
,[Ajustement_EssenceUnite7].[AjustementID] [Code_AjustementID]
,[Ajustement_EssenceUnite7].[EssenceID] [Code_EssenceID]
,[Ajustement_EssenceUnite7].[UniteID] [Code_UniteID]
,[Ajustement_EssenceUnite7].[ContratID] [Code_ContratID]
,[Ajustement_EssenceUnite7].[Taux_usine] [Code_Taux_usine]
,[Ajustement_EssenceUnite7].[Taux_producteur] [Code_Taux_producteur]
,[Ajustement_EssenceUnite7].[Taux_transporteur] [Code_Taux_transporteur]
,[Ajustement_EssenceUnite7].[Date_Modification] [Code_Date_Modification]
,[Ajustement_EssenceUnite7].[Code] [Code_Code]

From [dbo].[AjustementCalcule_TransporteurEssence] [AjustementCalcule_TransporteurEssence]
    Left Outer Join [dbo].[Ajustement_EssenceUnite] [Ajustement_EssenceUnite1] On [AjustementCalcule_TransporteurEssence].[AjustementID] = [Ajustement_EssenceUnite1].[AjustementID]
        Left Outer Join [dbo].[Ajustement_EssenceUnite] [Ajustement_EssenceUnite2] On [AjustementCalcule_TransporteurEssence].[EssenceID] = [Ajustement_EssenceUnite2].[EssenceID]
            Left Outer Join [dbo].[Ajustement_EssenceUnite] [Ajustement_EssenceUnite3] On [AjustementCalcule_TransporteurEssence].[UniteID] = [Ajustement_EssenceUnite3].[UniteID]
                Left Outer Join [dbo].[Livraison_Detail] [Livraison_Detail4] On [AjustementCalcule_TransporteurEssence].[LivraisonDetailID] = [Livraison_Detail4].[ID]
                    Left Outer Join [dbo].[Fournisseur] [Fournisseur5] On [AjustementCalcule_TransporteurEssence].[TransporteurID] = [Fournisseur5].[ID]
                        Left Outer Join [dbo].[FactureFournisseur] [FactureFournisseur6] On [AjustementCalcule_TransporteurEssence].[FactureID] = [FactureFournisseur6].[ID]
                            Left Outer Join [dbo].[Ajustement_EssenceUnite] [Ajustement_EssenceUnite7] On [AjustementCalcule_TransporteurEssence].[Code] = [Ajustement_EssenceUnite7].[Code]

Where

    ((@ID Is Null) Or ([AjustementCalcule_TransporteurEssence].[ID] = @ID))
And ((@AjustementID Is Null) Or ([AjustementCalcule_TransporteurEssence].[AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([AjustementCalcule_TransporteurEssence].[EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([AjustementCalcule_TransporteurEssence].[UniteID] = @UniteID))
And ((@LivraisonDetailID Is Null) Or ([AjustementCalcule_TransporteurEssence].[LivraisonDetailID] = @LivraisonDetailID))
And ((@TransporteurID Is Null) Or ([AjustementCalcule_TransporteurEssence].[TransporteurID] = @TransporteurID))
And ((@FactureID Is Null) Or ([AjustementCalcule_TransporteurEssence].[FactureID] = @FactureID))
And ((@Code Is Null) Or ([AjustementCalcule_TransporteurEssence].[Code] = @Code))
)
