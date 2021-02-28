CREATE PROCEDURE [app].[PermMeta_Lookup_Parent]
AS
BEGIN
SET NOCOUNT ON
;
SELECT
    pt.ID [ID],
    pt.Description [Description],
	'ROLE-GROUP' [Code]
FROM PermMeta pt
WHERE Groupe = 'ROLE-GROUP' AND pt.Archive = 0
UNION
SELECT
    pt.ID [ID],
    pt.Description [Description],
	'PERM-GROUP' [Code]
FROM PermMeta pt
WHERE Groupe = 'PERM-GROUP' AND pt.Archive = 0
;
END