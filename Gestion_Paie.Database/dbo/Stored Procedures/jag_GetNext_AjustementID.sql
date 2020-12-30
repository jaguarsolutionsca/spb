








CREATE PROCEDURE dbo.jag_GetNext_AjustementID
	(
		@ID int output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Ajustement
WHERE [ID] > @ID
ORDER BY [ID] ASC

IF (NOT EXISTS (SELECT * FROM Ajustement WHERE [ID] = @ID))
BEGIN
	exec jag_GetLast_AjustementID @ID out
END

RETURN 









