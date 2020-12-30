

Create Function [fnFactureClient_Full]

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
 [FactureClient].[ID]
,[FactureClient].[NoFacture]
,[FactureClient].[DateFacture]
,[FactureClient].[Annee]
,[FactureClient].[TypeFacture]
,[FactureClient].[TypeInvoiceClientAcomba]
,[FactureClient].[ClientID]
,[FactureClient].[PayerAID]
,[FactureClient].[Montant_Total]
,[FactureClient].[Montant_TPS]
,[FactureClient].[Montant_TVQ]
,[FactureClient].[Description]
,[FactureClient].[Status]
,[FactureClient].[StatusDescription]
,[FactureClient].[DateFactureAcomba]
,[TypeFacture1].[ID] [TypeFacture_ID]
,[TypeFacture1].[Description] [TypeFacture_Description]
,[TypeFacture1].[FactureDescriptionMask] [TypeFacture_FactureDescriptionMask]
,[TypeInvoiceClientAcomba2].[ID] [TypeInvoiceClientAcomba_ID]
,[TypeInvoiceClientAcomba2].[Description] [TypeInvoiceClientAcomba_Description]
,[Usine3].[ID] [ClientID_ID]
,[Usine3].[Description] [ClientID_Description]
,[Usine3].[UtilisationID] [ClientID_UtilisationID]
,[Usine3].[Paye_producteur] [ClientID_Paye_producteur]
,[Usine3].[Paye_transporteur] [ClientID_Paye_transporteur]
,[Usine3].[Specification] [ClientID_Specification]
,[Usine3].[Compte_a_recevoir] [ClientID_Compte_a_recevoir]
,[Usine3].[Compte_ajustement] [ClientID_Compte_ajustement]
,[Usine3].[Compte_transporteur] [ClientID_Compte_transporteur]
,[Usine3].[Compte_producteur] [ClientID_Compte_producteur]
,[Usine3].[Compte_preleve_plan_conjoint] [ClientID_Compte_preleve_plan_conjoint]
,[Usine3].[Compte_preleve_fond_roulement] [ClientID_Compte_preleve_fond_roulement]
,[Usine3].[Compte_preleve_fond_forestier] [ClientID_Compte_preleve_fond_forestier]
,[Usine3].[Compte_preleve_divers] [ClientID_Compte_preleve_divers]
,[Usine3].[Compte_mise_en_commun] [ClientID_Compte_mise_en_commun]
,[Usine3].[Compte_surcharge] [ClientID_Compte_surcharge]
,[Usine3].[Compte_indexation_carburant] [ClientID_Compte_indexation_carburant]
,[Usine3].[Actif] [ClientID_Actif]
,[Usine3].[NePaiePasTPS] [ClientID_NePaiePasTPS]
,[Usine3].[NePaiePasTVQ] [ClientID_NePaiePasTVQ]
,[Usine3].[NoTPS] [ClientID_NoTPS]
,[Usine3].[NoTVQ] [ClientID_NoTVQ]
,[Usine3].[Compte_chargeur] [ClientID_Compte_chargeur]
,[Usine3].[UsineGestionVolume] [ClientID_UsineGestionVolume]
,[Usine3].[AuSoinsDe] [ClientID_AuSoinsDe]
,[Usine3].[Rue] [ClientID_Rue]
,[Usine3].[Ville] [ClientID_Ville]
,[Usine3].[PaysID] [ClientID_PaysID]
,[Usine3].[Code_postal] [ClientID_Code_postal]
,[Usine3].[Telephone] [ClientID_Telephone]
,[Usine3].[Telephone_Poste] [ClientID_Telephone_Poste]
,[Usine3].[Telecopieur] [ClientID_Telecopieur]
,[Usine3].[Telephone2] [ClientID_Telephone2]
,[Usine3].[Telephone2_Desc] [ClientID_Telephone2_Desc]
,[Usine3].[Telephone2_Poste] [ClientID_Telephone2_Poste]
,[Usine3].[Telephone3] [ClientID_Telephone3]
,[Usine3].[Telephone3_Desc] [ClientID_Telephone3_Desc]
,[Usine3].[Telephone3_Poste] [ClientID_Telephone3_Poste]
,[Usine3].[Email] [ClientID_Email]
,[Usine4].[ID] [PayerAID_ID]
,[Usine4].[Description] [PayerAID_Description]
,[Usine4].[UtilisationID] [PayerAID_UtilisationID]
,[Usine4].[Paye_producteur] [PayerAID_Paye_producteur]
,[Usine4].[Paye_transporteur] [PayerAID_Paye_transporteur]
,[Usine4].[Specification] [PayerAID_Specification]
,[Usine4].[Compte_a_recevoir] [PayerAID_Compte_a_recevoir]
,[Usine4].[Compte_ajustement] [PayerAID_Compte_ajustement]
,[Usine4].[Compte_transporteur] [PayerAID_Compte_transporteur]
,[Usine4].[Compte_producteur] [PayerAID_Compte_producteur]
,[Usine4].[Compte_preleve_plan_conjoint] [PayerAID_Compte_preleve_plan_conjoint]
,[Usine4].[Compte_preleve_fond_roulement] [PayerAID_Compte_preleve_fond_roulement]
,[Usine4].[Compte_preleve_fond_forestier] [PayerAID_Compte_preleve_fond_forestier]
,[Usine4].[Compte_preleve_divers] [PayerAID_Compte_preleve_divers]
,[Usine4].[Compte_mise_en_commun] [PayerAID_Compte_mise_en_commun]
,[Usine4].[Compte_surcharge] [PayerAID_Compte_surcharge]
,[Usine4].[Compte_indexation_carburant] [PayerAID_Compte_indexation_carburant]
,[Usine4].[Actif] [PayerAID_Actif]
,[Usine4].[NePaiePasTPS] [PayerAID_NePaiePasTPS]
,[Usine4].[NePaiePasTVQ] [PayerAID_NePaiePasTVQ]
,[Usine4].[NoTPS] [PayerAID_NoTPS]
,[Usine4].[NoTVQ] [PayerAID_NoTVQ]
,[Usine4].[Compte_chargeur] [PayerAID_Compte_chargeur]
,[Usine4].[UsineGestionVolume] [PayerAID_UsineGestionVolume]
,[Usine4].[AuSoinsDe] [PayerAID_AuSoinsDe]
,[Usine4].[Rue] [PayerAID_Rue]
,[Usine4].[Ville] [PayerAID_Ville]
,[Usine4].[PaysID] [PayerAID_PaysID]
,[Usine4].[Code_postal] [PayerAID_Code_postal]
,[Usine4].[Telephone] [PayerAID_Telephone]
,[Usine4].[Telephone_Poste] [PayerAID_Telephone_Poste]
,[Usine4].[Telecopieur] [PayerAID_Telecopieur]
,[Usine4].[Telephone2] [PayerAID_Telephone2]
,[Usine4].[Telephone2_Desc] [PayerAID_Telephone2_Desc]
,[Usine4].[Telephone2_Poste] [PayerAID_Telephone2_Poste]
,[Usine4].[Telephone3] [PayerAID_Telephone3]
,[Usine4].[Telephone3_Desc] [PayerAID_Telephone3_Desc]
,[Usine4].[Telephone3_Poste] [PayerAID_Telephone3_Poste]
,[Usine4].[Email] [PayerAID_Email]
,[FactureStatus5].[ID] [Status_ID]

From [dbo].[FactureClient] [FactureClient]
    Left Outer Join [dbo].[TypeFacture] [TypeFacture1] On [FactureClient].[TypeFacture] = [TypeFacture1].[ID]
        Left Outer Join [dbo].[TypeInvoiceClientAcomba] [TypeInvoiceClientAcomba2] On [FactureClient].[TypeInvoiceClientAcomba] = [TypeInvoiceClientAcomba2].[ID]
            Left Outer Join [dbo].[Usine] [Usine3] On [FactureClient].[ClientID] = [Usine3].[ID]
                Left Outer Join [dbo].[Usine] [Usine4] On [FactureClient].[PayerAID] = [Usine4].[ID]
                    Left Outer Join [dbo].[FactureStatus] [FactureStatus5] On [FactureClient].[Status] = [FactureStatus5].[ID]

Where

    ((@ID Is Null) Or ([FactureClient].[ID] = @ID))
And ((@TypeFacture Is Null) Or ([FactureClient].[TypeFacture] = @TypeFacture))
And ((@TypeInvoiceClientAcomba Is Null) Or ([FactureClient].[TypeInvoiceClientAcomba] = @TypeInvoiceClientAcomba))
And ((@ClientID Is Null) Or ([FactureClient].[ClientID] = @ClientID))
And ((@PayerAID Is Null) Or ([FactureClient].[PayerAID] = @PayerAID))
And ((@Status Is Null) Or ([FactureClient].[Status] = @Status))
)



