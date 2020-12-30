
CREATE Function [fnContingentement_Demande_SelectDisplay]
(
 @ID [int] = Null
,@ProducteurID [varchar](15) = Null
,@TransporteurID [varchar](15) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [Contingentement_Demande].[ID]
	,[Contingentement_Demande].[Annee]
	,[Contingentement_Demande].[ProducteurID]
	,[Fournisseur1].[Display] [ProducteurID_Display]
	,[Contingentement_Demande].[TransporteurID]
	,[Fournisseur2].[Display] [TransporteurID_Display]
	,[Contingentement_Demande].[Superficie_Boisee]
	,[Contingentement_Demande].[Remarques]
	,[Contingentement_Demande].[DateModification]

From [dbo].[Contingentement_Demande]
    Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur1] On [ProducteurID] = [Fournisseur1].[ID1]
        Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur2] On [TransporteurID] = [Fournisseur2].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
)

