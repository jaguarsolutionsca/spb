








CREATE PROCEDURE dbo.jag_GetNext_PermitID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Permit
WHERE [ID] > @ID
ORDER BY [ID] ASC

IF (NOT EXISTS (SELECT * FROM Permit WHERE [ID] = @ID))
BEGIN
	exec jag_GetLast_PermitID @ID out
END

RETURN 









