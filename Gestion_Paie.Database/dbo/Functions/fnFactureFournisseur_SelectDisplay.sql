

Create Function [fnFactureFournisseur_SelectDisplay]
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
Select
	 [FactureFournisseur].[ID]
	,[FactureFournisseur].[NoFacture]
	,[FactureFournisseur].[DateFacture]
	,[FactureFournisseur].[Annee]
	,[FactureFournisseur].[TypeFactureFournisseur]
	,[TypeFactureFournisseur1].[Display] [TypeFactureFournisseur_Display]
	,[FactureFournisseur].[TypeFacture]
	,[TypeFacture2].[Display] [TypeFacture_Display]
	,[FactureFournisseur].[TypeInvoiceAcomba]
	,[TypeInvoiceAcomba3].[Display] [TypeInvoiceAcomba_Display]
	,[FactureFournisseur].[FournisseurID]
	,[Fournisseur4].[Display] [FournisseurID_Display]
	,[FactureFournisseur].[PayerAID]
	,[Fournisseur5].[Display] [PayerAID_Display]
	,[FactureFournisseur].[Montant_Total]
	,[FactureFournisseur].[Montant_TPS]
	,[FactureFournisseur].[Montant_TVQ]
	,[FactureFournisseur].[Description]
	,[FactureFournisseur].[Status]
	,[FactureFournisseur].[StatusDescription]
	,[FactureFournisseur].[NumeroCheque]
	,[FactureFournisseur].[NumeroPaiement]
	,[FactureFournisseur].[NumeroPaiementUnique]
	,[FactureFournisseur].[DateFactureAcomba]
	,[FactureFournisseur].[DatePaiementAcomba]

From [dbo].[FactureFournisseur]
    Left Outer Join [fnTypeFactureFournisseur_Display](Null) [TypeFactureFournisseur1] On [TypeFactureFournisseur] = [TypeFactureFournisseur1].[ID1]
        Left Outer Join [fnTypeFacture_Display](Null) [TypeFacture2] On [TypeFacture] = [TypeFacture2].[ID1]
            Left Outer Join [fnTypeInvoiceAcomba_Display](Null) [TypeInvoiceAcomba3] On [TypeInvoiceAcomba] = [TypeInvoiceAcomba3].[ID1]
                Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur4] On [FournisseurID] = [Fournisseur4].[ID1]
                    Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur5] On [PayerAID] = [Fournisseur5].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@TypeFactureFournisseur Is Null) Or ([TypeFactureFournisseur] = @TypeFactureFournisseur))
And ((@TypeFacture Is Null) Or ([TypeFacture] = @TypeFacture))
And ((@TypeInvoiceAcomba Is Null) Or ([TypeInvoiceAcomba] = @TypeInvoiceAcomba))
And ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))
And ((@PayerAID Is Null) Or ([PayerAID] = @PayerAID))
)


