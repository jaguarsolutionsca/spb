

Create Procedure [spS_UniteMesure_Display]

(
 @ID [varchar](6) = Null -- for [UniteMesure].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [UniteMesure_Records].[ID1]
,[UniteMesure_Records].[Display]

From [fnUniteMesure_Display](@ID) As [UniteMesure_Records]

Return(@@RowCount)


