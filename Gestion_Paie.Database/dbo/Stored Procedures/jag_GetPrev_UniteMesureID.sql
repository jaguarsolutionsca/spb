








CREATE PROCEDURE dbo.jag_GetPrev_UniteMesureID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM UniteMesure
WHERE [ID] < @ID
ORDER BY [ID] desc

RETURN 









