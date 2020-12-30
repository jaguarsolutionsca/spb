

Create Procedure [spS_FactureClient_Sommaire_Full]

/*
Retrieve specific records from the [FactureClient_Sommaire] table, as well as all its foreign tables, depending on the input parameters you supply:
	[FactureClient] (via [FactureID])
	[Compte] (via [Compte])
*/

(
 @FactureID [int] = Null -- for [FactureClient_Sommaire].[FactureID] column
,@Ligne [int] = Null -- for [FactureClient_Sommaire].[Ligne] column
,@Compte [int] = Null -- for [FactureClient_Sommaire].[Compte] column
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

		 [FactureClient_Sommaire_Records].[FactureID]
		,[FactureClient_Sommaire_Records].[Ligne]
		,[FactureClient_Sommaire_Records].[Compte]
		,[FactureClient_Sommaire_Records].[Montant]
		,[FactureClient_Sommaire_Records].[Description]
		,[FactureClient_Sommaire_Records].[isTaxe]
		,[FactureClient_Sommaire_Records].[Compte_ID]
		,[FactureClient_Sommaire_Records].[Compte_Description]
		,[FactureClient_Sommaire_Records].[Compte_CategoryID]
		,[FactureClient_Sommaire_Records].[Compte_isTaxe]
		,[FactureClient_Sommaire_Records].[Compte_Actif]

		From [fnFactureClient_Sommaire_Full](@FactureID, @Ligne, @Compte) As [FactureClient_Sommaire_Records]
	End

Else

	Begin
		Select

		 [FactureClient_Sommaire_Records].[FactureID]
		,[FactureClient_Sommaire_Records].[Ligne]
		,[FactureClient_Sommaire_Records].[Compte]
		,[FactureClient_Sommaire_Records].[Montant]
		,[FactureClient_Sommaire_Records].[Description]
		,[FactureClient_Sommaire_Records].[isTaxe]
		,[FactureClient_Sommaire_Records].[Compte_ID]
		,[FactureClient_Sommaire_Records].[Compte_Description]
		,[FactureClient_Sommaire_Records].[Compte_CategoryID]
		,[FactureClient_Sommaire_Records].[Compte_isTaxe]
		,[FactureClient_Sommaire_Records].[Compte_Actif]

		From [fnFactureClient_Sommaire_Full](@FactureID, @Ligne, @Compte) As [FactureClient_Sommaire_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


