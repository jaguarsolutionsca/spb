CREATE FUNCTION [dbo].[fnEssence_Unite]
(@EssenceID VARCHAR (6)=Null, @UniteID VARCHAR (6)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [EssenceID]
,[UniteID]
,[Facteur_M3app]
,[Facteur_M3sol]
,[Facteur_FPBQ]
,[Actif]
,[Preleve_plan_conjoint]
,[Preleve_plan_conjoint_Override]
,[Preleve_fond_roulement]
,[Preleve_fond_roulement_Override]
,[Preleve_fond_forestier]
,[Preleve_fond_forestier_Override]
,[Preleve_divers]
,[Preleve_divers_Override]
,[UseMontant]

From [dbo].[Essence_Unite]

Where

    ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
)



