

Create Function [fnLivraison_Permis]
(
 @LivraisonID [int] = Null
,@PermisID [int] = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [LivraisonID]
,[PermisID]
,[NumeroFactureUsine]

From [dbo].[Livraison_Permis]

Where

    ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@PermisID Is Null) Or ([PermisID] = @PermisID))
)


