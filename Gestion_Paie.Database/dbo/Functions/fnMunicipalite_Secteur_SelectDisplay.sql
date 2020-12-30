

Create Function [fnMunicipalite_Secteur_SelectDisplay]
(
 @MunicipaliteID [varchar](6) = Null
,@Secteur [varchar](2) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [Municipalite_Secteur].[MunicipaliteID]
	,[Municipalite1].[Display] [MunicipaliteID_Display]
	,[Municipalite_Secteur].[Secteur]
	,[Municipalite_Secteur].[Actif]

From [dbo].[Municipalite_Secteur]
    Inner Join [fnMunicipalite_Display](Null, Null, Null) [Municipalite1] On [MunicipaliteID] = [Municipalite1].[ID1]

Where

    ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@Secteur Is Null) Or ([Secteur] = @Secteur))
)


