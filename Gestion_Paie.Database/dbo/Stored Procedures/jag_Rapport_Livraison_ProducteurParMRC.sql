CREATE PROCEDURE [dbo].[jag_Rapport_Livraison_ProducteurParMRC]
@PeriodeDebut INT, @AnneeDebut INT, @PeriodeFin INT, @AnneeFin INT, @MunicipaliteID VARCHAR (6), @MRC VARCHAR (6), @Resident CHAR (1)
AS
select 
		MRC.Description MRC,
		d.ProducteurID,
		f.Nom,
		f.Resident,
		count(distinct (l.MunicipaliteID)) NbreMunicipalite,
		(Case when count(distinct(l.sciage))=2 then 'Pâte et Sciage' else 
			(case when sum(cast(l.sciage as int))=0 then 'Pâte' else 'Sciage' end)
			end) TypeLivraison

	from livraison l
		left join livraison_detail as d on l.id=d.livraisonID
		left join fournisseur as f on f.id=d.ProducteurID
		left join municipalite as m on m.id=l.MunicipaliteID
		left join MRC  on mrc.id=m.MrcID


	WHERE ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), l.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,l.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
		AND	  ((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), l.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,l.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))	
		AND   ((@MunicipaliteID is null) or (l.MunicipaliteID = @MunicipaliteID))
		AND   ((@MRC is null) or (m.MrcID = @MRC))
		AND   ((@Resident is null) or (f.Resident = @Resident))

	group by 
		MRC.Description ,
		d.ProducteurID,
		f.Nom,
		f.Resident

	order by 
		MRC.Description ,
		d.ProducteurID


