

CREATE Function [dbo].[fnPermit_Display]
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


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID] As [ID1]
,[ID] As [Display]
	
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

-- YG 2020-11-04 - limite le nombre de permit pour GESTION des PERIODES
And Annee > 2019
--and ID > 154208

Order By [Display]
)


