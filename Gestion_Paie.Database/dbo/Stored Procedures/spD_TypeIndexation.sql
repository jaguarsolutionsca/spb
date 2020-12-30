

Create Procedure [spD_TypeIndexation]

-- Delete a specific record from table [TypeIndexation]

(
 @ID [char](1) -- for [TypeIndexation].[ID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[TypeIndexation]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Set NoCount Off

Return(@@RowCount)


