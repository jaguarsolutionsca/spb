

Create Procedure [spI_EssenceContingent]

-- Inserts a new record in [EssenceContingent] table
(
  @ID [int] = Null Output -- for [EssenceContingent].[ID] column
, @Description [varchar](25) = Null  -- for [EssenceContingent].[Description] column
, @Actif [bit] = Null  -- for [EssenceContingent].[Actif] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[EssenceContingent]
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
		Set Identity_Insert [dbo].[EssenceContingent] On

		Insert Into [dbo].[EssenceContingent]
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

		Set Identity_Insert [dbo].[EssenceContingent] Off

	End

Set NoCount Off

Return(0)


