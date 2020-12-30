


CREATE PROCEDURE dbo.jag_GetFirst_FactureUsineID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM FactureUsine
ORDER BY [ID] ASC
	
RETURN 


