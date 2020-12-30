

Create Procedure [spU_GestionVolume]

-- Update an existing record in [GestionVolume] table

(
  @ID [int] -- for [GestionVolume].[ID] column
, @DateLivraison [datetime] = Null -- for [GestionVolume].[DateLivraison] column
, @ConsiderNull_DateLivraison bit = 0
, @UsineID [varchar](6) = Null -- for [GestionVolume].[UsineID] column
, @ConsiderNull_UsineID bit = 0
, @UniteMesureID [varchar](6) = Null -- for [GestionVolume].[UniteMesureID] column
, @ConsiderNull_UniteMesureID bit = 0
, @ProducteurID [varchar](15) = Null -- for [GestionVolume].[ProducteurID] column
, @ConsiderNull_ProducteurID bit = 0
, @Annee [int] = Null -- for [GestionVolume].[Annee] column
, @ConsiderNull_Annee bit = 0
, @Periode [int] = Null -- for [GestionVolume].[Periode] column
, @ConsiderNull_Periode bit = 0
, @LotID [int] = Null -- for [GestionVolume].[LotID] column
, @ConsiderNull_LotID bit = 0
, @DateEntree [smalldatetime] = Null -- for [GestionVolume].[DateEntree] column
, @ConsiderNull_DateEntree bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_DateLivraison Is Null
	Set @ConsiderNull_DateLivraison = 0

If @ConsiderNull_UsineID Is Null
	Set @ConsiderNull_UsineID = 0

If @ConsiderNull_UniteMesureID Is Null
	Set @ConsiderNull_UniteMesureID = 0

If @ConsiderNull_ProducteurID Is Null
	Set @ConsiderNull_ProducteurID = 0

If @ConsiderNull_Annee Is Null
	Set @ConsiderNull_Annee = 0

If @ConsiderNull_Periode Is Null
	Set @ConsiderNull_Periode = 0

If @ConsiderNull_LotID Is Null
	Set @ConsiderNull_LotID = 0

If @ConsiderNull_DateEntree Is Null
	Set @ConsiderNull_DateEntree = 0


Update [dbo].[GestionVolume]

Set
	 [DateLivraison] = Case @ConsiderNull_DateLivraison When 0 Then IsNull(@DateLivraison, [DateLivraison]) When 1 Then @DateLivraison End
	,[UsineID] = Case @ConsiderNull_UsineID When 0 Then IsNull(@UsineID, [UsineID]) When 1 Then @UsineID End
	,[UniteMesureID] = Case @ConsiderNull_UniteMesureID When 0 Then IsNull(@UniteMesureID, [UniteMesureID]) When 1 Then @UniteMesureID End
	,[ProducteurID] = Case @ConsiderNull_ProducteurID When 0 Then IsNull(@ProducteurID, [ProducteurID]) When 1 Then @ProducteurID End
	,[Annee] = Case @ConsiderNull_Annee When 0 Then IsNull(@Annee, [Annee]) When 1 Then @Annee End
	,[Periode] = Case @ConsiderNull_Periode When 0 Then IsNull(@Periode, [Periode]) When 1 Then @Periode End
	,[LotID] = Case @ConsiderNull_LotID When 0 Then IsNull(@LotID, [LotID]) When 1 Then @LotID End
	,[DateEntree] = Case @ConsiderNull_DateEntree When 0 Then IsNull(@DateEntree, [DateEntree]) When 1 Then @DateEntree End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


