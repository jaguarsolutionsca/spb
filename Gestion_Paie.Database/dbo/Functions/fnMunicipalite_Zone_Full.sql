

Create Function [fnMunicipalite_Zone_Full]

(
 @ID [varchar](2) = Null
,@MunicipaliteID [varchar](6) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Municipalite_Zone].[ID]
,[Municipalite_Zone].[MunicipaliteID]
,[Municipalite_Zone].[Description]
,[Municipalite_Zone].[Actif]
,[Municipalite1].[ID] [MunicipaliteID_ID]
,[Municipalite1].[Description] [MunicipaliteID_Description]
,[Municipalite1].[MrcID] [MunicipaliteID_MrcID]
,[Municipalite1].[AgenceID] [MunicipaliteID_AgenceID]
,[Municipalite1].[Actif] [MunicipaliteID_Actif]

From [dbo].[Municipalite_Zone] [Municipalite_Zone]
    Inner Join [dbo].[Municipalite] [Municipalite1] On [Municipalite_Zone].[MunicipaliteID] = [Municipalite1].[ID]

Where

    ((@ID Is Null) Or ([Municipalite_Zone].[ID] = @ID))
And ((@MunicipaliteID Is Null) Or ([Municipalite_Zone].[MunicipaliteID] = @MunicipaliteID))
)



