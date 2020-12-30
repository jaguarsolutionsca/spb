
CREATE Procedure [spS_Contingentement_Demande]

-- Retrieve specific records from the [Contingentement_Demande] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [Contingentement_Demande].[ID] column
,@ProducteurID [varchar](15) = Null -- for [Contingentement_Demande].[ProducteurID] column
,@TransporteurID [varchar](15) = Null -- for [Contingentement_Demande].[TransporteurID] column
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

		 [Contingentement_Demande_Records].[ID]
		,[Contingentement_Demande_Records].[Annee]
		,[Contingentement_Demande_Records].[ProducteurID]
		,[Contingentement_Demande_Records].[TransporteurID]
		,[Contingentement_Demande_Records].[Superficie_Boisee]
		,[Contingentement_Demande_Records].[Remarques]
		,[Contingentement_Demande_Records].[DateModification]

		From [fnContingentement_Demande](@ID, @ProducteurID, @TransporteurID) As [Contingentement_Demande_Records]
	End

Else

	Begin
		Select

		 [Contingentement_Demande_Records].[ID]
		,[Contingentement_Demande_Records].[Annee]
		,[Contingentement_Demande_Records].[ProducteurID]
		,[Contingentement_Demande_Records].[TransporteurID]
		,[Contingentement_Demande_Records].[Superficie_Boisee]
		,[Contingentement_Demande_Records].[Remarques]
		,[Contingentement_Demande_Records].[DateModification]

		From [fnContingentement_Demande](@ID, @ProducteurID, @TransporteurID) As [Contingentement_Demande_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)

