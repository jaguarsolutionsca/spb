

CREATE PROCEDURE dbo.jag_Rapport_PermisNonConformes
	(
		@TransporteurDebut varchar(15) = NULL,
		@TransporteurFin varchar(15) = NULL,
		@PeriodeDebut int = Null,
		@PeriodeFin int = Null,
		@AnneeDebut int = Null,
		@AnneeFin int = Null

	)
AS

SET NOCOUNT ON

SELECT
P.[ID] AS [Permis],
CONVERT(VARCHAR,P.DateDebut,103) + ' - ' + CONVERT(VARCHAR,P.DateFin,103) AS [DateValide],
CONVERT(VARCHAR,L.DateLivraison,103) AS [DateLivraison],
Pr.ID + ' - ' + Pr.Nom AS [Producteur],
Tr.ID + ' - ' + Tr.Nom AS [Transporteur],
case 
	when (P.DateDebut > DateLivraison) then 'Livraison effectué avant la période valide'
	when (P.DateFin < DateLivraison) then 'Livraison effectué après la période valide'
	else 'Date de livraison hors de la période de validité' end as [Raison]

FROM Permit P
	INNER JOIN Livraison L on L.ID = P.ID 
	INNER JOIN Fournisseur Tr ON Tr.[ID] = L.TransporteurID
	INNER JOIN Fournisseur Pr ON Pr.[ID] = L.DroitCoupeID

WHERE PermitLivre = 1
AND ((@TransporteurDebut IS NULL) OR (@TransporteurDebut <= L.TransporteurID))
AND ((@TransporteurFin IS NULL) OR (@TransporteurFin >= L.TransporteurID))
AND ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) 
		>= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)) )) ))
AND ((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) 
		<= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	)
AND ((P.DateDebut > DateLivraison) or (P.DateFin < DateLivraison))

order by Tr.[ID], P.[ID]




