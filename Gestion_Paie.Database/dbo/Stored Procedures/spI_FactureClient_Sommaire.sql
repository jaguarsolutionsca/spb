

Create Procedure [spI_FactureClient_Sommaire]

-- Inserts a new record in [FactureClient_Sommaire] table
(
  @FactureID [int] -- for [FactureClient_Sommaire].[FactureID] column
, @Ligne [int] -- for [FactureClient_Sommaire].[Ligne] column
, @Compte [int] = Null  -- for [FactureClient_Sommaire].[Compte] column
, @Montant [float] = Null  -- for [FactureClient_Sommaire].[Montant] column
, @Description [varchar](90) = Null  -- for [FactureClient_Sommaire].[Description] column
, @isTaxe [bit] = Null  -- for [FactureClient_Sommaire].[isTaxe] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[FactureClient_Sommaire]
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


