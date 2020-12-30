








CREATE PROCEDURE dbo.jag_GetNext_ContratID
	(
		@ID varchar(10) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Contrat
WHERE [ID] > @ID
ORDER BY [ID] ASC

IF (NOT EXISTS (SELECT * FROM Contrat WHERE [ID] = @ID))
BEGIN
	exec jag_GetLast_ContratID @ID out
END

RETURN 









