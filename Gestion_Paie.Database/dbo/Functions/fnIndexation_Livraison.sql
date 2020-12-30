

Create Function [fnIndexation_Livraison]
(
 @IndexationID [int] = Null
,@LivraisonID [int] = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [IndexationID]
,[LivraisonID]

From [dbo].[Indexation_Livraison]

Where

    ((@IndexationID Is Null) Or ([IndexationID] = @IndexationID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
)


