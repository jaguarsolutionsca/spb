








CREATE PROCEDURE dbo.jag_ProfileSettings_GetValue
	(
		@ProfileID int,
		@Name varchar(500)
	)
AS
	
--select * from jag_SystemEx

select [Value] from jag_ProfileSettings where [Name] = @Name and [ProfileID] = @ProfileID



