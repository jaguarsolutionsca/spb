

CREATE Procedure jag_ListView_EssenceContingent

-- Retrieve specific records from the [EssenceContingent] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [EssenceContingent].[ID] column
,@Actif bit = null
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 



		Select

		 [EssenceContingent_Records].[Description]
		,[EssenceContingent_Records].[ID]
		,[EssenceContingent_Records].[Actif]

		From [fnEssenceContingent](@ID) As [EssenceContingent_Records]
		
		where ((@Actif is null) or ([EssenceContingent_Records].[Actif] = @Actif))


Return(@@RowCount)









