



CREATE PROCEDURE dbo.jag_GetPrev_ProfileID
	(
		@ID int output,
		@Name varchar(500)
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM jag_Profile
WHERE [nom] < @Name
ORDER BY [Nom] desc

if @ID is null or @ID = 0
BEGIN
	exec jag_GetFirst_ProfileID @ID out
END

RETURN



