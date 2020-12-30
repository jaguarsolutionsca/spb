CREATE FUNCTION [dbo].[fnEssence_Unite_SelectDisplay]
(@EssenceID VARCHAR (6)=Null, @UniteID VARCHAR (6)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [Essence_Unite].[EssenceID]
	,[Essence1].[Display] [EssenceID_Display]
	,[Essence_Unite].[UniteID]
	,[UniteMesure2].[Display] [UniteID_Display]
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

From [dbo].[Essence_Unite]
    Inner Join [fnEssence_Display](Null, Null, Null, Null) [Essence1] On [EssenceID] = [Essence1].[ID1]
        Inner Join [fnUniteMesure_Display](Null) [UniteMesure2] On [UniteID] = [UniteMesure2].[ID1]

Where

    ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
)



