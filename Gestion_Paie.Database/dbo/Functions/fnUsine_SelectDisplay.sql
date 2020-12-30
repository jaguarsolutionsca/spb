CREATE FUNCTION [dbo].[fnUsine_SelectDisplay]
(@ID VARCHAR (6)=Null, @UtilisationID INT=Null, @Compte_a_recevoir INT=Null, @Compte_ajustement INT=Null, @Compte_transporteur INT=Null, @Compte_producteur INT=Null, @Compte_preleve_plan_conjoint INT=Null, @Compte_preleve_fond_roulement INT=Null, @Compte_preleve_fond_forestier INT=Null, @Compte_preleve_divers INT=Null, @Compte_mise_en_commun INT=Null, @Compte_surcharge INT=Null, @Compte_indexation_carburant INT=Null, @PaysID VARCHAR (2)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [Usine].[ID]
	,[Usine].[Description]
	,[Usine].[UtilisationID]
	,[UsineUtilisation1].[Display] [UtilisationID_Display]
	,[Usine].[Paye_producteur]
	,[Usine].[Paye_transporteur]
	,[Usine].[Specification]
	,[Usine].[Compte_a_recevoir]
	,[Compte2].[Display] [Compte_a_recevoir_Display]
	,[Usine].[Compte_ajustement]
	,[Compte3].[Display] [Compte_ajustement_Display]
	,[Usine].[Compte_transporteur]
	,[Compte4].[Display] [Compte_transporteur_Display]
	,[Usine].[Compte_producteur]
	,[Compte5].[Display] [Compte_producteur_Display]
	,[Usine].[Compte_preleve_plan_conjoint]
	,[Compte6].[Display] [Compte_preleve_plan_conjoint_Display]
	,[Usine].[Compte_preleve_fond_roulement]
	,[Compte7].[Display] [Compte_preleve_fond_roulement_Display]
	,[Usine].[Compte_preleve_fond_forestier]
	,[Compte8].[Display] [Compte_preleve_fond_forestier_Display]
	,[Usine].[Compte_preleve_divers]
	,[Compte9].[Display] [Compte_preleve_divers_Display]
	,[Usine].[Compte_mise_en_commun]
	,[Compte10].[Display] [Compte_mise_en_commun_Display]
	,[Usine].[Compte_surcharge]
	,[Compte11].[Display] [Compte_surcharge_Display]
	,[Usine].[Compte_indexation_carburant]
	,[Compte12].[Display] [Compte_indexation_carburant_Display]
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
	,[Pays13].[Display] [PaysID_Display]
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

From [dbo].[Usine]
    Left Outer Join [fnUsineUtilisation_Display](Null) [UsineUtilisation1] On [UtilisationID] = [UsineUtilisation1].[ID1]
        Left Outer Join [fnCompte_Display](Null, Null) [Compte2] On [Compte_a_recevoir] = [Compte2].[ID1]
            Left Outer Join [fnCompte_Display](Null, Null) [Compte3] On [Compte_ajustement] = [Compte3].[ID1]
                Left Outer Join [fnCompte_Display](Null, Null) [Compte4] On [Compte_transporteur] = [Compte4].[ID1]
                    Left Outer Join [fnCompte_Display](Null, Null) [Compte5] On [Compte_producteur] = [Compte5].[ID1]
                        Left Outer Join [fnCompte_Display](Null, Null) [Compte6] On [Compte_preleve_plan_conjoint] = [Compte6].[ID1]
                            Left Outer Join [fnCompte_Display](Null, Null) [Compte7] On [Compte_preleve_fond_roulement] = [Compte7].[ID1]
                                Left Outer Join [fnCompte_Display](Null, Null) [Compte8] On [Compte_preleve_fond_forestier] = [Compte8].[ID1]
                                    Left Outer Join [fnCompte_Display](Null, Null) [Compte9] On [Compte_preleve_divers] = [Compte9].[ID1]
                                        Left Outer Join [fnCompte_Display](Null, Null) [Compte10] On [Compte_mise_en_commun] = [Compte10].[ID1]
                                            Left Outer Join [fnCompte_Display](Null, Null) [Compte11] On [Compte_surcharge] = [Compte11].[ID1]
                                                Left Outer Join [fnCompte_Display](Null, Null) [Compte12] On [Compte_indexation_carburant] = [Compte12].[ID1]
                                                    Left Outer Join [fnPays_Display](Null) [Pays13] On [PaysID] = [Pays13].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@UtilisationID Is Null) Or ([UtilisationID] = @UtilisationID))
And ((@Compte_a_recevoir Is Null) Or ([Compte_a_recevoir] = @Compte_a_recevoir))
And ((@Compte_ajustement Is Null) Or ([Compte_ajustement] = @Compte_ajustement))
And ((@Compte_transporteur Is Null) Or ([Compte_transporteur] = @Compte_transporteur))
And ((@Compte_producteur Is Null) Or ([Compte_producteur] = @Compte_producteur))
And ((@Compte_preleve_plan_conjoint Is Null) Or ([Compte_preleve_plan_conjoint] = @Compte_preleve_plan_conjoint))
And ((@Compte_preleve_fond_roulement Is Null) Or ([Compte_preleve_fond_roulement] = @Compte_preleve_fond_roulement))
And ((@Compte_preleve_fond_forestier Is Null) Or ([Compte_preleve_fond_forestier] = @Compte_preleve_fond_forestier))
And ((@Compte_preleve_divers Is Null) Or ([Compte_preleve_divers] = @Compte_preleve_divers))
And ((@Compte_mise_en_commun Is Null) Or ([Compte_mise_en_commun] = @Compte_mise_en_commun))
And ((@Compte_surcharge Is Null) Or ([Compte_surcharge] = @Compte_surcharge))
And ((@Compte_indexation_carburant Is Null) Or ([Compte_indexation_carburant] = @Compte_indexation_carburant))
And ((@PaysID Is Null) Or ([PaysID] = @PaysID))
)



