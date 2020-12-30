

Create Function [fnContrat_Transporteur_SelectDisplay]
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
Select
	 [Contrat_Transporteur].[ContratID]
	,[Contrat1].[Display] [ContratID_Display]
	,[Contrat_Transporteur].[UniteID]
	,[UniteMesure2].[Display] [UniteID_Display]
	,[Contrat_Transporteur].[MunicipaliteID]
	,[Municipalite_Zone3].[Display] [MunicipaliteID_Display]
	,[Contrat_Transporteur].[Taux_transporteur]
	,[Contrat_Transporteur].[Taux_producteur]
	,[Contrat_Transporteur].[Actif]
	,[Contrat_Transporteur].[ZoneID]
	,[Municipalite_Zone4].[Display] [ZoneID_Display]

From [dbo].[Contrat_Transporteur]
    Inner Join [fnContrat_Display](Null, Null) [Contrat1] On [ContratID] = [Contrat1].[ID1]
        Inner Join [fnUniteMesure_Display](Null) [UniteMesure2] On [UniteID] = [UniteMesure2].[ID1]
            Inner Join [fnMunicipalite_Zone_Display](Null, Null) [Municipalite_Zone3] On [MunicipaliteID] = [Municipalite_Zone3].[ID2]
                Inner Join [fnMunicipalite_Zone_Display](Null, Null) [Municipalite_Zone4] On [ZoneID] = [Municipalite_Zone4].[ID1]

Where

    ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))
)


