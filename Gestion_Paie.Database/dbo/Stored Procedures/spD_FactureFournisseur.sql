

Create Procedure [spD_FactureFournisseur]

-- Delete a specific record from table [FactureFournisseur]

(
 @ID [int] -- for [FactureFournisseur].[ID] column
,@TypeFactureFournisseur [char](1) = Null -- for [FactureFournisseur].[TypeFactureFournisseur] column
,@TypeFacture [char](1) = Null -- for [FactureFournisseur].[TypeFacture] column
,@TypeInvoiceAcomba [int] = Null -- for [FactureFournisseur].[TypeInvoiceAcomba] column
,@FournisseurID [varchar](15) = Null -- for [FactureFournisseur].[FournisseurID] column
,@PayerAID [varchar](15) = Null -- for [FactureFournisseur].[PayerAID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[FactureFournisseur]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@TypeFactureFournisseur Is Null) Or ([TypeFactureFournisseur] = @TypeFactureFournisseur))
And ((@TypeFacture Is Null) Or ([TypeFacture] = @TypeFacture))
And ((@TypeInvoiceAcomba Is Null) Or ([TypeInvoiceAcomba] = @TypeInvoiceAcomba))
And ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))
And ((@PayerAID Is Null) Or ([PayerAID] = @PayerAID))

Set NoCount Off

Return(@@RowCount)


