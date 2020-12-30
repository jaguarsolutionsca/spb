








CREATE PROCEDURE dbo.jag_GetLast_AjustementID
	(
		@ID int output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Ajustement
ORDER BY [ID] desc
	
RETURN 









