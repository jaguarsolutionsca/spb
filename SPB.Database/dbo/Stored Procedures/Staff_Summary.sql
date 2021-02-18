CREATE PROCEDURE [dbo].[Staff_Summary]
(
    @Staffid int = NULL,
    @Equipmentid int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
IF (@Equipmentid IS NOT NULL)
    SELECT @Staffid = StaffID FROM Equipment WHERE ID = @Equipmentid;

SELECT
    (SELECT Firstname FROM Staff WHERE ID = @Staffid) [title],
    (SELECT COUNT(*) FROM Equipment WHERE StaffID = @Staffid) [EquipmentCount],
    --(SELECT COUNT(*) FROM dbo.DataFile WHERE TableName = 'staff' AND TableID = @Staffid AND Archive = 0) [fileCount]
    CAST(0 as int) [fileCount]
;
END