



CREATE PROCEDURE dbo.jag_GetNext_ProfileID
	(
		@ID int output,
		@Name varchar(500)
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM jag_Profile
WHERE [Nom] > @Name
ORDER BY [Nom] ASC



if @ID is null or @ID = 0
BEGIN
	exec jag_GetLast_ProfileID @ID out
END



IF (NOT EXISTS (SELECT * FROM jag_Profile WHERE [Nom] = @Name))
BEGIN
	exec jag_GetLast_ProfileID @ID out
END

RETURN



