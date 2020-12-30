



CREATE PROCEDURE dbo.jag_GetNext_FactureUsineID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM FactureUsine
WHERE [ID] > @ID
ORDER BY [ID] ASC

IF (NOT EXISTS (SELECT * FROM FactureUsine WHERE [ID] = @ID))
BEGIN
	exec jag_GetLast_FactureUsineID @ID out
END

RETURN 


