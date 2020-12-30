

Create Function [fnContingentement_Unite_Display]
(
 @ContingentementID [int] = Null
,@UniteID [varchar](6) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ContingentementID] As [ID1]
,[UniteID] As [ID2]
,[UniteID] As [Display]
	
From [dbo].[Contingentement_Unite]

Where
    ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))

Order By [Display]
)


