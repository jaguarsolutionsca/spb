

Create Procedure [spD_EssenceRegroupement]

-- Delete a specific record from table [EssenceRegroupement]

(
 @ID [int] -- for [EssenceRegroupement].[ID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[EssenceRegroupement]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Set NoCount Off

Return(@@RowCount)


