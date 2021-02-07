CREATE PROCEDURE [dbo].[Office_Lookup]
AS
BEGIN
SET NOCOUNT ON
;
SELECT
    pt.ID [ID],
    pt.Name [Description]
FROM Office pt
WHERE pt.Archive = 0
ORDER BY pt.Name
;
END