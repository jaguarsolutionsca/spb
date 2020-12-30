

Create Function [fnFactureClient]
(
 @ID [int] = Null
,@TypeFacture [char](1) = Null
,@TypeInvoiceClientAcomba [int] = Null
,@ClientID [varchar](6) = Null
,@PayerAID [varchar](6) = Null
,@Status [varchar](15) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID]
,[NoFacture]
,[DateFacture]
,[Annee]
,[TypeFacture]
,[TypeInvoiceClientAcomba]
,[ClientID]
,[PayerAID]
,[Montant_Total]
,[Montant_TPS]
,[Montant_TVQ]
,[Description]
,[Status]
,[StatusDescription]
,[DateFactureAcomba]

From [dbo].[FactureClient]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@TypeFacture Is Null) Or ([TypeFacture] = @TypeFacture))
And ((@TypeInvoiceClientAcomba Is Null) Or ([TypeInvoiceClientAcomba] = @TypeInvoiceClientAcomba))
And ((@ClientID Is Null) Or ([ClientID] = @ClientID))
And ((@PayerAID Is Null) Or ([PayerAID] = @PayerAID))
And ((@Status Is Null) Or ([Status] = @Status))
)


