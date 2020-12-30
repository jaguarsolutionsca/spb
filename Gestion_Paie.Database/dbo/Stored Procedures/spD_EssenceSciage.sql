

Create Procedure [spD_EssenceSciage]

-- Delete a specific record from table [EssenceSciage]

(
 @ID [int] -- for [EssenceSciage].[ID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[EssenceSciage]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Set NoCount Off

Return(@@RowCount)


