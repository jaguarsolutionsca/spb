CREATE FUNCTION [dbo].[fnContingentement_Producteur_Display]
(@ContingentementID INT=Null, @ProducteurID VARCHAR (15)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [ContingentementID] As [ID1]
,[ProducteurID] As [ID2]
,[ProducteurID] As [Display]
	
From [dbo].[Contingentement_Producteur]

Where
    ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))

Order By [Display]
)



