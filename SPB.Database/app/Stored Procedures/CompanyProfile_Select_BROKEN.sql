CREATE PROCEDURE [app].[CompanyProfile_Select_BROKEN]
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
SELECT
(
	SELECT * FROM (
		SELECT [Name], ISNULL([Value],'''') [Value] FROM Gestion_Paie.dbo.jag_SystemEx
	) t1
	PIVOT (MAX([Value]) FOR [Name] IN (' + @columns  + ')) t2
	FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
) AS [company_profile]';

DECLARE @table TABLE (p1 nvarchar(MAX), p2 nvarchar(MAX), p3 nvarchar(MAX));
INSERT INTO @table (p1)
EXEC sp_executesql @query
;
UPDATE @table SET p2 = (SELECT * FROM Gestion_Paie.dbo.jag_System FOR JSON PATH, WITHOUT_ARRAY_WRAPPER);
UPDATE @table SET p3 = REPLACE(p1 + p2, '}{"', ',"');


SELECT p3 [profileJson] FROM @table
;

END