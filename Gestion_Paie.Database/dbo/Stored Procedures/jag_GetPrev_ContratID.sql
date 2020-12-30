








CREATE PROCEDURE dbo.jag_GetPrev_ContratID
	(
		@ID varchar(10) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Contrat
WHERE [ID] < @ID
ORDER BY [ID] desc

RETURN 









