CREATE PROCEDURE [app].[Account_Select]
(
	@_uid int,
	@uid int
)
AS
BEGIN
SET NOCOUNT ON
;

SELECT * FROM app.Account_Full WHERE UID = @uid;

EXEC app.AccountProfile_Select @_uid=@_uid, @uid=@uid;

END