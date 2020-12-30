








CREATE PROCEDURE dbo.jag_GetLast_ProfileID
	(
		@ID int output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM jag_Profile
ORDER BY [nom] desc
	
RETURN



