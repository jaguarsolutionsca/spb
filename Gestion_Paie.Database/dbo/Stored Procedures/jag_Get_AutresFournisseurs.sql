

CREATE PROCEDURE dbo.jag_Get_AutresFournisseurs
	(
		@Actif bit = Null
	)
AS

SELECT
[ID],
Nom,
Actif
FROM Fournisseur
WHERE ((@Actif IS NULL) OR (Actif=@Actif))
AND IsAutre = 1
ORDER BY [ID]


