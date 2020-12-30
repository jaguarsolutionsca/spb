

Create Procedure [spS_Permit]

-- Retrieve specific records from the [Permit] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [Permit].[ID] column
,@ContratID [varchar](10) = Null -- for [Permit].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [Permit].[EssenceID] column
,@TransporteurID [varchar](15) = Null -- for [Permit].[TransporteurID] column
,@ProducteurDroitCoupeID [varchar](15) = Null -- for [Permit].[ProducteurDroitCoupeID] column
,@ProducteurEntentePaiementID [varchar](15) = Null -- for [Permit].[ProducteurEntentePaiementID] column
,@LotID [int] = Null -- for [Permit].[LotID] column
,@ChargeurID [varchar](15) = Null -- for [Permit].[ChargeurID] column
,@ZoneID [varchar](2) = Null -- for [Permit].[ZoneID] column
,@MunicipaliteID [varchar](6) = Null -- for [Permit].[MunicipaliteID] column
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

		 [Permit_Records].[ID]
		,[Permit_Records].[DatePermit]
		,[Permit_Records].[DateDebut]
		,[Permit_Records].[DateFin]
		,[Permit_Records].[Annee]
		,[Permit_Records].[Periode]
		,[Permit_Records].[ContratID]
		,[Permit_Records].[EssenceID]
		,[Permit_Records].[PermitSciage]
		,[Permit_Records].[TransporteurID]
		,[Permit_Records].[VR]
		,[Permit_Records].[ProducteurDroitCoupeID]
		,[Permit_Records].[ProducteurEntentePaiementID]
		,[Permit_Records].[PermitLivre]
		,[Permit_Records].[PermitImprime]
		,[Permit_Records].[PermitAnnule]
		,[Permit_Records].[LotID]
		,[Permit_Records].[EssenceSciage]
		,[Permit_Records].[Code]
		,[Permit_Records].[Remarques]
		,[Permit_Records].[ChargeurID]
		,[Permit_Records].[ZoneID]
		,[Permit_Records].[MunicipaliteID]

		From [fnPermit](@ID, @ContratID, @EssenceID, @TransporteurID, @ProducteurDroitCoupeID, @ProducteurEntentePaiementID, @LotID, @ChargeurID, @ZoneID, @MunicipaliteID) As [Permit_Records]
	End

Else

	Begin
		Select

		 [Permit_Records].[ID]
		,[Permit_Records].[DatePermit]
		,[Permit_Records].[DateDebut]
		,[Permit_Records].[DateFin]
		,[Permit_Records].[Annee]
		,[Permit_Records].[Periode]
		,[Permit_Records].[ContratID]
		,[Permit_Records].[EssenceID]
		,[Permit_Records].[PermitSciage]
		,[Permit_Records].[TransporteurID]
		,[Permit_Records].[VR]
		,[Permit_Records].[ProducteurDroitCoupeID]
		,[Permit_Records].[ProducteurEntentePaiementID]
		,[Permit_Records].[PermitLivre]
		,[Permit_Records].[PermitImprime]
		,[Permit_Records].[PermitAnnule]
		,[Permit_Records].[LotID]
		,[Permit_Records].[EssenceSciage]
		,[Permit_Records].[Code]
		,[Permit_Records].[Remarques]
		,[Permit_Records].[ChargeurID]
		,[Permit_Records].[ZoneID]
		,[Permit_Records].[MunicipaliteID]

		From [fnPermit](@ID, @ContratID, @EssenceID, @TransporteurID, @ProducteurDroitCoupeID, @ProducteurEntentePaiementID, @LotID, @ChargeurID, @ZoneID, @MunicipaliteID) As [Permit_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


