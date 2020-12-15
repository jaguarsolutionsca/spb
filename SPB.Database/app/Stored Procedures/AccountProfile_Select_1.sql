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
SELECT
(
	SELECT * FROM (SELECT [Name], ISNULL([Value],'''') [Value] FROM dbo.jag_ProfileSettings WHERE ProfileID = '+ CAST(@uid as varchar(8)) +') t1
	PIVOT (MAX([Value]) FOR [Name] IN (' + @columns  + ')) t2
	FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
) AS [account_profile]
';

EXEC sp_executesql @query;

END