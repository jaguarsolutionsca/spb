
CREATE Function [dbo].[fnFournisseur]
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
Select TOP 100 PERCENT
 [ID]
,[CleTri]
,[Nom]
,[AuSoinsDe]
,[Rue]
,[Ville]
,[PaysID]
,[Code_postal]
,[Telephone]
,[Telephone_Poste]
,[Telecopieur]
,[Telephone2]
,[Telephone2_Desc]
,[Telephone2_Poste]
,[Telephone3]
,[Telephone3_Desc]
,[Telephone3_Poste]
,[No_membre]
,[Resident]
,[Email]
,[WWW]
,[Commentaires]
,[AfficherCommentaires]
,[DepotDirect]
,[InstitutionBanquaireID]
,[Banque_transit]
,[Banque_folio]
,[No_TPS]
,[No_TVQ]
,[PayerA]
,[PayerAID]
,[Statut]
,[Rep_Nom]
,[Rep_Telephone]
,[Rep_Telephone_Poste]
,[Rep_Email]
,[EnAnglais]
,[Actif]
,[MRCProducteurID]
,[PaiementManuel]
,[Journal]
,[RecoitTPS]
,[RecoitTVQ]
,[ModifierTrigger]
,[IsProducteur]
,[IsTransporteur]
,[IsChargeur]
,[IsAutre]
,[AfficherCommentairesSurPermit]
,[PasEmissionPermis]
,[Generique]
,[Membre_OGC]
,[InscritTPS]
,[InscritTVQ]
,[IsOGC]
,[Rep2_Nom]
,[Rep2_Telephone]
,[Rep2_Telephone_Poste]
,[Rep2_Email]
,[Rep2_Commentaires]

From [dbo].[Fournisseur]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@PaysID Is Null) Or ([PaysID] = @PaysID))
And ((@InstitutionBanquaireID Is Null) Or ([InstitutionBanquaireID] = @InstitutionBanquaireID))
)

