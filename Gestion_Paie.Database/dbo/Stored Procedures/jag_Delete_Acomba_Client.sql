

CREATE PROCEDURE dbo.jag_Delete_Acomba_Client

	(
		@ClientID varchar(6) = Null,
		@XMLPath varchar(8000) = Null
	)

AS

CREATE TABLE #temp (val VARCHAR(8000))

DECLARE @path varchar(7000)
declare @error int 
DECLARE @BatchFileName varchar(7000)
declare @BatchFile varchar(8000)
declare @Copy varchar(8000)
declare @RunBatch varchar(8000)

select 	@path = [Value] from jag_SystemEx where [Name] = 'AcombaSyncroPath'
set @path = REPLACE(@path + '\', '\\', '\')

select 	@BatchFileName = 'Client.bat'

-- Get the ID of the Deleted Row
DECLARE @ID varchar(6)
Select @ID  = @ClientID
-- Try to run sync executable
set @BatchFile = '"'+@path + 'Gestion_Paie_Process" Client Delete "' + @XMLPath + '"'
set @Copy = 'echo c: > "' + @path + @BatchFileName + '"'
exec master..xp_cmdshell @Copy
set @Copy = 'echo cd \ >> "' + @path + @BatchFileName + '"'
exec master..xp_cmdshell @Copy
set @Copy = 'echo cd "' + @path + '" >> "' + @path + @BatchFileName + '"'
exec master..xp_cmdshell @Copy
set @Copy = 'echo '+ @BatchFile +' >> "' + @path + @BatchFileName + '"'
exec master..xp_cmdshell @Copy

set @RunBatch = '"' + @path + @BatchFileName + '"'

delete from #temp
INSERT #temp exec master..xp_cmdshell @RunBatch

set @error = (select count(*) from #temp where val like '%Erreur%')
if (@error > 0)
Begin
	RAISERROR ('Erreur dans la syncronisation Acomba.  Veuillez consulter le fichier Log pour plus de détails', 17, 1)
End

RETURN


