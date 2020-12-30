

Create Procedure [spS_jag_SystemEx]

-- Retrieve specific records from the [jag_SystemEx] table depending on the input parameters you supply.

(
 @Name [varchar](50) = Null -- for [jag_SystemEx].[Name] column
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

		 [jag_SystemEx_Records].[Name]
		,[jag_SystemEx_Records].[Value]

		From [fnjag_SystemEx](@Name) As [jag_SystemEx_Records]
	End

Else

	Begin
		Select

		 [jag_SystemEx_Records].[Name]
		,[jag_SystemEx_Records].[Value]

		From [fnjag_SystemEx](@Name) As [jag_SystemEx_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


