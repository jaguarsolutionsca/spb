

Create Procedure [spS_MRCCorrection]

-- Retrieve specific records from the [MRCCorrection] table depending on the input parameters you supply.

(
 @ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
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

		 [MRCCorrection_Records].[CodeMRC]
		,[MRCCorrection_Records].[CodeCIEL]

		From [fnMRCCorrection]() As [MRCCorrection_Records]
	End

Else

	Begin
		Select

		 [MRCCorrection_Records].[CodeMRC]
		,[MRCCorrection_Records].[CodeCIEL]

		From [fnMRCCorrection]() As [MRCCorrection_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


