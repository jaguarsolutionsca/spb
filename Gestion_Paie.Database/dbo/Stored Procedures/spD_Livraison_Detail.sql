

Create Procedure [spD_Livraison_Detail]

-- Delete a specific record from table [Livraison_Detail]

(
 @ID [int] -- for [Livraison_Detail].[ID] column
,@LivraisonID [int] = Null -- for [Livraison_Detail].[LivraisonID] column
,@ContratID [varchar](10) = Null -- for [Livraison_Detail].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [Livraison_Detail].[EssenceID] column
,@UniteMesureID [varchar](6) = Null -- for [Livraison_Detail].[UniteMesureID] column
,@ProducteurID [varchar](15) = Null -- for [Livraison_Detail].[ProducteurID] column
,@ContingentementID [int] = Null -- for [Livraison_Detail].[ContingentementID] column
,@Code [char](4) = Null -- for [Livraison_Detail].[Code] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Livraison_Detail]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@Code Is Null) Or ([Code] = @Code))

Set NoCount Off

Return(@@RowCount)


