CREATE FUNCTION [dbo].[fnEssence_Unite_Full]
(@EssenceID VARCHAR (6)=Null, @UniteID VARCHAR (6)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
 [Essence_Unite].[EssenceID]
,[Essence_Unite].[UniteID]
,[Essence_Unite].[Facteur_M3app]
,[Essence_Unite].[Facteur_M3sol]
,[Essence_Unite].[Facteur_FPBQ]
,[Essence_Unite].[Actif]
,[Essence_Unite].[Preleve_plan_conjoint]
,[Essence_Unite].[Preleve_plan_conjoint_Override]
,[Essence_Unite].[Preleve_fond_roulement]
,[Essence_Unite].[Preleve_fond_roulement_Override]
,[Essence_Unite].[Preleve_fond_forestier]
,[Essence_Unite].[Preleve_fond_forestier_Override]
,[Essence_Unite].[Preleve_divers]
,[Essence_Unite].[Preleve_divers_Override]
,[Essence_Unite].[UseMontant]
,[Essence1].[ID] [EssenceID_ID]
,[Essence1].[Description] [EssenceID_Description]
,[Essence1].[RegroupementID] [EssenceID_RegroupementID]
,[Essence1].[ContingentID] [EssenceID_ContingentID]
,[Essence1].[RepartitionID] [EssenceID_RepartitionID]
,[Essence1].[Actif] [EssenceID_Actif]
,[UniteMesure2].[ID] [UniteID_ID]
,[UniteMesure2].[Description] [UniteID_Description]
,[UniteMesure2].[Nb_decimale] [UniteID_Nb_decimale]
,[UniteMesure2].[Actif] [UniteID_Actif]
,[UniteMesure2].[UseMontant] [UniteID_UseMontant]
,[UniteMesure2].[Montant_Preleve_plan_conjoint] [UniteID_Montant_Preleve_plan_conjoint]
,[UniteMesure2].[Montant_Preleve_fond_roulement] [UniteID_Montant_Preleve_fond_roulement]
,[UniteMesure2].[Montant_Preleve_fond_forestier] [UniteID_Montant_Preleve_fond_forestier]
,[UniteMesure2].[Montant_Preleve_divers] [UniteID_Montant_Preleve_divers]
,[UniteMesure2].[Pourc_Preleve_plan_conjoint] [UniteID_Pourc_Preleve_plan_conjoint]
,[UniteMesure2].[Pourc_Preleve_fond_roulement] [UniteID_Pourc_Preleve_fond_roulement]
,[UniteMesure2].[Pourc_Preleve_fond_forestier] [UniteID_Pourc_Preleve_fond_forestier]
,[UniteMesure2].[Pourc_Preleve_divers] [UniteID_Pourc_Preleve_divers]

From [dbo].[Essence_Unite] [Essence_Unite]
    Inner Join [dbo].[Essence] [Essence1] On [Essence_Unite].[EssenceID] = [Essence1].[ID]
        Inner Join [dbo].[UniteMesure] [UniteMesure2] On [Essence_Unite].[UniteID] = [UniteMesure2].[ID]

Where

    ((@EssenceID Is Null) Or ([Essence_Unite].[EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([Essence_Unite].[UniteID] = @UniteID))
)



