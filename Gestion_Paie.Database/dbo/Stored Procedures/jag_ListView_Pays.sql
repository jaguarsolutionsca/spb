








CREATE Procedure jag_ListView_Pays

-- Retrieve specific records from the [Pays] table depending on the input parameters you supply.

(
 @ID [varchar](2) = Null -- for [Pays].[ID] column
,@Actif bit = null 
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


		Select

		 [Pays_Records].[Nom]
		,[Pays_Records].[ID]
		,[Pays_Records].[Actif]

		From [fnPays](@ID) As [Pays_Records]
		
		where ((@Actif is null) or ([Pays_Records].[Actif] = @Actif))
		order by [Pays_Records].[Nom]


Return(@@RowCount)



