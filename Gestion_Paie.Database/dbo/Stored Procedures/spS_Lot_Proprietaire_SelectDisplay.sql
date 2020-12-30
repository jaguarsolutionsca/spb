

Create Procedure [spS_Lot_Proprietaire_SelectDisplay]

-- Retrieve specific records from the [Lot_Proprietaire] table depending on the input parameters you supply.

(
 @ProprietaireID [varchar](15) = Null -- for [Lot_Proprietaire].[ProprietaireID] column
,@DateDebut [datetime] = Null -- for [Lot_Proprietaire].[DateDebut] column
,@LotID [int] = Null -- for [Lot_Proprietaire].[LotID] column
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

		 [Lot_Proprietaire_Records].[ProprietaireID]
		,[Lot_Proprietaire_Records].[ProprietaireID_Display]
		,[Lot_Proprietaire_Records].[DateDebut]
		,[Lot_Proprietaire_Records].[DateFin]
		,[Lot_Proprietaire_Records].[LotID]
		,[Lot_Proprietaire_Records].[LotID_Display]

		From [fnLot_Proprietaire_SelectDisplay](@ProprietaireID, @DateDebut, @LotID) As [Lot_Proprietaire_Records]
	End

Else

	Begin
		Select

		 [Lot_Proprietaire_Records].[ProprietaireID]
		,[Lot_Proprietaire_Records].[ProprietaireID_Display]
		,[Lot_Proprietaire_Records].[DateDebut]
		,[Lot_Proprietaire_Records].[DateFin]
		,[Lot_Proprietaire_Records].[LotID]
		,[Lot_Proprietaire_Records].[LotID_Display]

		From [fnLot_Proprietaire_SelectDisplay](@ProprietaireID, @DateDebut, @LotID) As [Lot_Proprietaire_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


