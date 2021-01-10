CREATE PROCEDURE [app].[Account_Delete]
(
	@_uid int,
    @UID int,
    @Updated datetime
)
AS
BEGIN
SET XACT_ABORT, NOCOUNT ON
;

IF EXISTS(
    SELECT *
    FROM app.Account
    WHERE UID = @UID AND Updated > @Updated
)
    THROW 50000, 'Concurrency Error', 1
;

IF (app.UserIs_Support(@UID) = 1 AND app.UserIs_Support(@_uid) = 0)
    THROW 50001, 'You cannot delete a support account!', 1
;

IF (@UID = @_uid)
    THROW 50001, 'You cannot delete your own account!', 1
;



DELETE app.Account WHERE UID = @UID
;

EXEC app.AccountProfile_Delete @uid=@uid, @updated=@updated
;
END