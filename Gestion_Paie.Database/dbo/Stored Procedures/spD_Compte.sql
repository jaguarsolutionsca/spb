

Create Procedure [spD_Compte]

-- Delete a specific record from table [Compte]

(
 @ID [int] -- for [Compte].[ID] column
,@CategoryID [int] = Null -- for [Compte].[CategoryID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Compte]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@CategoryID Is Null) Or ([CategoryID] = @CategoryID))

Set NoCount Off

Return(@@RowCount)


