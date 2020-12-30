








CREATE PROCEDURE dbo.jag_GetLast_IndexationID
	(
		@ID int output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Indexation
ORDER BY [ID] desc
	
RETURN 









