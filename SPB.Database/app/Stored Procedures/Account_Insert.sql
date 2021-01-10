CREATE PROCEDURE [app].[Account_Insert]
(
	@_uid int,
	@CIE int,
    @Email nvarchar(128),
	@Password nvarchar(50) NULL,
	@RoleLUID int,
    @ResetGuid uniqueidentifier NULL,
    @ResetExpiry datetime NULL,
    @FirstName nvarchar(128),
    @LastName nvarchar(128),
	@UseRealEmail bit,
	@ArchiveDays int NULL,
	@CurrentYear int NULL,
	@Comment nvarchar(1024),
    @Archive bit,
	@ProfileJson nvarchar(MAX)
)
AS
BEGIN
SET NOCOUNT ON
;

--
-- Make sure we're not going to create a duplicate email in company
--
IF EXISTS(
	select * from app.Account
	where CIE = @cie and EMail = @email and Archive = 0
)
THROW 50001, 'Email already exists in company', 1


INSERT app.Account
([CIE],[Email],[Password],[RoleLUID],[ResetGuid],[ResetExpiry],[FirstName],[LastName],[UseRealEmail],[ArchiveDays],[CurrentYear],[Comment],[Archive],[Created],[Updated],[UpdatedBy])
VALUES (
	@cie,
	@email,
	@Password,
	@RoleLUID,
	@ResetGuid,
	@ResetExpiry,
	@FirstName,
	@LastName,
	@UseRealEmail,
	@ArchiveDays,
	@CurrentYear,
	@Comment,
	@Archive,
	GETDATE(),
	GETDATE(),
	@_uid
);
DECLARE @uid int = (SELECT CAST(SCOPE_IDENTITY() as int));

EXEC app.AccountProfile_Insert @uid = @uid, @json = @ProfileJson;

SELECT @uid;
END