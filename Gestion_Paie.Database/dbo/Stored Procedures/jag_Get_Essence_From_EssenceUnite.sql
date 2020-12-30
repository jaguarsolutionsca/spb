

CREATE PROCEDURE dbo.jag_Get_Essence_From_EssenceUnite
	(
		@UniteMesureID varchar(6) = NULL,
		@Actif bit = NULL
	)
AS

SELECT DISTINCT
EssenceID,
Essence.[Description] AS [EssenceDesc],
(CASE WHEN Essence_Unite.Actif = 0 OR Essence.Actif = 0 THEN CONVERT(BIT, 0) ELSE CONVERT(BIT, 1) END) AS [Actif]
FROM Essence_Unite
	INNER JOIN Essence ON Essence.[ID] = EssenceID
WHERE ((@UniteMesureID IS NULL) OR (UniteID = @UniteMesureID))
AND ((@Actif IS NULL) OR (Essence_Unite.Actif = @Actif))
ORDER BY EssenceID








