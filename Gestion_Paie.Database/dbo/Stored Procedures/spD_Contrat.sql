

Create Procedure [spD_Contrat]

-- Delete a specific record from table [Contrat]

(
 @ID [varchar](10) -- for [Contrat].[ID] column
,@UsineID [varchar](6) = Null -- for [Contrat].[UsineID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Contrat]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@UsineID Is Null) Or ([UsineID] = @UsineID))

Set NoCount Off

Return(@@RowCount)


