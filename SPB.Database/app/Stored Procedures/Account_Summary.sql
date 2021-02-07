CREATE PROCEDURE [app].[Account_Summary]
(
    @uid int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT
    (SELECT Name FROM app.Company c INNER JOIN app.Account a ON a.CIE = c.CIE WHERE a.UID = @uid) [title],
    (SELECT Email FROM app.Account WHERE UID = @uid) [subtitle],
    --(SELECT COUNT(*) FROM dbo.DataFile WHERE TableName = 'account' AND TableID = @id AND Archive = 0)  [fileCount]
    CAST(0 as int) [fileCount]
;
END