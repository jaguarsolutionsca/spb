

Create Procedure [spS_Compte]

-- Retrieve specific records from the [Compte] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [Compte].[ID] column
,@CategoryID [int] = Null -- for [Compte].[CategoryID] column
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

		 [Compte_Records].[ID]
		,[Compte_Records].[Description]
		,[Compte_Records].[CategoryID]
		,[Compte_Records].[isTaxe]
		,[Compte_Records].[Actif]

		From [fnCompte](@ID, @CategoryID) As [Compte_Records]
	End

Else

	Begin
		Select

		 [Compte_Records].[ID]
		,[Compte_Records].[Description]
		,[Compte_Records].[CategoryID]
		,[Compte_Records].[isTaxe]
		,[Compte_Records].[Actif]

		From [fnCompte](@ID, @CategoryID) As [Compte_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


