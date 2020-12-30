

Create Procedure [spS_Ajustement_Display]

(
 @ID [int] = Null -- for [Ajustement].[ID] column
,@ContratID [varchar](10) = Null -- for [Ajustement].[ContratID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Ajustement_Records].[ID1]
,[Ajustement_Records].[Display]

From [fnAjustement_Display](@ID, @ContratID) As [Ajustement_Records]

Return(@@RowCount)


