CREATE PROCEDURE [dbo].[Equipment_Summary]
(
    @Equipmentid int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;

SELECT
    (SELECT Name FROM Equipment WHERE ID = @Equipmentid) [title],
    
    --(SELECT COUNT(*) FROM dbo.DataFile WHERE TableName = 'equipment' AND TableID = @Equipmentid AND Archive = 0) [fileCount]
    CAST(0 as int) [fileCount]
;
END