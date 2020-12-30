

Create Procedure [spS_Compte_Display]

(
 @ID [int] = Null -- for [Compte].[ID] column
,@CategoryID [int] = Null -- for [Compte].[CategoryID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Compte_Records].[ID1]
,[Compte_Records].[Display]

From [fnCompte_Display](@ID, @CategoryID) As [Compte_Records]

Return(@@RowCount)


