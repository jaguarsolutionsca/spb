CREATE PROCEDURE [dbo].[Fournisseur_Summary]
(
	@_uid int,
    @id nvarchar(15)
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @out TABLE (title nvarchar(255), fileCount int not null);
INSERT @out
SELECT
    (SELECT CASE WHEN COUNT(*) > 0 THEN MAX(Nom) ELSE CAST(@id AS nvarchar(255)) END FROM Fournisseur WHERE ID = @id) [title],
    (SELECT 0) [fileCount]
;
SELECT * FROM @out;
END
