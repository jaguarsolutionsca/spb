

Create Function [fnLotContingente_Full]

(
 @LotID [int] = Null
,@Annee [int] = Null
,@FournisseurID [varchar](15) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [LotContingente].[LotID]
,[LotContingente].[Annee]
,[LotContingente].[SuperficieContingentee]
,[LotContingente].[Override]
,[LotContingente].[FournisseurID]
,[Lot1].[CantonID] [LotID_CantonID]
,[Lot1].[Rang] [LotID_Rang]
,[Lot1].[Lot] [LotID_Lot]
,[Lot1].[MunicipaliteID] [LotID_MunicipaliteID]
,[Lot1].[Superficie_total] [LotID_Superficie_total]
,[Lot1].[Superficie_boisee] [LotID_Superficie_boisee]
,[Lot1].[ProprietaireID] [LotID_ProprietaireID]
,[Lot1].[ContingentID] [LotID_ContingentID]
,[Lot1].[Contingent_Date] [LotID_Contingent_Date]
,[Lot1].[Droit_coupeID] [LotID_Droit_coupeID]
,[Lot1].[Droit_coupe_Date] [LotID_Droit_coupe_Date]
,[Lot1].[Entente_paiementID] [LotID_Entente_paiementID]
,[Lot1].[Entente_paiement_Date] [LotID_Entente_paiement_Date]
,[Lot1].[Actif] [LotID_Actif]
,[Lot1].[ID] [LotID_ID]
,[Lot1].[Sequence] [LotID_Sequence]
,[Lot1].[Partie] [LotID_Partie]
,[Lot1].[Matricule] [LotID_Matricule]
,[Lot1].[ZoneID] [LotID_ZoneID]
,[Lot1].[Secteur] [LotID_Secteur]
,[Lot1].[Cadastre] [LotID_Cadastre]
,[Fournisseur2].[ID] [FournisseurID_ID]
,[Fournisseur2].[CleTri] [FournisseurID_CleTri]
,[Fournisseur2].[Nom] [FournisseurID_Nom]
,[Fournisseur2].[AuSoinsDe] [FournisseurID_AuSoinsDe]
,[Fournisseur2].[Rue] [FournisseurID_Rue]
,[Fournisseur2].[Ville] [FournisseurID_Ville]
,[Fournisseur2].[PaysID] [FournisseurID_PaysID]
,[Fournisseur2].[Code_postal] [FournisseurID_Code_postal]
,[Fournisseur2].[Telephone] [FournisseurID_Telephone]
,[Fournisseur2].[Telephone_Poste] [FournisseurID_Telephone_Poste]
,[Fournisseur2].[Telecopieur] [FournisseurID_Telecopieur]
,[Fournisseur2].[Telephone2] [FournisseurID_Telephone2]
,[Fournisseur2].[Telephone2_Desc] [FournisseurID_Telephone2_Desc]
,[Fournisseur2].[Telephone2_Poste] [FournisseurID_Telephone2_Poste]
,[Fournisseur2].[Telephone3] [FournisseurID_Telephone3]
,[Fournisseur2].[Telephone3_Desc] [FournisseurID_Telephone3_Desc]
,[Fournisseur2].[Telephone3_Poste] [FournisseurID_Telephone3_Poste]
,[Fournisseur2].[No_membre] [FournisseurID_No_membre]
,[Fournisseur2].[Resident] [FournisseurID_Resident]
,[Fournisseur2].[Email] [FournisseurID_Email]
,[Fournisseur2].[WWW] [FournisseurID_WWW]
,[Fournisseur2].[Commentaires] [FournisseurID_Commentaires]
,[Fournisseur2].[AfficherCommentaires] [FournisseurID_AfficherCommentaires]
,[Fournisseur2].[DepotDirect] [FournisseurID_DepotDirect]
,[Fournisseur2].[InstitutionBanquaireID] [FournisseurID_InstitutionBanquaireID]
,[Fournisseur2].[Banque_transit] [FournisseurID_Banque_transit]
,[Fournisseur2].[Banque_folio] [FournisseurID_Banque_folio]
,[Fournisseur2].[No_TPS] [FournisseurID_No_TPS]
,[Fournisseur2].[No_TVQ] [FournisseurID_No_TVQ]
,[Fournisseur2].[PayerA] [FournisseurID_PayerA]
,[Fournisseur2].[PayerAID] [FournisseurID_PayerAID]
,[Fournisseur2].[Statut] [FournisseurID_Statut]
,[Fournisseur2].[Rep_Nom] [FournisseurID_Rep_Nom]
,[Fournisseur2].[Rep_Telephone] [FournisseurID_Rep_Telephone]
,[Fournisseur2].[Rep_Telephone_Poste] [FournisseurID_Rep_Telephone_Poste]
,[Fournisseur2].[Rep_Email] [FournisseurID_Rep_Email]
,[Fournisseur2].[EnAnglais] [FournisseurID_EnAnglais]
,[Fournisseur2].[Actif] [FournisseurID_Actif]
,[Fournisseur2].[MRCProducteurID] [FournisseurID_MRCProducteurID]
,[Fournisseur2].[PaiementManuel] [FournisseurID_PaiementManuel]
,[Fournisseur2].[Journal] [FournisseurID_Journal]
,[Fournisseur2].[RecoitTPS] [FournisseurID_RecoitTPS]
,[Fournisseur2].[RecoitTVQ] [FournisseurID_RecoitTVQ]
,[Fournisseur2].[ModifierTrigger] [FournisseurID_ModifierTrigger]
,[Fournisseur2].[IsProducteur] [FournisseurID_IsProducteur]
,[Fournisseur2].[IsTransporteur] [FournisseurID_IsTransporteur]
,[Fournisseur2].[IsChargeur] [FournisseurID_IsChargeur]
,[Fournisseur2].[IsAutre] [FournisseurID_IsAutre]
,[Fournisseur2].[AfficherCommentairesSurPermit] [FournisseurID_AfficherCommentairesSurPermit]
,[Fournisseur2].[PasEmissionPermis] [FournisseurID_PasEmissionPermis]
,[Fournisseur2].[Generique] [FournisseurID_Generique]

From [dbo].[LotContingente] [LotContingente]
    Inner Join [dbo].[Lot] [Lot1] On [LotContingente].[LotID] = [Lot1].[ID]
        Inner Join [dbo].[Fournisseur] [Fournisseur2] On [LotContingente].[FournisseurID] = [Fournisseur2].[ID]

Where

    ((@LotID Is Null) Or ([LotContingente].[LotID] = @LotID))
And ((@Annee Is Null) Or ([LotContingente].[Annee] = @Annee))
And ((@FournisseurID Is Null) Or ([LotContingente].[FournisseurID] = @FournisseurID))
)



