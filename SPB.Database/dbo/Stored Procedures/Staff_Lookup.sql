CREATE PROCEDURE [dbo].[Staff_Lookup]
AS
BEGIN
SET NOCOUNT ON
;
SELECT
    pt.ID [ID],
    pt.Firstname [Description]
FROM Staff pt
WHERE pt.Archive = 0
ORDER BY pt.Firstname
;
END