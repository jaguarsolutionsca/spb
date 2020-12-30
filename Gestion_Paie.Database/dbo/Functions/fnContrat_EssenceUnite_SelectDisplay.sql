CREATE FUNCTION [dbo].[fnContrat_EssenceUnite_SelectDisplay]
(@ContratID VARCHAR (10)=Null, @EssenceID VARCHAR (6)=Null, @UniteID VARCHAR (6)=Null, @Code CHAR (4)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [Contrat_EssenceUnite].[ContratID]
	,[Contrat1].[Display] [ContratID_Display]
	,[Contrat_EssenceUnite].[EssenceID]
	,[Essence_Unite2].[Display] [EssenceID_Display]
	,[Contrat_EssenceUnite].[UniteID]
	,[Essence_Unite3].[Display] [UniteID_Display]
	,[Contrat_EssenceUnite].[Code]
	,[Contrat_EssenceUnite].[Quantite_prevue]
	,[Contrat_EssenceUnite].[Taux_usine]
	,[Contrat_EssenceUnite].[Taux_producteur]
	,[Contrat_EssenceUnite].[Actif]
	,[Contrat_EssenceUnite].[Description]

From [dbo].[Contrat_EssenceUnite]
    Inner Join [fnContrat_Display](Null, Null) [Contrat1] On [ContratID] = [Contrat1].[ID1]
        Inner Join [fnEssence_Unite_Display](Null, Null) [Essence_Unite2] On [EssenceID] = [Essence_Unite2].[ID1]
            Inner Join [fnEssence_Unite_Display](Null, Null) [Essence_Unite3] On [UniteID] = [Essence_Unite3].[ID2]

Where

    ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@Code Is Null) Or ([Code] = @Code))
)



