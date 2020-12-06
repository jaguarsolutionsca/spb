CREATE PROCEDURE [app].[Account_AutoArchive]
(
	@cie int
)
AS
BEGIN
SET NOCOUNT ON
;

UPDATE
	app.Account
SET
	app.Account.Archive = 1
FROM
	app.Account acc
INNER JOIN
	app.Account_Full af ON af.UID = acc.UID
WHERE
	af.ReadyToArchive = 1 AND
	af.CIE = @cie
;
END