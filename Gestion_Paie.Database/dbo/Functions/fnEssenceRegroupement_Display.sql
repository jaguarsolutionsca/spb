CREATE FUNCTION [dbo].[fnEssenceRegroupement_Display]
(@ID INT=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [ID] As [ID1]
,[Description] As [Display]
	
From [dbo].[EssenceRegroupement]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Order By [Display]
)



