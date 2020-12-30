CREATE PROCEDURE [dbo].[spS_FactureUsine_Detail_Display]
@ID INT=Null, @FactureUsineID INT=Null, @ProducteurID VARCHAR (15)=Null, @ProducteurEntentePaiementID VARCHAR (15)=Null, @ZoneID VARCHAR (2)=Null, @MunicipaliteID VARCHAR (6)=Null, @LotID INT=Null, @UniteMesureID VARCHAR (6)=Null, @LivraisonID INT=Null, @EssenceID VARCHAR (6)=Null
AS
Select
 [FactureUsine_Detail_Records].[ID1]
,[FactureUsine_Detail_Records].[Display]

From [fnFactureUsine_Detail_Display](@ID, @FactureUsineID, @ProducteurID, @ProducteurEntentePaiementID, @ZoneID, @MunicipaliteID, @LotID, @UniteMesureID, @LivraisonID, @EssenceID) As [FactureUsine_Detail_Records]

Return(@@RowCount)


