

Create Procedure [spS_Municipalite_Zone_Display]

(
 @ID [varchar](2) = Null -- for [Municipalite_Zone].[ID] column
,@MunicipaliteID [varchar](6) = Null -- for [Municipalite_Zone].[MunicipaliteID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Municipalite_Zone_Records].[ID1]
,[Municipalite_Zone_Records].[ID2]
,[Municipalite_Zone_Records].[Display]

From [fnMunicipalite_Zone_Display](@ID, @MunicipaliteID) As [Municipalite_Zone_Records]

Return(@@RowCount)


