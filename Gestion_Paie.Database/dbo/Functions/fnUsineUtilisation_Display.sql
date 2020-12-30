CREATE FUNCTION [dbo].[fnUsineUtilisation_Display]
(@ID INT=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [ID] As [ID1]
,[Description] As [Display]
	
From [dbo].[UsineUtilisation]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Order By [Display]
)



