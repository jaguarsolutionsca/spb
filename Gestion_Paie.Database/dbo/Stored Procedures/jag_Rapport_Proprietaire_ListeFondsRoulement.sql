

CREATE PROCEDURE dbo.jag_Rapport_Proprietaire_ListeFondsRoulement
	(			
		@ProducteurDebut varchar(15) = Null,
		@ProducteurFin varchar(15) = Null,
		@PeriodeDebut int = Null,
		@PeriodeFin int = Null,
		@AnneeDebut int = Null,
		@AnneeFin int = Null	
	)
AS

SET NOCOUNT ON


SELECT
Fournisseur.ID,
max(Fournisseur.Nom) AS [Nom],
sum(Livraison_detail.Montant_Preleve_Fond_Roulement) As Montant

FROM 
	Livraison_detail inner join Fournisseur on Livraison_detail.[ProducteurID] = Fournisseur.[ID]
		inner join Livraison on Livraison.ID = Livraison_Detail.LivraisonID

WHERE 

		((@ProducteurDebut	IS NULL) OR (Fournisseur.[ID]				>= @ProducteurDebut))
	AND	((@ProducteurFin	IS NULL) OR (Fournisseur.[ID]				<= @ProducteurFin))
	
	AND	((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
	AND	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	)
	
group by Fournisseur.ID
order by [Nom]
	

Return(@@RowCount)




