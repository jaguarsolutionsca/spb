

Create Procedure [spS_Canton_Display]

(
 @ID [varchar](6) = Null -- for [Canton].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Canton_Records].[ID1]
,[Canton_Records].[Display]

From [fnCanton_Display](@ID) As [Canton_Records]

Return(@@RowCount)


