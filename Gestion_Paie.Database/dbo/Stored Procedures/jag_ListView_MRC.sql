








CREATE Procedure jag_ListView_MRC

-- Retrieve specific records from the [MRC] table depending on the input parameters you supply.

(
 @ID [varchar](6) = Null -- for [MRC].[ID] column
,@Actif bit = null 
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 



		Select

		 [MRC_Records].[Description]
		,[MRC_Records].[ID]
		,[MRC_Records].[Actif]

		From [fnMRC](@ID) As [MRC_Records]
		
		where ((@Actif is null) or ([MRC_Records].[Actif] = @Actif))

Return(@@RowCount)









