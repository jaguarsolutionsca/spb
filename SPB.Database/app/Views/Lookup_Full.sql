CREATE VIEW [app].[Lookup_Full]
AS
SELECT
    pt.ID,
    pt.CIE,
    lut1.Name [CIE_Text],
    pt.Groupe,
    lut2.Description [Groupe_Text],
    pt.ParentGroupe,
    lut3.Description [ParentGroupe_Text],
    pt.Code,
    pt.Description,
    pt.Value1,
    pt.Value2,
    pt.Value3,
    pt.Started,
    pt.Ended,
    pt.SortOrder,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By]
FROM [app].[Lookup] pt
LEFT OUTER JOIN app.Company lut1 ON lut1.CIE = pt.CIE
INNER JOIN app.LookupGroupe lut2 ON lut2.ID = pt.Groupe
LEFT OUTER JOIN app.LookupGroupe lut3 ON lut3.ID = pt.ParentGroupe
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy