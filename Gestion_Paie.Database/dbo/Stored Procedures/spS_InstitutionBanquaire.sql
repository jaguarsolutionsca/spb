

Create Procedure [spS_InstitutionBanquaire]

-- Retrieve specific records from the [InstitutionBanquaire] table depending on the input parameters you supply.

(
 @ID [varchar](3) = Null -- for [InstitutionBanquaire].[ID] column
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

		 [InstitutionBanquaire_Records].[ID]
		,[InstitutionBanquaire_Records].[Description]
		,[InstitutionBanquaire_Records].[Actif]

		From [fnInstitutionBanquaire](@ID) As [InstitutionBanquaire_Records]
	End

Else

	Begin
		Select

		 [InstitutionBanquaire_Records].[ID]
		,[InstitutionBanquaire_Records].[Description]
		,[InstitutionBanquaire_Records].[Actif]

		From [fnInstitutionBanquaire](@ID) As [InstitutionBanquaire_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


