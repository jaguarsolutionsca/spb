

CREATE PROCEDURE dbo.jag_Update_Preleves
	(
		@UniteID VARCHAR(6) = NULL
	)
AS

SET NOCOUNT ON

UPDATE Essence_Unite SET
UseMontant = (SELECT UseMontant FROM UniteMesure WHERE [ID] = [UniteID])
WHERE Preleve_plan_conjoint_Override = 0
AND ((@UniteID IS NULL) OR ([UniteID] = @UniteID))

UPDATE Essence_Unite SET
Preleve_plan_conjoint = (SELECT (CASE WHEN (UseMontant = 1) THEN Montant_Preleve_plan_conjoint ELSE Pourc_Preleve_plan_conjoint END) FROM UniteMesure WHERE [ID] = [UniteID])
WHERE Preleve_plan_conjoint_Override = 0
AND ((@UniteID IS NULL) OR ([UniteID] = @UniteID))

UPDATE Essence_Unite SET
Preleve_fond_roulement = (SELECT (CASE WHEN (UseMontant = 1) THEN Montant_Preleve_fond_roulement ELSE Pourc_Preleve_fond_roulement END) FROM UniteMesure WHERE [ID] = [UniteID])
WHERE Preleve_fond_roulement_Override = 0
AND ((@UniteID IS NULL) OR ([UniteID] = @UniteID))

UPDATE Essence_Unite SET
Preleve_fond_forestier = (SELECT (CASE WHEN (UseMontant = 1) THEN Montant_Preleve_fond_forestier ELSE Pourc_Preleve_fond_forestier END) FROM UniteMesure WHERE [ID] = [UniteID])
WHERE Preleve_fond_forestier_Override = 0
AND ((@UniteID IS NULL) OR ([UniteID] = @UniteID))

UPDATE Essence_Unite SET
Preleve_divers = (SELECT (CASE WHEN (UseMontant = 1) THEN Montant_Preleve_divers ELSE Pourc_Preleve_divers END) FROM UniteMesure WHERE [ID] = [UniteID])
WHERE Preleve_divers_Override = 0
AND ((@UniteID IS NULL) OR ([UniteID] = @UniteID))

