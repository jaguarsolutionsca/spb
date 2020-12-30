

Create Procedure [spI_IndexationCalcule_Transporteur]

-- Inserts a new record in [IndexationCalcule_Transporteur] table
(
  @ID [int] = Null Output -- for [IndexationCalcule_Transporteur].[ID] column
, @DateCalcul [datetime] = Null  -- for [IndexationCalcule_Transporteur].[DateCalcul] column
, @TypeIndexation [char](1) = Null  -- for [IndexationCalcule_Transporteur].[TypeIndexation] column
, @IndexationID [int] = Null  -- for [IndexationCalcule_Transporteur].[IndexationID] column
, @IndexationDetailID [int] = Null  -- for [IndexationCalcule_Transporteur].[IndexationDetailID] column
, @LivraisonID [int] = Null  -- for [IndexationCalcule_Transporteur].[LivraisonID] column
, @TransporteurID [varchar](15) = Null  -- for [IndexationCalcule_Transporteur].[TransporteurID] column
, @MontantDejaPaye [float] = Null  -- for [IndexationCalcule_Transporteur].[MontantDejaPaye] column
, @PourcentageDuMontant [float] = Null  -- for [IndexationCalcule_Transporteur].[PourcentageDuMontant] column
, @Montant [float] = Null  -- for [IndexationCalcule_Transporteur].[Montant] column
, @Facture [bit] = Null  -- for [IndexationCalcule_Transporteur].[Facture] column
, @FactureID [int] = Null  -- for [IndexationCalcule_Transporteur].[FactureID] column
, @ErreurCalcul [bit] = Null  -- for [IndexationCalcule_Transporteur].[ErreurCalcul] column
, @ErreurDescription [varchar](300) = Null  -- for [IndexationCalcule_Transporteur].[ErreurDescription] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[IndexationCalcule_Transporteur]
		(
			  [DateCalcul]
			, [TypeIndexation]
			, [IndexationID]
			, [IndexationDetailID]
			, [LivraisonID]
			, [TransporteurID]
			, [MontantDejaPaye]
			, [PourcentageDuMontant]
			, [Montant]
			, [Facture]
			, [FactureID]
			, [ErreurCalcul]
			, [ErreurDescription]
		)

		Values
		(
			  @DateCalcul
			, @TypeIndexation
			, @IndexationID
			, @IndexationDetailID
			, @LivraisonID
			, @TransporteurID
			, @MontantDejaPaye
			, @PourcentageDuMontant
			, @Montant
			, @Facture
			, @FactureID
			, @ErreurCalcul
			, @ErreurDescription
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[IndexationCalcule_Transporteur] On

		Insert Into [dbo].[IndexationCalcule_Transporteur]
		(
			  [ID]
			, [DateCalcul]
			, [TypeIndexation]
			, [IndexationID]
			, [IndexationDetailID]
			, [LivraisonID]
			, [TransporteurID]
			, [MontantDejaPaye]
			, [PourcentageDuMontant]
			, [Montant]
			, [Facture]
			, [FactureID]
			, [ErreurCalcul]
			, [ErreurDescription]
		)

		Values
		(
			  @ID
			, @DateCalcul
			, @TypeIndexation
			, @IndexationID
			, @IndexationDetailID
			, @LivraisonID
			, @TransporteurID
			, @MontantDejaPaye
			, @PourcentageDuMontant
			, @Montant
			, @Facture
			, @FactureID
			, @ErreurCalcul
			, @ErreurDescription
		)

		Set Identity_Insert [dbo].[IndexationCalcule_Transporteur] Off

	End

Set NoCount Off

Return(0)


