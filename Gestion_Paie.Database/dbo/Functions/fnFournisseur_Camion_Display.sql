

Create Function [fnFournisseur_Camion_Display]
(
 @FournisseurID [varchar](15) = Null
,@VR [varchar](10) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [FournisseurID] As [ID1]
,[VR] As [ID2]
,[VR] As [Display]
	
From [dbo].[Fournisseur_Camion]

Where
    ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))
And ((@VR Is Null) Or ([VR] = @VR))

Order By [Display]
)


