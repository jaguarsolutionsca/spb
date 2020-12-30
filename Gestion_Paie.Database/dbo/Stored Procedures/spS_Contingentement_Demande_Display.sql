
Create Procedure [spS_Contingentement_Demande_Display]

(
 @ID [int] = Null -- for [Contingentement_Demande].[ID] column
,@ProducteurID [varchar](15) = Null -- for [Contingentement_Demande].[ProducteurID] column
,@TransporteurID [varchar](15) = Null -- for [Contingentement_Demande].[TransporteurID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Contingentement_Demande_Records].[ID1]
,[Contingentement_Demande_Records].[Display]

From [fnContingentement_Demande_Display](@ID, @ProducteurID, @TransporteurID) As [Contingentement_Demande_Records]

Return(@@RowCount)

