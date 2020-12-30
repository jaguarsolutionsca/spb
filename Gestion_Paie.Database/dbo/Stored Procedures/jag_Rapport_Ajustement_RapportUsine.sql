

CREATE PROCEDURE dbo.jag_Rapport_Ajustement_RapportUsine
	(		
		@DateDebut SMALLDATETIME,
		@DateFin SMALLDATETIME,
		@AjustementDebut INT = NULL,
		@AjustementFin INT = NULL,
		@UsineDebut VARCHAR(6) = NULL,
		@UsineFin VARCHAR(6) = NULL
	)
AS

SET NOCOUNT ON

SELECT
CONVERT(VARCHAR,A.[DateAjustement],103) AS [Date],
A.[ID] AS [Ajustement],
LD.LivraisonID AS [Livraison],
U.[Description] AS [Usine],
E.[Description] + ' ' + LTRIM(RTRIM(ACU.Code)) AS [Essence],
ACU.UniteID,
SUM(ACU.Volume) AS [Volume],
(ACU.Taux) AS [Taux],
SUM(ACU.Montant) AS [Montant]
FROM AjustementCalcule_Usine ACU
	INNER JOIN Ajustement A ON A.[ID] = ACU.AjustementID
	INNER JOIN Livraison_Detail LD ON LD.[ID] = ACU.LivraisonDetailID
	INNER JOIN Contrat C ON C.[ID] = A.ContratID
	INNER JOIN Usine U ON U.[ID] = ACU.UsineID
	INNER JOIN Essence E ON E.[ID] = ACU.EssenceID
WHERE ((@DateDebut is null) or (DATEDIFF(day, @DateDebut, A.DateAjustement) >= 0))
AND ((@DateFin is null) or (DATEDIFF(day, @DateFin, A.DateAjustement) <= 0))
AND ((@AjustementDebut IS NULL) OR (A.[ID] >= @AjustementDebut))
AND ((@AjustementFin IS NULL) OR (A.[ID] <= @AjustementFin))	
AND	((@UsineDebut IS NULL) OR (C.[UsineID] >= @UsineDebut))
AND ((@UsineFin	IS NULL) OR (C.[UsineID] <= @UsineFin))

GROUP BY A.[DateAjustement], A.[ID], LD.LivraisonID, U.[Description], E.[Description], ACU.Code, ACU.UniteID, ACU.Taux
ORDER BY A.[DateAjustement], A.[ID], LD.LivraisonID, U.[Description], [Essence], ACU.UniteID, ACU.Taux DESC



