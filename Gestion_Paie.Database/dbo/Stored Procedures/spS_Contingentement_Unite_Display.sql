

Create Procedure [spS_Contingentement_Unite_Display]

(
 @ContingentementID [int] = Null -- for [Contingentement_Unite].[ContingentementID] column
,@UniteID [varchar](6) = Null -- for [Contingentement_Unite].[UniteID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Contingentement_Unite_Records].[ID1]
,[Contingentement_Unite_Records].[ID2]
,[Contingentement_Unite_Records].[Display]

From [fnContingentement_Unite_Display](@ContingentementID, @UniteID) As [Contingentement_Unite_Records]

Return(@@RowCount)


