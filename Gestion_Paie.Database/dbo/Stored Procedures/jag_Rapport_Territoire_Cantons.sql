

CREATE PROCEDURE dbo.jag_Rapport_Territoire_Cantons
	(
		@Actif bit = NULL
	)
AS

SET NOCOUNT ON

SELECT
Canton.[ID],
Canton.[Description],
(CASE WHEN ((Canton.Actif IS NULL)OR(Canton.Actif = 1)) THEN 'Actif' ELSE 'Inactif' END) AS [Statut]
FROM Canton
WHERE ((@Actif IS NULL) OR (Canton.[Actif] = @Actif))
ORDER BY Canton.[Description]


Return(@@RowCount)









