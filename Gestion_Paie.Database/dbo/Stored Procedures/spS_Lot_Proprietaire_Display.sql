

Create Procedure [spS_Lot_Proprietaire_Display]

(
 @ProprietaireID [varchar](15) = Null -- for [Lot_Proprietaire].[ProprietaireID] column
,@DateDebut [datetime] = Null -- for [Lot_Proprietaire].[DateDebut] column
,@LotID [int] = Null -- for [Lot_Proprietaire].[LotID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Lot_Proprietaire_Records].[ID1]
,[Lot_Proprietaire_Records].[ID2]
,[Lot_Proprietaire_Records].[ID3]
,[Lot_Proprietaire_Records].[Display]

From [fnLot_Proprietaire_Display](@ProprietaireID, @DateDebut, @LotID) As [Lot_Proprietaire_Records]

Return(@@RowCount)


