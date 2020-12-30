

Create Function [fnContrat_Transporteur_Full]

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
 [Contrat_Transporteur].[ContratID]
,[Contrat_Transporteur].[UniteID]
,[Contrat_Transporteur].[MunicipaliteID]
,[Contrat_Transporteur].[Taux_transporteur]
,[Contrat_Transporteur].[Taux_producteur]
,[Contrat_Transporteur].[Actif]
,[Contrat_Transporteur].[ZoneID]
,[Contrat1].[ID] [ContratID_ID]
,[Contrat1].[Description] [ContratID_Description]
,[Contrat1].[UsineID] [ContratID_UsineID]
,[Contrat1].[Annee] [ContratID_Annee]
,[Contrat1].[Date_debut] [ContratID_Date_debut]
,[Contrat1].[Date_fin] [ContratID_Date_fin]
,[Contrat1].[Actif] [ContratID_Actif]
,[Contrat1].[PaieTransporteur] [ContratID_PaieTransporteur]
,[Contrat1].[Taux_Surcharge] [ContratID_Taux_Surcharge]
,[Contrat1].[SurchargeManuel] [ContratID_SurchargeManuel]
,[Contrat1].[TxTransSameProd] [ContratID_TxTransSameProd]
,[UniteMesure2].[ID] [UniteID_ID]
,[UniteMesure2].[Description] [UniteID_Description]
,[UniteMesure2].[Nb_decimale] [UniteID_Nb_decimale]
,[UniteMesure2].[Actif] [UniteID_Actif]
,[UniteMesure2].[UseMontant] [UniteID_UseMontant]
,[UniteMesure2].[Montant_Preleve_plan_conjoint] [UniteID_Montant_Preleve_plan_conjoint]
,[UniteMesure2].[Montant_Preleve_fond_roulement] [UniteID_Montant_Preleve_fond_roulement]
,[UniteMesure2].[Montant_Preleve_fond_forestier] [UniteID_Montant_Preleve_fond_forestier]
,[UniteMesure2].[Montant_Preleve_divers] [UniteID_Montant_Preleve_divers]
,[UniteMesure2].[Pourc_Preleve_plan_conjoint] [UniteID_Pourc_Preleve_plan_conjoint]
,[UniteMesure2].[Pourc_Preleve_fond_roulement] [UniteID_Pourc_Preleve_fond_roulement]
,[UniteMesure2].[Pourc_Preleve_fond_forestier] [UniteID_Pourc_Preleve_fond_forestier]
,[UniteMesure2].[Pourc_Preleve_divers] [UniteID_Pourc_Preleve_divers]
,[Municipalite_Zone3].[ID] [MunicipaliteID_ID]
,[Municipalite_Zone3].[MunicipaliteID] [MunicipaliteID_MunicipaliteID]
,[Municipalite_Zone3].[Description] [MunicipaliteID_Description]
,[Municipalite_Zone3].[Actif] [MunicipaliteID_Actif]
,[Municipalite_Zone4].[ID] [ZoneID_ID]
,[Municipalite_Zone4].[MunicipaliteID] [ZoneID_MunicipaliteID]
,[Municipalite_Zone4].[Description] [ZoneID_Description]
,[Municipalite_Zone4].[Actif] [ZoneID_Actif]

From [dbo].[Contrat_Transporteur] [Contrat_Transporteur]
    Inner Join [dbo].[Contrat] [Contrat1] On [Contrat_Transporteur].[ContratID] = [Contrat1].[ID]
        Inner Join [dbo].[UniteMesure] [UniteMesure2] On [Contrat_Transporteur].[UniteID] = [UniteMesure2].[ID]
            Inner Join [dbo].[Municipalite_Zone] [Municipalite_Zone3] On [Contrat_Transporteur].[MunicipaliteID] = [Municipalite_Zone3].[MunicipaliteID]
                Inner Join [dbo].[Municipalite_Zone] [Municipalite_Zone4] On [Contrat_Transporteur].[ZoneID] = [Municipalite_Zone4].[ID]

Where

    ((@ContratID Is Null) Or ([Contrat_Transporteur].[ContratID] = @ContratID))
And ((@UniteID Is Null) Or ([Contrat_Transporteur].[UniteID] = @UniteID))
And ((@MunicipaliteID Is Null) Or ([Contrat_Transporteur].[MunicipaliteID] = @MunicipaliteID))
And ((@ZoneID Is Null) Or ([Contrat_Transporteur].[ZoneID] = @ZoneID))
)



