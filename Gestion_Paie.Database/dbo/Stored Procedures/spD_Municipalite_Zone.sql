

Create Procedure [spD_Municipalite_Zone]

-- Delete a specific record from table [Municipalite_Zone]

(
 @ID [varchar](2) -- for [Municipalite_Zone].[ID] column
,@MunicipaliteID [varchar](6) -- for [Municipalite_Zone].[MunicipaliteID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Municipalite_Zone]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))

Set NoCount Off

Return(@@RowCount)


