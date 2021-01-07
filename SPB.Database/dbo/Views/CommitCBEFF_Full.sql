
CREATE VIEW [dbo].[CommitCBEFF_Full]
AS

SELECT
    pt.ID,
    pt.Year,
    pt.RegionLUID,
    lut1.Description [RegionLUID_Text],
    pt.Details,
    pt.MonthPaid,
    pt.Paid,
    pt.Amount,
    pt.Comment,
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By]
FROM [dbo].[CommitCBEFF] pt
INNER JOIN app.Lookup lut1 ON lut1.ID = pt.RegionLUID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy