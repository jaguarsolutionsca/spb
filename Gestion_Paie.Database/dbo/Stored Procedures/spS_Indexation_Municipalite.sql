

CREATE Procedure [spS_Indexation_Municipalite]

-- Retrieve specific records from the [Indexation_Municipalite] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [Indexation_Municipalite].[ID] column
,@IndexationID [int] = Null -- for [Indexation_Municipalite].[IndexationID] column
,@MunicipaliteID [varchar](6) = Null -- for [Indexation_Municipalite].[MunicipaliteID] column
,@ZoneID [varchar](2) = Null -- for [Indexation_Municipalite].[ZoneID] column
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

		 [Indexation_Municipalite_Records].[ID]
		,[Indexation_Municipalite_Records].[IndexationID]
		,[Indexation_Municipalite_Records].[MunicipaliteID]
		,[Indexation_Municipalite_Records].[Montant]
		,[Indexation_Municipalite_Records].[ZoneID]

		From [fnIndexation_Municipalite](@ID, @IndexationID, @MunicipaliteID, @ZoneID) As [Indexation_Municipalite_Records]
	End

Else

	Begin
		Select

		 [Indexation_Municipalite_Records].[ID]
		,[Indexation_Municipalite_Records].[IndexationID]
		,[Indexation_Municipalite_Records].[MunicipaliteID]
		,[Indexation_Municipalite_Records].[Montant]
		,[Indexation_Municipalite_Records].[ZoneID]

		From [fnIndexation_Municipalite](@ID, @IndexationID, @MunicipaliteID, @ZoneID) As [Indexation_Municipalite_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


