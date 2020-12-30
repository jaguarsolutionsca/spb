

Create Procedure [spS_Indexation_Livraison]

-- Retrieve specific records from the [Indexation_Livraison] table depending on the input parameters you supply.

(
 @IndexationID [int] = Null -- for [Indexation_Livraison].[IndexationID] column
,@LivraisonID [int] = Null -- for [Indexation_Livraison].[LivraisonID] column
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

		 [Indexation_Livraison_Records].[IndexationID]
		,[Indexation_Livraison_Records].[LivraisonID]

		From [fnIndexation_Livraison](@IndexationID, @LivraisonID) As [Indexation_Livraison_Records]
	End

Else

	Begin
		Select

		 [Indexation_Livraison_Records].[IndexationID]
		,[Indexation_Livraison_Records].[LivraisonID]

		From [fnIndexation_Livraison](@IndexationID, @LivraisonID) As [Indexation_Livraison_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


