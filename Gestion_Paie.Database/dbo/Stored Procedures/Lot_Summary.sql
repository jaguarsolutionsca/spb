CREATE PROCEDURE [dbo].[Lot_Summary]
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
    (SELECT CASE WHEN COUNT(*) > 0 THEN MAX(CantonID +' - '+ Rang +' - '+ Lot) ELSE CAST(@id AS nvarchar(255)) END FROM Lot WHERE ID = @id) [title],
    CAST(0 as int) [fileCount]
;
SELECT * FROM @out;
END