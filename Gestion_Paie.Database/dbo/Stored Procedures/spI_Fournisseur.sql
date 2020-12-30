CREATE Procedure [dbo].[spI_Fournisseur]

-- Inserts a new record in [Fournisseur] table
(
  @ID [varchar](15) -- for [Fournisseur].[ID] column
, @CleTri [varchar](15) = Null  -- for [Fournisseur].[CleTri] column
, @Nom [varchar](40) = Null  -- for [Fournisseur].[Nom] column
, @AuSoinsDe [varchar](30) = Null  -- for [Fournisseur].[AuSoinsDe] column
, @Rue [varchar](30) = Null  -- for [Fournisseur].[Rue] column
, @Ville [varchar](30) = Null  -- for [Fournisseur].[Ville] column
, @PaysID [varchar](2) = Null  -- for [Fournisseur].[PaysID] column
, @Code_postal [varchar](7) = Null  -- for [Fournisseur].[Code_postal] column
, @Telephone [varchar](12) = Null  -- for [Fournisseur].[Telephone] column
, @Telephone_Poste [varchar](4) = Null  -- for [Fournisseur].[Telephone_Poste] column
, @Telecopieur [varchar](12) = Null  -- for [Fournisseur].[Telecopieur] column
, @Telephone2 [varchar](12) = Null  -- for [Fournisseur].[Telephone2] column
, @Telephone2_Desc [varchar](20) = Null  -- for [Fournisseur].[Telephone2_Desc] column
, @Telephone2_Poste [varchar](4) = Null  -- for [Fournisseur].[Telephone2_Poste] column
, @Telephone3 [varchar](12) = Null  -- for [Fournisseur].[Telephone3] column
, @Telephone3_Desc [varchar](20) = Null  -- for [Fournisseur].[Telephone3_Desc] column
, @Telephone3_Poste [varchar](4) = Null  -- for [Fournisseur].[Telephone3_Poste] column
, @No_membre [varchar](10) = Null  -- for [Fournisseur].[No_membre] column
, @Resident [char](1) = Null  -- for [Fournisseur].[Resident] column
, @Email [varchar](80) = Null  -- for [Fournisseur].[Email] column
, @WWW [varchar](80) = Null  -- for [Fournisseur].[WWW] column
, @Commentaires [varchar](255) = Null  -- for [Fournisseur].[Commentaires] column
, @AfficherCommentaires [bit] = Null  -- for [Fournisseur].[AfficherCommentaires] column
, @DepotDirect [bit] = Null  -- for [Fournisseur].[DepotDirect] column
, @InstitutionBanquaireID [varchar](3) = Null  -- for [Fournisseur].[InstitutionBanquaireID] column
, @Banque_transit [varchar](5) = Null  -- for [Fournisseur].[Banque_transit] column
, @Banque_folio [varchar](12) = Null  -- for [Fournisseur].[Banque_folio] column
, @No_TPS [varchar](25) = Null  -- for [Fournisseur].[No_TPS] column
, @No_TVQ [varchar](25) = Null  -- for [Fournisseur].[No_TVQ] column
, @PayerA [bit] = Null  -- for [Fournisseur].[PayerA] column
, @PayerAID [varchar](15) = Null  -- for [Fournisseur].[PayerAID] column
, @Statut [varchar](50) = Null  -- for [Fournisseur].[Statut] column
, @Rep_Nom [varchar](30) = Null  -- for [Fournisseur].[Rep_Nom] column
, @Rep_Telephone [varchar](12) = Null  -- for [Fournisseur].[Rep_Telephone] column
, @Rep_Telephone_Poste [varchar](4) = Null  -- for [Fournisseur].[Rep_Telephone_Poste] column
, @Rep_Email [varchar](80) = Null  -- for [Fournisseur].[Rep_Email] column
, @EnAnglais [bit] = Null  -- for [Fournisseur].[EnAnglais] column
, @Actif [bit] = Null  -- for [Fournisseur].[Actif] column
, @MRCProducteurID [int] = Null  -- for [Fournisseur].[MRCProducteurID] column
, @PaiementManuel [bit] = Null  -- for [Fournisseur].[PaiementManuel] column
, @Journal [bit] = Null  -- for [Fournisseur].[Journal] column
, @RecoitTPS [bit] = Null  -- for [Fournisseur].[RecoitTPS] column
, @RecoitTVQ [bit] = Null  -- for [Fournisseur].[RecoitTVQ] column
, @ModifierTrigger [bit] = Null  -- for [Fournisseur].[ModifierTrigger] column
, @IsProducteur [bit] = Null  -- for [Fournisseur].[IsProducteur] column
, @IsTransporteur [bit] = Null  -- for [Fournisseur].[IsTransporteur] column
, @IsChargeur [bit] = Null  -- for [Fournisseur].[IsChargeur] column
, @IsAutre [bit] = Null  -- for [Fournisseur].[IsAutre] column
, @AfficherCommentairesSurPermit [bit] = Null  -- for [Fournisseur].[AfficherCommentairesSurPermit] column
, @PasEmissionPermis [bit] = Null  -- for [Fournisseur].[PasEmissionPermis] column
, @Generique [bit] = Null  -- for [Fournisseur].[Generique] column
, @Membre_OGC [bit] = Null  -- for [Fournisseur].[Membre_OGC] column
, @InscritTPS [bit] = Null  -- for [Fournisseur].[InscritTPS] column
, @InscritTVQ [bit] = Null  -- for [Fournisseur].[InscritTVQ] column
, @IsOGC [bit] = Null  -- for [Fournisseur].[IsOGC] column
, @Rep2_Nom [varchar](80) = Null  -- for [Fournisseur].[Rep2_Nom] column
, @Rep2_Telephone [varchar](12) = Null  -- for [Fournisseur].[Rep2_Telephone] column
, @Rep2_Telephone_Poste [varchar](4) = Null  -- for [Fournisseur].[Rep2_Telephone_Poste] column
, @Rep2_Email [varchar](80) = Null  -- for [Fournisseur].[Rep2_Email] column
, @Rep2_Commentaires [varchar](255) = Null  -- for [Fournisseur].[Rep2_Commentaires] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @AfficherCommentairesSurPermit Is Null
	Set @AfficherCommentairesSurPermit = (0)

If @IsOGC Is Null
	Set @IsOGC = (0)

Insert Into [dbo].[Fournisseur]
(
	  [ID]
	, [CleTri]
	, [Nom]
	, [AuSoinsDe]
	, [Rue]
	, [Ville]
	, [PaysID]
	, [Code_postal]
	, [Telephone]
	, [Telephone_Poste]
	, [Telecopieur]
	, [Telephone2]
	, [Telephone2_Desc]
	, [Telephone2_Poste]
	, [Telephone3]
	, [Telephone3_Desc]
	, [Telephone3_Poste]
	, [No_membre]
	, [Resident]
	, [Email]
	, [WWW]
	, [Commentaires]
	, [AfficherCommentaires]
	, [DepotDirect]
	, [InstitutionBanquaireID]
	, [Banque_transit]
	, [Banque_folio]
	, [No_TPS]
	, [No_TVQ]
	, [PayerA]
	, [PayerAID]
	, [Statut]
	, [Rep_Nom]
	, [Rep_Telephone]
	, [Rep_Telephone_Poste]
	, [Rep_Email]
	, [EnAnglais]
	, [Actif]
	, [MRCProducteurID]
	, [PaiementManuel]
	, [Journal]
	, [RecoitTPS]
	, [RecoitTVQ]
	, [ModifierTrigger]
	, [IsProducteur]
	, [IsTransporteur]
	, [IsChargeur]
	, [IsAutre]
	, [AfficherCommentairesSurPermit]
	, [PasEmissionPermis]
	, [Generique]
	, [Membre_OGC]
	, [InscritTPS]
	, [InscritTVQ]
	, [IsOGC]
	, [Rep2_Nom]
	, [Rep2_Telephone]
	, [Rep2_Telephone_Poste]
	, [Rep2_Email]
	, [Rep2_Commentaires]
)

Values
(
	  @ID
	, @CleTri
	, @Nom
	, @AuSoinsDe
	, @Rue
	, @Ville
	, @PaysID
	, @Code_postal
	, @Telephone
	, @Telephone_Poste
	, @Telecopieur
	, @Telephone2
	, @Telephone2_Desc
	, @Telephone2_Poste
	, @Telephone3
	, @Telephone3_Desc
	, @Telephone3_Poste
	, @No_membre
	, @Resident
	, @Email
	, @WWW
	, @Commentaires
	, @AfficherCommentaires
	, @DepotDirect
	, @InstitutionBanquaireID
	, @Banque_transit
	, @Banque_folio
	, @No_TPS
	, @No_TVQ
	, @PayerA
	, @PayerAID
	, @Statut
	, @Rep_Nom
	, @Rep_Telephone
	, @Rep_Telephone_Poste
	, @Rep_Email
	, @EnAnglais
	, @Actif
	, @MRCProducteurID
	, @PaiementManuel
	, @Journal
	, @RecoitTPS
	, @RecoitTVQ
	, @ModifierTrigger
	, @IsProducteur
	, @IsTransporteur
	, @IsChargeur
	, @IsAutre
	, @AfficherCommentairesSurPermit
	, @PasEmissionPermis
	, @Generique
	, @Membre_OGC
	, @InscritTPS
	, @InscritTVQ
	, @IsOGC
	, @Rep2_Nom
	, @Rep2_Telephone
	, @Rep2_Telephone_Poste
	, @Rep2_Email
	, @Rep2_Commentaires
)

Set NoCount Off

Return(0)




