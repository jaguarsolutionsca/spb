

Create Procedure [spI_IndexationCalcule_Producteur]

-- Inserts a new record in [IndexationCalcule_Producteur] table
(
  @ID [int] = Null Output -- for [IndexationCalcule_Producteur].[ID] column
, @DateCalcul [datetime] = Null  -- for [IndexationCalcule_Producteur].[DateCalcul] column
, @TypeIndexation [char](1) = Null  -- for [IndexationCalcule_Producteur].[TypeIndexation] column
, @IndexationID [int] = Null  -- for [IndexationCalcule_Producteur].[IndexationID] column
, @IndexationDetailID [int] = Null  -- for [IndexationCalcule_Producteur].[IndexationDetailID] column
, @LivraisonID [int] = Null  -- for [IndexationCalcule_Producteur].[LivraisonID] column
, @LivraisonDetailID [int] = Null  -- for [IndexationCalcule_Producteur].[LivraisonDetailID] column
, @ProducteurID [varchar](15) = Null  -- for [IndexationCalcule_Producteur].[ProducteurID] column
, @ContratID [varchar](10) = Null  -- for [IndexationCalcule_Producteur].[ContratID] column
, @EssenceID [varchar](6) = Null  -- for [IndexationCalcule_Producteur].[EssenceID] column
, @Code [char](4) = Null  -- for [IndexationCalcule_Producteur].[Code] column
, @UniteID [varchar](6) = Null  -- for [IndexationCalcule_Producteur].[UniteID] column
, @Volume [float] = Null  -- for [IndexationCalcule_Producteur].[Volume] column
, @MontantDejaPaye [float] = Null  -- for [IndexationCalcule_Producteur].[MontantDejaPaye] column
, @PourcentageDuMontant [float] = Null  -- for [IndexationCalcule_Producteur].[PourcentageDuMontant] column
, @Taux [float] = Null  -- for [IndexationCalcule_Producteur].[Taux] column
, @Montant [float] = Null  -- for [IndexationCalcule_Producteur].[Montant] column
, @Facture [bit] = Null  -- for [IndexationCalcule_Producteur].[Facture] column
, @FactureID [int] = Null  -- for [IndexationCalcule_Producteur].[FactureID] column
, @ErreurCalcul [bit] = Null  -- for [IndexationCalcule_Producteur].[ErreurCalcul] column
, @ErreurDescription [varchar](300) = Null  -- for [IndexationCalcule_Producteur].[ErreurDescription] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[IndexationCalcule_Producteur]
		(
			  [DateCalcul]
			, [TypeIndexation]
			, [IndexationID]
			, [IndexationDetailID]
			, [LivraisonID]
			, [LivraisonDetailID]
			, [ProducteurID]
			, [ContratID]
			, [EssenceID]
			, [Code]
			, [UniteID]
			, [Volume]
			, [MontantDejaPaye]
			, [PourcentageDuMontant]
			, [Taux]
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
			, @LivraisonDetailID
			, @ProducteurID
			, @ContratID
			, @EssenceID
			, @Code
			, @UniteID
			, @Volume
			, @MontantDejaPaye
			, @PourcentageDuMontant
			, @Taux
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
		Set Identity_Insert [dbo].[IndexationCalcule_Producteur] On

		Insert Into [dbo].[IndexationCalcule_Producteur]
		(
			  [ID]
			, [DateCalcul]
			, [TypeIndexation]
			, [IndexationID]
			, [IndexationDetailID]
			, [LivraisonID]
			, [LivraisonDetailID]
			, [ProducteurID]
			, [ContratID]
			, [EssenceID]
			, [Code]
			, [UniteID]
			, [Volume]
			, [MontantDejaPaye]
			, [PourcentageDuMontant]
			, [Taux]
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
			, @LivraisonDetailID
			, @ProducteurID
			, @ContratID
			, @EssenceID
			, @Code
			, @UniteID
			, @Volume
			, @MontantDejaPaye
			, @PourcentageDuMontant
			, @Taux
			, @Montant
			, @Facture
			, @FactureID
			, @ErreurCalcul
			, @ErreurDescription
		)

		Set Identity_Insert [dbo].[IndexationCalcule_Producteur] Off

	End

Set NoCount Off

Return(0)


