

Create Procedure [spS_TypeFacture]

-- Retrieve specific records from the [TypeFacture] table depending on the input parameters you supply.

(
 @ID [char](1) = Null -- for [TypeFacture].[ID] column
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

		 [TypeFacture_Records].[ID]
		,[TypeFacture_Records].[Description]
		,[TypeFacture_Records].[FactureDescriptionMask]

		From [fnTypeFacture](@ID) As [TypeFacture_Records]
	End

Else

	Begin
		Select

		 [TypeFacture_Records].[ID]
		,[TypeFacture_Records].[Description]
		,[TypeFacture_Records].[FactureDescriptionMask]

		From [fnTypeFacture](@ID) As [TypeFacture_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


