

Create Procedure [spD_Municipalite_Secteur]

-- Delete a specific record from table [Municipalite_Secteur]

(
 @MunicipaliteID [varchar](6) -- for [Municipalite_Secteur].[MunicipaliteID] column
,@Secteur [varchar](2) -- for [Municipalite_Secteur].[Secteur] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Municipalite_Secteur]

Where
    ((@MunicipaliteID Is Null) Or ([MunicipaliteID] = @MunicipaliteID))
And ((@Secteur Is Null) Or ([Secteur] = @Secteur))

Set NoCount Off

Return(@@RowCount)


