CREATE FUNCTION [dbo].[fnContrat_EssenceUnite_Full]
(@ContratID VARCHAR (10)=Null, @EssenceID VARCHAR (6)=Null, @UniteID VARCHAR (6)=Null, @Code CHAR (4)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [Contrat_EssenceUnite].[ContratID]
,[Contrat_EssenceUnite].[EssenceID]
,[Contrat_EssenceUnite].[UniteID]
,[Contrat_EssenceUnite].[Code]
,[Contrat_EssenceUnite].[Quantite_prevue]
,[Contrat_EssenceUnite].[Taux_usine]
,[Contrat_EssenceUnite].[Taux_producteur]
,[Contrat_EssenceUnite].[Actif]
,[Contrat_EssenceUnite].[Description]
,[Contrat1].[ID] [ContratID_ID]
,[Contrat1].[Description] [ContratID_Description]
,[Contrat1].[UsineID] [ContratID_UsineID]
,[Contrat1].[Annee] [ContratID_Annee]
,[Contrat1].[Date_debut] [ContratID_Date_debut]
,[Contrat1].[Date_fin] [ContratID_Date_fin]
,[Contrat1].[Actif] [ContratID_Actif]
,[Contrat1].[PaieTransporteur] [ContratID_PaieTransporteur]
,[Contrat1].[Taux_Surcharge] [ContratID_Taux_Surcharge]
,[Contrat1].[SurchargeManuel] [ContratID_SurchargeManuel]
,[Contrat1].[TxTransSameProd] [ContratID_TxTransSameProd]
,[Essence_Unite2].[EssenceID] [EssenceID_EssenceID]
,[Essence_Unite2].[UniteID] [EssenceID_UniteID]
,[Essence_Unite2].[Facteur_M3app] [EssenceID_Facteur_M3app]
,[Essence_Unite2].[Facteur_M3sol] [EssenceID_Facteur_M3sol]
,[Essence_Unite2].[Actif] [EssenceID_Actif]
,[Essence_Unite2].[Preleve_plan_conjoint] [EssenceID_Preleve_plan_conjoint]
,[Essence_Unite2].[Preleve_plan_conjoint_Override] [EssenceID_Preleve_plan_conjoint_Override]
,[Essence_Unite2].[Preleve_fond_roulement] [EssenceID_Preleve_fond_roulement]
,[Essence_Unite2].[Preleve_fond_roulement_Override] [EssenceID_Preleve_fond_roulement_Override]
,[Essence_Unite2].[Preleve_fond_forestier] [EssenceID_Preleve_fond_forestier]
,[Essence_Unite2].[Preleve_fond_forestier_Override] [EssenceID_Preleve_fond_forestier_Override]
,[Essence_Unite2].[Preleve_divers] [EssenceID_Preleve_divers]
,[Essence_Unite2].[Preleve_divers_Override] [EssenceID_Preleve_divers_Override]
,[Essence_Unite2].[UseMontant] [EssenceID_UseMontant]
,[Essence_Unite3].[EssenceID] [UniteID_EssenceID]
,[Essence_Unite3].[UniteID] [UniteID_UniteID]
,[Essence_Unite3].[Facteur_M3app] [UniteID_Facteur_M3app]
,[Essence_Unite3].[Facteur_M3sol] [UniteID_Facteur_M3sol]
,[Essence_Unite3].[Actif] [UniteID_Actif]
,[Essence_Unite3].[Preleve_plan_conjoint] [UniteID_Preleve_plan_conjoint]
,[Essence_Unite3].[Preleve_plan_conjoint_Override] [UniteID_Preleve_plan_conjoint_Override]
,[Essence_Unite3].[Preleve_fond_roulement] [UniteID_Preleve_fond_roulement]
,[Essence_Unite3].[Preleve_fond_roulement_Override] [UniteID_Preleve_fond_roulement_Override]
,[Essence_Unite3].[Preleve_fond_forestier] [UniteID_Preleve_fond_forestier]
,[Essence_Unite3].[Preleve_fond_forestier_Override] [UniteID_Preleve_fond_forestier_Override]
,[Essence_Unite3].[Preleve_divers] [UniteID_Preleve_divers]
,[Essence_Unite3].[Preleve_divers_Override] [UniteID_Preleve_divers_Override]
,[Essence_Unite3].[UseMontant] [UniteID_UseMontant]

From [dbo].[Contrat_EssenceUnite] [Contrat_EssenceUnite]
    Inner Join [dbo].[Contrat] [Contrat1] On [Contrat_EssenceUnite].[ContratID] = [Contrat1].[ID]
        Inner Join [dbo].[Essence_Unite] [Essence_Unite2] On [Contrat_EssenceUnite].[EssenceID] = [Essence_Unite2].[EssenceID]
            Inner Join [dbo].[Essence_Unite] [Essence_Unite3] On [Contrat_EssenceUnite].[UniteID] = [Essence_Unite3].[UniteID]

Where

    ((@ContratID Is Null) Or ([Contrat_EssenceUnite].[ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([Contrat_EssenceUnite].[EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([Contrat_EssenceUnite].[UniteID] = @UniteID))
And ((@Code Is Null) Or ([Contrat_EssenceUnite].[Code] = @Code))
)



