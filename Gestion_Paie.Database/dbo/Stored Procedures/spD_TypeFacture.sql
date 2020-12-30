

Create Procedure [spD_TypeFacture]

-- Delete a specific record from table [TypeFacture]

(
 @ID [char](1) -- for [TypeFacture].[ID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[TypeFacture]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Set NoCount Off

Return(@@RowCount)


