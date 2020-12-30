

Create Procedure [spS_jag_ProfileSettings_Display]

(
 @ProfileID [int] = Null -- for [jag_ProfileSettings].[ProfileID] column
,@Name [varchar](500) = Null -- for [jag_ProfileSettings].[Name] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [jag_ProfileSettings_Records].[ID1]
,[jag_ProfileSettings_Records].[ID2]
,[jag_ProfileSettings_Records].[Display]

From [fnjag_ProfileSettings_Display](@ProfileID, @Name) As [jag_ProfileSettings_Records]

Return(@@RowCount)


