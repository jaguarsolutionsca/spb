

Create Procedure [spS_FactureClient_Details_SelectDisplay]

-- Retrieve specific records from the [FactureClient_Details] table depending on the input parameters you supply.

(
 @FactureID [int] = Null -- for [FactureClient_Details].[FactureID] column
,@Ligne [int] = Null -- for [FactureClient_Details].[Ligne] column
,@Compte [int] = Null -- for [FactureClient_Details].[Compte] column
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

		 [FactureClient_Details_Records].[FactureID]
		,[FactureClient_Details_Records].[FactureID_Display]
		,[FactureClient_Details_Records].[Ligne]
		,[FactureClient_Details_Records].[Compte]
		,[FactureClient_Details_Records].[Compte_Display]
		,[FactureClient_Details_Records].[Montant]
		,[FactureClient_Details_Records].[RefID]

		From [fnFactureClient_Details_SelectDisplay](@FactureID, @Ligne, @Compte) As [FactureClient_Details_Records]
	End

Else

	Begin
		Select

		 [FactureClient_Details_Records].[FactureID]
		,[FactureClient_Details_Records].[FactureID_Display]
		,[FactureClient_Details_Records].[Ligne]
		,[FactureClient_Details_Records].[Compte]
		,[FactureClient_Details_Records].[Compte_Display]
		,[FactureClient_Details_Records].[Montant]
		,[FactureClient_Details_Records].[RefID]

		From [fnFactureClient_Details_SelectDisplay](@FactureID, @Ligne, @Compte) As [FactureClient_Details_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


