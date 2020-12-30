

Create Procedure [spD_Indexation_Livraison]

-- Delete a specific record from table [Indexation_Livraison]

(
 @IndexationID [int] -- for [Indexation_Livraison].[IndexationID] column
,@LivraisonID [int] -- for [Indexation_Livraison].[LivraisonID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Indexation_Livraison]

Where
    ((@IndexationID Is Null) Or ([IndexationID] = @IndexationID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))

Set NoCount Off

Return(@@RowCount)


