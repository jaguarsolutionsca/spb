

Create Procedure [spS_FactureClient_Details_Display]

(
 @FactureID [int] = Null -- for [FactureClient_Details].[FactureID] column
,@Ligne [int] = Null -- for [FactureClient_Details].[Ligne] column
,@Compte [int] = Null -- for [FactureClient_Details].[Compte] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [FactureClient_Details_Records].[ID1]
,[FactureClient_Details_Records].[ID2]
,[FactureClient_Details_Records].[Display]

From [fnFactureClient_Details_Display](@FactureID, @Ligne, @Compte) As [FactureClient_Details_Records]

Return(@@RowCount)


