

CREATE PROCEDURE [dbo].[jag_Rapport_Livraison_ListeDesCalculs]
	(		
		@PeriodeDebut int,
		@AnneeDebut int,
		@PeriodeFin int,
		@AnneeFin int,
		@UsineDebut VARCHAR(6),
		@UsineFin VARCHAR(6)
	)
AS

SET NOCOUNT ON

DECLARE @Livraisons TABLE
(
	[ID] int
)

INSERT INTO @Livraisons
SELECT L.[ID] FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )
AND	( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	
AND	((@UsineDebut	is null) or (C.[UsineID]	>= @UsineDebut))
AND ((@UsineFin		is null) or (C.[UsineID]	<= @UsineFin))
AND (Facture = 1)

SELECT
Contrat.UsineID,
NumeroFactureUsine,
CONVERT(VARCHAR,Livraison.DateLivraison,103) AS [Date],
Montant_Usine,
ROUND((Montant_Producteur1 + Montant_Producteur2),2) AS [Montant_Producteur],
Taux_Transporteur,
Montant_Transporteur,
Montant_Chargeur,
Montant_Preleve_Plan_Conjoint,
Montant_Preleve_Fond_Roulement,
Montant_Preleve_Fond_Forestier,
Montant_Preleve_Divers,
Montant_Surcharge,
Montant_MiseEnCommun,
Frais_ChargeurAuProducteur,
Frais_ChargeurAuTransporteur,
Frais_AutresAuProducteur + Frais_AutresAuProducteurTransportSciage,
Frais_AutresAuTransporteur,
Frais_CompensationDeDeplacement,
Frais_AutresRevenusProducteur,
Frais_AutresRevenusTransporteur
FROM Livraison
	INNER JOIN Contrat ON Contrat.[ID] = Livraison.ContratID
WHERE Livraison.[ID] in (SELECT [ID] FROM @Livraisons)
ORDER BY Livraison.ContratID, RIGHT('000000000000000000000000'+NumeroFactureUsine,25)

