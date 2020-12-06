CREATE PROCEDURE [app].[Account_Summary]
(
    @uid int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT
    (SELECT CASE WHEN COUNT(*) > 0 THEN MAX(Email) ELSE CAST(@uid AS nvarchar(50)) END FROM app.Account WHERE UID = @uid) [title],
    --(SELECT COUNT(*) FROM dbo.DataFile WHERE TableName = 'account' AND TableID = @id AND Archive = 0)  [fileCount]
    CAST(0 as int) [fileCount]
;
END