

Create Function [fnAjustement_Transporteur_Display]
(
 @AjustementID [int] = Null
,@UniteID [varchar](6) = Null
,@MunicipaliteID [varchar](6) = Null
,@ZoneID [varchar](2) = Null
,@ContratID [varchar](10) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [AjustementID] As [ID1]
,[UniteID] As [ID2]
,[MunicipaliteID] As [ID3]
,[ZoneID] As [ID4]
,[ZoneID] As [Display]
	
From [dbo].[Ajustement_Transporteur]

Where
    ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))

Order By [Display]
)


