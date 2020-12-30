

Create Procedure [spI_Ajustement_Transporteur]

-- Inserts a new record in [Ajustement_Transporteur] table
(
  @AjustementID [int] -- for [Ajustement_Transporteur].[AjustementID] column
, @UniteID [varchar](6) -- for [Ajustement_Transporteur].[UniteID] column
, @MunicipaliteID [varchar](6) -- for [Ajustement_Transporteur].[MunicipaliteID] column
, @ContratID [varchar](10) = Null  -- for [Ajustement_Transporteur].[ContratID] column
, @Taux_transporteur [real] = Null  -- for [Ajustement_Transporteur].[Taux_transporteur] column
, @Date_Modification [datetime] = Null  -- for [Ajustement_Transporteur].[Date_Modification] column
, @ZoneID [varchar](2) -- for [Ajustement_Transporteur].[ZoneID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Ajustement_Transporteur]
(
	  [AjustementID]
	, [UniteID]
	, [MunicipaliteID]
	, [ContratID]
	, [Taux_transporteur]
	, [Date_Modification]
	, [ZoneID]
)

Values
(
	  @AjustementID
	, @UniteID
	, @MunicipaliteID
	, @ContratID
	, @Taux_transporteur
	, @Date_Modification
	, @ZoneID
)

Set NoCount Off

Return(0)


