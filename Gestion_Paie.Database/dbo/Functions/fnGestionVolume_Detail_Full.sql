CREATE FUNCTION [dbo].[fnGestionVolume_Detail_Full]
(@ID INT=Null, @GestionVolumeID INT=Null, @EssenceID VARCHAR (6)=Null, @UniteMesureID VARCHAR (6)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [GestionVolume_Detail].[ID]
,[GestionVolume_Detail].[GestionVolumeID]
,[GestionVolume_Detail].[EssenceID]
,[GestionVolume_Detail].[UniteMesureID]
,[GestionVolume_Detail].[VolumeBrut]
,[GestionVolume_Detail].[VolumeReduction]
,[GestionVolume_Detail].[VolumeNet]
,[GestionVolume1].[ID] [GestionVolumeID_ID]
,[GestionVolume1].[DateLivraison] [GestionVolumeID_DateLivraison]
,[GestionVolume1].[UsineID] [GestionVolumeID_UsineID]
,[GestionVolume1].[UniteMesureID] [GestionVolumeID_UniteMesureID]
,[GestionVolume1].[ProducteurID] [GestionVolumeID_ProducteurID]
,[GestionVolume1].[Annee] [GestionVolumeID_Annee]
,[GestionVolume1].[Periode] [GestionVolumeID_Periode]
,[GestionVolume1].[LotID] [GestionVolumeID_LotID]
,[GestionVolume1].[DateEntree] [GestionVolumeID_DateEntree]
,[Essence_Unite2].[EssenceID] [EssenceID_EssenceID]
,[Essence_Unite2].[UniteID] [EssenceID_UniteID]
,[Essence_Unite2].[Facteur_M3app] [EssenceID_Facteur_M3app]
,[Essence_Unite2].[Facteur_M3sol] [EssenceID_Facteur_M3sol]
,[Essence_Unite2].[Actif] [EssenceID_Actif]
,[Essence_Unite2].[Preleve_plan_conjoint] [EssenceID_Preleve_plan_conjoint]
,[Essence_Unite2].[Preleve_plan_conjoint_Override] [EssenceID_Preleve_plan_conjoint_Override]
,[Essence_Unite2].[Preleve_fond_roulement] [EssenceID_Preleve_fond_roulement]
,[Essence_Unite2].[Preleve_fond_roulement_Override] [EssenceID_Preleve_fond_roulement_Override]
,[Essence_Unite2].[Preleve_fond_forestier] [EssenceID_Preleve_fond_forestier]
,[Essence_Unite2].[Preleve_fond_forestier_Override] [EssenceID_Preleve_fond_forestier_Override]
,[Essence_Unite2].[Preleve_divers] [EssenceID_Preleve_divers]
,[Essence_Unite2].[Preleve_divers_Override] [EssenceID_Preleve_divers_Override]
,[Essence_Unite2].[UseMontant] [EssenceID_UseMontant]
,[Essence_Unite3].[EssenceID] [UniteMesureID_EssenceID]
,[Essence_Unite3].[UniteID] [UniteMesureID_UniteID]
,[Essence_Unite3].[Facteur_M3app] [UniteMesureID_Facteur_M3app]
,[Essence_Unite3].[Facteur_M3sol] [UniteMesureID_Facteur_M3sol]
,[Essence_Unite3].[Actif] [UniteMesureID_Actif]
,[Essence_Unite3].[Preleve_plan_conjoint] [UniteMesureID_Preleve_plan_conjoint]
,[Essence_Unite3].[Preleve_plan_conjoint_Override] [UniteMesureID_Preleve_plan_conjoint_Override]
,[Essence_Unite3].[Preleve_fond_roulement] [UniteMesureID_Preleve_fond_roulement]
,[Essence_Unite3].[Preleve_fond_roulement_Override] [UniteMesureID_Preleve_fond_roulement_Override]
,[Essence_Unite3].[Preleve_fond_forestier] [UniteMesureID_Preleve_fond_forestier]
,[Essence_Unite3].[Preleve_fond_forestier_Override] [UniteMesureID_Preleve_fond_forestier_Override]
,[Essence_Unite3].[Preleve_divers] [UniteMesureID_Preleve_divers]
,[Essence_Unite3].[Preleve_divers_Override] [UniteMesureID_Preleve_divers_Override]
,[Essence_Unite3].[UseMontant] [UniteMesureID_UseMontant]

From [dbo].[GestionVolume_Detail] [GestionVolume_Detail]
    Left Outer Join [dbo].[GestionVolume] [GestionVolume1] On [GestionVolume_Detail].[GestionVolumeID] = [GestionVolume1].[ID]
        Left Outer Join [dbo].[Essence_Unite] [Essence_Unite2] On [GestionVolume_Detail].[EssenceID] = [Essence_Unite2].[EssenceID]
            Left Outer Join [dbo].[Essence_Unite] [Essence_Unite3] On [GestionVolume_Detail].[UniteMesureID] = [Essence_Unite3].[UniteID]

Where

    ((@ID Is Null) Or ([GestionVolume_Detail].[ID] = @ID))
And ((@GestionVolumeID Is Null) Or ([GestionVolume_Detail].[GestionVolumeID] = @GestionVolumeID))
And ((@EssenceID Is Null) Or ([GestionVolume_Detail].[EssenceID] = @EssenceID))
And ((@UniteMesureID Is Null) Or ([GestionVolume_Detail].[UniteMesureID] = @UniteMesureID))
)



