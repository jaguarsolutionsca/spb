

Create Procedure [spU_Municipalite_Zone]

-- Update an existing record in [Municipalite_Zone] table

(
  @ID [varchar](2) -- for [Municipalite_Zone].[ID] column
, @MunicipaliteID [varchar](6) -- for [Municipalite_Zone].[MunicipaliteID] column
, @Description [varchar](50) = Null -- for [Municipalite_Zone].[Description] column
, @ConsiderNull_Description bit = 0
, @Actif [bit] = Null -- for [Municipalite_Zone].[Actif] column
, @ConsiderNull_Actif bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0


Update [dbo].[Municipalite_Zone]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End

Where
	     ([ID] = @ID)
	And ([MunicipaliteID] = @MunicipaliteID)

Set NoCount Off

Return(0)


