CREATE FUNCTION [dbo].[fnUsine_Full]
(@ID VARCHAR (6)=Null, @UtilisationID INT=Null, @Compte_a_recevoir INT=Null, @Compte_ajustement INT=Null, @Compte_transporteur INT=Null, @Compte_producteur INT=Null, @Compte_preleve_plan_conjoint INT=Null, @Compte_preleve_fond_roulement INT=Null, @Compte_preleve_fond_forestier INT=Null, @Compte_preleve_divers INT=Null, @Compte_mise_en_commun INT=Null, @Compte_surcharge INT=Null, @Compte_indexation_carburant INT=Null, @PaysID VARCHAR (2)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [Usine].[ID]
,[Usine].[Description]
,[Usine].[UtilisationID]
,[Usine].[Paye_producteur]
,[Usine].[Paye_transporteur]
,[Usine].[Specification]
,[Usine].[Compte_a_recevoir]
,[Usine].[Compte_ajustement]
,[Usine].[Compte_transporteur]
,[Usine].[Compte_producteur]
,[Usine].[Compte_preleve_plan_conjoint]
,[Usine].[Compte_preleve_fond_roulement]
,[Usine].[Compte_preleve_fond_forestier]
,[Usine].[Compte_preleve_divers]
,[Usine].[Compte_mise_en_commun]
,[Usine].[Compte_surcharge]
,[Usine].[Compte_indexation_carburant]
,[Usine].[Actif]
,[Usine].[NePaiePasTPS]
,[Usine].[NePaiePasTVQ]
,[Usine].[NoTPS]
,[Usine].[NoTVQ]
,[Usine].[Compte_chargeur]
,[Usine].[UsineGestionVolume]
,[Usine].[AuSoinsDe]
,[Usine].[Rue]
,[Usine].[Ville]
,[Usine].[PaysID]
,[Usine].[Code_postal]
,[Usine].[Telephone]
,[Usine].[Telephone_Poste]
,[Usine].[Telecopieur]
,[Usine].[Telephone2]
,[Usine].[Telephone2_Desc]
,[Usine].[Telephone2_Poste]
,[Usine].[Telephone3]
,[Usine].[Telephone3_Desc]
,[Usine].[Telephone3_Poste]
,[Usine].[Email]
,[UsineUtilisation1].[ID] [UtilisationID_ID]
,[UsineUtilisation1].[Description] [UtilisationID_Description]
,[UsineUtilisation1].[Actif] [UtilisationID_Actif]
,[Compte2].[ID] [Compte_a_recevoir_ID]
,[Compte2].[Description] [Compte_a_recevoir_Description]
,[Compte2].[CategoryID] [Compte_a_recevoir_CategoryID]
,[Compte2].[isTaxe] [Compte_a_recevoir_isTaxe]
,[Compte2].[Actif] [Compte_a_recevoir_Actif]
,[Compte3].[ID] [Compte_ajustement_ID]
,[Compte3].[Description] [Compte_ajustement_Description]
,[Compte3].[CategoryID] [Compte_ajustement_CategoryID]
,[Compte3].[isTaxe] [Compte_ajustement_isTaxe]
,[Compte3].[Actif] [Compte_ajustement_Actif]
,[Compte4].[ID] [Compte_transporteur_ID]
,[Compte4].[Description] [Compte_transporteur_Description]
,[Compte4].[CategoryID] [Compte_transporteur_CategoryID]
,[Compte4].[isTaxe] [Compte_transporteur_isTaxe]
,[Compte4].[Actif] [Compte_transporteur_Actif]
,[Compte5].[ID] [Compte_producteur_ID]
,[Compte5].[Description] [Compte_producteur_Description]
,[Compte5].[CategoryID] [Compte_producteur_CategoryID]
,[Compte5].[isTaxe] [Compte_producteur_isTaxe]
,[Compte5].[Actif] [Compte_producteur_Actif]
,[Compte6].[ID] [Compte_preleve_plan_conjoint_ID]
,[Compte6].[Description] [Compte_preleve_plan_conjoint_Description]
,[Compte6].[CategoryID] [Compte_preleve_plan_conjoint_CategoryID]
,[Compte6].[isTaxe] [Compte_preleve_plan_conjoint_isTaxe]
,[Compte6].[Actif] [Compte_preleve_plan_conjoint_Actif]
,[Compte7].[ID] [Compte_preleve_fond_roulement_ID]
,[Compte7].[Description] [Compte_preleve_fond_roulement_Description]
,[Compte7].[CategoryID] [Compte_preleve_fond_roulement_CategoryID]
,[Compte7].[isTaxe] [Compte_preleve_fond_roulement_isTaxe]
,[Compte7].[Actif] [Compte_preleve_fond_roulement_Actif]
,[Compte8].[ID] [Compte_preleve_fond_forestier_ID]
,[Compte8].[Description] [Compte_preleve_fond_forestier_Description]
,[Compte8].[CategoryID] [Compte_preleve_fond_forestier_CategoryID]
,[Compte8].[isTaxe] [Compte_preleve_fond_forestier_isTaxe]
,[Compte8].[Actif] [Compte_preleve_fond_forestier_Actif]
,[Compte9].[ID] [Compte_preleve_divers_ID]
,[Compte9].[Description] [Compte_preleve_divers_Description]
,[Compte9].[CategoryID] [Compte_preleve_divers_CategoryID]
,[Compte9].[isTaxe] [Compte_preleve_divers_isTaxe]
,[Compte9].[Actif] [Compte_preleve_divers_Actif]
,[Compte10].[ID] [Compte_mise_en_commun_ID]
,[Compte10].[Description] [Compte_mise_en_commun_Description]
,[Compte10].[CategoryID] [Compte_mise_en_commun_CategoryID]
,[Compte10].[isTaxe] [Compte_mise_en_commun_isTaxe]
,[Compte10].[Actif] [Compte_mise_en_commun_Actif]
,[Compte11].[ID] [Compte_surcharge_ID]
,[Compte11].[Description] [Compte_surcharge_Description]
,[Compte11].[CategoryID] [Compte_surcharge_CategoryID]
,[Compte11].[isTaxe] [Compte_surcharge_isTaxe]
,[Compte11].[Actif] [Compte_surcharge_Actif]
,[Compte12].[ID] [Compte_indexation_carburant_ID]
,[Compte12].[Description] [Compte_indexation_carburant_Description]
,[Compte12].[CategoryID] [Compte_indexation_carburant_CategoryID]
,[Compte12].[isTaxe] [Compte_indexation_carburant_isTaxe]
,[Compte12].[Actif] [Compte_indexation_carburant_Actif]
,[Pays13].[ID] [PaysID_ID]
,[Pays13].[Nom] [PaysID_Nom]
,[Pays13].[CodePostal_InputMask] [PaysID_CodePostal_InputMask]
,[Pays13].[Actif] [PaysID_Actif]

From [dbo].[Usine] [Usine]
    Left Outer Join [dbo].[UsineUtilisation] [UsineUtilisation1] On [Usine].[UtilisationID] = [UsineUtilisation1].[ID]
        Left Outer Join [dbo].[Compte] [Compte2] On [Usine].[Compte_a_recevoir] = [Compte2].[ID]
            Left Outer Join [dbo].[Compte] [Compte3] On [Usine].[Compte_ajustement] = [Compte3].[ID]
                Left Outer Join [dbo].[Compte] [Compte4] On [Usine].[Compte_transporteur] = [Compte4].[ID]
                    Left Outer Join [dbo].[Compte] [Compte5] On [Usine].[Compte_producteur] = [Compte5].[ID]
                        Left Outer Join [dbo].[Compte] [Compte6] On [Usine].[Compte_preleve_plan_conjoint] = [Compte6].[ID]
                            Left Outer Join [dbo].[Compte] [Compte7] On [Usine].[Compte_preleve_fond_roulement] = [Compte7].[ID]
                                Left Outer Join [dbo].[Compte] [Compte8] On [Usine].[Compte_preleve_fond_forestier] = [Compte8].[ID]
                                    Left Outer Join [dbo].[Compte] [Compte9] On [Usine].[Compte_preleve_divers] = [Compte9].[ID]
                                        Left Outer Join [dbo].[Compte] [Compte10] On [Usine].[Compte_mise_en_commun] = [Compte10].[ID]
                                            Left Outer Join [dbo].[Compte] [Compte11] On [Usine].[Compte_surcharge] = [Compte11].[ID]
                                                Left Outer Join [dbo].[Compte] [Compte12] On [Usine].[Compte_indexation_carburant] = [Compte12].[ID]
                                                    Left Outer Join [dbo].[Pays] [Pays13] On [Usine].[PaysID] = [Pays13].[ID]

Where

    ((@ID Is Null) Or ([Usine].[ID] = @ID))
And ((@UtilisationID Is Null) Or ([Usine].[UtilisationID] = @UtilisationID))
And ((@Compte_a_recevoir Is Null) Or ([Usine].[Compte_a_recevoir] = @Compte_a_recevoir))
And ((@Compte_ajustement Is Null) Or ([Usine].[Compte_ajustement] = @Compte_ajustement))
And ((@Compte_transporteur Is Null) Or ([Usine].[Compte_transporteur] = @Compte_transporteur))
And ((@Compte_producteur Is Null) Or ([Usine].[Compte_producteur] = @Compte_producteur))
And ((@Compte_preleve_plan_conjoint Is Null) Or ([Usine].[Compte_preleve_plan_conjoint] = @Compte_preleve_plan_conjoint))
And ((@Compte_preleve_fond_roulement Is Null) Or ([Usine].[Compte_preleve_fond_roulement] = @Compte_preleve_fond_roulement))
And ((@Compte_preleve_fond_forestier Is Null) Or ([Usine].[Compte_preleve_fond_forestier] = @Compte_preleve_fond_forestier))
And ((@Compte_preleve_divers Is Null) Or ([Usine].[Compte_preleve_divers] = @Compte_preleve_divers))
And ((@Compte_mise_en_commun Is Null) Or ([Usine].[Compte_mise_en_commun] = @Compte_mise_en_commun))
And ((@Compte_surcharge Is Null) Or ([Usine].[Compte_surcharge] = @Compte_surcharge))
And ((@Compte_indexation_carburant Is Null) Or ([Usine].[Compte_indexation_carburant] = @Compte_indexation_carburant))
And ((@PaysID Is Null) Or ([Usine].[PaysID] = @PaysID))
)



