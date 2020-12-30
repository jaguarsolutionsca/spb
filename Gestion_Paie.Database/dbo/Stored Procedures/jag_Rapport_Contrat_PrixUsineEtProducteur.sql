

CREATE PROCEDURE dbo.jag_Rapport_Contrat_PrixUsineEtProducteur
	(		
		@Date datetime = Null,
		@Usine varchar(6) = Null,
		@Unite varchar(6) = Null
	)
AS

SET NOCOUNT ON


select 

Essence.[Description] + ' ' + LTRIM(RTRIM(Code)) as [Essence],
Contrat_EssenceUnite.[UniteID] + ' - ' + UniteMesure.[Description] as Unite,
Contrat_EssenceUnite.[Taux_usine] as TauxUsine,
Contrat_EssenceUnite.[Taux_producteur] as TauxProducteur

from 
	Contrat
		inner join Contrat_EssenceUnite on Contrat.[ID] = Contrat_EssenceUnite.[ContratID]
			inner join Essence on Essence.[ID] = Contrat_EssenceUnite.[EssenceID]
			inner join UniteMesure on UniteMesure.[ID] = Contrat_EssenceUnite.[UniteID]
				
where 
	    ((@Date	is null) or ((Contrat.[Date_debut]		<= @Date) AND (Contrat.[Date_fin]	>= @Date)))
	AND ((@Usine is null) or (Contrat.[UsineID]			= @Usine))
	AND ((@Unite is null) or (Contrat_EssenceUnite.[UniteID]	= @Unite))	

order by [Essence], UniteMesure.[Description]

Return(@@RowCount)



