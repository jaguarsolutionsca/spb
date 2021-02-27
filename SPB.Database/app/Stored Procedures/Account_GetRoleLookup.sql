CREATE PROCEDURE [app].[Account_GetRoleLookup]
(
	@uid int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT
	ID,
	Description,
	SortOrder
FROM app.PermMeta
WHERE
	Groupe = 'ROLE-ITEM' AND
	((Archive = 0) OR (app.UserIs_Support(@uid) = 1))
;
END