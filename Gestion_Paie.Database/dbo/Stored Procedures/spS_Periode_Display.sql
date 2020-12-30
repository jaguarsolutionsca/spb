

Create Procedure [spS_Periode_Display]

(
 @Annee [int] = Null -- for [Periode].[Annee] column
,@SemaineNo [int] = Null -- for [Periode].[SemaineNo] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Periode_Records].[ID1]
,[Periode_Records].[ID2]
,[Periode_Records].[Display]

From [fnPeriode_Display](@Annee, @SemaineNo) As [Periode_Records]

Return(@@RowCount)


