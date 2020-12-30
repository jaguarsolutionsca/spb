

Create Procedure [spS_Pays_Display]

(
 @ID [varchar](2) = Null -- for [Pays].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Pays_Records].[ID1]
,[Pays_Records].[Display]

From [fnPays_Display](@ID) As [Pays_Records]

Return(@@RowCount)


