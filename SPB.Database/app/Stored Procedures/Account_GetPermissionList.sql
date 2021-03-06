﻿CREATE PROCEDURE [app].[Account_GetPermissionList]
(
    @uid int
)
AS
BEGIN
SET NOCOUNT ON
;

	declare @cie int;
	declare @roleMask int;
	select
		@cie = up.CIE,
		@roleMask = lut.Code
	from app.Account up
	inner join app.PermMeta lut on lut.ID = up.RoleLUID
	where up.UID = @uid and up.Archive = 0
	;
	with cte as
	(
		SELECT
			PermID,
			PermValue,
			CAST(CASE WHEN (PermValue & @RoleMask) <> 0 THEN 1 ELSE 0 END as bit) [valid]
		FROM app.Perm
		WHERE [CIE] = @cie
	)
	select
		PermID
	from cte
	where (valid = 1)
	;

END