CREATE FUNCTION [dbo].[fnFeuilletDomtar_Display]
(@Transaction VARCHAR (15)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [Transaction] As [ID1]
,[Transaction] As [Display]
	
From [dbo].[FeuilletDomtar]

Where
    ((@Transaction Is Null) Or ([Transaction] = @Transaction))

Order By [Display]
)



