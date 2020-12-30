

Create Procedure [spD_jag_ProfileSettings]

-- Delete a specific record from table [jag_ProfileSettings]

(
 @ProfileID [int] -- for [jag_ProfileSettings].[ProfileID] column
,@Name [varchar](500) -- for [jag_ProfileSettings].[Name] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[jag_ProfileSettings]

Where
    ((@ProfileID Is Null) Or ([ProfileID] = @ProfileID))
And ((@Name Is Null) Or ([Name] = @Name))

Set NoCount Off

Return(@@RowCount)


