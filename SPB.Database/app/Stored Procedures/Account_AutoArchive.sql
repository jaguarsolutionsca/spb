CREATE PROCEDURE [app].[Account_AutoArchive]
(
	@cid int
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
	af.CID = @cid
;
END