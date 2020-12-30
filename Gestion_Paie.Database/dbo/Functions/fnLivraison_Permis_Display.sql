

Create Function [fnLivraison_Permis_Display]
(
 @LivraisonID [int] = Null
,@PermisID [int] = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [LivraisonID] As [ID1]
,[PermisID] As [ID2]
,[PermisID] As [Display]
	
From [dbo].[Livraison_Permis]

Where
    ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@PermisID Is Null) Or ([PermisID] = @PermisID))

Order By [Display]
)


