

Create Procedure [spS_FactureUsine_Display]

(
 @ID [int] = Null -- for [FactureUsine].[ID] column
,@Annee [int] = Null -- for [FactureUsine].[Annee] column
,@Periode [int] = Null -- for [FactureUsine].[Periode] column
,@ContratID [varchar](10) = Null -- for [FactureUsine].[ContratID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [FactureUsine_Records].[ID1]
,[FactureUsine_Records].[Display]

From [fnFactureUsine_Display](@ID, @Annee, @Periode, @ContratID) As [FactureUsine_Records]

Return(@@RowCount)


