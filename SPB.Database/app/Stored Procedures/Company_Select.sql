CREATE PROCEDURE [app].[Company_Select]
(
	@_uid int,
	@cie int
)
AS
BEGIN
SET NOCOUNT ON
;


--
-- For some obscure reason I will get "An INSERT EXEC statement cannot be nested" error when retrieving the company [profileJson] using app.CompanyProfile_Select like so:
--
--		declare @profile TABLE ([profileJson] nvarchar(MAX));
--		insert @profile
--		exec app.CompanyProfile_Select @_uid=@_uid, @cie=@cie
--
-- To get rid of the error, I'm executing the code for [app].[CompanyProfile_Select] right here instead.
-- This will have to be fixed at some point later because it's ugly and there shouldn't be any direct reference to [Gestion_Paie] objects here.
--
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



--
-- (back to normal)
--
SELECT
	c.*,
	cp.p3 [company_profile]
FROM app.Company c
INNER JOIN @table cp ON 1=1
;

END