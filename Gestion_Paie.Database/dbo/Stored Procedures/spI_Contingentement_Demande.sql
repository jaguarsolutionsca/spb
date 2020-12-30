
CREATE Procedure [spI_Contingentement_Demande]

-- Inserts a new record in [Contingentement_Demande] table
(
  @ID [int] = Null Output -- for [Contingentement_Demande].[ID] column
, @Annee [int] = Null  -- for [Contingentement_Demande].[Annee] column
, @ProducteurID [varchar](15) = Null  -- for [Contingentement_Demande].[ProducteurID] column
, @TransporteurID [varchar](15) = Null  -- for [Contingentement_Demande].[TransporteurID] column
, @Superficie_Boisee [real] = Null  -- for [Contingentement_Demande].[Superficie_Boisee] column
, @Remarques [varchar](2000) = Null  -- for [Contingentement_Demande].[Remarques] column
, @DateModification [smalldatetime] = Null  -- for [Contingentement_Demande].[DateModification] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[Contingentement_Demande]
		(
			  [Annee]
			, [ProducteurID]
			, [TransporteurID]
			, [Superficie_Boisee]
			, [Remarques]
			, [DateModification]
		)

		Values
		(
			  @Annee
			, @ProducteurID
			, @TransporteurID
			, @Superficie_Boisee
			, @Remarques
			, @DateModification
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[Contingentement_Demande] On

		Insert Into [dbo].[Contingentement_Demande]
		(
			  [ID]
			, [Annee]
			, [ProducteurID]
			, [TransporteurID]
			, [Superficie_Boisee]
			, [Remarques]
			, [DateModification]
		)

		Values
		(
			  @ID
			, @Annee
			, @ProducteurID
			, @TransporteurID
			, @Superficie_Boisee
			, @Remarques
			, @DateModification
		)

		Set Identity_Insert [dbo].[Contingentement_Demande] Off

	End

Set NoCount Off

Return(0)

