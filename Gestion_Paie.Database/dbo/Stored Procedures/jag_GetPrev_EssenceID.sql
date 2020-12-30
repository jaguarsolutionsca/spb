








CREATE PROCEDURE dbo.jag_GetPrev_EssenceID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Essence
WHERE [ID] < @ID
ORDER BY [ID] desc

RETURN 









