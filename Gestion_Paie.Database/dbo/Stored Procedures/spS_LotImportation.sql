

Create Procedure [spS_LotImportation]

-- Retrieve specific records from the [LotImportation] table depending on the input parameters you supply.

(
 @ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
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

		 [LotImportation_Records].[lo_code_canton]
		,[LotImportation_Records].[lo_rang]
		,[LotImportation_Records].[lo_code]
		,[LotImportation_Records].[lo_super_tot]
		,[LotImportation_Records].[lo_super_boisee]
		,[LotImportation_Records].[lo_super_contin]
		,[LotImportation_Records].[lo_code_fournisseur]
		,[LotImportation_Records].[lo_code_muni]
		,[LotImportation_Records].[lo_code_prop]
		,[LotImportation_Records].[lo_code_cont]
		,[LotImportation_Records].[lo_date]
		,[LotImportation_Records].[lo_code_deux]
		,[LotImportation_Records].[Traite]
		,[LotImportation_Records].[Valide]
		,[LotImportation_Records].[Raison]

		From [fnLotImportation]() As [LotImportation_Records]
	End

Else

	Begin
		Select

		 [LotImportation_Records].[lo_code_canton]
		,[LotImportation_Records].[lo_rang]
		,[LotImportation_Records].[lo_code]
		,[LotImportation_Records].[lo_super_tot]
		,[LotImportation_Records].[lo_super_boisee]
		,[LotImportation_Records].[lo_super_contin]
		,[LotImportation_Records].[lo_code_fournisseur]
		,[LotImportation_Records].[lo_code_muni]
		,[LotImportation_Records].[lo_code_prop]
		,[LotImportation_Records].[lo_code_cont]
		,[LotImportation_Records].[lo_date]
		,[LotImportation_Records].[lo_code_deux]
		,[LotImportation_Records].[Traite]
		,[LotImportation_Records].[Valide]
		,[LotImportation_Records].[Raison]

		From [fnLotImportation]() As [LotImportation_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


