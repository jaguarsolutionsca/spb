








CREATE PROCEDURE dbo.jag_GetFirst_AjustementID
	(
		@ID int output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Ajustement
ORDER BY [ID] ASC
	
RETURN 









