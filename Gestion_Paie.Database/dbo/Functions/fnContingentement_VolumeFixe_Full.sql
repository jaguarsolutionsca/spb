
Create Function [fnContingentement_VolumeFixe_Full]

(
 @ContingentementID [int] = Null
,@Superficie_Min [real] = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
 [Contingentement_VolumeFixe].[ContingentementID]
,[Contingentement_VolumeFixe].[Superficie_Min]
,[Contingentement_VolumeFixe].[Volume_Fixe]
,[Contingentement_VolumeFixe].[NombreMois]
,[Contingentement_VolumeFixe].[UseNombreMois]
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
,[Contingentement1].[Volume_Regroupement] [ContingentementID_Volume_Regroupement]
,[Contingentement1].[Volume_RegroupementPourcentage] [ContingentementID_Volume_RegroupementPourcentage]
,[Contingentement1].[MaxVolumeFixe_Pourcentage] [ContingentementID_MaxVolumeFixe_Pourcentage]
,[Contingentement1].[MaxVolumeFixe_ContingentementID] [ContingentementID_MaxVolumeFixe_ContingentementID]
,[Contingentement1].[UseVolumeFixeUnique] [ContingentementID_UseVolumeFixeUnique]

From [dbo].[Contingentement_VolumeFixe] [Contingentement_VolumeFixe]
    Inner Join [dbo].[Contingentement] [Contingentement1] On [Contingentement_VolumeFixe].[ContingentementID] = [Contingentement1].[ID]

Where

    ((@ContingentementID Is Null) Or ([Contingentement_VolumeFixe].[ContingentementID] = @ContingentementID))
And ((@Superficie_Min Is Null) Or ([Contingentement_VolumeFixe].[Superficie_Min] = @Superficie_Min))
)

