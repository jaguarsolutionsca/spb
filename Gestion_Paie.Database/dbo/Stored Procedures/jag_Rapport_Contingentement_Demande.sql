

CREATE PROCEDURE [dbo].[jag_Rapport_Contingentement_Demande]
	(		
		@Annee INT = null,
		@DemandeID_Debut int = null,
		@DemandeID_Fin int = null
	)
AS

SET NOCOUNT ON

	select 
	c.Annee,
	d.ID,
	p.ProducteurID,
	(Select Nom from fournisseur where ID = p.ProducteurID) as Producteur,
	case when d.TransporteurID is not null then d.TransporteurID else '' end as TransporteurID,
	case when d.TransporteurID is not null then (Select Nom from fournisseur where ID = d.TransporteurID)  else '' end as Transporteur,
	c.PeriodeContingentement as Periode,
	
	case when c.ContingentUsine = 1 
		then c.UsineID + ' ' +  c.EssenceID + ' ' + LTRIM(RTRIM(c.Code))
		else r.Description end as Contingentement,
	
	c.UniteMesureID,
	p.Superficie_Contingentee,
	p.Volume_Demande,
	d.DateModification

	
	from 
	Contingentement_Producteur as p
	left join Contingentement as c on c.ID = p.ContingentementID
	left join EssenceRegroupement as r on RegroupementID = r.ID
	left join Contingentement_Demande as d on c.Annee = d.Annee and p.ProducteurID = d.ProducteurID
	where ((@Annee is null) or (@Annee = c.Annee))
	and ((@DemandeID_Debut is null or @DemandeID_Fin is null) or
	(d.ID >= @DemandeID_Debut and d.ID <= @DemandeID_Fin))
	
	order by Producteur, c.id, c.PeriodeContingentement

