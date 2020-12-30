



CREATE PROCEDURE dbo.jag_GetPrev_FactureUsineID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM FactureUsine
WHERE [ID] < @ID
ORDER BY [ID] desc

RETURN 


