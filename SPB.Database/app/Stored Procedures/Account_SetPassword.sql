CREATE PROCEDURE [app].[Account_SetPassword]
(
    @email nvarchar(128),
	@password nvarchar(128)
)
AS
BEGIN
SET NOCOUNT ON
;
UPDATE app.Account
SET Password = @password
WHERE EMail = @email
;
END