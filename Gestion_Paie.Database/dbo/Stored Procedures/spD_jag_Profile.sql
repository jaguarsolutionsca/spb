

Create Procedure [spD_jag_Profile]

-- Delete a specific record from table [jag_Profile]

(
 @ID [int] -- for [jag_Profile].[ID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[jag_Profile]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Set NoCount Off

Return(@@RowCount)


