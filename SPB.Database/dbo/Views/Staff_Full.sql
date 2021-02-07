
CREATE VIEW [dbo].[Staff_Full]
AS
SELECT
    pt.ID,
    pt.FirstName,
    pt.LastName,
    pt.OfficeID,
    lut1.Name [OfficeID_Text],
    pt.JobID,
    lut2.Title [JobID_Text],
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By]
FROM [dbo].[Staff] pt
LEFT OUTER JOIN Office lut1 ON lut1.ID = pt.OfficeID
LEFT OUTER JOIN Job lut2 ON lut2.ID = pt.JobID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy