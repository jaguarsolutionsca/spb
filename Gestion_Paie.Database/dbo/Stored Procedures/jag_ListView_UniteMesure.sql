








CREATE Procedure jag_ListView_UniteMesure

-- Retrieve specific records from the [UniteMesure] table depending on the input parameters you supply.

(
 @ID [varchar](6) = Null -- for [UniteMesure].[ID] column
,@Actif bit = null 
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


		Select

		 [UniteMesure_Records].[Description]
		,[UniteMesure_Records].[ID]
		,[UniteMesure_Records].[Actif]

		From [fnUniteMesure](@ID) As [UniteMesure_Records]
		
		where ((@Actif is null) or ([UniteMesure_Records].[Actif] = @Actif))
		order by [UniteMesure_Records].[Description]


Return(@@RowCount)



