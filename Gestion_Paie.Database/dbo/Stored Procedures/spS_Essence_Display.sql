

Create Procedure [spS_Essence_Display]

(
 @ID [varchar](6) = Null -- for [Essence].[ID] column
,@RegroupementID [int] = Null -- for [Essence].[RegroupementID] column
,@ContingentID [int] = Null -- for [Essence].[ContingentID] column
,@RepartitionID [int] = Null -- for [Essence].[RepartitionID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Essence_Records].[ID1]
,[Essence_Records].[Display]

From [fnEssence_Display](@ID, @RegroupementID, @ContingentID, @RepartitionID) As [Essence_Records]

Return(@@RowCount)


