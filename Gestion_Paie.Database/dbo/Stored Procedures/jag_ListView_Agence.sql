








CREATE Procedure jag_ListView_Agence

-- Retrieve specific records from the [Agence] table depending on the input parameters you supply.

(
 @ID [varchar](4) = Null -- for [Agence].[ID] column
,@Actif bit = null
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 

		Select

		 [Agence_Records].[Description]
		,[Agence_Records].[ID]
		,[Agence_Records].[Actif]

		From [fnAgence](@ID) As [Agence_Records]
		
		where ((@Actif is null) or ([Agence_Records].[Actif] = @Actif))


Return(@@RowCount)









