

Create Procedure [spI_Municipalite_Zone]

-- Inserts a new record in [Municipalite_Zone] table
(
  @ID [varchar](2) -- for [Municipalite_Zone].[ID] column
, @MunicipaliteID [varchar](6) -- for [Municipalite_Zone].[MunicipaliteID] column
, @Description [varchar](50) = Null  -- for [Municipalite_Zone].[Description] column
, @Actif [bit] = Null  -- for [Municipalite_Zone].[Actif] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Municipalite_Zone]
(
	  [ID]
	, [MunicipaliteID]
	, [Description]
	, [Actif]
)

Values
(
	  @ID
	, @MunicipaliteID
	, @Description
	, @Actif
)

Set NoCount Off

Return(0)


