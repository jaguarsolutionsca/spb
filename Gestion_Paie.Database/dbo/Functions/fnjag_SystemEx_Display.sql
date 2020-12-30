

Create Function [fnjag_SystemEx_Display]
(
 @Name [varchar](50) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Name] As [ID1]
,[Name] As [Display]
	
From [dbo].[jag_SystemEx]

Where
    ((@Name Is Null) Or ([Name] = @Name))

Order By [Display]
)


