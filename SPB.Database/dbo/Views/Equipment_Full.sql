CREATE VIEW [dbo].[Equipment_Full]
AS
SELECT
    pt.ID,
    pt.StaffID,
    lut1.FirstName [StaffID_Text],
    pt.Name,
    pt.CatLUID,
    lut2.Description [CatLUID_Text],
    pt.Price,
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By]
FROM [dbo].[Equipment] pt
INNER JOIN Staff lut1 ON lut1.ID = pt.StaffID
LEFT OUTER JOIN app.Lookup lut2 ON lut2.ID = pt.CatLUID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy