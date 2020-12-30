

Create Procedure [spS_Pays]

-- Retrieve specific records from the [Pays] table depending on the input parameters you supply.

(
 @ID [varchar](2) = Null -- for [Pays].[ID] column
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

		 [Pays_Records].[ID]
		,[Pays_Records].[Nom]
		,[Pays_Records].[CodePostal_InputMask]
		,[Pays_Records].[Actif]

		From [fnPays](@ID) As [Pays_Records]
	End

Else

	Begin
		Select

		 [Pays_Records].[ID]
		,[Pays_Records].[Nom]
		,[Pays_Records].[CodePostal_InputMask]
		,[Pays_Records].[Actif]

		From [fnPays](@ID) As [Pays_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


