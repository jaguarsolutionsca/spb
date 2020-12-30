
CREATE Function [dbo].[fnFournisseur_Full]

(
 @ID [varchar](15) = Null
,@PaysID [varchar](2) = Null
,@InstitutionBanquaireID [varchar](3) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
 [Fournisseur].[ID]
,[Fournisseur].[CleTri]
,[Fournisseur].[Nom]
,[Fournisseur].[AuSoinsDe]
,[Fournisseur].[Rue]
,[Fournisseur].[Ville]
,[Fournisseur].[PaysID]
,[Fournisseur].[Code_postal]
,[Fournisseur].[Telephone]
,[Fournisseur].[Telephone_Poste]
,[Fournisseur].[Telecopieur]
,[Fournisseur].[Telephone2]
,[Fournisseur].[Telephone2_Desc]
,[Fournisseur].[Telephone2_Poste]
,[Fournisseur].[Telephone3]
,[Fournisseur].[Telephone3_Desc]
,[Fournisseur].[Telephone3_Poste]
,[Fournisseur].[No_membre]
,[Fournisseur].[Resident]
,[Fournisseur].[Email]
,[Fournisseur].[WWW]
,[Fournisseur].[Commentaires]
,[Fournisseur].[AfficherCommentaires]
,[Fournisseur].[DepotDirect]
,[Fournisseur].[InstitutionBanquaireID]
,[Fournisseur].[Banque_transit]
,[Fournisseur].[Banque_folio]
,[Fournisseur].[No_TPS]
,[Fournisseur].[No_TVQ]
,[Fournisseur].[PayerA]
,[Fournisseur].[PayerAID]
,[Fournisseur].[Statut]
,[Fournisseur].[Rep_Nom]
,[Fournisseur].[Rep_Telephone]
,[Fournisseur].[Rep_Telephone_Poste]
,[Fournisseur].[Rep_Email]
,[Fournisseur].[EnAnglais]
,[Fournisseur].[Actif]
,[Fournisseur].[MRCProducteurID]
,[Fournisseur].[PaiementManuel]
,[Fournisseur].[Journal]
,[Fournisseur].[RecoitTPS]
,[Fournisseur].[RecoitTVQ]
,[Fournisseur].[ModifierTrigger]
,[Fournisseur].[IsProducteur]
,[Fournisseur].[IsTransporteur]
,[Fournisseur].[IsChargeur]
,[Fournisseur].[IsAutre]
,[Fournisseur].[AfficherCommentairesSurPermit]
,[Fournisseur].[PasEmissionPermis]
,[Fournisseur].[Generique]
,[Fournisseur].[Membre_OGC]
,[Fournisseur].[InscritTPS]
,[Fournisseur].[InscritTVQ]
,[Fournisseur].[IsOGC]
,[Fournisseur].[Rep2_Nom]
,[Fournisseur].[Rep2_Telephone]
,[Fournisseur].[Rep2_Telephone_Poste]
,[Fournisseur].[Rep2_Email]
,[Fournisseur].[Rep2_Commentaires]
,[Pays1].[ID] [PaysID_ID]
,[Pays1].[Nom] [PaysID_Nom]
,[Pays1].[CodePostal_InputMask] [PaysID_CodePostal_InputMask]
,[Pays1].[Actif] [PaysID_Actif]
,[InstitutionBanquaire2].[ID] [InstitutionBanquaireID_ID]
,[InstitutionBanquaire2].[Description] [InstitutionBanquaireID_Description]
,[InstitutionBanquaire2].[Actif] [InstitutionBanquaireID_Actif]

From [dbo].[Fournisseur] [Fournisseur]
    Left Outer Join [dbo].[Pays] [Pays1] On [Fournisseur].[PaysID] = [Pays1].[ID]
        Left Outer Join [dbo].[InstitutionBanquaire] [InstitutionBanquaire2] On [Fournisseur].[InstitutionBanquaireID] = [InstitutionBanquaire2].[ID]

Where

    ((@ID Is Null) Or ([Fournisseur].[ID] = @ID))
And ((@PaysID Is Null) Or ([Fournisseur].[PaysID] = @PaysID))
And ((@InstitutionBanquaireID Is Null) Or ([Fournisseur].[InstitutionBanquaireID] = @InstitutionBanquaireID))
)

