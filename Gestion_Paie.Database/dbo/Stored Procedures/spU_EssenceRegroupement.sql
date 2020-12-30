CREATE PROCEDURE [dbo].[spU_EssenceRegroupement]
@ID INT, @Description VARCHAR (25)=Null, @ConsiderNull_Description BIT=0, @Actif BIT=Null, @ConsiderNull_Actif BIT=0, @Ordre INT, @ConsiderNull_Ordre BIT=0
AS
Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0

If @ConsiderNull_Ordre Is Null
	Set @ConsiderNull_Ordre = 0


Update [dbo].[EssenceRegroupement]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End
	,[Ordre] = Case @ConsiderNull_Ordre When 0 Then IsNull(@Ordre, [Ordre]) When 1 Then @Ordre End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


