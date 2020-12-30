

CREATE FUNCTION dbo.jag_GetAjustementsNonFactures
	(
		@UsineID VARCHAR(6) = Null,
		@AjustementID INT = Null
	)
RETURNS TABLE 

AS

Return
(
	SELECT TOP 100 PERCENT
	A.[ID],
	CONVERT(VARCHAR,DateAjustement,103) AS [Date],
	A.ContratID,
	C.UsineID,
	U.[Description] AS [Usine]
	FROM Ajustement A
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ((A.Facture = 0) OR (A.Facture IS NULL))
	AND ((@UsineID IS NULL) OR (C.UsineID = @UsineID))
	AND ((@AjustementID IS NULL) OR (A.[ID] = @AjustementID))
	ORDER BY A.[ID]--A.ContratID, A.DateAjustement DESC

)









