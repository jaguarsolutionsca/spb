

Create Procedure [spS_Indexation_Municipalite_Display]

(
 @ID [int] = Null -- for [Indexation_Municipalite].[ID] column
,@IndexationID [int] = Null -- for [Indexation_Municipalite].[IndexationID] column
,@MunicipaliteID [varchar](6) = Null -- for [Indexation_Municipalite].[MunicipaliteID] column
,@ZoneID [varchar](2) = Null -- for [Indexation_Municipalite].[ZoneID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Indexation_Municipalite_Records].[ID1]
,[Indexation_Municipalite_Records].[Display]

From [fnIndexation_Municipalite_Display](@ID, @IndexationID, @MunicipaliteID, @ZoneID) As [Indexation_Municipalite_Records]

Return(@@RowCount)


