

Create Procedure [spU_FactureClient]

-- Update an existing record in [FactureClient] table

(
  @ID [int] -- for [FactureClient].[ID] column
, @NoFacture [varchar](12) = Null -- for [FactureClient].[NoFacture] column
, @ConsiderNull_NoFacture bit = 0
, @DateFacture [smalldatetime] = Null -- for [FactureClient].[DateFacture] column
, @ConsiderNull_DateFacture bit = 0
, @Annee [int] = Null -- for [FactureClient].[Annee] column
, @ConsiderNull_Annee bit = 0
, @TypeFacture [char](1) = Null -- for [FactureClient].[TypeFacture] column
, @ConsiderNull_TypeFacture bit = 0
, @TypeInvoiceClientAcomba [int] = Null -- for [FactureClient].[TypeInvoiceClientAcomba] column
, @ConsiderNull_TypeInvoiceClientAcomba bit = 0
, @ClientID [varchar](6) = Null -- for [FactureClient].[ClientID] column
, @ConsiderNull_ClientID bit = 0
, @PayerAID [varchar](6) = Null -- for [FactureClient].[PayerAID] column
, @ConsiderNull_PayerAID bit = 0
, @Montant_Total [float] = Null -- for [FactureClient].[Montant_Total] column
, @ConsiderNull_Montant_Total bit = 0
, @Montant_TPS [float] = Null -- for [FactureClient].[Montant_TPS] column
, @ConsiderNull_Montant_TPS bit = 0
, @Montant_TVQ [float] = Null -- for [FactureClient].[Montant_TVQ] column
, @ConsiderNull_Montant_TVQ bit = 0
, @Description [varchar](255) = Null -- for [FactureClient].[Description] column
, @ConsiderNull_Description bit = 0
, @Status [varchar](15) = Null -- for [FactureClient].[Status] column
, @ConsiderNull_Status bit = 0
, @StatusDescription [varchar](300) = Null -- for [FactureClient].[StatusDescription] column
, @ConsiderNull_StatusDescription bit = 0
, @DateFactureAcomba [smalldatetime] = Null -- for [FactureClient].[DateFactureAcomba] column
, @ConsiderNull_DateFactureAcomba bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_NoFacture Is Null
	Set @ConsiderNull_NoFacture = 0

If @ConsiderNull_DateFacture Is Null
	Set @ConsiderNull_DateFacture = 0

If @ConsiderNull_Annee Is Null
	Set @ConsiderNull_Annee = 0

If @ConsiderNull_TypeFacture Is Null
	Set @ConsiderNull_TypeFacture = 0

If @ConsiderNull_TypeInvoiceClientAcomba Is Null
	Set @ConsiderNull_TypeInvoiceClientAcomba = 0

If @ConsiderNull_ClientID Is Null
	Set @ConsiderNull_ClientID = 0

If @ConsiderNull_PayerAID Is Null
	Set @ConsiderNull_PayerAID = 0

If @ConsiderNull_Montant_Total Is Null
	Set @ConsiderNull_Montant_Total = 0

If @ConsiderNull_Montant_TPS Is Null
	Set @ConsiderNull_Montant_TPS = 0

If @ConsiderNull_Montant_TVQ Is Null
	Set @ConsiderNull_Montant_TVQ = 0

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0

If @ConsiderNull_Status Is Null
	Set @ConsiderNull_Status = 0

If @ConsiderNull_StatusDescription Is Null
	Set @ConsiderNull_StatusDescription = 0

If @ConsiderNull_DateFactureAcomba Is Null
	Set @ConsiderNull_DateFactureAcomba = 0


Update [dbo].[FactureClient]

Set
	 [NoFacture] = Case @ConsiderNull_NoFacture When 0 Then IsNull(@NoFacture, [NoFacture]) When 1 Then @NoFacture End
	,[DateFacture] = Case @ConsiderNull_DateFacture When 0 Then IsNull(@DateFacture, [DateFacture]) When 1 Then @DateFacture End
	,[Annee] = Case @ConsiderNull_Annee When 0 Then IsNull(@Annee, [Annee]) When 1 Then @Annee End
	,[TypeFacture] = Case @ConsiderNull_TypeFacture When 0 Then IsNull(@TypeFacture, [TypeFacture]) When 1 Then @TypeFacture End
	,[TypeInvoiceClientAcomba] = Case @ConsiderNull_TypeInvoiceClientAcomba When 0 Then IsNull(@TypeInvoiceClientAcomba, [TypeInvoiceClientAcomba]) When 1 Then @TypeInvoiceClientAcomba End
	,[ClientID] = Case @ConsiderNull_ClientID When 0 Then IsNull(@ClientID, [ClientID]) When 1 Then @ClientID End
	,[PayerAID] = Case @ConsiderNull_PayerAID When 0 Then IsNull(@PayerAID, [PayerAID]) When 1 Then @PayerAID End
	,[Montant_Total] = Case @ConsiderNull_Montant_Total When 0 Then IsNull(@Montant_Total, [Montant_Total]) When 1 Then @Montant_Total End
	,[Montant_TPS] = Case @ConsiderNull_Montant_TPS When 0 Then IsNull(@Montant_TPS, [Montant_TPS]) When 1 Then @Montant_TPS End
	,[Montant_TVQ] = Case @ConsiderNull_Montant_TVQ When 0 Then IsNull(@Montant_TVQ, [Montant_TVQ]) When 1 Then @Montant_TVQ End
	,[Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[Status] = Case @ConsiderNull_Status When 0 Then IsNull(@Status, [Status]) When 1 Then @Status End
	,[StatusDescription] = Case @ConsiderNull_StatusDescription When 0 Then IsNull(@StatusDescription, [StatusDescription]) When 1 Then @StatusDescription End
	,[DateFactureAcomba] = Case @ConsiderNull_DateFactureAcomba When 0 Then IsNull(@DateFactureAcomba, [DateFactureAcomba]) When 1 Then @DateFactureAcomba End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


