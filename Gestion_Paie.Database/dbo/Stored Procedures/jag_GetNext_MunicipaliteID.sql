








CREATE PROCEDURE dbo.jag_GetNext_MunicipaliteID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Municipalite
WHERE [ID] > @ID
ORDER BY [ID] asc

IF (NOT EXISTS (SELECT * FROM Municipalite WHERE [ID] = @ID))
BEGIN
	exec jag_GetLast_MunicipaliteID @ID out
END

RETURN 









