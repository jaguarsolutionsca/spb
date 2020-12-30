








CREATE PROCEDURE dbo.jag_GetLast_EssenceID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Essence
ORDER BY [ID] desc
	
RETURN 









