

Create Procedure [spU_FactureFournisseur_Details]

-- Update an existing record in [FactureFournisseur_Details] table

(
  @FactureID [int] -- for [FactureFournisseur_Details].[FactureID] column
, @Ligne [int] -- for [FactureFournisseur_Details].[Ligne] column
, @Compte [int] = Null -- for [FactureFournisseur_Details].[Compte] column
, @ConsiderNull_Compte bit = 0
, @Montant [float] = Null -- for [FactureFournisseur_Details].[Montant] column
, @ConsiderNull_Montant bit = 0
, @RefID [int] = Null -- for [FactureFournisseur_Details].[RefID] column
, @ConsiderNull_RefID bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Compte Is Null
	Set @ConsiderNull_Compte = 0

If @ConsiderNull_Montant Is Null
	Set @ConsiderNull_Montant = 0

If @ConsiderNull_RefID Is Null
	Set @ConsiderNull_RefID = 0


Update [dbo].[FactureFournisseur_Details]

Set
	 [Compte] = Case @ConsiderNull_Compte When 0 Then IsNull(@Compte, [Compte]) When 1 Then @Compte End
	,[Montant] = Case @ConsiderNull_Montant When 0 Then IsNull(@Montant, [Montant]) When 1 Then @Montant End
	,[RefID] = Case @ConsiderNull_RefID When 0 Then IsNull(@RefID, [RefID]) When 1 Then @RefID End

Where
	     ([FactureID] = @FactureID)
	And ([Ligne] = @Ligne)

Set NoCount Off

Return(0)


