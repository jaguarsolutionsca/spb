
CREATE Procedure [spI_Lot]

-- Inserts a new record in [Lot] table
(
  @CantonID [varchar](6) = Null  -- for [Lot].[CantonID] column
, @Rang [varchar](25) = Null  -- for [Lot].[Rang] column
, @Lot [varchar](6) = Null  -- for [Lot].[Lot] column
, @MunicipaliteID [varchar](6) = Null  -- for [Lot].[MunicipaliteID] column
, @Superficie_total [real] = Null  -- for [Lot].[Superficie_total] column
, @Superficie_boisee [real] = Null  -- for [Lot].[Superficie_boisee] column
, @ProprietaireID [varchar](15) = Null  -- for [Lot].[ProprietaireID] column
, @ContingentID [varchar](15) = Null  -- for [Lot].[ContingentID] column
, @Contingent_Date [smalldatetime] = Null  -- for [Lot].[Contingent_Date] column
, @Droit_coupeID [varchar](15) = Null  -- for [Lot].[Droit_coupeID] column
, @Droit_coupe_Date [smalldatetime] = Null  -- for [Lot].[Droit_coupe_Date] column
, @Entente_paiementID [varchar](15) = Null  -- for [Lot].[Entente_paiementID] column
, @Entente_paiement_Date [smalldatetime] = Null  -- for [Lot].[Entente_paiement_Date] column
, @Actif [bit] = Null  -- for [Lot].[Actif] column
, @ID [int] = Null Output -- for [Lot].[ID] column
, @Sequence [varchar](6) = Null  -- for [Lot].[Sequence] column
, @Partie [bit] = Null  -- for [Lot].[Partie] column
, @Matricule [varchar](20) = Null  -- for [Lot].[Matricule] column
, @ZoneID [varchar](2) = Null  -- for [Lot].[ZoneID] column
, @Secteur [varchar](2) = Null  -- for [Lot].[Secteur] column
, @Cadastre [int] = Null  -- for [Lot].[Cadastre] column
, @Reforme [bit] = Null  -- for [Lot].[Reforme] column
, @LotsComplementaires [varchar](255) = Null  -- for [Lot].[LotsComplementaires] column
, @Certifie [bit] = Null  -- for [Lot].[Certifie] column
, @NumeroCertification [varchar](50) = Null  -- for [Lot].[NumeroCertification] column
, @OGC [bit] = Null  -- for [Lot].[OGC] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[Lot]
		(
			  [CantonID]
			, [Rang]
			, [Lot]
			, [MunicipaliteID]
			, [Superficie_total]
			, [Superficie_boisee]
			, [ProprietaireID]
			, [ContingentID]
			, [Contingent_Date]
			, [Droit_coupeID]
			, [Droit_coupe_Date]
			, [Entente_paiementID]
			, [Entente_paiement_Date]
			, [Actif]
			, [Sequence]
			, [Partie]
			, [Matricule]
			, [ZoneID]
			, [Secteur]
			, [Cadastre]
			, [Reforme]
			, [LotsComplementaires]
			, [Certifie]
			, [NumeroCertification]
			, [OGC]
		)

		Values
		(
			  @CantonID
			, @Rang
			, @Lot
			, @MunicipaliteID
			, @Superficie_total
			, @Superficie_boisee
			, @ProprietaireID
			, @ContingentID
			, @Contingent_Date
			, @Droit_coupeID
			, @Droit_coupe_Date
			, @Entente_paiementID
			, @Entente_paiement_Date
			, @Actif
			, @Sequence
			, @Partie
			, @Matricule
			, @ZoneID
			, @Secteur
			, @Cadastre
			, @Reforme
			, @LotsComplementaires
			, @Certifie
			, @NumeroCertification
			, @OGC
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[Lot] On

		Insert Into [dbo].[Lot]
		(
			  [CantonID]
			, [Rang]
			, [Lot]
			, [MunicipaliteID]
			, [Superficie_total]
			, [Superficie_boisee]
			, [ProprietaireID]
			, [ContingentID]
			, [Contingent_Date]
			, [Droit_coupeID]
			, [Droit_coupe_Date]
			, [Entente_paiementID]
			, [Entente_paiement_Date]
			, [Actif]
			, [ID]
			, [Sequence]
			, [Partie]
			, [Matricule]
			, [ZoneID]
			, [Secteur]
			, [Cadastre]
			, [Reforme]
			, [LotsComplementaires]
			, [Certifie]
			, [NumeroCertification]
			, [OGC]
		)

		Values
		(
			  @CantonID
			, @Rang
			, @Lot
			, @MunicipaliteID
			, @Superficie_total
			, @Superficie_boisee
			, @ProprietaireID
			, @ContingentID
			, @Contingent_Date
			, @Droit_coupeID
			, @Droit_coupe_Date
			, @Entente_paiementID
			, @Entente_paiement_Date
			, @Actif
			, @ID
			, @Sequence
			, @Partie
			, @Matricule
			, @ZoneID
			, @Secteur
			, @Cadastre
			, @Reforme
			, @LotsComplementaires
			, @Certifie
			, @NumeroCertification
			, @OGC
		)

		Set Identity_Insert [dbo].[Lot] Off

	End

Set NoCount Off

Return(0)

