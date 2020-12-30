

Create Procedure [spS_Lot_SuperficieBoisee_Display]

(
 @Annee [datetime] = Null -- for [Lot_SuperficieBoisee].[Annee] column
,@LotID [int] = Null -- for [Lot_SuperficieBoisee].[LotID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Lot_SuperficieBoisee_Records].[ID1]
,[Lot_SuperficieBoisee_Records].[ID2]
,[Lot_SuperficieBoisee_Records].[Display]

From [fnLot_SuperficieBoisee_Display](@Annee, @LotID) As [Lot_SuperficieBoisee_Records]

Return(@@RowCount)


