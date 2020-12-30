

Create Procedure [spD_AjustementCalcule_Usine]

-- Delete a specific record from table [AjustementCalcule_Usine]

(
 @ID [int] -- for [AjustementCalcule_Usine].[ID] column
,@AjustementID [int] = Null -- for [AjustementCalcule_Usine].[AjustementID] column
,@EssenceID [varchar](6) = Null -- for [AjustementCalcule_Usine].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [AjustementCalcule_Usine].[UniteID] column
,@LivraisonDetailID [int] = Null -- for [AjustementCalcule_Usine].[LivraisonDetailID] column
,@UsineID [varchar](6) = Null -- for [AjustementCalcule_Usine].[UsineID] column
,@FactureID [int] = Null -- for [AjustementCalcule_Usine].[FactureID] column
,@Code [char](4) = Null -- for [AjustementCalcule_Usine].[Code] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[AjustementCalcule_Usine]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@LivraisonDetailID Is Null) Or ([LivraisonDetailID] = @LivraisonDetailID))
And ((@UsineID Is Null) Or ([UsineID] = @UsineID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Code Is Null) Or ([Code] = @Code))

Set NoCount Off

Return(@@RowCount)


