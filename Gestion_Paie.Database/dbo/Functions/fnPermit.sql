

Create Function [fnPermit]
(
 @ID [int] = Null
,@ContratID [varchar](10) = Null
,@EssenceID [varchar](6) = Null
,@TransporteurID [varchar](15) = Null
,@ProducteurDroitCoupeID [varchar](15) = Null
,@ProducteurEntentePaiementID [varchar](15) = Null
,@LotID [int] = Null
,@ChargeurID [varchar](15) = Null
,@ZoneID [varchar](2) = Null
,@MunicipaliteID [varchar](6) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID]
,[DatePermit]
,[DateDebut]
,[DateFin]
,[Annee]
,[Periode]
,[ContratID]
,[EssenceID]
,[PermitSciage]
,[TransporteurID]
,[VR]
,[ProducteurDroitCoupeID]
,[ProducteurEntentePaiementID]
,[PermitLivre]
,[PermitImprime]
,[PermitAnnule]
,[LotID]
,[EssenceSciage]
,[Code]
,[Remarques]
,[ChargeurID]
,[ZoneID]
,[MunicipaliteID]

From [dbo].[Permit]

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
)


