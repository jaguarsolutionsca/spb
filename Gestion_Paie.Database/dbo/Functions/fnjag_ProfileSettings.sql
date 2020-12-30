

Create Function [fnjag_ProfileSettings]
(
 @ProfileID [int] = Null
,@Name [varchar](500) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ProfileID]
,[Name]
,[Value]

From [dbo].[jag_ProfileSettings]

Where

    ((@ProfileID Is Null) Or ([ProfileID] = @ProfileID))
And ((@Name Is Null) Or ([Name] = @Name))
)


