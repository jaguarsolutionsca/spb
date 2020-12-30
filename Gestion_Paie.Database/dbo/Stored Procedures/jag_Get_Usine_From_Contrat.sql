

CREATE PROCEDURE dbo.jag_Get_Usine_From_Contrat
	(
		@Annee int = NULL
	)
AS

SELECT DISTINCT
UsineID AS [ID],
Usine.[Description] AS [Description],
(CASE WHEN (Contrat.Actif = 0 OR Usine.Actif = 0) THEN CONVERT(BIT, 0) ELSE CONVERT(BIT, 1) END) AS [Actif]
FROM Contrat
	INNER JOIN Usine ON Usine.ID = UsineID
WHERE ((@Annee IS NULL) OR (Contrat.Annee = @Annee))









