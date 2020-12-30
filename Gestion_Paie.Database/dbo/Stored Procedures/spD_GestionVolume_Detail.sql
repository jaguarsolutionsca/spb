

Create Procedure [spD_GestionVolume_Detail]

-- Delete a specific record from table [GestionVolume_Detail]

(
 @ID [int] -- for [GestionVolume_Detail].[ID] column
,@GestionVolumeID [int] = Null -- for [GestionVolume_Detail].[GestionVolumeID] column
,@EssenceID [varchar](6) = Null -- for [GestionVolume_Detail].[EssenceID] column
,@UniteMesureID [varchar](6) = Null -- for [GestionVolume_Detail].[UniteMesureID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[GestionVolume_Detail]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@GestionVolumeID Is Null) Or ([GestionVolumeID] = @GestionVolumeID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))

Set NoCount Off

Return(@@RowCount)


