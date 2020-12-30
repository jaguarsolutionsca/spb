

Create Procedure [spI_EssenceSciage]

-- Inserts a new record in [EssenceSciage] table
(
  @ID [int] = Null Output -- for [EssenceSciage].[ID] column
, @Description [varchar](25) = Null  -- for [EssenceSciage].[Description] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[EssenceSciage]
		(
			  [Description]
		)

		Values
		(
			  @Description
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[EssenceSciage] On

		Insert Into [dbo].[EssenceSciage]
		(
			  [ID]
			, [Description]
		)

		Values
		(
			  @ID
			, @Description
		)

		Set Identity_Insert [dbo].[EssenceSciage] Off

	End

Set NoCount Off

Return(0)


