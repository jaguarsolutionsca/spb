

Create Procedure [spS_Municipalite_Zone_Full]

/*
Retrieve specific records from the [Municipalite_Zone] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Municipalite] (via [MunicipaliteID])
*/

(
 @ID [varchar](2) = Null -- for [Municipalite_Zone].[ID] column
,@MunicipaliteID [varchar](6) = Null -- for [Municipalite_Zone].[MunicipaliteID] column
,@ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [Municipalite_Zone_Records].[ID]
		,[Municipalite_Zone_Records].[MunicipaliteID]
		,[Municipalite_Zone_Records].[Description]
		,[Municipalite_Zone_Records].[Actif]

		From [fnMunicipalite_Zone_Full](@ID, @MunicipaliteID) As [Municipalite_Zone_Records]
	End

Else

	Begin
		Select

		 [Municipalite_Zone_Records].[ID]
		,[Municipalite_Zone_Records].[MunicipaliteID]
		,[Municipalite_Zone_Records].[Description]
		,[Municipalite_Zone_Records].[Actif]

		From [fnMunicipalite_Zone_Full](@ID, @MunicipaliteID) As [Municipalite_Zone_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


