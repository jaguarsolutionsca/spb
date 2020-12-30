CREATE FUNCTION [dbo].[fnLivraison_Permis_SelectDisplay]
(@LivraisonID INT=Null, @PermisID INT=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [Livraison_Permis].[LivraisonID]
	,[Livraison1].[Display] [LivraisonID_Display]
	,[Livraison_Permis].[PermisID]
	,[Permit2].[Display] [PermisID_Display]
	,[Livraison_Permis].[NumeroFactureUsine]

From [dbo].[Livraison_Permis]
    Inner Join [fnLivraison_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Livraison1] On [LivraisonID] = [Livraison1].[ID1]
        Inner Join [fnPermit_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Permit2] On [PermisID] = [Permit2].[ID1]

Where

    ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@PermisID Is Null) Or ([PermisID] = @PermisID))
)



