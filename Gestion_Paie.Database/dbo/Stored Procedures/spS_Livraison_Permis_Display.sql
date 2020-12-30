

Create Procedure [spS_Livraison_Permis_Display]

(
 @LivraisonID [int] = Null -- for [Livraison_Permis].[LivraisonID] column
,@PermisID [int] = Null -- for [Livraison_Permis].[PermisID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Livraison_Permis_Records].[ID1]
,[Livraison_Permis_Records].[ID2]
,[Livraison_Permis_Records].[Display]

From [fnLivraison_Permis_Display](@LivraisonID, @PermisID) As [Livraison_Permis_Records]

Return(@@RowCount)


