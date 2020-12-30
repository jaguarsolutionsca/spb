








CREATE PROCEDURE dbo.jag_GetPrev_IndexationID
	(
		@ID int output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Indexation
WHERE [ID] < @ID
ORDER BY [ID] desc

RETURN 









