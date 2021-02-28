CREATE VIEW [app].[PermMeta_Full]
AS
SELECT
    pt.ID,
    pt.Groupe,
    pt.Groupe [Groupe_Text],
    pt.Code,
    pt.Description,
    pt.ParentID,
    lut2.Description [ParentID_Text],
    pt.SortOrder,
    pt.[Key],
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By]
FROM [app].[PermMeta] pt
LEFT OUTER JOIN app.PermMeta lut2 ON lut2.ID = pt.ParentID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy