

Create Procedure [spU_Permit]

-- Update an existing record in [Permit] table

(
  @ID [int] -- for [Permit].[ID] column
, @DatePermit [smalldatetime] = Null -- for [Permit].[DatePermit] column
, @ConsiderNull_DatePermit bit = 0
, @DateDebut [smalldatetime] = Null -- for [Permit].[DateDebut] column
, @ConsiderNull_DateDebut bit = 0
, @DateFin [smalldatetime] = Null -- for [Permit].[DateFin] column
, @ConsiderNull_DateFin bit = 0
, @Annee [int] = Null -- for [Permit].[Annee] column
, @ConsiderNull_Annee bit = 0
, @Periode [int] = Null -- for [Permit].[Periode] column
, @ConsiderNull_Periode bit = 0
, @ContratID [varchar](10) = Null -- for [Permit].[ContratID] column
, @ConsiderNull_ContratID bit = 0
, @EssenceID [varchar](6) = Null -- for [Permit].[EssenceID] column
, @ConsiderNull_EssenceID bit = 0
, @PermitSciage [bit] = Null -- for [Permit].[PermitSciage] column
, @ConsiderNull_PermitSciage bit = 0
, @TransporteurID [varchar](15) = Null -- for [Permit].[TransporteurID] column
, @ConsiderNull_TransporteurID bit = 0
, @VR [varchar](10) = Null -- for [Permit].[VR] column
, @ConsiderNull_VR bit = 0
, @ProducteurDroitCoupeID [varchar](15) = Null -- for [Permit].[ProducteurDroitCoupeID] column
, @ConsiderNull_ProducteurDroitCoupeID bit = 0
, @ProducteurEntentePaiementID [varchar](15) = Null -- for [Permit].[ProducteurEntentePaiementID] column
, @ConsiderNull_ProducteurEntentePaiementID bit = 0
, @PermitLivre [bit] = Null -- for [Permit].[PermitLivre] column
, @ConsiderNull_PermitLivre bit = 0
, @PermitImprime [bit] = Null -- for [Permit].[PermitImprime] column
, @ConsiderNull_PermitImprime bit = 0
, @PermitAnnule [bit] = Null -- for [Permit].[PermitAnnule] column
, @ConsiderNull_PermitAnnule bit = 0
, @LotID [int] = Null -- for [Permit].[LotID] column
, @ConsiderNull_LotID bit = 0
, @EssenceSciage [varchar](25) = Null -- for [Permit].[EssenceSciage] column
, @ConsiderNull_EssenceSciage bit = 0
, @Code [char](4) = Null -- for [Permit].[Code] column
, @ConsiderNull_Code bit = 0
, @Remarques [varchar](2000) = Null -- for [Permit].[Remarques] column
, @ConsiderNull_Remarques bit = 0
, @ChargeurID [varchar](15) = Null -- for [Permit].[ChargeurID] column
, @ConsiderNull_ChargeurID bit = 0
, @ZoneID [varchar](2) = Null -- for [Permit].[ZoneID] column
, @ConsiderNull_ZoneID bit = 0
, @MunicipaliteID [varchar](6) = Null -- for [Permit].[MunicipaliteID] column
, @ConsiderNull_MunicipaliteID bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_DatePermit Is Null
	Set @ConsiderNull_DatePermit = 0

If @ConsiderNull_DateDebut Is Null
	Set @ConsiderNull_DateDebut = 0

If @ConsiderNull_DateFin Is Null
	Set @ConsiderNull_DateFin = 0

If @ConsiderNull_Annee Is Null
	Set @ConsiderNull_Annee = 0

If @ConsiderNull_Periode Is Null
	Set @ConsiderNull_Periode = 0

If @ConsiderNull_ContratID Is Null
	Set @ConsiderNull_ContratID = 0

If @ConsiderNull_EssenceID Is Null
	Set @ConsiderNull_EssenceID = 0

If @ConsiderNull_PermitSciage Is Null
	Set @ConsiderNull_PermitSciage = 0

If @ConsiderNull_TransporteurID Is Null
	Set @ConsiderNull_TransporteurID = 0

If @ConsiderNull_VR Is Null
	Set @ConsiderNull_VR = 0

If @ConsiderNull_ProducteurDroitCoupeID Is Null
	Set @ConsiderNull_ProducteurDroitCoupeID = 0

If @ConsiderNull_ProducteurEntentePaiementID Is Null
	Set @ConsiderNull_ProducteurEntentePaiementID = 0

If @ConsiderNull_PermitLivre Is Null
	Set @ConsiderNull_PermitLivre = 0

If @ConsiderNull_PermitImprime Is Null
	Set @ConsiderNull_PermitImprime = 0

If @ConsiderNull_PermitAnnule Is Null
	Set @ConsiderNull_PermitAnnule = 0

If @ConsiderNull_LotID Is Null
	Set @ConsiderNull_LotID = 0

If @ConsiderNull_EssenceSciage Is Null
	Set @ConsiderNull_EssenceSciage = 0

If @ConsiderNull_Code Is Null
	Set @ConsiderNull_Code = 0

If @ConsiderNull_Remarques Is Null
	Set @ConsiderNull_Remarques = 0

If @ConsiderNull_ChargeurID Is Null
	Set @ConsiderNull_ChargeurID = 0

If @ConsiderNull_ZoneID Is Null
	Set @ConsiderNull_ZoneID = 0

If @ConsiderNull_MunicipaliteID Is Null
	Set @ConsiderNull_MunicipaliteID = 0


Update [dbo].[Permit]

Set
	 [DatePermit] = Case @ConsiderNull_DatePermit When 0 Then IsNull(@DatePermit, [DatePermit]) When 1 Then @DatePermit End
	,[DateDebut] = Case @ConsiderNull_DateDebut When 0 Then IsNull(@DateDebut, [DateDebut]) When 1 Then @DateDebut End
	,[DateFin] = Case @ConsiderNull_DateFin When 0 Then IsNull(@DateFin, [DateFin]) When 1 Then @DateFin End
	,[Annee] = Case @ConsiderNull_Annee When 0 Then IsNull(@Annee, [Annee]) When 1 Then @Annee End
	,[Periode] = Case @ConsiderNull_Periode When 0 Then IsNull(@Periode, [Periode]) When 1 Then @Periode End
	,[ContratID] = Case @ConsiderNull_ContratID When 0 Then IsNull(@ContratID, [ContratID]) When 1 Then @ContratID End
	,[EssenceID] = Case @ConsiderNull_EssenceID When 0 Then IsNull(@EssenceID, [EssenceID]) When 1 Then @EssenceID End
	,[PermitSciage] = Case @ConsiderNull_PermitSciage When 0 Then IsNull(@PermitSciage, [PermitSciage]) When 1 Then @PermitSciage End
	,[TransporteurID] = Case @ConsiderNull_TransporteurID When 0 Then IsNull(@TransporteurID, [TransporteurID]) When 1 Then @TransporteurID End
	,[VR] = Case @ConsiderNull_VR When 0 Then IsNull(@VR, [VR]) When 1 Then @VR End
	,[ProducteurDroitCoupeID] = Case @ConsiderNull_ProducteurDroitCoupeID When 0 Then IsNull(@ProducteurDroitCoupeID, [ProducteurDroitCoupeID]) When 1 Then @ProducteurDroitCoupeID End
	,[ProducteurEntentePaiementID] = Case @ConsiderNull_ProducteurEntentePaiementID When 0 Then IsNull(@ProducteurEntentePaiementID, [ProducteurEntentePaiementID]) When 1 Then @ProducteurEntentePaiementID End
	,[PermitLivre] = Case @ConsiderNull_PermitLivre When 0 Then IsNull(@PermitLivre, [PermitLivre]) When 1 Then @PermitLivre End
	,[PermitImprime] = Case @ConsiderNull_PermitImprime When 0 Then IsNull(@PermitImprime, [PermitImprime]) When 1 Then @PermitImprime End
	,[PermitAnnule] = Case @ConsiderNull_PermitAnnule When 0 Then IsNull(@PermitAnnule, [PermitAnnule]) When 1 Then @PermitAnnule End
	,[LotID] = Case @ConsiderNull_LotID When 0 Then IsNull(@LotID, [LotID]) When 1 Then @LotID End
	,[EssenceSciage] = Case @ConsiderNull_EssenceSciage When 0 Then IsNull(@EssenceSciage, [EssenceSciage]) When 1 Then @EssenceSciage End
	,[Code] = Case @ConsiderNull_Code When 0 Then IsNull(@Code, [Code]) When 1 Then @Code End
	,[Remarques] = Case @ConsiderNull_Remarques When 0 Then IsNull(@Remarques, [Remarques]) When 1 Then @Remarques End
	,[ChargeurID] = Case @ConsiderNull_ChargeurID When 0 Then IsNull(@ChargeurID, [ChargeurID]) When 1 Then @ChargeurID End
	,[ZoneID] = Case @ConsiderNull_ZoneID When 0 Then IsNull(@ZoneID, [ZoneID]) When 1 Then @ZoneID End
	,[MunicipaliteID] = Case @ConsiderNull_MunicipaliteID When 0 Then IsNull(@MunicipaliteID, [MunicipaliteID]) When 1 Then @MunicipaliteID End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


