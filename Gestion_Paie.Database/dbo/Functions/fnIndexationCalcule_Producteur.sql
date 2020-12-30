

Create Function [fnIndexationCalcule_Producteur]
(
 @ID [int] = Null
,@TypeIndexation [char](1) = Null
,@IndexationID [int] = Null
,@IndexationDetailID [int] = Null
,@LivraisonID [int] = Null
,@LivraisonDetailID [int] = Null
,@ProducteurID [varchar](15) = Null
,@ContratID [varchar](10) = Null
,@EssenceID [varchar](6) = Null
,@Code [char](4) = Null
,@UniteID [varchar](6) = Null
,@FactureID [int] = Null
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
,[TypeIndexation]
,[IndexationID]
,[IndexationDetailID]
,[LivraisonID]
,[LivraisonDetailID]
,[ProducteurID]
,[ContratID]
,[EssenceID]
,[Code]
,[UniteID]
,[Volume]
,[MontantDejaPaye]
,[PourcentageDuMontant]
,[Taux]
,[Montant]
,[Facture]
,[FactureID]
,[ErreurCalcul]
,[ErreurDescription]

From [dbo].[IndexationCalcule_Producteur]

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
)


