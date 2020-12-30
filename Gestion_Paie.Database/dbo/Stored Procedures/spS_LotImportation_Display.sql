

Create Procedure [spS_LotImportation_Display]


-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [LotImportation_Records].[Display]

From [fnLotImportation_Display]() As [LotImportation_Records]

Return(@@RowCount)


