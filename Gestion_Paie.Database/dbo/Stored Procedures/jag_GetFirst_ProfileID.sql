








CREATE PROCEDURE dbo.jag_GetFirst_ProfileID
	(
		@ID int output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM jag_Profile
ORDER BY [Nom] ASC
	
RETURN



