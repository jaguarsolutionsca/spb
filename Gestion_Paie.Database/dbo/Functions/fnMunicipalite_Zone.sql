

Create Function [fnMunicipalite_Zone]
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
 [ID]
,[MunicipaliteID]
,[Description]
,[Actif]

From [dbo].[Municipalite_Zone]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
)


