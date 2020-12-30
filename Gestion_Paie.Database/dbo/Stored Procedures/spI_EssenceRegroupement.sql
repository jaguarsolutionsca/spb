CREATE PROCEDURE [dbo].[spI_EssenceRegroupement]
@ID INT=Null OUTPUT, @Description VARCHAR (25)=Null, @Actif BIT=Null, @Ordre INT=Null
AS
Set NoCount On

If @Ordre Is Null
	Set @Ordre = (0)

If @ID Is Null
	Begin

		Insert Into [dbo].[EssenceRegroupement]
		(
			  [Description]
			, [Actif]
			, [Ordre]
		)

		Values
		(
			  @Description
			, @Actif
			, @Ordre
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[EssenceRegroupement] On

		Insert Into [dbo].[EssenceRegroupement]
		(
			  [ID]
			, [Description]
			, [Actif]
			, [Ordre]
		)

		Values
		(
			  @ID
			, @Description
			, @Actif
			, @Ordre
		)

		Set Identity_Insert [dbo].[EssenceRegroupement] Off

	End

Set NoCount Off

Return(0)


