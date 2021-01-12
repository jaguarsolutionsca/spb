CREATE PROCEDURE [app].[Lookup_Summary]
(
    @_uid int,
    @id int
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @out TABLE (title nvarchar(255), fileCount int not null);
INSERT @out
SELECT
    (SELECT CASE WHEN COUNT(*) > 0 THEN MAX(Description) ELSE CAST(@id AS nvarchar(255)) END FROM Lookup WHERE ID = @id) [title],
    0 [fileCount]
;
SELECT * FROM @out;
END