

Create Function [fnMunicipalite]
(
 @ID [varchar](6) = Null
,@MrcID [varchar](6) = Null
,@AgenceID [varchar](4) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID]
,[Description]
,[MrcID]
,[AgenceID]
,[Actif]

From [dbo].[Municipalite]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@MrcID Is Null) Or ([MrcID] = @MrcID))
And ((@AgenceID Is Null) Or ([AgenceID] = @AgenceID))
)


