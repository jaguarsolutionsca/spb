








CREATE Procedure jag_ListView_Lot_SuperficieBoisee

-- Retrieve specific records from the [Lot_SuperficieBoisee] table depending on the input parameters you supply.

(
 @LotID [int] = Null -- for [Lot_SuperficieBoisee].[Lot] column
,@Annee [smalldatetime] = Null -- for [Lot_SuperficieBoisee].[Annee] column
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


		Select

		[Lot_SuperficieBoisee_Records].[Annee] AS [Date]
		,[Lot_SuperficieBoisee_Records].[Superficie_boisee]

		From [fnLot_SuperficieBoisee](@Annee, @LotID) As [Lot_SuperficieBoisee_Records]
		
		order by [Lot_SuperficieBoisee_Records].[Annee] desc
		


Return(@@RowCount)




