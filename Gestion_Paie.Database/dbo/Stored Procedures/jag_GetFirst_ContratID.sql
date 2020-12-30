








CREATE PROCEDURE dbo.jag_GetFirst_ContratID
	(
		@ID varchar(10) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Contrat
ORDER BY [ID] ASC
	
RETURN 









