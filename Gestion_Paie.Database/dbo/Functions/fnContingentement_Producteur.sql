CREATE FUNCTION [dbo].[fnContingentement_Producteur]
(@ContingentementID INT=Null, @ProducteurID VARCHAR (15)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [ContingentementID]
,[ProducteurID]
,[Superficie_Contingentee]
,[Volume_Demande]
,[Volume_Facteur]
,[Volume_Fixe]
,[Volume_Supplementaire]
,[Volume_Accorde]
,[Date_Modification]
,[Volume_Inventaire]
,[LastLivraison]
,[VolumeMaximum]
,[Imprime]

From [dbo].[Contingentement_Producteur]

Where

    ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
)



