CREATE VIEW [dbo].[Office_Full]
AS
SELECT
    pt.ID,
    pt.Name,
    pt.Location,
    pt.OpenedOn,
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By]
FROM [dbo].[Office] pt
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy