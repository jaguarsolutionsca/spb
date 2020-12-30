
CREATE Procedure [spD_FeuilletDomtar]

-- Delete a specific record from table [FeuilletDomtar]

(
 @Transaction [varchar](15) -- for [FeuilletDomtar].[Transaction] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[FeuilletDomtar]

Where
    ((@Transaction Is Null) Or ([Transaction] = @Transaction))

Set NoCount Off

Return(@@RowCount)

