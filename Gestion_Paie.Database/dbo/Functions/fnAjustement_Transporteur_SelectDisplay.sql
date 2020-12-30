

Create Function [fnAjustement_Transporteur_SelectDisplay]
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
Select
	 [Ajustement_Transporteur].[AjustementID]
	,[Ajustement1].[Display] [AjustementID_Display]
	,[Ajustement_Transporteur].[UniteID]
	,[Contrat_Transporteur2].[Display] [UniteID_Display]
	,[Ajustement_Transporteur].[MunicipaliteID]
	,[Contrat_Transporteur3].[Display] [MunicipaliteID_Display]
	,[Ajustement_Transporteur].[ContratID]
	,[Contrat_Transporteur4].[Display] [ContratID_Display]
	,[Ajustement_Transporteur].[Taux_transporteur]
	,[Ajustement_Transporteur].[Date_Modification]
	,[Ajustement_Transporteur].[ZoneID]
	,[Contrat_Transporteur5].[Display] [ZoneID_Display]

From [dbo].[Ajustement_Transporteur]
    Inner Join [fnAjustement_Display](Null, Null) [Ajustement1] On [AjustementID] = [Ajustement1].[ID1]
        Inner Join [fnContrat_Transporteur_Display](Null, Null, Null, Null) [Contrat_Transporteur2] On [UniteID] = [Contrat_Transporteur2].[ID2]
            Inner Join [fnContrat_Transporteur_Display](Null, Null, Null, Null) [Contrat_Transporteur3] On [MunicipaliteID] = [Contrat_Transporteur3].[ID3]
                Inner Join [fnContrat_Transporteur_Display](Null, Null, Null, Null) [Contrat_Transporteur4] On [ContratID] = [Contrat_Transporteur4].[ID1]
                    Inner Join [fnContrat_Transporteur_Display](Null, Null, Null, Null) [Contrat_Transporteur5] On [ZoneID] = [Contrat_Transporteur5].[ID4]

Where

    ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
)


