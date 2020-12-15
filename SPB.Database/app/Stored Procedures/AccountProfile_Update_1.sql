CREATE PROCEDURE [app].[AccountProfile_Update]
(
	@UID int,
    @json nvarchar(MAX) -- '{"AcrobatPath":"123","AutresRapportsPrinterMarginBottom":"3","AutresRapportsPrinterMarginLeft":"40"}'
)
AS
BEGIN
SET NOCOUNT ON
;

declare @table TABLE ([uid] int, [key] nvarchar(50), [value] nvarchar(500));

INSERT @table
SELECT
	@uid [uid],
	[key],
	[value]
FROM openjson(@json)
;

UPDATE
	dbo.jag_ProfileSettings
SET
	dbo.jag_ProfileSettings.Value = cte.[value]
FROM
	dbo.jag_ProfileSettings ps
INNER JOIN
	@table cte on cte.uid = ps.ProfileID
WHERE
	cte.[key] = ps.Name
;

END