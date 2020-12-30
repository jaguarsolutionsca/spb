








CREATE PROCEDURE dbo.jag_SystemEx_SetValue
	(
		@Name varchar(50),
		@Value varchar(500)
	)
AS

IF NOT EXISTS (SELECT * FROM jag_SystemEx WHERE [Name] = @Name)
BEGIN
	INSERT INTO jag_SystemEx ([Name], [Value])
	SELECT @Name, @Value	
END
ELSE 
BEGIN
	UPDATE jag_SystemEx SET
	[Value] = @Value
	WHERE [Name] = @Name
END

--declare @cmd varchar(500)
--select @cmd = 'UPDATE jag_SystemEx SET [Value]='''+@Value+''' WHERE Name = '''+@Name+''''
--exec(@cmd)










