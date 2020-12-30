

Create Function [fnContingentement_Unite_SelectDisplay]
(
 @ContingentementID [int] = Null
,@UniteID [varchar](6) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [Contingentement_Unite].[ContingentementID]
	,[Contingentement1].[Display] [ContingentementID_Display]
	,[Contingentement_Unite].[UniteID]
	,[UniteMesure2].[Display] [UniteID_Display]
	,[Contingentement_Unite].[Facteur]

From [dbo].[Contingentement_Unite]
    Inner Join [fnContingentement_Display](Null, Null, Null, Null, Null) [Contingentement1] On [ContingentementID] = [Contingentement1].[ID1]
        Inner Join [fnUniteMesure_Display](Null) [UniteMesure2] On [UniteID] = [UniteMesure2].[ID1]

Where

    ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
)


