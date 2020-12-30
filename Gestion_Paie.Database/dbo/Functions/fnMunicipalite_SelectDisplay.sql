

Create Function [fnMunicipalite_SelectDisplay]
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
Select
	 [Municipalite].[ID]
	,[Municipalite].[Description]
	,[Municipalite].[MrcID]
	,[MRC1].[Display] [MrcID_Display]
	,[Municipalite].[AgenceID]
	,[Agence2].[Display] [AgenceID_Display]
	,[Municipalite].[Actif]

From [dbo].[Municipalite]
    Left Outer Join [fnMRC_Display](Null) [MRC1] On [MrcID] = [MRC1].[ID1]
        Left Outer Join [fnAgence_Display](Null) [Agence2] On [AgenceID] = [Agence2].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@MrcID Is Null) Or ([MrcID] = @MrcID))
And ((@AgenceID Is Null) Or ([AgenceID] = @AgenceID))
)


