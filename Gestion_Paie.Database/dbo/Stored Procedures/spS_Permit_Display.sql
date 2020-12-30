

Create Procedure [spS_Permit_Display]

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
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Permit_Records].[ID1]
,[Permit_Records].[Display]

From [fnPermit_Display](@ID, @ContratID, @EssenceID, @TransporteurID, @ProducteurDroitCoupeID, @ProducteurEntentePaiementID, @LotID, @ChargeurID, @ZoneID, @MunicipaliteID) As [Permit_Records]

Return(@@RowCount)


