

Create Procedure [spD_Fournisseur_Camion]

-- Delete a specific record from table [Fournisseur_Camion]

(
 @FournisseurID [varchar](15) -- for [Fournisseur_Camion].[FournisseurID] column
,@VR [varchar](10) -- for [Fournisseur_Camion].[VR] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Fournisseur_Camion]

Where
    ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))
And ((@VR Is Null) Or ([VR] = @VR))

Set NoCount Off

Return(@@RowCount)


