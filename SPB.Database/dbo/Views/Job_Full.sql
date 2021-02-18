CREATE VIEW [dbo].[Job_Full]
AS
SELECT
    pt.ID,
    pt.Title,
    pt.KindLUID,
    lut1.Description [KindLUID_Text],
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By]
FROM [dbo].[Job] pt
LEFT OUTER JOIN app.Lookup lut1 ON lut1.ID = pt.KindLUID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy