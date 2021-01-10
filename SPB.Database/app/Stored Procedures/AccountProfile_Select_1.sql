CREATE PROCEDURE [app].[AccountProfile_Select]
(
	@uid int
)
AS
BEGIN
SET NOCOUNT ON
;

DECLARE @columns nvarchar(MAX);
SELECT @columns = COALESCE(@columns + ',', '') + QUOTENAME([Description]) FROM app.lookup where Groupe='PROFILE.KEY';

DECLARE @query AS nvarchar(MAX) =
'
SELECT * FROM (
	SELECT [Name], ISNULL([Value],'''') [Value] FROM Gestion_Paie.dbo.jag_ProfileSettings WHERE ProfileID = '+ CAST(@uid as varchar(8)) +'
) t1
PIVOT (MAX([Value]) FOR [Name] IN (' + @columns  + ')) t2
';

EXEC sp_executesql @query;

END