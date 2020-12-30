CREATE FUNCTION [dbo].[fnUsineUtilisation]
(@ID INT=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [ID]
,[Description]
,[isPate]
,[Actif]

From [dbo].[UsineUtilisation]

Where

    ((@ID Is Null) Or ([ID] = @ID))
)



