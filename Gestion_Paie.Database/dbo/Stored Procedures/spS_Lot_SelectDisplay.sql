
CREATE Procedure [spS_Lot_SelectDisplay]

-- Retrieve specific records from the [Lot] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [Lot].[ID] column
,@CantonID [varchar](6) = Null -- for [Lot].[CantonID] column
,@MunicipaliteID [varchar](6) = Null -- for [Lot].[MunicipaliteID] column
,@ProprietaireID [varchar](15) = Null -- for [Lot].[ProprietaireID] column
,@ContingentID [varchar](15) = Null -- for [Lot].[ContingentID] column
,@Droit_coupeID [varchar](15) = Null -- for [Lot].[Droit_coupeID] column
,@Entente_paiementID [varchar](15) = Null -- for [Lot].[Entente_paiementID] column
,@ZoneID [varchar](2) = Null -- for [Lot].[ZoneID] column
,@ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [Lot_Records].[CantonID]
		,[Lot_Records].[CantonID_Display]
		,[Lot_Records].[Rang]
		,[Lot_Records].[Lot]
		,[Lot_Records].[MunicipaliteID]
		,[Lot_Records].[MunicipaliteID_Display]
		,[Lot_Records].[Superficie_total]
		,[Lot_Records].[Superficie_boisee]
		,[Lot_Records].[ProprietaireID]
		,[Lot_Records].[ProprietaireID_Display]
		,[Lot_Records].[ContingentID]
		,[Lot_Records].[ContingentID_Display]
		,[Lot_Records].[Contingent_Date]
		,[Lot_Records].[Droit_coupeID]
		,[Lot_Records].[Droit_coupeID_Display]
		,[Lot_Records].[Droit_coupe_Date]
		,[Lot_Records].[Entente_paiementID]
		,[Lot_Records].[Entente_paiementID_Display]
		,[Lot_Records].[Entente_paiement_Date]
		,[Lot_Records].[Actif]
		,[Lot_Records].[ID]
		,[Lot_Records].[Sequence]
		,[Lot_Records].[Partie]
		,[Lot_Records].[Matricule]
		,[Lot_Records].[ZoneID]
		,[Lot_Records].[ZoneID_Display]
		,[Lot_Records].[Secteur]
		,[Lot_Records].[Cadastre]
		,[Lot_Records].[Reforme]
		,[Lot_Records].[LotsComplementaires]
		,[Lot_Records].[Certifie]
		,[Lot_Records].[NumeroCertification]
		,[Lot_Records].[OGC]

		From [fnLot_SelectDisplay](@ID, @CantonID, @MunicipaliteID, @ProprietaireID, @ContingentID, @Droit_coupeID, @Entente_paiementID, @ZoneID) As [Lot_Records]
	End

Else

	Begin
		Select

		 [Lot_Records].[CantonID]
		,[Lot_Records].[CantonID_Display]
		,[Lot_Records].[Rang]
		,[Lot_Records].[Lot]
		,[Lot_Records].[MunicipaliteID]
		,[Lot_Records].[MunicipaliteID_Display]
		,[Lot_Records].[Superficie_total]
		,[Lot_Records].[Superficie_boisee]
		,[Lot_Records].[ProprietaireID]
		,[Lot_Records].[ProprietaireID_Display]
		,[Lot_Records].[ContingentID]
		,[Lot_Records].[ContingentID_Display]
		,[Lot_Records].[Contingent_Date]
		,[Lot_Records].[Droit_coupeID]
		,[Lot_Records].[Droit_coupeID_Display]
		,[Lot_Records].[Droit_coupe_Date]
		,[Lot_Records].[Entente_paiementID]
		,[Lot_Records].[Entente_paiementID_Display]
		,[Lot_Records].[Entente_paiement_Date]
		,[Lot_Records].[Actif]
		,[Lot_Records].[ID]
		,[Lot_Records].[Sequence]
		,[Lot_Records].[Partie]
		,[Lot_Records].[Matricule]
		,[Lot_Records].[ZoneID]
		,[Lot_Records].[ZoneID_Display]
		,[Lot_Records].[Secteur]
		,[Lot_Records].[Cadastre]
		,[Lot_Records].[Reforme]
		,[Lot_Records].[LotsComplementaires]
		,[Lot_Records].[Certifie]
		,[Lot_Records].[NumeroCertification]
		,[Lot_Records].[OGC]

		From [fnLot_SelectDisplay](@ID, @CantonID, @MunicipaliteID, @ProprietaireID, @ContingentID, @Droit_coupeID, @Entente_paiementID, @ZoneID) As [Lot_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)

