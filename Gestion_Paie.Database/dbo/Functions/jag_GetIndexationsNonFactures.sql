

CREATE FUNCTION dbo.jag_GetIndexationsNonFactures
	(
		@UsineID VARCHAR(6) = Null,
		@IndexationID INT = NULL
	)
RETURNS TABLE 

AS

Return
(
	SELECT TOP 100 PERCENT
	I.[ID],
	CONVERT(VARCHAR,DateIndexation,103) AS [Date],
	I.ContratID,
	C.UsineID,
	U.[Description] AS [Usine]
	FROM Indexation I
		INNER JOIN Contrat C ON C.[ID] = I.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ((I.Facture = 0) OR (I.Facture IS NULL))
	AND ((@UsineID IS NULL) OR (C.UsineID = @UsineID))
	AND ((@IndexationID IS NULL) OR (I.[ID] = @IndexationID))
	ORDER BY I.[ID]--A.ContratID, A.DateAjustement DESC

)









