

Create Procedure [spS_Lot_SuperficieBoisee_Full]

/*
Retrieve specific records from the [Lot_SuperficieBoisee] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Lot] (via [LotID])
*/

(
 @Annee [datetime] = Null -- for [Lot_SuperficieBoisee].[Annee] column
,@LotID [int] = Null -- for [Lot_SuperficieBoisee].[LotID] column
,@ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [Lot_SuperficieBoisee_Records].[Annee]
		,[Lot_SuperficieBoisee_Records].[Superficie_boisee]
		,[Lot_SuperficieBoisee_Records].[LotID]

		From [fnLot_SuperficieBoisee_Full](@Annee, @LotID) As [Lot_SuperficieBoisee_Records]
	End

Else

	Begin
		Select

		 [Lot_SuperficieBoisee_Records].[Annee]
		,[Lot_SuperficieBoisee_Records].[Superficie_boisee]
		,[Lot_SuperficieBoisee_Records].[LotID]

		From [fnLot_SuperficieBoisee_Full](@Annee, @LotID) As [Lot_SuperficieBoisee_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


