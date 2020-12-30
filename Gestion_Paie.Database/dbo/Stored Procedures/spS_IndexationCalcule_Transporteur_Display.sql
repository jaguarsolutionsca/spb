

Create Procedure [spS_IndexationCalcule_Transporteur_Display]

(
 @ID [int] = Null -- for [IndexationCalcule_Transporteur].[ID] column
,@TypeIndexation [char](1) = Null -- for [IndexationCalcule_Transporteur].[TypeIndexation] column
,@IndexationID [int] = Null -- for [IndexationCalcule_Transporteur].[IndexationID] column
,@IndexationDetailID [int] = Null -- for [IndexationCalcule_Transporteur].[IndexationDetailID] column
,@LivraisonID [int] = Null -- for [IndexationCalcule_Transporteur].[LivraisonID] column
,@TransporteurID [varchar](15) = Null -- for [IndexationCalcule_Transporteur].[TransporteurID] column
,@FactureID [int] = Null -- for [IndexationCalcule_Transporteur].[FactureID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [IndexationCalcule_Transporteur_Records].[ID1]
,[IndexationCalcule_Transporteur_Records].[Display]

From [fnIndexationCalcule_Transporteur_Display](@ID, @TypeIndexation, @IndexationID, @IndexationDetailID, @LivraisonID, @TransporteurID, @FactureID) As [IndexationCalcule_Transporteur_Records]

Return(@@RowCount)


