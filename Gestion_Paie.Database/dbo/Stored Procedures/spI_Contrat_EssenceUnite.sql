

Create Procedure [spI_Contrat_EssenceUnite]

-- Inserts a new record in [Contrat_EssenceUnite] table
(
  @ContratID [varchar](10) -- for [Contrat_EssenceUnite].[ContratID] column
, @EssenceID [varchar](6) -- for [Contrat_EssenceUnite].[EssenceID] column
, @UniteID [varchar](6) -- for [Contrat_EssenceUnite].[UniteID] column
, @Code [char](4) -- for [Contrat_EssenceUnite].[Code] column
, @Quantite_prevue [float] = Null  -- for [Contrat_EssenceUnite].[Quantite_prevue] column
, @Taux_usine [float] = Null  -- for [Contrat_EssenceUnite].[Taux_usine] column
, @Taux_producteur [real] = Null  -- for [Contrat_EssenceUnite].[Taux_producteur] column
, @Actif [bit] = Null  -- for [Contrat_EssenceUnite].[Actif] column
, @Description [varchar](50) = Null  -- for [Contrat_EssenceUnite].[Description] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Contrat_EssenceUnite]
(
	  [ContratID]
	, [EssenceID]
	, [UniteID]
	, [Code]
	, [Quantite_prevue]
	, [Taux_usine]
	, [Taux_producteur]
	, [Actif]
	, [Description]
)

Values
(
	  @ContratID
	, @EssenceID
	, @UniteID
	, @Code
	, @Quantite_prevue
	, @Taux_usine
	, @Taux_producteur
	, @Actif
	, @Description
)

Set NoCount Off

Return(0)


