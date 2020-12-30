

CREATE Procedure [spD_Indexation_Municipalite]

-- Delete a specific record from table [Indexation_Municipalite]

(
 @ID [int] -- for [Indexation_Municipalite].[ID] column
,@IndexationID [int] = Null -- for [Indexation_Municipalite].[IndexationID] column
,@MunicipaliteID [varchar](6) = Null -- for [Indexation_Municipalite].[MunicipaliteID] column
,@ZoneID [varchar](2) = Null -- for [Indexation_Municipalite].[ZoneID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Indexation_Municipalite]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@IndexationID Is Null) Or ([IndexationID] = @IndexationID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@ZoneID Is Null) Or ([ZoneID] = @ZoneID))

Set NoCount Off

Return(@@RowCount)


