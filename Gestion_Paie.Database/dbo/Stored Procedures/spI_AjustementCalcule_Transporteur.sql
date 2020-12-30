

Create Procedure [spI_AjustementCalcule_Transporteur]

-- Inserts a new record in [AjustementCalcule_Transporteur] table
(
  @ID [int] = Null Output -- for [AjustementCalcule_Transporteur].[ID] column
, @DateCalcul [datetime] = Null  -- for [AjustementCalcule_Transporteur].[DateCalcul] column
, @AjustementID [int] = Null  -- for [AjustementCalcule_Transporteur].[AjustementID] column
, @UniteID [varchar](6) = Null  -- for [AjustementCalcule_Transporteur].[UniteID] column
, @MunicipaliteID [varchar](6) = Null  -- for [AjustementCalcule_Transporteur].[MunicipaliteID] column
, @LivraisonID [int] = Null  -- for [AjustementCalcule_Transporteur].[LivraisonID] column
, @TransporteurID [varchar](15) = Null  -- for [AjustementCalcule_Transporteur].[TransporteurID] column
, @Volume [float] = Null  -- for [AjustementCalcule_Transporteur].[Volume] column
, @Taux [float] = Null  -- for [AjustementCalcule_Transporteur].[Taux] column
, @Montant [float] = Null  -- for [AjustementCalcule_Transporteur].[Montant] column
, @Facture [bit] = Null  -- for [AjustementCalcule_Transporteur].[Facture] column
, @FactureID [int] = Null  -- for [AjustementCalcule_Transporteur].[FactureID] column
, @ErreurCalcul [bit] = Null  -- for [AjustementCalcule_Transporteur].[ErreurCalcul] column
, @ErreurDescription [varchar](300) = Null  -- for [AjustementCalcule_Transporteur].[ErreurDescription] column
, @ZoneID [varchar](2) = Null  -- for [AjustementCalcule_Transporteur].[ZoneID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[AjustementCalcule_Transporteur]
		(
			  [DateCalcul]
			, [AjustementID]
			, [UniteID]
			, [MunicipaliteID]
			, [LivraisonID]
			, [TransporteurID]
			, [Volume]
			, [Taux]
			, [Montant]
			, [Facture]
			, [FactureID]
			, [ErreurCalcul]
			, [ErreurDescription]
			, [ZoneID]
		)

		Values
		(
			  @DateCalcul
			, @AjustementID
			, @UniteID
			, @MunicipaliteID
			, @LivraisonID
			, @TransporteurID
			, @Volume
			, @Taux
			, @Montant
			, @Facture
			, @FactureID
			, @ErreurCalcul
			, @ErreurDescription
			, @ZoneID
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[AjustementCalcule_Transporteur] On

		Insert Into [dbo].[AjustementCalcule_Transporteur]
		(
			  [ID]
			, [DateCalcul]
			, [AjustementID]
			, [UniteID]
			, [MunicipaliteID]
			, [LivraisonID]
			, [TransporteurID]
			, [Volume]
			, [Taux]
			, [Montant]
			, [Facture]
			, [FactureID]
			, [ErreurCalcul]
			, [ErreurDescription]
			, [ZoneID]
		)

		Values
		(
			  @ID
			, @DateCalcul
			, @AjustementID
			, @UniteID
			, @MunicipaliteID
			, @LivraisonID
			, @TransporteurID
			, @Volume
			, @Taux
			, @Montant
			, @Facture
			, @FactureID
			, @ErreurCalcul
			, @ErreurDescription
			, @ZoneID
		)

		Set Identity_Insert [dbo].[AjustementCalcule_Transporteur] Off

	End

Set NoCount Off

Return(0)


