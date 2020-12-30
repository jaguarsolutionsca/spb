

Create Procedure [spU_IndexationCalcule_Transporteur]

-- Update an existing record in [IndexationCalcule_Transporteur] table

(
  @ID [int] -- for [IndexationCalcule_Transporteur].[ID] column
, @DateCalcul [datetime] = Null -- for [IndexationCalcule_Transporteur].[DateCalcul] column
, @ConsiderNull_DateCalcul bit = 0
, @TypeIndexation [char](1) = Null -- for [IndexationCalcule_Transporteur].[TypeIndexation] column
, @ConsiderNull_TypeIndexation bit = 0
, @IndexationID [int] = Null -- for [IndexationCalcule_Transporteur].[IndexationID] column
, @ConsiderNull_IndexationID bit = 0
, @IndexationDetailID [int] = Null -- for [IndexationCalcule_Transporteur].[IndexationDetailID] column
, @ConsiderNull_IndexationDetailID bit = 0
, @LivraisonID [int] = Null -- for [IndexationCalcule_Transporteur].[LivraisonID] column
, @ConsiderNull_LivraisonID bit = 0
, @TransporteurID [varchar](15) = Null -- for [IndexationCalcule_Transporteur].[TransporteurID] column
, @ConsiderNull_TransporteurID bit = 0
, @MontantDejaPaye [float] = Null -- for [IndexationCalcule_Transporteur].[MontantDejaPaye] column
, @ConsiderNull_MontantDejaPaye bit = 0
, @PourcentageDuMontant [float] = Null -- for [IndexationCalcule_Transporteur].[PourcentageDuMontant] column
, @ConsiderNull_PourcentageDuMontant bit = 0
, @Montant [float] = Null -- for [IndexationCalcule_Transporteur].[Montant] column
, @ConsiderNull_Montant bit = 0
, @Facture [bit] = Null -- for [IndexationCalcule_Transporteur].[Facture] column
, @ConsiderNull_Facture bit = 0
, @FactureID [int] = Null -- for [IndexationCalcule_Transporteur].[FactureID] column
, @ConsiderNull_FactureID bit = 0
, @ErreurCalcul [bit] = Null -- for [IndexationCalcule_Transporteur].[ErreurCalcul] column
, @ConsiderNull_ErreurCalcul bit = 0
, @ErreurDescription [varchar](300) = Null -- for [IndexationCalcule_Transporteur].[ErreurDescription] column
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

If @ConsiderNull_TransporteurID Is Null
	Set @ConsiderNull_TransporteurID = 0

If @ConsiderNull_MontantDejaPaye Is Null
	Set @ConsiderNull_MontantDejaPaye = 0

If @ConsiderNull_PourcentageDuMontant Is Null
	Set @ConsiderNull_PourcentageDuMontant = 0

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


Update [dbo].[IndexationCalcule_Transporteur]

Set
	 [DateCalcul] = Case @ConsiderNull_DateCalcul When 0 Then IsNull(@DateCalcul, [DateCalcul]) When 1 Then @DateCalcul End
	,[TypeIndexation] = Case @ConsiderNull_TypeIndexation When 0 Then IsNull(@TypeIndexation, [TypeIndexation]) When 1 Then @TypeIndexation End
	,[IndexationID] = Case @ConsiderNull_IndexationID When 0 Then IsNull(@IndexationID, [IndexationID]) When 1 Then @IndexationID End
	,[IndexationDetailID] = Case @ConsiderNull_IndexationDetailID When 0 Then IsNull(@IndexationDetailID, [IndexationDetailID]) When 1 Then @IndexationDetailID End
	,[LivraisonID] = Case @ConsiderNull_LivraisonID When 0 Then IsNull(@LivraisonID, [LivraisonID]) When 1 Then @LivraisonID End
	,[TransporteurID] = Case @ConsiderNull_TransporteurID When 0 Then IsNull(@TransporteurID, [TransporteurID]) When 1 Then @TransporteurID End
	,[MontantDejaPaye] = Case @ConsiderNull_MontantDejaPaye When 0 Then IsNull(@MontantDejaPaye, [MontantDejaPaye]) When 1 Then @MontantDejaPaye End
	,[PourcentageDuMontant] = Case @ConsiderNull_PourcentageDuMontant When 0 Then IsNull(@PourcentageDuMontant, [PourcentageDuMontant]) When 1 Then @PourcentageDuMontant End
	,[Montant] = Case @ConsiderNull_Montant When 0 Then IsNull(@Montant, [Montant]) When 1 Then @Montant End
	,[Facture] = Case @ConsiderNull_Facture When 0 Then IsNull(@Facture, [Facture]) When 1 Then @Facture End
	,[FactureID] = Case @ConsiderNull_FactureID When 0 Then IsNull(@FactureID, [FactureID]) When 1 Then @FactureID End
	,[ErreurCalcul] = Case @ConsiderNull_ErreurCalcul When 0 Then IsNull(@ErreurCalcul, [ErreurCalcul]) When 1 Then @ErreurCalcul End
	,[ErreurDescription] = Case @ConsiderNull_ErreurDescription When 0 Then IsNull(@ErreurDescription, [ErreurDescription]) When 1 Then @ErreurDescription End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


