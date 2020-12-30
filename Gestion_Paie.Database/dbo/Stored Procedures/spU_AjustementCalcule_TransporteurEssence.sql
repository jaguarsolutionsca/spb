CREATE Procedure [dbo].[spU_AjustementCalcule_TransporteurEssence]

-- Update an existing record in [AjustementCalcule_TransporteurEssence] table

(
  @ID [int] -- for [AjustementCalcule_TransporteurEssence].[ID] column
, @DateCalcul [datetime] = Null -- for [AjustementCalcule_TransporteurEssence].[DateCalcul] column
, @ConsiderNull_DateCalcul bit = 0
, @AjustementID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[AjustementID] column
, @ConsiderNull_AjustementID bit = 0
, @EssenceID [varchar](6) = Null -- for [AjustementCalcule_TransporteurEssence].[EssenceID] column
, @ConsiderNull_EssenceID bit = 0
, @UniteID [varchar](6) = Null -- for [AjustementCalcule_TransporteurEssence].[UniteID] column
, @ConsiderNull_UniteID bit = 0
, @LivraisonDetailID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[LivraisonDetailID] column
, @ConsiderNull_LivraisonDetailID bit = 0
, @TransporteurID [varchar](15) = Null -- for [AjustementCalcule_TransporteurEssence].[TransporteurID] column
, @ConsiderNull_TransporteurID bit = 0
, @Volume [float] = Null -- for [AjustementCalcule_TransporteurEssence].[Volume] column
, @ConsiderNull_Volume bit = 0
, @Taux [float] = Null -- for [AjustementCalcule_TransporteurEssence].[Taux] column
, @ConsiderNull_Taux bit = 0
, @Montant [float] = Null -- for [AjustementCalcule_TransporteurEssence].[Montant] column
, @ConsiderNull_Montant bit = 0
, @Facture [bit] = Null -- for [AjustementCalcule_TransporteurEssence].[Facture] column
, @ConsiderNull_Facture bit = 0
, @FactureID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[FactureID] column
, @ConsiderNull_FactureID bit = 0
, @ErreurCalcul [bit] = Null -- for [AjustementCalcule_TransporteurEssence].[ErreurCalcul] column
, @ConsiderNull_ErreurCalcul bit = 0
, @ErreurDescription [varchar](300) = Null -- for [AjustementCalcule_TransporteurEssence].[ErreurDescription] column
, @ConsiderNull_ErreurDescription bit = 0
, @Code [char](4) = Null -- for [AjustementCalcule_TransporteurEssence].[Code] column
, @ConsiderNull_Code bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_DateCalcul Is Null
	Set @ConsiderNull_DateCalcul = 0

If @ConsiderNull_AjustementID Is Null
	Set @ConsiderNull_AjustementID = 0

If @ConsiderNull_EssenceID Is Null
	Set @ConsiderNull_EssenceID = 0

If @ConsiderNull_UniteID Is Null
	Set @ConsiderNull_UniteID = 0

If @ConsiderNull_LivraisonDetailID Is Null
	Set @ConsiderNull_LivraisonDetailID = 0

If @ConsiderNull_TransporteurID Is Null
	Set @ConsiderNull_TransporteurID = 0

If @ConsiderNull_Volume Is Null
	Set @ConsiderNull_Volume = 0

If @ConsiderNull_Taux Is Null
	Set @ConsiderNull_Taux = 0

If @ConsiderNull_Montant Is Null
	Set @ConsiderNull_Montant = 0

If @ConsiderNull_Facture Is Null
	Set @ConsiderNull_Facture = 0

If @ConsiderNull_FactureID Is Null
	Set @ConsiderNull_FactureID = 0

If @ConsiderNull_ErreurCalcul Is Null
	Set @ConsiderNull_ErreurCalcul = 0

If @ConsiderNull_ErreurDescription Is Null
	Set @ConsiderNull_ErreurDescription = 0

If @ConsiderNull_Code Is Null
	Set @ConsiderNull_Code = 0


Update [dbo].[AjustementCalcule_TransporteurEssence]

Set
	 [DateCalcul] = Case @ConsiderNull_DateCalcul When 0 Then IsNull(@DateCalcul, [DateCalcul]) When 1 Then @DateCalcul End
	,[AjustementID] = Case @ConsiderNull_AjustementID When 0 Then IsNull(@AjustementID, [AjustementID]) When 1 Then @AjustementID End
	,[EssenceID] = Case @ConsiderNull_EssenceID When 0 Then IsNull(@EssenceID, [EssenceID]) When 1 Then @EssenceID End
	,[UniteID] = Case @ConsiderNull_UniteID When 0 Then IsNull(@UniteID, [UniteID]) When 1 Then @UniteID End
	,[LivraisonDetailID] = Case @ConsiderNull_LivraisonDetailID When 0 Then IsNull(@LivraisonDetailID, [LivraisonDetailID]) When 1 Then @LivraisonDetailID End
	,[TransporteurID] = Case @ConsiderNull_TransporteurID When 0 Then IsNull(@TransporteurID, [TransporteurID]) When 1 Then @TransporteurID End
	,[Volume] = Case @ConsiderNull_Volume When 0 Then IsNull(@Volume, [Volume]) When 1 Then @Volume End
	,[Taux] = Case @ConsiderNull_Taux When 0 Then IsNull(@Taux, [Taux]) When 1 Then @Taux End
	,[Montant] = Case @ConsiderNull_Montant When 0 Then IsNull(@Montant, [Montant]) When 1 Then @Montant End
	,[Facture] = Case @ConsiderNull_Facture When 0 Then IsNull(@Facture, [Facture]) When 1 Then @Facture End
	,[FactureID] = Case @ConsiderNull_FactureID When 0 Then IsNull(@FactureID, [FactureID]) When 1 Then @FactureID End
	,[ErreurCalcul] = Case @ConsiderNull_ErreurCalcul When 0 Then IsNull(@ErreurCalcul, [ErreurCalcul]) When 1 Then @ErreurCalcul End
	,[ErreurDescription] = Case @ConsiderNull_ErreurDescription When 0 Then IsNull(@ErreurDescription, [ErreurDescription]) When 1 Then @ErreurDescription End
	,[Code] = Case @ConsiderNull_Code When 0 Then IsNull(@Code, [Code]) When 1 Then @Code End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)
