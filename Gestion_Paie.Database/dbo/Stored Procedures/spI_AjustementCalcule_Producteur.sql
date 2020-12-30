

Create Procedure [spI_AjustementCalcule_Producteur]

-- Inserts a new record in [AjustementCalcule_Producteur] table
(
  @ID [int] = Null Output -- for [AjustementCalcule_Producteur].[ID] column
, @DateCalcul [datetime] = Null  -- for [AjustementCalcule_Producteur].[DateCalcul] column
, @AjustementID [int] = Null  -- for [AjustementCalcule_Producteur].[AjustementID] column
, @EssenceID [varchar](6) = Null  -- for [AjustementCalcule_Producteur].[EssenceID] column
, @UniteID [varchar](6) = Null  -- for [AjustementCalcule_Producteur].[UniteID] column
, @LivraisonDetailID [int] = Null  -- for [AjustementCalcule_Producteur].[LivraisonDetailID] column
, @ProducteurID [varchar](15) = Null  -- for [AjustementCalcule_Producteur].[ProducteurID] column
, @Volume [float] = Null  -- for [AjustementCalcule_Producteur].[Volume] column
, @Taux [float] = Null  -- for [AjustementCalcule_Producteur].[Taux] column
, @Montant [float] = Null  -- for [AjustementCalcule_Producteur].[Montant] column
, @Facture [bit] = Null  -- for [AjustementCalcule_Producteur].[Facture] column
, @FactureID [int] = Null  -- for [AjustementCalcule_Producteur].[FactureID] column
, @ErreurCalcul [bit] = Null  -- for [AjustementCalcule_Producteur].[ErreurCalcul] column
, @ErreurDescription [varchar](300) = Null  -- for [AjustementCalcule_Producteur].[ErreurDescription] column
, @Code [char](4) = Null  -- for [AjustementCalcule_Producteur].[Code] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[AjustementCalcule_Producteur]
		(
			  [DateCalcul]
			, [AjustementID]
			, [EssenceID]
			, [UniteID]
			, [LivraisonDetailID]
			, [ProducteurID]
			, [Volume]
			, [Taux]
			, [Montant]
			, [Facture]
			, [FactureID]
			, [ErreurCalcul]
			, [ErreurDescription]
			, [Code]
		)

		Values
		(
			  @DateCalcul
			, @AjustementID
			, @EssenceID
			, @UniteID
			, @LivraisonDetailID
			, @ProducteurID
			, @Volume
			, @Taux
			, @Montant
			, @Facture
			, @FactureID
			, @ErreurCalcul
			, @ErreurDescription
			, @Code
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[AjustementCalcule_Producteur] On

		Insert Into [dbo].[AjustementCalcule_Producteur]
		(
			  [ID]
			, [DateCalcul]
			, [AjustementID]
			, [EssenceID]
			, [UniteID]
			, [LivraisonDetailID]
			, [ProducteurID]
			, [Volume]
			, [Taux]
			, [Montant]
			, [Facture]
			, [FactureID]
			, [ErreurCalcul]
			, [ErreurDescription]
			, [Code]
		)

		Values
		(
			  @ID
			, @DateCalcul
			, @AjustementID
			, @EssenceID
			, @UniteID
			, @LivraisonDetailID
			, @ProducteurID
			, @Volume
			, @Taux
			, @Montant
			, @Facture
			, @FactureID
			, @ErreurCalcul
			, @ErreurDescription
			, @Code
		)

		Set Identity_Insert [dbo].[AjustementCalcule_Producteur] Off

	End

Set NoCount Off

Return(0)


