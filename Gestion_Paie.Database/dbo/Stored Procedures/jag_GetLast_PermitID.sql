








CREATE PROCEDURE dbo.jag_GetLast_PermitID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Permit
ORDER BY [ID] desc
	
RETURN 









