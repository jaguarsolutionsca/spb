

Create Function [fnAjustementCalcule_Usine_Full]

(
 @ID [int] = Null
,@AjustementID [int] = Null
,@EssenceID [varchar](6) = Null
,@UniteID [varchar](6) = Null
,@LivraisonDetailID [int] = Null
,@UsineID [varchar](6) = Null
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
Select TOP 100 PERCENT
 [AjustementCalcule_Usine].[ID]
,[AjustementCalcule_Usine].[DateCalcul]
,[AjustementCalcule_Usine].[AjustementID]
,[AjustementCalcule_Usine].[EssenceID]
,[AjustementCalcule_Usine].[UniteID]
,[AjustementCalcule_Usine].[LivraisonDetailID]
,[AjustementCalcule_Usine].[UsineID]
,[AjustementCalcule_Usine].[Volume]
,[AjustementCalcule_Usine].[Taux]
,[AjustementCalcule_Usine].[Montant]
,[AjustementCalcule_Usine].[Facture]
,[AjustementCalcule_Usine].[FactureID]
,[AjustementCalcule_Usine].[ErreurCalcul]
,[AjustementCalcule_Usine].[ErreurDescription]
,[AjustementCalcule_Usine].[Code]
,[Ajustement_EssenceUnite1].[AjustementID] [AjustementID_AjustementID]
,[Ajustement_EssenceUnite1].[EssenceID] [AjustementID_EssenceID]
,[Ajustement_EssenceUnite1].[UniteID] [AjustementID_UniteID]
,[Ajustement_EssenceUnite1].[ContratID] [AjustementID_ContratID]
,[Ajustement_EssenceUnite1].[Taux_usine] [AjustementID_Taux_usine]
,[Ajustement_EssenceUnite1].[Taux_producteur] [AjustementID_Taux_producteur]
,[Ajustement_EssenceUnite1].[Date_Modification] [AjustementID_Date_Modification]
,[Ajustement_EssenceUnite1].[Code] [AjustementID_Code]
,[Ajustement_EssenceUnite2].[AjustementID] [EssenceID_AjustementID]
,[Ajustement_EssenceUnite2].[EssenceID] [EssenceID_EssenceID]
,[Ajustement_EssenceUnite2].[UniteID] [EssenceID_UniteID]
,[Ajustement_EssenceUnite2].[ContratID] [EssenceID_ContratID]
,[Ajustement_EssenceUnite2].[Taux_usine] [EssenceID_Taux_usine]
,[Ajustement_EssenceUnite2].[Taux_producteur] [EssenceID_Taux_producteur]
,[Ajustement_EssenceUnite2].[Date_Modification] [EssenceID_Date_Modification]
,[Ajustement_EssenceUnite2].[Code] [EssenceID_Code]
,[Ajustement_EssenceUnite3].[AjustementID] [UniteID_AjustementID]
,[Ajustement_EssenceUnite3].[EssenceID] [UniteID_EssenceID]
,[Ajustement_EssenceUnite3].[UniteID] [UniteID_UniteID]
,[Ajustement_EssenceUnite3].[ContratID] [UniteID_ContratID]
,[Ajustement_EssenceUnite3].[Taux_usine] [UniteID_Taux_usine]
,[Ajustement_EssenceUnite3].[Taux_producteur] [UniteID_Taux_producteur]
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
,[Usine5].[ID] [UsineID_ID]
,[Usine5].[Description] [UsineID_Description]
,[Usine5].[UtilisationID] [UsineID_UtilisationID]
,[Usine5].[Paye_producteur] [UsineID_Paye_producteur]
,[Usine5].[Paye_transporteur] [UsineID_Paye_transporteur]
,[Usine5].[Specification] [UsineID_Specification]
,[Usine5].[Compte_a_recevoir] [UsineID_Compte_a_recevoir]
,[Usine5].[Compte_ajustement] [UsineID_Compte_ajustement]
,[Usine5].[Compte_transporteur] [UsineID_Compte_transporteur]
,[Usine5].[Compte_producteur] [UsineID_Compte_producteur]
,[Usine5].[Compte_preleve_plan_conjoint] [UsineID_Compte_preleve_plan_conjoint]
,[Usine5].[Compte_preleve_fond_roulement] [UsineID_Compte_preleve_fond_roulement]
,[Usine5].[Compte_preleve_fond_forestier] [UsineID_Compte_preleve_fond_forestier]
,[Usine5].[Compte_preleve_divers] [UsineID_Compte_preleve_divers]
,[Usine5].[Compte_mise_en_commun] [UsineID_Compte_mise_en_commun]
,[Usine5].[Compte_surcharge] [UsineID_Compte_surcharge]
,[Usine5].[Compte_indexation_carburant] [UsineID_Compte_indexation_carburant]
,[Usine5].[Actif] [UsineID_Actif]
,[Usine5].[NePaiePasTPS] [UsineID_NePaiePasTPS]
,[Usine5].[NePaiePasTVQ] [UsineID_NePaiePasTVQ]
,[Usine5].[NoTPS] [UsineID_NoTPS]
,[Usine5].[NoTVQ] [UsineID_NoTVQ]
,[Usine5].[Compte_chargeur] [UsineID_Compte_chargeur]
,[Usine5].[UsineGestionVolume] [UsineID_UsineGestionVolume]
,[Usine5].[AuSoinsDe] [UsineID_AuSoinsDe]
,[Usine5].[Rue] [UsineID_Rue]
,[Usine5].[Ville] [UsineID_Ville]
,[Usine5].[PaysID] [UsineID_PaysID]
,[Usine5].[Code_postal] [UsineID_Code_postal]
,[Usine5].[Telephone] [UsineID_Telephone]
,[Usine5].[Telephone_Poste] [UsineID_Telephone_Poste]
,[Usine5].[Telecopieur] [UsineID_Telecopieur]
,[Usine5].[Telephone2] [UsineID_Telephone2]
,[Usine5].[Telephone2_Desc] [UsineID_Telephone2_Desc]
,[Usine5].[Telephone2_Poste] [UsineID_Telephone2_Poste]
,[Usine5].[Telephone3] [UsineID_Telephone3]
,[Usine5].[Telephone3_Desc] [UsineID_Telephone3_Desc]
,[Usine5].[Telephone3_Poste] [UsineID_Telephone3_Poste]
,[Usine5].[Email] [UsineID_Email]
,[FactureClient6].[ID] [FactureID_ID]
,[FactureClient6].[NoFacture] [FactureID_NoFacture]
,[FactureClient6].[DateFacture] [FactureID_DateFacture]
,[FactureClient6].[Annee] [FactureID_Annee]
,[FactureClient6].[TypeFacture] [FactureID_TypeFacture]
,[FactureClient6].[TypeInvoiceClientAcomba] [FactureID_TypeInvoiceClientAcomba]
,[FactureClient6].[ClientID] [FactureID_ClientID]
,[FactureClient6].[PayerAID] [FactureID_PayerAID]
,[FactureClient6].[Montant_Total] [FactureID_Montant_Total]
,[FactureClient6].[Montant_TPS] [FactureID_Montant_TPS]
,[FactureClient6].[Montant_TVQ] [FactureID_Montant_TVQ]
,[FactureClient6].[Description] [FactureID_Description]
,[FactureClient6].[Status] [FactureID_Status]
,[FactureClient6].[StatusDescription] [FactureID_StatusDescription]
,[FactureClient6].[DateFactureAcomba] [FactureID_DateFactureAcomba]
,[Ajustement_EssenceUnite7].[AjustementID] [Code_AjustementID]
,[Ajustement_EssenceUnite7].[EssenceID] [Code_EssenceID]
,[Ajustement_EssenceUnite7].[UniteID] [Code_UniteID]
,[Ajustement_EssenceUnite7].[ContratID] [Code_ContratID]
,[Ajustement_EssenceUnite7].[Taux_usine] [Code_Taux_usine]
,[Ajustement_EssenceUnite7].[Taux_producteur] [Code_Taux_producteur]
,[Ajustement_EssenceUnite7].[Date_Modification] [Code_Date_Modification]
,[Ajustement_EssenceUnite7].[Code] [Code_Code]

From [dbo].[AjustementCalcule_Usine] [AjustementCalcule_Usine]
    Left Outer Join [dbo].[Ajustement_EssenceUnite] [Ajustement_EssenceUnite1] On [AjustementCalcule_Usine].[AjustementID] = [Ajustement_EssenceUnite1].[AjustementID]
        Left Outer Join [dbo].[Ajustement_EssenceUnite] [Ajustement_EssenceUnite2] On [AjustementCalcule_Usine].[EssenceID] = [Ajustement_EssenceUnite2].[EssenceID]
            Left Outer Join [dbo].[Ajustement_EssenceUnite] [Ajustement_EssenceUnite3] On [AjustementCalcule_Usine].[UniteID] = [Ajustement_EssenceUnite3].[UniteID]
                Left Outer Join [dbo].[Livraison_Detail] [Livraison_Detail4] On [AjustementCalcule_Usine].[LivraisonDetailID] = [Livraison_Detail4].[ID]
                    Left Outer Join [dbo].[Usine] [Usine5] On [AjustementCalcule_Usine].[UsineID] = [Usine5].[ID]
                        Left Outer Join [dbo].[FactureClient] [FactureClient6] On [AjustementCalcule_Usine].[FactureID] = [FactureClient6].[ID]
                            Left Outer Join [dbo].[Ajustement_EssenceUnite] [Ajustement_EssenceUnite7] On [AjustementCalcule_Usine].[Code] = [Ajustement_EssenceUnite7].[Code]

Where

    ((@ID Is Null) Or ([AjustementCalcule_Usine].[ID] = @ID))
And ((@AjustementID Is Null) Or ([AjustementCalcule_Usine].[AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([AjustementCalcule_Usine].[EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([AjustementCalcule_Usine].[UniteID] = @UniteID))
And ((@LivraisonDetailID Is Null) Or ([AjustementCalcule_Usine].[LivraisonDetailID] = @LivraisonDetailID))
And ((@UsineID Is Null) Or ([AjustementCalcule_Usine].[UsineID] = @UsineID))
And ((@FactureID Is Null) Or ([AjustementCalcule_Usine].[FactureID] = @FactureID))
And ((@Code Is Null) Or ([AjustementCalcule_Usine].[Code] = @Code))
)



