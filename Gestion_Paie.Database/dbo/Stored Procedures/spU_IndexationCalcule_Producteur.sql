

Create Procedure [spU_IndexationCalcule_Producteur]

-- Update an existing record in [IndexationCalcule_Producteur] table

(
  @ID [int] -- for [IndexationCalcule_Producteur].[ID] column
, @DateCalcul [datetime] = Null -- for [IndexationCalcule_Producteur].[DateCalcul] column
, @ConsiderNull_DateCalcul bit = 0
, @TypeIndexation [char](1) = Null -- for [IndexationCalcule_Producteur].[TypeIndexation] column
, @ConsiderNull_TypeIndexation bit = 0
, @IndexationID [int] = Null -- for [IndexationCalcule_Producteur].[IndexationID] column
, @ConsiderNull_IndexationID bit = 0
, @IndexationDetailID [int] = Null -- for [IndexationCalcule_Producteur].[IndexationDetailID] column
, @ConsiderNull_IndexationDetailID bit = 0
, @LivraisonID [int] = Null -- for [IndexationCalcule_Producteur].[LivraisonID] column
, @ConsiderNull_LivraisonID bit = 0
, @LivraisonDetailID [int] = Null -- for [IndexationCalcule_Producteur].[LivraisonDetailID] column
, @ConsiderNull_LivraisonDetailID bit = 0
, @ProducteurID [varchar](15) = Null -- for [IndexationCalcule_Producteur].[ProducteurID] column
, @ConsiderNull_ProducteurID bit = 0
, @ContratID [varchar](10) = Null -- for [IndexationCalcule_Producteur].[ContratID] column
, @ConsiderNull_ContratID bit = 0
, @EssenceID [varchar](6) = Null -- for [IndexationCalcule_Producteur].[EssenceID] column
, @ConsiderNull_EssenceID bit = 0
, @Code [char](4) = Null -- for [IndexationCalcule_Producteur].[Code] column
, @ConsiderNull_Code bit = 0
, @UniteID [varchar](6) = Null -- for [IndexationCalcule_Producteur].[UniteID] column
, @ConsiderNull_UniteID bit = 0
, @Volume [float] = Null -- for [IndexationCalcule_Producteur].[Volume] column
, @ConsiderNull_Volume bit = 0
, @MontantDejaPaye [float] = Null -- for [IndexationCalcule_Producteur].[MontantDejaPaye] column
, @ConsiderNull_MontantDejaPaye bit = 0
, @PourcentageDuMontant [float] = Null -- for [IndexationCalcule_Producteur].[PourcentageDuMontant] column
, @ConsiderNull_PourcentageDuMontant bit = 0
, @Taux [float] = Null -- for [IndexationCalcule_Producteur].[Taux] column
, @ConsiderNull_Taux bit = 0
, @Montant [float] = Null -- for [IndexationCalcule_Producteur].[Montant] column
, @ConsiderNull_Montant bit = 0
, @Facture [bit] = Null -- for [IndexationCalcule_Producteur].[Facture] column
, @ConsiderNull_Facture bit = 0
, @FactureID [int] = Null -- for [IndexationCalcule_Producteur].[FactureID] column
, @ConsiderNull_FactureID bit = 0
, @ErreurCalcul [bit] = Null -- for [IndexationCalcule_Producteur].[ErreurCalcul] column
, @ConsiderNull_ErreurCalcul bit = 0
, @ErreurDescription [varchar](300) = Null -- for [IndexationCalcule_Producteur].[ErreurDescription] column
, @ConsiderNull_ErreurDescription bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_DateCalcul Is Null
	Set @ConsiderNull_DateCalcul = 0

If @ConsiderNull_TypeIndexation Is Null
	Set @ConsiderNull_TypeIndexation = 0

If @ConsiderNull_IndexationID Is Null
	Set @ConsiderNull_IndexationID = 0

If @ConsiderNull_IndexationDetailID Is Null
	Set @ConsiderNull_IndexationDetailID = 0

If @ConsiderNull_LivraisonID Is Null
	Set @ConsiderNull_LivraisonID = 0

If @ConsiderNull_LivraisonDetailID Is Null
	Set @ConsiderNull_LivraisonDetailID = 0

If @ConsiderNull_ProducteurID Is Null
	Set @ConsiderNull_ProducteurID = 0

If @ConsiderNull_ContratID Is Null
	Set @ConsiderNull_ContratID = 0

If @ConsiderNull_EssenceID Is Null
	Set @ConsiderNull_EssenceID = 0

If @ConsiderNull_Code Is Null
	Set @ConsiderNull_Code = 0

If @ConsiderNull_UniteID Is Null
	Set @ConsiderNull_UniteID = 0

If @ConsiderNull_Volume Is Null
	Set @ConsiderNull_Volume = 0

If @ConsiderNull_MontantDejaPaye Is Null
	Set @ConsiderNull_MontantDejaPaye = 0

If @ConsiderNull_PourcentageDuMontant Is Null
	Set @ConsiderNull_PourcentageDuMontant = 0

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


Update [dbo].[IndexationCalcule_Producteur]

Set
	 [DateCalcul] = Case @ConsiderNull_DateCalcul When 0 Then IsNull(@DateCalcul, [DateCalcul]) When 1 Then @DateCalcul End
	,[TypeIndexation] = Case @ConsiderNull_TypeIndexation When 0 Then IsNull(@TypeIndexation, [TypeIndexation]) When 1 Then @TypeIndexation End
	,[IndexationID] = Case @ConsiderNull_IndexationID When 0 Then IsNull(@IndexationID, [IndexationID]) When 1 Then @IndexationID End
	,[IndexationDetailID] = Case @ConsiderNull_IndexationDetailID When 0 Then IsNull(@IndexationDetailID, [IndexationDetailID]) When 1 Then @IndexationDetailID End
	,[LivraisonID] = Case @ConsiderNull_LivraisonID When 0 Then IsNull(@LivraisonID, [LivraisonID]) When 1 Then @LivraisonID End
	,[LivraisonDetailID] = Case @ConsiderNull_LivraisonDetailID When 0 Then IsNull(@LivraisonDetailID, [LivraisonDetailID]) When 1 Then @LivraisonDetailID End
	,[ProducteurID] = Case @ConsiderNull_ProducteurID When 0 Then IsNull(@ProducteurID, [ProducteurID]) When 1 Then @ProducteurID End
	,[ContratID] = Case @ConsiderNull_ContratID When 0 Then IsNull(@ContratID, [ContratID]) When 1 Then @ContratID End
	,[EssenceID] = Case @ConsiderNull_EssenceID When 0 Then IsNull(@EssenceID, [EssenceID]) When 1 Then @EssenceID End
	,[Code] = Case @ConsiderNull_Code When 0 Then IsNull(@Code, [Code]) When 1 Then @Code End
	,[UniteID] = Case @ConsiderNull_UniteID When 0 Then IsNull(@UniteID, [UniteID]) When 1 Then @UniteID End
	,[Volume] = Case @ConsiderNull_Volume When 0 Then IsNull(@Volume, [Volume]) When 1 Then @Volume End
	,[MontantDejaPaye] = Case @ConsiderNull_MontantDejaPaye When 0 Then IsNull(@MontantDejaPaye, [MontantDejaPaye]) When 1 Then @MontantDejaPaye End
	,[PourcentageDuMontant] = Case @ConsiderNull_PourcentageDuMontant When 0 Then IsNull(@PourcentageDuMontant, [PourcentageDuMontant]) When 1 Then @PourcentageDuMontant End
	,[Taux] = Case @ConsiderNull_Taux When 0 Then IsNull(@Taux, [Taux]) When 1 Then @Taux End
	,[Montant] = Case @ConsiderNull_Montant When 0 Then IsNull(@Montant, [Montant]) When 1 Then @Montant End
	,[Facture] = Case @ConsiderNull_Facture When 0 Then IsNull(@Facture, [Facture]) When 1 Then @Facture End
	,[FactureID] = Case @ConsiderNull_FactureID When 0 Then IsNull(@FactureID, [FactureID]) When 1 Then @FactureID End
	,[ErreurCalcul] = Case @ConsiderNull_ErreurCalcul When 0 Then IsNull(@ErreurCalcul, [ErreurCalcul]) When 1 Then @ErreurCalcul End
	,[ErreurDescription] = Case @ConsiderNull_ErreurDescription When 0 Then IsNull(@ErreurDescription, [ErreurDescription]) When 1 Then @ErreurDescription End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


