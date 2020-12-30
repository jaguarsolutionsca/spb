

Create Procedure [spS_TypeIndexation_Display]

(
 @ID [char](1) = Null -- for [TypeIndexation].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [TypeIndexation_Records].[ID1]
,[TypeIndexation_Records].[Display]

From [fnTypeIndexation_Display](@ID) As [TypeIndexation_Records]

Return(@@RowCount)


