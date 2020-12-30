

Create Procedure [spD_EssenceRepartition]

-- Delete a specific record from table [EssenceRepartition]

(
 @ID [int] -- for [EssenceRepartition].[ID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[EssenceRepartition]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Set NoCount Off

Return(@@RowCount)


