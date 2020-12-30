

Create Procedure [spS_EssenceContingent_Display]

(
 @ID [int] = Null -- for [EssenceContingent].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [EssenceContingent_Records].[ID1]
,[EssenceContingent_Records].[Display]

From [fnEssenceContingent_Display](@ID) As [EssenceContingent_Records]

Return(@@RowCount)


