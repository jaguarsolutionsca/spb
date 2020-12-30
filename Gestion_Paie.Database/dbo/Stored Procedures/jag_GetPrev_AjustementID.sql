








CREATE PROCEDURE dbo.jag_GetPrev_AjustementID
	(
		@ID int output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Ajustement
WHERE [ID] < @ID
ORDER BY [ID] desc

RETURN 









