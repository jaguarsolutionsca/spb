

Create Function [fnFactureFournisseur_Full]

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
 [FactureFournisseur].[ID]
,[FactureFournisseur].[NoFacture]
,[FactureFournisseur].[DateFacture]
,[FactureFournisseur].[Annee]
,[FactureFournisseur].[TypeFactureFournisseur]
,[FactureFournisseur].[TypeFacture]
,[FactureFournisseur].[TypeInvoiceAcomba]
,[FactureFournisseur].[FournisseurID]
,[FactureFournisseur].[PayerAID]
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
,[TypeFactureFournisseur1].[ID] [TypeFactureFournisseur_ID]
,[TypeFactureFournisseur1].[Description] [TypeFactureFournisseur_Description]
,[TypeFacture2].[ID] [TypeFacture_ID]
,[TypeFacture2].[Description] [TypeFacture_Description]
,[TypeFacture2].[FactureDescriptionMask] [TypeFacture_FactureDescriptionMask]
,[TypeInvoiceAcomba3].[ID] [TypeInvoiceAcomba_ID]
,[TypeInvoiceAcomba3].[Description] [TypeInvoiceAcomba_Description]
,[Fournisseur4].[ID] [FournisseurID_ID]
,[Fournisseur4].[CleTri] [FournisseurID_CleTri]
,[Fournisseur4].[Nom] [FournisseurID_Nom]
,[Fournisseur4].[AuSoinsDe] [FournisseurID_AuSoinsDe]
,[Fournisseur4].[Rue] [FournisseurID_Rue]
,[Fournisseur4].[Ville] [FournisseurID_Ville]
,[Fournisseur4].[PaysID] [FournisseurID_PaysID]
,[Fournisseur4].[Code_postal] [FournisseurID_Code_postal]
,[Fournisseur4].[Telephone] [FournisseurID_Telephone]
,[Fournisseur4].[Telephone_Poste] [FournisseurID_Telephone_Poste]
,[Fournisseur4].[Telecopieur] [FournisseurID_Telecopieur]
,[Fournisseur4].[Telephone2] [FournisseurID_Telephone2]
,[Fournisseur4].[Telephone2_Desc] [FournisseurID_Telephone2_Desc]
,[Fournisseur4].[Telephone2_Poste] [FournisseurID_Telephone2_Poste]
,[Fournisseur4].[Telephone3] [FournisseurID_Telephone3]
,[Fournisseur4].[Telephone3_Desc] [FournisseurID_Telephone3_Desc]
,[Fournisseur4].[Telephone3_Poste] [FournisseurID_Telephone3_Poste]
,[Fournisseur4].[No_membre] [FournisseurID_No_membre]
,[Fournisseur4].[Resident] [FournisseurID_Resident]
,[Fournisseur4].[Email] [FournisseurID_Email]
,[Fournisseur4].[WWW] [FournisseurID_WWW]
,[Fournisseur4].[Commentaires] [FournisseurID_Commentaires]
,[Fournisseur4].[AfficherCommentaires] [FournisseurID_AfficherCommentaires]
,[Fournisseur4].[DepotDirect] [FournisseurID_DepotDirect]
,[Fournisseur4].[InstitutionBanquaireID] [FournisseurID_InstitutionBanquaireID]
,[Fournisseur4].[Banque_transit] [FournisseurID_Banque_transit]
,[Fournisseur4].[Banque_folio] [FournisseurID_Banque_folio]
,[Fournisseur4].[No_TPS] [FournisseurID_No_TPS]
,[Fournisseur4].[No_TVQ] [FournisseurID_No_TVQ]
,[Fournisseur4].[PayerA] [FournisseurID_PayerA]
,[Fournisseur4].[PayerAID] [FournisseurID_PayerAID]
,[Fournisseur4].[Statut] [FournisseurID_Statut]
,[Fournisseur4].[Rep_Nom] [FournisseurID_Rep_Nom]
,[Fournisseur4].[Rep_Telephone] [FournisseurID_Rep_Telephone]
,[Fournisseur4].[Rep_Telephone_Poste] [FournisseurID_Rep_Telephone_Poste]
,[Fournisseur4].[Rep_Email] [FournisseurID_Rep_Email]
,[Fournisseur4].[EnAnglais] [FournisseurID_EnAnglais]
,[Fournisseur4].[Actif] [FournisseurID_Actif]
,[Fournisseur4].[MRCProducteurID] [FournisseurID_MRCProducteurID]
,[Fournisseur4].[PaiementManuel] [FournisseurID_PaiementManuel]
,[Fournisseur4].[Journal] [FournisseurID_Journal]
,[Fournisseur4].[RecoitTPS] [FournisseurID_RecoitTPS]
,[Fournisseur4].[RecoitTVQ] [FournisseurID_RecoitTVQ]
,[Fournisseur4].[ModifierTrigger] [FournisseurID_ModifierTrigger]
,[Fournisseur4].[IsProducteur] [FournisseurID_IsProducteur]
,[Fournisseur4].[IsTransporteur] [FournisseurID_IsTransporteur]
,[Fournisseur4].[IsChargeur] [FournisseurID_IsChargeur]
,[Fournisseur4].[IsAutre] [FournisseurID_IsAutre]
,[Fournisseur4].[AfficherCommentairesSurPermit] [FournisseurID_AfficherCommentairesSurPermit]
,[Fournisseur4].[PasEmissionPermis] [FournisseurID_PasEmissionPermis]
,[Fournisseur4].[Generique] [FournisseurID_Generique]
,[Fournisseur5].[ID] [PayerAID_ID]
,[Fournisseur5].[CleTri] [PayerAID_CleTri]
,[Fournisseur5].[Nom] [PayerAID_Nom]
,[Fournisseur5].[AuSoinsDe] [PayerAID_AuSoinsDe]
,[Fournisseur5].[Rue] [PayerAID_Rue]
,[Fournisseur5].[Ville] [PayerAID_Ville]
,[Fournisseur5].[PaysID] [PayerAID_PaysID]
,[Fournisseur5].[Code_postal] [PayerAID_Code_postal]
,[Fournisseur5].[Telephone] [PayerAID_Telephone]
,[Fournisseur5].[Telephone_Poste] [PayerAID_Telephone_Poste]
,[Fournisseur5].[Telecopieur] [PayerAID_Telecopieur]
,[Fournisseur5].[Telephone2] [PayerAID_Telephone2]
,[Fournisseur5].[Telephone2_Desc] [PayerAID_Telephone2_Desc]
,[Fournisseur5].[Telephone2_Poste] [PayerAID_Telephone2_Poste]
,[Fournisseur5].[Telephone3] [PayerAID_Telephone3]
,[Fournisseur5].[Telephone3_Desc] [PayerAID_Telephone3_Desc]
,[Fournisseur5].[Telephone3_Poste] [PayerAID_Telephone3_Poste]
,[Fournisseur5].[No_membre] [PayerAID_No_membre]
,[Fournisseur5].[Resident] [PayerAID_Resident]
,[Fournisseur5].[Email] [PayerAID_Email]
,[Fournisseur5].[WWW] [PayerAID_WWW]
,[Fournisseur5].[Commentaires] [PayerAID_Commentaires]
,[Fournisseur5].[AfficherCommentaires] [PayerAID_AfficherCommentaires]
,[Fournisseur5].[DepotDirect] [PayerAID_DepotDirect]
,[Fournisseur5].[InstitutionBanquaireID] [PayerAID_InstitutionBanquaireID]
,[Fournisseur5].[Banque_transit] [PayerAID_Banque_transit]
,[Fournisseur5].[Banque_folio] [PayerAID_Banque_folio]
,[Fournisseur5].[No_TPS] [PayerAID_No_TPS]
,[Fournisseur5].[No_TVQ] [PayerAID_No_TVQ]
,[Fournisseur5].[PayerA] [PayerAID_PayerA]
,[Fournisseur5].[PayerAID] [PayerAID_PayerAID]
,[Fournisseur5].[Statut] [PayerAID_Statut]
,[Fournisseur5].[Rep_Nom] [PayerAID_Rep_Nom]
,[Fournisseur5].[Rep_Telephone] [PayerAID_Rep_Telephone]
,[Fournisseur5].[Rep_Telephone_Poste] [PayerAID_Rep_Telephone_Poste]
,[Fournisseur5].[Rep_Email] [PayerAID_Rep_Email]
,[Fournisseur5].[EnAnglais] [PayerAID_EnAnglais]
,[Fournisseur5].[Actif] [PayerAID_Actif]
,[Fournisseur5].[MRCProducteurID] [PayerAID_MRCProducteurID]
,[Fournisseur5].[PaiementManuel] [PayerAID_PaiementManuel]
,[Fournisseur5].[Journal] [PayerAID_Journal]
,[Fournisseur5].[RecoitTPS] [PayerAID_RecoitTPS]
,[Fournisseur5].[RecoitTVQ] [PayerAID_RecoitTVQ]
,[Fournisseur5].[ModifierTrigger] [PayerAID_ModifierTrigger]
,[Fournisseur5].[IsProducteur] [PayerAID_IsProducteur]
,[Fournisseur5].[IsTransporteur] [PayerAID_IsTransporteur]
,[Fournisseur5].[IsChargeur] [PayerAID_IsChargeur]
,[Fournisseur5].[IsAutre] [PayerAID_IsAutre]
,[Fournisseur5].[AfficherCommentairesSurPermit] [PayerAID_AfficherCommentairesSurPermit]
,[Fournisseur5].[PasEmissionPermis] [PayerAID_PasEmissionPermis]
,[Fournisseur5].[Generique] [PayerAID_Generique]

From [dbo].[FactureFournisseur] [FactureFournisseur]
    Left Outer Join [dbo].[TypeFactureFournisseur] [TypeFactureFournisseur1] On [FactureFournisseur].[TypeFactureFournisseur] = [TypeFactureFournisseur1].[ID]
        Left Outer Join [dbo].[TypeFacture] [TypeFacture2] On [FactureFournisseur].[TypeFacture] = [TypeFacture2].[ID]
            Left Outer Join [dbo].[TypeInvoiceAcomba] [TypeInvoiceAcomba3] On [FactureFournisseur].[TypeInvoiceAcomba] = [TypeInvoiceAcomba3].[ID]
                Left Outer Join [dbo].[Fournisseur] [Fournisseur4] On [FactureFournisseur].[FournisseurID] = [Fournisseur4].[ID]
                    Left Outer Join [dbo].[Fournisseur] [Fournisseur5] On [FactureFournisseur].[PayerAID] = [Fournisseur5].[ID]

Where

    ((@ID Is Null) Or ([FactureFournisseur].[ID] = @ID))
And ((@TypeFactureFournisseur Is Null) Or ([FactureFournisseur].[TypeFactureFournisseur] = @TypeFactureFournisseur))
And ((@TypeFacture Is Null) Or ([FactureFournisseur].[TypeFacture] = @TypeFacture))
And ((@TypeInvoiceAcomba Is Null) Or ([FactureFournisseur].[TypeInvoiceAcomba] = @TypeInvoiceAcomba))
And ((@FournisseurID Is Null) Or ([FactureFournisseur].[FournisseurID] = @FournisseurID))
And ((@PayerAID Is Null) Or ([FactureFournisseur].[PayerAID] = @PayerAID))
)



