

Create Function [fnAjustement_Transporteur_Full]

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
 [Ajustement_Transporteur].[AjustementID]
,[Ajustement_Transporteur].[UniteID]
,[Ajustement_Transporteur].[MunicipaliteID]
,[Ajustement_Transporteur].[ContratID]
,[Ajustement_Transporteur].[Taux_transporteur]
,[Ajustement_Transporteur].[Date_Modification]
,[Ajustement_Transporteur].[ZoneID]
,[Ajustement1].[ID] [AjustementID_ID]
,[Ajustement1].[ContratID] [AjustementID_ContratID]
,[Ajustement1].[DateAjustement] [AjustementID_DateAjustement]
,[Ajustement1].[Periode_Debut] [AjustementID_Periode_Debut]
,[Ajustement1].[Periode_Fin] [AjustementID_Periode_Fin]
,[Ajustement1].[Facture] [AjustementID_Facture]
,[Ajustement1].[UsePeriodes] [AjustementID_UsePeriodes]
,[Ajustement1].[Date_Debut] [AjustementID_Date_Debut]
,[Ajustement1].[Date_Fin] [AjustementID_Date_Fin]
,[Ajustement1].[ProducteurID] [AjustementID_ProducteurID]
,[Ajustement1].[TransporteurID] [AjustementID_TransporteurID]
,[Contrat_Transporteur2].[ContratID] [UniteID_ContratID]
,[Contrat_Transporteur2].[UniteID] [UniteID_UniteID]
,[Contrat_Transporteur2].[MunicipaliteID] [UniteID_MunicipaliteID]
,[Contrat_Transporteur2].[Taux_transporteur] [UniteID_Taux_transporteur]
,[Contrat_Transporteur2].[Taux_producteur] [UniteID_Taux_producteur]
,[Contrat_Transporteur2].[Actif] [UniteID_Actif]
,[Contrat_Transporteur2].[ZoneID] [UniteID_ZoneID]
,[Contrat_Transporteur3].[ContratID] [MunicipaliteID_ContratID]
,[Contrat_Transporteur3].[UniteID] [MunicipaliteID_UniteID]
,[Contrat_Transporteur3].[MunicipaliteID] [MunicipaliteID_MunicipaliteID]
,[Contrat_Transporteur3].[Taux_transporteur] [MunicipaliteID_Taux_transporteur]
,[Contrat_Transporteur3].[Taux_producteur] [MunicipaliteID_Taux_producteur]
,[Contrat_Transporteur3].[Actif] [MunicipaliteID_Actif]
,[Contrat_Transporteur3].[ZoneID] [MunicipaliteID_ZoneID]
,[Contrat_Transporteur4].[ContratID] [ContratID_ContratID]
,[Contrat_Transporteur4].[UniteID] [ContratID_UniteID]
,[Contrat_Transporteur4].[MunicipaliteID] [ContratID_MunicipaliteID]
,[Contrat_Transporteur4].[Taux_transporteur] [ContratID_Taux_transporteur]
,[Contrat_Transporteur4].[Taux_producteur] [ContratID_Taux_producteur]
,[Contrat_Transporteur4].[Actif] [ContratID_Actif]
,[Contrat_Transporteur4].[ZoneID] [ContratID_ZoneID]
,[Contrat_Transporteur5].[ContratID] [ZoneID_ContratID]
,[Contrat_Transporteur5].[UniteID] [ZoneID_UniteID]
,[Contrat_Transporteur5].[MunicipaliteID] [ZoneID_MunicipaliteID]
,[Contrat_Transporteur5].[Taux_transporteur] [ZoneID_Taux_transporteur]
,[Contrat_Transporteur5].[Taux_producteur] [ZoneID_Taux_producteur]
,[Contrat_Transporteur5].[Actif] [ZoneID_Actif]
,[Contrat_Transporteur5].[ZoneID] [ZoneID_ZoneID]

From [dbo].[Ajustement_Transporteur] [Ajustement_Transporteur]
    Inner Join [dbo].[Ajustement] [Ajustement1] On [Ajustement_Transporteur].[AjustementID] = [Ajustement1].[ID]
        Inner Join [dbo].[Contrat_Transporteur] [Contrat_Transporteur2] On [Ajustement_Transporteur].[UniteID] = [Contrat_Transporteur2].[UniteID]
            Inner Join [dbo].[Contrat_Transporteur] [Contrat_Transporteur3] On [Ajustement_Transporteur].[MunicipaliteID] = [Contrat_Transporteur3].[MunicipaliteID]
                Inner Join [dbo].[Contrat_Transporteur] [Contrat_Transporteur4] On [Ajustement_Transporteur].[ContratID] = [Contrat_Transporteur4].[ContratID]
                    Inner Join [dbo].[Contrat_Transporteur] [Contrat_Transporteur5] On [Ajustement_Transporteur].[ZoneID] = [Contrat_Transporteur5].[ZoneID]

Where

    ((@AjustementID Is Null) Or ([Ajustement_Transporteur].[AjustementID] = @AjustementID))
And ((@UniteID Is Null) Or ([Ajustement_Transporteur].[UniteID] = @UniteID))
And ((@MunicipaliteID Is Null) Or ([Ajustement_Transporteur].[MunicipaliteID] = @MunicipaliteID))
And ((@ZoneID Is Null) Or ([Ajustement_Transporteur].[ZoneID] = @ZoneID))
And ((@ContratID Is Null) Or ([Ajustement_Transporteur].[ContratID] = @ContratID))
)



