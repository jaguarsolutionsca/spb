CREATE PROCEDURE [app].[CompanyProfile_Select]
(
	@_uid int,
	@cie int
)
AS
BEGIN
SET NOCOUNT ON
;

DECLARE @columns nvarchar(MAX);
SELECT @columns = COALESCE(@columns + ',', '') + QUOTENAME([Name]) FROM Gestion_Paie.dbo.jag_SystemEx;
DECLARE @query AS nvarchar(MAX) = '
SELECT * FROM (
	SELECT [Name], ISNULL([Value],'''') [Value] FROM Gestion_Paie.dbo.jag_SystemEx
) t1
PIVOT (MAX([Value]) FOR [Name] IN (' + @columns  + ')) t2
';
EXEC sp_executesql @query
;


SELECT * FROM Gestion_Paie.dbo.jag_System;

END