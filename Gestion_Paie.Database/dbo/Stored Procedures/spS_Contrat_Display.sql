

Create Procedure [spS_Contrat_Display]

(
 @ID [varchar](10) = Null -- for [Contrat].[ID] column
,@UsineID [varchar](6) = Null -- for [Contrat].[UsineID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Contrat_Records].[ID1]
,[Contrat_Records].[Display]

From [fnContrat_Display](@ID, @UsineID) As [Contrat_Records]

Return(@@RowCount)


