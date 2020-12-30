

CREATE PROCEDURE dbo.jag_Rapport_Territoire_MRC
	(
		@Actif bit = NULL
	)
AS

SET NOCOUNT ON

SELECT
MRC.[ID],
MRC.[Description],
(CASE WHEN ((MRC.Actif IS NULL)OR(MRC.Actif = 1)) THEN 'Actif' ELSE 'Inactif' END) AS [Statut]
FROM MRC
WHERE ((@Actif IS NULL) OR (MRC.[Actif] = @Actif))
ORDER BY MRC.[Description]

Return(@@RowCount)









