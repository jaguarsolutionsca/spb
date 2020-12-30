








CREATE PROCEDURE dbo.jag_Get_Comptes
	(
		@CategoryID int = NULL,
		@Actif bit = 1
	)
AS

SELECT
Compte.[ID],
Compte.Description,
CompteCategory.[Description] AS [Categorie],
Actif
FROM Compte
	INNER JOIN CompteCategory ON CompteCategory.[ID] = CategoryID
WHERE ((@Actif IS NULL) OR (Actif=@Actif))
AND ((@CategoryID IS NULL) OR (CategoryID = @CategoryID))
ORDER BY Compte.[ID]









