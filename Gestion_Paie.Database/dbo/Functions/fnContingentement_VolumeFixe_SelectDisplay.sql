
Create Function [fnContingentement_VolumeFixe_SelectDisplay]
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
	,[Contingentement1].[Display] [ContingentementID_Display]
	,[Contingentement_VolumeFixe].[Superficie_Min]
	,[Contingentement_VolumeFixe].[Volume_Fixe]
	,[Contingentement_VolumeFixe].[NombreMois]
	,[Contingentement_VolumeFixe].[UseNombreMois]

From [dbo].[Contingentement_VolumeFixe]
    Inner Join [fnContingentement_Display](Null, Null, Null, Null, Null) [Contingentement1] On [ContingentementID] = [Contingentement1].[ID1]

Where

    ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@Superficie_Min Is Null) Or ([Superficie_Min] = @Superficie_Min))
)

