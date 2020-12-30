

Create Function [fnAjustementCalcule_Producteur]
(
 @ID [int] = Null
,@AjustementID [int] = Null
,@EssenceID [varchar](6) = Null
,@UniteID [varchar](6) = Null
,@LivraisonDetailID [int] = Null
,@ProducteurID [varchar](15) = Null
,@FactureID [int] = Null
,@Code [char](4) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID]
,[DateCalcul]
,[AjustementID]
,[EssenceID]
,[UniteID]
,[LivraisonDetailID]
,[ProducteurID]
,[Volume]
,[Taux]
,[Montant]
,[Facture]
,[FactureID]
,[ErreurCalcul]
,[ErreurDescription]
,[Code]

From [dbo].[AjustementCalcule_Producteur]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@LivraisonDetailID Is Null) Or ([LivraisonDetailID] = @LivraisonDetailID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Code Is Null) Or ([Code] = @Code))
)


