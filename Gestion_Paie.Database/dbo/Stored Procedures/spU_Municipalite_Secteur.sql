

Create Procedure [spU_Municipalite_Secteur]

-- Update an existing record in [Municipalite_Secteur] table

(
  @MunicipaliteID [varchar](6) -- for [Municipalite_Secteur].[MunicipaliteID] column
, @Secteur [varchar](2) -- for [Municipalite_Secteur].[Secteur] column
, @Actif [bit] = Null -- for [Municipalite_Secteur].[Actif] column
, @ConsiderNull_Actif bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0


Update [dbo].[Municipalite_Secteur]

Set
	 [Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End

Where
	     ([MunicipaliteID] = @MunicipaliteID)
	And ([Secteur] = @Secteur)

Set NoCount Off

Return(0)


