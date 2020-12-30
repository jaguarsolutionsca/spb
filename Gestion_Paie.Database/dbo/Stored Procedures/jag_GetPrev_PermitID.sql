








CREATE PROCEDURE dbo.jag_GetPrev_PermitID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Permit
WHERE [ID] < @ID
ORDER BY [ID] desc

RETURN 









