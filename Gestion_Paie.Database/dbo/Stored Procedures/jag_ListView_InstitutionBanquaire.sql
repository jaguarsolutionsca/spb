








CREATE Procedure jag_ListView_InstitutionBanquaire

-- Retrieve specific records from the [InstitutionBanquaire] table depending on the input parameters you supply.

(
 @ID [varchar](3) = Null -- for [InstitutionBanquaire].[ID] column
,@Actif bit = null 
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 

		Select

		 [InstitutionBanquaire_Records].[Description]
		,[InstitutionBanquaire_Records].[ID]
		,[InstitutionBanquaire_Records].[Actif]

		From [fnInstitutionBanquaire](@ID) As [InstitutionBanquaire_Records]
		
		where ((@Actif is null) or ([InstitutionBanquaire_Records].[Actif] = @Actif))


Return(@@RowCount)









