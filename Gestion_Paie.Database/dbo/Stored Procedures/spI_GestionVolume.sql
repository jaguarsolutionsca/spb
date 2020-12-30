

Create Procedure [spI_GestionVolume]

-- Inserts a new record in [GestionVolume] table
(
  @ID [int] = Null Output -- for [GestionVolume].[ID] column
, @DateLivraison [datetime] = Null  -- for [GestionVolume].[DateLivraison] column
, @UsineID [varchar](6) = Null  -- for [GestionVolume].[UsineID] column
, @UniteMesureID [varchar](6) = Null  -- for [GestionVolume].[UniteMesureID] column
, @ProducteurID [varchar](15) = Null  -- for [GestionVolume].[ProducteurID] column
, @Annee [int] = Null  -- for [GestionVolume].[Annee] column
, @Periode [int] = Null  -- for [GestionVolume].[Periode] column
, @LotID [int] = Null  -- for [GestionVolume].[LotID] column
, @DateEntree [smalldatetime] = Null  -- for [GestionVolume].[DateEntree] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[GestionVolume]
		(
			  [DateLivraison]
			, [UsineID]
			, [UniteMesureID]
			, [ProducteurID]
			, [Annee]
			, [Periode]
			, [LotID]
			, [DateEntree]
		)

		Values
		(
			  @DateLivraison
			, @UsineID
			, @UniteMesureID
			, @ProducteurID
			, @Annee
			, @Periode
			, @LotID
			, @DateEntree
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[GestionVolume] On

		Insert Into [dbo].[GestionVolume]
		(
			  [ID]
			, [DateLivraison]
			, [UsineID]
			, [UniteMesureID]
			, [ProducteurID]
			, [Annee]
			, [Periode]
			, [LotID]
			, [DateEntree]
		)

		Values
		(
			  @ID
			, @DateLivraison
			, @UsineID
			, @UniteMesureID
			, @ProducteurID
			, @Annee
			, @Periode
			, @LotID
			, @DateEntree
		)

		Set Identity_Insert [dbo].[GestionVolume] Off

	End

Set NoCount Off

Return(0)


