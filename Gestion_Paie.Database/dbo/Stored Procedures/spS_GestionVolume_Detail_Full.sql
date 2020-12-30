

Create Procedure [spS_GestionVolume_Detail_Full]

/*
Retrieve specific records from the [GestionVolume_Detail] table, as well as all its foreign tables, depending on the input parameters you supply:
	[GestionVolume] (via [GestionVolumeID])
	[Essence_Unite] (via [EssenceID])
	[Essence_Unite] (via [UniteMesureID])
*/

(
 @ID [int] = Null -- for [GestionVolume_Detail].[ID] column
,@GestionVolumeID [int] = Null -- for [GestionVolume_Detail].[GestionVolumeID] column
,@EssenceID [varchar](6) = Null -- for [GestionVolume_Detail].[EssenceID] column
,@UniteMesureID [varchar](6) = Null -- for [GestionVolume_Detail].[UniteMesureID] column
,@ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [GestionVolume_Detail_Records].[ID]
		,[GestionVolume_Detail_Records].[GestionVolumeID]
		,[GestionVolume_Detail_Records].[EssenceID]
		,[GestionVolume_Detail_Records].[UniteMesureID]
		,[GestionVolume_Detail_Records].[VolumeBrut]
		,[GestionVolume_Detail_Records].[VolumeReduction]
		,[GestionVolume_Detail_Records].[VolumeNet]
		,[GestionVolume_Detail_Records].[GestionVolumeID_ID]
		,[GestionVolume_Detail_Records].[GestionVolumeID_DateLivraison]
		,[GestionVolume_Detail_Records].[GestionVolumeID_UsineID]
		,[GestionVolume_Detail_Records].[GestionVolumeID_UniteMesureID]
		,[GestionVolume_Detail_Records].[GestionVolumeID_ProducteurID]
		,[GestionVolume_Detail_Records].[GestionVolumeID_Annee]
		,[GestionVolume_Detail_Records].[GestionVolumeID_Periode]
		,[GestionVolume_Detail_Records].[GestionVolumeID_LotID]
		,[GestionVolume_Detail_Records].[GestionVolumeID_DateEntree]
		,[GestionVolume_Detail_Records].[EssenceID_EssenceID]
		,[GestionVolume_Detail_Records].[EssenceID_UniteID]
		,[GestionVolume_Detail_Records].[EssenceID_Facteur_M3app]
		,[GestionVolume_Detail_Records].[EssenceID_Facteur_M3sol]
		,[GestionVolume_Detail_Records].[EssenceID_Actif]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_plan_conjoint]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_plan_conjoint_Override]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_fond_roulement]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_fond_roulement_Override]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_fond_forestier]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_fond_forestier_Override]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_divers]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_divers_Override]
		,[GestionVolume_Detail_Records].[EssenceID_UseMontant]
		,[GestionVolume_Detail_Records].[UniteMesureID_EssenceID]
		,[GestionVolume_Detail_Records].[UniteMesureID_UniteID]
		,[GestionVolume_Detail_Records].[UniteMesureID_Facteur_M3app]
		,[GestionVolume_Detail_Records].[UniteMesureID_Facteur_M3sol]
		,[GestionVolume_Detail_Records].[UniteMesureID_Actif]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_plan_conjoint]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_plan_conjoint_Override]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_fond_roulement]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_fond_roulement_Override]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_fond_forestier]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_fond_forestier_Override]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_divers]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_divers_Override]
		,[GestionVolume_Detail_Records].[UniteMesureID_UseMontant]

		From [fnGestionVolume_Detail_Full](@ID, @GestionVolumeID, @EssenceID, @UniteMesureID) As [GestionVolume_Detail_Records]
	End

Else

	Begin
		Select

		 [GestionVolume_Detail_Records].[ID]
		,[GestionVolume_Detail_Records].[GestionVolumeID]
		,[GestionVolume_Detail_Records].[EssenceID]
		,[GestionVolume_Detail_Records].[UniteMesureID]
		,[GestionVolume_Detail_Records].[VolumeBrut]
		,[GestionVolume_Detail_Records].[VolumeReduction]
		,[GestionVolume_Detail_Records].[VolumeNet]
		,[GestionVolume_Detail_Records].[GestionVolumeID_ID]
		,[GestionVolume_Detail_Records].[GestionVolumeID_DateLivraison]
		,[GestionVolume_Detail_Records].[GestionVolumeID_UsineID]
		,[GestionVolume_Detail_Records].[GestionVolumeID_UniteMesureID]
		,[GestionVolume_Detail_Records].[GestionVolumeID_ProducteurID]
		,[GestionVolume_Detail_Records].[GestionVolumeID_Annee]
		,[GestionVolume_Detail_Records].[GestionVolumeID_Periode]
		,[GestionVolume_Detail_Records].[GestionVolumeID_LotID]
		,[GestionVolume_Detail_Records].[GestionVolumeID_DateEntree]
		,[GestionVolume_Detail_Records].[EssenceID_EssenceID]
		,[GestionVolume_Detail_Records].[EssenceID_UniteID]
		,[GestionVolume_Detail_Records].[EssenceID_Facteur_M3app]
		,[GestionVolume_Detail_Records].[EssenceID_Facteur_M3sol]
		,[GestionVolume_Detail_Records].[EssenceID_Actif]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_plan_conjoint]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_plan_conjoint_Override]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_fond_roulement]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_fond_roulement_Override]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_fond_forestier]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_fond_forestier_Override]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_divers]
		,[GestionVolume_Detail_Records].[EssenceID_Preleve_divers_Override]
		,[GestionVolume_Detail_Records].[EssenceID_UseMontant]
		,[GestionVolume_Detail_Records].[UniteMesureID_EssenceID]
		,[GestionVolume_Detail_Records].[UniteMesureID_UniteID]
		,[GestionVolume_Detail_Records].[UniteMesureID_Facteur_M3app]
		,[GestionVolume_Detail_Records].[UniteMesureID_Facteur_M3sol]
		,[GestionVolume_Detail_Records].[UniteMesureID_Actif]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_plan_conjoint]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_plan_conjoint_Override]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_fond_roulement]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_fond_roulement_Override]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_fond_forestier]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_fond_forestier_Override]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_divers]
		,[GestionVolume_Detail_Records].[UniteMesureID_Preleve_divers_Override]
		,[GestionVolume_Detail_Records].[UniteMesureID_UseMontant]

		From [fnGestionVolume_Detail_Full](@ID, @GestionVolumeID, @EssenceID, @UniteMesureID) As [GestionVolume_Detail_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


