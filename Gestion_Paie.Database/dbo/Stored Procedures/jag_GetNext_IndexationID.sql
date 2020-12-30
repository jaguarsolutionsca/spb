








CREATE PROCEDURE dbo.jag_GetNext_IndexationID
	(
		@ID int output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Indexation
WHERE [ID] > @ID
ORDER BY [ID] ASC

IF (NOT EXISTS (SELECT * FROM Indexation WHERE [ID] = @ID))
BEGIN
	exec jag_GetLast_IndexationID @ID out
END

RETURN 









