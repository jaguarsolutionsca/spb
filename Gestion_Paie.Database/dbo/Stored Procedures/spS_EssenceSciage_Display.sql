

Create Procedure [spS_EssenceSciage_Display]

(
 @ID [int] = Null -- for [EssenceSciage].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [EssenceSciage_Records].[ID1]
,[EssenceSciage_Records].[Display]

From [fnEssenceSciage_Display](@ID) As [EssenceSciage_Records]

Return(@@RowCount)


