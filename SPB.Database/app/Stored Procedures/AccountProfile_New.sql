CREATE PROCEDURE [app].[AccountProfile_New]
(
	@cie int
)
AS
BEGIN
SET NOCOUNT ON
;

SELECT
(
	SELECT
		Description [key],
		NULL [value]
	FROM app.Lookup
	WHERE Groupe = 'PROFILE.KEY'
	FOR JSON AUTO
) AS [account_profile]
;

END