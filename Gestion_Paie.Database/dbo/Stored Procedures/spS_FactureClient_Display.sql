

Create Procedure [spS_FactureClient_Display]

(
 @ID [int] = Null -- for [FactureClient].[ID] column
,@TypeFacture [char](1) = Null -- for [FactureClient].[TypeFacture] column
,@TypeInvoiceClientAcomba [int] = Null -- for [FactureClient].[TypeInvoiceClientAcomba] column
,@ClientID [varchar](6) = Null -- for [FactureClient].[ClientID] column
,@PayerAID [varchar](6) = Null -- for [FactureClient].[PayerAID] column
,@Status [varchar](15) = Null -- for [FactureClient].[Status] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [FactureClient_Records].[ID1]
,[FactureClient_Records].[Display]

From [fnFactureClient_Display](@ID, @TypeFacture, @TypeInvoiceClientAcomba, @ClientID, @PayerAID, @Status) As [FactureClient_Records]

Return(@@RowCount)


