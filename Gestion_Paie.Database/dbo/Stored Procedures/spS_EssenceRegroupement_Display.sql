

Create Procedure [spS_EssenceRegroupement_Display]

(
 @ID [int] = Null -- for [EssenceRegroupement].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [EssenceRegroupement_Records].[ID1]
,[EssenceRegroupement_Records].[Display]

From [fnEssenceRegroupement_Display](@ID) As [EssenceRegroupement_Records]

Return(@@RowCount)


