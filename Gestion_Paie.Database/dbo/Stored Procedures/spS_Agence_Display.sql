

Create Procedure [spS_Agence_Display]

(
 @ID [varchar](4) = Null -- for [Agence].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Agence_Records].[ID1]
,[Agence_Records].[Display]

From [fnAgence_Display](@ID) As [Agence_Records]

Return(@@RowCount)


