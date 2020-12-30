








CREATE PROCEDURE dbo.jag_System_SetValue
	(
		@Name varchar(50),
		@Value varchar(500)
	)
	
AS

declare @Val varchar(500)
select @Val = @Value
if @Val is null
BEGIN
	select @Val = ''
END

declare @cmd varchar(600)
select @cmd = 'update jag_System SET '+@Name+' = '''+@Val+''''

exec(@cmd)

