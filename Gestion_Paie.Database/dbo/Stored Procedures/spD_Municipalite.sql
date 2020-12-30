

Create Procedure [spD_Municipalite]

-- Delete a specific record from table [Municipalite]

(
 @ID [varchar](6) -- for [Municipalite].[ID] column
,@MrcID [varchar](6) = Null -- for [Municipalite].[MrcID] column
,@AgenceID [varchar](4) = Null -- for [Municipalite].[AgenceID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Municipalite]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@MrcID Is Null) Or ([MrcID] = @MrcID))
And ((@AgenceID Is Null) Or ([AgenceID] = @AgenceID))

Set NoCount Off

Return(@@RowCount)


