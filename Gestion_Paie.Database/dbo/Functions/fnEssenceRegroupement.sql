CREATE FUNCTION [dbo].[fnEssenceRegroupement]
(@ID INT=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [ID]
,[Description]
,[Actif]
,[Ordre]

From [dbo].[EssenceRegroupement]

Where

    ((@ID Is Null) Or ([ID] = @ID))
)



