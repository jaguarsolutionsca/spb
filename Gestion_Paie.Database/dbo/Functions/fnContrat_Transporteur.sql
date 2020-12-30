

Create Function [fnContrat_Transporteur]
(
 @ContratID [varchar](10) = Null
,@UniteID [varchar](6) = Null
,@MunicipaliteID [varchar](6) = Null
,@ZoneID [varchar](2) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ContratID]
,[UniteID]
,[MunicipaliteID]
,[Taux_transporteur]
,[Taux_producteur]
,[Actif]
,[ZoneID]

From [dbo].[Contrat_Transporteur]

Where

    ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))
)


