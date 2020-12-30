
CREATE Procedure [spI_Contingentement_VolumeFixe]

-- Inserts a new record in [Contingentement_VolumeFixe] table
(
  @ContingentementID [int] -- for [Contingentement_VolumeFixe].[ContingentementID] column
, @Superficie_Min [real] -- for [Contingentement_VolumeFixe].[Superficie_Min] column
, @Volume_Fixe [real] = Null  -- for [Contingentement_VolumeFixe].[Volume_Fixe] column
, @NombreMois [int] = Null  -- for [Contingentement_VolumeFixe].[NombreMois] column
, @UseNombreMois [bit] = Null  -- for [Contingentement_VolumeFixe].[UseNombreMois] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @UseNombreMois Is Null
	Set @UseNombreMois = (1)

Insert Into [dbo].[Contingentement_VolumeFixe]
(
	  [ContingentementID]
	, [Superficie_Min]
	, [Volume_Fixe]
	, [NombreMois]
	, [UseNombreMois]
)

Values
(
	  @ContingentementID
	, @Superficie_Min
	, @Volume_Fixe
	, @NombreMois
	, @UseNombreMois
)

Set NoCount Off

Return(0)

