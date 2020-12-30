

Create Procedure [spU_GestionVolume_Detail]

-- Update an existing record in [GestionVolume_Detail] table

(
  @ID [int] -- for [GestionVolume_Detail].[ID] column
, @GestionVolumeID [int] = Null -- for [GestionVolume_Detail].[GestionVolumeID] column
, @ConsiderNull_GestionVolumeID bit = 0
, @EssenceID [varchar](6) = Null -- for [GestionVolume_Detail].[EssenceID] column
, @ConsiderNull_EssenceID bit = 0
, @UniteMesureID [varchar](6) = Null -- for [GestionVolume_Detail].[UniteMesureID] column
, @ConsiderNull_UniteMesureID bit = 0
, @VolumeBrut [float] = Null -- for [GestionVolume_Detail].[VolumeBrut] column
, @ConsiderNull_VolumeBrut bit = 0
, @VolumeReduction [float] = Null -- for [GestionVolume_Detail].[VolumeReduction] column
, @ConsiderNull_VolumeReduction bit = 0
, @VolumeNet [float] = Null -- for [GestionVolume_Detail].[VolumeNet] column
, @ConsiderNull_VolumeNet bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_GestionVolumeID Is Null
	Set @ConsiderNull_GestionVolumeID = 0

If @ConsiderNull_EssenceID Is Null
	Set @ConsiderNull_EssenceID = 0

If @ConsiderNull_UniteMesureID Is Null
	Set @ConsiderNull_UniteMesureID = 0

If @ConsiderNull_VolumeBrut Is Null
	Set @ConsiderNull_VolumeBrut = 0

If @ConsiderNull_VolumeReduction Is Null
	Set @ConsiderNull_VolumeReduction = 0

If @ConsiderNull_VolumeNet Is Null
	Set @ConsiderNull_VolumeNet = 0


Update [dbo].[GestionVolume_Detail]

Set
	 [GestionVolumeID] = Case @ConsiderNull_GestionVolumeID When 0 Then IsNull(@GestionVolumeID, [GestionVolumeID]) When 1 Then @GestionVolumeID End
	,[EssenceID] = Case @ConsiderNull_EssenceID When 0 Then IsNull(@EssenceID, [EssenceID]) When 1 Then @EssenceID End
	,[UniteMesureID] = Case @ConsiderNull_UniteMesureID When 0 Then IsNull(@UniteMesureID, [UniteMesureID]) When 1 Then @UniteMesureID End
	,[VolumeBrut] = Case @ConsiderNull_VolumeBrut When 0 Then IsNull(@VolumeBrut, [VolumeBrut]) When 1 Then @VolumeBrut End
	,[VolumeReduction] = Case @ConsiderNull_VolumeReduction When 0 Then IsNull(@VolumeReduction, [VolumeReduction]) When 1 Then @VolumeReduction End
	,[VolumeNet] = Case @ConsiderNull_VolumeNet When 0 Then IsNull(@VolumeNet, [VolumeNet]) When 1 Then @VolumeNet End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


