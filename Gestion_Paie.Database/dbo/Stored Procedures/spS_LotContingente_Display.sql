

Create Procedure [spS_LotContingente_Display]

(
 @LotID [int] = Null -- for [LotContingente].[LotID] column
,@Annee [int] = Null -- for [LotContingente].[Annee] column
,@FournisseurID [varchar](15) = Null -- for [LotContingente].[FournisseurID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [LotContingente_Records].[ID1]
,[LotContingente_Records].[ID2]
,[LotContingente_Records].[ID3]
,[LotContingente_Records].[Display]

From [fnLotContingente_Display](@LotID, @Annee, @FournisseurID) As [LotContingente_Records]

Return(@@RowCount)


