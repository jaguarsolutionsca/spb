

Create Function [fnFournisseur_Camion_SelectDisplay]
(
 @FournisseurID [varchar](15) = Null
,@VR [varchar](10) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [Fournisseur_Camion].[FournisseurID]
	,[Fournisseur1].[Display] [FournisseurID_Display]
	,[Fournisseur_Camion].[VR]
	,[Fournisseur_Camion].[MasseLimite]
	,[Fournisseur_Camion].[Actif]

From [dbo].[Fournisseur_Camion]
    Inner Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur1] On [FournisseurID] = [Fournisseur1].[ID1]

Where

    ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))
And ((@VR Is Null) Or ([VR] = @VR))
)


