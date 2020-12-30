

Create Procedure [spI_GestionVolume_Detail]

-- Inserts a new record in [GestionVolume_Detail] table
(
  @ID [int] = Null Output -- for [GestionVolume_Detail].[ID] column
, @GestionVolumeID [int] = Null  -- for [GestionVolume_Detail].[GestionVolumeID] column
, @EssenceID [varchar](6) = Null  -- for [GestionVolume_Detail].[EssenceID] column
, @UniteMesureID [varchar](6) = Null  -- for [GestionVolume_Detail].[UniteMesureID] column
, @VolumeBrut [float] = Null  -- for [GestionVolume_Detail].[VolumeBrut] column
, @VolumeReduction [float] = Null  -- for [GestionVolume_Detail].[VolumeReduction] column
, @VolumeNet [float] = Null  -- for [GestionVolume_Detail].[VolumeNet] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[GestionVolume_Detail]
		(
			  [GestionVolumeID]
			, [EssenceID]
			, [UniteMesureID]
			, [VolumeBrut]
			, [VolumeReduction]
			, [VolumeNet]
		)

		Values
		(
			  @GestionVolumeID
			, @EssenceID
			, @UniteMesureID
			, @VolumeBrut
			, @VolumeReduction
			, @VolumeNet
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[GestionVolume_Detail] On

		Insert Into [dbo].[GestionVolume_Detail]
		(
			  [ID]
			, [GestionVolumeID]
			, [EssenceID]
			, [UniteMesureID]
			, [VolumeBrut]
			, [VolumeReduction]
			, [VolumeNet]
		)

		Values
		(
			  @ID
			, @GestionVolumeID
			, @EssenceID
			, @UniteMesureID
			, @VolumeBrut
			, @VolumeReduction
			, @VolumeNet
		)

		Set Identity_Insert [dbo].[GestionVolume_Detail] Off

	End

Set NoCount Off

Return(0)


