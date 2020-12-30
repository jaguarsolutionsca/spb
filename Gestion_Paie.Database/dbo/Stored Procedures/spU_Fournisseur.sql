CREATE Procedure [dbo].[spU_Fournisseur]

-- Update an existing record in [Fournisseur] table

(
  @ID [varchar](15) -- for [Fournisseur].[ID] column
, @CleTri [varchar](15) = Null -- for [Fournisseur].[CleTri] column
, @ConsiderNull_CleTri bit = 0
, @Nom [varchar](40) = Null -- for [Fournisseur].[Nom] column
, @ConsiderNull_Nom bit = 0
, @AuSoinsDe [varchar](30) = Null -- for [Fournisseur].[AuSoinsDe] column
, @ConsiderNull_AuSoinsDe bit = 0
, @Rue [varchar](30) = Null -- for [Fournisseur].[Rue] column
, @ConsiderNull_Rue bit = 0
, @Ville [varchar](30) = Null -- for [Fournisseur].[Ville] column
, @ConsiderNull_Ville bit = 0
, @PaysID [varchar](2) = Null -- for [Fournisseur].[PaysID] column
, @ConsiderNull_PaysID bit = 0
, @Code_postal [varchar](7) = Null -- for [Fournisseur].[Code_postal] column
, @ConsiderNull_Code_postal bit = 0
, @Telephone [varchar](12) = Null -- for [Fournisseur].[Telephone] column
, @ConsiderNull_Telephone bit = 0
, @Telephone_Poste [varchar](4) = Null -- for [Fournisseur].[Telephone_Poste] column
, @ConsiderNull_Telephone_Poste bit = 0
, @Telecopieur [varchar](12) = Null -- for [Fournisseur].[Telecopieur] column
, @ConsiderNull_Telecopieur bit = 0
, @Telephone2 [varchar](12) = Null -- for [Fournisseur].[Telephone2] column
, @ConsiderNull_Telephone2 bit = 0
, @Telephone2_Desc [varchar](20) = Null -- for [Fournisseur].[Telephone2_Desc] column
, @ConsiderNull_Telephone2_Desc bit = 0
, @Telephone2_Poste [varchar](4) = Null -- for [Fournisseur].[Telephone2_Poste] column
, @ConsiderNull_Telephone2_Poste bit = 0
, @Telephone3 [varchar](12) = Null -- for [Fournisseur].[Telephone3] column
, @ConsiderNull_Telephone3 bit = 0
, @Telephone3_Desc [varchar](20) = Null -- for [Fournisseur].[Telephone3_Desc] column
, @ConsiderNull_Telephone3_Desc bit = 0
, @Telephone3_Poste [varchar](4) = Null -- for [Fournisseur].[Telephone3_Poste] column
, @ConsiderNull_Telephone3_Poste bit = 0
, @No_membre [varchar](10) = Null -- for [Fournisseur].[No_membre] column
, @ConsiderNull_No_membre bit = 0
, @Resident [char](1) = Null -- for [Fournisseur].[Resident] column
, @ConsiderNull_Resident bit = 0
, @Email [varchar](80) = Null -- for [Fournisseur].[Email] column
, @ConsiderNull_Email bit = 0
, @WWW [varchar](80) = Null -- for [Fournisseur].[WWW] column
, @ConsiderNull_WWW bit = 0
, @Commentaires [varchar](255) = Null -- for [Fournisseur].[Commentaires] column
, @ConsiderNull_Commentaires bit = 0
, @AfficherCommentaires [bit] = Null -- for [Fournisseur].[AfficherCommentaires] column
, @ConsiderNull_AfficherCommentaires bit = 0
, @DepotDirect [bit] = Null -- for [Fournisseur].[DepotDirect] column
, @ConsiderNull_DepotDirect bit = 0
, @InstitutionBanquaireID [varchar](3) = Null -- for [Fournisseur].[InstitutionBanquaireID] column
, @ConsiderNull_InstitutionBanquaireID bit = 0
, @Banque_transit [varchar](5) = Null -- for [Fournisseur].[Banque_transit] column
, @ConsiderNull_Banque_transit bit = 0
, @Banque_folio [varchar](12) = Null -- for [Fournisseur].[Banque_folio] column
, @ConsiderNull_Banque_folio bit = 0
, @No_TPS [varchar](25) = Null -- for [Fournisseur].[No_TPS] column
, @ConsiderNull_No_TPS bit = 0
, @No_TVQ [varchar](25) = Null -- for [Fournisseur].[No_TVQ] column
, @ConsiderNull_No_TVQ bit = 0
, @PayerA [bit] = Null -- for [Fournisseur].[PayerA] column
, @ConsiderNull_PayerA bit = 0
, @PayerAID [varchar](15) = Null -- for [Fournisseur].[PayerAID] column
, @ConsiderNull_PayerAID bit = 0
, @Statut [varchar](50) = Null -- for [Fournisseur].[Statut] column
, @ConsiderNull_Statut bit = 0
, @Rep_Nom [varchar](30) = Null -- for [Fournisseur].[Rep_Nom] column
, @ConsiderNull_Rep_Nom bit = 0
, @Rep_Telephone [varchar](12) = Null -- for [Fournisseur].[Rep_Telephone] column
, @ConsiderNull_Rep_Telephone bit = 0
, @Rep_Telephone_Poste [varchar](4) = Null -- for [Fournisseur].[Rep_Telephone_Poste] column
, @ConsiderNull_Rep_Telephone_Poste bit = 0
, @Rep_Email [varchar](80) = Null -- for [Fournisseur].[Rep_Email] column
, @ConsiderNull_Rep_Email bit = 0
, @EnAnglais [bit] = Null -- for [Fournisseur].[EnAnglais] column
, @ConsiderNull_EnAnglais bit = 0
, @Actif [bit] = Null -- for [Fournisseur].[Actif] column
, @ConsiderNull_Actif bit = 0
, @MRCProducteurID [int] = Null -- for [Fournisseur].[MRCProducteurID] column
, @ConsiderNull_MRCProducteurID bit = 0
, @PaiementManuel [bit] = Null -- for [Fournisseur].[PaiementManuel] column
, @ConsiderNull_PaiementManuel bit = 0
, @Journal [bit] = Null -- for [Fournisseur].[Journal] column
, @ConsiderNull_Journal bit = 0
, @RecoitTPS [bit] = Null -- for [Fournisseur].[RecoitTPS] column
, @ConsiderNull_RecoitTPS bit = 0
, @RecoitTVQ [bit] = Null -- for [Fournisseur].[RecoitTVQ] column
, @ConsiderNull_RecoitTVQ bit = 0
, @ModifierTrigger [bit] = Null -- for [Fournisseur].[ModifierTrigger] column
, @ConsiderNull_ModifierTrigger bit = 0
, @IsProducteur [bit] = Null -- for [Fournisseur].[IsProducteur] column
, @ConsiderNull_IsProducteur bit = 0
, @IsTransporteur [bit] = Null -- for [Fournisseur].[IsTransporteur] column
, @ConsiderNull_IsTransporteur bit = 0
, @IsChargeur [bit] = Null -- for [Fournisseur].[IsChargeur] column
, @ConsiderNull_IsChargeur bit = 0
, @IsAutre [bit] = Null -- for [Fournisseur].[IsAutre] column
, @ConsiderNull_IsAutre bit = 0
, @AfficherCommentairesSurPermit [bit] -- for [Fournisseur].[AfficherCommentairesSurPermit] column
, @ConsiderNull_AfficherCommentairesSurPermit bit = 0
, @PasEmissionPermis [bit] = Null -- for [Fournisseur].[PasEmissionPermis] column
, @ConsiderNull_PasEmissionPermis bit = 0
, @Generique [bit] = Null -- for [Fournisseur].[Generique] column
, @ConsiderNull_Generique bit = 0
, @Membre_OGC [bit] = Null -- for [Fournisseur].[Membre_OGC] column
, @ConsiderNull_Membre_OGC bit = 0
, @InscritTPS [bit] = Null -- for [Fournisseur].[InscritTPS] column
, @ConsiderNull_InscritTPS bit = 0
, @InscritTVQ [bit] = Null -- for [Fournisseur].[InscritTVQ] column
, @ConsiderNull_InscritTVQ bit = 0
, @IsOGC [bit] -- for [Fournisseur].[IsOGC] column
, @ConsiderNull_IsOGC bit = 0
, @Rep2_Nom [varchar](80) = Null -- for [Fournisseur].[Rep2_Nom] column
, @ConsiderNull_Rep2_Nom bit = 0
, @Rep2_Telephone [varchar](12) = Null -- for [Fournisseur].[Rep2_Telephone] column
, @ConsiderNull_Rep2_Telephone bit = 0
, @Rep2_Telephone_Poste [varchar](4) = Null -- for [Fournisseur].[Rep2_Telephone_Poste] column
, @ConsiderNull_Rep2_Telephone_Poste bit = 0
, @Rep2_Email [varchar](80) = Null -- for [Fournisseur].[Rep2_Email] column
, @ConsiderNull_Rep2_Email bit = 0
, @Rep2_Commentaires [varchar](255) = Null -- for [Fournisseur].[Rep2_Commentaires] column
, @ConsiderNull_Rep2_Commentaires bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_CleTri Is Null
	Set @ConsiderNull_CleTri = 0

If @ConsiderNull_Nom Is Null
	Set @ConsiderNull_Nom = 0

If @ConsiderNull_AuSoinsDe Is Null
	Set @ConsiderNull_AuSoinsDe = 0

If @ConsiderNull_Rue Is Null
	Set @ConsiderNull_Rue = 0

If @ConsiderNull_Ville Is Null
	Set @ConsiderNull_Ville = 0

If @ConsiderNull_PaysID Is Null
	Set @ConsiderNull_PaysID = 0

If @ConsiderNull_Code_postal Is Null
	Set @ConsiderNull_Code_postal = 0

If @ConsiderNull_Telephone Is Null
	Set @ConsiderNull_Telephone = 0

If @ConsiderNull_Telephone_Poste Is Null
	Set @ConsiderNull_Telephone_Poste = 0

If @ConsiderNull_Telecopieur Is Null
	Set @ConsiderNull_Telecopieur = 0

If @ConsiderNull_Telephone2 Is Null
	Set @ConsiderNull_Telephone2 = 0

If @ConsiderNull_Telephone2_Desc Is Null
	Set @ConsiderNull_Telephone2_Desc = 0

If @ConsiderNull_Telephone2_Poste Is Null
	Set @ConsiderNull_Telephone2_Poste = 0

If @ConsiderNull_Telephone3 Is Null
	Set @ConsiderNull_Telephone3 = 0

If @ConsiderNull_Telephone3_Desc Is Null
	Set @ConsiderNull_Telephone3_Desc = 0

If @ConsiderNull_Telephone3_Poste Is Null
	Set @ConsiderNull_Telephone3_Poste = 0

If @ConsiderNull_No_membre Is Null
	Set @ConsiderNull_No_membre = 0

If @ConsiderNull_Resident Is Null
	Set @ConsiderNull_Resident = 0

If @ConsiderNull_Email Is Null
	Set @ConsiderNull_Email = 0

If @ConsiderNull_WWW Is Null
	Set @ConsiderNull_WWW = 0

If @ConsiderNull_Commentaires Is Null
	Set @ConsiderNull_Commentaires = 0

If @ConsiderNull_AfficherCommentaires Is Null
	Set @ConsiderNull_AfficherCommentaires = 0

If @ConsiderNull_DepotDirect Is Null
	Set @ConsiderNull_DepotDirect = 0

If @ConsiderNull_InstitutionBanquaireID Is Null
	Set @ConsiderNull_InstitutionBanquaireID = 0

If @ConsiderNull_Banque_transit Is Null
	Set @ConsiderNull_Banque_transit = 0

If @ConsiderNull_Banque_folio Is Null
	Set @ConsiderNull_Banque_folio = 0

If @ConsiderNull_No_TPS Is Null
	Set @ConsiderNull_No_TPS = 0

If @ConsiderNull_No_TVQ Is Null
	Set @ConsiderNull_No_TVQ = 0

If @ConsiderNull_PayerA Is Null
	Set @ConsiderNull_PayerA = 0

If @ConsiderNull_PayerAID Is Null
	Set @ConsiderNull_PayerAID = 0

If @ConsiderNull_Statut Is Null
	Set @ConsiderNull_Statut = 0

If @ConsiderNull_Rep_Nom Is Null
	Set @ConsiderNull_Rep_Nom = 0

If @ConsiderNull_Rep_Telephone Is Null
	Set @ConsiderNull_Rep_Telephone = 0

If @ConsiderNull_Rep_Telephone_Poste Is Null
	Set @ConsiderNull_Rep_Telephone_Poste = 0

If @ConsiderNull_Rep_Email Is Null
	Set @ConsiderNull_Rep_Email = 0

If @ConsiderNull_EnAnglais Is Null
	Set @ConsiderNull_EnAnglais = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0

If @ConsiderNull_MRCProducteurID Is Null
	Set @ConsiderNull_MRCProducteurID = 0

If @ConsiderNull_PaiementManuel Is Null
	Set @ConsiderNull_PaiementManuel = 0

If @ConsiderNull_Journal Is Null
	Set @ConsiderNull_Journal = 0

If @ConsiderNull_RecoitTPS Is Null
	Set @ConsiderNull_RecoitTPS = 0

If @ConsiderNull_RecoitTVQ Is Null
	Set @ConsiderNull_RecoitTVQ = 0

If @ConsiderNull_ModifierTrigger Is Null
	Set @ConsiderNull_ModifierTrigger = 0

If @ConsiderNull_IsProducteur Is Null
	Set @ConsiderNull_IsProducteur = 0

If @ConsiderNull_IsTransporteur Is Null
	Set @ConsiderNull_IsTransporteur = 0

If @ConsiderNull_IsChargeur Is Null
	Set @ConsiderNull_IsChargeur = 0

If @ConsiderNull_IsAutre Is Null
	Set @ConsiderNull_IsAutre = 0

If @ConsiderNull_AfficherCommentairesSurPermit Is Null
	Set @ConsiderNull_AfficherCommentairesSurPermit = 0

If @ConsiderNull_PasEmissionPermis Is Null
	Set @ConsiderNull_PasEmissionPermis = 0

If @ConsiderNull_Generique Is Null
	Set @ConsiderNull_Generique = 0

If @ConsiderNull_Membre_OGC Is Null
	Set @ConsiderNull_Membre_OGC = 0

If @ConsiderNull_InscritTPS Is Null
	Set @ConsiderNull_InscritTPS = 0

If @ConsiderNull_InscritTVQ Is Null
	Set @ConsiderNull_InscritTVQ = 0

If @ConsiderNull_IsOGC Is Null
	Set @ConsiderNull_IsOGC = 0

If @ConsiderNull_Rep2_Nom Is Null
	Set @ConsiderNull_Rep2_Nom = 0

If @ConsiderNull_Rep2_Telephone Is Null
	Set @ConsiderNull_Rep2_Telephone = 0

If @ConsiderNull_Rep2_Telephone_Poste Is Null
	Set @ConsiderNull_Rep2_Telephone_Poste = 0

If @ConsiderNull_Rep2_Email Is Null
	Set @ConsiderNull_Rep2_Email = 0

If @ConsiderNull_Rep2_Commentaires Is Null
	Set @ConsiderNull_Rep2_Commentaires = 0


Update [dbo].[Fournisseur]

Set
	 [CleTri] = Case @ConsiderNull_CleTri When 0 Then IsNull(@CleTri, [CleTri]) When 1 Then @CleTri End
	,[Nom] = Case @ConsiderNull_Nom When 0 Then IsNull(@Nom, [Nom]) When 1 Then @Nom End
	,[AuSoinsDe] = Case @ConsiderNull_AuSoinsDe When 0 Then IsNull(@AuSoinsDe, [AuSoinsDe]) When 1 Then @AuSoinsDe End
	,[Rue] = Case @ConsiderNull_Rue When 0 Then IsNull(@Rue, [Rue]) When 1 Then @Rue End
	,[Ville] = Case @ConsiderNull_Ville When 0 Then IsNull(@Ville, [Ville]) When 1 Then @Ville End
	,[PaysID] = Case @ConsiderNull_PaysID When 0 Then IsNull(@PaysID, [PaysID]) When 1 Then @PaysID End
	,[Code_postal] = Case @ConsiderNull_Code_postal When 0 Then IsNull(@Code_postal, [Code_postal]) When 1 Then @Code_postal End
	,[Telephone] = Case @ConsiderNull_Telephone When 0 Then IsNull(@Telephone, [Telephone]) When 1 Then @Telephone End
	,[Telephone_Poste] = Case @ConsiderNull_Telephone_Poste When 0 Then IsNull(@Telephone_Poste, [Telephone_Poste]) When 1 Then @Telephone_Poste End
	,[Telecopieur] = Case @ConsiderNull_Telecopieur When 0 Then IsNull(@Telecopieur, [Telecopieur]) When 1 Then @Telecopieur End
	,[Telephone2] = Case @ConsiderNull_Telephone2 When 0 Then IsNull(@Telephone2, [Telephone2]) When 1 Then @Telephone2 End
	,[Telephone2_Desc] = Case @ConsiderNull_Telephone2_Desc When 0 Then IsNull(@Telephone2_Desc, [Telephone2_Desc]) When 1 Then @Telephone2_Desc End
	,[Telephone2_Poste] = Case @ConsiderNull_Telephone2_Poste When 0 Then IsNull(@Telephone2_Poste, [Telephone2_Poste]) When 1 Then @Telephone2_Poste End
	,[Telephone3] = Case @ConsiderNull_Telephone3 When 0 Then IsNull(@Telephone3, [Telephone3]) When 1 Then @Telephone3 End
	,[Telephone3_Desc] = Case @ConsiderNull_Telephone3_Desc When 0 Then IsNull(@Telephone3_Desc, [Telephone3_Desc]) When 1 Then @Telephone3_Desc End
	,[Telephone3_Poste] = Case @ConsiderNull_Telephone3_Poste When 0 Then IsNull(@Telephone3_Poste, [Telephone3_Poste]) When 1 Then @Telephone3_Poste End
	,[No_membre] = Case @ConsiderNull_No_membre When 0 Then IsNull(@No_membre, [No_membre]) When 1 Then @No_membre End
	,[Resident] = Case @ConsiderNull_Resident When 0 Then IsNull(@Resident, [Resident]) When 1 Then @Resident End
	,[Email] = Case @ConsiderNull_Email When 0 Then IsNull(@Email, [Email]) When 1 Then @Email End
	,[WWW] = Case @ConsiderNull_WWW When 0 Then IsNull(@WWW, [WWW]) When 1 Then @WWW End
	,[Commentaires] = Case @ConsiderNull_Commentaires When 0 Then IsNull(@Commentaires, [Commentaires]) When 1 Then @Commentaires End
	,[AfficherCommentaires] = Case @ConsiderNull_AfficherCommentaires When 0 Then IsNull(@AfficherCommentaires, [AfficherCommentaires]) When 1 Then @AfficherCommentaires End
	,[DepotDirect] = Case @ConsiderNull_DepotDirect When 0 Then IsNull(@DepotDirect, [DepotDirect]) When 1 Then @DepotDirect End
	,[InstitutionBanquaireID] = Case @ConsiderNull_InstitutionBanquaireID When 0 Then IsNull(@InstitutionBanquaireID, [InstitutionBanquaireID]) When 1 Then @InstitutionBanquaireID End
	,[Banque_transit] = Case @ConsiderNull_Banque_transit When 0 Then IsNull(@Banque_transit, [Banque_transit]) When 1 Then @Banque_transit End
	,[Banque_folio] = Case @ConsiderNull_Banque_folio When 0 Then IsNull(@Banque_folio, [Banque_folio]) When 1 Then @Banque_folio End
	,[No_TPS] = Case @ConsiderNull_No_TPS When 0 Then IsNull(@No_TPS, [No_TPS]) When 1 Then @No_TPS End
	,[No_TVQ] = Case @ConsiderNull_No_TVQ When 0 Then IsNull(@No_TVQ, [No_TVQ]) When 1 Then @No_TVQ End
	,[PayerA] = Case @ConsiderNull_PayerA When 0 Then IsNull(@PayerA, [PayerA]) When 1 Then @PayerA End
	,[PayerAID] = Case @ConsiderNull_PayerAID When 0 Then IsNull(@PayerAID, [PayerAID]) When 1 Then @PayerAID End
	,[Statut] = Case @ConsiderNull_Statut When 0 Then IsNull(@Statut, [Statut]) When 1 Then @Statut End
	,[Rep_Nom] = Case @ConsiderNull_Rep_Nom When 0 Then IsNull(@Rep_Nom, [Rep_Nom]) When 1 Then @Rep_Nom End
	,[Rep_Telephone] = Case @ConsiderNull_Rep_Telephone When 0 Then IsNull(@Rep_Telephone, [Rep_Telephone]) When 1 Then @Rep_Telephone End
	,[Rep_Telephone_Poste] = Case @ConsiderNull_Rep_Telephone_Poste When 0 Then IsNull(@Rep_Telephone_Poste, [Rep_Telephone_Poste]) When 1 Then @Rep_Telephone_Poste End
	,[Rep_Email] = Case @ConsiderNull_Rep_Email When 0 Then IsNull(@Rep_Email, [Rep_Email]) When 1 Then @Rep_Email End
	,[EnAnglais] = Case @ConsiderNull_EnAnglais When 0 Then IsNull(@EnAnglais, [EnAnglais]) When 1 Then @EnAnglais End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End
	,[MRCProducteurID] = Case @ConsiderNull_MRCProducteurID When 0 Then IsNull(@MRCProducteurID, [MRCProducteurID]) When 1 Then @MRCProducteurID End
	,[PaiementManuel] = Case @ConsiderNull_PaiementManuel When 0 Then IsNull(@PaiementManuel, [PaiementManuel]) When 1 Then @PaiementManuel End
	,[Journal] = Case @ConsiderNull_Journal When 0 Then IsNull(@Journal, [Journal]) When 1 Then @Journal End
	,[RecoitTPS] = Case @ConsiderNull_RecoitTPS When 0 Then IsNull(@RecoitTPS, [RecoitTPS]) When 1 Then @RecoitTPS End
	,[RecoitTVQ] = Case @ConsiderNull_RecoitTVQ When 0 Then IsNull(@RecoitTVQ, [RecoitTVQ]) When 1 Then @RecoitTVQ End
	,[ModifierTrigger] = Case @ConsiderNull_ModifierTrigger When 0 Then IsNull(@ModifierTrigger, [ModifierTrigger]) When 1 Then @ModifierTrigger End
	,[IsProducteur] = Case @ConsiderNull_IsProducteur When 0 Then IsNull(@IsProducteur, [IsProducteur]) When 1 Then @IsProducteur End
	,[IsTransporteur] = Case @ConsiderNull_IsTransporteur When 0 Then IsNull(@IsTransporteur, [IsTransporteur]) When 1 Then @IsTransporteur End
	,[IsChargeur] = Case @ConsiderNull_IsChargeur When 0 Then IsNull(@IsChargeur, [IsChargeur]) When 1 Then @IsChargeur End
	,[IsAutre] = Case @ConsiderNull_IsAutre When 0 Then IsNull(@IsAutre, [IsAutre]) When 1 Then @IsAutre End
	,[AfficherCommentairesSurPermit] = Case @ConsiderNull_AfficherCommentairesSurPermit When 0 Then IsNull(@AfficherCommentairesSurPermit, [AfficherCommentairesSurPermit]) When 1 Then @AfficherCommentairesSurPermit End
	,[PasEmissionPermis] = Case @ConsiderNull_PasEmissionPermis When 0 Then IsNull(@PasEmissionPermis, [PasEmissionPermis]) When 1 Then @PasEmissionPermis End
	,[Generique] = Case @ConsiderNull_Generique When 0 Then IsNull(@Generique, [Generique]) When 1 Then @Generique End
	,[Membre_OGC] = Case @ConsiderNull_Membre_OGC When 0 Then IsNull(@Membre_OGC, [Membre_OGC]) When 1 Then @Membre_OGC End
	,[InscritTPS] = Case @ConsiderNull_InscritTPS When 0 Then IsNull(@InscritTPS, [InscritTPS]) When 1 Then @InscritTPS End
	,[InscritTVQ] = Case @ConsiderNull_InscritTVQ When 0 Then IsNull(@InscritTVQ, [InscritTVQ]) When 1 Then @InscritTVQ End
	,[IsOGC] = Case @ConsiderNull_IsOGC When 0 Then IsNull(@IsOGC, [IsOGC]) When 1 Then @IsOGC End
	,[Rep2_Nom] = Case @ConsiderNull_Rep2_Nom When 0 Then IsNull(@Rep2_Nom, [Rep2_Nom]) When 1 Then @Rep2_Nom End
	,[Rep2_Telephone] = Case @ConsiderNull_Rep2_Telephone When 0 Then IsNull(@Rep2_Telephone, [Rep2_Telephone]) When 1 Then @Rep2_Telephone End
	,[Rep2_Telephone_Poste] = Case @ConsiderNull_Rep2_Telephone_Poste When 0 Then IsNull(@Rep2_Telephone_Poste, [Rep2_Telephone_Poste]) When 1 Then @Rep2_Telephone_Poste End
	,[Rep2_Email] = Case @ConsiderNull_Rep2_Email When 0 Then IsNull(@Rep2_Email, [Rep2_Email]) When 1 Then @Rep2_Email End
	,[Rep2_Commentaires] = Case @ConsiderNull_Rep2_Commentaires When 0 Then IsNull(@Rep2_Commentaires, [Rep2_Commentaires]) When 1 Then @Rep2_Commentaires End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)

