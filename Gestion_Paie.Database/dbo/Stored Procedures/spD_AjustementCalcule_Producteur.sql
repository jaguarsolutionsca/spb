

Create Procedure [spD_AjustementCalcule_Producteur]

-- Delete a specific record from table [AjustementCalcule_Producteur]

(
 @ID [int] -- for [AjustementCalcule_Producteur].[ID] column
,@AjustementID [int] = Null -- for [AjustementCalcule_Producteur].[AjustementID] column
,@EssenceID [varchar](6) = Null -- for [AjustementCalcule_Producteur].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [AjustementCalcule_Producteur].[UniteID] column
,@LivraisonDetailID [int] = Null -- for [AjustementCalcule_Producteur].[LivraisonDetailID] column
,@ProducteurID [varchar](15) = Null -- for [AjustementCalcule_Producteur].[ProducteurID] column
,@FactureID [int] = Null -- for [AjustementCalcule_Producteur].[FactureID] column
,@Code [char](4) = Null -- for [AjustementCalcule_Producteur].[Code] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[AjustementCalcule_Producteur]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@LivraisonDetailID Is Null) Or ([LivraisonDetailID] = @LivraisonDetailID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Code Is Null) Or ([Code] = @Code))

Set NoCount Off

Return(@@RowCount)


