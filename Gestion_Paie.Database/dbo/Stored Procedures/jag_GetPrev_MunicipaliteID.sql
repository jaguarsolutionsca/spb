








CREATE PROCEDURE dbo.jag_GetPrev_MunicipaliteID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Municipalite
WHERE [ID] < @ID
ORDER BY [ID] desc

RETURN 









