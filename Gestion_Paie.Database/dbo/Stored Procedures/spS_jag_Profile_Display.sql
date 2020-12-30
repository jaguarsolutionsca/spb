

Create Procedure [spS_jag_Profile_Display]

(
 @ID [int] = Null -- for [jag_Profile].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [jag_Profile_Records].[ID1]
,[jag_Profile_Records].[Display]

From [fnjag_Profile_Display](@ID) As [jag_Profile_Records]

Return(@@RowCount)


