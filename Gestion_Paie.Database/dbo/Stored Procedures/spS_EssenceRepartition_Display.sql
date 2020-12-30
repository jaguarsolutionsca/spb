

Create Procedure [spS_EssenceRepartition_Display]

(
 @ID [int] = Null -- for [EssenceRepartition].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [EssenceRepartition_Records].[ID1]
,[EssenceRepartition_Records].[Display]

From [fnEssenceRepartition_Display](@ID) As [EssenceRepartition_Records]

Return(@@RowCount)


