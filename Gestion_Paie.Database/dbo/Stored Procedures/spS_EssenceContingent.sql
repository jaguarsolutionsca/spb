

Create Procedure [spS_EssenceContingent]

-- Retrieve specific records from the [EssenceContingent] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [EssenceContingent].[ID] column
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

		 [EssenceContingent_Records].[ID]
		,[EssenceContingent_Records].[Description]
		,[EssenceContingent_Records].[Actif]

		From [fnEssenceContingent](@ID) As [EssenceContingent_Records]
	End

Else

	Begin
		Select

		 [EssenceContingent_Records].[ID]
		,[EssenceContingent_Records].[Description]
		,[EssenceContingent_Records].[Actif]

		From [fnEssenceContingent](@ID) As [EssenceContingent_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


