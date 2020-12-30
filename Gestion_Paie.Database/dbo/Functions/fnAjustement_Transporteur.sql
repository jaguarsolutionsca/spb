

Create Function [fnAjustement_Transporteur]
(
 @AjustementID [int] = Null
,@UniteID [varchar](6) = Null
,@MunicipaliteID [varchar](6) = Null
,@ZoneID [varchar](2) = Null
,@ContratID [varchar](10) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [AjustementID]
,[UniteID]
,[MunicipaliteID]
,[ContratID]
,[Taux_transporteur]
,[Date_Modification]
,[ZoneID]

From [dbo].[Ajustement_Transporteur]

Where

    ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
)


