

CREATE PROCEDURE dbo.jag_Get_Unite_From_EssenceUnite
	(
		@EssenceID varchar(6) = NULL,
		@Actif bit = NULL
	)
AS

SELECT DISTINCT
UniteID AS [UniteMesureID],
UniteMesure.[Description] AS [UniteMesureDesc],
(CASE WHEN Essence_Unite.Actif = 0 OR UniteMesure.Actif = 0 THEN CONVERT(BIT, 0) ELSE CONVERT(BIT, 1) END) AS [Actif]
FROM Essence_Unite
	INNER JOIN UniteMesure ON UniteMesure.[ID] = UniteID
WHERE ((@EssenceID IS NULL) OR (EssenceID = @EssenceID))
AND ((@Actif IS NULL) OR (Essence_Unite.Actif = @Actif))
ORDER BY UniteID








