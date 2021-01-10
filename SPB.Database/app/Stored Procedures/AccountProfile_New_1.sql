CREATE PROCEDURE [app].[AccountProfile_New]
(
	@cie int
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
	SELECT [Description], '''' [Value] FROM app.Lookup WHERE Groupe = ''PROFILE.KEY''
) t1
PIVOT (MAX([Value]) FOR [Description] IN (' + @columns  + ')) t2
';

EXEC sp_executesql @query;

END