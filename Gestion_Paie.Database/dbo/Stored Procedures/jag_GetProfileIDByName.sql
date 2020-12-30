



CREATE PROCEDURE dbo.jag_GetProfileIDByName
	(
		@ID int output,
		@Name varchar(500)
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM jag_Profile
WHERE [Nom] = @Name

select @ID = 0

RETURN



