

CREATE Procedure [spI_Indexation_Municipalite]

-- Inserts a new record in [Indexation_Municipalite] table
(
  @ID [int] = Null Output -- for [Indexation_Municipalite].[ID] column
, @IndexationID [int] = Null  -- for [Indexation_Municipalite].[IndexationID] column
, @MunicipaliteID [varchar](6) = Null  -- for [Indexation_Municipalite].[MunicipaliteID] column
, @Montant [real] = Null  -- for [Indexation_Municipalite].[Montant] column
, @ZoneID [varchar](2) = Null  -- for [Indexation_Municipalite].[ZoneID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[Indexation_Municipalite]
		(
			  [IndexationID]
			, [MunicipaliteID]
			, [Montant]
			, [ZoneID]
		)

		Values
		(
			  @IndexationID
			, @MunicipaliteID
			, @Montant
			, @ZoneID
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[Indexation_Municipalite] On

		Insert Into [dbo].[Indexation_Municipalite]
		(
			  [ID]
			, [IndexationID]
			, [MunicipaliteID]
			, [Montant]
			, [ZoneID]
		)

		Values
		(
			  @ID
			, @IndexationID
			, @MunicipaliteID
			, @Montant
			, @ZoneID
		)

		Set Identity_Insert [dbo].[Indexation_Municipalite] Off

	End

Set NoCount Off

Return(0)


