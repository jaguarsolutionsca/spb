








CREATE PROCEDURE dbo.jag_GetLast_UsineID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Usine
ORDER BY [ID] desc
	
RETURN 









