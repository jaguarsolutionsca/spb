

Create Procedure [spD_Contingentement_Unite]

-- Delete a specific record from table [Contingentement_Unite]

(
 @ContingentementID [int] -- for [Contingentement_Unite].[ContingentementID] column
,@UniteID [varchar](6) -- for [Contingentement_Unite].[UniteID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Contingentement_Unite]

Where
    ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))

Set NoCount Off

Return(@@RowCount)


