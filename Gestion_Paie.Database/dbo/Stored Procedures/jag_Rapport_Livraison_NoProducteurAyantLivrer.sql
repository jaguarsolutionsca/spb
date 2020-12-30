

CREATE PROCEDURE dbo.jag_Rapport_Livraison_NoProducteurAyantLivrer
	(		
		@Annee int
	)
AS

select 
	count(*) as Compte,
	L.ID as LivraisonID,
	LD.ProducteurID,
	C.UsineID,
	LD.EssenceID,
	U.UtilisationID,
	max(U.Description) as Usine,
	max(E.Description) as Essence,
	max(UU.Description) as Utilisation
from 
	Livraison_detail LD inner join
	Livraison L 		on L.ID = LD.LivraisonID inner join 
	Contrat C 			on C.ID = L.ContratID inner join
	Essence E 			on E.ID = LD.EssenceID inner join
	Usine U 			on U.ID = C.UsineID inner join
	UsineUtilisation UU on UU.ID = U.UtilisationID
where 
	((@Annee is null) or (L.Annee = @Annee))
group by
  	L.ID,
	C.UsineID,
	LD.ProducteurID,
	LD.EssenceID,
	U.UtilisationID,
	L.Annee


