

Create Procedure [spI_Permit]

-- Inserts a new record in [Permit] table
(
  @ID [int] -- for [Permit].[ID] column
, @DatePermit [smalldatetime] = Null  -- for [Permit].[DatePermit] column
, @DateDebut [smalldatetime] = Null  -- for [Permit].[DateDebut] column
, @DateFin [smalldatetime] = Null  -- for [Permit].[DateFin] column
, @Annee [int] = Null  -- for [Permit].[Annee] column
, @Periode [int] = Null  -- for [Permit].[Periode] column
, @ContratID [varchar](10) = Null  -- for [Permit].[ContratID] column
, @EssenceID [varchar](6) = Null  -- for [Permit].[EssenceID] column
, @PermitSciage [bit] = Null  -- for [Permit].[PermitSciage] column
, @TransporteurID [varchar](15) = Null  -- for [Permit].[TransporteurID] column
, @VR [varchar](10) = Null  -- for [Permit].[VR] column
, @ProducteurDroitCoupeID [varchar](15) = Null  -- for [Permit].[ProducteurDroitCoupeID] column
, @ProducteurEntentePaiementID [varchar](15) = Null  -- for [Permit].[ProducteurEntentePaiementID] column
, @PermitLivre [bit] = Null  -- for [Permit].[PermitLivre] column
, @PermitImprime [bit] = Null  -- for [Permit].[PermitImprime] column
, @PermitAnnule [bit] = Null  -- for [Permit].[PermitAnnule] column
, @LotID [int] = Null  -- for [Permit].[LotID] column
, @EssenceSciage [varchar](25) = Null  -- for [Permit].[EssenceSciage] column
, @Code [char](4) = Null  -- for [Permit].[Code] column
, @Remarques [varchar](2000) = Null  -- for [Permit].[Remarques] column
, @ChargeurID [varchar](15) = Null  -- for [Permit].[ChargeurID] column
, @ZoneID [varchar](2) = Null  -- for [Permit].[ZoneID] column
, @MunicipaliteID [varchar](6) = Null  -- for [Permit].[MunicipaliteID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Permit]
(
	  [ID]
	, [DatePermit]
	, [DateDebut]
	, [DateFin]
	, [Annee]
	, [Periode]
	, [ContratID]
	, [EssenceID]
	, [PermitSciage]
	, [TransporteurID]
	, [VR]
	, [ProducteurDroitCoupeID]
	, [ProducteurEntentePaiementID]
	, [PermitLivre]
	, [PermitImprime]
	, [PermitAnnule]
	, [LotID]
	, [EssenceSciage]
	, [Code]
	, [Remarques]
	, [ChargeurID]
	, [ZoneID]
	, [MunicipaliteID]
)

Values
(
	  @ID
	, @DatePermit
	, @DateDebut
	, @DateFin
	, @Annee
	, @Periode
	, @ContratID
	, @EssenceID
	, @PermitSciage
	, @TransporteurID
	, @VR
	, @ProducteurDroitCoupeID
	, @ProducteurEntentePaiementID
	, @PermitLivre
	, @PermitImprime
	, @PermitAnnule
	, @LotID
	, @EssenceSciage
	, @Code
	, @Remarques
	, @ChargeurID
	, @ZoneID
	, @MunicipaliteID
)

Set NoCount Off

Return(0)


