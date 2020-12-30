

CREATE PROCEDURE dbo.jag_Rapport_Contrat_SommaireContratsParUsine
	(		
		@UsineDebut varchar(6) = Null,
		@UsineFin varchar(6) = Null
	)
AS

SET NOCOUNT ON

declare @Annee int
set @Annee = (select top 1 Value from jag_SystemEx where Name='AnneeCourante')

select 

max(Usine.[Description]) as Usine,
max(Essence.[Description]) + ' ' + LTRIM(RTRIM(Contrat_EssenceUnite.Code)) as [Essence],
max(UniteMesure.[Description]) as Unite,
(CASE WHEN sum(Contrat_EssenceUnite.Quantite_prevue) IS NOT NULL THEN sum(Contrat_EssenceUnite.Quantite_prevue) ELSE 0 END) as VolumeAccorde,
VolumeLivre = (CASE WHEN sum(Livraison_Detail.VolumeNet) IS NOT NULL THEN sum(Livraison_Detail.VolumeNet) ELSE 0 END),
(CASE WHEN sum(Contrat_EssenceUnite.Quantite_prevue) IS NOT NULL THEN sum(Contrat_EssenceUnite.Quantite_prevue) ELSE 0 END) -  (CASE WHEN sum(Livraison_Detail.VolumeNet) IS NOT NULL THEN sum(Livraison_Detail.VolumeNet) ELSE 0 END) as VolumeALivre,

(case when (CASE WHEN sum(Contrat_EssenceUnite.Quantite_prevue) IS NOT NULL THEN sum(Contrat_EssenceUnite.Quantite_prevue) ELSE 0 END) <> 0
then (CASE WHEN sum(Livraison_Detail.VolumeNet) IS NOT NULL THEN sum(Livraison_Detail.VolumeNet) ELSE 0 END) / (CASE WHEN sum(Contrat_EssenceUnite.Quantite_prevue) IS NOT NULL THEN sum(Contrat_EssenceUnite.Quantite_prevue) ELSE 0 END)
else 0 
end)as Pourcentage

from 
	Contrat
		left outer join Contrat_EssenceUnite on Contrat.[ID] = Contrat_EssenceUnite.[ContratID]	
			left outer join Usine on Usine.[ID] = Contrat.[UsineID]
				left outer join UniteMesure on UniteMesure.[ID] = Contrat_EssenceUnite.[UniteID]
					left outer join Essence on Essence.[ID] = Contrat_EssenceUnite.[EssenceID]
						left outer join Livraison_Detail on Livraison_Detail.[ContratID] = Contrat_EssenceUnite.[ContratID] 
														and Livraison_Detail.[EssenceID] = Contrat_EssenceUnite.[EssenceID] 
															and Livraison_Detail.[UniteMesureID] = Contrat_EssenceUnite.[UniteID] 
															
					
			
where 
		(Contrat.[Annee] = @Annee)
	AND ((@UsineDebut	is null) or (Contrat.[UsineID]					>= @UsineDebut))
	AND ((@UsineFin		is null) or (Contrat.[UsineID]					<= @UsineFin))
	
group by Usine.[ID],
			Essence.[ID],
				Contrat_EssenceUnite.Code,
				UniteMesure.[ID]
order by max(Usine.[Description]),
			[Essence],
				max(UniteMesure.[Description])

Return(@@RowCount)









