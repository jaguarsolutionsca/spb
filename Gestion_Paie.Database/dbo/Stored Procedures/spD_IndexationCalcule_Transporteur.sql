

Create Procedure [spD_IndexationCalcule_Transporteur]

-- Delete a specific record from table [IndexationCalcule_Transporteur]

(
 @ID [int] -- for [IndexationCalcule_Transporteur].[ID] column
,@TypeIndexation [char](1) = Null -- for [IndexationCalcule_Transporteur].[TypeIndexation] column
,@IndexationID [int] = Null -- for [IndexationCalcule_Transporteur].[IndexationID] column
,@IndexationDetailID [int] = Null -- for [IndexationCalcule_Transporteur].[IndexationDetailID] column
,@LivraisonID [int] = Null -- for [IndexationCalcule_Transporteur].[LivraisonID] column
,@TransporteurID [varchar](15) = Null -- for [IndexationCalcule_Transporteur].[TransporteurID] column
,@FactureID [int] = Null -- for [IndexationCalcule_Transporteur].[FactureID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[IndexationCalcule_Transporteur]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@TypeIndexation Is Null) Or ([TypeIndexation] = @TypeIndexation))
And ((@IndexationID Is Null) Or ([IndexationID] = @IndexationID))
And ((@IndexationDetailID Is Null) Or ([IndexationDetailID] = @IndexationDetailID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))

Set NoCount Off

Return(@@RowCount)


