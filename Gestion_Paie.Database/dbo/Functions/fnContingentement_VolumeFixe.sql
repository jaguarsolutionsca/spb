
CREATE Function [fnContingentement_VolumeFixe]
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
Select TOP 100 PERCENT
 [ContingentementID]
,[Superficie_Min]
,[Volume_Fixe]
,[NombreMois]
,[UseNombreMois]

From [dbo].[Contingentement_VolumeFixe]

Where

    ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@Superficie_Min Is Null) Or ([Superficie_Min] = @Superficie_Min))
)

