

CREATE PROCEDURE dbo.jag_Rapport_Livraison_SciageDeroullage
	(		
		@Annee int
	)
AS

select 
	LD.UniteMesureID,
	ER.ID as RepartitionID,
	ER.Description as Repartition,
	LD.EssenceID,
	E.Description as Essence,
	LD.VolumeNet as Poids,
	EU.Facteur_M3sol as FacteurConversion,
	LD.VolumeNet * EU.Facteur_M3sol as M3Solide
from 
	Livraison_detail LD left outer join
	Livraison L 			on L.ID = LD.LivraisonID left outer join 
	Essence E 				on E.ID = LD.EssenceID left outer join
	EssenceRepartition ER 	on ER.ID = E.RepartitionID left outer join
	Essence_Unite EU		on EU.EssenceID = LD.EssenceID and EU.UniteID = LD.UniteMesureID 
where 
	((@Annee is null) or (L.Annee = @Annee))


