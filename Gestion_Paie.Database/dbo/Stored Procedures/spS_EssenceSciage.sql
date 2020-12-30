

Create Procedure [spS_EssenceSciage]

-- Retrieve specific records from the [EssenceSciage] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [EssenceSciage].[ID] column
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

		 [EssenceSciage_Records].[ID]
		,[EssenceSciage_Records].[Description]

		From [fnEssenceSciage](@ID) As [EssenceSciage_Records]
	End

Else

	Begin
		Select

		 [EssenceSciage_Records].[ID]
		,[EssenceSciage_Records].[Description]

		From [fnEssenceSciage](@ID) As [EssenceSciage_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


