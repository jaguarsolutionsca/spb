CREATE PROCEDURE [app].[Account_New]
(
	@_uid int,
	@cie int
)
AS
BEGIN
SET NOCOUNT ON
;

declare @roleLUID int = app.Role_Default();


SELECT
	NULL [UID], 
	@cie [CIE], 
	(select Name from app.Company where CIE = @cie) [CIE_Text],
	NULL [Email], 
	NULL [Password],
	@roleLUID [RoleLUID], 
	(select Description from app.PermMeta where ID = @roleLUID) [RoleLUID_Text],
	(select Code from app.PermMeta where ID = @roleLUID) [roleMask],
	CAST(0 as bit) [IsSupport],
	NULL [ResetGuid], 
	NULL [ResetExpiry], 
	NULL [LastActivity], 
	CAST(0 as bit) [IsAdminReset], 
	NULL [FirstName], 
	NULL [LastName], 
	CAST(1 as bit) [UseRealEmail], 
	NULL [ArchiveDays], 
	CAST(0 as bit) [ReadyToArchive],
	CAST(0 as bit) [CanExtendInvitation],
	CAST(0 as bit) [canResetPassword],
	CAST(0 as bit) [canCreateInvitation],
	app.CurrentYear() [CurrentYear],
	NULL [Comment], 
	CAST(0 as bit) [Archive], 
	GETDATE() [Created], 
	GETDATE() [Updated], 
	@_uid [UpdatedBy], 
	(SELECT Email FROM app.Account WHERE UID = @_uid) [By]
;

EXEC app.AccountProfile_New @cie = @cie;

END