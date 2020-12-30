

Create Procedure [spS_UsineUtilisation_Display]

(
 @ID [int] = Null -- for [UsineUtilisation].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [UsineUtilisation_Records].[ID1]
,[UsineUtilisation_Records].[Display]

From [fnUsineUtilisation_Display](@ID) As [UsineUtilisation_Records]

Return(@@RowCount)


