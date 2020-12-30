

Create Procedure [spI_FactureClient]

-- Inserts a new record in [FactureClient] table
(
  @ID [int] = Null Output -- for [FactureClient].[ID] column
, @NoFacture [varchar](12) = Null  -- for [FactureClient].[NoFacture] column
, @DateFacture [smalldatetime] = Null  -- for [FactureClient].[DateFacture] column
, @Annee [int] = Null  -- for [FactureClient].[Annee] column
, @TypeFacture [char](1) = Null  -- for [FactureClient].[TypeFacture] column
, @TypeInvoiceClientAcomba [int] = Null  -- for [FactureClient].[TypeInvoiceClientAcomba] column
, @ClientID [varchar](6) = Null  -- for [FactureClient].[ClientID] column
, @PayerAID [varchar](6) = Null  -- for [FactureClient].[PayerAID] column
, @Montant_Total [float] = Null  -- for [FactureClient].[Montant_Total] column
, @Montant_TPS [float] = Null  -- for [FactureClient].[Montant_TPS] column
, @Montant_TVQ [float] = Null  -- for [FactureClient].[Montant_TVQ] column
, @Description [varchar](255) = Null  -- for [FactureClient].[Description] column
, @Status [varchar](15) = Null  -- for [FactureClient].[Status] column
, @StatusDescription [varchar](300) = Null  -- for [FactureClient].[StatusDescription] column
, @DateFactureAcomba [smalldatetime] = Null  -- for [FactureClient].[DateFactureAcomba] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[FactureClient]
		(
			  [NoFacture]
			, [DateFacture]
			, [Annee]
			, [TypeFacture]
			, [TypeInvoiceClientAcomba]
			, [ClientID]
			, [PayerAID]
			, [Montant_Total]
			, [Montant_TPS]
			, [Montant_TVQ]
			, [Description]
			, [Status]
			, [StatusDescription]
			, [DateFactureAcomba]
		)

		Values
		(
			  @NoFacture
			, @DateFacture
			, @Annee
			, @TypeFacture
			, @TypeInvoiceClientAcomba
			, @ClientID
			, @PayerAID
			, @Montant_Total
			, @Montant_TPS
			, @Montant_TVQ
			, @Description
			, @Status
			, @StatusDescription
			, @DateFactureAcomba
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[FactureClient] On

		Insert Into [dbo].[FactureClient]
		(
			  [ID]
			, [NoFacture]
			, [DateFacture]
			, [Annee]
			, [TypeFacture]
			, [TypeInvoiceClientAcomba]
			, [ClientID]
			, [PayerAID]
			, [Montant_Total]
			, [Montant_TPS]
			, [Montant_TVQ]
			, [Description]
			, [Status]
			, [StatusDescription]
			, [DateFactureAcomba]
		)

		Values
		(
			  @ID
			, @NoFacture
			, @DateFacture
			, @Annee
			, @TypeFacture
			, @TypeInvoiceClientAcomba
			, @ClientID
			, @PayerAID
			, @Montant_Total
			, @Montant_TPS
			, @Montant_TVQ
			, @Description
			, @Status
			, @StatusDescription
			, @DateFactureAcomba
		)

		Set Identity_Insert [dbo].[FactureClient] Off

	End

Set NoCount Off

Return(0)


