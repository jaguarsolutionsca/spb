
CREATE Procedure [spU_Contingentement_VolumeFixe]

-- Update an existing record in [Contingentement_VolumeFixe] table

(
  @ContingentementID [int] -- for [Contingentement_VolumeFixe].[ContingentementID] column
, @Superficie_Min [real] -- for [Contingentement_VolumeFixe].[Superficie_Min] column
, @Volume_Fixe [real] = Null -- for [Contingentement_VolumeFixe].[Volume_Fixe] column
, @ConsiderNull_Volume_Fixe bit = 0
, @NombreMois [int] = Null -- for [Contingentement_VolumeFixe].[NombreMois] column
, @ConsiderNull_NombreMois bit = 0
, @UseNombreMois [bit] -- for [Contingentement_VolumeFixe].[UseNombreMois] column
, @ConsiderNull_UseNombreMois bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Volume_Fixe Is Null
	Set @ConsiderNull_Volume_Fixe = 0

If @ConsiderNull_NombreMois Is Null
	Set @ConsiderNull_NombreMois = 0

If @ConsiderNull_UseNombreMois Is Null
	Set @ConsiderNull_UseNombreMois = 0


Update [dbo].[Contingentement_VolumeFixe]

Set
	 [Volume_Fixe] = Case @ConsiderNull_Volume_Fixe When 0 Then IsNull(@Volume_Fixe, [Volume_Fixe]) When 1 Then @Volume_Fixe End
	,[NombreMois] = Case @ConsiderNull_NombreMois When 0 Then IsNull(@NombreMois, [NombreMois]) When 1 Then @NombreMois End
	,[UseNombreMois] = Case @ConsiderNull_UseNombreMois When 0 Then IsNull(@UseNombreMois, [UseNombreMois]) When 1 Then @UseNombreMois End

Where
	     ([ContingentementID] = @ContingentementID)
	And ([Superficie_Min] = @Superficie_Min)

Set NoCount Off

Return(0)

