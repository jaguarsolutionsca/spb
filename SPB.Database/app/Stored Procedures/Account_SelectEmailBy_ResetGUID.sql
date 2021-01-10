CREATE PROCEDURE [app].[Account_SelectEmailBy_ResetGUID]
(
    @guid uniqueidentifier,
	@isInvitation bit
)
AS
BEGIN
SET NOCOUNT ON
;

DECLARE @email nvarchar(50);
DECLARE @resetExpiry datetime;

SELECT
	@email = Email,
	@resetExpiry = ResetExpiry
FROM app.Account_Full WHERE ResetGuid = @guid
;

IF (@email IS NULL)
	IF @isInvitation = 1
	    THROW 50001, 'This invitation is invalid', 1
	ELSE
	    THROW 50001, 'Invalid account', 1
;

IF (GETDATE() > @resetExpiry)
	IF @isInvitation = 1
	    THROW 50001, 'This invitation is expired', 1
	ELSE
	    THROW 50001, 'Expired email reset', 1
;

SELECT @email [email]
;

END