

Create Function [fnMunicipalite_Secteur]
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
 [MunicipaliteID]
,[Secteur]
,[Actif]

From [dbo].[Municipalite_Secteur]

Where

    ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@Secteur Is Null) Or ([Secteur] = @Secteur))
)


