

Create Procedure [spS_FactureFournisseur_Details_Display]

(
 @FactureID [int] = Null -- for [FactureFournisseur_Details].[FactureID] column
,@Ligne [int] = Null -- for [FactureFournisseur_Details].[Ligne] column
,@Compte [int] = Null -- for [FactureFournisseur_Details].[Compte] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [FactureFournisseur_Details_Records].[ID1]
,[FactureFournisseur_Details_Records].[ID2]
,[FactureFournisseur_Details_Records].[Display]

From [fnFactureFournisseur_Details_Display](@FactureID, @Ligne, @Compte) As [FactureFournisseur_Details_Records]

Return(@@RowCount)


