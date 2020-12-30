
CREATE Procedure [spU_Ajustement]

-- Update an existing record in [Ajustement] table

(
  @ID [int] -- for [Ajustement].[ID] column
, @ContratID [varchar](10) -- for [Ajustement].[ContratID] column
, @ConsiderNull_ContratID bit = 0
, @DateAjustement [datetime] = Null -- for [Ajustement].[DateAjustement] column
, @ConsiderNull_DateAjustement bit = 0
, @Periode_Debut [int] = Null -- for [Ajustement].[Periode_Debut] column
, @ConsiderNull_Periode_Debut bit = 0
, @Periode_Fin [int] = Null -- for [Ajustement].[Periode_Fin] column
, @ConsiderNull_Periode_Fin bit = 0
, @Facture [bit] = Null -- for [Ajustement].[Facture] column
, @ConsiderNull_Facture bit = 0
, @UsePeriodes [bit] = Null -- for [Ajustement].[UsePeriodes] column
, @ConsiderNull_UsePeriodes bit = 0
, @Date_Debut [smalldatetime] = Null -- for [Ajustement].[Date_Debut] column
, @ConsiderNull_Date_Debut bit = 0
, @Date_Fin [smalldatetime] = Null -- for [Ajustement].[Date_Fin] column
, @ConsiderNull_Date_Fin bit = 0
, @ProducteurID [varchar](15) = Null -- for [Ajustement].[ProducteurID] column
, @ConsiderNull_ProducteurID bit = 0
, @TransporteurID [varchar](15) = Null -- for [Ajustement].[TransporteurID] column
, @ConsiderNull_TransporteurID bit = 0
, @IsRistourne [bit] -- for [Ajustement].[IsRistourne] column
, @ConsiderNull_IsRistourne bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_ContratID Is Null
	Set @ConsiderNull_ContratID = 0

If @ConsiderNull_DateAjustement Is Null
	Set @ConsiderNull_DateAjustement = 0

If @ConsiderNull_Periode_Debut Is Null
	Set @ConsiderNull_Periode_Debut = 0

If @ConsiderNull_Periode_Fin Is Null
	Set @ConsiderNull_Periode_Fin = 0

If @ConsiderNull_Facture Is Null
	Set @ConsiderNull_Facture = 0

If @ConsiderNull_UsePeriodes Is Null
	Set @ConsiderNull_UsePeriodes = 0

If @ConsiderNull_Date_Debut Is Null
	Set @ConsiderNull_Date_Debut = 0

If @ConsiderNull_Date_Fin Is Null
	Set @ConsiderNull_Date_Fin = 0

If @ConsiderNull_ProducteurID Is Null
	Set @ConsiderNull_ProducteurID = 0

If @ConsiderNull_TransporteurID Is Null
	Set @ConsiderNull_TransporteurID = 0

If @ConsiderNull_IsRistourne Is Null
	Set @ConsiderNull_IsRistourne = 0


Update [dbo].[Ajustement]

Set
	 [ContratID] = Case @ConsiderNull_ContratID When 0 Then IsNull(@ContratID, [ContratID]) When 1 Then @ContratID End
	,[DateAjustement] = Case @ConsiderNull_DateAjustement When 0 Then IsNull(@DateAjustement, [DateAjustement]) When 1 Then @DateAjustement End
	,[Periode_Debut] = Case @ConsiderNull_Periode_Debut When 0 Then IsNull(@Periode_Debut, [Periode_Debut]) When 1 Then @Periode_Debut End
	,[Periode_Fin] = Case @ConsiderNull_Periode_Fin When 0 Then IsNull(@Periode_Fin, [Periode_Fin]) When 1 Then @Periode_Fin End
	,[Facture] = Case @ConsiderNull_Facture When 0 Then IsNull(@Facture, [Facture]) When 1 Then @Facture End
	,[UsePeriodes] = Case @ConsiderNull_UsePeriodes When 0 Then IsNull(@UsePeriodes, [UsePeriodes]) When 1 Then @UsePeriodes End
	,[Date_Debut] = Case @ConsiderNull_Date_Debut When 0 Then IsNull(@Date_Debut, [Date_Debut]) When 1 Then @Date_Debut End
	,[Date_Fin] = Case @ConsiderNull_Date_Fin When 0 Then IsNull(@Date_Fin, [Date_Fin]) When 1 Then @Date_Fin End
	,[ProducteurID] = Case @ConsiderNull_ProducteurID When 0 Then IsNull(@ProducteurID, [ProducteurID]) When 1 Then @ProducteurID End
	,[TransporteurID] = Case @ConsiderNull_TransporteurID When 0 Then IsNull(@TransporteurID, [TransporteurID]) When 1 Then @TransporteurID End
	,[IsRistourne] = Case @ConsiderNull_IsRistourne When 0 Then IsNull(@IsRistourne, [IsRistourne]) When 1 Then @IsRistourne End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)

