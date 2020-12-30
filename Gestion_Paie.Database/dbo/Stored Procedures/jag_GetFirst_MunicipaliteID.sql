








CREATE PROCEDURE dbo.jag_GetFirst_MunicipaliteID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Municipalite
ORDER BY [ID] ASC
	
RETURN 









