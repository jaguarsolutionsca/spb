CREATE PROCEDURE [dbo].[jag_Rapport_Contrat_ListeContrats]
@UsineDebut VARCHAR (6)=Null, @UsineFin VARCHAR (6)=Null, @Annee INT=Null
AS
SET NOCOUNT ON

select 

max(Usine.[Description]) as Usine,
max(Essence.[Description] + ' ' + LTRIM(RTRIM(Contrat_EssenceUnite.Code))) as Essence,
Contrat_EssenceUnite.[UniteID] as UniteMesure,
sum(Contrat_EssenceUnite.[Quantite_prevue])/count(*) as Prevu,
sum(Livraison_Detail.VolumeNet) as QuantiteLivre,
(sum(Contrat_EssenceUnite.[Quantite_prevue])/count(*))-(sum(Livraison_Detail.VolumeNet)) as ALivre,
PourcentageLivre =
	CASE 
		WHEN ((sum(Contrat_EssenceUnite.[Quantite_prevue])/count(*)) <> 0)	THEN (sum(Livraison_Detail.VolumeNet)/(sum(Contrat_EssenceUnite.[Quantite_prevue])/count(*)))				
		ELSE 0
	END
from 
	Contrat
		inner join Contrat_EssenceUnite on Contrat.ID = Contrat_EssenceUnite.ContratID
			left outer join Livraison on Livraison.[ContratID] = Contrat.ID
				left outer join Livraison_Detail on	(Livraison.[ID] = Livraison_Detail.[LivraisonID]) and 
												(Livraison_Detail.[EssenceID] = Contrat_EssenceUnite.[EssenceID]) and 
												(Livraison_Detail.[UniteMesureID] = Contrat_EssenceUnite.[UniteID]) 
					left outer join Usine on Contrat.UsineID = Usine.ID
						left outer join Essence on Contrat_EssenceUnite.EssenceID = Essence.ID

where
--		((@ContratDebut is null) 	or (Contrat.[ID] >= @ContratDebut))
--	and	((@ContratFin is null) 		or (Contrat.[ID] <= @ContratFin))

	((@Annee 		is null) or (year(Livraison.DateLivraison) = @Annee))
	AND ((@UsineDebut	is null) or (Contrat.UsineID >= @UsineDebut))
	AND ((@UsineFin		is null) or (Contrat.UsineID <= @UsineFin))


group by 
		Contrat.[ID], 
			Contrat_EssenceUnite.[EssenceID], 
				Contrat_EssenceUnite.[UniteID], 
					Contrat.[Annee]
ORDER BY [Usine], [Essence]

Return(@@RowCount)


