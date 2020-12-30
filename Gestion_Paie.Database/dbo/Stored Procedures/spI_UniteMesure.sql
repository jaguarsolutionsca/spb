

Create Procedure [spI_UniteMesure]

-- Inserts a new record in [UniteMesure] table
(
  @ID [varchar](6) -- for [UniteMesure].[ID] column
, @Description [varchar](25) = Null  -- for [UniteMesure].[Description] column
, @Nb_decimale [int] = Null  -- for [UniteMesure].[Nb_decimale] column
, @Actif [bit] = Null  -- for [UniteMesure].[Actif] column
, @UseMontant [bit] = Null  -- for [UniteMesure].[UseMontant] column
, @Montant_Preleve_plan_conjoint [float] = Null  -- for [UniteMesure].[Montant_Preleve_plan_conjoint] column
, @Montant_Preleve_fond_roulement [float] = Null  -- for [UniteMesure].[Montant_Preleve_fond_roulement] column
, @Montant_Preleve_fond_forestier [float] = Null  -- for [UniteMesure].[Montant_Preleve_fond_forestier] column
, @Montant_Preleve_divers [float] = Null  -- for [UniteMesure].[Montant_Preleve_divers] column
, @Pourc_Preleve_plan_conjoint [float] = Null  -- for [UniteMesure].[Pourc_Preleve_plan_conjoint] column
, @Pourc_Preleve_fond_roulement [float] = Null  -- for [UniteMesure].[Pourc_Preleve_fond_roulement] column
, @Pourc_Preleve_fond_forestier [float] = Null  -- for [UniteMesure].[Pourc_Preleve_fond_forestier] column
, @Pourc_Preleve_divers [float] = Null  -- for [UniteMesure].[Pourc_Preleve_divers] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[UniteMesure]
(
	  [ID]
	, [Description]
	, [Nb_decimale]
	, [Actif]
	, [UseMontant]
	, [Montant_Preleve_plan_conjoint]
	, [Montant_Preleve_fond_roulement]
	, [Montant_Preleve_fond_forestier]
	, [Montant_Preleve_divers]
	, [Pourc_Preleve_plan_conjoint]
	, [Pourc_Preleve_fond_roulement]
	, [Pourc_Preleve_fond_forestier]
	, [Pourc_Preleve_divers]
)

Values
(
	  @ID
	, @Description
	, @Nb_decimale
	, @Actif
	, @UseMontant
	, @Montant_Preleve_plan_conjoint
	, @Montant_Preleve_fond_roulement
	, @Montant_Preleve_fond_forestier
	, @Montant_Preleve_divers
	, @Pourc_Preleve_plan_conjoint
	, @Pourc_Preleve_fond_roulement
	, @Pourc_Preleve_fond_forestier
	, @Pourc_Preleve_divers
)

Set NoCount Off

Return(0)


