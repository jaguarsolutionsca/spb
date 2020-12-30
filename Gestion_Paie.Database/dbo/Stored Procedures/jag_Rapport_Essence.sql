

CREATE PROCEDURE dbo.jag_Rapport_Essence
	(
		@Actif bit = NULL
	)
AS

SET NOCOUNT ON

SELECT
Essence.[ID],
Essence.[Description],
EssenceRegroupement.[Description] AS [Regroupement],
--EssenceContingent.[Description] AS [Contingent],
EssenceRepartition.[Description] AS [Repartition],
(CASE WHEN ((Essence.Actif IS NULL)OR(Essence.Actif = 1)) THEN 'Actif' ELSE 'Inactif' END) AS [Statut]
FROM Essence
	LEFT OUTER JOIN EssenceRegroupement ON EssenceRegroupement.[ID] = Essence.[RegroupementID]
--	LEFT OUTER JOIN EssenceContingent ON EssenceContingent.[ID] = Essence.[ContingentID]
	LEFT OUTER JOIN EssenceRepartition ON EssenceRepartition.[ID] = Essence.[RepartitionID]
WHERE ((@Actif IS NULL) OR (Essence.[Actif] = @Actif))
ORDER BY Essence.[Description]

Return(@@RowCount)



