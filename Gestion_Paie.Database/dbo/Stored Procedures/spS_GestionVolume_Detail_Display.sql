

Create Procedure [spS_GestionVolume_Detail_Display]

(
 @ID [int] = Null -- for [GestionVolume_Detail].[ID] column
,@GestionVolumeID [int] = Null -- for [GestionVolume_Detail].[GestionVolumeID] column
,@EssenceID [varchar](6) = Null -- for [GestionVolume_Detail].[EssenceID] column
,@UniteMesureID [varchar](6) = Null -- for [GestionVolume_Detail].[UniteMesureID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [GestionVolume_Detail_Records].[ID1]
,[GestionVolume_Detail_Records].[Display]

From [fnGestionVolume_Detail_Display](@ID, @GestionVolumeID, @EssenceID, @UniteMesureID) As [GestionVolume_Detail_Records]

Return(@@RowCount)


