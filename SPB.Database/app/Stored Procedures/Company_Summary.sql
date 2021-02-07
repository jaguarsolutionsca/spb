CREATE PROCEDURE [app].[Company_Summary]
(
    @_uid int,
    @cie int
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @out TABLE (title nvarchar(255), fileCount int not null);
INSERT @out
SELECT
    (SELECT Name FROM app.Company WHERE CIE = @cie) [title],
    CAST(0 as int) [fileCount]
;
SELECT * FROM @out;
END