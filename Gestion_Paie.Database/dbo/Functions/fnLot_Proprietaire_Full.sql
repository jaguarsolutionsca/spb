

Create Function [fnLot_Proprietaire_Full]

(
 @ProprietaireID [varchar](15) = Null
,@DateDebut [datetime] = Null
,@LotID [int] = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Lot_Proprietaire].[ProprietaireID]
,[Lot_Proprietaire].[DateDebut]
,[Lot_Proprietaire].[DateFin]
,[Lot_Proprietaire].[LotID]
,[Fournisseur1].[ID] [ProprietaireID_ID]
,[Fournisseur1].[CleTri] [ProprietaireID_CleTri]
,[Fournisseur1].[Nom] [ProprietaireID_Nom]
,[Fournisseur1].[AuSoinsDe] [ProprietaireID_AuSoinsDe]
,[Fournisseur1].[Rue] [ProprietaireID_Rue]
,[Fournisseur1].[Ville] [ProprietaireID_Ville]
,[Fournisseur1].[PaysID] [ProprietaireID_PaysID]
,[Fournisseur1].[Code_postal] [ProprietaireID_Code_postal]
,[Fournisseur1].[Telephone] [ProprietaireID_Telephone]
,[Fournisseur1].[Telephone_Poste] [ProprietaireID_Telephone_Poste]
,[Fournisseur1].[Telecopieur] [ProprietaireID_Telecopieur]
,[Fournisseur1].[Telephone2] [ProprietaireID_Telephone2]
,[Fournisseur1].[Telephone2_Desc] [ProprietaireID_Telephone2_Desc]
,[Fournisseur1].[Telephone2_Poste] [ProprietaireID_Telephone2_Poste]
,[Fournisseur1].[Telephone3] [ProprietaireID_Telephone3]
,[Fournisseur1].[Telephone3_Desc] [ProprietaireID_Telephone3_Desc]
,[Fournisseur1].[Telephone3_Poste] [ProprietaireID_Telephone3_Poste]
,[Fournisseur1].[No_membre] [ProprietaireID_No_membre]
,[Fournisseur1].[Resident] [ProprietaireID_Resident]
,[Fournisseur1].[Email] [ProprietaireID_Email]
,[Fournisseur1].[WWW] [ProprietaireID_WWW]
,[Fournisseur1].[Commentaires] [ProprietaireID_Commentaires]
,[Fournisseur1].[AfficherCommentaires] [ProprietaireID_AfficherCommentaires]
,[Fournisseur1].[DepotDirect] [ProprietaireID_DepotDirect]
,[Fournisseur1].[InstitutionBanquaireID] [ProprietaireID_InstitutionBanquaireID]
,[Fournisseur1].[Banque_transit] [ProprietaireID_Banque_transit]
,[Fournisseur1].[Banque_folio] [ProprietaireID_Banque_folio]
,[Fournisseur1].[No_TPS] [ProprietaireID_No_TPS]
,[Fournisseur1].[No_TVQ] [ProprietaireID_No_TVQ]
,[Fournisseur1].[PayerA] [ProprietaireID_PayerA]
,[Fournisseur1].[PayerAID] [ProprietaireID_PayerAID]
,[Fournisseur1].[Statut] [ProprietaireID_Statut]
,[Fournisseur1].[Rep_Nom] [ProprietaireID_Rep_Nom]
,[Fournisseur1].[Rep_Telephone] [ProprietaireID_Rep_Telephone]
,[Fournisseur1].[Rep_Telephone_Poste] [ProprietaireID_Rep_Telephone_Poste]
,[Fournisseur1].[Rep_Email] [ProprietaireID_Rep_Email]
,[Fournisseur1].[EnAnglais] [ProprietaireID_EnAnglais]
,[Fournisseur1].[Actif] [ProprietaireID_Actif]
,[Fournisseur1].[MRCProducteurID] [ProprietaireID_MRCProducteurID]
,[Fournisseur1].[PaiementManuel] [ProprietaireID_PaiementManuel]
,[Fournisseur1].[Journal] [ProprietaireID_Journal]
,[Fournisseur1].[RecoitTPS] [ProprietaireID_RecoitTPS]
,[Fournisseur1].[RecoitTVQ] [ProprietaireID_RecoitTVQ]
,[Fournisseur1].[ModifierTrigger] [ProprietaireID_ModifierTrigger]
,[Fournisseur1].[IsProducteur] [ProprietaireID_IsProducteur]
,[Fournisseur1].[IsTransporteur] [ProprietaireID_IsTransporteur]
,[Fournisseur1].[IsChargeur] [ProprietaireID_IsChargeur]
,[Fournisseur1].[IsAutre] [ProprietaireID_IsAutre]
,[Fournisseur1].[AfficherCommentairesSurPermit] [ProprietaireID_AfficherCommentairesSurPermit]
,[Fournisseur1].[PasEmissionPermis] [ProprietaireID_PasEmissionPermis]
,[Fournisseur1].[Generique] [ProprietaireID_Generique]
,[Lot2].[CantonID] [LotID_CantonID]
,[Lot2].[Rang] [LotID_Rang]
,[Lot2].[Lot] [LotID_Lot]
,[Lot2].[MunicipaliteID] [LotID_MunicipaliteID]
,[Lot2].[Superficie_total] [LotID_Superficie_total]
,[Lot2].[Superficie_boisee] [LotID_Superficie_boisee]
,[Lot2].[ProprietaireID] [LotID_ProprietaireID]
,[Lot2].[ContingentID] [LotID_ContingentID]
,[Lot2].[Contingent_Date] [LotID_Contingent_Date]
,[Lot2].[Droit_coupeID] [LotID_Droit_coupeID]
,[Lot2].[Droit_coupe_Date] [LotID_Droit_coupe_Date]
,[Lot2].[Entente_paiementID] [LotID_Entente_paiementID]
,[Lot2].[Entente_paiement_Date] [LotID_Entente_paiement_Date]
,[Lot2].[Actif] [LotID_Actif]
,[Lot2].[ID] [LotID_ID]
,[Lot2].[Sequence] [LotID_Sequence]
,[Lot2].[Partie] [LotID_Partie]
,[Lot2].[Matricule] [LotID_Matricule]
,[Lot2].[ZoneID] [LotID_ZoneID]
,[Lot2].[Secteur] [LotID_Secteur]
,[Lot2].[Cadastre] [LotID_Cadastre]

From [dbo].[Lot_Proprietaire] [Lot_Proprietaire]
    Inner Join [dbo].[Fournisseur] [Fournisseur1] On [Lot_Proprietaire].[ProprietaireID] = [Fournisseur1].[ID]
        Inner Join [dbo].[Lot] [Lot2] On [Lot_Proprietaire].[LotID] = [Lot2].[ID]

Where

    ((@ProprietaireID Is Null) Or ([Lot_Proprietaire].[ProprietaireID] = @ProprietaireID))
And ((@DateDebut Is Null) Or ([Lot_Proprietaire].[DateDebut] = @DateDebut))
And ((@LotID Is Null) Or ([Lot_Proprietaire].[LotID] = @LotID))
)



