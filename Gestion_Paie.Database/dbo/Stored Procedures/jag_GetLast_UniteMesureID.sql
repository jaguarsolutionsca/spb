








CREATE PROCEDURE dbo.jag_GetLast_UniteMesureID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM UniteMesure
ORDER BY [ID] desc
	
RETURN 









