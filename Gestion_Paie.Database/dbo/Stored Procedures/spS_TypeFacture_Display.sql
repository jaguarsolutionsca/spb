

Create Procedure [spS_TypeFacture_Display]

(
 @ID [char](1) = Null -- for [TypeFacture].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [TypeFacture_Records].[ID1]
,[TypeFacture_Records].[Display]

From [fnTypeFacture_Display](@ID) As [TypeFacture_Records]

Return(@@RowCount)


