

Create Procedure [spS_jag_SystemEx_Display]

(
 @Name [varchar](50) = Null -- for [jag_SystemEx].[Name] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [jag_SystemEx_Records].[ID1]
,[jag_SystemEx_Records].[Display]

From [fnjag_SystemEx_Display](@Name) As [jag_SystemEx_Records]

Return(@@RowCount)


