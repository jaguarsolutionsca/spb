

CREATE PROCEDURE dbo.jag_Get_ListeProducteursAvecLivraisonNonConforme
	(
		@PeriodeDebut int,
		@PeriodeFin int,
		@AnneeDebut int,
		@AnneeFin int,
		@FournisseurDebut varchar(15),
		@FournisseurFin varchar(15)
	)
AS

SET NOCOUNT ON

SELECT
L.DroitCoupeID AS [ID]
FROM 
	Livraison L 
				INNER JOIN Permit P ON P.ID = L.ID

where 
	-- Condition pour filtrer
	((L.DateLivraison < P.DateDebut) or (L.DateLivraison > P.DateFin))and
	-- Conditions pour l'intervale
	((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(varchar,RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )) AND
	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(varchar,RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )) AND
	(L.DroitCoupeID >= @FournisseurDebut) and
	(L.DroitCoupeID <= @FournisseurFin) and
	(L.Facture = 1)

ORDER BY L.DateLivraison DESC










