

Create Procedure [spD_Permit]

-- Delete a specific record from table [Permit]

(
 @ID [int] -- for [Permit].[ID] column
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

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Permit]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
And ((@ProducteurDroitCoupeID Is Null) Or ([ProducteurDroitCoupeID] = @ProducteurDroitCoupeID))
And ((@ProducteurEntentePaiementID Is Null) Or ([ProducteurEntentePaiementID] = @ProducteurEntentePaiementID))
And ((@LotID Is Null) Or ([LotID] = @LotID))
And ((@ChargeurID Is Null) Or ([ChargeurID] = @ChargeurID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))

Set NoCount Off

Return(@@RowCount)


