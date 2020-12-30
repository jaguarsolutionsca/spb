

Create Procedure [spS_jag_ProfileSettings_SelectDisplay]

-- Retrieve specific records from the [jag_ProfileSettings] table depending on the input parameters you supply.

(
 @ProfileID [int] = Null -- for [jag_ProfileSettings].[ProfileID] column
,@Name [varchar](500) = Null -- for [jag_ProfileSettings].[Name] column
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

		 [jag_ProfileSettings_Records].[ProfileID]
		,[jag_ProfileSettings_Records].[ProfileID_Display]
		,[jag_ProfileSettings_Records].[Name]
		,[jag_ProfileSettings_Records].[Value]

		From [fnjag_ProfileSettings_SelectDisplay](@ProfileID, @Name) As [jag_ProfileSettings_Records]
	End

Else

	Begin
		Select

		 [jag_ProfileSettings_Records].[ProfileID]
		,[jag_ProfileSettings_Records].[ProfileID_Display]
		,[jag_ProfileSettings_Records].[Name]
		,[jag_ProfileSettings_Records].[Value]

		From [fnjag_ProfileSettings_SelectDisplay](@ProfileID, @Name) As [jag_ProfileSettings_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


