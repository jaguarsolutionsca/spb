

CREATE PROCEDURE dbo.jag_Rapport_Facture_EcrituresMiseEnCommun
	(		
		@DateDebut SMALLDATETIME,
		@DateFin SMALLDATETIME,
		@UsineDebut varchar(6),
		@UsineFin varchar(6)
	)
AS

SET NOCOUNT ON

SELECT
FC.NoFacture,
CONVERT(VARCHAR,FC.DateFactureAcomba,103) AS [DateFactureAcomba],
--FC.ClientID,
U.[Description] AS [Usine],
FC.[Description] AS [FactureDescription],
FCS.Compte,
C.[Description] AS [CompteDescription],
FCS.[Description] AS [DetailDescription],
FCS.Montant
FROM FactureClient FC
	INNER JOIN FactureClient_Sommaire FCS ON FCS.FactureID = FC.[ID]
	INNER JOIN Usine U ON U.[ID] = FC.ClientID
	INNER JOIN Compte C ON C.[ID] = FCS.Compte
WHERE ((@UsineDebut IS NULL) OR (FC.ClientID >= @UsineDebut))
AND ((@UsineFin IS NULL) OR (FC.ClientID <= @UsineFin))
AND ((@DateDebut IS NULL) OR (DATEDIFF(day, @DateDebut, FC.DateFactureAcomba) >= 0))
AND ((@DateFin IS NULL) OR (DATEDIFF(day, @DateFin, FC.DateFactureAcomba) <= 0))
AND (FC.Montant_Total = 0)
AND (FCS.Montant <> 0)

