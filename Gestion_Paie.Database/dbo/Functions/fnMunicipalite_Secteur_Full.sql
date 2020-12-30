

Create Function [fnMunicipalite_Secteur_Full]

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
Select TOP 100 PERCENT
 [Municipalite_Secteur].[MunicipaliteID]
,[Municipalite_Secteur].[Secteur]
,[Municipalite_Secteur].[Actif]
,[Municipalite1].[ID] [MunicipaliteID_ID]
,[Municipalite1].[Description] [MunicipaliteID_Description]
,[Municipalite1].[MrcID] [MunicipaliteID_MrcID]
,[Municipalite1].[AgenceID] [MunicipaliteID_AgenceID]
,[Municipalite1].[Actif] [MunicipaliteID_Actif]

From [dbo].[Municipalite_Secteur] [Municipalite_Secteur]
    Inner Join [dbo].[Municipalite] [Municipalite1] On [Municipalite_Secteur].[MunicipaliteID] = [Municipalite1].[ID]

Where

    ((@MunicipaliteID Is Null) Or ([Municipalite_Secteur].[MunicipaliteID] = @MunicipaliteID))
And ((@Secteur Is Null) Or ([Municipalite_Secteur].[Secteur] = @Secteur))
)



