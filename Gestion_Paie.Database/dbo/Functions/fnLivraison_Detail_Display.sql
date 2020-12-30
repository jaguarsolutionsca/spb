

Create Function [fnLivraison_Detail_Display]
(
 @ID [int] = Null
,@LivraisonID [int] = Null
,@ContratID [varchar](10) = Null
,@EssenceID [varchar](6) = Null
,@UniteMesureID [varchar](6) = Null
,@ProducteurID [varchar](15) = Null
,@ContingentementID [int] = Null
,@Code [char](4) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID] As [ID1]
,[ID] As [Display]
	
From [dbo].[Livraison_Detail]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@Code Is Null) Or ([Code] = @Code))

Order By [Display]
)


