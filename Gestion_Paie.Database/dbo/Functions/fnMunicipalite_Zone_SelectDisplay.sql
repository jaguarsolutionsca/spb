

Create Function [fnMunicipalite_Zone_SelectDisplay]
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
Select
	 [Municipalite_Zone].[ID]
	,[Municipalite_Zone].[MunicipaliteID]
	,[Municipalite1].[Display] [MunicipaliteID_Display]
	,[Municipalite_Zone].[Description]
	,[Municipalite_Zone].[Actif]

From [dbo].[Municipalite_Zone]
    Inner Join [fnMunicipalite_Display](Null, Null, Null) [Municipalite1] On [MunicipaliteID] = [Municipalite1].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
)


