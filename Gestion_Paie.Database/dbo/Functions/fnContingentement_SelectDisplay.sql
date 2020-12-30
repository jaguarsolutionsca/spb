CREATE FUNCTION [dbo].[fnContingentement_SelectDisplay]
(@ID INT=Null, @UsineID VARCHAR (6)=Null, @RegroupementID INT=Null, @EssenceID VARCHAR (6)=Null, @UniteMesureID VARCHAR (6)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [Contingentement].[ID]
	,[Contingentement].[ContingentUsine]
	,[Contingentement].[UsineID]
	,[Usine1].[Display] [UsineID_Display]
	,[Contingentement].[RegroupementID]
	,[EssenceRegroupement2].[Display] [RegroupementID_Display]
	,[Contingentement].[Annee]
	,[Contingentement].[PeriodeContingentement]
	,[Contingentement].[PeriodeDebut]
	,[Contingentement].[PeriodeFin]
	,[Contingentement].[EssenceID]
	,[Essence3].[Display] [EssenceID_Display]
	,[Contingentement].[UniteMesureID]
	,[UniteMesure4].[Display] [UniteMesureID_Display]
	,[Contingentement].[Volume_Usine]
	,[Contingentement].[Facteur]
	,[Contingentement].[Volume_Fixe]
	,[Contingentement].[Date_Calcul]
	,[Contingentement].[CalculAccepte]
	,[Contingentement].[Code]
	,[Contingentement].[Volume_Regroupement]
	,[Contingentement].[Volume_RegroupementPourcentage]
	,[Contingentement].[MaxVolumeFixe_Pourcentage]
	,[Contingentement].[MaxVolumeFixe_ContingentementID]
	,[Contingentement].[UseVolumeFixeUnique]
	,[Contingentement].[MasseContingentVoyageDefaut]

From [dbo].[Contingentement]
    Left Outer Join [fnUsine_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Usine1] On [UsineID] = [Usine1].[ID1]
        Left Outer Join [fnEssenceRegroupement_Display](Null) [EssenceRegroupement2] On [RegroupementID] = [EssenceRegroupement2].[ID1]
            Left Outer Join [fnEssence_Display](Null, Null, Null, Null) [Essence3] On [EssenceID] = [Essence3].[ID1]
                Left Outer Join [fnUniteMesure_Display](Null) [UniteMesure4] On [UniteMesureID] = [UniteMesure4].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@UsineID Is Null) Or ([UsineID] = @UsineID))
And ((@RegroupementID Is Null) Or ([RegroupementID] = @RegroupementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))
)



