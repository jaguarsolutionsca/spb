

Create Function [fnContingentement_Unite_Full]

(
 @ContingentementID [int] = Null
,@UniteID [varchar](6) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Contingentement_Unite].[ContingentementID]
,[Contingentement_Unite].[UniteID]
,[Contingentement_Unite].[Facteur]
,[Contingentement1].[ID] [ContingentementID_ID]
,[Contingentement1].[ContingentUsine] [ContingentementID_ContingentUsine]
,[Contingentement1].[UsineID] [ContingentementID_UsineID]
,[Contingentement1].[RegroupementID] [ContingentementID_RegroupementID]
,[Contingentement1].[Annee] [ContingentementID_Annee]
,[Contingentement1].[PeriodeContingentement] [ContingentementID_PeriodeContingentement]
,[Contingentement1].[PeriodeDebut] [ContingentementID_PeriodeDebut]
,[Contingentement1].[PeriodeFin] [ContingentementID_PeriodeFin]
,[Contingentement1].[EssenceID] [ContingentementID_EssenceID]
,[Contingentement1].[UniteMesureID] [ContingentementID_UniteMesureID]
,[Contingentement1].[Volume_Usine] [ContingentementID_Volume_Usine]
,[Contingentement1].[Facteur] [ContingentementID_Facteur]
,[Contingentement1].[Volume_Fixe] [ContingentementID_Volume_Fixe]
,[Contingentement1].[Date_Calcul] [ContingentementID_Date_Calcul]
,[Contingentement1].[CalculAccepte] [ContingentementID_CalculAccepte]
,[Contingentement1].[Code] [ContingentementID_Code]
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

From [dbo].[Contingentement_Unite] [Contingentement_Unite]
    Inner Join [dbo].[Contingentement] [Contingentement1] On [Contingentement_Unite].[ContingentementID] = [Contingentement1].[ID]
        Inner Join [dbo].[UniteMesure] [UniteMesure2] On [Contingentement_Unite].[UniteID] = [UniteMesure2].[ID]

Where

    ((@ContingentementID Is Null) Or ([Contingentement_Unite].[ContingentementID] = @ContingentementID))
And ((@UniteID Is Null) Or ([Contingentement_Unite].[UniteID] = @UniteID))
)



