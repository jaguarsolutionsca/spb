








CREATE Procedure jag_ListView_EssenceRepartition

-- Retrieve specific records from the [EssenceRepartition] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [EssenceRepartition].[ID] column
,@Actif bit = null 
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


		Select

		 [EssenceRepartition_Records].[Description]
		,[EssenceRepartition_Records].[ID]
		,[EssenceRepartition_Records].[Actif]

		From [fnEssenceRepartition](@ID) As [EssenceRepartition_Records]
		
		where ((@Actif is null) or ([EssenceRepartition_Records].[Actif] = @Actif))


Return(@@RowCount)









