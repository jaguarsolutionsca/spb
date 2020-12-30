

CREATE Procedure jag_ListView_Ajustement
(
	@ContratID [varchar](10) = Null
)

As

SELECT
Ajustement.[ID],
ContratID + ' - ' + Contrat.[Description] AS [Contrat],
Contrat.Annee,
Periode_Debut,
Periode_Fin,
CONVERT(varchar,DateAjustement,103) AS [Date],
Facture
FROM Ajustement
	INNER JOIN Contrat ON Contrat.[ID] = ContratID
WHERE ((@ContratID IS NULL) OR (ContratID = @ContratID))


