

Create Procedure [spS_MRCCorrection_Display]


-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [MRCCorrection_Records].[Display]

From [fnMRCCorrection_Display]() As [MRCCorrection_Records]

Return(@@RowCount)


