CREATE FUNCTION [dbo].[fnGestionVolume_Detail_SelectDisplay]
(@ID INT=Null, @GestionVolumeID INT=Null, @EssenceID VARCHAR (6)=Null, @UniteMesureID VARCHAR (6)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
	 [GestionVolume_Detail].[ID]
	,[GestionVolume_Detail].[GestionVolumeID]
	,[GestionVolume1].[Display] [GestionVolumeID_Display]
	,[GestionVolume_Detail].[EssenceID]
	,[Essence_Unite2].[Display] [EssenceID_Display]
	,[GestionVolume_Detail].[UniteMesureID]
	,[Essence_Unite3].[Display] [UniteMesureID_Display]
	,[GestionVolume_Detail].[VolumeBrut]
	,[GestionVolume_Detail].[VolumeReduction]
	,[GestionVolume_Detail].[VolumeNet]

From [dbo].[GestionVolume_Detail]
    Left Outer Join [fnGestionVolume_Display](Null, Null, Null, Null, Null) [GestionVolume1] On [GestionVolumeID] = [GestionVolume1].[ID1]
        Left Outer Join [fnEssence_Unite_Display](Null, Null) [Essence_Unite2] On [EssenceID] = [Essence_Unite2].[ID1]
            Left Outer Join [fnEssence_Unite_Display](Null, Null) [Essence_Unite3] On [UniteMesureID] = [Essence_Unite3].[ID2]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@GestionVolumeID Is Null) Or ([GestionVolumeID] = @GestionVolumeID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))
)



