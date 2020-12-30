

Create Procedure [spS_FactureFournisseur_Details_Full]

/*
Retrieve specific records from the [FactureFournisseur_Details] table, as well as all its foreign tables, depending on the input parameters you supply:
	[FactureFournisseur] (via [FactureID])
	[Compte] (via [Compte])
*/

(
 @FactureID [int] = Null -- for [FactureFournisseur_Details].[FactureID] column
,@Ligne [int] = Null -- for [FactureFournisseur_Details].[Ligne] column
,@Compte [int] = Null -- for [FactureFournisseur_Details].[Compte] column
,@ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [FactureFournisseur_Details_Records].[FactureID]
		,[FactureFournisseur_Details_Records].[Ligne]
		,[FactureFournisseur_Details_Records].[Compte]
		,[FactureFournisseur_Details_Records].[Montant]
		,[FactureFournisseur_Details_Records].[RefID]
		,[FactureFournisseur_Details_Records].[Compte_ID]
		,[FactureFournisseur_Details_Records].[Compte_Description]
		,[FactureFournisseur_Details_Records].[Compte_CategoryID]
		,[FactureFournisseur_Details_Records].[Compte_isTaxe]
		,[FactureFournisseur_Details_Records].[Compte_Actif]

		From [fnFactureFournisseur_Details_Full](@FactureID, @Ligne, @Compte) As [FactureFournisseur_Details_Records]
	End

Else

	Begin
		Select

		 [FactureFournisseur_Details_Records].[FactureID]
		,[FactureFournisseur_Details_Records].[Ligne]
		,[FactureFournisseur_Details_Records].[Compte]
		,[FactureFournisseur_Details_Records].[Montant]
		,[FactureFournisseur_Details_Records].[RefID]
		,[FactureFournisseur_Details_Records].[Compte_ID]
		,[FactureFournisseur_Details_Records].[Compte_Description]
		,[FactureFournisseur_Details_Records].[Compte_CategoryID]
		,[FactureFournisseur_Details_Records].[Compte_isTaxe]
		,[FactureFournisseur_Details_Records].[Compte_Actif]

		From [fnFactureFournisseur_Details_Full](@FactureID, @Ligne, @Compte) As [FactureFournisseur_Details_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


