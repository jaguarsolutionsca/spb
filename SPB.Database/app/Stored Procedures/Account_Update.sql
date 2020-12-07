CREATE PROCEDURE [app].[Account_Update]
(
    @UID int,
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
    @Updated datetime,
    @UpdatedBy int
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS(
    SELECT *
    FROM app.Account
    WHERE UID = @UID AND Updated > @Updated
)
    THROW 50000, 'Concurrency Error', 1
;

--
-- Make sure the update is not going to create a duplicate email in company
--
IF EXISTS(
	select * from app.Account
	where CIE = @cie and EMail = @email and UID <> @UID and Archive <> @Archive
)
THROW 50001, 'Email already exists in company', 1


UPDATE app.Account
SET
	[CIE] = @cie,
	[Email] = @email,
	[Password] = CASE WHEN @UseRealEmail = 0 THEN ISNULL(@Password, Password) ELSE Password END,
	[RoleLUID] = @RoleLUID,
	[ResetGuid] = @ResetGuid,
	[ResetExpiry] = @ResetExpiry,
	--[IsAdminReset] = @IsAdminReset, --never updated here
	[FirstName] = @FirstName,
	[LastName] = @LastName,
	[UseRealEmail] = @UseRealEmail,
	[ArchiveDays] = @ArchiveDays,
	[CurrentYear] = @CurrentYear,
	[Comment] = @Comment,
	[Archive] = @Archive,
	[Updated] = GETDATE(),
	[UpdatedBy] = @UpdatedBy
WHERE UID = @uid
;
END