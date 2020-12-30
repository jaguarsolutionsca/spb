

Create Function [fnjag_ProfileSettings_Display]
(
 @ProfileID [int] = Null
,@Name [varchar](500) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ProfileID] As [ID1]
,[Name] As [ID2]
,[Name] As [Display]
	
From [dbo].[jag_ProfileSettings]

Where
    ((@ProfileID Is Null) Or ([ProfileID] = @ProfileID))
And ((@Name Is Null) Or ([Name] = @Name))

Order By [Display]
)


