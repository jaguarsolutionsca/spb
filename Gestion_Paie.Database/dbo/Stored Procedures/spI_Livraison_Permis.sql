

Create Procedure [spI_Livraison_Permis]

-- Inserts a new record in [Livraison_Permis] table
(
  @LivraisonID [int] -- for [Livraison_Permis].[LivraisonID] column
, @PermisID [int] -- for [Livraison_Permis].[PermisID] column
, @NumeroFactureUsine [varchar](25) = Null  -- for [Livraison_Permis].[NumeroFactureUsine] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Livraison_Permis]
(
	  [LivraisonID]
	, [PermisID]
	, [NumeroFactureUsine]
)

Values
(
	  @LivraisonID
	, @PermisID
	, @NumeroFactureUsine
)

Set NoCount Off

Return(0)


