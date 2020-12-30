


CREATE PROCEDURE dbo.jag_GetLast_FactureUsineID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM FactureUsine
ORDER BY [ID] desc
	
RETURN 


