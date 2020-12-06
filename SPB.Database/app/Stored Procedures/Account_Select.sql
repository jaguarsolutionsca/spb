CREATE PROCEDURE [app].[Account_Select]
(
	@uid int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT
	*
FROM app.Account_Full
WHERE
	UID = @uid
;
END