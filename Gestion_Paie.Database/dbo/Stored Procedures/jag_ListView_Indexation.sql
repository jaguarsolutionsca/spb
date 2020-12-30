

CREATE Procedure jag_ListView_Indexation
(
	@ContratID [varchar](10) = Null
)

As

SELECT
Indexation.[ID],
ContratID + ' - ' + Contrat.[Description] AS [Contrat],
Contrat.Annee,
Periode_Debut,
Periode_Fin,
CONVERT(varchar,DateIndexation,103) AS [Date],
Facture
FROM Indexation
	INNER JOIN Contrat ON Contrat.[ID] = ContratID
WHERE ((@ContratID IS NULL) OR (ContratID = @ContratID))








