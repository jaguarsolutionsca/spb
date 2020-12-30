CREATE FUNCTION [dbo].[fnIndexationCalcule_Transporteur_SelectDisplay]
(@ID INT=Null, @TypeIndexation CHAR (1)=Null, @IndexationID INT=Null, @IndexationDetailID INT=Null, @LivraisonID INT=Null, @TransporteurID VARCHAR (15)=Null, @FactureID INT=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [IndexationCalcule_Transporteur].[ID]
	,[IndexationCalcule_Transporteur].[DateCalcul]
	,[IndexationCalcule_Transporteur].[TypeIndexation]
	,[TypeIndexation1].[Display] [TypeIndexation_Display]
	,[IndexationCalcule_Transporteur].[IndexationID]
	,[Indexation2].[Display] [IndexationID_Display]
	,[IndexationCalcule_Transporteur].[IndexationDetailID]
	,[Indexation_Municipalite3].[Display] [IndexationDetailID_Display]
	,[IndexationCalcule_Transporteur].[LivraisonID]
	,[Livraison4].[Display] [LivraisonID_Display]
	,[IndexationCalcule_Transporteur].[TransporteurID]
	,[Fournisseur5].[Display] [TransporteurID_Display]
	,[IndexationCalcule_Transporteur].[MontantDejaPaye]
	,[IndexationCalcule_Transporteur].[PourcentageDuMontant]
	,[IndexationCalcule_Transporteur].[Montant]
	,[IndexationCalcule_Transporteur].[Facture]
	,[IndexationCalcule_Transporteur].[FactureID]
	,[FactureFournisseur6].[Display] [FactureID_Display]
	,[IndexationCalcule_Transporteur].[ErreurCalcul]
	,[IndexationCalcule_Transporteur].[ErreurDescription]

From [dbo].[IndexationCalcule_Transporteur]
    Left Outer Join [fnTypeIndexation_Display](Null) [TypeIndexation1] On [TypeIndexation] = [TypeIndexation1].[ID1]
        Left Outer Join [fnIndexation_Display](Null, Null, Null) [Indexation2] On [IndexationID] = [Indexation2].[ID1]
            Left Outer Join [fnIndexation_Municipalite_Display](Null, Null, Null, Null) [Indexation_Municipalite3] On [IndexationDetailID] = [Indexation_Municipalite3].[ID1]
                Left Outer Join [fnLivraison_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Livraison4] On [LivraisonID] = [Livraison4].[ID1]
                    Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur5] On [TransporteurID] = [Fournisseur5].[ID1]
                        Left Outer Join [fnFactureFournisseur_Display](Null, Null, Null, Null, Null, Null) [FactureFournisseur6] On [FactureID] = [FactureFournisseur6].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@TypeIndexation Is Null) Or ([TypeIndexation] = @TypeIndexation))
And ((@IndexationID Is Null) Or ([IndexationID] = @IndexationID))
And ((@IndexationDetailID Is Null) Or ([IndexationDetailID] = @IndexationDetailID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))
)



