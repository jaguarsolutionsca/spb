

Create Function [fnFactureFournisseur_Display]
(
 @ID [int] = Null
,@TypeFactureFournisseur [char](1) = Null
,@TypeFacture [char](1) = Null
,@TypeInvoiceAcomba [int] = Null
,@FournisseurID [varchar](15) = Null
,@PayerAID [varchar](15) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID] As [ID1]
,[Description] As [Display]
	
From [dbo].[FactureFournisseur]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@TypeFactureFournisseur Is Null) Or ([TypeFactureFournisseur] = @TypeFactureFournisseur))
And ((@TypeFacture Is Null) Or ([TypeFacture] = @TypeFacture))
And ((@TypeInvoiceAcomba Is Null) Or ([TypeInvoiceAcomba] = @TypeInvoiceAcomba))
And ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))
And ((@PayerAID Is Null) Or ([PayerAID] = @PayerAID))

Order By [Display]
)


