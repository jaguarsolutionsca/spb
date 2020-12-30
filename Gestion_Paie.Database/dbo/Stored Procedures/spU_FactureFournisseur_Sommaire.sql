

Create Procedure [spU_FactureFournisseur_Sommaire]

-- Update an existing record in [FactureFournisseur_Sommaire] table

(
  @FactureID [int] -- for [FactureFournisseur_Sommaire].[FactureID] column
, @Ligne [int] -- for [FactureFournisseur_Sommaire].[Ligne] column
, @Compte [int] = Null -- for [FactureFournisseur_Sommaire].[Compte] column
, @ConsiderNull_Compte bit = 0
, @Montant [float] = Null -- for [FactureFournisseur_Sommaire].[Montant] column
, @ConsiderNull_Montant bit = 0
, @Description [varchar](90) = Null -- for [FactureFournisseur_Sommaire].[Description] column
, @ConsiderNull_Description bit = 0
, @isTaxe [bit] = Null -- for [FactureFournisseur_Sommaire].[isTaxe] column
, @ConsiderNull_isTaxe bit = 0
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

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0

If @ConsiderNull_isTaxe Is Null
	Set @ConsiderNull_isTaxe = 0


Update [dbo].[FactureFournisseur_Sommaire]

Set
	 [Compte] = Case @ConsiderNull_Compte When 0 Then IsNull(@Compte, [Compte]) When 1 Then @Compte End
	,[Montant] = Case @ConsiderNull_Montant When 0 Then IsNull(@Montant, [Montant]) When 1 Then @Montant End
	,[Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[isTaxe] = Case @ConsiderNull_isTaxe When 0 Then IsNull(@isTaxe, [isTaxe]) When 1 Then @isTaxe End

Where
	     ([FactureID] = @FactureID)
	And ([Ligne] = @Ligne)

Set NoCount Off

Return(0)


