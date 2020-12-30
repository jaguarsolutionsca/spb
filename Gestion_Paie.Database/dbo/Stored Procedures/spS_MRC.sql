

Create Procedure [spS_MRC]

-- Retrieve specific records from the [MRC] table depending on the input parameters you supply.

(
 @ID [varchar](6) = Null -- for [MRC].[ID] column
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

		 [MRC_Records].[ID]
		,[MRC_Records].[Description]
		,[MRC_Records].[Actif]

		From [fnMRC](@ID) As [MRC_Records]
	End

Else

	Begin
		Select

		 [MRC_Records].[ID]
		,[MRC_Records].[Description]
		,[MRC_Records].[Actif]

		From [fnMRC](@ID) As [MRC_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


