

Create Procedure [spS_Municipalite_Display]

(
 @ID [varchar](6) = Null -- for [Municipalite].[ID] column
,@MrcID [varchar](6) = Null -- for [Municipalite].[MrcID] column
,@AgenceID [varchar](4) = Null -- for [Municipalite].[AgenceID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Municipalite_Records].[ID1]
,[Municipalite_Records].[Display]

From [fnMunicipalite_Display](@ID, @MrcID, @AgenceID) As [Municipalite_Records]

Return(@@RowCount)


