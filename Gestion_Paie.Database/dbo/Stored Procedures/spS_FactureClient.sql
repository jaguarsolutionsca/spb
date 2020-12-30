

Create Procedure [spS_FactureClient]

-- Retrieve specific records from the [FactureClient] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [FactureClient].[ID] column
,@TypeFacture [char](1) = Null -- for [FactureClient].[TypeFacture] column
,@TypeInvoiceClientAcomba [int] = Null -- for [FactureClient].[TypeInvoiceClientAcomba] column
,@ClientID [varchar](6) = Null -- for [FactureClient].[ClientID] column
,@PayerAID [varchar](6) = Null -- for [FactureClient].[PayerAID] column
,@Status [varchar](15) = Null -- for [FactureClient].[Status] column
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

		 [FactureClient_Records].[ID]
		,[FactureClient_Records].[NoFacture]
		,[FactureClient_Records].[DateFacture]
		,[FactureClient_Records].[Annee]
		,[FactureClient_Records].[TypeFacture]
		,[FactureClient_Records].[TypeInvoiceClientAcomba]
		,[FactureClient_Records].[ClientID]
		,[FactureClient_Records].[PayerAID]
		,[FactureClient_Records].[Montant_Total]
		,[FactureClient_Records].[Montant_TPS]
		,[FactureClient_Records].[Montant_TVQ]
		,[FactureClient_Records].[Description]
		,[FactureClient_Records].[Status]
		,[FactureClient_Records].[StatusDescription]
		,[FactureClient_Records].[DateFactureAcomba]

		From [fnFactureClient](@ID, @TypeFacture, @TypeInvoiceClientAcomba, @ClientID, @PayerAID, @Status) As [FactureClient_Records]
	End

Else

	Begin
		Select

		 [FactureClient_Records].[ID]
		,[FactureClient_Records].[NoFacture]
		,[FactureClient_Records].[DateFacture]
		,[FactureClient_Records].[Annee]
		,[FactureClient_Records].[TypeFacture]
		,[FactureClient_Records].[TypeInvoiceClientAcomba]
		,[FactureClient_Records].[ClientID]
		,[FactureClient_Records].[PayerAID]
		,[FactureClient_Records].[Montant_Total]
		,[FactureClient_Records].[Montant_TPS]
		,[FactureClient_Records].[Montant_TVQ]
		,[FactureClient_Records].[Description]
		,[FactureClient_Records].[Status]
		,[FactureClient_Records].[StatusDescription]
		,[FactureClient_Records].[DateFactureAcomba]

		From [fnFactureClient](@ID, @TypeFacture, @TypeInvoiceClientAcomba, @ClientID, @PayerAID, @Status) As [FactureClient_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


