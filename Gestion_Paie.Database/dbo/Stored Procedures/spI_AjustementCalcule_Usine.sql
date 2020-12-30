

Create Procedure [spI_AjustementCalcule_Usine]

-- Inserts a new record in [AjustementCalcule_Usine] table
(
  @ID [int] = Null Output -- for [AjustementCalcule_Usine].[ID] column
, @DateCalcul [datetime] = Null  -- for [AjustementCalcule_Usine].[DateCalcul] column
, @AjustementID [int] = Null  -- for [AjustementCalcule_Usine].[AjustementID] column
, @EssenceID [varchar](6) = Null  -- for [AjustementCalcule_Usine].[EssenceID] column
, @UniteID [varchar](6) = Null  -- for [AjustementCalcule_Usine].[UniteID] column
, @LivraisonDetailID [int] = Null  -- for [AjustementCalcule_Usine].[LivraisonDetailID] column
, @UsineID [varchar](6) = Null  -- for [AjustementCalcule_Usine].[UsineID] column
, @Volume [float] = Null  -- for [AjustementCalcule_Usine].[Volume] column
, @Taux [float] = Null  -- for [AjustementCalcule_Usine].[Taux] column
, @Montant [float] = Null  -- for [AjustementCalcule_Usine].[Montant] column
, @Facture [bit] = Null  -- for [AjustementCalcule_Usine].[Facture] column
, @FactureID [int] = Null  -- for [AjustementCalcule_Usine].[FactureID] column
, @ErreurCalcul [bit] = Null  -- for [AjustementCalcule_Usine].[ErreurCalcul] column
, @ErreurDescription [varchar](300) = Null  -- for [AjustementCalcule_Usine].[ErreurDescription] column
, @Code [char](4) = Null  -- for [AjustementCalcule_Usine].[Code] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[AjustementCalcule_Usine]
		(
			  [DateCalcul]
			, [AjustementID]
			, [EssenceID]
			, [UniteID]
			, [LivraisonDetailID]
			, [UsineID]
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
			, @UsineID
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
		Set Identity_Insert [dbo].[AjustementCalcule_Usine] On

		Insert Into [dbo].[AjustementCalcule_Usine]
		(
			  [ID]
			, [DateCalcul]
			, [AjustementID]
			, [EssenceID]
			, [UniteID]
			, [LivraisonDetailID]
			, [UsineID]
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
			, @UsineID
			, @Volume
			, @Taux
			, @Montant
			, @Facture
			, @FactureID
			, @ErreurCalcul
			, @ErreurDescription
			, @Code
		)

		Set Identity_Insert [dbo].[AjustementCalcule_Usine] Off

	End

Set NoCount Off

Return(0)


