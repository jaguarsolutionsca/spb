

CREATE PROCEDURE dbo.jag_Rapport_Ajustement_RapportProducteur
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
C.UsineID AS [UsineID],
F.[Nom] AS [Producteur],
E.[Description] + ' ' + RTRIM(LTRIM(ACP.Code)) AS [Essence],
ACP.UniteID,
SUM(ACP.Volume) AS [Volume],
(ACP.Taux) AS [Taux],
SUM(ACP.Montant) AS [Montant]
FROM AjustementCalcule_Producteur ACP
	INNER JOIN Ajustement A ON A.[ID] = ACP.AjustementID
	INNER JOIN Livraison_Detail LD ON LD.[ID] = ACP.LivraisonDetailID
	INNER JOIN Contrat C ON C.[ID] = A.ContratID
	INNER JOIN Fournisseur F ON F.[ID] = ACP.ProducteurID
	INNER JOIN Essence E ON E.[ID] = ACP.EssenceID
WHERE ((@DateDebut is null) or (DATEDIFF(day, @DateDebut, A.DateAjustement) >= 0))
AND ((@DateFin is null) or (DATEDIFF(day, @DateFin, A.DateAjustement) <= 0))
AND ((@AjustementDebut IS NULL) OR (A.[ID] >= @AjustementDebut))
AND ((@AjustementFin IS NULL) OR (A.[ID] <= @AjustementFin))	
AND	((@UsineDebut IS NULL) OR (C.[UsineID] >= @UsineDebut))
AND ((@UsineFin	IS NULL) OR (C.[UsineID] <= @UsineFin))

GROUP BY A.[DateAjustement], A.[ID], LD.LivraisonID, C.UsineID, F.[Nom], E.[Description], ACP.Code, ACP.UniteID, ACP.Taux
ORDER BY A.[DateAjustement], A.[ID], LD.LivraisonID, C.UsineID, F.[Nom], [Essence], ACP.UniteID, ACP.Taux DESC



