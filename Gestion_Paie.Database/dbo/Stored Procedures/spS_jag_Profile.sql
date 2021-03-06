﻿

Create Procedure [spS_jag_Profile]

-- Retrieve specific records from the [jag_Profile] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [jag_Profile].[ID] column
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

		 [jag_Profile_Records].[ID]
		,[jag_Profile_Records].[Nom]
		,[jag_Profile_Records].[Password]

		From [fnjag_Profile](@ID) As [jag_Profile_Records]
	End

Else

	Begin
		Select

		 [jag_Profile_Records].[ID]
		,[jag_Profile_Records].[Nom]
		,[jag_Profile_Records].[Password]

		From [fnjag_Profile](@ID) As [jag_Profile_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


