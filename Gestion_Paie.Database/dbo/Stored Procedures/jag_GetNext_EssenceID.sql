








CREATE PROCEDURE dbo.jag_GetNext_EssenceID
	(
		@ID varchar(6) output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Essence
WHERE [ID] > @ID
ORDER BY [ID] ASC

IF (NOT EXISTS (SELECT * FROM Essence WHERE [ID] = @ID))
BEGIN
	exec jag_GetLast_EssenceID @ID out
END

RETURN 









