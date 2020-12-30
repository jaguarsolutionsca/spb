

Create Procedure [spS_MRC_Display]

(
 @ID [varchar](6) = Null -- for [MRC].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [MRC_Records].[ID1]
,[MRC_Records].[Display]

From [fnMRC_Display](@ID) As [MRC_Records]

Return(@@RowCount)


