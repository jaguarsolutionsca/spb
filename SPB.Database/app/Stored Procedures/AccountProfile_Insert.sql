CREATE PROCEDURE [app].[AccountProfile_Insert]
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
INSERT dbo.jag_ProfileSettings
SELECT
	@UID [uid],
	Description [key],
	cte.[value]
FROM app.Lookup lut
LEFT OUTER JOIN cte on cte.[key] = lut.Description
WHERE Groupe = 'PROFILE.KEY'
;

END