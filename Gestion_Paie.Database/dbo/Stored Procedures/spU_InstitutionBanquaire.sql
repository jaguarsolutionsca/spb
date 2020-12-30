

CREATE Procedure [spU_InstitutionBanquaire]

-- Update an existing record in [InstitutionBanquaire] table

(
  @ID [varchar](3) -- for [InstitutionBanquaire].[ID] column
, @Description [varchar](50) = Null -- for [InstitutionBanquaire].[Description] column
, @ConsiderNull_Description bit = 0
, @Actif [bit] = Null -- for [InstitutionBanquaire].[Actif] column
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


Update [dbo].[InstitutionBanquaire]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


