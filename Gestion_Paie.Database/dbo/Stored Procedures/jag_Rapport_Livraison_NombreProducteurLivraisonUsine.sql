

CREATE PROCEDURE dbo.jag_Rapport_Livraison_NombreProducteurLivraisonUsine
	(		
		@PeriodeDebut int = Null,
		@PeriodeFin int = Null,
		@AnneeDebut int = Null,
		@AnneeFin int = Null
	)
AS

SET NOCOUNT ON

select CodeUsine, max(NomUsine) as Usine, count(Producteur) as NbProducteur from 
(	select 

	distinct

	Usine.ID as CodeUsine,
	Usine.Description as NomUsine,
	DroitCoupeID as Producteur

	from 
		Livraison
			inner join Contrat on Livraison.[ContratID] = Contrat.[ID]
				inner join Usine on Contrat.[UsineID] = Usine.[ID]

	where 
			((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
		AND	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))	


	) 
as t1
group by CodeUsine


Return(@@RowCount)




