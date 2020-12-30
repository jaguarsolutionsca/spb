
Create Function [fnContingentement_VolumeFixe_Display]
(
 @ContingentementID [int] = Null
,@Superficie_Min [real] = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ContingentementID] As [ID1]
,[Superficie_Min] As [ID2]
,[Superficie_Min] As [Display]
	
From [dbo].[Contingentement_VolumeFixe]

Where
    ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@Superficie_Min Is Null) Or ([Superficie_Min] = @Superficie_Min))

Order By [Display]
)

