

Create Procedure [spS_Fournisseur_Camion_Display]

(
 @FournisseurID [varchar](15) = Null -- for [Fournisseur_Camion].[FournisseurID] column
,@VR [varchar](10) = Null -- for [Fournisseur_Camion].[VR] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Fournisseur_Camion_Records].[ID1]
,[Fournisseur_Camion_Records].[ID2]
,[Fournisseur_Camion_Records].[Display]

From [fnFournisseur_Camion_Display](@FournisseurID, @VR) As [Fournisseur_Camion_Records]

Return(@@RowCount)


