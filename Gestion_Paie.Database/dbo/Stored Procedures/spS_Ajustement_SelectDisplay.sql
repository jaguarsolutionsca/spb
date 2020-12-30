
CREATE Procedure [spS_Ajustement_SelectDisplay]

-- Retrieve specific records from the [Ajustement] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [Ajustement].[ID] column
,@ContratID [varchar](10) = Null -- for [Ajustement].[ContratID] column
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

		 [Ajustement_Records].[ID]
		,[Ajustement_Records].[ContratID]
		,[Ajustement_Records].[ContratID_Display]
		,[Ajustement_Records].[DateAjustement]
		,[Ajustement_Records].[Periode_Debut]
		,[Ajustement_Records].[Periode_Fin]
		,[Ajustement_Records].[Facture]
		,[Ajustement_Records].[UsePeriodes]
		,[Ajustement_Records].[Date_Debut]
		,[Ajustement_Records].[Date_Fin]
		,[Ajustement_Records].[ProducteurID]
		,[Ajustement_Records].[TransporteurID]
		,[Ajustement_Records].[IsRistourne]

		From [fnAjustement_SelectDisplay](@ID, @ContratID) As [Ajustement_Records]
	End

Else

	Begin
		Select

		 [Ajustement_Records].[ID]
		,[Ajustement_Records].[ContratID]
		,[Ajustement_Records].[ContratID_Display]
		,[Ajustement_Records].[DateAjustement]
		,[Ajustement_Records].[Periode_Debut]
		,[Ajustement_Records].[Periode_Fin]
		,[Ajustement_Records].[Facture]
		,[Ajustement_Records].[UsePeriodes]
		,[Ajustement_Records].[Date_Debut]
		,[Ajustement_Records].[Date_Fin]
		,[Ajustement_Records].[ProducteurID]
		,[Ajustement_Records].[TransporteurID]
		,[Ajustement_Records].[IsRistourne]

		From [fnAjustement_SelectDisplay](@ID, @ContratID) As [Ajustement_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)

