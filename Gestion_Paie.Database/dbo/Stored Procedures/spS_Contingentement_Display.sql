

Create Procedure [spS_Contingentement_Display]

(
 @ID [int] = Null -- for [Contingentement].[ID] column
,@UsineID [varchar](6) = Null -- for [Contingentement].[UsineID] column
,@RegroupementID [int] = Null -- for [Contingentement].[RegroupementID] column
,@EssenceID [varchar](6) = Null -- for [Contingentement].[EssenceID] column
,@UniteMesureID [varchar](6) = Null -- for [Contingentement].[UniteMesureID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Contingentement_Records].[ID1]
,[Contingentement_Records].[Display]

From [fnContingentement_Display](@ID, @UsineID, @RegroupementID, @EssenceID, @UniteMesureID) As [Contingentement_Records]

Return(@@RowCount)


