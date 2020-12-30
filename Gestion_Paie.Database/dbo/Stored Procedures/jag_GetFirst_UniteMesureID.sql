








CREATE PROCEDURE dbo.jag_GetFirst_UniteMesureID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM UniteMesure
ORDER BY [ID] ASC
	
RETURN 









