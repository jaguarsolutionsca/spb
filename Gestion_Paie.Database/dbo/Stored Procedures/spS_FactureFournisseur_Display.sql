

Create Procedure [spS_FactureFournisseur_Display]

(
 @ID [int] = Null -- for [FactureFournisseur].[ID] column
,@TypeFactureFournisseur [char](1) = Null -- for [FactureFournisseur].[TypeFactureFournisseur] column
,@TypeFacture [char](1) = Null -- for [FactureFournisseur].[TypeFacture] column
,@TypeInvoiceAcomba [int] = Null -- for [FactureFournisseur].[TypeInvoiceAcomba] column
,@FournisseurID [varchar](15) = Null -- for [FactureFournisseur].[FournisseurID] column
,@PayerAID [varchar](15) = Null -- for [FactureFournisseur].[PayerAID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [FactureFournisseur_Records].[ID1]
,[FactureFournisseur_Records].[Display]

From [fnFactureFournisseur_Display](@ID, @TypeFactureFournisseur, @TypeFacture, @TypeInvoiceAcomba, @FournisseurID, @PayerAID) As [FactureFournisseur_Records]

Return(@@RowCount)


