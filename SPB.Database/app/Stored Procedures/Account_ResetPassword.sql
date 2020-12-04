CREATE PROCEDURE [app].[Account_ResetPassword]
(
    @email nvarchar(128),
	@guid uniqueidentifier,
	@expiry datetime,
	@isAdminReset bit,
	@unArchive bit
)
AS
BEGIN
SET NOCOUNT ON
;

UPDATE app.Account 
SET 
	Password = NULL, 
	ResetGuid = @guid, 
	ResetExpiry = @expiry, 
	IsAdminReset = @isAdminReset, 
	Archive = CAST(CASE WHEN @unArchive = 1 THEN 0 ELSE Archive END AS bit)
WHERE Email = @email

END