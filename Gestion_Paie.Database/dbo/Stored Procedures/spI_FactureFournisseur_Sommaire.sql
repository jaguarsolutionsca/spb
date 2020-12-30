

Create Procedure [spI_FactureFournisseur_Sommaire]

-- Inserts a new record in [FactureFournisseur_Sommaire] table
(
  @FactureID [int] -- for [FactureFournisseur_Sommaire].[FactureID] column
, @Ligne [int] -- for [FactureFournisseur_Sommaire].[Ligne] column
, @Compte [int] = Null  -- for [FactureFournisseur_Sommaire].[Compte] column
, @Montant [float] = Null  -- for [FactureFournisseur_Sommaire].[Montant] column
, @Description [varchar](90) = Null  -- for [FactureFournisseur_Sommaire].[Description] column
, @isTaxe [bit] = Null  -- for [FactureFournisseur_Sommaire].[isTaxe] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[FactureFournisseur_Sommaire]
(
	  [FactureID]
	, [Ligne]
	, [Compte]
	, [Montant]
	, [Description]
	, [isTaxe]
)

Values
(
	  @FactureID
	, @Ligne
	, @Compte
	, @Montant
	, @Description
	, @isTaxe
)

Set NoCount Off

Return(0)


