CREATE FUNCTION [dbo].[fnIndexationCalcule_Producteur_SelectDisplay]
(@ID INT=Null, @TypeIndexation CHAR (1)=Null, @IndexationID INT=Null, @IndexationDetailID INT=Null, @LivraisonID INT=Null, @LivraisonDetailID INT=Null, @ProducteurID VARCHAR (15)=Null, @ContratID VARCHAR (10)=Null, @EssenceID VARCHAR (6)=Null, @Code CHAR (4)=Null, @UniteID VARCHAR (6)=Null, @FactureID INT=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [IndexationCalcule_Producteur].[ID]
	,[IndexationCalcule_Producteur].[DateCalcul]
	,[IndexationCalcule_Producteur].[TypeIndexation]
	,[TypeIndexation1].[Display] [TypeIndexation_Display]
	,[IndexationCalcule_Producteur].[IndexationID]
	,[Indexation2].[Display] [IndexationID_Display]
	,[IndexationCalcule_Producteur].[IndexationDetailID]
	,[Indexation_EssenceUnite3].[Display] [IndexationDetailID_Display]
	,[IndexationCalcule_Producteur].[LivraisonID]
	,[Livraison4].[Display] [LivraisonID_Display]
	,[IndexationCalcule_Producteur].[LivraisonDetailID]
	,[Livraison_Detail5].[Display] [LivraisonDetailID_Display]
	,[IndexationCalcule_Producteur].[ProducteurID]
	,[Fournisseur6].[Display] [ProducteurID_Display]
	,[IndexationCalcule_Producteur].[ContratID]
	,[Contrat_EssenceUnite7].[Display] [ContratID_Display]
	,[IndexationCalcule_Producteur].[EssenceID]
	,[Contrat_EssenceUnite8].[Display] [EssenceID_Display]
	,[IndexationCalcule_Producteur].[Code]
	,[Contrat_EssenceUnite9].[Display] [Code_Display]
	,[IndexationCalcule_Producteur].[UniteID]
	,[Contrat_EssenceUnite10].[Display] [UniteID_Display]
	,[IndexationCalcule_Producteur].[Volume]
	,[IndexationCalcule_Producteur].[MontantDejaPaye]
	,[IndexationCalcule_Producteur].[PourcentageDuMontant]
	,[IndexationCalcule_Producteur].[Taux]
	,[IndexationCalcule_Producteur].[Montant]
	,[IndexationCalcule_Producteur].[Facture]
	,[IndexationCalcule_Producteur].[FactureID]
	,[FactureFournisseur11].[Display] [FactureID_Display]
	,[IndexationCalcule_Producteur].[ErreurCalcul]
	,[IndexationCalcule_Producteur].[ErreurDescription]

From [dbo].[IndexationCalcule_Producteur]
    Left Outer Join [fnTypeIndexation_Display](Null) [TypeIndexation1] On [TypeIndexation] = [TypeIndexation1].[ID1]
        Left Outer Join [fnIndexation_Display](Null, Null, Null) [Indexation2] On [IndexationID] = [Indexation2].[ID1]
            Left Outer Join [fnIndexation_EssenceUnite_Display](Null, Null, Null, Null, Null, Null) [Indexation_EssenceUnite3] On [IndexationDetailID] = [Indexation_EssenceUnite3].[ID1]
                Left Outer Join [fnLivraison_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Livraison4] On [LivraisonID] = [Livraison4].[ID1]
                    Left Outer Join [fnLivraison_Detail_Display](Null, Null, Null, Null, Null, Null, Null, Null) [Livraison_Detail5] On [LivraisonDetailID] = [Livraison_Detail5].[ID1]
                        Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur6] On [ProducteurID] = [Fournisseur6].[ID1]
                            Left Outer Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite7] On [ContratID] = [Contrat_EssenceUnite7].[ID1]
                                Left Outer Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite8] On [EssenceID] = [Contrat_EssenceUnite8].[ID2]
                                    Left Outer Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite9] On [Code] = [Contrat_EssenceUnite9].[ID4]
                                        Left Outer Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite10] On [UniteID] = [Contrat_EssenceUnite10].[ID3]
                                            Left Outer Join [fnFactureFournisseur_Display](Null, Null, Null, Null, Null, Null) [FactureFournisseur11] On [FactureID] = [FactureFournisseur11].[ID1]

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



