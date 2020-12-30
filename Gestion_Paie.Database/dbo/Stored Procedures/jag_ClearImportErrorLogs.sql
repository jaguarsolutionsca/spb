








CREATE PROCEDURE dbo.jag_ClearImportErrorLogs
AS

SET NOCOUNT ON

declare @COMMAND varchar(2000)
declare @path varchar(300) 

set @path = 'c:\Syndicats\Import'
set @path = REPLACE(@path + '\', '\\', '\')

select @COMMAND = 'del ' + @path + '*-errorlog.txt'
exec master..xp_cmdshell @COMMAND, NO_OUTPUT










