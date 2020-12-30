CREATE Procedure [dbo].[spI_AjustementCalcule_TransporteurEssence]

-- Inserts a new record in [AjustementCalcule_TransporteurEssence] table
(
  @ID [int] = Null Output -- for [AjustementCalcule_TransporteurEssence].[ID] column
, @DateCalcul [datetime] = Null  -- for [AjustementCalcule_TransporteurEssence].[DateCalcul] column
, @AjustementID [int] = Null  -- for [AjustementCalcule_TransporteurEssence].[AjustementID] column
, @EssenceID [varchar](6) = Null  -- for [AjustementCalcule_TransporteurEssence].[EssenceID] column
, @UniteID [varchar](6) = Null  -- for [AjustementCalcule_TransporteurEssence].[UniteID] column
, @LivraisonDetailID [int] = Null  -- for [AjustementCalcule_TransporteurEssence].[LivraisonDetailID] column
, @TransporteurID [varchar](15) = Null  -- for [AjustementCalcule_TransporteurEssence].[TransporteurID] column
, @Volume [float] = Null  -- for [AjustementCalcule_TransporteurEssence].[Volume] column
, @Taux [float] = Null  -- for [AjustementCalcule_TransporteurEssence].[Taux] column
, @Montant [float] = Null  -- for [AjustementCalcule_TransporteurEssence].[Montant] column
, @Facture [bit] = Null  -- for [AjustementCalcule_TransporteurEssence].[Facture] column
, @FactureID [int] = Null  -- for [AjustementCalcule_TransporteurEssence].[FactureID] column
, @ErreurCalcul [bit] = Null  -- for [AjustementCalcule_TransporteurEssence].[ErreurCalcul] column
, @ErreurDescription [varchar](300) = Null  -- for [AjustementCalcule_TransporteurEssence].[ErreurDescription] column
, @Code [char](4) = Null  -- for [AjustementCalcule_TransporteurEssence].[Code] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[AjustementCalcule_TransporteurEssence]
		(
			  [DateCalcul]
			, [AjustementID]
			, [EssenceID]
			, [UniteID]
			, [LivraisonDetailID]
			, [TransporteurID]
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
			, @TransporteurID
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
		Set Identity_Insert [dbo].[AjustementCalcule_TransporteurEssence] On

		Insert Into [dbo].[AjustementCalcule_TransporteurEssence]
		(
			  [ID]
			, [DateCalcul]
			, [AjustementID]
			, [EssenceID]
			, [UniteID]
			, [LivraisonDetailID]
			, [TransporteurID]
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
			, @TransporteurID
			, @Volume
			, @Taux
			, @Montant
			, @Facture
			, @FactureID
			, @ErreurCalcul
			, @ErreurDescription
			, @Code
		)

		Set Identity_Insert [dbo].[AjustementCalcule_TransporteurEssence] Off

	End

Set NoCount Off

Return(0)
