

CREATE PROCEDURE dbo.jag_Rapport_UniteMesure
	(
		@Actif bit = NULL
	)
AS

SET NOCOUNT ON

SELECT
UniteMesure.[ID],
UniteMesure.[Description],
UniteMesure.[Nb_decimale] AS [Decimales],
(CASE WHEN ((UniteMesure.Actif IS NULL)OR(UniteMesure.Actif = 1)) THEN 'Actif' ELSE 'Inactif' END) AS [Statut]
FROM UniteMesure
WHERE ((@Actif IS NULL) OR (UniteMesure.[Actif] = @Actif))
ORDER BY UniteMesure.[Description]

Return(@@RowCount)









