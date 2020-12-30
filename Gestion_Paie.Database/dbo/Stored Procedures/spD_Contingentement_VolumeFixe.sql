
CREATE Procedure [spD_Contingentement_VolumeFixe]

-- Delete a specific record from table [Contingentement_VolumeFixe]

(
 @ContingentementID [int] -- for [Contingentement_VolumeFixe].[ContingentementID] column
,@Superficie_Min [real] -- for [Contingentement_VolumeFixe].[Superficie_Min] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Contingentement_VolumeFixe]

Where
    ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@Superficie_Min Is Null) Or ([Superficie_Min] = @Superficie_Min))

Set NoCount Off

Return(@@RowCount)

