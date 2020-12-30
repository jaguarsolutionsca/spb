CREATE FUNCTION [dbo].[fnContingentement_Producteur_SelectDisplay]
(@ContingentementID INT=Null, @ProducteurID VARCHAR (15)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [Contingentement_Producteur].[ContingentementID]
	,[Contingentement1].[Display] [ContingentementID_Display]
	,[Contingentement_Producteur].[ProducteurID]
	,[Fournisseur2].[Display] [ProducteurID_Display]
	,[Contingentement_Producteur].[Superficie_Contingentee]
	,[Contingentement_Producteur].[Volume_Demande]
	,[Contingentement_Producteur].[Volume_Facteur]
	,[Contingentement_Producteur].[Volume_Fixe]
	,[Contingentement_Producteur].[Volume_Supplementaire]
	,[Contingentement_Producteur].[Volume_Accorde]
	,[Contingentement_Producteur].[Date_Modification]
	,[Contingentement_Producteur].[Volume_Inventaire]
	,[Contingentement_Producteur].[LastLivraison]
	,[Contingentement_Producteur].[VolumeMaximum]
	,[Contingentement_Producteur].[Imprime]

From [dbo].[Contingentement_Producteur]
    Inner Join [fnContingentement_Display](Null, Null, Null, Null, Null) [Contingentement1] On [ContingentementID] = [Contingentement1].[ID1]
        Inner Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur2] On [ProducteurID] = [Fournisseur2].[ID1]

Where

    ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
)



