

Create Procedure [spS_FactureFournisseur_Sommaire]

-- Retrieve specific records from the [FactureFournisseur_Sommaire] table depending on the input parameters you supply.

(
 @FactureID [int] = Null -- for [FactureFournisseur_Sommaire].[FactureID] column
,@Ligne [int] = Null -- for [FactureFournisseur_Sommaire].[Ligne] column
,@Compte [int] = Null -- for [FactureFournisseur_Sommaire].[Compte] column
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

		 [FactureFournisseur_Sommaire_Records].[FactureID]
		,[FactureFournisseur_Sommaire_Records].[Ligne]
		,[FactureFournisseur_Sommaire_Records].[Compte]
		,[FactureFournisseur_Sommaire_Records].[Montant]
		,[FactureFournisseur_Sommaire_Records].[Description]
		,[FactureFournisseur_Sommaire_Records].[isTaxe]

		From [fnFactureFournisseur_Sommaire](@FactureID, @Ligne, @Compte) As [FactureFournisseur_Sommaire_Records]
	End

Else

	Begin
		Select

		 [FactureFournisseur_Sommaire_Records].[FactureID]
		,[FactureFournisseur_Sommaire_Records].[Ligne]
		,[FactureFournisseur_Sommaire_Records].[Compte]
		,[FactureFournisseur_Sommaire_Records].[Montant]
		,[FactureFournisseur_Sommaire_Records].[Description]
		,[FactureFournisseur_Sommaire_Records].[isTaxe]

		From [fnFactureFournisseur_Sommaire](@FactureID, @Ligne, @Compte) As [FactureFournisseur_Sommaire_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


