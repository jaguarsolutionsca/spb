








CREATE PROCEDURE dbo.jag_ProfileSettings_SetValue
	(
		@ProfileID int,
		@Name varchar(500),
		@Value varchar(500)
	)
AS

IF NOT EXISTS (SELECT * FROM jag_ProfileSettings WHERE [Name] = @Name and [ProfileID] = @ProfileID)
BEGIN
	INSERT INTO jag_ProfileSettings ([ProfileID], [Name], [Value])
	SELECT @ProfileID, @Name, @Value
END
ELSE 
BEGIN
	UPDATE jag_ProfileSettings SET
	[Value] = @Value
	WHERE [Name] = @Name and [ProfileID] = @ProfileID
END



