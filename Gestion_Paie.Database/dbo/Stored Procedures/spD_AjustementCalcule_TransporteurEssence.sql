CREATE Procedure [dbo].[spD_AjustementCalcule_TransporteurEssence]

-- Delete a specific record from table [AjustementCalcule_TransporteurEssence]

(
 @ID [int] -- for [AjustementCalcule_TransporteurEssence].[ID] column
,@AjustementID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[AjustementID] column
,@EssenceID [varchar](6) = Null -- for [AjustementCalcule_TransporteurEssence].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [AjustementCalcule_TransporteurEssence].[UniteID] column
,@LivraisonDetailID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[LivraisonDetailID] column
,@TransporteurID [varchar](15) = Null -- for [AjustementCalcule_TransporteurEssence].[TransporteurID] column
,@FactureID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[FactureID] column
,@Code [char](4) = Null -- for [AjustementCalcule_TransporteurEssence].[Code] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[AjustementCalcule_TransporteurEssence]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@LivraisonDetailID Is Null) Or ([LivraisonDetailID] = @LivraisonDetailID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Code Is Null) Or ([Code] = @Code))

Set NoCount Off

Return(@@RowCount)
