

Create Procedure [spI_Municipalite_Secteur]

-- Inserts a new record in [Municipalite_Secteur] table
(
  @MunicipaliteID [varchar](6) -- for [Municipalite_Secteur].[MunicipaliteID] column
, @Secteur [varchar](2) -- for [Municipalite_Secteur].[Secteur] column
, @Actif [bit] = Null  -- for [Municipalite_Secteur].[Actif] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Municipalite_Secteur]
(
	  [MunicipaliteID]
	, [Secteur]
	, [Actif]
)

Values
(
	  @MunicipaliteID
	, @Secteur
	, @Actif
)

Set NoCount Off

Return(0)


