

Create Function [fnFactureFournisseur]
(
 @ID [int] = Null
,@TypeFactureFournisseur [char](1) = Null
,@TypeFacture [char](1) = Null
,@TypeInvoiceAcomba [int] = Null
,@FournisseurID [varchar](15) = Null
,@PayerAID [varchar](15) = Null
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
,[TypeFactureFournisseur]
,[TypeFacture]
,[TypeInvoiceAcomba]
,[FournisseurID]
,[PayerAID]
,[Montant_Total]
,[Montant_TPS]
,[Montant_TVQ]
,[Description]
,[Status]
,[StatusDescription]
,[NumeroCheque]
,[NumeroPaiement]
,[NumeroPaiementUnique]
,[DateFactureAcomba]
,[DatePaiementAcomba]

From [dbo].[FactureFournisseur]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@TypeFactureFournisseur Is Null) Or ([TypeFactureFournisseur] = @TypeFactureFournisseur))
And ((@TypeFacture Is Null) Or ([TypeFacture] = @TypeFacture))
And ((@TypeInvoiceAcomba Is Null) Or ([TypeInvoiceAcomba] = @TypeInvoiceAcomba))
And ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))
And ((@PayerAID Is Null) Or ([PayerAID] = @PayerAID))
)


