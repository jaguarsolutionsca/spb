CREATE PROCEDURE [app].[Account_Delete]
(
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

DELETE app.Account WHERE UID = @UID
;
EXEC app.AccountProfile_Delete @uid=@uid, @updated=@updated
;
END