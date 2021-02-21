CREATE PROCEDURE [dbo].[Equipment_Lookup]
AS
BEGIN
SET NOCOUNT ON
;
SELECT
    pt.ID [ID],
    pt.Name [Description]
FROM Equipment pt
WHERE pt.Archive = 0
ORDER BY pt.Name
;
END