

Create Procedure [spS_FactureStatus_Display]

(
 @ID [varchar](15) = Null -- for [FactureStatus].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [FactureStatus_Records].[ID1]
,[FactureStatus_Records].[Display]

From [fnFactureStatus_Display](@ID) As [FactureStatus_Records]

Return(@@RowCount)


