

Create Procedure [spS_FactureClient_Sommaire_Display]

(
 @FactureID [int] = Null -- for [FactureClient_Sommaire].[FactureID] column
,@Ligne [int] = Null -- for [FactureClient_Sommaire].[Ligne] column
,@Compte [int] = Null -- for [FactureClient_Sommaire].[Compte] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [FactureClient_Sommaire_Records].[ID1]
,[FactureClient_Sommaire_Records].[ID2]
,[FactureClient_Sommaire_Records].[Display]

From [fnFactureClient_Sommaire_Display](@FactureID, @Ligne, @Compte) As [FactureClient_Sommaire_Records]

Return(@@RowCount)


