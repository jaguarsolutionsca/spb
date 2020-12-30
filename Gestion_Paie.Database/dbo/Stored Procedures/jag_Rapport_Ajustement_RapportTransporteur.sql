

CREATE PROCEDURE [dbo].[jag_Rapport_Ajustement_RapportTransporteur]
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

select * from 
(SELECT
CONVERT(VARCHAR,A.[DateAjustement],103) AS [Date],
A.[ID] AS [Ajustement],
L.[ID] AS [Livraison],
C.UsineID AS [UsineID],
F.[Nom] AS [Transporteur],
(CASE WHEN L.Sciage = 0 THEN E.[Description] + ' ' + RTRIM(LTRIM(L.Code)) ELSE 'SCIAGE' END) AS [Essence],
ACT.UniteID,
M.[Description] AS [Municipalite],
SUM(ACT.Volume) AS [Volume],
(ACT.Taux) AS [Taux],
SUM(ACT.Montant) AS [Montant]
FROM AjustementCalcule_Transporteur ACT
	INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
	INNER JOIN Livraison L ON L.[ID] = ACT.LivraisonID
	INNER JOIN Contrat C ON C.[ID] = A.ContratID
	LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
	INNER JOIN Fournisseur F ON F.[ID] = ACT.TransporteurID
	INNER JOIN Municipalite M ON M.[ID] = ACT.MunicipaliteID
WHERE ((@DateDebut is null) 	or (DATEDIFF(day, @DateDebut, A.DateAjustement) >= 0))
AND ((@DateFin is null) 	or (DATEDIFF(day, @DateFin, A.DateAjustement) <= 0))
AND ((@AjustementDebut IS NULL) OR (A.[ID] >= @AjustementDebut))
AND ((@AjustementFin IS NULL) OR (A.[ID] <= @AjustementFin))	
AND	((@UsineDebut IS NULL) OR (C.[UsineID] >= @UsineDebut))
AND ((@UsineFin	IS NULL) OR (C.[UsineID] <= @UsineFin))

GROUP BY A.[DateAjustement], A.[ID], L.[ID], C.UsineID, F.[Nom], L.Sciage, E.[Description], L.Code, ACT.UniteID, M.[Description], ACT.Taux
--ORDER BY A.[DateAjustement], A.[ID], L.[ID], C.UsineID, F.[Nom], L.Sciage DESC, [Essence], ACT.UniteID, M.[Description], ACT.Taux DESC

UNION ALL

SELECT
CONVERT(VARCHAR,A.[DateAjustement],103) AS [Date],
A.[ID] AS [Ajustement],
L.[ID] AS [Livraison],
C.UsineID AS [UsineID],
F.[Nom] AS [Transporteur],
(CASE WHEN L.Sciage = 0 THEN E.[Description] + ' ' + RTRIM(LTRIM(L.Code)) ELSE 'SCIAGE' END) AS [Essence],
ACT.UniteID,
M.[Description] AS [Municipalite],
SUM(ACT.Volume) AS [Volume],
(ACT.Taux) AS [Taux],
SUM(ACT.Montant) AS [Montant]
FROM AjustementCalcule_TransporteurEssence ACT
	INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
	INNER JOIN Livraison_Detail LD ON LD.[ID] = ACT.LivraisonDetailID
	INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
	INNER JOIN Contrat C ON C.[ID] = A.ContratID
	LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
	INNER JOIN Fournisseur F ON F.[ID] = ACT.TransporteurID
	INNER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
WHERE ((@DateDebut is null) 	or (DATEDIFF(day, @DateDebut, A.DateAjustement) >= 0))
AND ((@DateFin is null) 	or (DATEDIFF(day, @DateFin, A.DateAjustement) <= 0))
AND ((@AjustementDebut IS NULL) OR (A.[ID] >= @AjustementDebut))
AND ((@AjustementFin IS NULL) OR (A.[ID] <= @AjustementFin))	
AND	((@UsineDebut IS NULL) OR (C.[UsineID] >= @UsineDebut))
AND ((@UsineFin	IS NULL) OR (C.[UsineID] <= @UsineFin))
GROUP BY A.[DateAjustement], A.[ID], L.[ID], C.UsineID, F.[Nom], L.Sciage, E.[Description], L.Code, ACT.UniteID, M.[Description], ACT.Taux
) result

ORDER BY Date, Ajustement, Livraison, UsineID, Transporteur, Essence, UniteID, Municipalite, Taux DESC