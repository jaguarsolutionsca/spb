

Create Procedure [spS_Municipalite_Full]

/*
Retrieve specific records from the [Municipalite] table, as well as all its foreign tables, depending on the input parameters you supply:
	[MRC] (via [MrcID])
	[Agence] (via [AgenceID])
*/

(
 @ID [varchar](6) = Null -- for [Municipalite].[ID] column
,@MrcID [varchar](6) = Null -- for [Municipalite].[MrcID] column
,@AgenceID [varchar](4) = Null -- for [Municipalite].[AgenceID] column
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

		 [Municipalite_Records].[ID]
		,[Municipalite_Records].[Description]
		,[Municipalite_Records].[MrcID]
		,[Municipalite_Records].[AgenceID]
		,[Municipalite_Records].[Actif]
		,[Municipalite_Records].[MrcID_ID]
		,[Municipalite_Records].[MrcID_Description]
		,[Municipalite_Records].[MrcID_Actif]
		,[Municipalite_Records].[AgenceID_ID]
		,[Municipalite_Records].[AgenceID_Description]
		,[Municipalite_Records].[AgenceID_Actif]

		From [fnMunicipalite_Full](@ID, @MrcID, @AgenceID) As [Municipalite_Records]
	End

Else

	Begin
		Select

		 [Municipalite_Records].[ID]
		,[Municipalite_Records].[Description]
		,[Municipalite_Records].[MrcID]
		,[Municipalite_Records].[AgenceID]
		,[Municipalite_Records].[Actif]
		,[Municipalite_Records].[MrcID_ID]
		,[Municipalite_Records].[MrcID_Description]
		,[Municipalite_Records].[MrcID_Actif]
		,[Municipalite_Records].[AgenceID_ID]
		,[Municipalite_Records].[AgenceID_Description]
		,[Municipalite_Records].[AgenceID_Actif]

		From [fnMunicipalite_Full](@ID, @MrcID, @AgenceID) As [Municipalite_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


