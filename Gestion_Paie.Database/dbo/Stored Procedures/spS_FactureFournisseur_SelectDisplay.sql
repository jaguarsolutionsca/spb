

Create Procedure [spS_FactureFournisseur_SelectDisplay]

-- Retrieve specific records from the [FactureFournisseur] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [FactureFournisseur].[ID] column
,@TypeFactureFournisseur [char](1) = Null -- for [FactureFournisseur].[TypeFactureFournisseur] column
,@TypeFacture [char](1) = Null -- for [FactureFournisseur].[TypeFacture] column
,@TypeInvoiceAcomba [int] = Null -- for [FactureFournisseur].[TypeInvoiceAcomba] column
,@FournisseurID [varchar](15) = Null -- for [FactureFournisseur].[FournisseurID] column
,@PayerAID [varchar](15) = Null -- for [FactureFournisseur].[PayerAID] column
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

		 [FactureFournisseur_Records].[ID]
		,[FactureFournisseur_Records].[NoFacture]
		,[FactureFournisseur_Records].[DateFacture]
		,[FactureFournisseur_Records].[Annee]
		,[FactureFournisseur_Records].[TypeFactureFournisseur]
		,[FactureFournisseur_Records].[TypeFactureFournisseur_Display]
		,[FactureFournisseur_Records].[TypeFacture]
		,[FactureFournisseur_Records].[TypeFacture_Display]
		,[FactureFournisseur_Records].[TypeInvoiceAcomba]
		,[FactureFournisseur_Records].[TypeInvoiceAcomba_Display]
		,[FactureFournisseur_Records].[FournisseurID]
		,[FactureFournisseur_Records].[FournisseurID_Display]
		,[FactureFournisseur_Records].[PayerAID]
		,[FactureFournisseur_Records].[PayerAID_Display]
		,[FactureFournisseur_Records].[Montant_Total]
		,[FactureFournisseur_Records].[Montant_TPS]
		,[FactureFournisseur_Records].[Montant_TVQ]
		,[FactureFournisseur_Records].[Description]
		,[FactureFournisseur_Records].[Status]
		,[FactureFournisseur_Records].[StatusDescription]
		,[FactureFournisseur_Records].[NumeroCheque]
		,[FactureFournisseur_Records].[NumeroPaiement]
		,[FactureFournisseur_Records].[NumeroPaiementUnique]
		,[FactureFournisseur_Records].[DateFactureAcomba]
		,[FactureFournisseur_Records].[DatePaiementAcomba]

		From [fnFactureFournisseur_SelectDisplay](@ID, @TypeFactureFournisseur, @TypeFacture, @TypeInvoiceAcomba, @FournisseurID, @PayerAID) As [FactureFournisseur_Records]
	End

Else

	Begin
		Select

		 [FactureFournisseur_Records].[ID]
		,[FactureFournisseur_Records].[NoFacture]
		,[FactureFournisseur_Records].[DateFacture]
		,[FactureFournisseur_Records].[Annee]
		,[FactureFournisseur_Records].[TypeFactureFournisseur]
		,[FactureFournisseur_Records].[TypeFactureFournisseur_Display]
		,[FactureFournisseur_Records].[TypeFacture]
		,[FactureFournisseur_Records].[TypeFacture_Display]
		,[FactureFournisseur_Records].[TypeInvoiceAcomba]
		,[FactureFournisseur_Records].[TypeInvoiceAcomba_Display]
		,[FactureFournisseur_Records].[FournisseurID]
		,[FactureFournisseur_Records].[FournisseurID_Display]
		,[FactureFournisseur_Records].[PayerAID]
		,[FactureFournisseur_Records].[PayerAID_Display]
		,[FactureFournisseur_Records].[Montant_Total]
		,[FactureFournisseur_Records].[Montant_TPS]
		,[FactureFournisseur_Records].[Montant_TVQ]
		,[FactureFournisseur_Records].[Description]
		,[FactureFournisseur_Records].[Status]
		,[FactureFournisseur_Records].[StatusDescription]
		,[FactureFournisseur_Records].[NumeroCheque]
		,[FactureFournisseur_Records].[NumeroPaiement]
		,[FactureFournisseur_Records].[NumeroPaiementUnique]
		,[FactureFournisseur_Records].[DateFactureAcomba]
		,[FactureFournisseur_Records].[DatePaiementAcomba]

		From [fnFactureFournisseur_SelectDisplay](@ID, @TypeFactureFournisseur, @TypeFacture, @TypeInvoiceAcomba, @FournisseurID, @PayerAID) As [FactureFournisseur_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


