

Create Function [fnFactureClient_Sommaire_Full]

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
 [FactureClient_Sommaire].[FactureID]
,[FactureClient_Sommaire].[Ligne]
,[FactureClient_Sommaire].[Compte]
,[FactureClient_Sommaire].[Montant]
,[FactureClient_Sommaire].[Description]
,[FactureClient_Sommaire].[isTaxe]
,[FactureClient1].[ID] [FactureID_ID]
,[FactureClient1].[NoFacture] [FactureID_NoFacture]
,[FactureClient1].[DateFacture] [FactureID_DateFacture]
,[FactureClient1].[Annee] [FactureID_Annee]
,[FactureClient1].[TypeFacture] [FactureID_TypeFacture]
,[FactureClient1].[TypeInvoiceClientAcomba] [FactureID_TypeInvoiceClientAcomba]
,[FactureClient1].[ClientID] [FactureID_ClientID]
,[FactureClient1].[PayerAID] [FactureID_PayerAID]
,[FactureClient1].[Montant_Total] [FactureID_Montant_Total]
,[FactureClient1].[Montant_TPS] [FactureID_Montant_TPS]
,[FactureClient1].[Montant_TVQ] [FactureID_Montant_TVQ]
,[FactureClient1].[Description] [FactureID_Description]
,[FactureClient1].[Status] [FactureID_Status]
,[FactureClient1].[StatusDescription] [FactureID_StatusDescription]
,[FactureClient1].[DateFactureAcomba] [FactureID_DateFactureAcomba]
,[Compte2].[ID] [Compte_ID]
,[Compte2].[Description] [Compte_Description]
,[Compte2].[CategoryID] [Compte_CategoryID]
,[Compte2].[isTaxe] [Compte_isTaxe]
,[Compte2].[Actif] [Compte_Actif]

From [dbo].[FactureClient_Sommaire] [FactureClient_Sommaire]
    Inner Join [dbo].[FactureClient] [FactureClient1] On [FactureClient_Sommaire].[FactureID] = [FactureClient1].[ID]
        Left Outer Join [dbo].[Compte] [Compte2] On [FactureClient_Sommaire].[Compte] = [Compte2].[ID]

Where

    ((@FactureID Is Null) Or ([FactureClient_Sommaire].[FactureID] = @FactureID))
And ((@Ligne Is Null) Or ([FactureClient_Sommaire].[Ligne] = @Ligne))
And ((@Compte Is Null) Or ([FactureClient_Sommaire].[Compte] = @Compte))
)



