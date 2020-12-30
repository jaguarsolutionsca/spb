

Create Procedure [spU_Usine]

-- Update an existing record in [Usine] table

(
  @ID [varchar](6) -- for [Usine].[ID] column
, @Description [varchar](50) = Null -- for [Usine].[Description] column
, @ConsiderNull_Description bit = 0
, @UtilisationID [int] = Null -- for [Usine].[UtilisationID] column
, @ConsiderNull_UtilisationID bit = 0
, @Paye_producteur [bit] = Null -- for [Usine].[Paye_producteur] column
, @ConsiderNull_Paye_producteur bit = 0
, @Paye_transporteur [bit] = Null -- for [Usine].[Paye_transporteur] column
, @ConsiderNull_Paye_transporteur bit = 0
, @Specification [text] = Null -- for [Usine].[Specification] column
, @ConsiderNull_Specification bit = 0
, @Compte_a_recevoir [int] = Null -- for [Usine].[Compte_a_recevoir] column
, @ConsiderNull_Compte_a_recevoir bit = 0
, @Compte_ajustement [int] = Null -- for [Usine].[Compte_ajustement] column
, @ConsiderNull_Compte_ajustement bit = 0
, @Compte_transporteur [int] = Null -- for [Usine].[Compte_transporteur] column
, @ConsiderNull_Compte_transporteur bit = 0
, @Compte_producteur [int] = Null -- for [Usine].[Compte_producteur] column
, @ConsiderNull_Compte_producteur bit = 0
, @Compte_preleve_plan_conjoint [int] = Null -- for [Usine].[Compte_preleve_plan_conjoint] column
, @ConsiderNull_Compte_preleve_plan_conjoint bit = 0
, @Compte_preleve_fond_roulement [int] = Null -- for [Usine].[Compte_preleve_fond_roulement] column
, @ConsiderNull_Compte_preleve_fond_roulement bit = 0
, @Compte_preleve_fond_forestier [int] = Null -- for [Usine].[Compte_preleve_fond_forestier] column
, @ConsiderNull_Compte_preleve_fond_forestier bit = 0
, @Compte_preleve_divers [int] = Null -- for [Usine].[Compte_preleve_divers] column
, @ConsiderNull_Compte_preleve_divers bit = 0
, @Compte_mise_en_commun [int] = Null -- for [Usine].[Compte_mise_en_commun] column
, @ConsiderNull_Compte_mise_en_commun bit = 0
, @Compte_surcharge [int] = Null -- for [Usine].[Compte_surcharge] column
, @ConsiderNull_Compte_surcharge bit = 0
, @Compte_indexation_carburant [int] = Null -- for [Usine].[Compte_indexation_carburant] column
, @ConsiderNull_Compte_indexation_carburant bit = 0
, @Actif [bit] = Null -- for [Usine].[Actif] column
, @ConsiderNull_Actif bit = 0
, @NePaiePasTPS [bit] = Null -- for [Usine].[NePaiePasTPS] column
, @ConsiderNull_NePaiePasTPS bit = 0
, @NePaiePasTVQ [bit] = Null -- for [Usine].[NePaiePasTVQ] column
, @ConsiderNull_NePaiePasTVQ bit = 0
, @NoTPS [varchar](25) = Null -- for [Usine].[NoTPS] column
, @ConsiderNull_NoTPS bit = 0
, @NoTVQ [varchar](25) = Null -- for [Usine].[NoTVQ] column
, @ConsiderNull_NoTVQ bit = 0
, @Compte_chargeur [int] = Null -- for [Usine].[Compte_chargeur] column
, @ConsiderNull_Compte_chargeur bit = 0
, @UsineGestionVolume [bit] = Null -- for [Usine].[UsineGestionVolume] column
, @ConsiderNull_UsineGestionVolume bit = 0
, @AuSoinsDe [varchar](30) = Null -- for [Usine].[AuSoinsDe] column
, @ConsiderNull_AuSoinsDe bit = 0
, @Rue [varchar](30) = Null -- for [Usine].[Rue] column
, @ConsiderNull_Rue bit = 0
, @Ville [varchar](30) = Null -- for [Usine].[Ville] column
, @ConsiderNull_Ville bit = 0
, @PaysID [varchar](2) = Null -- for [Usine].[PaysID] column
, @ConsiderNull_PaysID bit = 0
, @Code_postal [varchar](7) = Null -- for [Usine].[Code_postal] column
, @ConsiderNull_Code_postal bit = 0
, @Telephone [varchar](12) = Null -- for [Usine].[Telephone] column
, @ConsiderNull_Telephone bit = 0
, @Telephone_Poste [varchar](4) = Null -- for [Usine].[Telephone_Poste] column
, @ConsiderNull_Telephone_Poste bit = 0
, @Telecopieur [varchar](12) = Null -- for [Usine].[Telecopieur] column
, @ConsiderNull_Telecopieur bit = 0
, @Telephone2 [varchar](12) = Null -- for [Usine].[Telephone2] column
, @ConsiderNull_Telephone2 bit = 0
, @Telephone2_Desc [varchar](20) = Null -- for [Usine].[Telephone2_Desc] column
, @ConsiderNull_Telephone2_Desc bit = 0
, @Telephone2_Poste [varchar](4) = Null -- for [Usine].[Telephone2_Poste] column
, @ConsiderNull_Telephone2_Poste bit = 0
, @Telephone3 [varchar](12) = Null -- for [Usine].[Telephone3] column
, @ConsiderNull_Telephone3 bit = 0
, @Telephone3_Desc [varchar](20) = Null -- for [Usine].[Telephone3_Desc] column
, @ConsiderNull_Telephone3_Desc bit = 0
, @Telephone3_Poste [varchar](4) = Null -- for [Usine].[Telephone3_Poste] column
, @ConsiderNull_Telephone3_Poste bit = 0
, @Email [varchar](80) = Null -- for [Usine].[Email] column
, @ConsiderNull_Email bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0

If @ConsiderNull_UtilisationID Is Null
	Set @ConsiderNull_UtilisationID = 0

If @ConsiderNull_Paye_producteur Is Null
	Set @ConsiderNull_Paye_producteur = 0

If @ConsiderNull_Paye_transporteur Is Null
	Set @ConsiderNull_Paye_transporteur = 0

If @ConsiderNull_Specification Is Null
	Set @ConsiderNull_Specification = 0

If @ConsiderNull_Compte_a_recevoir Is Null
	Set @ConsiderNull_Compte_a_recevoir = 0

If @ConsiderNull_Compte_ajustement Is Null
	Set @ConsiderNull_Compte_ajustement = 0

If @ConsiderNull_Compte_transporteur Is Null
	Set @ConsiderNull_Compte_transporteur = 0

If @ConsiderNull_Compte_producteur Is Null
	Set @ConsiderNull_Compte_producteur = 0

If @ConsiderNull_Compte_preleve_plan_conjoint Is Null
	Set @ConsiderNull_Compte_preleve_plan_conjoint = 0

If @ConsiderNull_Compte_preleve_fond_roulement Is Null
	Set @ConsiderNull_Compte_preleve_fond_roulement = 0

If @ConsiderNull_Compte_preleve_fond_forestier Is Null
	Set @ConsiderNull_Compte_preleve_fond_forestier = 0

If @ConsiderNull_Compte_preleve_divers Is Null
	Set @ConsiderNull_Compte_preleve_divers = 0

If @ConsiderNull_Compte_mise_en_commun Is Null
	Set @ConsiderNull_Compte_mise_en_commun = 0

If @ConsiderNull_Compte_surcharge Is Null
	Set @ConsiderNull_Compte_surcharge = 0

If @ConsiderNull_Compte_indexation_carburant Is Null
	Set @ConsiderNull_Compte_indexation_carburant = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0

If @ConsiderNull_NePaiePasTPS Is Null
	Set @ConsiderNull_NePaiePasTPS = 0

If @ConsiderNull_NePaiePasTVQ Is Null
	Set @ConsiderNull_NePaiePasTVQ = 0

If @ConsiderNull_NoTPS Is Null
	Set @ConsiderNull_NoTPS = 0

If @ConsiderNull_NoTVQ Is Null
	Set @ConsiderNull_NoTVQ = 0

If @ConsiderNull_Compte_chargeur Is Null
	Set @ConsiderNull_Compte_chargeur = 0

If @ConsiderNull_UsineGestionVolume Is Null
	Set @ConsiderNull_UsineGestionVolume = 0

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

If @ConsiderNull_Email Is Null
	Set @ConsiderNull_Email = 0


Update [dbo].[Usine]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[UtilisationID] = Case @ConsiderNull_UtilisationID When 0 Then IsNull(@UtilisationID, [UtilisationID]) When 1 Then @UtilisationID End
	,[Paye_producteur] = Case @ConsiderNull_Paye_producteur When 0 Then IsNull(@Paye_producteur, [Paye_producteur]) When 1 Then @Paye_producteur End
	,[Paye_transporteur] = Case @ConsiderNull_Paye_transporteur When 0 Then IsNull(@Paye_transporteur, [Paye_transporteur]) When 1 Then @Paye_transporteur End
	,[Specification] = Case @ConsiderNull_Specification When 0 Then IsNull(@Specification, [Specification]) When 1 Then @Specification End
	,[Compte_a_recevoir] = Case @ConsiderNull_Compte_a_recevoir When 0 Then IsNull(@Compte_a_recevoir, [Compte_a_recevoir]) When 1 Then @Compte_a_recevoir End
	,[Compte_ajustement] = Case @ConsiderNull_Compte_ajustement When 0 Then IsNull(@Compte_ajustement, [Compte_ajustement]) When 1 Then @Compte_ajustement End
	,[Compte_transporteur] = Case @ConsiderNull_Compte_transporteur When 0 Then IsNull(@Compte_transporteur, [Compte_transporteur]) When 1 Then @Compte_transporteur End
	,[Compte_producteur] = Case @ConsiderNull_Compte_producteur When 0 Then IsNull(@Compte_producteur, [Compte_producteur]) When 1 Then @Compte_producteur End
	,[Compte_preleve_plan_conjoint] = Case @ConsiderNull_Compte_preleve_plan_conjoint When 0 Then IsNull(@Compte_preleve_plan_conjoint, [Compte_preleve_plan_conjoint]) When 1 Then @Compte_preleve_plan_conjoint End
	,[Compte_preleve_fond_roulement] = Case @ConsiderNull_Compte_preleve_fond_roulement When 0 Then IsNull(@Compte_preleve_fond_roulement, [Compte_preleve_fond_roulement]) When 1 Then @Compte_preleve_fond_roulement End
	,[Compte_preleve_fond_forestier] = Case @ConsiderNull_Compte_preleve_fond_forestier When 0 Then IsNull(@Compte_preleve_fond_forestier, [Compte_preleve_fond_forestier]) When 1 Then @Compte_preleve_fond_forestier End
	,[Compte_preleve_divers] = Case @ConsiderNull_Compte_preleve_divers When 0 Then IsNull(@Compte_preleve_divers, [Compte_preleve_divers]) When 1 Then @Compte_preleve_divers End
	,[Compte_mise_en_commun] = Case @ConsiderNull_Compte_mise_en_commun When 0 Then IsNull(@Compte_mise_en_commun, [Compte_mise_en_commun]) When 1 Then @Compte_mise_en_commun End
	,[Compte_surcharge] = Case @ConsiderNull_Compte_surcharge When 0 Then IsNull(@Compte_surcharge, [Compte_surcharge]) When 1 Then @Compte_surcharge End
	,[Compte_indexation_carburant] = Case @ConsiderNull_Compte_indexation_carburant When 0 Then IsNull(@Compte_indexation_carburant, [Compte_indexation_carburant]) When 1 Then @Compte_indexation_carburant End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End
	,[NePaiePasTPS] = Case @ConsiderNull_NePaiePasTPS When 0 Then IsNull(@NePaiePasTPS, [NePaiePasTPS]) When 1 Then @NePaiePasTPS End
	,[NePaiePasTVQ] = Case @ConsiderNull_NePaiePasTVQ When 0 Then IsNull(@NePaiePasTVQ, [NePaiePasTVQ]) When 1 Then @NePaiePasTVQ End
	,[NoTPS] = Case @ConsiderNull_NoTPS When 0 Then IsNull(@NoTPS, [NoTPS]) When 1 Then @NoTPS End
	,[NoTVQ] = Case @ConsiderNull_NoTVQ When 0 Then IsNull(@NoTVQ, [NoTVQ]) When 1 Then @NoTVQ End
	,[Compte_chargeur] = Case @ConsiderNull_Compte_chargeur When 0 Then IsNull(@Compte_chargeur, [Compte_chargeur]) When 1 Then @Compte_chargeur End
	,[UsineGestionVolume] = Case @ConsiderNull_UsineGestionVolume When 0 Then IsNull(@UsineGestionVolume, [UsineGestionVolume]) When 1 Then @UsineGestionVolume End
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
	,[Email] = Case @ConsiderNull_Email When 0 Then IsNull(@Email, [Email]) When 1 Then @Email End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


