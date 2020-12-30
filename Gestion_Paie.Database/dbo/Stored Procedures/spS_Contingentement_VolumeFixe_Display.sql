
Create Procedure [spS_Contingentement_VolumeFixe_Display]

(
 @ContingentementID [int] = Null -- for [Contingentement_VolumeFixe].[ContingentementID] column
,@Superficie_Min [real] = Null -- for [Contingentement_VolumeFixe].[Superficie_Min] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Contingentement_VolumeFixe_Records].[ID1]
,[Contingentement_VolumeFixe_Records].[ID2]
,[Contingentement_VolumeFixe_Records].[Display]

From [fnContingentement_VolumeFixe_Display](@ContingentementID, @Superficie_Min) As [Contingentement_VolumeFixe_Records]

Return(@@RowCount)

