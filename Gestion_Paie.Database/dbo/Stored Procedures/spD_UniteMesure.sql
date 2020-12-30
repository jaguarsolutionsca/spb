

Create Procedure [spD_UniteMesure]

-- Delete a specific record from table [UniteMesure]

(
 @ID [varchar](6) -- for [UniteMesure].[ID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[UniteMesure]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Set NoCount Off

Return(@@RowCount)


