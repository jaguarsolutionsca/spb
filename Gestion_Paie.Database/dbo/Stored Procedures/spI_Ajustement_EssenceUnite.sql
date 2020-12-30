CREATE Procedure [dbo].[spI_Ajustement_EssenceUnite]

-- Inserts a new record in [Ajustement_EssenceUnite] table
(
  @AjustementID [int] -- for [Ajustement_EssenceUnite].[AjustementID] column
, @EssenceID [varchar](6) -- for [Ajustement_EssenceUnite].[EssenceID] column
, @UniteID [varchar](6) -- for [Ajustement_EssenceUnite].[UniteID] column
, @ContratID [varchar](10) = Null  -- for [Ajustement_EssenceUnite].[ContratID] column
, @Taux_usine [real] = Null  -- for [Ajustement_EssenceUnite].[Taux_usine] column
, @Taux_producteur [real] = Null  -- for [Ajustement_EssenceUnite].[Taux_producteur] column
, @Taux_transporteur [real] = Null  -- for [Ajustement_EssenceUnite].[Taux_transporteur] column
, @Date_Modification [datetime] = Null  -- for [Ajustement_EssenceUnite].[Date_Modification] column
, @Code [char](4) -- for [Ajustement_EssenceUnite].[Code] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Ajustement_EssenceUnite]
(
	  [AjustementID]
	, [EssenceID]
	, [UniteID]
	, [ContratID]
	, [Taux_usine]
	, [Taux_producteur]
	, [Taux_transporteur]
	, [Date_Modification]
	, [Code]
)

Values
(
	  @AjustementID
	, @EssenceID
	, @UniteID
	, @ContratID
	, @Taux_usine
	, @Taux_producteur
	, @Taux_transporteur
	, @Date_Modification
	, @Code
)

Set NoCount Off

Return(0)
