

Create Procedure [spD_IndexationCalcule_Producteur]

-- Delete a specific record from table [IndexationCalcule_Producteur]

(
 @ID [int] -- for [IndexationCalcule_Producteur].[ID] column
,@TypeIndexation [char](1) = Null -- for [IndexationCalcule_Producteur].[TypeIndexation] column
,@IndexationID [int] = Null -- for [IndexationCalcule_Producteur].[IndexationID] column
,@IndexationDetailID [int] = Null -- for [IndexationCalcule_Producteur].[IndexationDetailID] column
,@LivraisonID [int] = Null -- for [IndexationCalcule_Producteur].[LivraisonID] column
,@LivraisonDetailID [int] = Null -- for [IndexationCalcule_Producteur].[LivraisonDetailID] column
,@ProducteurID [varchar](15) = Null -- for [IndexationCalcule_Producteur].[ProducteurID] column
,@ContratID [varchar](10) = Null -- for [IndexationCalcule_Producteur].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [IndexationCalcule_Producteur].[EssenceID] column
,@Code [char](4) = Null -- for [IndexationCalcule_Producteur].[Code] column
,@UniteID [varchar](6) = Null -- for [IndexationCalcule_Producteur].[UniteID] column
,@FactureID [int] = Null -- for [IndexationCalcule_Producteur].[FactureID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[IndexationCalcule_Producteur]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@TypeIndexation Is Null) Or ([TypeIndexation] = @TypeIndexation))
And ((@IndexationID Is Null) Or ([IndexationID] = @IndexationID))
And ((@IndexationDetailID Is Null) Or ([IndexationDetailID] = @IndexationDetailID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@LivraisonDetailID Is Null) Or ([LivraisonDetailID] = @LivraisonDetailID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@Code Is Null) Or ([Code] = @Code))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))

Set NoCount Off

Return(@@RowCount)


