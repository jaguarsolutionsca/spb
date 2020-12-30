

Create Procedure [spU_Livraison_Permis]

-- Update an existing record in [Livraison_Permis] table

(
  @LivraisonID [int] -- for [Livraison_Permis].[LivraisonID] column
, @PermisID [int] -- for [Livraison_Permis].[PermisID] column
, @NumeroFactureUsine [varchar](25) = Null -- for [Livraison_Permis].[NumeroFactureUsine] column
, @ConsiderNull_NumeroFactureUsine bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_NumeroFactureUsine Is Null
	Set @ConsiderNull_NumeroFactureUsine = 0


Update [dbo].[Livraison_Permis]

Set
	 [NumeroFactureUsine] = Case @ConsiderNull_NumeroFactureUsine When 0 Then IsNull(@NumeroFactureUsine, [NumeroFactureUsine]) When 1 Then @NumeroFactureUsine End

Where
	     ([LivraisonID] = @LivraisonID)
	And ([PermisID] = @PermisID)

Set NoCount Off

Return(0)


