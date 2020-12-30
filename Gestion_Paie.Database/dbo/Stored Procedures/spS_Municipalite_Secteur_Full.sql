

Create Procedure [spS_Municipalite_Secteur_Full]

/*
Retrieve specific records from the [Municipalite_Secteur] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Municipalite] (via [MunicipaliteID])
*/

(
 @MunicipaliteID [varchar](6) = Null -- for [Municipalite_Secteur].[MunicipaliteID] column
,@Secteur [varchar](2) = Null -- for [Municipalite_Secteur].[Secteur] column
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

		 [Municipalite_Secteur_Records].[MunicipaliteID]
		,[Municipalite_Secteur_Records].[Secteur]
		,[Municipalite_Secteur_Records].[Actif]

		From [fnMunicipalite_Secteur_Full](@MunicipaliteID, @Secteur) As [Municipalite_Secteur_Records]
	End

Else

	Begin
		Select

		 [Municipalite_Secteur_Records].[MunicipaliteID]
		,[Municipalite_Secteur_Records].[Secteur]
		,[Municipalite_Secteur_Records].[Actif]

		From [fnMunicipalite_Secteur_Full](@MunicipaliteID, @Secteur) As [Municipalite_Secteur_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


