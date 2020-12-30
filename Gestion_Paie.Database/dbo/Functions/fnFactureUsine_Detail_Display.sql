CREATE FUNCTION [dbo].[fnFactureUsine_Detail_Display]
(@ID INT=Null, @FactureUsineID INT=Null, @ProducteurID VARCHAR (15)=Null, @ProducteurEntentePaiementID VARCHAR (15)=Null, @ZoneID VARCHAR (2)=Null, @MunicipaliteID VARCHAR (6)=Null, @LotID INT=Null, @UniteMesureID VARCHAR (6)=Null, @LivraisonID INT=Null, @EssenceID VARCHAR (6)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [ID] As [ID1]
,[ID] As [Display]
	
From [dbo].[FactureUsine_Detail]

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

Order By [Display]
)



