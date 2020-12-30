








CREATE PROCEDURE dbo.jag_GetNext_UniteMesureID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM UniteMesure
WHERE [ID] > @ID
ORDER BY [ID] asc

IF (NOT EXISTS (SELECT * FROM UniteMesure WHERE [ID] = @ID))
BEGIN
	exec jag_GetLast_UniteMesureID @ID out
END

RETURN 









