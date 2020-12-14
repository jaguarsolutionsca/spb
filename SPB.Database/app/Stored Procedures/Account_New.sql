CREATE PROCEDURE [app].[Account_New]
(
	@cie int
)
AS
BEGIN
SET NOCOUNT ON
;

declare @profile TABLE ([profileJson] nvarchar(MAX));
insert @profile
exec app.AccountProfile_New @cie = @cie
;

declare @roleLUID int = app.Role_Default();


with cte as
(
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
		app.CurrentYear() [CurrentYear],
		NULL [Comment], 
		CAST(0 as bit) [Archive], 
		GETDATE() [Created], 
		GETDATE() [Updated], 
		CAST(0 as int) [UpdatedBy], 
		'' [By]
)
SELECT
	*
FROM cte
INNER JOIN @profile pro ON 1=1
;

EXEC app.AccountProfile_New @cie = @cie;

END