

CREATE PROCEDURE dbo.jag_Rapport_Usine_UniteMesure
	(		
		@UsineDebut varchar(6) = Null,
		@UsineFin varchar(6) = Null
	)
AS

SET NOCOUNT ON



select 

distinct

Usine.ID							as [Code],
Usine.Description					as [Usine],
Contrat_EssenceUnite.EssenceID + ' ' + RTRIM(LTRIM(Contrat_EssenceUnite.Code)) + ' - ' + E.[Description] as [Essence], 
Contrat_EssenceUnite.UniteID + ' - ' + UM.[Description] as [UniteMesure]

from Usine
	left outer join Contrat on Contrat.UsineID = Usine.ID
	left outer join Contrat_EssenceUnite on Contrat.ID = Contrat_EssenceUnite.ContratID
	inner join Essence E ON E.[ID] = Contrat_EssenceUnite.EssenceID
	inner join UniteMesure UM ON UM.[ID] = Contrat_EssenceUnite.UniteID
			
where 
		((@UsineDebut	is null) or (Usine.[ID]	>= @UsineDebut))
	AND ((@UsineFin		is null) or (Usine.[ID]	<= @UsineFin))
	
order by [Usine], [Essence], [UniteMesure]

Return(@@RowCount)









