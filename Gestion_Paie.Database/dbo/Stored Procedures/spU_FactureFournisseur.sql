

Create Procedure [spU_FactureFournisseur]

-- Update an existing record in [FactureFournisseur] table

(
  @ID [int] -- for [FactureFournisseur].[ID] column
, @NoFacture [varchar](12) -- for [FactureFournisseur].[NoFacture] column
, @ConsiderNull_NoFacture bit = 0
, @DateFacture [smalldatetime] = Null -- for [FactureFournisseur].[DateFacture] column
, @ConsiderNull_DateFacture bit = 0
, @Annee [int] = Null -- for [FactureFournisseur].[Annee] column
, @ConsiderNull_Annee bit = 0
, @TypeFactureFournisseur [char](1) = Null -- for [FactureFournisseur].[TypeFactureFournisseur] column
, @ConsiderNull_TypeFactureFournisseur bit = 0
, @TypeFacture [char](1) = Null -- for [FactureFournisseur].[TypeFacture] column
, @ConsiderNull_TypeFacture bit = 0
, @TypeInvoiceAcomba [int] = Null -- for [FactureFournisseur].[TypeInvoiceAcomba] column
, @ConsiderNull_TypeInvoiceAcomba bit = 0
, @FournisseurID [varchar](15) = Null -- for [FactureFournisseur].[FournisseurID] column
, @ConsiderNull_FournisseurID bit = 0
, @PayerAID [varchar](15) = Null -- for [FactureFournisseur].[PayerAID] column
, @ConsiderNull_PayerAID bit = 0
, @Montant_Total [float] = Null -- for [FactureFournisseur].[Montant_Total] column
, @ConsiderNull_Montant_Total bit = 0
, @Montant_TPS [float] = Null -- for [FactureFournisseur].[Montant_TPS] column
, @ConsiderNull_Montant_TPS bit = 0
, @Montant_TVQ [float] = Null -- for [FactureFournisseur].[Montant_TVQ] column
, @ConsiderNull_Montant_TVQ bit = 0
, @Description [varchar](255) = Null -- for [FactureFournisseur].[Description] column
, @ConsiderNull_Description bit = 0
, @Status [varchar](15) = Null -- for [FactureFournisseur].[Status] column
, @ConsiderNull_Status bit = 0
, @StatusDescription [varchar](300) = Null -- for [FactureFournisseur].[StatusDescription] column
, @ConsiderNull_StatusDescription bit = 0
, @NumeroCheque [varchar](20) = Null -- for [FactureFournisseur].[NumeroCheque] column
, @ConsiderNull_NumeroCheque bit = 0
, @NumeroPaiement [varchar](20) = Null -- for [FactureFournisseur].[NumeroPaiement] column
, @ConsiderNull_NumeroPaiement bit = 0
, @NumeroPaiementUnique [varchar](20) = Null -- for [FactureFournisseur].[NumeroPaiementUnique] column
, @ConsiderNull_NumeroPaiementUnique bit = 0
, @DateFactureAcomba [smalldatetime] = Null -- for [FactureFournisseur].[DateFactureAcomba] column
, @ConsiderNull_DateFactureAcomba bit = 0
, @DatePaiementAcomba [smalldatetime] = Null -- for [FactureFournisseur].[DatePaiementAcomba] column
, @ConsiderNull_DatePaiementAcomba bit = 0
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

If @ConsiderNull_TypeFactureFournisseur Is Null
	Set @ConsiderNull_TypeFactureFournisseur = 0

If @ConsiderNull_TypeFacture Is Null
	Set @ConsiderNull_TypeFacture = 0

If @ConsiderNull_TypeInvoiceAcomba Is Null
	Set @ConsiderNull_TypeInvoiceAcomba = 0

If @ConsiderNull_FournisseurID Is Null
	Set @ConsiderNull_FournisseurID = 0

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

If @ConsiderNull_NumeroCheque Is Null
	Set @ConsiderNull_NumeroCheque = 0

If @ConsiderNull_NumeroPaiement Is Null
	Set @ConsiderNull_NumeroPaiement = 0

If @ConsiderNull_NumeroPaiementUnique Is Null
	Set @ConsiderNull_NumeroPaiementUnique = 0

If @ConsiderNull_DateFactureAcomba Is Null
	Set @ConsiderNull_DateFactureAcomba = 0

If @ConsiderNull_DatePaiementAcomba Is Null
	Set @ConsiderNull_DatePaiementAcomba = 0


Update [dbo].[FactureFournisseur]

Set
	 [NoFacture] = Case @ConsiderNull_NoFacture When 0 Then IsNull(@NoFacture, [NoFacture]) When 1 Then @NoFacture End
	,[DateFacture] = Case @ConsiderNull_DateFacture When 0 Then IsNull(@DateFacture, [DateFacture]) When 1 Then @DateFacture End
	,[Annee] = Case @ConsiderNull_Annee When 0 Then IsNull(@Annee, [Annee]) When 1 Then @Annee End
	,[TypeFactureFournisseur] = Case @ConsiderNull_TypeFactureFournisseur When 0 Then IsNull(@TypeFactureFournisseur, [TypeFactureFournisseur]) When 1 Then @TypeFactureFournisseur End
	,[TypeFacture] = Case @ConsiderNull_TypeFacture When 0 Then IsNull(@TypeFacture, [TypeFacture]) When 1 Then @TypeFacture End
	,[TypeInvoiceAcomba] = Case @ConsiderNull_TypeInvoiceAcomba When 0 Then IsNull(@TypeInvoiceAcomba, [TypeInvoiceAcomba]) When 1 Then @TypeInvoiceAcomba End
	,[FournisseurID] = Case @ConsiderNull_FournisseurID When 0 Then IsNull(@FournisseurID, [FournisseurID]) When 1 Then @FournisseurID End
	,[PayerAID] = Case @ConsiderNull_PayerAID When 0 Then IsNull(@PayerAID, [PayerAID]) When 1 Then @PayerAID End
	,[Montant_Total] = Case @ConsiderNull_Montant_Total When 0 Then IsNull(@Montant_Total, [Montant_Total]) When 1 Then @Montant_Total End
	,[Montant_TPS] = Case @ConsiderNull_Montant_TPS When 0 Then IsNull(@Montant_TPS, [Montant_TPS]) When 1 Then @Montant_TPS End
	,[Montant_TVQ] = Case @ConsiderNull_Montant_TVQ When 0 Then IsNull(@Montant_TVQ, [Montant_TVQ]) When 1 Then @Montant_TVQ End
	,[Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[Status] = Case @ConsiderNull_Status When 0 Then IsNull(@Status, [Status]) When 1 Then @Status End
	,[StatusDescription] = Case @ConsiderNull_StatusDescription When 0 Then IsNull(@StatusDescription, [StatusDescription]) When 1 Then @StatusDescription End
	,[NumeroCheque] = Case @ConsiderNull_NumeroCheque When 0 Then IsNull(@NumeroCheque, [NumeroCheque]) When 1 Then @NumeroCheque End
	,[NumeroPaiement] = Case @ConsiderNull_NumeroPaiement When 0 Then IsNull(@NumeroPaiement, [NumeroPaiement]) When 1 Then @NumeroPaiement End
	,[NumeroPaiementUnique] = Case @ConsiderNull_NumeroPaiementUnique When 0 Then IsNull(@NumeroPaiementUnique, [NumeroPaiementUnique]) When 1 Then @NumeroPaiementUnique End
	,[DateFactureAcomba] = Case @ConsiderNull_DateFactureAcomba When 0 Then IsNull(@DateFactureAcomba, [DateFactureAcomba]) When 1 Then @DateFactureAcomba End
	,[DatePaiementAcomba] = Case @ConsiderNull_DatePaiementAcomba When 0 Then IsNull(@DatePaiementAcomba, [DatePaiementAcomba]) When 1 Then @DatePaiementAcomba End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


