

Create Procedure [spI_jag_System]

-- Inserts a new record in [jag_System] table
(
  @Fournisseur_PlanConjoint [varchar](15) = Null  -- for [jag_System].[Fournisseur_PlanConjoint] column
, @Fournisseur_Surcharge [varchar](15) = Null  -- for [jag_System].[Fournisseur_Surcharge] column
, @Compte_Paiements [int] = Null  -- for [jag_System].[Compte_Paiements] column
, @Compte_ARecevoir [int] = Null  -- for [jag_System].[Compte_ARecevoir] column
, @Compte_APayer [int] = Null  -- for [jag_System].[Compte_APayer] column
, @Compte_DuAuxProducteurs [int] = Null  -- for [jag_System].[Compte_DuAuxProducteurs] column
, @Compte_TPSpercues [int] = Null  -- for [jag_System].[Compte_TPSpercues] column
, @Compte_TPSpayees [int] = Null  -- for [jag_System].[Compte_TPSpayees] column
, @Compte_TVQpercues [int] = Null  -- for [jag_System].[Compte_TVQpercues] column
, @Compte_TVQpayees [int] = Null  -- for [jag_System].[Compte_TVQpayees] column
, @Taux_TPS [float] = Null  -- for [jag_System].[Taux_TPS] column
, @Taux_TVQ [float] = Null  -- for [jag_System].[Taux_TVQ] column
, @Fournisseur_Fond_Roulement [varchar](15) = Null  -- for [jag_System].[Fournisseur_Fond_Roulement] column
, @Fournisseur_Fond_Forestier [varchar](15) = Null  -- for [jag_System].[Fournisseur_Fond_Forestier] column
, @Fournisseur_Preleve_Divers [varchar](15) = Null  -- for [jag_System].[Fournisseur_Preleve_Divers] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[jag_System]
(
	  [Fournisseur_PlanConjoint]
	, [Fournisseur_Surcharge]
	, [Compte_Paiements]
	, [Compte_ARecevoir]
	, [Compte_APayer]
	, [Compte_DuAuxProducteurs]
	, [Compte_TPSpercues]
	, [Compte_TPSpayees]
	, [Compte_TVQpercues]
	, [Compte_TVQpayees]
	, [Taux_TPS]
	, [Taux_TVQ]
	, [Fournisseur_Fond_Roulement]
	, [Fournisseur_Fond_Forestier]
	, [Fournisseur_Preleve_Divers]
)

Values
(
	  @Fournisseur_PlanConjoint
	, @Fournisseur_Surcharge
	, @Compte_Paiements
	, @Compte_ARecevoir
	, @Compte_APayer
	, @Compte_DuAuxProducteurs
	, @Compte_TPSpercues
	, @Compte_TPSpayees
	, @Compte_TVQpercues
	, @Compte_TVQpayees
	, @Taux_TPS
	, @Taux_TVQ
	, @Fournisseur_Fond_Roulement
	, @Fournisseur_Fond_Forestier
	, @Fournisseur_Preleve_Divers
)

Set NoCount Off

Return(0)


