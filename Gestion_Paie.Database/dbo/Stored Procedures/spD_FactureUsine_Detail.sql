CREATE PROCEDURE [dbo].[spD_FactureUsine_Detail]
@ID INT, @FactureUsineID INT=Null, @ProducteurID VARCHAR (15)=Null, @ProducteurEntentePaiementID VARCHAR (15)=Null, @ZoneID VARCHAR (2)=Null, @MunicipaliteID VARCHAR (6)=Null, @LotID INT=Null, @UniteMesureID VARCHAR (6)=Null, @LivraisonID INT=Null, @EssenceID VARCHAR (6)=Null
AS
Set NoCount On

Delete From [dbo].[FactureUsine_Detail]

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

Set NoCount Off

Return(@@RowCount)


