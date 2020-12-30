

Create Procedure [spU_FactureUsine]

-- Update an existing record in [FactureUsine] table

(
  @ID [int] -- for [FactureUsine].[ID] column
, @DatePermis [smalldatetime] = Null -- for [FactureUsine].[DatePermis] column
, @ConsiderNull_DatePermis bit = 0
, @DateLivraison [smalldatetime] = Null -- for [FactureUsine].[DateLivraison] column
, @ConsiderNull_DateLivraison bit = 0
, @DatePaye [smalldatetime] = Null -- for [FactureUsine].[DatePaye] column
, @ConsiderNull_DatePaye bit = 0
, @Annee [int] = Null -- for [FactureUsine].[Annee] column
, @ConsiderNull_Annee bit = 0
, @Periode [int] = Null -- for [FactureUsine].[Periode] column
, @ConsiderNull_Periode bit = 0
, @ContratID [varchar](10) = Null -- for [FactureUsine].[ContratID] column
, @ConsiderNull_ContratID bit = 0
, @Sciage [bit] = Null -- for [FactureUsine].[Sciage] column
, @ConsiderNull_Sciage bit = 0
, @EssenceSciage [varchar](25) = Null -- for [FactureUsine].[EssenceSciage] column
, @ConsiderNull_EssenceSciage bit = 0
, @NumeroFactureUsine [varchar](25) = Null -- for [FactureUsine].[NumeroFactureUsine] column
, @ConsiderNull_NumeroFactureUsine bit = 0
, @ProducteurID [varchar](15) = Null -- for [FactureUsine].[ProducteurID] column
, @ConsiderNull_ProducteurID bit = 0
, @Livraison [bit] = Null -- for [FactureUsine].[Livraison] column
, @ConsiderNull_Livraison bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_DatePermis Is Null
	Set @ConsiderNull_DatePermis = 0

If @ConsiderNull_DateLivraison Is Null
	Set @ConsiderNull_DateLivraison = 0

If @ConsiderNull_DatePaye Is Null
	Set @ConsiderNull_DatePaye = 0

If @ConsiderNull_Annee Is Null
	Set @ConsiderNull_Annee = 0

If @ConsiderNull_Periode Is Null
	Set @ConsiderNull_Periode = 0

If @ConsiderNull_ContratID Is Null
	Set @ConsiderNull_ContratID = 0

If @ConsiderNull_Sciage Is Null
	Set @ConsiderNull_Sciage = 0

If @ConsiderNull_EssenceSciage Is Null
	Set @ConsiderNull_EssenceSciage = 0

If @ConsiderNull_NumeroFactureUsine Is Null
	Set @ConsiderNull_NumeroFactureUsine = 0

If @ConsiderNull_ProducteurID Is Null
	Set @ConsiderNull_ProducteurID = 0

If @ConsiderNull_Livraison Is Null
	Set @ConsiderNull_Livraison = 0


Update [dbo].[FactureUsine]

Set
	 [DatePermis] = Case @ConsiderNull_DatePermis When 0 Then IsNull(@DatePermis, [DatePermis]) When 1 Then @DatePermis End
	,[DateLivraison] = Case @ConsiderNull_DateLivraison When 0 Then IsNull(@DateLivraison, [DateLivraison]) When 1 Then @DateLivraison End
	,[DatePaye] = Case @ConsiderNull_DatePaye When 0 Then IsNull(@DatePaye, [DatePaye]) When 1 Then @DatePaye End
	,[Annee] = Case @ConsiderNull_Annee When 0 Then IsNull(@Annee, [Annee]) When 1 Then @Annee End
	,[Periode] = Case @ConsiderNull_Periode When 0 Then IsNull(@Periode, [Periode]) When 1 Then @Periode End
	,[ContratID] = Case @ConsiderNull_ContratID When 0 Then IsNull(@ContratID, [ContratID]) When 1 Then @ContratID End
	,[Sciage] = Case @ConsiderNull_Sciage When 0 Then IsNull(@Sciage, [Sciage]) When 1 Then @Sciage End
	,[EssenceSciage] = Case @ConsiderNull_EssenceSciage When 0 Then IsNull(@EssenceSciage, [EssenceSciage]) When 1 Then @EssenceSciage End
	,[NumeroFactureUsine] = Case @ConsiderNull_NumeroFactureUsine When 0 Then IsNull(@NumeroFactureUsine, [NumeroFactureUsine]) When 1 Then @NumeroFactureUsine End
	,[ProducteurID] = Case @ConsiderNull_ProducteurID When 0 Then IsNull(@ProducteurID, [ProducteurID]) When 1 Then @ProducteurID End
	,[Livraison] = Case @ConsiderNull_Livraison When 0 Then IsNull(@Livraison, [Livraison]) When 1 Then @Livraison End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


