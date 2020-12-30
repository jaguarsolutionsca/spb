CREATE PROCEDURE [dbo].[spI_Essence_Unite]
@EssenceID VARCHAR (6), @UniteID VARCHAR (6), @Facteur_M3app REAL=Null, @Facteur_M3sol REAL=Null, @Facteur_FPBQ REAL=Null, @Actif BIT=Null, @Preleve_plan_conjoint REAL=Null, @Preleve_plan_conjoint_Override BIT=Null, @Preleve_fond_roulement REAL=Null, @Preleve_fond_roulement_Override BIT=Null, @Preleve_fond_forestier REAL=Null, @Preleve_fond_forestier_Override BIT=Null, @Preleve_divers REAL=Null, @Preleve_divers_Override BIT=Null, @UseMontant BIT=Null
AS
Set NoCount On

If @UseMontant Is Null
	Set @UseMontant = (1)

Insert Into [dbo].[Essence_Unite]
(
	  [EssenceID]
	, [UniteID]
	, [Facteur_M3app]
	, [Facteur_M3sol]
	, [Facteur_FPBQ]
	, [Actif]
	, [Preleve_plan_conjoint]
	, [Preleve_plan_conjoint_Override]
	, [Preleve_fond_roulement]
	, [Preleve_fond_roulement_Override]
	, [Preleve_fond_forestier]
	, [Preleve_fond_forestier_Override]
	, [Preleve_divers]
	, [Preleve_divers_Override]
	, [UseMontant]
)

Values
(
	  @EssenceID
	, @UniteID
	, @Facteur_M3app
	, @Facteur_M3sol
	, @Facteur_FPBQ
	, @Actif
	, @Preleve_plan_conjoint
	, @Preleve_plan_conjoint_Override
	, @Preleve_fond_roulement
	, @Preleve_fond_roulement_Override
	, @Preleve_fond_forestier
	, @Preleve_fond_forestier_Override
	, @Preleve_divers
	, @Preleve_divers_Override
	, @UseMontant
)

Set NoCount Off

Return(0)


