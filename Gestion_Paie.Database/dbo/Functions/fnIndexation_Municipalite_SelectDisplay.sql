

CREATE Function [fnIndexation_Municipalite_SelectDisplay]
(
 @ID [int] = Null
,@IndexationID [int] = Null
,@MunicipaliteID [varchar](6) = Null
,@ZoneID [varchar](2) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [Indexation_Municipalite].[ID]
	,[Indexation_Municipalite].[IndexationID]
	,[Indexation1].[Display] [IndexationID_Display]
	,[Indexation_Municipalite].[MunicipaliteID]
	,[Municipalite_Zone2].[Display] [MunicipaliteID_Display]
	,[Indexation_Municipalite].[Montant]
	,[Indexation_Municipalite].[ZoneID]
	,[Municipalite_Zone3].[Display] [ZoneID_Display]

From [dbo].[Indexation_Municipalite]
    Left Outer Join [fnIndexation_Display](Null, Null, Null) [Indexation1] On [IndexationID] = [Indexation1].[ID1]
        Left Outer Join [fnMunicipalite_Zone_Display](Null, Null) [Municipalite_Zone2] On [MunicipaliteID] = [Municipalite_Zone2].[ID2]
            Left Outer Join [fnMunicipalite_Zone_Display](Null, Null) [Municipalite_Zone3] On [ZoneID] = [Municipalite_Zone3].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@IndexationID Is Null) Or ([IndexationID] = @IndexationID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))
)


