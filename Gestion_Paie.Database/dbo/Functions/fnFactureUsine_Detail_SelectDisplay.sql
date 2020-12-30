CREATE FUNCTION [dbo].[fnFactureUsine_Detail_SelectDisplay]
(@ID INT=Null, @FactureUsineID INT=Null, @ProducteurID VARCHAR (15)=Null, @ProducteurEntentePaiementID VARCHAR (15)=Null, @ZoneID VARCHAR (2)=Null, @MunicipaliteID VARCHAR (6)=Null, @LotID INT=Null, @UniteMesureID VARCHAR (6)=Null, @LivraisonID INT=Null, @EssenceID VARCHAR (6)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [FactureUsine_Detail].[ID]
	,[FactureUsine_Detail].[FactureUsineID]
	,[FactureUsine1].[Display] [FactureUsineID_Display]
	,[FactureUsine_Detail].[ContratID]
	,[FactureUsine_Detail].[ProducteurID]
	,[Fournisseur2].[Display] [ProducteurID_Display]
	,[FactureUsine_Detail].[ProducteurEntentePaiementID]
	,[Fournisseur3].[Display] [ProducteurEntentePaiementID_Display]
	,[FactureUsine_Detail].[ZoneID]
	,[Municipalite_Zone4].[Display] [ZoneID_Display]
	,[FactureUsine_Detail].[MunicipaliteID]
	,[Municipalite_Zone5].[Display] [MunicipaliteID_Display]
	,[FactureUsine_Detail].[LotID]
	,[Lot6].[Display] [LotID_Display]
	,[FactureUsine_Detail].[UniteMesureID]
	,[UniteMesure7].[Display] [UniteMesureID_Display]
	,[FactureUsine_Detail].[LivraisonID]
	,[Livraison8].[Display] [LivraisonID_Display]
	,[FactureUsine_Detail].[EssenceID]
	,[Essence9].[Display] [EssenceID_Display]
	,[FactureUsine_Detail].[Code]
	,[FactureUsine_Detail].[Volume]
	,[FactureUsine_Detail].[Taux]
	,[FactureUsine_Detail].[Montant]
	,[FactureUsine_Detail].[Taux_Usine_Override]
	,[FactureUsine_Detail].[PermisID]

From [dbo].[FactureUsine_Detail]
    Left Outer Join [fnFactureUsine_Display](Null, Null, Null, Null) [FactureUsine1] On [FactureUsineID] = [FactureUsine1].[ID1]
        Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur2] On [ProducteurID] = [Fournisseur2].[ID1]
            Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur3] On [ProducteurEntentePaiementID] = [Fournisseur3].[ID1]
                Left Outer Join [fnMunicipalite_Zone_Display](Null, Null) [Municipalite_Zone4] On [ZoneID] = [Municipalite_Zone4].[ID1]
                    Left Outer Join [fnMunicipalite_Zone_Display](Null, Null) [Municipalite_Zone5] On [MunicipaliteID] = [Municipalite_Zone5].[ID2]
                        Left Outer Join [fnLot_Display](Null, Null, Null, Null, Null, Null, Null, Null) [Lot6] On [LotID] = [Lot6].[ID1]
                            Inner Join [fnUniteMesure_Display](Null) [UniteMesure7] On [UniteMesureID] = [UniteMesure7].[ID1]
                                Left Outer Join [fnLivraison_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Livraison8] On [LivraisonID] = [Livraison8].[ID1]
                                    Left Outer Join [fnEssence_Display](Null, Null, Null, Null) [Essence9] On [EssenceID] = [Essence9].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@FactureUsineID Is Null) Or ([FactureUsineID] = @FactureUsineID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@ProducteurEntentePaiementID Is Null) Or ([ProducteurEntentePaiementID] = @ProducteurEntentePaiementID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@LotID Is Null) Or ([LotID] = @LotID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
)



