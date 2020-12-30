

Create Procedure [spI_FactureClient_Details]

-- Inserts a new record in [FactureClient_Details] table
(
  @FactureID [int] -- for [FactureClient_Details].[FactureID] column
, @Ligne [int] -- for [FactureClient_Details].[Ligne] column
, @Compte [int] = Null  -- for [FactureClient_Details].[Compte] column
, @Montant [float] = Null  -- for [FactureClient_Details].[Montant] column
, @RefID [int] = Null  -- for [FactureClient_Details].[RefID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[FactureClient_Details]
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


