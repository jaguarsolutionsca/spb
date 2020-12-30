

Create Procedure [spS_Agence]

-- Retrieve specific records from the [Agence] table depending on the input parameters you supply.

(
 @ID [varchar](4) = Null -- for [Agence].[ID] column
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

		 [Agence_Records].[ID]
		,[Agence_Records].[Description]
		,[Agence_Records].[Actif]

		From [fnAgence](@ID) As [Agence_Records]
	End

Else

	Begin
		Select

		 [Agence_Records].[ID]
		,[Agence_Records].[Description]
		,[Agence_Records].[Actif]

		From [fnAgence](@ID) As [Agence_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


