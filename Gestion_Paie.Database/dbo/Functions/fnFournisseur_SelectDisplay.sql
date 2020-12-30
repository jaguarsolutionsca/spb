
CREATE Function [dbo].[fnFournisseur_SelectDisplay]
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
	,[Pays1].[Display] [PaysID_Display]
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
	,[InstitutionBanquaire2].[Display] [InstitutionBanquaireID_Display]
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

From [dbo].[Fournisseur]
    Left Outer Join [fnPays_Display](Null) [Pays1] On [PaysID] = [Pays1].[ID1]
        Left Outer Join [fnInstitutionBanquaire_Display](Null) [InstitutionBanquaire2] On [InstitutionBanquaireID] = [InstitutionBanquaire2].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@PaysID Is Null) Or ([PaysID] = @PaysID))
And ((@InstitutionBanquaireID Is Null) Or ([InstitutionBanquaireID] = @InstitutionBanquaireID))
)

