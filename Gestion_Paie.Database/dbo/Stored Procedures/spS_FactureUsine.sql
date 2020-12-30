

Create Procedure [spS_FactureUsine]

-- Retrieve specific records from the [FactureUsine] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [FactureUsine].[ID] column
,@Annee [int] = Null -- for [FactureUsine].[Annee] column
,@Periode [int] = Null -- for [FactureUsine].[Periode] column
,@ContratID [varchar](10) = Null -- for [FactureUsine].[ContratID] column
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

		 [FactureUsine_Records].[ID]
		,[FactureUsine_Records].[DatePermis]
		,[FactureUsine_Records].[DateLivraison]
		,[FactureUsine_Records].[DatePaye]
		,[FactureUsine_Records].[Annee]
		,[FactureUsine_Records].[Periode]
		,[FactureUsine_Records].[ContratID]
		,[FactureUsine_Records].[Sciage]
		,[FactureUsine_Records].[EssenceSciage]
		,[FactureUsine_Records].[NumeroFactureUsine]
		,[FactureUsine_Records].[ProducteurID]
		,[FactureUsine_Records].[Livraison]

		From [fnFactureUsine](@ID, @Annee, @Periode, @ContratID) As [FactureUsine_Records]
	End

Else

	Begin
		Select

		 [FactureUsine_Records].[ID]
		,[FactureUsine_Records].[DatePermis]
		,[FactureUsine_Records].[DateLivraison]
		,[FactureUsine_Records].[DatePaye]
		,[FactureUsine_Records].[Annee]
		,[FactureUsine_Records].[Periode]
		,[FactureUsine_Records].[ContratID]
		,[FactureUsine_Records].[Sciage]
		,[FactureUsine_Records].[EssenceSciage]
		,[FactureUsine_Records].[NumeroFactureUsine]
		,[FactureUsine_Records].[ProducteurID]
		,[FactureUsine_Records].[Livraison]

		From [fnFactureUsine](@ID, @Annee, @Periode, @ContratID) As [FactureUsine_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


