

Create Procedure [spS_GestionVolume_Detail_SelectDisplay]

-- Retrieve specific records from the [GestionVolume_Detail] table depending on the input parameters you supply.

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
		,[GestionVolume_Detail_Records].[GestionVolumeID_Display]
		,[GestionVolume_Detail_Records].[EssenceID]
		,[GestionVolume_Detail_Records].[EssenceID_Display]
		,[GestionVolume_Detail_Records].[UniteMesureID]
		,[GestionVolume_Detail_Records].[UniteMesureID_Display]
		,[GestionVolume_Detail_Records].[VolumeBrut]
		,[GestionVolume_Detail_Records].[VolumeReduction]
		,[GestionVolume_Detail_Records].[VolumeNet]

		From [fnGestionVolume_Detail_SelectDisplay](@ID, @GestionVolumeID, @EssenceID, @UniteMesureID) As [GestionVolume_Detail_Records]
	End

Else

	Begin
		Select

		 [GestionVolume_Detail_Records].[ID]
		,[GestionVolume_Detail_Records].[GestionVolumeID]
		,[GestionVolume_Detail_Records].[GestionVolumeID_Display]
		,[GestionVolume_Detail_Records].[EssenceID]
		,[GestionVolume_Detail_Records].[EssenceID_Display]
		,[GestionVolume_Detail_Records].[UniteMesureID]
		,[GestionVolume_Detail_Records].[UniteMesureID_Display]
		,[GestionVolume_Detail_Records].[VolumeBrut]
		,[GestionVolume_Detail_Records].[VolumeReduction]
		,[GestionVolume_Detail_Records].[VolumeNet]

		From [fnGestionVolume_Detail_SelectDisplay](@ID, @GestionVolumeID, @EssenceID, @UniteMesureID) As [GestionVolume_Detail_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


