CREATE PROCEDURE [app].[AccountProfile_Update]
(
	@UID int,
    @json nvarchar(MAX) -- '[{"key":"AcrobatPath","value":"cheval"},{"key":"ExcelLanguage","value":"Français"}]'
)
AS
BEGIN
SET NOCOUNT ON
;

with cte as
(
	SELECT
		@uid [uid],
		[key],
		[value]
	FROM openjson(@json)
	WITH (
		[key] nvarchar(50),
		[value] nvarchar(500)
	)
)
UPDATE
	dbo.jag_ProfileSettings
SET
	dbo.jag_ProfileSettings.Value = cte.[value]
FROM
	dbo.jag_ProfileSettings ps
INNER JOIN
	cte on cte.uid = ps.ProfileID
WHERE
	cte.[key] = ps.Name
;

END