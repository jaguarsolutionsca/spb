

Create Procedure [spU_Contrat]

-- Update an existing record in [Contrat] table

(
  @ID [varchar](10) -- for [Contrat].[ID] column
, @Description [varchar](50) = Null -- for [Contrat].[Description] column
, @ConsiderNull_Description bit = 0
, @UsineID [varchar](6) = Null -- for [Contrat].[UsineID] column
, @ConsiderNull_UsineID bit = 0
, @Annee [int] = Null -- for [Contrat].[Annee] column
, @ConsiderNull_Annee bit = 0
, @Date_debut [smalldatetime] = Null -- for [Contrat].[Date_debut] column
, @ConsiderNull_Date_debut bit = 0
, @Date_fin [smalldatetime] = Null -- for [Contrat].[Date_fin] column
, @ConsiderNull_Date_fin bit = 0
, @Actif [bit] = Null -- for [Contrat].[Actif] column
, @ConsiderNull_Actif bit = 0
, @PaieTransporteur [bit] = Null -- for [Contrat].[PaieTransporteur] column
, @ConsiderNull_PaieTransporteur bit = 0
, @Taux_Surcharge [float] = Null -- for [Contrat].[Taux_Surcharge] column
, @ConsiderNull_Taux_Surcharge bit = 0
, @SurchargeManuel [bit] = Null -- for [Contrat].[SurchargeManuel] column
, @ConsiderNull_SurchargeManuel bit = 0
, @TxTransSameProd [bit] = Null -- for [Contrat].[TxTransSameProd] column
, @ConsiderNull_TxTransSameProd bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0

If @ConsiderNull_UsineID Is Null
	Set @ConsiderNull_UsineID = 0

If @ConsiderNull_Annee Is Null
	Set @ConsiderNull_Annee = 0

If @ConsiderNull_Date_debut Is Null
	Set @ConsiderNull_Date_debut = 0

If @ConsiderNull_Date_fin Is Null
	Set @ConsiderNull_Date_fin = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0

If @ConsiderNull_PaieTransporteur Is Null
	Set @ConsiderNull_PaieTransporteur = 0

If @ConsiderNull_Taux_Surcharge Is Null
	Set @ConsiderNull_Taux_Surcharge = 0

If @ConsiderNull_SurchargeManuel Is Null
	Set @ConsiderNull_SurchargeManuel = 0

If @ConsiderNull_TxTransSameProd Is Null
	Set @ConsiderNull_TxTransSameProd = 0


Update [dbo].[Contrat]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[UsineID] = Case @ConsiderNull_UsineID When 0 Then IsNull(@UsineID, [UsineID]) When 1 Then @UsineID End
	,[Annee] = Case @ConsiderNull_Annee When 0 Then IsNull(@Annee, [Annee]) When 1 Then @Annee End
	,[Date_debut] = Case @ConsiderNull_Date_debut When 0 Then IsNull(@Date_debut, [Date_debut]) When 1 Then @Date_debut End
	,[Date_fin] = Case @ConsiderNull_Date_fin When 0 Then IsNull(@Date_fin, [Date_fin]) When 1 Then @Date_fin End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End
	,[PaieTransporteur] = Case @ConsiderNull_PaieTransporteur When 0 Then IsNull(@PaieTransporteur, [PaieTransporteur]) When 1 Then @PaieTransporteur End
	,[Taux_Surcharge] = Case @ConsiderNull_Taux_Surcharge When 0 Then IsNull(@Taux_Surcharge, [Taux_Surcharge]) When 1 Then @Taux_Surcharge End
	,[SurchargeManuel] = Case @ConsiderNull_SurchargeManuel When 0 Then IsNull(@SurchargeManuel, [SurchargeManuel]) When 1 Then @SurchargeManuel End
	,[TxTransSameProd] = Case @ConsiderNull_TxTransSameProd When 0 Then IsNull(@TxTransSameProd, [TxTransSameProd]) When 1 Then @TxTransSameProd End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


