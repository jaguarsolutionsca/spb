

Create Procedure [spS_Indexation_Display]

(
 @ID [int] = Null -- for [Indexation].[ID] column
,@ContratID [varchar](10) = Null -- for [Indexation].[ContratID] column
,@TypeIndexation [char](1) = Null -- for [Indexation].[TypeIndexation] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Indexation_Records].[ID1]
,[Indexation_Records].[Display]

From [fnIndexation_Display](@ID, @ContratID, @TypeIndexation) As [Indexation_Records]

Return(@@RowCount)


