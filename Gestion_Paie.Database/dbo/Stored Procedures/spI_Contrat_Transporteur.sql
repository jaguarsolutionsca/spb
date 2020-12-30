

Create Procedure [spI_Contrat_Transporteur]

-- Inserts a new record in [Contrat_Transporteur] table
(
  @ContratID [varchar](10) -- for [Contrat_Transporteur].[ContratID] column
, @UniteID [varchar](6) -- for [Contrat_Transporteur].[UniteID] column
, @MunicipaliteID [varchar](6) -- for [Contrat_Transporteur].[MunicipaliteID] column
, @Taux_transporteur [real] = Null  -- for [Contrat_Transporteur].[Taux_transporteur] column
, @Taux_producteur [real] = Null  -- for [Contrat_Transporteur].[Taux_producteur] column
, @Actif [bit] = Null  -- for [Contrat_Transporteur].[Actif] column
, @ZoneID [varchar](2) -- for [Contrat_Transporteur].[ZoneID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Contrat_Transporteur]
(
	  [ContratID]
	, [UniteID]
	, [MunicipaliteID]
	, [Taux_transporteur]
	, [Taux_producteur]
	, [Actif]
	, [ZoneID]
)

Values
(
	  @ContratID
	, @UniteID
	, @MunicipaliteID
	, @Taux_transporteur
	, @Taux_producteur
	, @Actif
	, @ZoneID
)

Set NoCount Off

Return(0)


