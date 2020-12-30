

Create Procedure [spS_Indexation_EssenceUnite_Display]

(
 @ID [int] = Null -- for [Indexation_EssenceUnite].[ID] column
,@IndexationID [int] = Null -- for [Indexation_EssenceUnite].[IndexationID] column
,@ContratID [varchar](10) = Null -- for [Indexation_EssenceUnite].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [Indexation_EssenceUnite].[EssenceID] column
,@Code [char](4) = Null -- for [Indexation_EssenceUnite].[Code] column
,@UniteID [varchar](6) = Null -- for [Indexation_EssenceUnite].[UniteID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Indexation_EssenceUnite_Records].[ID1]
,[Indexation_EssenceUnite_Records].[Display]

From [fnIndexation_EssenceUnite_Display](@ID, @IndexationID, @ContratID, @EssenceID, @Code, @UniteID) As [Indexation_EssenceUnite_Records]

Return(@@RowCount)


