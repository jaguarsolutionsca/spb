

Create Procedure [spD_FactureStatus]

-- Delete a specific record from table [FactureStatus]

(
 @ID [varchar](15) -- for [FactureStatus].[ID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[FactureStatus]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Set NoCount Off

Return(@@RowCount)


