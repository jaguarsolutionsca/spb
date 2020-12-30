

Create Procedure [spD_EssenceContingent]

-- Delete a specific record from table [EssenceContingent]

(
 @ID [int] -- for [EssenceContingent].[ID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[EssenceContingent]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Set NoCount Off

Return(@@RowCount)


