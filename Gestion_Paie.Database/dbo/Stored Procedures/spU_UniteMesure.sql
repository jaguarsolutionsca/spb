

Create Procedure [spU_UniteMesure]

-- Update an existing record in [UniteMesure] table

(
  @ID [varchar](6) -- for [UniteMesure].[ID] column
, @Description [varchar](25) = Null -- for [UniteMesure].[Description] column
, @ConsiderNull_Description bit = 0
, @Nb_decimale [int] = Null -- for [UniteMesure].[Nb_decimale] column
, @ConsiderNull_Nb_decimale bit = 0
, @Actif [bit] = Null -- for [UniteMesure].[Actif] column
, @ConsiderNull_Actif bit = 0
, @UseMontant [bit] = Null -- for [UniteMesure].[UseMontant] column
, @ConsiderNull_UseMontant bit = 0
, @Montant_Preleve_plan_conjoint [float] = Null -- for [UniteMesure].[Montant_Preleve_plan_conjoint] column
, @ConsiderNull_Montant_Preleve_plan_conjoint bit = 0
, @Montant_Preleve_fond_roulement [float] = Null -- for [UniteMesure].[Montant_Preleve_fond_roulement] column
, @ConsiderNull_Montant_Preleve_fond_roulement bit = 0
, @Montant_Preleve_fond_forestier [float] = Null -- for [UniteMesure].[Montant_Preleve_fond_forestier] column
, @ConsiderNull_Montant_Preleve_fond_forestier bit = 0
, @Montant_Preleve_divers [float] = Null -- for [UniteMesure].[Montant_Preleve_divers] column
, @ConsiderNull_Montant_Preleve_divers bit = 0
, @Pourc_Preleve_plan_conjoint [float] = Null -- for [UniteMesure].[Pourc_Preleve_plan_conjoint] column
, @ConsiderNull_Pourc_Preleve_plan_conjoint bit = 0
, @Pourc_Preleve_fond_roulement [float] = Null -- for [UniteMesure].[Pourc_Preleve_fond_roulement] column
, @ConsiderNull_Pourc_Preleve_fond_roulement bit = 0
, @Pourc_Preleve_fond_forestier [float] = Null -- for [UniteMesure].[Pourc_Preleve_fond_forestier] column
, @ConsiderNull_Pourc_Preleve_fond_forestier bit = 0
, @Pourc_Preleve_divers [float] = Null -- for [UniteMesure].[Pourc_Preleve_divers] column
, @ConsiderNull_Pourc_Preleve_divers bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0

If @ConsiderNull_Nb_decimale Is Null
	Set @ConsiderNull_Nb_decimale = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0

If @ConsiderNull_UseMontant Is Null
	Set @ConsiderNull_UseMontant = 0

If @ConsiderNull_Montant_Preleve_plan_conjoint Is Null
	Set @ConsiderNull_Montant_Preleve_plan_conjoint = 0

If @ConsiderNull_Montant_Preleve_fond_roulement Is Null
	Set @ConsiderNull_Montant_Preleve_fond_roulement = 0

If @ConsiderNull_Montant_Preleve_fond_forestier Is Null
	Set @ConsiderNull_Montant_Preleve_fond_forestier = 0

If @ConsiderNull_Montant_Preleve_divers Is Null
	Set @ConsiderNull_Montant_Preleve_divers = 0

If @ConsiderNull_Pourc_Preleve_plan_conjoint Is Null
	Set @ConsiderNull_Pourc_Preleve_plan_conjoint = 0

If @ConsiderNull_Pourc_Preleve_fond_roulement Is Null
	Set @ConsiderNull_Pourc_Preleve_fond_roulement = 0

If @ConsiderNull_Pourc_Preleve_fond_forestier Is Null
	Set @ConsiderNull_Pourc_Preleve_fond_forestier = 0

If @ConsiderNull_Pourc_Preleve_divers Is Null
	Set @ConsiderNull_Pourc_Preleve_divers = 0


Update [dbo].[UniteMesure]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[Nb_decimale] = Case @ConsiderNull_Nb_decimale When 0 Then IsNull(@Nb_decimale, [Nb_decimale]) When 1 Then @Nb_decimale End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End
	,[UseMontant] = Case @ConsiderNull_UseMontant When 0 Then IsNull(@UseMontant, [UseMontant]) When 1 Then @UseMontant End
	,[Montant_Preleve_plan_conjoint] = Case @ConsiderNull_Montant_Preleve_plan_conjoint When 0 Then IsNull(@Montant_Preleve_plan_conjoint, [Montant_Preleve_plan_conjoint]) When 1 Then @Montant_Preleve_plan_conjoint End
	,[Montant_Preleve_fond_roulement] = Case @ConsiderNull_Montant_Preleve_fond_roulement When 0 Then IsNull(@Montant_Preleve_fond_roulement, [Montant_Preleve_fond_roulement]) When 1 Then @Montant_Preleve_fond_roulement End
	,[Montant_Preleve_fond_forestier] = Case @ConsiderNull_Montant_Preleve_fond_forestier When 0 Then IsNull(@Montant_Preleve_fond_forestier, [Montant_Preleve_fond_forestier]) When 1 Then @Montant_Preleve_fond_forestier End
	,[Montant_Preleve_divers] = Case @ConsiderNull_Montant_Preleve_divers When 0 Then IsNull(@Montant_Preleve_divers, [Montant_Preleve_divers]) When 1 Then @Montant_Preleve_divers End
	,[Pourc_Preleve_plan_conjoint] = Case @ConsiderNull_Pourc_Preleve_plan_conjoint When 0 Then IsNull(@Pourc_Preleve_plan_conjoint, [Pourc_Preleve_plan_conjoint]) When 1 Then @Pourc_Preleve_plan_conjoint End
	,[Pourc_Preleve_fond_roulement] = Case @ConsiderNull_Pourc_Preleve_fond_roulement When 0 Then IsNull(@Pourc_Preleve_fond_roulement, [Pourc_Preleve_fond_roulement]) When 1 Then @Pourc_Preleve_fond_roulement End
	,[Pourc_Preleve_fond_forestier] = Case @ConsiderNull_Pourc_Preleve_fond_forestier When 0 Then IsNull(@Pourc_Preleve_fond_forestier, [Pourc_Preleve_fond_forestier]) When 1 Then @Pourc_Preleve_fond_forestier End
	,[Pourc_Preleve_divers] = Case @ConsiderNull_Pourc_Preleve_divers When 0 Then IsNull(@Pourc_Preleve_divers, [Pourc_Preleve_divers]) When 1 Then @Pourc_Preleve_divers End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


