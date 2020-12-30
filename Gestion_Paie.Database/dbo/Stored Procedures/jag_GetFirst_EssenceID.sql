








CREATE PROCEDURE dbo.jag_GetFirst_EssenceID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Essence
ORDER BY [ID] ASC
	
RETURN 









