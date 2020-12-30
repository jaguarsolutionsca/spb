








CREATE PROCEDURE dbo.jag_GetLast_MunicipaliteID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Municipalite
ORDER BY [ID] desc
	
RETURN 









