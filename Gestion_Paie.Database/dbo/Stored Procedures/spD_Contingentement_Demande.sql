
CREATE Procedure [spD_Contingentement_Demande]

-- Delete a specific record from table [Contingentement_Demande]

(
 @ID [int] -- for [Contingentement_Demande].[ID] column
,@ProducteurID [varchar](15) = Null -- for [Contingentement_Demande].[ProducteurID] column
,@TransporteurID [varchar](15) = Null -- for [Contingentement_Demande].[TransporteurID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Contingentement_Demande]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))

Set NoCount Off

Return(@@RowCount)

