

Create Procedure [spU_Pays]

-- Update an existing record in [Pays] table

(
  @ID [varchar](2) -- for [Pays].[ID] column
, @Nom [varchar](50) = Null -- for [Pays].[Nom] column
, @ConsiderNull_Nom bit = 0
, @CodePostal_InputMask [varchar](50) = Null -- for [Pays].[CodePostal_InputMask] column
, @ConsiderNull_CodePostal_InputMask bit = 0
, @Actif [bit] = Null -- for [Pays].[Actif] column
, @ConsiderNull_Actif bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Nom Is Null
	Set @ConsiderNull_Nom = 0

If @ConsiderNull_CodePostal_InputMask Is Null
	Set @ConsiderNull_CodePostal_InputMask = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0


Update [dbo].[Pays]

Set
	 [Nom] = Case @ConsiderNull_Nom When 0 Then IsNull(@Nom, [Nom]) When 1 Then @Nom End
	,[CodePostal_InputMask] = Case @ConsiderNull_CodePostal_InputMask When 0 Then IsNull(@CodePostal_InputMask, [CodePostal_InputMask]) When 1 Then @CodePostal_InputMask End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


