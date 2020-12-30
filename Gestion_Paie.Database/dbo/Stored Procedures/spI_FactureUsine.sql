

Create Procedure [spI_FactureUsine]

-- Inserts a new record in [FactureUsine] table
(
  @ID [int] -- for [FactureUsine].[ID] column
, @DatePermis [smalldatetime] = Null  -- for [FactureUsine].[DatePermis] column
, @DateLivraison [smalldatetime] = Null  -- for [FactureUsine].[DateLivraison] column
, @DatePaye [smalldatetime] = Null  -- for [FactureUsine].[DatePaye] column
, @Annee [int] = Null  -- for [FactureUsine].[Annee] column
, @Periode [int] = Null  -- for [FactureUsine].[Periode] column
, @ContratID [varchar](10) = Null  -- for [FactureUsine].[ContratID] column
, @Sciage [bit] = Null  -- for [FactureUsine].[Sciage] column
, @EssenceSciage [varchar](25) = Null  -- for [FactureUsine].[EssenceSciage] column
, @NumeroFactureUsine [varchar](25) = Null  -- for [FactureUsine].[NumeroFactureUsine] column
, @ProducteurID [varchar](15) = Null  -- for [FactureUsine].[ProducteurID] column
, @Livraison [bit] = Null  -- for [FactureUsine].[Livraison] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[FactureUsine]
(
	  [ID]
	, [DatePermis]
	, [DateLivraison]
	, [DatePaye]
	, [Annee]
	, [Periode]
	, [ContratID]
	, [Sciage]
	, [EssenceSciage]
	, [NumeroFactureUsine]
	, [ProducteurID]
	, [Livraison]
)

Values
(
	  @ID
	, @DatePermis
	, @DateLivraison
	, @DatePaye
	, @Annee
	, @Periode
	, @ContratID
	, @Sciage
	, @EssenceSciage
	, @NumeroFactureUsine
	, @ProducteurID
	, @Livraison
)

Set NoCount Off

Return(0)


