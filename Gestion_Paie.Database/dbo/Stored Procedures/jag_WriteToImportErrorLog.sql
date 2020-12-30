








CREATE PROCEDURE dbo.jag_WriteToImportErrorLog
(
	@str varchar(2000),
	@tablename varchar(100)
)
AS

SET NOCOUNT ON

declare @COMMAND varchar(2000)
declare @path varchar(300) 
declare @filename varchar(500)

set @path = 'c:\Syndicats\Import'
set @path = REPLACE(@path + '\', '\\', '\')

select @filename = @path + @tablename + '-errorlog.txt'

select @COMMAND = 'mkdir ' + @path
exec master..xp_cmdshell @COMMAND, NO_OUTPUT

select @COMMAND = 'echo ' + @str + ' >> ' + @filename
exec master..xp_cmdshell @COMMAND, NO_OUTPUT









