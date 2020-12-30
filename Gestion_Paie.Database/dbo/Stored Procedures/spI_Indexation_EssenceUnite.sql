

CREATE Procedure [spI_Indexation_EssenceUnite]

-- Inserts a new record in [Indexation_EssenceUnite] table
(
  @ID [int] = Null Output -- for [Indexation_EssenceUnite].[ID] column
, @IndexationID [int] = Null  -- for [Indexation_EssenceUnite].[IndexationID] column
, @ContratID [varchar](10) = Null  -- for [Indexation_EssenceUnite].[ContratID] column
, @EssenceID [varchar](6) = Null  -- for [Indexation_EssenceUnite].[EssenceID] column
, @Code [char](4) = Null  -- for [Indexation_EssenceUnite].[Code] column
, @UniteID [varchar](6) = Null  -- for [Indexation_EssenceUnite].[UniteID] column
, @Taux [real] = Null  -- for [Indexation_EssenceUnite].[Taux] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[Indexation_EssenceUnite]
		(
			  [IndexationID]
			, [ContratID]
			, [EssenceID]
			, [Code]
			, [UniteID]
			, [Taux]
		)

		Values
		(
			  @IndexationID
			, @ContratID
			, @EssenceID
			, @Code
			, @UniteID
			, @Taux
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[Indexation_EssenceUnite] On

		Insert Into [dbo].[Indexation_EssenceUnite]
		(
			  [ID]
			, [IndexationID]
			, [ContratID]
			, [EssenceID]
			, [Code]
			, [UniteID]
			, [Taux]
		)

		Values
		(
			  @ID
			, @IndexationID
			, @ContratID
			, @EssenceID
			, @Code
			, @UniteID
			, @Taux
		)

		Set Identity_Insert [dbo].[Indexation_EssenceUnite] Off

	End

Set NoCount Off

Return(0)


