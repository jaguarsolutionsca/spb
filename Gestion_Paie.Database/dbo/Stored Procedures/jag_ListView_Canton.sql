








CREATE Procedure jag_ListView_Canton

-- Retrieve specific records from the [Canton] table depending on the input parameters you supply.

(
 @ID [varchar](6) = Null -- for [Canton].[ID] column
,@Actif bit = null 
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 

		Select

		 [Canton_Records].[Description]
		,[Canton_Records].[ID]
		,[Canton_Records].[Actif]

		From [fnCanton](@ID) As [Canton_Records]
		
		where ((@Actif is null) or ([Canton_Records].[Actif] = @Actif))

Return(@@RowCount)









