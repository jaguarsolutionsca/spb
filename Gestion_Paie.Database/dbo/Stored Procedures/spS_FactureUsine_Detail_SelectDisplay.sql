CREATE PROCEDURE [dbo].[spS_FactureUsine_Detail_SelectDisplay]
@ID INT=Null, @FactureUsineID INT=Null, @ProducteurID VARCHAR (15)=Null, @ProducteurEntentePaiementID VARCHAR (15)=Null, @ZoneID VARCHAR (2)=Null, @MunicipaliteID VARCHAR (6)=Null, @LotID INT=Null, @UniteMesureID VARCHAR (6)=Null, @LivraisonID INT=Null, @EssenceID VARCHAR (6)=Null, @ReturnXML BIT=0
AS
If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [FactureUsine_Detail_Records].[ID]
		,[FactureUsine_Detail_Records].[FactureUsineID]
		,[FactureUsine_Detail_Records].[FactureUsineID_Display]
		,[FactureUsine_Detail_Records].[ContratID]
		,[FactureUsine_Detail_Records].[ProducteurID]
		,[FactureUsine_Detail_Records].[ProducteurID_Display]
		,[FactureUsine_Detail_Records].[ProducteurEntentePaiementID]
		,[FactureUsine_Detail_Records].[ProducteurEntentePaiementID_Display]
		,[FactureUsine_Detail_Records].[ZoneID]
		,[FactureUsine_Detail_Records].[ZoneID_Display]
		,[FactureUsine_Detail_Records].[MunicipaliteID]
		,[FactureUsine_Detail_Records].[MunicipaliteID_Display]
		,[FactureUsine_Detail_Records].[LotID]
		,[FactureUsine_Detail_Records].[LotID_Display]
		,[FactureUsine_Detail_Records].[UniteMesureID]
		,[FactureUsine_Detail_Records].[UniteMesureID_Display]
		,[FactureUsine_Detail_Records].[LivraisonID]
		,[FactureUsine_Detail_Records].[LivraisonID_Display]
		,[FactureUsine_Detail_Records].[EssenceID]
		,[FactureUsine_Detail_Records].[EssenceID_Display]
		,[FactureUsine_Detail_Records].[Code]
		,[FactureUsine_Detail_Records].[Volume]
		,[FactureUsine_Detail_Records].[Taux]
		,[FactureUsine_Detail_Records].[Montant]
		,[FactureUsine_Detail_Records].[Taux_Usine_Override]
		,[FactureUsine_Detail_Records].[PermisID]

		From [fnFactureUsine_Detail_SelectDisplay](@ID, @FactureUsineID, @ProducteurID, @ProducteurEntentePaiementID, @ZoneID, @MunicipaliteID, @LotID, @UniteMesureID, @LivraisonID, @EssenceID) As [FactureUsine_Detail_Records]
	End

Else

	Begin
		Select

		 [FactureUsine_Detail_Records].[ID]
		,[FactureUsine_Detail_Records].[FactureUsineID]
		,[FactureUsine_Detail_Records].[FactureUsineID_Display]
		,[FactureUsine_Detail_Records].[ContratID]
		,[FactureUsine_Detail_Records].[ProducteurID]
		,[FactureUsine_Detail_Records].[ProducteurID_Display]
		,[FactureUsine_Detail_Records].[ProducteurEntentePaiementID]
		,[FactureUsine_Detail_Records].[ProducteurEntentePaiementID_Display]
		,[FactureUsine_Detail_Records].[ZoneID]
		,[FactureUsine_Detail_Records].[ZoneID_Display]
		,[FactureUsine_Detail_Records].[MunicipaliteID]
		,[FactureUsine_Detail_Records].[MunicipaliteID_Display]
		,[FactureUsine_Detail_Records].[LotID]
		,[FactureUsine_Detail_Records].[LotID_Display]
		,[FactureUsine_Detail_Records].[UniteMesureID]
		,[FactureUsine_Detail_Records].[UniteMesureID_Display]
		,[FactureUsine_Detail_Records].[LivraisonID]
		,[FactureUsine_Detail_Records].[LivraisonID_Display]
		,[FactureUsine_Detail_Records].[EssenceID]
		,[FactureUsine_Detail_Records].[EssenceID_Display]
		,[FactureUsine_Detail_Records].[Code]
		,[FactureUsine_Detail_Records].[Volume]
		,[FactureUsine_Detail_Records].[Taux]
		,[FactureUsine_Detail_Records].[Montant]
		,[FactureUsine_Detail_Records].[Taux_Usine_Override]
		,[FactureUsine_Detail_Records].[PermisID]

		From [fnFactureUsine_Detail_SelectDisplay](@ID, @FactureUsineID, @ProducteurID, @ProducteurEntentePaiementID, @ZoneID, @MunicipaliteID, @LotID, @UniteMesureID, @LivraisonID, @EssenceID) As [FactureUsine_Detail_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


