CREATE PROCEDURE [app].[Account_Update_LastActivity]
(
    @uid int,
	@lastActivity datetime
)
AS
BEGIN
SET NOCOUNT ON
;

UPDATE app.Account 
SET 
	lastActivity = @lastActivity, 
	ResetGuid = NULL, 
	ResetExpiry = NULL 
WHERE UID = @uid

END