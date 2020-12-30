

Create Procedure [spS_Canton]

-- Retrieve specific records from the [Canton] table depending on the input parameters you supply.

(
 @ID [varchar](6) = Null -- for [Canton].[ID] column
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

		 [Canton_Records].[ID]
		,[Canton_Records].[Description]
		,[Canton_Records].[Actif]

		From [fnCanton](@ID) As [Canton_Records]
	End

Else

	Begin
		Select

		 [Canton_Records].[ID]
		,[Canton_Records].[Description]
		,[Canton_Records].[Actif]

		From [fnCanton](@ID) As [Canton_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


