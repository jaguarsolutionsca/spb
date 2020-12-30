

Create Procedure [spS_CompteCategory_Display]

(
 @ID [int] = Null -- for [CompteCategory].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [CompteCategory_Records].[ID1]
,[CompteCategory_Records].[Display]

From [fnCompteCategory_Display](@ID) As [CompteCategory_Records]

Return(@@RowCount)


