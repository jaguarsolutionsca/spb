

Create Procedure [spI_EssenceRepartition]

-- Inserts a new record in [EssenceRepartition] table
(
  @ID [int] = Null Output -- for [EssenceRepartition].[ID] column
, @Description [varchar](25) = Null  -- for [EssenceRepartition].[Description] column
, @Actif [bit] = Null  -- for [EssenceRepartition].[Actif] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[EssenceRepartition]
		(
			  [Description]
			, [Actif]
		)

		Values
		(
			  @Description
			, @Actif
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[EssenceRepartition] On

		Insert Into [dbo].[EssenceRepartition]
		(
			  [ID]
			, [Description]
			, [Actif]
		)

		Values
		(
			  @ID
			, @Description
			, @Actif
		)

		Set Identity_Insert [dbo].[EssenceRepartition] Off

	End

Set NoCount Off

Return(0)


