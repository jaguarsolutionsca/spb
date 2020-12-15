CREATE PROCEDURE [app].[AccountProfile_Delete]
(
    @UID int,
    @Updated datetime
)
AS
BEGIN
SET XACT_ABORT, NOCOUNT ON
;
DELETE dbo.jag_ProfileSettings WHERE ProfileID = @UID
;
END