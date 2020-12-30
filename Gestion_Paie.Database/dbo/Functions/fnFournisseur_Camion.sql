

Create Function [fnFournisseur_Camion]
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
Select TOP 100 PERCENT
 [FournisseurID]
,[VR]
,[MasseLimite]
,[Actif]

From [dbo].[Fournisseur_Camion]

Where

    ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))
And ((@VR Is Null) Or ([VR] = @VR))
)


