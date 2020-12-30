
CREATE Procedure [spI_Contingentement]

-- Inserts a new record in [Contingentement] table
(
  @ID [int] = Null Output -- for [Contingentement].[ID] column
, @ContingentUsine [bit] = Null  -- for [Contingentement].[ContingentUsine] column
, @UsineID [varchar](6) = Null  -- for [Contingentement].[UsineID] column
, @RegroupementID [int] = Null  -- for [Contingentement].[RegroupementID] column
, @Annee [int] = Null  -- for [Contingentement].[Annee] column
, @PeriodeContingentement [int] = Null  -- for [Contingentement].[PeriodeContingentement] column
, @PeriodeDebut [int] = Null  -- for [Contingentement].[PeriodeDebut] column
, @PeriodeFin [int] = Null  -- for [Contingentement].[PeriodeFin] column
, @EssenceID [varchar](6) = Null  -- for [Contingentement].[EssenceID] column
, @UniteMesureID [varchar](6) = Null  -- for [Contingentement].[UniteMesureID] column
, @Volume_Usine [real] = Null  -- for [Contingentement].[Volume_Usine] column
, @Facteur [real] = Null  -- for [Contingentement].[Facteur] column
, @Volume_Fixe [real] = Null  -- for [Contingentement].[Volume_Fixe] column
, @Date_Calcul [datetime] = Null  -- for [Contingentement].[Date_Calcul] column
, @CalculAccepte [bit] = Null  -- for [Contingentement].[CalculAccepte] column
, @Code [char](4) = Null  -- for [Contingentement].[Code] column
, @Volume_Regroupement [real] = Null  -- for [Contingentement].[Volume_Regroupement] column
, @Volume_RegroupementPourcentage [real] = Null  -- for [Contingentement].[Volume_RegroupementPourcentage] column
, @MaxVolumeFixe_Pourcentage [real] = Null  -- for [Contingentement].[MaxVolumeFixe_Pourcentage] column
, @MaxVolumeFixe_ContingentementID [int] = Null  -- for [Contingentement].[MaxVolumeFixe_ContingentementID] column
, @UseVolumeFixeUnique [bit] = Null  -- for [Contingentement].[UseVolumeFixeUnique] column
, @MasseContingentVoyageDefaut [real] = Null  -- for [Contingentement].[MasseContingentVoyageDefaut] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @UseVolumeFixeUnique Is Null
	Set @UseVolumeFixeUnique = (1)

If @ID Is Null
	Begin

		Insert Into [dbo].[Contingentement]
		(
			  [ContingentUsine]
			, [UsineID]
			, [RegroupementID]
			, [Annee]
			, [PeriodeContingentement]
			, [PeriodeDebut]
			, [PeriodeFin]
			, [EssenceID]
			, [UniteMesureID]
			, [Volume_Usine]
			, [Facteur]
			, [Volume_Fixe]
			, [Date_Calcul]
			, [CalculAccepte]
			, [Code]
			, [Volume_Regroupement]
			, [Volume_RegroupementPourcentage]
			, [MaxVolumeFixe_Pourcentage]
			, [MaxVolumeFixe_ContingentementID]
			, [UseVolumeFixeUnique]
			, [MasseContingentVoyageDefaut]
		)

		Values
		(
			  @ContingentUsine
			, @UsineID
			, @RegroupementID
			, @Annee
			, @PeriodeContingentement
			, @PeriodeDebut
			, @PeriodeFin
			, @EssenceID
			, @UniteMesureID
			, @Volume_Usine
			, @Facteur
			, @Volume_Fixe
			, @Date_Calcul
			, @CalculAccepte
			, @Code
			, @Volume_Regroupement
			, @Volume_RegroupementPourcentage
			, @MaxVolumeFixe_Pourcentage
			, @MaxVolumeFixe_ContingentementID
			, @UseVolumeFixeUnique
			, @MasseContingentVoyageDefaut
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[Contingentement] On

		Insert Into [dbo].[Contingentement]
		(
			  [ID]
			, [ContingentUsine]
			, [UsineID]
			, [RegroupementID]
			, [Annee]
			, [PeriodeContingentement]
			, [PeriodeDebut]
			, [PeriodeFin]
			, [EssenceID]
			, [UniteMesureID]
			, [Volume_Usine]
			, [Facteur]
			, [Volume_Fixe]
			, [Date_Calcul]
			, [CalculAccepte]
			, [Code]
			, [Volume_Regroupement]
			, [Volume_RegroupementPourcentage]
			, [MaxVolumeFixe_Pourcentage]
			, [MaxVolumeFixe_ContingentementID]
			, [UseVolumeFixeUnique]
			, [MasseContingentVoyageDefaut]
		)

		Values
		(
			  @ID
			, @ContingentUsine
			, @UsineID
			, @RegroupementID
			, @Annee
			, @PeriodeContingentement
			, @PeriodeDebut
			, @PeriodeFin
			, @EssenceID
			, @UniteMesureID
			, @Volume_Usine
			, @Facteur
			, @Volume_Fixe
			, @Date_Calcul
			, @CalculAccepte
			, @Code
			, @Volume_Regroupement
			, @Volume_RegroupementPourcentage
			, @MaxVolumeFixe_Pourcentage
			, @MaxVolumeFixe_ContingentementID
			, @UseVolumeFixeUnique
			, @MasseContingentVoyageDefaut
		)

		Set Identity_Insert [dbo].[Contingentement] Off

	End

Set NoCount Off

Return(0)

