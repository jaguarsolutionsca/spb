

Create Procedure [spS_Indexation_Livraison_Display]

(
 @IndexationID [int] = Null -- for [Indexation_Livraison].[IndexationID] column
,@LivraisonID [int] = Null -- for [Indexation_Livraison].[LivraisonID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Indexation_Livraison_Records].[ID1]
,[Indexation_Livraison_Records].[ID2]
,[Indexation_Livraison_Records].[Display]

From [fnIndexation_Livraison_Display](@IndexationID, @LivraisonID) As [Indexation_Livraison_Records]

Return(@@RowCount)


