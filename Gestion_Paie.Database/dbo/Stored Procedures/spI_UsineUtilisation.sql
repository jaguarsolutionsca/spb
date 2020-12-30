CREATE PROCEDURE [dbo].[spI_UsineUtilisation]
@ID INT=Null OUTPUT, @Description VARCHAR (50)=Null, @isPate BIT=Null, @Actif BIT=Null
AS
Set NoCount On

If @isPate Is Null
	Set @isPate = (0)

If @ID Is Null
	Begin

		Insert Into [dbo].[UsineUtilisation]
		(
			  [Description]
			, [isPate]
			, [Actif]
		)

		Values
		(
			  @Description
			, @isPate
			, @Actif
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[UsineUtilisation] On

		Insert Into [dbo].[UsineUtilisation]
		(
			  [ID]
			, [Description]
			, [isPate]
			, [Actif]
		)

		Values
		(
			  @ID
			, @Description
			, @isPate
			, @Actif
		)

		Set Identity_Insert [dbo].[UsineUtilisation] Off

	End

Set NoCount Off

Return(0)


