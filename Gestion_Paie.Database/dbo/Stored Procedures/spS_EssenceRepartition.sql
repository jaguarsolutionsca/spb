

Create Procedure [spS_EssenceRepartition]

-- Retrieve specific records from the [EssenceRepartition] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [EssenceRepartition].[ID] column
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

		 [EssenceRepartition_Records].[ID]
		,[EssenceRepartition_Records].[Description]
		,[EssenceRepartition_Records].[Actif]

		From [fnEssenceRepartition](@ID) As [EssenceRepartition_Records]
	End

Else

	Begin
		Select

		 [EssenceRepartition_Records].[ID]
		,[EssenceRepartition_Records].[Description]
		,[EssenceRepartition_Records].[Actif]

		From [fnEssenceRepartition](@ID) As [EssenceRepartition_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


