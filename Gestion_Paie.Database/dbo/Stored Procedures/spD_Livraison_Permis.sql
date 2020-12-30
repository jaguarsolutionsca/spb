

Create Procedure [spD_Livraison_Permis]

-- Delete a specific record from table [Livraison_Permis]

(
 @LivraisonID [int] -- for [Livraison_Permis].[LivraisonID] column
,@PermisID [int] -- for [Livraison_Permis].[PermisID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Livraison_Permis]

Where
    ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@PermisID Is Null) Or ([PermisID] = @PermisID))

Set NoCount Off

Return(@@RowCount)


