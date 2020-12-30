

Create Function [fnFactureFournisseur_Sommaire_Full]

(
 @FactureID [int] = Null
,@Ligne [int] = Null
,@Compte [int] = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [FactureFournisseur_Sommaire].[FactureID]
,[FactureFournisseur_Sommaire].[Ligne]
,[FactureFournisseur_Sommaire].[Compte]
,[FactureFournisseur_Sommaire].[Montant]
,[FactureFournisseur_Sommaire].[Description]
,[FactureFournisseur_Sommaire].[isTaxe]
,[FactureFournisseur1].[ID] [FactureID_ID]
,[FactureFournisseur1].[NoFacture] [FactureID_NoFacture]
,[FactureFournisseur1].[DateFacture] [FactureID_DateFacture]
,[FactureFournisseur1].[Annee] [FactureID_Annee]
,[FactureFournisseur1].[TypeFactureFournisseur] [FactureID_TypeFactureFournisseur]
,[FactureFournisseur1].[TypeFacture] [FactureID_TypeFacture]
,[FactureFournisseur1].[TypeInvoiceAcomba] [FactureID_TypeInvoiceAcomba]
,[FactureFournisseur1].[FournisseurID] [FactureID_FournisseurID]
,[FactureFournisseur1].[PayerAID] [FactureID_PayerAID]
,[FactureFournisseur1].[Montant_Total] [FactureID_Montant_Total]
,[FactureFournisseur1].[Montant_TPS] [FactureID_Montant_TPS]
,[FactureFournisseur1].[Montant_TVQ] [FactureID_Montant_TVQ]
,[FactureFournisseur1].[Description] [FactureID_Description]
,[FactureFournisseur1].[Status] [FactureID_Status]
,[FactureFournisseur1].[StatusDescription] [FactureID_StatusDescription]
,[FactureFournisseur1].[NumeroCheque] [FactureID_NumeroCheque]
,[FactureFournisseur1].[NumeroPaiement] [FactureID_NumeroPaiement]
,[FactureFournisseur1].[NumeroPaiementUnique] [FactureID_NumeroPaiementUnique]
,[FactureFournisseur1].[DateFactureAcomba] [FactureID_DateFactureAcomba]
,[FactureFournisseur1].[DatePaiementAcomba] [FactureID_DatePaiementAcomba]
,[Compte2].[ID] [Compte_ID]
,[Compte2].[Description] [Compte_Description]
,[Compte2].[CategoryID] [Compte_CategoryID]
,[Compte2].[isTaxe] [Compte_isTaxe]
,[Compte2].[Actif] [Compte_Actif]

From [dbo].[FactureFournisseur_Sommaire] [FactureFournisseur_Sommaire]
    Inner Join [dbo].[FactureFournisseur] [FactureFournisseur1] On [FactureFournisseur_Sommaire].[FactureID] = [FactureFournisseur1].[ID]
        Left Outer Join [dbo].[Compte] [Compte2] On [FactureFournisseur_Sommaire].[Compte] = [Compte2].[ID]

Where

    ((@FactureID Is Null) Or ([FactureFournisseur_Sommaire].[FactureID] = @FactureID))
And ((@Ligne Is Null) Or ([FactureFournisseur_Sommaire].[Ligne] = @Ligne))
And ((@Compte Is Null) Or ([FactureFournisseur_Sommaire].[Compte] = @Compte))
)



