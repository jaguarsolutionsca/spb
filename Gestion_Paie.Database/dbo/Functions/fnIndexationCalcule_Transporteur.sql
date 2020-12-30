

Create Function [fnIndexationCalcule_Transporteur]
(
 @ID [int] = Null
,@TypeIndexation [char](1) = Null
,@IndexationID [int] = Null
,@IndexationDetailID [int] = Null
,@LivraisonID [int] = Null
,@TransporteurID [varchar](15) = Null
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
,[TransporteurID]
,[MontantDejaPaye]
,[PourcentageDuMontant]
,[Montant]
,[Facture]
,[FactureID]
,[ErreurCalcul]
,[ErreurDescription]

From [dbo].[IndexationCalcule_Transporteur]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@TypeIndexation Is Null) Or ([TypeIndexation] = @TypeIndexation))
And ((@IndexationID Is Null) Or ([IndexationID] = @IndexationID))
And ((@IndexationDetailID Is Null) Or ([IndexationDetailID] = @IndexationDetailID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))
)


