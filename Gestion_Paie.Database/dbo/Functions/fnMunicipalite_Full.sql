

Create Function [fnMunicipalite_Full]

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
 [Municipalite].[ID]
,[Municipalite].[Description]
,[Municipalite].[MrcID]
,[Municipalite].[AgenceID]
,[Municipalite].[Actif]
,[MRC1].[ID] [MrcID_ID]
,[MRC1].[Description] [MrcID_Description]
,[MRC1].[Actif] [MrcID_Actif]
,[Agence2].[ID] [AgenceID_ID]
,[Agence2].[Description] [AgenceID_Description]
,[Agence2].[Actif] [AgenceID_Actif]

From [dbo].[Municipalite] [Municipalite]
    Left Outer Join [dbo].[MRC] [MRC1] On [Municipalite].[MrcID] = [MRC1].[ID]
        Left Outer Join [dbo].[Agence] [Agence2] On [Municipalite].[AgenceID] = [Agence2].[ID]

Where

    ((@ID Is Null) Or ([Municipalite].[ID] = @ID))
And ((@MrcID Is Null) Or ([Municipalite].[MrcID] = @MrcID))
And ((@AgenceID Is Null) Or ([Municipalite].[AgenceID] = @AgenceID))
)



