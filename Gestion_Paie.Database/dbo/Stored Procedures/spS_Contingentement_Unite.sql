

Create Procedure [spS_Contingentement_Unite]

-- Retrieve specific records from the [Contingentement_Unite] table depending on the input parameters you supply.

(
 @ContingentementID [int] = Null -- for [Contingentement_Unite].[ContingentementID] column
,@UniteID [varchar](6) = Null -- for [Contingentement_Unite].[UniteID] column
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

		 [Contingentement_Unite_Records].[ContingentementID]
		,[Contingentement_Unite_Records].[UniteID]
		,[Contingentement_Unite_Records].[Facteur]

		From [fnContingentement_Unite](@ContingentementID, @UniteID) As [Contingentement_Unite_Records]
	End

Else

	Begin
		Select

		 [Contingentement_Unite_Records].[ContingentementID]
		,[Contingentement_Unite_Records].[UniteID]
		,[Contingentement_Unite_Records].[Facteur]

		From [fnContingentement_Unite](@ContingentementID, @UniteID) As [Contingentement_Unite_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


