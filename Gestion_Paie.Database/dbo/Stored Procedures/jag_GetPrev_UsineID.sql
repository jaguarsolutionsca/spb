








CREATE PROCEDURE dbo.jag_GetPrev_UsineID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Usine
WHERE [ID] < @ID
ORDER BY [ID] desc

RETURN 









