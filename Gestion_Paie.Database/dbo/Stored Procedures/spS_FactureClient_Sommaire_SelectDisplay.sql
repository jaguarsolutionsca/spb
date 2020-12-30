

Create Procedure [spS_FactureClient_Sommaire_SelectDisplay]

-- Retrieve specific records from the [FactureClient_Sommaire] table depending on the input parameters you supply.

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
		,[FactureClient_Sommaire_Records].[FactureID_Display]
		,[FactureClient_Sommaire_Records].[Ligne]
		,[FactureClient_Sommaire_Records].[Compte]
		,[FactureClient_Sommaire_Records].[Compte_Display]
		,[FactureClient_Sommaire_Records].[Montant]
		,[FactureClient_Sommaire_Records].[Description]
		,[FactureClient_Sommaire_Records].[isTaxe]

		From [fnFactureClient_Sommaire_SelectDisplay](@FactureID, @Ligne, @Compte) As [FactureClient_Sommaire_Records]
	End

Else

	Begin
		Select

		 [FactureClient_Sommaire_Records].[FactureID]
		,[FactureClient_Sommaire_Records].[FactureID_Display]
		,[FactureClient_Sommaire_Records].[Ligne]
		,[FactureClient_Sommaire_Records].[Compte]
		,[FactureClient_Sommaire_Records].[Compte_Display]
		,[FactureClient_Sommaire_Records].[Montant]
		,[FactureClient_Sommaire_Records].[Description]
		,[FactureClient_Sommaire_Records].[isTaxe]

		From [fnFactureClient_Sommaire_SelectDisplay](@FactureID, @Ligne, @Compte) As [FactureClient_Sommaire_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


