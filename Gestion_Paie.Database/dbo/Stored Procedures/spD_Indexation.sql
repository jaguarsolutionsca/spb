

CREATE Procedure [spD_Indexation]

-- Delete a specific record from table [Indexation]

(
 @ID [int] -- for [Indexation].[ID] column
,@ContratID [varchar](10) = Null -- for [Indexation].[ContratID] column
,@TypeIndexation [char](1) = Null -- for [Indexation].[TypeIndexation] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Indexation]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@TypeIndexation Is Null) Or ([TypeIndexation] = @TypeIndexation))

Set NoCount Off

Return(@@RowCount)


