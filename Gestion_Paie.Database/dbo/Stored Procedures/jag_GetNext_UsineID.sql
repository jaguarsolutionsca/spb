








CREATE PROCEDURE dbo.jag_GetNext_UsineID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Usine
WHERE [ID] > @ID
ORDER BY [ID] asc

IF (NOT EXISTS (SELECT * FROM Usine WHERE [ID] = @ID))
BEGIN
	exec jag_GetLast_UsineID @ID out
END

RETURN 









