








CREATE PROCEDURE dbo.jag_GetLast_LivraisonID
	(
		@ID INT = NULL output
	)
AS

SET @ID = NULL

SELECT TOP 1
@ID = [ID]
FROM Livraison
ORDER BY [ID] DESC








