CREATE FUNCTION [dbo].[fnLivraison_Detail_SelectDisplay]
(@ID INT=Null, @LivraisonID INT=Null, @ContratID VARCHAR (10)=Null, @EssenceID VARCHAR (6)=Null, @UniteMesureID VARCHAR (6)=Null, @ProducteurID VARCHAR (15)=Null, @ContingentementID INT=Null, @Code CHAR (4)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [Livraison_Detail].[ID]
	,[Livraison_Detail].[LivraisonID]
	,[Livraison1].[Display] [LivraisonID_Display]
	,[Livraison_Detail].[ContratID]
	,[Contrat_EssenceUnite2].[Display] [ContratID_Display]
	,[Livraison_Detail].[EssenceID]
	,[Contrat_EssenceUnite3].[Display] [EssenceID_Display]
	,[Livraison_Detail].[UniteMesureID]
	,[Contrat_EssenceUnite4].[Display] [UniteMesureID_Display]
	,[Livraison_Detail].[ProducteurID]
	,[Fournisseur5].[Display] [ProducteurID_Display]
	,[Livraison_Detail].[Droit_Coupe]
	,[Livraison_Detail].[VolumeBrut]
	,[Livraison_Detail].[VolumeReduction]
	,[Livraison_Detail].[VolumeNet]
	,[Livraison_Detail].[VolumeContingente]
	,[Livraison_Detail].[ContingentementID]
	,[Contingentement6].[Display] [ContingentementID_Display]
	,[Livraison_Detail].[DateCalcul]
	,[Livraison_Detail].[Taux_Usine]
	,[Livraison_Detail].[Montant_Usine]
	,[Livraison_Detail].[Taux_Producteur]
	,[Livraison_Detail].[Montant_ProducteurBrut]
	,[Livraison_Detail].[Taux_TransporteurMoyen]
	,[Livraison_Detail].[Taux_TransporteurMoyen_Override]
	,[Livraison_Detail].[Montant_TransporteurMoyen]
	,[Livraison_Detail].[Taux_Preleve_Plan_Conjoint]
	,[Livraison_Detail].[Montant_Preleve_Plan_Conjoint]
	,[Livraison_Detail].[Taux_Preleve_Fond_Roulement]
	,[Livraison_Detail].[Montant_Preleve_Fond_Roulement]
	,[Livraison_Detail].[Taux_Preleve_Fond_Forestier]
	,[Livraison_Detail].[Montant_Preleve_Fond_Forestier]
	,[Livraison_Detail].[Taux_Preleve_Divers]
	,[Livraison_Detail].[Montant_Preleve_Divers]
	,[Livraison_Detail].[Montant_ProducteurNet]
	,[Livraison_Detail].[Taux_Producteur_Override]
	,[Livraison_Detail].[Taux_Usine_Override]
	,[Livraison_Detail].[Code]
	,[Contrat_EssenceUnite7].[Display] [Code_Display]
	,[Livraison_Detail].[UsePreleveMontant]

From [dbo].[Livraison_Detail]
    Inner Join [fnLivraison_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Livraison1] On [LivraisonID] = [Livraison1].[ID1]
        Inner Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite2] On [ContratID] = [Contrat_EssenceUnite2].[ID1]
            Inner Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite3] On [EssenceID] = [Contrat_EssenceUnite3].[ID2]
                Inner Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite4] On [UniteMesureID] = [Contrat_EssenceUnite4].[ID3]
                    Inner Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur5] On [ProducteurID] = [Fournisseur5].[ID1]
                        Left Outer Join [fnContingentement_Display](Null, Null, Null, Null, Null) [Contingentement6] On [ContingentementID] = [Contingentement6].[ID1]
                            Left Outer Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite7] On [Code] = [Contrat_EssenceUnite7].[ID4]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@Code Is Null) Or ([Code] = @Code))
)



