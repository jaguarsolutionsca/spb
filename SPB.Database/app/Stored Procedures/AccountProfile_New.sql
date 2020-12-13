CREATE PROCEDURE [app].[AccountProfile_New]
(
	@cie int
)
AS
BEGIN
SET NOCOUNT ON
;

SELECT
	Description [key],
	NULL [value]
FROM app.Lookup
WHERE Groupe = 'PROFILE.KEY'
;
END