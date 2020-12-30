CREATE PROCEDURE [dbo].[spU_UsineUtilisation]
@ID INT, @Description VARCHAR (50)=Null, @ConsiderNull_Description BIT=0, @isPate BIT, @ConsiderNull_isPate BIT=0, @Actif BIT=Null, @ConsiderNull_Actif BIT=0
AS
Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0

If @ConsiderNull_isPate Is Null
	Set @ConsiderNull_isPate = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0


Update [dbo].[UsineUtilisation]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[isPate] = Case @ConsiderNull_isPate When 0 Then IsNull(@isPate, [isPate]) When 1 Then @isPate End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


