

Create Procedure [spS_FactureFournisseur_Sommaire_Display]

(
 @FactureID [int] = Null -- for [FactureFournisseur_Sommaire].[FactureID] column
,@Ligne [int] = Null -- for [FactureFournisseur_Sommaire].[Ligne] column
,@Compte [int] = Null -- for [FactureFournisseur_Sommaire].[Compte] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [FactureFournisseur_Sommaire_Records].[ID1]
,[FactureFournisseur_Sommaire_Records].[ID2]
,[FactureFournisseur_Sommaire_Records].[Display]

From [fnFactureFournisseur_Sommaire_Display](@FactureID, @Ligne, @Compte) As [FactureFournisseur_Sommaire_Records]

Return(@@RowCount)


