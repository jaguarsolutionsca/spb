
Create Procedure [spS_FeuilletDomtar_Display]

(
 @Transaction [varchar](15) = Null -- for [FeuilletDomtar].[Transaction] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [FeuilletDomtar_Records].[ID1]
,[FeuilletDomtar_Records].[Display]

From [fnFeuilletDomtar_Display](@Transaction) As [FeuilletDomtar_Records]

Return(@@RowCount)

