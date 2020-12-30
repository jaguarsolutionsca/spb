

Create Procedure [spU_jag_Profile]

-- Update an existing record in [jag_Profile] table

(
  @ID [int] -- for [jag_Profile].[ID] column
, @Nom [varchar](100) = Null -- for [jag_Profile].[Nom] column
, @ConsiderNull_Nom bit = 0
, @Password [varchar](20) = Null -- for [jag_Profile].[Password] column
, @ConsiderNull_Password bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Nom Is Null
	Set @ConsiderNull_Nom = 0

If @ConsiderNull_Password Is Null
	Set @ConsiderNull_Password = 0


Update [dbo].[jag_Profile]

Set
	 [Nom] = Case @ConsiderNull_Nom When 0 Then IsNull(@Nom, [Nom]) When 1 Then @Nom End
	,[Password] = Case @ConsiderNull_Password When 0 Then IsNull(@Password, [Password]) When 1 Then @Password End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


