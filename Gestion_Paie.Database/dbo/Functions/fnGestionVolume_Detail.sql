

Create Function [fnGestionVolume_Detail]
(
 @ID [int] = Null
,@GestionVolumeID [int] = Null
,@EssenceID [varchar](6) = Null
,@UniteMesureID [varchar](6) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID]
,[GestionVolumeID]
,[EssenceID]
,[UniteMesureID]
,[VolumeBrut]
,[VolumeReduction]
,[VolumeNet]

From [dbo].[GestionVolume_Detail]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@GestionVolumeID Is Null) Or ([GestionVolumeID] = @GestionVolumeID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))
)


