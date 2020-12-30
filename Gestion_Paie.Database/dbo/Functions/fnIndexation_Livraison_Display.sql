

Create Function [fnIndexation_Livraison_Display]
(
 @IndexationID [int] = Null
,@LivraisonID [int] = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [IndexationID] As [ID1]
,[LivraisonID] As [ID2]
,[LivraisonID] As [Display]
	
From [dbo].[Indexation_Livraison]

Where
    ((@IndexationID Is Null) Or ([IndexationID] = @IndexationID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))

Order By [Display]
)


