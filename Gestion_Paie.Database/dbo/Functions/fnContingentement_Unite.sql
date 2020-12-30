

Create Function [fnContingentement_Unite]
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
Select TOP 100 PERCENT
 [ContingentementID]
,[UniteID]
,[Facteur]

From [dbo].[Contingentement_Unite]

Where

    ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
)


