

Create Procedure [spI_Contrat]

-- Inserts a new record in [Contrat] table
(
  @ID [varchar](10) -- for [Contrat].[ID] column
, @Description [varchar](50) = Null  -- for [Contrat].[Description] column
, @UsineID [varchar](6) = Null  -- for [Contrat].[UsineID] column
, @Annee [int] = Null  -- for [Contrat].[Annee] column
, @Date_debut [smalldatetime] = Null  -- for [Contrat].[Date_debut] column
, @Date_fin [smalldatetime] = Null  -- for [Contrat].[Date_fin] column
, @Actif [bit] = Null  -- for [Contrat].[Actif] column
, @PaieTransporteur [bit] = Null  -- for [Contrat].[PaieTransporteur] column
, @Taux_Surcharge [float] = Null  -- for [Contrat].[Taux_Surcharge] column
, @SurchargeManuel [bit] = Null  -- for [Contrat].[SurchargeManuel] column
, @TxTransSameProd [bit] = Null  -- for [Contrat].[TxTransSameProd] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Contrat]
(
	  [ID]
	, [Description]
	, [UsineID]
	, [Annee]
	, [Date_debut]
	, [Date_fin]
	, [Actif]
	, [PaieTransporteur]
	, [Taux_Surcharge]
	, [SurchargeManuel]
	, [TxTransSameProd]
)

Values
(
	  @ID
	, @Description
	, @UsineID
	, @Annee
	, @Date_debut
	, @Date_fin
	, @Actif
	, @PaieTransporteur
	, @Taux_Surcharge
	, @SurchargeManuel
	, @TxTransSameProd
)

Set NoCount Off

Return(0)


