CREATE PROCEDURE [app].[PermMeta_Lookup_Groupe]
AS
BEGIN
SET NOCOUNT ON
;
SELECT
    DISTINCT(pt.Groupe) [ID],
    pt.Groupe [Description]
FROM PermMeta pt
WHERE pt.Archive = 0
ORDER BY pt.Groupe
;
END