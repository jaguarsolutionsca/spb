








CREATE PROCEDURE dbo.jag_System_GetValue
	(
		@Name varchar(50)
	)
AS

--select * from jag_System

declare @cmd varchar(500)
select @cmd = 'select '+@Name+' from jag_System'
	
exec(@cmd)








