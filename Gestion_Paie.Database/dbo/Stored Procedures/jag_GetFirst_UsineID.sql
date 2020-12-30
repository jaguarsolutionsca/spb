








CREATE PROCEDURE dbo.jag_GetFirst_UsineID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Usine
ORDER BY [ID] ASC
	
RETURN 









