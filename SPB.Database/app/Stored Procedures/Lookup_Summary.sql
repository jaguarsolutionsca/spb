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
SELECT (
		SELECT 
			CASE WHEN COUNT(*) > 0 THEN MAX(lut.Description +': '+ pt.Description) ELSE CAST(@id AS nvarchar(255)) END 
		FROM Lookup pt
		INNER JOIN app.Lookup lut ON lut.Code = pt.Groupe
		WHERE pt.ID = @id
	) [title],
    0 [fileCount]
;
SELECT * FROM @out;
END