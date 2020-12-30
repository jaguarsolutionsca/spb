

Create Procedure [spI_Indexation]

-- Inserts a new record in [Indexation] table
(
  @ID [int] = Null Output -- for [Indexation].[ID] column
, @DateIndexation [datetime] = Null  -- for [Indexation].[DateIndexation] column
, @ContratID [varchar](10) = Null  -- for [Indexation].[ContratID] column
, @Periode_Debut [int] = Null  -- for [Indexation].[Periode_Debut] column
, @Periode_Fin [int] = Null  -- for [Indexation].[Periode_Fin] column
, @TypeIndexation [char](1) = Null  -- for [Indexation].[TypeIndexation] column
, @PourcentageDuMontant [real] = Null  -- for [Indexation].[PourcentageDuMontant] column
, @Facture [bit] = Null  -- for [Indexation].[Facture] column
, @IndexationTransporteur [bit] = Null  -- for [Indexation].[IndexationTransporteur] column
, @Date_Debut [smalldatetime] = Null  -- for [Indexation].[Date_Debut] column
, @Date_Fin [smalldatetime] = Null  -- for [Indexation].[Date_Fin] column
, @IndexationManuelle [bit] = Null  -- for [Indexation].[IndexationManuelle] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[Indexation]
		(
			  [DateIndexation]
			, [ContratID]
			, [Periode_Debut]
			, [Periode_Fin]
			, [TypeIndexation]
			, [PourcentageDuMontant]
			, [Facture]
			, [IndexationTransporteur]
			, [Date_Debut]
			, [Date_Fin]
			, [IndexationManuelle]
		)

		Values
		(
			  @DateIndexation
			, @ContratID
			, @Periode_Debut
			, @Periode_Fin
			, @TypeIndexation
			, @PourcentageDuMontant
			, @Facture
			, @IndexationTransporteur
			, @Date_Debut
			, @Date_Fin
			, @IndexationManuelle
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[Indexation] On

		Insert Into [dbo].[Indexation]
		(
			  [ID]
			, [DateIndexation]
			, [ContratID]
			, [Periode_Debut]
			, [Periode_Fin]
			, [TypeIndexation]
			, [PourcentageDuMontant]
			, [Facture]
			, [IndexationTransporteur]
			, [Date_Debut]
			, [Date_Fin]
			, [IndexationManuelle]
		)

		Values
		(
			  @ID
			, @DateIndexation
			, @ContratID
			, @Periode_Debut
			, @Periode_Fin
			, @TypeIndexation
			, @PourcentageDuMontant
			, @Facture
			, @IndexationTransporteur
			, @Date_Debut
			, @Date_Fin
			, @IndexationManuelle
		)

		Set Identity_Insert [dbo].[Indexation] Off

	End

Set NoCount Off

Return(0)


