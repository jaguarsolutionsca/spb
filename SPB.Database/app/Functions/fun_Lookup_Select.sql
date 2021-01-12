CREATE FUNCTION [app].[fun_Lookup_Select]
(
    @ID int
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        pt.ID,
        pt.CIE,
        lut1.Name [CIE_Text],
        pt.Groupe,
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
    LEFT OUTER JOIN Company lut1 ON lut1.CIE = pt.CIE
    INNER JOIN Account a ON a.UID = pt.UpdatedBy
    WHERE pt.ID = @ID
)