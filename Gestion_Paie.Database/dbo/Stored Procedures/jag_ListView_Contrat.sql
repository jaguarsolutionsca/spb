

CREATE Procedure jag_ListView_Contrat

/*
Retrieve specific records from the [Contrat] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Usine] (via [UsineID])
*/

(
 @ID [varchar](6) = Null -- for [Contrat].[ID] column
,@UsineID [varchar](6) = Null -- for [Contrat].[UsineID] column
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


		Select

		[Contrat_Records].[ID]
		,[Contrat_Records].[UsineID] + ' - ' + [Contrat_Records].[UsineID_Description] AS [Usine]
		,[Contrat_Records].[Annee]
		,[Contrat_Records].[Description]
		, CONVERT(varchar,[Contrat_Records].[Date_debut],103) AS [Date_debut]
		, CONVERT(varchar,[Contrat_Records].[Date_fin],103) AS [Date_fin]
		,[Contrat_Records].[Actif]

		From [fnContrat_Full](@ID, @UsineID) As [Contrat_Records]

Return(@@RowCount)









