








CREATE Procedure jag_ListView_EssenceRegroupement

-- Retrieve specific records from the [EssenceRegroupement] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [EssenceRegroupement].[ID] column
,@Actif bit = null
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 

		Select

		 [EssenceRegroupement_Records].[Description]
		,[EssenceRegroupement_Records].[ID]
		,[EssenceRegroupement_Records].[Actif]

		From [fnEssenceRegroupement](@ID) As [EssenceRegroupement_Records]
		
		where ((@Actif is null) or ([EssenceRegroupement_Records].[Actif] = @Actif))


Return(@@RowCount)









