CREATE PROCEDURE [dbo].[spU_Essence_Unite]
@EssenceID VARCHAR (6), @UniteID VARCHAR (6), @Facteur_M3app REAL=Null, @ConsiderNull_Facteur_M3app BIT=0, @Facteur_M3sol REAL=Null, @ConsiderNull_Facteur_M3sol BIT=0, @Facteur_FPBQ REAL=Null, @ConsiderNull_Facteur_FPBQ BIT=0, @Actif BIT=Null, @ConsiderNull_Actif BIT=0, @Preleve_plan_conjoint REAL=Null, @ConsiderNull_Preleve_plan_conjoint BIT=0, @Preleve_plan_conjoint_Override BIT=Null, @ConsiderNull_Preleve_plan_conjoint_Override BIT=0, @Preleve_fond_roulement REAL=Null, @ConsiderNull_Preleve_fond_roulement BIT=0, @Preleve_fond_roulement_Override BIT=Null, @ConsiderNull_Preleve_fond_roulement_Override BIT=0, @Preleve_fond_forestier REAL=Null, @ConsiderNull_Preleve_fond_forestier BIT=0, @Preleve_fond_forestier_Override BIT=Null, @ConsiderNull_Preleve_fond_forestier_Override BIT=0, @Preleve_divers REAL=Null, @ConsiderNull_Preleve_divers BIT=0, @Preleve_divers_Override BIT=Null, @ConsiderNull_Preleve_divers_Override BIT=0, @UseMontant BIT, @ConsiderNull_UseMontant BIT=0
AS
Set NoCount On

If @ConsiderNull_Facteur_M3app Is Null
	Set @ConsiderNull_Facteur_M3app = 0

If @ConsiderNull_Facteur_M3sol Is Null
	Set @ConsiderNull_Facteur_M3sol = 0

If @ConsiderNull_Facteur_FPBQ Is Null
	Set @ConsiderNull_Facteur_FPBQ = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0

If @ConsiderNull_Preleve_plan_conjoint Is Null
	Set @ConsiderNull_Preleve_plan_conjoint = 0

If @ConsiderNull_Preleve_plan_conjoint_Override Is Null
	Set @ConsiderNull_Preleve_plan_conjoint_Override = 0

If @ConsiderNull_Preleve_fond_roulement Is Null
	Set @ConsiderNull_Preleve_fond_roulement = 0

If @ConsiderNull_Preleve_fond_roulement_Override Is Null
	Set @ConsiderNull_Preleve_fond_roulement_Override = 0

If @ConsiderNull_Preleve_fond_forestier Is Null
	Set @ConsiderNull_Preleve_fond_forestier = 0

If @ConsiderNull_Preleve_fond_forestier_Override Is Null
	Set @ConsiderNull_Preleve_fond_forestier_Override = 0

If @ConsiderNull_Preleve_divers Is Null
	Set @ConsiderNull_Preleve_divers = 0

If @ConsiderNull_Preleve_divers_Override Is Null
	Set @ConsiderNull_Preleve_divers_Override = 0

If @ConsiderNull_UseMontant Is Null
	Set @ConsiderNull_UseMontant = 0


Update [dbo].[Essence_Unite]

Set
	 [Facteur_M3app] = Case @ConsiderNull_Facteur_M3app When 0 Then IsNull(@Facteur_M3app, [Facteur_M3app]) When 1 Then @Facteur_M3app End
	,[Facteur_M3sol] = Case @ConsiderNull_Facteur_M3sol When 0 Then IsNull(@Facteur_M3sol, [Facteur_M3sol]) When 1 Then @Facteur_M3sol End
	,[Facteur_FPBQ] = Case @ConsiderNull_Facteur_FPBQ When 0 Then IsNull(@Facteur_FPBQ, [Facteur_FPBQ]) When 1 Then @Facteur_FPBQ End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End
	,[Preleve_plan_conjoint] = Case @ConsiderNull_Preleve_plan_conjoint When 0 Then IsNull(@Preleve_plan_conjoint, [Preleve_plan_conjoint]) When 1 Then @Preleve_plan_conjoint End
	,[Preleve_plan_conjoint_Override] = Case @ConsiderNull_Preleve_plan_conjoint_Override When 0 Then IsNull(@Preleve_plan_conjoint_Override, [Preleve_plan_conjoint_Override]) When 1 Then @Preleve_plan_conjoint_Override End
	,[Preleve_fond_roulement] = Case @ConsiderNull_Preleve_fond_roulement When 0 Then IsNull(@Preleve_fond_roulement, [Preleve_fond_roulement]) When 1 Then @Preleve_fond_roulement End
	,[Preleve_fond_roulement_Override] = Case @ConsiderNull_Preleve_fond_roulement_Override When 0 Then IsNull(@Preleve_fond_roulement_Override, [Preleve_fond_roulement_Override]) When 1 Then @Preleve_fond_roulement_Override End
	,[Preleve_fond_forestier] = Case @ConsiderNull_Preleve_fond_forestier When 0 Then IsNull(@Preleve_fond_forestier, [Preleve_fond_forestier]) When 1 Then @Preleve_fond_forestier End
	,[Preleve_fond_forestier_Override] = Case @ConsiderNull_Preleve_fond_forestier_Override When 0 Then IsNull(@Preleve_fond_forestier_Override, [Preleve_fond_forestier_Override]) When 1 Then @Preleve_fond_forestier_Override End
	,[Preleve_divers] = Case @ConsiderNull_Preleve_divers When 0 Then IsNull(@Preleve_divers, [Preleve_divers]) When 1 Then @Preleve_divers End
	,[Preleve_divers_Override] = Case @ConsiderNull_Preleve_divers_Override When 0 Then IsNull(@Preleve_divers_Override, [Preleve_divers_Override]) When 1 Then @Preleve_divers_Override End
	,[UseMontant] = Case @ConsiderNull_UseMontant When 0 Then IsNull(@UseMontant, [UseMontant]) When 1 Then @UseMontant End

Where
	     ([EssenceID] = @EssenceID)
	And ([UniteID] = @UniteID)

Set NoCount Off

Return(0)


