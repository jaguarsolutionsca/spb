

Create Procedure [spI_FactureFournisseur_Details]

-- Inserts a new record in [FactureFournisseur_Details] table
(
  @FactureID [int] -- for [FactureFournisseur_Details].[FactureID] column
, @Ligne [int] -- for [FactureFournisseur_Details].[Ligne] column
, @Compte [int] = Null  -- for [FactureFournisseur_Details].[Compte] column
, @Montant [float] = Null  -- for [FactureFournisseur_Details].[Montant] column
, @RefID [int] = Null  -- for [FactureFournisseur_Details].[RefID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[FactureFournisseur_Details]
(
	  [FactureID]
	, [Ligne]
	, [Compte]
	, [Montant]
	, [RefID]
)

Values
(
	  @FactureID
	, @Ligne
	, @Compte
	, @Montant
	, @RefID
)

Set NoCount Off

Return(0)


