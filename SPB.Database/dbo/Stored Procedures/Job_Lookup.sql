CREATE PROCEDURE [dbo].[Job_Lookup]
AS
BEGIN
SET NOCOUNT ON
;
SELECT
    pt.ID [ID],
    pt.Title [Description]
FROM Job pt
WHERE pt.Archive = 0
ORDER BY pt.Title
;
END