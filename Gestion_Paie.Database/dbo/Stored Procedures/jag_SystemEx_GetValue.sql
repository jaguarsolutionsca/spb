








CREATE PROCEDURE dbo.jag_SystemEx_GetValue
	(
		@Name varchar(50)
	)
AS
	
--select * from jag_SystemEx

select [Value] from jag_SystemEx where [Name] = @Name








