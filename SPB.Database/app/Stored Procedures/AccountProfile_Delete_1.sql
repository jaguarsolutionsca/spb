CREATE PROCEDURE [app].[AccountProfile_Delete]
(
    @UID int,
    @Updated datetime
)
AS
BEGIN
SET XACT_ABORT, NOCOUNT ON
;

DELETE Gestion_Paie.dbo.jag_ProfileSettings WHERE ProfileID = @UID
;

DELETE Gestion_Paie.dbo.jag_Profile WHERE ID = @UID
;

END