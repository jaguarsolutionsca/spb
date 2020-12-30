

Create Procedure [spI_FactureFournisseur]

-- Inserts a new record in [FactureFournisseur] table
(
  @ID [int] = Null Output -- for [FactureFournisseur].[ID] column
, @NoFacture [varchar](12) = Null  -- for [FactureFournisseur].[NoFacture] column
, @DateFacture [smalldatetime] = Null  -- for [FactureFournisseur].[DateFacture] column
, @Annee [int] = Null  -- for [FactureFournisseur].[Annee] column
, @TypeFactureFournisseur [char](1) = Null  -- for [FactureFournisseur].[TypeFactureFournisseur] column
, @TypeFacture [char](1) = Null  -- for [FactureFournisseur].[TypeFacture] column
, @TypeInvoiceAcomba [int] = Null  -- for [FactureFournisseur].[TypeInvoiceAcomba] column
, @FournisseurID [varchar](15) = Null  -- for [FactureFournisseur].[FournisseurID] column
, @PayerAID [varchar](15) = Null  -- for [FactureFournisseur].[PayerAID] column
, @Montant_Total [float] = Null  -- for [FactureFournisseur].[Montant_Total] column
, @Montant_TPS [float] = Null  -- for [FactureFournisseur].[Montant_TPS] column
, @Montant_TVQ [float] = Null  -- for [FactureFournisseur].[Montant_TVQ] column
, @Description [varchar](255) = Null  -- for [FactureFournisseur].[Description] column
, @Status [varchar](15) = Null  -- for [FactureFournisseur].[Status] column
, @StatusDescription [varchar](300) = Null  -- for [FactureFournisseur].[StatusDescription] column
, @NumeroCheque [varchar](20) = Null  -- for [FactureFournisseur].[NumeroCheque] column
, @NumeroPaiement [varchar](20) = Null  -- for [FactureFournisseur].[NumeroPaiement] column
, @NumeroPaiementUnique [varchar](20) = Null  -- for [FactureFournisseur].[NumeroPaiementUnique] column
, @DateFactureAcomba [smalldatetime] = Null  -- for [FactureFournisseur].[DateFactureAcomba] column
, @DatePaiementAcomba [smalldatetime] = Null  -- for [FactureFournisseur].[DatePaiementAcomba] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[FactureFournisseur]
		(
			  [NoFacture]
			, [DateFacture]
			, [Annee]
			, [TypeFactureFournisseur]
			, [TypeFacture]
			, [TypeInvoiceAcomba]
			, [FournisseurID]
			, [PayerAID]
			, [Montant_Total]
			, [Montant_TPS]
			, [Montant_TVQ]
			, [Description]
			, [Status]
			, [StatusDescription]
			, [NumeroCheque]
			, [NumeroPaiement]
			, [NumeroPaiementUnique]
			, [DateFactureAcomba]
			, [DatePaiementAcomba]
		)

		Values
		(
			  @NoFacture
			, @DateFacture
			, @Annee
			, @TypeFactureFournisseur
			, @TypeFacture
			, @TypeInvoiceAcomba
			, @FournisseurID
			, @PayerAID
			, @Montant_Total
			, @Montant_TPS
			, @Montant_TVQ
			, @Description
			, @Status
			, @StatusDescription
			, @NumeroCheque
			, @NumeroPaiement
			, @NumeroPaiementUnique
			, @DateFactureAcomba
			, @DatePaiementAcomba
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[FactureFournisseur] On

		Insert Into [dbo].[FactureFournisseur]
		(
			  [ID]
			, [NoFacture]
			, [DateFacture]
			, [Annee]
			, [TypeFactureFournisseur]
			, [TypeFacture]
			, [TypeInvoiceAcomba]
			, [FournisseurID]
			, [PayerAID]
			, [Montant_Total]
			, [Montant_TPS]
			, [Montant_TVQ]
			, [Description]
			, [Status]
			, [StatusDescription]
			, [NumeroCheque]
			, [NumeroPaiement]
			, [NumeroPaiementUnique]
			, [DateFactureAcomba]
			, [DatePaiementAcomba]
		)

		Values
		(
			  @ID
			, @NoFacture
			, @DateFacture
			, @Annee
			, @TypeFactureFournisseur
			, @TypeFacture
			, @TypeInvoiceAcomba
			, @FournisseurID
			, @PayerAID
			, @Montant_Total
			, @Montant_TPS
			, @Montant_TVQ
			, @Description
			, @Status
			, @StatusDescription
			, @NumeroCheque
			, @NumeroPaiement
			, @NumeroPaiementUnique
			, @DateFactureAcomba
			, @DatePaiementAcomba
		)

		Set Identity_Insert [dbo].[FactureFournisseur] Off

	End

Set NoCount Off

Return(0)


