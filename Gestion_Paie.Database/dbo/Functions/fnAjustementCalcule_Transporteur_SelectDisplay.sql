CREATE FUNCTION [dbo].[fnAjustementCalcule_Transporteur_SelectDisplay]
(@ID INT=Null, @AjustementID INT=Null, @UniteID VARCHAR (6)=Null, @MunicipaliteID VARCHAR (6)=Null, @LivraisonID INT=Null, @TransporteurID VARCHAR (15)=Null, @FactureID INT=Null, @ZoneID VARCHAR (2)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [AjustementCalcule_Transporteur].[ID]
	,[AjustementCalcule_Transporteur].[DateCalcul]
	,[AjustementCalcule_Transporteur].[AjustementID]
	,[Ajustement_Transporteur1].[Display] [AjustementID_Display]
	,[AjustementCalcule_Transporteur].[UniteID]
	,[Ajustement_Transporteur2].[Display] [UniteID_Display]
	,[AjustementCalcule_Transporteur].[MunicipaliteID]
	,[Ajustement_Transporteur3].[Display] [MunicipaliteID_Display]
	,[AjustementCalcule_Transporteur].[LivraisonID]
	,[Livraison4].[Display] [LivraisonID_Display]
	,[AjustementCalcule_Transporteur].[TransporteurID]
	,[Fournisseur5].[Display] [TransporteurID_Display]
	,[AjustementCalcule_Transporteur].[Volume]
	,[AjustementCalcule_Transporteur].[Taux]
	,[AjustementCalcule_Transporteur].[Montant]
	,[AjustementCalcule_Transporteur].[Facture]
	,[AjustementCalcule_Transporteur].[FactureID]
	,[FactureFournisseur6].[Display] [FactureID_Display]
	,[AjustementCalcule_Transporteur].[ErreurCalcul]
	,[AjustementCalcule_Transporteur].[ErreurDescription]
	,[AjustementCalcule_Transporteur].[ZoneID]
	,[Ajustement_Transporteur7].[Display] [ZoneID_Display]

From [dbo].[AjustementCalcule_Transporteur]
    Left Outer Join [fnAjustement_Transporteur_Display](Null, Null, Null, Null, Null) [Ajustement_Transporteur1] On [AjustementID] = [Ajustement_Transporteur1].[ID1]
        Left Outer Join [fnAjustement_Transporteur_Display](Null, Null, Null, Null, Null) [Ajustement_Transporteur2] On [UniteID] = [Ajustement_Transporteur2].[ID2]
            Left Outer Join [fnAjustement_Transporteur_Display](Null, Null, Null, Null, Null) [Ajustement_Transporteur3] On [MunicipaliteID] = [Ajustement_Transporteur3].[ID3]
                Left Outer Join [fnLivraison_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Livraison4] On [LivraisonID] = [Livraison4].[ID1]
                    Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur5] On [TransporteurID] = [Fournisseur5].[ID1]
                        Left Outer Join [fnFactureFournisseur_Display](Null, Null, Null, Null, Null, Null) [FactureFournisseur6] On [FactureID] = [FactureFournisseur6].[ID1]
                            Left Outer Join [fnAjustement_Transporteur_Display](Null, Null, Null, Null, Null) [Ajustement_Transporteur7] On [ZoneID] = [Ajustement_Transporteur7].[ID4]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))
)



